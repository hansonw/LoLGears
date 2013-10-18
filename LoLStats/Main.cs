using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Be.Timvw.Framework.ComponentModel;
using Pietschsoft;

namespace LoLStats
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
    private SortableBindingList<SummonerStats> summonerData;
    private SortableBindingList<GameStats> gameData;
    private Dictionary<string, SummonerStats> summoners;

    public Main() {
      InitializeComponent();

      gameTable.ColumnHeadersBorderStyle = Util.ProperColumnHeadersBorderStyle;
      summonerTable.ColumnHeadersBorderStyle = Util.ProperColumnHeadersBorderStyle;

      LoadLogFiles();
    }

    public void OpenSummonerDetails(string summonerName) {
      if (summoners != null && summoners.ContainsKey(summonerName)) {
        new SummonerDetails(summoners[summonerName], this).Show();
      }
    }

    public void SearchSummoner(string summonerName, string champion = null) {
      ResetForm();
      if (champion != null) {
        summonerSearch.Text = summonerName + ":" + Util.Sanitize(champion);
      } else {
        summonerSearch.Text = "^" + summonerName + "$";
      }
      tabControl.SelectedTab = gamesPage;

      ReloadGameTable();
      gameTable.Select();
    }

    private void LoadLogFiles() {
      database = new LogDatabase();

      var pd = new ProgressDialog(this.Handle);
      pd.Title = "Loading logs...";
      pd.CancelMessage = "Please wait while the operation is cancelled...";
      pd.Maximum = 100;
      pd.Value = 0;
      pd.Line1 = "Loading LoLStats...";
      pd.Line2 = "Loading new logs...";
      pd.Line3 = "This may take a while. Please be patient..";

      pd.ShowDialog(ProgressDialog.PROGDLG.Modal, ProgressDialog.PROGDLG.AutoTime, ProgressDialog.PROGDLG.NoMinimize);

      var bg = new BackgroundWorker();
      bg.WorkerReportsProgress = true;
      bg.WorkerSupportsCancellation = true;
      bg.DoWork += (sender, e) => {
        database.Load("C:\\Riot Games\\League of Legends\\Logs\\Game - R3d Logs", sender as BackgroundWorker);
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
        Show();
        TopMost = true;
        TopMost = false;
      };
      bg.RunWorkerAsync();
    }

    private void LoadData() {
      var logData = database.Select();
      Invoke(new Action(() => {
        gameTable.DataSource = gameData = new SortableBindingList<GameStats>(logData.Select(log => new GameStats(log)));
        gameTable.Sort(gameTable.Columns["Date"], ListSortDirection.Descending);
      }));

      summoners = new Dictionary<string, SummonerStats>();
      foreach (var row in logData) {
        foreach (var x in row.BlueTeam.Concat(row.PurpleTeam)) {
          if (!x.IsBot && (!row.BotGame || !x.Name.EndsWith(" Bot"))) {
            if (!summoners.ContainsKey(x.Name)) {
              summoners[x.Name] = new SummonerStats(x.Name);
            }
            summoners[x.Name].AddGame(row);
          }
        }
      }

      Invoke(new Action(() => {
        summonerTable.DataSource = summonerData = new SortableBindingList<SummonerStats>(summoners.Values.OrderByDescending(x => x.Games));
        summonerData.SetDefaultDirection("Games", -1);
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

      table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
      table.Columns[table.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

      foreach (DataGridViewColumn column in table.Columns) {
        // change HeaderLikeThis to Header Like This
        column.HeaderText = Regex.Replace(column.HeaderText, "([a-z])([A-Z])", "$1 $2");
      }

      if (table.Name == "gameTable") {
        // Make sure date, server column is always 100% visible.
        table.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        table.Columns["Server"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      }
    }

    private void gameTableCellChange(object sender, EventArgs e) {
      if (gameTable.CurrentCell != null) {
        currentGameLabel.Text = String.Format("Game {0}/{1}", gameTable.CurrentCell.RowIndex+1, gameData.Count);
      }
    }

    private bool TeamSatisfies(List<Summoner> team, List<Summoner> criteria) {
      var champs = new Dictionary<string, string>();
      foreach (var s in team) {
        champs[s.Name.ToLower()] = Util.Sanitize(s.Champion);
      }

      foreach (var c in criteria) {
        if (!champs.ContainsKey(c.Name.ToLower())) return false;
        if (c.Champion != "" && !champs[c.Name.ToLower()].StartsWith(c.Champion)) return false;
      }

      return true;
    }

    private void ReloadGameTable() {
      var search = summonerSearch.Text;
      Regex summonerRegex = null;
      var criteria = new List<List<Summoner>>();
      if (search.Contains(':') || search.Contains('|')) {
        foreach (var side in search.Split(new char[] {'|'}, 2)) {
          var sums = new List<Summoner>();
          foreach (var crit in side.Split(new char[] { ',' })) {
            string[] sum = crit.Trim().Split(new char[] {':'}, 2);
            sums.Add(new Summoner() {Name = sum[0], Champion = sum.Length > 1 ? Util.Sanitize(sum[1]) : ""});
          }
          criteria.Add(sums);
        }
      } else if (search != "") {
        summonerRegex = new Regex(search, RegexOptions.Compiled | RegexOptions.IgnoreCase);
      }

      string champion = Util.Sanitize(championSearch.Text);
      var logData = database.Select(
        Map: mapComboBox.SelectedItem as string,
        AllowSpectated: spectateCheckbox.Checked,
        AllowBotGames: botGamesCheckbox.Checked
      ).Where(x => {
        if (summonerRegex != null && !x.BlueTeam.Exists(s => summonerRegex.Match(s.Name).Success) &&
            !x.PurpleTeam.Exists(s => summonerRegex.Match(s.Name).Success)) {
          return false;
        }
        if (criteria.Count > 0) {
          bool ok = false;
          ok = ok || TeamSatisfies(x.BlueTeam, criteria[0]) && (criteria.Count == 1 || TeamSatisfies(x.PurpleTeam, criteria[1]));
          ok = ok || TeamSatisfies(x.PurpleTeam, criteria[0]) && (criteria.Count == 1 || TeamSatisfies(x.BlueTeam, criteria[1]));
          if (!ok) return false;
        }
        if (champion != "" && !x.BlueTeam.Exists(s => Util.Sanitize(s.Champion).StartsWith(champion)) &&
            !x.PurpleTeam.Exists(s => Util.Sanitize(s.Champion).StartsWith(champion))) {
          return false;
        }
        return true;
      });

      gameTable.DataSource = gameData = new SortableBindingList<GameStats>(logData.Select(log => new GameStats(log)));
      gameTable.Sort(gameTable.Columns["Date"], ListSortDirection.Descending);
      currentGameLabel.Text = String.Format("Game 1/{0}", gameData.Count);
    }

    private void ResetForm() {
      spectateCheckbox.Checked = true;
      botGamesCheckbox.Checked = true;
      mapComboBox.SelectedItem = "";
      summonerSearch.Text = "";
      championSearch.Text = "";
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
        new SummonerDetails(summonerData[e.RowIndex], this).Show();
      }
    }
  }
}
