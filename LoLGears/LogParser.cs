using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LoLGears
{
  public class Summoner
  {
    public string Name;
    public string Champion;
    public int SkinID;
    public bool IsBot;

    public static Summoner Parse(string s) {
      string[] parts = s.Split(',');
      return new Summoner() {
        Name = parts[0],
        Champion = parts[1],
        SkinID = int.Parse(parts[2]),
        IsBot = int.Parse(parts[3]) == 1,
      };
    }

    public override string ToString() {
      return Name + "," + Champion + "," + SkinID + "," + (IsBot ? "1" : "0");
    }
  }

  public class LogData
  {
    public long id;
    public string LogFile;
    public string GameID;
    public string Server = "";
    public int GameLength;
    public DateTime GameStartDate;
    public bool Spectated;
    public bool BotGame;

    public Version GameVersion;

    public string Map;
    public List<Summoner> BlueTeam = new List<Summoner>();
    public List<Summoner> PurpleTeam = new List<Summoner>();

    public string PlayerName = "";
    public List<int> Deaths = new List<int>();
    public enum ExitCodes {
      UNKNOWN,
      WIN,
      LOSE,
      CRASH,
      LEAVE
    };

    public ExitCodes ExitCode;

    public override string ToString() {
      string ret = "";
      ret += "Game ID: " + GameID;
      if (Spectated) {
        ret += " (spectated)";
      }
      ret += "\nGame date: " + GameStartDate + "\n";
      ret += "Game length: " + GameLength + " seconds\n";
      ret += "Game version: " + GameVersion + "\n";
      ret += "Map: " + Map + "\n";
      if (BlueTeam != null) {
        ret += "Blue team: " + String.Join(", ", BlueTeam.Select((x) => x.Name).ToArray()) + "\n";
      }
      if (PurpleTeam != null) {
        ret += "Purple team: " + String.Join(", ", PurpleTeam.Select((x) => x.Name).ToArray()) + "\n";
      }
      if (!Spectated) {
        ret += "Player: " + PlayerName + "\n";
        ret += "Deaths: " + Deaths.Count + "\n";
        ret += "Exit code: " + ExitCode.ToString() + "\n";
      }

      return ret;
    }
  }

  class LogParser
  {
    public static readonly Version CLIENT_ID_VERSION = new Version("3.01.0.1");
    // Important game versions:
    // - 1.0.0.143 - skin ID starts getting logged.
    // - 3.01.0.1 (2013-02-01) - clientID starts getting logged, allowing us to definitively discern who the player is
    // - 3.10.0.237 (2013-07-31) - exit code starts getting logged, allowing us to know the result of the game.

    public static Dictionary<int, string> MapDictionary = new Dictionary<int, string>() {
      {1, "Summoner's Rift"},
      {3, "Proving Grounds"},
      {4, "Twisted Treeline (Old)"},
      {6, "Summoner's Rift (Winter)"},
      {8, "Crystal Scar"},
      {10, "Twisted Treeline"},
      {12, "Howling Abyss"},
    };

    public static string FixChampionName(string champ) {
      switch (champ.ToLower()) {
        case "monkeyking":
          return "Wukong";
        case "khazix":
          return "Kha'Zix";
        case "kogmaw":
          return "Kog'Maw";
        case "chogath":
          return "Cho'Gath";
        case "leblanc":
          return "LeBlanc"; // don't separate
        case "fiddlesticks":
          return "Fiddlesticks"; // the S is capitalized by default for some reason
        case "drmundo":
          return "Dr. Mundo"; // add the period
        default:
          // Separate e.g. JarvanIV => Jarvan IV
          return Regex.Replace(champ, "([a-z])([A-Z])", "$1 $2");
      }
    }

    public Regex LOG_START_REGEX1 = new Regex("Log started at (.+) (.+) (.+) (.+) (.+)", RegexOptions.Compiled);
    public Regex LOG_START_REGEX2 = new Regex("Logging started at (.*)", RegexOptions.Compiled);
    public Regex GAME_ID_REGEX = new Regex("Receiving PKT_World_SendGameNumber, GameID[: ]+([0-9a-zA-Z]+)(.*?PlatformID: ([A-Z]+))?", RegexOptions.Compiled);
    public Regex BUILD_REGEX = new Regex("Build Version: Version ([0-9\\.]+)", RegexOptions.Compiled);
    public Regex MAP_REGEX = new Regex("Adding level zip file: Map([0-9]+).zip", RegexOptions.Compiled);
    public Regex NET_UID_REGEX = new Regex("netUID: ([0-9]+)", RegexOptions.Compiled);
    public Regex KILLER_REGEX = new Regex("The Killer was: (.*)", RegexOptions.Compiled);
    public Regex EXITCODE_REGEX = new Regex("EXITCODE_([A-Z]+)", RegexOptions.Compiled);
    public Regex CHAMPION_REGEX1 = new Regex(@"Spawning champion \(([^\)]+)\) with skinID ([0-9]+) on team ([0-9]+) for clientID ([0-9\-]+) and summonername \(([^\)]+)\)", RegexOptions.Compiled);
    public Regex CHAMPION_REGEX2 = new Regex(@"Hero ([^\)]+)(\(([0-9]+)\))? created for (.*)", RegexOptions.Compiled);

    public LogData ParseLog(string filename) {
      try {
        var file = File.Open(filename, FileMode.Open);
        var bs = new BufferedStream(file);
        var stream = new StreamReader(bs);

        var summonerMap = new Dictionary<string, int>();
        int netUID = -2;
        var mergedTeam = new List<Summoner>();
        double startTime = -1, lastTimeStamp = -1;
        bool disconnect = false;
        DateTime startDate = new DateTime();
        Match match;

        var ret = new LogData();
        ret.LogFile = filename;

        string line;
        while ((line = stream.ReadLine()) != null) {
          string[] parts = line.Split(new char[] {'|'}, 5, StringSplitOptions.None);
          if (parts.Length == 1) {
            // Old format e.g. --- Log started at Sun Apr 29 23:34:01 2012
            match = LOG_START_REGEX1.Match(line);
            if (match.Success) {
              var parsedDate = String.Format("{0} {1}, {2} {3}",
                match.Groups[2].Value, // month
                match.Groups[3].Value, // day
                match.Groups[5].Value, // year
                match.Groups[4].Value  // time
              );
              if (!DateTime.TryParse(parsedDate, out startDate)) {
                Logger.LogMessage(filename + ": Invalid date in " + match.Groups[0].Value);
              }
            }
          }

          if (parts.Length != 5) continue;

          double timeStamp = 0;
          if (!double.TryParse(parts[0].Trim(), NumberStyles.Number, new CultureInfo("en-US"), out timeStamp)) {
            // This line is corrupted. Ignore it
            continue;
          }
          lastTimeStamp = timeStamp;
          string text = parts.Last().Substring(1);

          if ((match = LOG_START_REGEX2.Match(text)).Success) {
            if (!DateTime.TryParse(match.Groups[1].Value, out startDate)) {
              Logger.LogMessage(filename + ": Invalid date " + match.Groups[1].Value);
            }
          } else if ((match = GAME_ID_REGEX.Match(text)).Success) { // Obtain game ID.
            ret.GameID = match.Groups[1].Value;
            if (match.Groups[3].Success) {
              ret.Server = match.Groups[3].Value;
            }
          } else if ((match = BUILD_REGEX.Match(text)).Success) {
            // game version
            ret.GameVersion = new Version(match.Groups[1].Value);
          } else if ((match = MAP_REGEX.Match(text)).Success) { // Obtain map ID
            int mapID = int.Parse(match.Groups[1].Value);
            if (!MapDictionary.TryGetValue(mapID, out ret.Map)) {
              ret.Map = "Unknown Map";
            }
          } else if ((match = NET_UID_REGEX.Match(text)).Success) { // client's ID
            netUID = int.Parse(match.Groups[1].Value);
          } else if (text.Contains("Started ReplayDownloadManager")) {
            // indicates that this was a spectated game.
            ret.Spectated = true;
          } else if (text == "PKT_StartGame") {
            // this indicates the game actually loaded.
            startTime = timeStamp;
            Debug.Assert(!startDate.Equals(new DateTime()), "Game started with undefined start date");
            ret.GameStartDate = startDate.AddSeconds(startTime);
          } else if ((match = KILLER_REGEX.Match(text)).Success && !ret.Spectated) {
            var killer = match.Groups[1].Value;
            if (summonerMap.ContainsKey(killer)) {
              ret.Deaths.Add(summonerMap[killer]);
            } else {
              // Most likely tower or minion.
              ret.Deaths.Add(-1);
            }
          } else if (text == "Disconnected") {
            disconnect = true;
          } else if (text == "End game message processing!") {
            // indicates game end.
            ret.GameLength = (int) (timeStamp - startTime + 0.5);
            disconnect = false;
          } else if (text == "Finished Play game" && ret.GameLength == 0) {
            // The end game message always comes first. If it didn't, that means we forcibly left the game.
            ret.GameLength = (int) (timeStamp - startTime + 0.5);
            ret.ExitCode = LogData.ExitCodes.LEAVE;
          } else if ((match = EXITCODE_REGEX.Match(text)).Success) {
            switch (match.Groups[1].Value) {
              case "WIN":
                ret.ExitCode = LogData.ExitCodes.WIN;
                break;
              case "LOSE":
                ret.ExitCode = LogData.ExitCodes.LOSE;
                break;
              case "ABANDON":
                ret.ExitCode = LogData.ExitCodes.LEAVE;
                break;
            }
          } else {
            if (ret.GameVersion >= CLIENT_ID_VERSION) {
              match = CHAMPION_REGEX1.Match(text);
              if (match.Success) {
                var summoner = new Summoner() {
                  Champion = FixChampionName(match.Groups[1].Value),
                  SkinID = int.Parse(match.Groups[2].Value),
                  Name = match.Groups[5].Value
                };

                var teamID = int.Parse(match.Groups[3].Value);
                var clientID = int.Parse(match.Groups[4].Value);

                if (clientID == -1) {
                  ret.BotGame = true;
                  summoner.IsBot = true;
                }

                List<Summoner> team = (teamID == 100 ? ret.BlueTeam : ret.PurpleTeam);
                if (!summonerMap.ContainsKey(summoner.Name)) {
                  team.Add(summoner);
                  summonerMap[summoner.Name] = summonerMap.Count;
                }
                if (!ret.Spectated && clientID == netUID) {
                  ret.PlayerName = summoner.Name;
                }
              }
            } else {
              match = CHAMPION_REGEX2.Match(text);
              if (match.Success) {
                var summoner = new Summoner() {
                  Champion = FixChampionName(match.Groups[1].Value),
                  Name = match.Groups[4].Value
                };

                if (match.Groups[3].Success) {
                  summoner.SkinID = int.Parse(match.Groups[3].Value);
                } else {
                  summoner.SkinID = -1;
                }

                // Guess the team.. might not be accurate for 1v5 bot games and such.
                if (!summonerMap.ContainsKey(summoner.Name)) {
                  mergedTeam.Add(summoner);
                  summonerMap[summoner.Name] = summonerMap.Count;
                }
              }
            }
          }
        }

        if (startTime == -1) {
          return null; // Game crashed before loading.
        }

        if (ret.GameLength == 0) {
          // Game crashed in the middle somewhere.
          ret.GameLength = (int) (lastTimeStamp - startTime + 0.5);
          ret.ExitCode = LogData.ExitCodes.CRASH;
        }

        if (disconnect) {
          ret.ExitCode = LogData.ExitCodes.CRASH;
        }

        if (mergedTeam.Count > 0) {
          // Assume half the players are on both teams. Doesn't account for uneven teams, of course..
          int l = (mergedTeam.Count + 1)/2;
          ret.BlueTeam = mergedTeam.Take(l).ToList();
          ret.PurpleTeam = mergedTeam.Skip(l).ToList();

          if (ret.BlueTeam.All((x) => x.Name.EndsWith(" Bot")) ||
              ret.PurpleTeam.All((x) => x.Name.EndsWith(" Bot"))) {
            ret.BotGame = true;
          }
        }

        return ret;
      } catch (Exception ex) {
        Logger.LogException(ex);
        return null;
      }
    }
  }
}
