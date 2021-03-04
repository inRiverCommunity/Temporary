using inRiver.Remoting.Extension;
using System;
using System.Collections.Generic;

namespace inRiverCommunity.Logging.Core
{


    // TODO: This is not needed?


    public static class LogContextManager
    {


        private static Dictionary<string, LogContext> LogContextCache = new Dictionary<string, LogContext>();


        public static LogContext Get(inRiverContext context)
        {
            if (context == null)
                throw new NullReferenceException("Input parameter 'context' to LogContextManager.Get(context) cannot be null/empty!");


            // Fallback if no extension id is available
            var id = context.ExtensionId;

            if (string.IsNullOrEmpty(id))
                id = "[NoExtensionId]";


            if (LogContextCache.ContainsKey(id))
                return LogContextCache[id];


            var logContext = new LogContext(context);

            LogContextCache.Add(id, logContext);

            return logContext;
        }


    }
}
