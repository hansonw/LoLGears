using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LoLStats
{
  class SummonerStats
  {
    public string Name { get; set; }
    public int Games { get; set; }
    public bool HasPlayed;
    public int KnownWins { get; set; }
    public int KnownLosses { get; set; }
    public int WinsWith;
    public int LossesWith;

    public SummonerStats(string name) {
      Name = name;
    }

    public void AddGame(LogData data) {
      Games += 1;
      if (Name == data.PlayerName) {
        HasPlayed = true;
      }

      if ((data.ExitCode == LogData.ExitCodes.WIN ||
           data.ExitCode == LogData.ExitCodes.LOSE) && !data.Spectated) {
        Debug.Assert(data.PlayerName != "");
        bool gameResult = data.ExitCode == LogData.ExitCodes.WIN;
        int resultTeam = data.BlueTeam.FindIndex(x => x.Name == data.PlayerName) >= 0 ? 0 : 1;
        int myTeam = data.BlueTeam.FindIndex(x => x.Name == Name) >= 0 ? 0 : 1;
        if (myTeam != resultTeam) {
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
