using System;
using System.Collections.Generic;
using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;
using inRiverCommunity.Extensions.Core.Settings;

namespace inRiverCommunity.Logging.Core
{
    public class LogContext : IExtensionLog
    {


        private List<ILogger> LoggerList { get; set; }


        public LogContext(inRiverContext context)
        {
            LoggerList = new List<ILogger>();

            var settings = context.GetSettings<LogContextSettings>();

            foreach (var loggers in settings.Loggers)
            {
                // TODO: Init loggers!
            }
        }


        /// <summary>
        /// Shorthand for 'LogContextManager.Get(context);' method.
        /// </summary>
        /// <param name="context">Initialized inRiver Context</param>
        /// <returns>Initialized LogContext</returns>
        public static LogContext Get(inRiverContext context)
        {
            return LogContextManager.Get(context);
        }


        #region IExtensionLog Interface Methods

        public void Log(LogLevel level, string message)
        {
            var timestamp = DateTime.Now;

            foreach (var logger in LoggerList)
                logger.Log(timestamp, level, message);
        }

        public void Log(LogLevel level, string message, Exception ex)
        {
            var timestamp = DateTime.Now;

            foreach (var logger in LoggerList)
                logger.Log(timestamp, level, message, ex);
        }

        #endregion


    }
}
