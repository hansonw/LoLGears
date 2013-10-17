using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoLStats
{
  public partial class SummonerDetails : Form
  {
    public SummonerStats Data;
    private Main mainForm;

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
      gamesPlayedLabel.Text = String.Format("Games: {0}{1}", data.Games,
                                            gamesDetails.Count > 0 ? " (" + String.Join(", ", gamesDetails.ToArray()) + ")" : "");

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
        recordDetails.Add("against: " + winsAgainst + "-" + lossesAgainst);
      }
      recordLabel.Text = "Known record" + (recordDetails.Count > 0 ? " " + String.Join(", ", recordDetails.ToArray()) : ": 0-0");
    }

    private void lolkingLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      var uri = new Uri("http://www.lolking.net/search?name=" + Data.Name);
      System.Diagnostics.Process.Start(uri.ToString());
    }

    private void gamesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      // bring to front
      mainForm.BringToFront();
      mainForm.SearchSummoner(Data.Name);
    }
  }
}
