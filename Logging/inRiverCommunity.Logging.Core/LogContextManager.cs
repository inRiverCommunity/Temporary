using inRiver.Remoting.Extension;
using System;
using System.Collections.Generic;

namespace inRiverCommunity.Logging.Core
{
    public static class LogContextManager
    {


        private static Dictionary<string, LogContext> LogContextCache = new Dictionary<string, LogContext>();


        public static LogContext Get(inRiverContext context)
        {
            if (context == null)
                throw new NullReferenceException("Input parameter 'context' to LogContextManager.Get(context) cannot be null/empty!");


            if (LogContextCache.ContainsKey(context.ExtensionId))
                return LogContextCache[context.ExtensionId];


            var logContext = new LogContext(context);

            LogContextCache.Add(context.ExtensionId, logContext);

            return logContext;
        }


    }
}
