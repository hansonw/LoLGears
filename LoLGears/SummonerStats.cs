using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LoLGears
{
  public class SummonerStats
  {
    public string Name { get; set; }
    public string Server { get; set; }

    public int Games { get; set; }
    public int GamesAs;
    public int GamesWith;
    public int GamesAgainst;
    public int PlayedWith { get { return GamesAs + GamesWith; } }
    public int PlayedVs { get { return GamesAgainst; } }
    public int TimePlayed;

    public int KnownWins { get; set; }
    public int KnownLosses { get; set; }
    public double WinRate {
      get { 
        int total = KnownWins + KnownLosses;
        return total > 0 ? 100.0*KnownWins/total : -1;
      }
    }
    public int WinsAs;
    public int LossesAs;
    public int WinsWith;
    public int LossesWith;

    public class ChampionStats
    {
      public string Name { get; set; }
      public int Games { get; set; }
      public int Wins { get; set; }
      public int Losses { get; set; }
      public double WinRate {
        get {
          int total = Wins + Losses;
          return total > 0 ? 100.0 * Wins / total : -1;
        }
      }
      public string DeathsPerGame { get { return DeathGames > 0 ? (1.0*Deaths/DeathGames).ToString("#0.#") : ""; } }
      public int DeathGames, Deaths;
    }
    public Dictionary<string, ChampionStats> ChampStats = new Dictionary<string, ChampionStats>();

    public SummonerStats(string name) {
      Name = name;
    }

    public void AddGame(LogData data) {
      Games++;
      TimePlayed += data.GameLength;
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

      var summoner = (myTeam == 0 ? data.BlueTeam : data.PurpleTeam).Find(x => x.Name == Name);
      if (!ChampStats.ContainsKey(summoner.Champion)) {
        ChampStats[summoner.Champion] = new ChampionStats() { Name = summoner.Champion };
      }
      var cs = ChampStats[summoner.Champion];
      cs.Games++;
      if (Name == data.PlayerName && !data.BotGame) {
        cs.DeathGames++;
        cs.Deaths += data.Deaths.Count;
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
          cs.Wins++;
        } else {
          KnownLosses++;
          cs.Losses++;
        }
      }
    }
  }
}
