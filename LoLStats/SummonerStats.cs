using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LoLStats
{
  public class SummonerStats
  {
    public string Name { get; set; }
    public string Server;

    public int Games { get; set; }
    public int GamesAs;
    public int GamesWith;
    public int GamesAgainst;

    public int KnownWins { get; set; }
    public int KnownLosses { get; set; }
    public int WinsAs;
    public int LossesAs;
    public int WinsWith;
    public int LossesWith;

    public SummonerStats(string name) {
      Name = name;
    }

    public void AddGame(LogData data) {
      Games++;
      if (Name == data.PlayerName) {
        GamesAs++;
      }

      if (!String.IsNullOrEmpty(data.Server)) {
        Server = data.Server;
      }

      int resultTeam = data.BlueTeam.FindIndex(x => x.Name == data.PlayerName) >= 0 ? 0 : 1;
      int myTeam = data.BlueTeam.FindIndex(x => x.Name == Name) >= 0 ? 0 : 1;
      if (!String.IsNullOrEmpty(data.PlayerName) && data.PlayerName != Name) {
        if (myTeam == resultTeam) {
          GamesWith++;
        } else {
          GamesAgainst++;
        }
      }

      if ((data.ExitCode == LogData.ExitCodes.WIN ||
           data.ExitCode == LogData.ExitCodes.LOSE) && !data.Spectated) {
        Debug.Assert(data.PlayerName != "");
        bool gameResult = data.ExitCode == LogData.ExitCodes.WIN;
        if (data.PlayerName == Name) {
          if (gameResult) {
            WinsAs++;
          } else {
            LossesAs++;
          }
        } else if (myTeam != resultTeam) {
          gameResult = !gameResult;
        } else {
          if (gameResult) {
            WinsWith++;
          } else {
            LossesWith++;
          }
        }

        if (gameResult) {
          KnownWins++;
        } else {
          KnownLosses++;
        }
      }
    }
  }
}
