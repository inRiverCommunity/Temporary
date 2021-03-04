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
            // TODO: Should we do this or let this be a separate logger?
            /*
            // Log to regular inRiver log
            if (ex == null)
                context.Log(level, message);
            else
                context.Log(level, message, ex);
            */


            // Get log context and log to it's initialized loggers
            var logContext = LogContextManager.Get(context);

            if (ex == null)
                logContext.Log(level, message);
            else
                logContext.Log(level, message, ex);
        }

    }
}
