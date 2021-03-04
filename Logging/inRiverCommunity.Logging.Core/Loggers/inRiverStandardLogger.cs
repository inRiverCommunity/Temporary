using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;
using System;

namespace inRiverCommunity.Logging.Core.Loggers
{
    public class inRiverStandardLogger : ILogger
    {


        private inRiverContext _context;

        public void Initialize(inRiverContext context)
        {
            if (context == null)
                throw new NullReferenceException("Input 'context' for 'inRiverLogger.Initialize(context)' is null!");

            _context = context;
        }


        public void Log(DateTime timestamp, LogLevel level, string message)
        {
            _context.Log(level, message);
        }

        public void Log(DateTime timestamp, LogLevel level, string message, Exception ex)
        {
            _context.Log(level, message, ex);
        }


    }
}
