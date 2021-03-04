using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;
using System;

namespace inRiverCommunity.Logging.Core
{
    public class EmptyExtensionLogger : IExtensionLog
    {


        public void Log(LogLevel level, string message) { }

        public void Log(LogLevel level, string message, Exception ex) { }


    }
}
