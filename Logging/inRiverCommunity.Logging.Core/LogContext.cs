using System;
using System.Collections.Generic;
using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;
using inRiverCommunity.Extensions.Core.Settings;

namespace inRiverCommunity.Logging.Core
{


    #region Settings class

    public class LogContextSettings
    {

        [ExtensionSetting(
            Name = "inRiverCommunity.LoggerTypes",
            CollectionDelimiter = ",",
            CollectionTrimValues = true,
            CollectionRemoveEmptyValues = true
        )]
        public List<string> Loggers { get; set; } = new List<string>
        {
            "inRiverCommunity.Logging.Core.Loggers.inRiverStandardLogger",
            "inRiverCommunity.Logging.Core.Loggers.ConsoleAppLogger",
            "inRiverCommunity.Logging.Core.Loggers.RollingFileLogger"
        };

    }

    #endregion


    public class LogContext
    {


        private List<ILogger> LoggerList { get; set; }


        public LogContext(inRiverContext context)
        {
            LoggerList = new List<ILogger>();


            // Get settings from extension
            var settings = context.GetSettings<LogContextSettings>();


            // Loop loggers to create instances for
            foreach (var logger in settings.Loggers)
            {
                // Create instance
                ILogger instance = null;

                try
                {
                    instance = (ILogger)Activator.CreateInstance(Type.GetType(logger));
                }
                catch (Exception ex)
                {
                    context.Log(LogLevel.Error, $"Failed to create instance of logger '{logger}' for extension '{context.ExtensionId}'!", ex);
                }

                if (instance == null)
                    continue;


                // Initalize logger and add to list if successful
                try
                {
                    instance.Initialize(context);

                    LoggerList.Add(instance);
                }
                catch (Exception ex)
                {
                    context.Log(LogLevel.Error, $"Failed to initialize logger '{logger}' for extension '{context.ExtensionId}'!", ex);
                }
            }
        }


        public List<Type> GetLoadedLoggerTypes()
        {
            var list = new List<Type>();

            foreach (var logger in LoggerList)
                list.Add(logger.GetType());

            return list;
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
