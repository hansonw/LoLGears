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

namespace LoLStats
{
  public partial class SummonerDetails : Form
  {
    public SummonerStats Data;
    private Main mainForm;
    private SortableBindingList<SummonerStats.ChampionStats> championData;

    public SummonerDetails(SummonerStats data, Main form) {
      mainForm = form;
      InitializeComponent();
      Data = data;

      headerLabel.Text = data.Name;
      if (!String.IsNullOrEmpty(data.Server)) {
        headerLabel.Text += " (" + data.Server + ")";
      }

      var gamesDetails = new List<string>();
      if (data.GamesWith > 0) {
        gamesDetails.Add("with: " + data.GamesWith);
      }
      if (data.GamesAgainst > 0) {
        gamesDetails.Add("against: " + data.GamesAgainst);
      }
      int spec = data.Games - data.GamesWith - data.GamesAgainst - data.GamesAs;
      if (spec > 0) {
        gamesDetails.Add("spec: " + spec);
      }
      if (data.GamesAs > 0 && gamesDetails.Count > 0) {
        gamesDetails.Insert(0, "as: " + data.GamesAs);
      }
      var gamesText = gamesPlayedLabel.Text = 
        String.Format("Games: {0}{1}", data.Games, gamesDetails.Count > 0 ? " (" + String.Join(", ", gamesDetails.ToArray()) + ")" : "");
      
      // Create links
      string[] labels = new string[] {"Games", "as", "with", "against", "spec"};
      foreach (var label in labels) {
        var match = Regex.Match(gamesText, label + ": ([0-9]+)");
        if (match.Success) {
          var type = label == "Games" ? "" : label;
          gamesPlayedLabel.Links.Add(new LinkLabel.Link(match.Groups[1].Index, match.Groups[1].Length, type));
        }
      }

      var recordDetails = new List<string>();
      if (data.WinsAs + data.LossesAs > 0) {
        recordDetails.Insert(0, "as: " + data.WinsAs + "-" + data.LossesAs);
      }
      if (data.WinsWith + data.LossesWith > 0) {
        recordDetails.Add("with: " + data.WinsWith + "-" + data.LossesWith);
      }
      int winsAgainst = data.KnownWins - data.WinsWith - data.WinsAs;
      int lossesAgainst = data.KnownLosses - data.LossesWith - data.LossesAs;
      if (winsAgainst + lossesAgainst > 0) {
        recordDetails.Add("against: " + lossesAgainst + "-" + winsAgainst);
      }
      recordLabel.Text = "Known record" + (recordDetails.Count > 0 ? " " + String.Join(", ", recordDetails.ToArray()) : ": 0-0");

      championData = new SortableBindingList<SummonerStats.ChampionStats>(data.ChampStats.Values.OrderByDescending(x => x.Games));
      championData.SetDefaultDirection("Games", -1);
      championData.SetDefaultDirection("Wins", -1);
      championData.SetDefaultDirection("Losses", -1);
      championData.SetDefaultDirection("WinRate", -1);

      championTable.DataSource = championData;
      championTable.ColumnHeadersBorderStyle = Util.ProperColumnHeadersBorderStyle;
      championTable.Columns["Wins"].HeaderText = "W";
      championTable.Columns["Losses"].HeaderText = "L";
      championTable.Columns["WinRate"].HeaderText = "WR";
      if (data.GamesAs > 0) {
        championTable.Columns["DeathsPerGame"].HeaderText = "D/G";
        championTable.Columns["DeathsPerGame"].ToolTipText = "Deaths per game";
      } else {
        championTable.Columns["DeathsPerGame"].Visible = false;
      }
      championTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      championTable.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      championTable.Select();
    }

    private void lolkingLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      var uri = new Uri("http://www.lolking.net/search?name=" + Data.Name);
      System.Diagnostics.Process.Start(uri.ToString());
    }

    private void gamesLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      // bring to front
      mainForm.BringToFront();
      var type = (string) e.Link.LinkData; // "", "as", "with", "against", "spec"
      mainForm.SearchSummoner(Data.Name, null, type);
    }

    private void closeButton_Click(object sender, EventArgs e) {
      Close();
    }

    private void showChampionGames(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && e.RowIndex < championData.Count) {
        mainForm.BringToFront();
        mainForm.SearchSummoner(Data.Name, championData[e.RowIndex].Name);
      }
    }

    private void championTableCellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
      if (championTable.Columns[e.ColumnIndex].Name == "WinRate") {
        var value = (double) e.Value;
        if (value == -1) {
          e.Value = "";
        } else {
          e.Value = value.ToString("#0.#") + '%';
        }
      }
    }
  }
}
