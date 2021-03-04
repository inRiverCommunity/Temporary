using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;
using System;

namespace inRiverCommunity.Logging.Core.Loggers
{
    public class ConsoleAppLogger : ILogger
    {


        public void Initialize(inRiverContext context) { }


        public void Log(DateTime timestamp, LogLevel logLevel, string message)
        {
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}, {logLevel}: {message}");
        }

        public void Log(DateTime timestamp, LogLevel logLevel, string message, Exception ex)
        {
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}, {logLevel}: {message}");
            Console.WriteLine($"Exception message: {ex.Message}");
            Console.WriteLine($"Exception Stack Trace: {ex.StackTrace}");
        }


    }
}
