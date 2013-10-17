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
          Result = "-";
        } else {
          Result = log.ExitCode.ToString().ToLower();
          Result = Result.Substring(0, 1).ToUpper() + Result.Substring(1);
        }
      }

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

    public Main() {
      InitializeComponent();

      gameTable.ColumnHeadersBorderStyle = ProperColumnHeadersBorderStyle;
      summonerTable.ColumnHeadersBorderStyle = ProperColumnHeadersBorderStyle;

      LoadLogFiles();
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
      var data = database.Select();
      Invoke(new Action(() => gameTable.DataSource = gameData = new SortableBindingList<GameStats>(data.Select(log =>
        new GameStats(log)).OrderByDescending(x => x.Date))));

      var summoners = new Dictionary<string, SummonerStats>();
      foreach (var row in data) {
        foreach (var x in row.BlueTeam.Concat(row.PurpleTeam)) {
          if (!x.IsBot && (!row.BotGame || !x.Name.EndsWith(" Bot"))) {
            if (!summoners.ContainsKey(x.Name)) {
              summoners[x.Name] = new SummonerStats(x.Name);
            }
            summoners[x.Name].AddGame(row);
          }
        }
      }
      Invoke(new Action(() => summonerTable.DataSource = summonerData = new SortableBindingList<SummonerStats>(
        summoners.Values.OrderByDescending(x => x.Games))));

      summonerData.SetDefaultSortOrder(typeof(SummonerStats).GetProperty("Games").PropertyType, -1);
    }

    /// <summary>
    /// Remove the column header border in the Aero theme in Vista,
    /// but keep it for other themes such as standard and classic.
    /// </summary>
    static DataGridViewHeaderBorderStyle ProperColumnHeadersBorderStyle {
	    get {
	      return (SystemFonts.MessageBoxFont.Name == "Segoe UI") ?
		      DataGridViewHeaderBorderStyle.None :
		      DataGridViewHeaderBorderStyle.Raised;
	    }
    }

    private void summonerTableCellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
      if (summonerTable.Columns[e.ColumnIndex].Name == "Name") {
        var stats = summonerData[e.RowIndex];
        if (stats.HasPlayed) {
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
      if (e.TabPage == tabPage1) {
        summonerTable.Select();
      } else if (e.TabPage == tabPage2) {
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
        table.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        table.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      }
    }
  }
}
