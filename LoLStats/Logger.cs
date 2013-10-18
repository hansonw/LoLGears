using System;
using System.IO;
using log4net;

namespace LoLStats
{
  class Logger
  {
    private static ILog log;
    static Logger() {
      var pattern = "%date %level - %message %exception%newline";
      var appender = new log4net.Appender.RollingFileAppender {
        Layout = new log4net.Layout.PatternLayout(pattern),
        File = "log.txt",
        AppendToFile = true,
        RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Composite,
        MaxSizeRollBackups = 1,
        MaximumFileSize = "1MB",
        StaticLogFileName = true
      };
      appender.ActivateOptions();
      log4net.Config.BasicConfigurator.Configure(appender);
      log = LogManager.GetLogger("LoLStats");
    }

    public static void LogException(Exception e) {
      if (log.IsErrorEnabled) {
        while (e.InnerException != null) e = e.InnerException;
        log.Error("Exception:", e);
      }
    }

    public static void LogMessage(string message, bool error = false) {
      if (log.IsErrorEnabled) {
        if (error) {
          log.Error(message);
        } else {
          log.Info(message);
        }
      }
    }
  }
}