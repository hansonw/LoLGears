using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using LoLStats.Properties;

namespace LoLStats
{
  public partial class GameDetails : Form
  {
    public LogData Game;
    private Main mainForm;

    public GameDetails(LogData game, Main form) {
      mainForm = form;
      InitializeComponent();

      Game = game;
      headerLabel.Text = String.Format("{0}, {1}v{2}{3}", Game.Map, Game.BlueTeam.Count, Game.PurpleTeam.Count,
                                       Game.BotGame ? " (Co-op vs. AI)" : "");
      switch (Game.ExitCode) {
        case LogData.ExitCodes.WIN:
          resultLabel.Text = "VICTORY";
          resultLabel.BackColor = Color.LimeGreen;
          resultLabel.ForeColor = Color.White;
          break;
        case LogData.ExitCodes.LOSE:
          resultLabel.Text = "DEFEAT";
          resultLabel.BackColor = Color.Tomato;
          resultLabel.ForeColor = Color.Black;
          break;
        case LogData.ExitCodes.CRASH:
          resultLabel.Text = "CRASH";
          resultLabel.BackColor = Color.Red;
          resultLabel.ForeColor = Color.White;
          break;
        case LogData.ExitCodes.UNKNOWN:
          resultLabel.Text = "UNKNOWN";
          resultDisclaimer.SetToolTip(resultLabel, "Game result was not logged in this client version.");
          resultLabel.BackColor = Color.Silver;
          resultLabel.ForeColor = Color.Black;
          break;
        case LogData.ExitCodes.LEAVE:
          resultLabel.Text = "LEAVE";
          resultLabel.BackColor = Color.Yellow;
          resultLabel.ForeColor = Color.Black;
          break;
      }
      if (Game.Spectated) {
        resultLabel.Text = "SPECTATED";
        resultLabel.BackColor = Color.SlateBlue;
        resultLabel.ForeColor = Color.White;
        deathsLabel.Text = "You spectated this game.";
      } else {
        string msg = "";
        if (Game.Deaths.Count > 7) {
          msg = " (Feeder!)";
        } else if (Game.Deaths.Count > 0) {
          msg = " (Killed by " + String.Join(", ", Game.Deaths.Select(x => x.Name).Distinct().ToArray()) + ")";
        } else {
          msg = " (Nice!)";
        }
        deathsLabel.Text = String.Format("You had {0} death{1} this game. {2}", Game.Deaths.Count, Game.Deaths.Count == 1 ? "" : "s", msg);
      }

      dateLabel.Text = String.Format("Played on {0}{1} (version {2})",
                                     Game.GameStartDate.ToString(@"MMM d, yyyy h:mm tt"),
                                     Game.Server == "" ? "" : " on " + Game.Server,
                                     Game.GameVersion);
      lengthLabel.Text = String.Format("Game length: {0}:{1:d2}", Game.GameLength/60, Game.GameLength%60);

      foreach (var summoner in Game.BlueTeam) {
        AddSummoner(summoner, blueTeamFlow, true, summoner.Name == Game.PlayerName);
      }
      foreach (var summoner in Game.PurpleTeam) {
        AddSummoner(summoner, purpleTeamFlow, false, summoner.Name == Game.PlayerName);
      }
    }

    private void AddSummoner(Summoner s, FlowLayoutPanel flow, bool leftSide, bool isPlayer) {
      var label = new Label() {
        Text = leftSide ? s.Name + " (" + s.Champion + ")" : "(" + s.Champion + ") " + s.Name,
        Margin = new Padding(0, 2, 0, 3),
        Font = new Font(headerLabel.Font.FontFamily, 9.5f, isPlayer ? FontStyle.Bold : FontStyle.Regular),
        AutoSize = true,
        Cursor = Cursors.Hand,
      };
      label.Click += (sender, e) => mainForm.OpenSummonerDetails(s.Name);

      var bitmap = Resources.ResourceManager.GetObject(Util.Sanitize(s.Champion)) as Bitmap;
      if (bitmap == null) {
        bitmap = Resources.unknown;
      }

      var icon = new PictureBox() {
        Width = 16,
        Height = 16,
        BackColor = Color.Silver,
        BackgroundImage = bitmap,
      };

      flow.Controls.Add(icon);
      flow.Controls.Add(label);
      flow.SetFlowBreak(label, true);
    }

    private void closeButton_Click(object sender, EventArgs e) {
      Close();
    }
  }
}
