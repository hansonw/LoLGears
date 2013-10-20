using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace LoLGears
{
  class LogDatabase
  {
    private SQLiteConnection sqlConnection;
    private string[] files;

    public LogDatabase() {
      if (!File.Exists("LoLGears.db")) {
        SQLiteConnection.CreateFile("LoLGears.db");
      }
      sqlConnection = new SQLiteConnection("Data Source=LoLGears.db;Version=3;Compress=True");
      sqlConnection.Open();

      var command = sqlConnection.CreateCommand();
      command.CommandText = @"CREATE TABLE IF NOT EXISTS games (
        id INTEGER PRIMARY KEY AUTOINCREMENT, game_id VARCHAR(20), log_file VARCHAR(50), server VARCHAR(5), length INT,
        start_date VARCHAR(30), spectated BOOLEAN, bot_game BOOLEAN, game_version VARCHAR(20),
        map VARCHAR(20), blue_team VARCHAR(255), purple_team VARCHAR(255),
        player_name VARCHAR(20), exit_code VARCHAR(10), deaths TEXT
      )";
      command.ExecuteNonQuery();
    }

    private string LastFile() {
      var command = sqlConnection.CreateCommand();
      command.CommandText = "SELECT log_file FROM games ORDER BY id DESC LIMIT 1";
      return (string)command.ExecuteScalar();
    }

    public bool Load(string path, BackgroundWorker worker) {
      try {
        files = Directory.GetFiles(path);
        Array.Sort(files);

        var rows = new List<LogData>();
        var parser = new LogParser();
        string lastFile = LastFile();
        if (lastFile != null) {
          lastFile = Path.GetFileName(lastFile);
        }

        Logger.LogMessage("Last file was: " + lastFile);
        int index = 0, length = 0, start = 0;
        foreach (var file in files) {
          if (Path.GetFileName(file).CompareTo(lastFile) > 0) {
            if (length == 0) {
              start = index;
              length = files.Length - index;
            }

            if (worker.CancellationPending) {
              break;
            }

            var data = parser.ParseLog(file);
            worker.ReportProgress(index*100/length, new int[] { index-start+1, length });
            if (data != null) {
              if (rows.Count > 0) {
                LogData lastLog = rows.Last();
                if (lastLog.GameID == data.GameID && lastLog.Spectated == data.Spectated) {
                  // Merge these games together.
                  lastLog.GameLength = (int)(data.GameStartDate - lastLog.GameStartDate).TotalSeconds + data.GameLength;
                  lastLog.ExitCode = data.ExitCode;
                  lastLog.Deaths.AddRange(data.Deaths);
                  continue;
                }
              } 
              rows.Add(data);
            }
          }
          index++;
        }

        var transaction = sqlConnection.BeginTransaction();
        var command = sqlConnection.CreateCommand();
        command.Transaction = transaction;
        command.CommandText = @"INSERT INTO games (
          game_id, log_file, server, length,
          start_date, spectated, bot_game, game_version,
          map, blue_team, purple_team,
          player_name, exit_code, deaths
        ) VALUES (
          @game_id, @log_file, @server, @length,
          @start_date, @spectated, @bot_game, @game_version,
          @map, @blue_team, @purple_team,
          @player_name, @exit_code, @deaths
        )";

        var ps = new SQLiteParameter[] {
          new SQLiteParameter("@game_id", System.Data.DbType.String),
          new SQLiteParameter("@log_file", System.Data.DbType.String),
          new SQLiteParameter("@server", System.Data.DbType.String),
          new SQLiteParameter("@length", System.Data.DbType.Int32),
          new SQLiteParameter("@start_date", System.Data.DbType.String),
          new SQLiteParameter("@spectated", System.Data.DbType.Boolean),
          new SQLiteParameter("@bot_game", System.Data.DbType.Boolean),
          new SQLiteParameter("@game_version", System.Data.DbType.String),
          new SQLiteParameter("@map", System.Data.DbType.String),
          new SQLiteParameter("@blue_team", System.Data.DbType.String),
          new SQLiteParameter("@purple_team", System.Data.DbType.String),
          new SQLiteParameter("@player_name", System.Data.DbType.String),
          new SQLiteParameter("@exit_code", System.Data.DbType.String),
          new SQLiteParameter("@deaths", System.Data.DbType.String)
        };
        command.Parameters.AddRange(ps);

        foreach (var data in rows) {
          command.Parameters[0].Value  = data.GameID;
          command.Parameters[1].Value  = data.LogFile;
          command.Parameters[2].Value  = data.Server;
          command.Parameters[3].Value  = data.GameLength;
          command.Parameters[4].Value  = data.GameStartDate.ToString();
          command.Parameters[5].Value  = data.Spectated;
          command.Parameters[6].Value  = data.BotGame;
          command.Parameters[7].Value  = data.GameVersion.ToString();
          command.Parameters[8].Value  = data.Map;
          command.Parameters[9].Value  = JoinObjects(data.BlueTeam);
          command.Parameters[10].Value = JoinObjects(data.PurpleTeam);
          command.Parameters[11].Value = data.PlayerName;
          command.Parameters[12].Value = data.ExitCode.ToString();
          command.Parameters[13].Value = JoinObjects(data.Deaths);

          command.ExecuteNonQuery();
        }

        transaction.Commit();

        return true;
      } catch (Exception ex) {
        Logger.LogException(ex);
        return false;
      }
    }

    public LogData Get(long id) {
      var command = sqlConnection.CreateCommand();
      command.CommandText = "SELECT * FROM games WHERE id = @id";
      command.Parameters.Add(new SQLiteParameter("@id", id));
      var reader = command.ExecuteReader();
      if (reader.Read()) {
        return GetDataFromRow(reader);
      }

      return null;
    }

    public List<LogData> Select() {
      var command = sqlConnection.CreateCommand();
      command.CommandText = "SELECT * FROM games ORDER BY id DESC";

      var reader = command.ExecuteReader();

      int numRows = files.Length;
      int tick = numRows/100;
      var result = new List<LogData>();
      var unknown = new Dictionary<long, LogData>();

      var playedCount = new Dictionary<string, int>();
      var summonerCount = new Dictionary<string, int>();
      while (reader.Read()) {
        var id = (long) reader["id"];
        var data = GetDataFromRow(reader);

        int count;
        if (data.PlayerName != "") {
          playedCount.TryGetValue(data.PlayerName, out count);
          playedCount[data.PlayerName] = count + 1;
        }

        foreach (var summoner in data.BlueTeam.Concat(data.PurpleTeam)) {
          summonerCount.TryGetValue(summoner.Name, out count);
          summonerCount[summoner.Name] = count + 1;
        }

        result.Add(data);
        if (!data.Spectated && data.PlayerName == "") {
          unknown[id] = data;
        }
      }

      // If any games have unknown players, update them now.
      if (unknown.Count > 0) {
        var transaction = sqlConnection.BeginTransaction();
        command = sqlConnection.CreateCommand();
        command.Transaction = transaction;
        command.CommandText = "UPDATE games SET player_name = @player_name WHERE id = @id";
        command.Parameters.Add(new SQLiteParameter("@player_name", System.Data.DbType.String));
        command.Parameters.Add(new SQLiteParameter("@id", System.Data.DbType.Int64));

        foreach (var kvp in unknown) {
          var id = kvp.Key;
          var row = kvp.Value;

          long max = 0;
          string bestMatch = "";

          // Take the most confirmed played. If we've never confirmed playing on one of these,
          // take the summoner name that appears the most
          foreach (var sum in row.BlueTeam.Concat(row.PurpleTeam)) {
            if (playedCount.ContainsKey(sum.Name) && playedCount[sum.Name]*100000L > max) {
              max = playedCount[sum.Name]*100000L;
              bestMatch = sum.Name;
            }
            if (summonerCount[sum.Name] > max) {
              max = summonerCount[sum.Name];
              bestMatch = sum.Name;
            }
          }

          row.PlayerName = bestMatch;
          command.Parameters[0].Value = bestMatch;
          command.Parameters[1].Value = id;
          command.ExecuteNonQuery();
        }
        transaction.Commit();
      }

      return result;
    }

    private string JoinObjects<T>(List<T> objs) {
      return String.Join(";", objs.Select((x) => x.ToString()).ToArray());
    }

    private delegate T Parse<T>(string value);
    private List<T> SplitObjects<T>(string s, Parse<T> parser) {
      if (s == "") return new List<T>();
      string[] parts = s.Split(';');
      return new List<T>(parts.Select((x) => parser(x)));
    }

    private LogData GetDataFromRow(SQLiteDataReader reader) {
      return new LogData() {
        id = (long) reader["id"],
        GameID = (string) reader["game_id"],
        LogFile = (string) reader["log_file"],
        Server = (string) reader["server"],
        GameLength = (int) reader["length"],
        GameStartDate = DateTime.Parse((string) reader["start_date"]),
        Spectated = (bool) reader["spectated"],
        BotGame = (bool) reader["bot_game"],
        GameVersion = new Version((string) reader["game_version"]),
        Map = (string) reader["map"],
        BlueTeam = SplitObjects((string) reader["blue_team"], Summoner.Parse),
        PurpleTeam = SplitObjects((string) reader["purple_team"], Summoner.Parse),
        PlayerName = (string) reader["player_name"],
        ExitCode = (LogData.ExitCodes)Enum.Parse(typeof(LogData.ExitCodes), (string) reader["exit_code"]),
        Deaths = SplitObjects((string) reader["deaths"], int.Parse)
      };
    }
  }
}
