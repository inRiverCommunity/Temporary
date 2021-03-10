using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;
using System;

namespace inRiverCommunity.Logging.Core
{
    public static class LoggingExtensionMethods
    {


        // TODO: LogPlus or LogExtra as the name? or something else?
        public static void LogPlus(this inRiverContext context, LogLevel level, string message, Exception ex = null)
        {
            var logContext = LogContextManager.Get(context);

            if (ex == null)
                logContext.Log(level, message);
            else
                logContext.Log(level, message, ex);
        }


        public static void LogVerbose(this inRiverContext context, string message, Exception ex = null)
        {
            var logContext = LogContextManager.Get(context);

            if (ex == null)
                logContext.Log(LogLevel.Verbose, message);
            else
                logContext.Log(LogLevel.Verbose, message, ex);
        }

        public static void LogDebug(this inRiverContext context, string message, Exception ex = null)
        {
            var logContext = LogContextManager.Get(context);

            if (ex == null)
                logContext.Log(LogLevel.Debug, message);
            else
                logContext.Log(LogLevel.Debug, message, ex);
        }

        public static void LogInformation(this inRiverContext context, string message, Exception ex = null)
        {
            var logContext = LogContextManager.Get(context);

            if (ex == null)
                logContext.Log(LogLevel.Information, message);
            else
                logContext.Log(LogLevel.Information, message, ex);
        }

        public static void LogWarning(this inRiverContext context, string message, Exception ex = null)
        {
            var logContext = LogContextManager.Get(context);

            if (ex == null)
                logContext.Log(LogLevel.Warning, message);
            else
                logContext.Log(LogLevel.Warning, message, ex);
        }

        public static void LogError(this inRiverContext context, string message, Exception ex = null)
        {
            var logContext = LogContextManager.Get(context);

            if (ex == null)
                logContext.Log(LogLevel.Error, message);
            else
                logContext.Log(LogLevel.Error, message, ex);
        }


    }
}
