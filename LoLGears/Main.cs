using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Be.Timvw.Framework.ComponentModel;
using LoLGears.Properties;
using Pietschsoft;

namespace LoLGears
{
  public partial class Main : Form
  {
    public class SummonerRow
    {
      public string Name { get; set; }
      public int Games { get; set; }
    }

    public class GameStats
    {
      public GameStats(LogData log) {
        id = log.id;
        Date = log.GameStartDate;
        Map = log.Map;
        Length = log.GameLength;

        if (log.Spectated) {
          Player = "(Spectator)";
        } else if (log.PlayerName == "") {
          Player = "(Unknown)";
        } else {
          Player = log.PlayerName;
        }

        Server = log.Server;
        BlueTeam = String.Join(", ", log.BlueTeam.Select((x) => x.Name).ToArray());
        PurpleTeam = String.Join(", ", log.PurpleTeam.Select((x) => x.Name).ToArray());

        if (log.Spectated) {
          Result = "(Spectated)";
        } else {
          Result = log.ExitCode.ToString().ToLower();
          Result = Result.Substring(0, 1).ToUpper() + Result.Substring(1);
          if (Result == "Unknown") {
            Result = "(" + Result + ")";
          } else if (log.BotGame) {
            Result += " (vs AI)";
          }
        }
      }

      public long id;
      public DateTime Date { get; set; }
      public string Server { get; set; }
      public string Map { get; set; }
      public string Player { get; set; }
      public string BlueTeam { get; set; }
      public string PurpleTeam { get; set; }
      public int Length { get; set; }
      public string Result { get; set; }
    }

    private LogDatabase database;
    private List<LogData> logData;
    private SortableBindingList<SummonerStats> summonerData;
    private SortableBindingList<GameStats> gameData;
    private Dictionary<string, SummonerStats> summoners;
    private int visibleWins, visibleLosses;

    public Main() {
      InitializeComponent();

      gameTable.ColumnHeadersBorderStyle = Util.ProperColumnHeadersBorderStyle;
      summonerTable.ColumnHeadersBorderStyle = Util.ProperColumnHeadersBorderStyle;

      LoadLogFiles();
      CheckForUpdates();
    }

    private void CheckForUpdates() {
      string changelogUrl = "https://raw.github.com/hansonw/LoLGears/master/CHANGELOG.txt";
      string downloadUrl = "https://raw.github.com/hansonw/LoLGears/master/download/LoLGears.zip";

      HttpWebRequest request;
      try {
        request = (HttpWebRequest) WebRequest.Create(changelogUrl);
      } catch (Exception ex) {
        Logger.LogException(ex);
        return;
      }

      Action updateAction = () => {
        request.BeginGetResponse(result => {
          try {
            var response = (HttpWebResponse) request.EndGetResponse(result);
            if (response.StatusCode == HttpStatusCode.OK) {
              var reader = new StreamReader(response.GetResponseStream());
              var latestVersion = new Version(reader.ReadLine());
              if (latestVersion > new Version(Application.ProductVersion)) {
                var dialogResult = MessageBox.Show("A new version of LoLGears (" + latestVersion + ") is available.\n" +
                                                   "Would you like to download it now?",
                                                   "Update available", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                  Process.Start(downloadUrl);
                }
              }
            }
          } catch (WebException) {
            // Can't reach the server. Just try again later
          } catch (Exception ex) {
            Logger.LogException(ex);
          }
        }, request);
      };

      updateAction.BeginInvoke(updateAction.EndInvoke, updateAction);
    }

    public void OpenSummonerDetails(string summonerName) {
      if (summoners != null && summoners.ContainsKey(summonerName)) {
        new SummonerDetails(summoners[summonerName], logData, this).Show();
      }
    }

    public void SearchSummoner(string summonerName, string champion = null, string type = "") {
      ResetForm();
      if (champion != null) {
        summonerSearch.Text = summonerName + ":" + Util.Sanitize(champion);
      } else {
        switch (type) {
          case "as":
            summonerSearch.Text = "@" + summonerName;
            break;
          case "with":
            summonerSearch.Text = "@," + summonerName;
            break;
          case "against":
            summonerSearch.Text = "@|" + summonerName;
            break;
          case "spec":
            summonerSearch.Text = summonerName + "#spec";
            break;
          default:
            summonerSearch.Text = "^" + summonerName + "$";
            break;
        }
      }
      tabControl.SelectedTab = gamesPage;

      ReloadGameTable();
      gameTable.Select();
    }

    private string FindLogDirectory() {
      string lolDir = (string)Settings.Default["LoLDirectory"];
      while (!File.Exists(Path.Combine(lolDir, "lol.launcher.exe"))) {
        var result = MessageBox.Show("Could not find your LoL folder. Please locate your LoL launcher (lol.launcher.exe).\n" +
                                     "Usually, it's in a folder named Riot Games\\League of Legends.",
                                     "Locate LoL Directory", MessageBoxButtons.OKCancel);
        if (result == DialogResult.OK) {
          var file = new OpenFileDialog();
          file.InitialDirectory = Path.GetPathRoot(Directory.GetCurrentDirectory());
          file.Filter = "LoL Launcher|lol.launcher.exe";
          result = file.ShowDialog();
          if (result == DialogResult.OK) {
            lolDir = Path.GetDirectoryName(file.FileName);
            Settings.Default["LoLDirectory"] = lolDir;
            Settings.Default.Save();
          } else {
            return null;
          }
        } else {
          return null;
        }
      }

      string dir = Path.Combine(lolDir, "Logs\\Game - R3d Logs");
      if (!Directory.Exists(dir)) {
        MessageBox.Show("You don't seem to have any game logs - cannot generate statistics. Sorry!");
        return null;
      }
      return dir;
    }

    private void LoadLogFiles() {
      var logDirectory = FindLogDirectory();
      if (logDirectory == null) {
        Environment.Exit(1);
      }

      database = new LogDatabase();

      var pd = new ProgressDialog(this.Handle);
      pd.Title = "Loading logs...";
      pd.CancelMessage = "Please wait while the operation is cancelled...";
      pd.Maximum = 100;
      pd.Value = 0;
      pd.Line1 = "Loading LoLGears...";
      pd.Line2 = "Loading new logs...";
      pd.Line3 = "This may take a while. Please be patient..";

      pd.ShowDialog(ProgressDialog.PROGDLG.Modal, ProgressDialog.PROGDLG.AutoTime, ProgressDialog.PROGDLG.NoMinimize);

      var bg = new BackgroundWorker();
      bg.WorkerReportsProgress = true;
      bg.WorkerSupportsCancellation = true;
      bg.DoWork += (sender, e) => {
        database.Load(logDirectory, sender as BackgroundWorker);
        Invoke(new Action(() => pd.Line2 = "Loading statistics..."));
        LoadData();
      };
      bg.ProgressChanged += (sender, e) => {
        if (pd.HasUserCancelled) {
          bg.CancelAsync();
        }
        var status = e.UserState as int[];
        int tick = status[1]/100;
        if (tick == 0) tick = 1;
        if (status[0]%tick == 0) {
          pd.Value = (uint) e.ProgressPercentage;
        }
        pd.Line2 = String.Format("Loading new logs... ({0}/{1})", status[0], status[1]);
      };
      bg.RunWorkerCompleted += (sender, e) => {
        pd.CloseDialog();
        // Bring to front; closing the dialog seems to send the window to the back.
        TopMost = true;
        TopMost = false;
      };
      bg.RunWorkerAsync();
    }

    private void LoadData() {
      Invoke(new Action(Show));

      logData = database.Select();
      Invoke(new Action(() => {
        gameTable.DataSource = gameData = new SortableBindingList<GameStats>(logData.Select(log => new GameStats(log)));
        gameData.SetDefaultDirection("Date", -1);
      }));

      summoners = new Dictionary<string, SummonerStats>();
      foreach (var row in logData) {
        foreach (var x in row.BlueTeam.Concat(row.PurpleTeam)) {
          if (!x.IsBot && (!row.BotGame || !x.Name.EndsWith(" Bot"))) {
            var key = x.Name;
            // Is this someone on a different server?
            if (summoners.ContainsKey(x.Name) && !String.IsNullOrEmpty(row.Server) && !String.IsNullOrEmpty(summoners[x.Name].Server)) {
              if (row.Server != summoners[x.Name].Server) {
                key = x.Name + "_" + row.Server;
              }
            }
            if (!summoners.ContainsKey(key)) {
              summoners[key] = new SummonerStats(x.Name);
            }
            summoners[key].AddGame(row);
          }
        }
      }

      Invoke(new Action(() => {
        summonerTable.DataSource = summonerData = new SortableBindingList<SummonerStats>(summoners.Values.OrderByDescending(x => x.Games));
        summonerData.SetDefaultDirection("Games", -1);
        summonerData.SetDefaultDirection("PlayedWith", -1);
        summonerData.SetDefaultDirection("PlayedVs", -1);
        summonerData.SetDefaultDirection("KnownWins", -1);
        summonerData.SetDefaultDirection("KnownLosses", -1);
      }));
    }

    private void summonerTableCellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
      if (summonerTable.Columns[e.ColumnIndex].Name == "Name") {
        var stats = summonerData[e.RowIndex];
        if (stats.GamesAs > 0) {
          e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
        }
      } else if (summonerTable.Columns[e.ColumnIndex].Name == "WinRate") {
        var value = (double) e.Value;
        if (value == -1) {
          e.Value = "";
        } else {
          e.Value = value.ToString("#0.#") + '%';
        }
      }
    }

    private void gameTableCellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
      if (gameTable.Columns[e.ColumnIndex].Name == "Length") {
        var length = (int) e.Value;
        e.Value = String.Format("{0}:{1:d2}", length/60, length%60);
      }
    }

    private void tabSelected(object sender, TabControlEventArgs e) {
      if (e.TabPage == summonerPage) {
        summonerTable.Select();
      } else if (e.TabPage == gamesPage) {
        gameTable.Select();
      }
    }

    private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
      var table = sender as DataGridView;

      table.Columns[table.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

      foreach (DataGridViewColumn column in table.Columns) {
        // change HeaderLikeThis to Header Like This
        column.HeaderText = Regex.Replace(column.HeaderText, "([a-z])([A-Z])", "$1 $2");
      }

      if (table.Name == "gameTable") {
        // Set widths manually; autofill is _really_ slow.
        table.Columns["Date"].Width = 125;
        table.Columns["Server"].Width = 50;
        visibleWins = visibleLosses = 0;
        foreach (var game in gameData) {
          if (game.Result == "Win") {
            visibleWins++;
          } else if (game.Result == "Lose") {
            visibleLosses++;
          }
        }
      } else {
        table.Columns["Name"].Width = 200;
      }
    }

    private void gameTableCellChange(object sender, EventArgs e) {
      UpdateCounter();
    }

    private bool TeamSatisfies(string player, List<Summoner> team, List<Summoner> criteria) {
      var champs = new Dictionary<string, string>();
      foreach (var s in team) {
        champs[s.Name.ToLower()] = Util.Sanitize(s.Champion);
        if (s.Name == player) {
          champs["@" + s.Name.ToLower()] = champs["@"] = champs[s.Name.ToLower()];
        }
      }

      foreach (var c in criteria) {
        if (String.IsNullOrEmpty(c.Name)) {
          if (String.IsNullOrEmpty(c.Champion)) continue;
          if (team.FindIndex(x => Util.Sanitize(x.Champion).StartsWith(c.Champion)) == -1) return false;
        } else {
          if (!champs.ContainsKey(c.Name.ToLower())) return false;
          if (c.Champion != "" && !champs[c.Name.ToLower()].StartsWith(c.Champion)) return false;
        }
      }

      return true;
    }

    private bool CriteriaSatisfied(LogData game, List<List<Summoner>> criteria) {
      if (TeamSatisfies(game.PlayerName, game.BlueTeam, criteria[0]) &&
        (criteria.Count == 1 || TeamSatisfies(game.PlayerName, game.PurpleTeam, criteria[1]))) {
        return true;
      }
      if (TeamSatisfies(game.PlayerName, game.PurpleTeam, criteria[0]) &&
        (criteria.Count == 1 || TeamSatisfies(game.PlayerName, game.BlueTeam, criteria[1]))) {
        return true;
      }
      return false;
    }

    private void ReloadGameTable() {
      var search = summonerSearch.Text;
      var specOnly = false;
      if (search.EndsWith("#spec")) {
        search = search.Substring(0, search.Length - 5);
        specOnly = true;
      }

      Regex summonerRegex = null;
      var criteria = new List<List<Summoner>>();
      if (Regex.IsMatch(search, "[:|,@]")) {
        foreach (var side in search.Split(new char[] {'|'}, 2)) {
          var sums = new List<Summoner>();
          foreach (var crit in side.Split(new char[] { ',' })) {
            string[] sum = crit.Trim().Split(new char[] {':'}, 2);
            sums.Add(new Summoner() {Name = sum[0], Champion = sum.Length > 1 ? Util.Sanitize(sum[1]) : ""});
          }
          criteria.Add(sums);
        }
      } else if (search != "") {
        try {
          summonerRegex = new Regex(search, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        } catch (Exception) {
          summonerRegex = new Regex(Regex.Escape(search), RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
      }

      string champion = Util.Sanitize(championSearch.Text);
      var data = logData.Where(x => {
        if (mapComboBox.SelectedItem != null && !x.Map.Contains((string)mapComboBox.SelectedItem)) {
          return false;
        }
        if (x.Spectated && !spectateCheckbox.Checked) {
          return false;
        }
        if (x.BotGame && !botGamesCheckbox.Checked) {
          return false; 
        }
        if (!x.Spectated && specOnly) {
          return false;
        }
        if (summonerRegex != null && !x.BlueTeam.Exists(s => summonerRegex.Match(s.Name).Success) &&
            !x.PurpleTeam.Exists(s => summonerRegex.Match(s.Name).Success)) {
          return false;
        }
        if (criteria.Count > 0) {
          if (!CriteriaSatisfied(x, criteria)) {
            return false;
          }
        }
        if (champion != "" && !x.BlueTeam.Exists(s => Util.Sanitize(s.Champion).StartsWith(champion)) &&
            !x.PurpleTeam.Exists(s => Util.Sanitize(s.Champion).StartsWith(champion))) {
          return false;
        }
        return true;
      });

      gameTable.DataSource = gameData = new SortableBindingList<GameStats>(data.Select(log => new GameStats(log)));
      UpdateCounter();
    }

    private void ResetForm() {
      spectateCheckbox.Checked = true;
      botGamesCheckbox.Checked = true;
      mapComboBox.SelectedItem = "";
      summonerSearch.Text = "";
      championSearch.Text = "";
    }

    private void UpdateCounter() {
      if (gameData.Count > 0) {
        currentGameLabel.Text = String.Format("Game {0}/{1}{2}", gameTable.CurrentCell != null ? gameTable.CurrentCell.RowIndex + 1 : 0, gameData.Count,
          visibleWins + visibleLosses > 0 ? String.Format(" ({0}W/{1}L)", visibleWins, visibleLosses) : "");
      } else {
        currentGameLabel.Text = "No games found.";
      }
    }

    private void spectateCheckbox_CheckedChanged(object sender, EventArgs e) {
      ReloadGameTable();
    }

    private void botGamesCheckbox_CheckedChanged(object sender, EventArgs e) {
      ReloadGameTable();
    }

    private void mapComboBox_SelectedIndexChanged(object sender, EventArgs e) {
      ReloadGameTable();
    }

    private void FieldKeyDown(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Enter) {
        ReloadGameTable();
      }
    }

    private void goButton_Click(object sender, EventArgs e) {
      ReloadGameTable();
    }

    private void resetButton_Click(object sender, EventArgs e) {
      ResetForm();
      ReloadGameTable();
    }

    private void viewGameDetails(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && e.RowIndex < gameData.Count) {
        var data = gameData[e.RowIndex];
        new GameDetails(database.Get(data.id), this).Show();
      }
    }

    private void viewSummonerDetails(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && e.RowIndex < summonerData.Count) {
        new SummonerDetails(summonerData[e.RowIndex], logData, this).Show();
      }
    }

    private void refreshGamesMenuItem_Click(object sender, EventArgs e) {
      LoadLogFiles();
    }

    private void exitMenuItem_Click(object sender, EventArgs e) {
      Close();
    }

    private void aboutMenuItem_Click(object sender, EventArgs e) {
      new AboutDialog().Show();
    }

    private void searchHelpButton_Click(object sender, EventArgs e) {
      MessageBox.Show("Advanced search syntax:\n" +
        "- Use commas to search for summoners on the same team.\n" +
        "    e.g. 'Doublelift, aphromoo'\n" +
        "- Use a bar '|' to search for summoners on opposite teams.\n" +
        "    e.g. 'Doublelift, Chauster|WildTurtle, Xpecial'\n" +
        "- Use a colon ':' to search for a summoner playing a particular champion.\n" +
        "    e.g. 'Doublelift:Ezreal'\n" +
        "- Use a '@' to search for yourself.\n" +
        "- Any combination of the above.", "Advanced Search");
    }

    private void readmeMenuItem_Click(object sender, EventArgs e) {
      Process.Start("README.txt");
    }

    private void checkUpdatesMenuItem_Click(object sender, EventArgs e) {
      CheckForUpdates();
    }
  }
}
