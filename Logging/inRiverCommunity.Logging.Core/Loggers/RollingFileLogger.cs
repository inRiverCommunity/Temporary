using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;
using inRiverCommunity.Extensions.Core.Settings;
using System;
using System.IO;

namespace inRiverCommunity.Logging.Core.Loggers
{


    #region Settings class

    public class RollingFileLoggerSettings
    {

        [ExtensionSetting(Name = "inRiverCommunity.RollingFileLogger.FilePath")]
        public string FilePath { get; set; } = @"C:\Temp\Logs\inRiver.{0}.{1}.log";

    }

    #endregion


    public class RollingFileLogger : ILogger
    {


        private RollingFileLoggerSettings _settings;
        private string _extensionId;


        public void Initialize(inRiverContext context)
        {
            if (context == null)
                throw new NullReferenceException("Input 'context' for 'inRiverLogger.Initialize(context)' is null!");

            _extensionId = context.ExtensionId;
            _settings = context.GetSettings<RollingFileLoggerSettings>();

            if (string.IsNullOrEmpty(_settings.FilePath))
                throw new Exception("The 'FilePath' setting is null/empty!");
        }


        private string GetFilePath(DateTime timestamp)
        {
            return string.Format(_settings.FilePath, _extensionId, timestamp.ToString("yyyy-MM-dd"));
        }


        public void Log(DateTime timestamp, LogLevel logLevel, string message)
        {
            File.AppendAllText(GetFilePath(timestamp), $"{timestamp.ToString("yyyy-MM-dd HH:mm:ss")}, {logLevel}: {message}{Environment.NewLine}");
        }

        public void Log(DateTime timestamp, LogLevel logLevel, string message, Exception ex)
        {
            var filePath = GetFilePath(timestamp);

            File.AppendAllText(filePath, $"{timestamp.ToString("yyyy-MM-dd HH:mm:ss")}, {logLevel}: {message}{Environment.NewLine}");
            File.AppendAllText(filePath, $"Exception message: {ex.Message}{Environment.NewLine}");
            File.AppendAllText(filePath, $"Exception Stack Trace: {ex.StackTrace}{Environment.NewLine}");
        }


    }
}
