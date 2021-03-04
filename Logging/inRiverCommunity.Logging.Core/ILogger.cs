using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;
using System;

namespace inRiverCommunity.Logging.Core
{
    public interface ILogger
    {


        void Initialize(inRiverContext context);


        void Log(DateTime timestamp, LogLevel level, string message);

        void Log(DateTime timestamp, LogLevel level, string message, Exception ex);


    }
}
