using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;
using System;
using System.Collections.Generic;

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

    }
}
