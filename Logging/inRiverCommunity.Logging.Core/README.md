# inRiverCommunity Logging Project
This logging framework is meant to be a lightweight, easy-to-implement and close-to-standard way of logging.


TODO: Can you use this https://timheuer.com/blog/building-a-code-analyzer-for-net/ to encourage users to use LogPlus instead of Log?


## Getting Started
1. Add a reference to the inRiverCommunity.Logging NuGet package `[TODO: Upload and add link!]`.
1. Configure your extension settings with the loggers you want to use and the settings for them.
1. Find and replace all existing "ontext.Log(LogLevel." with "ontext.LogPlus(LogLevel." and reference to `inRiverCommunity.Logging.Core` to the files.
1. Enjoy!


## Provided loggers
The loggers below are included in this logging framework.

### ControlCenterLogger
Does what it says!

**Full name:** `inRiverCommunity.Logging.Core.Loggers.ControlCenterLogger`\
**Requried settings:** `None`

### ConsoleAppLogger
Also pretty self-explanatory.

**Full name:** `inRiverCommunity.Logging.Core.Loggers.ConsoleAppLogger`\
**Requried settings:** `None`

### RollingFileLogger
Writes logs to a file on disk as they happen, using `File.AppendAllText`.

**Full name:** `inRiverCommunity.Logging.Core.Loggers.RollingFileLogger`\
**Requried settings:**
* `inRiverCommunity.RollingFileLogger.FilePath`, example value `@"C:\Temp\Logs\inRiverApp.{0}.{1}.log` (must be a full path!) where `{0}` is the ExtensionId and `{1}` is the `yyyy-MM-dd` timestamp.


## Building your own logger
1. Create a public class inheriting from the `inRiverCommunity.Logging.Core.ILogger` interface and make sure the class is included as a reference in your projects.

Feel free to look at the existing provided loggers for inspiration [TODO: Add link!].


## Usage examples
The below examples provide and insight into how to implement this in your new or existing solutions.

### Console App
```
using inRiver.Remoting;
using inRiver.Remoting.Extension;
using inRiver.Remoting.Log;
using inRiverCommunity.Logging.Core;
using System.Collections.Generic;

namespace MyNamespace.MyConsoleApp
{
    public class Program
    {

        static void Main(string[] args)
        {
            // 1. Create your inRiver context, you can decide if you want to pass an empty extension logger or something else.
            var context = new inRiverContext(RemoteManager.CreateInstance("[RemotingUrl]", "[Username]", "[Password]", "[Environment]"), new EmptyExtensionLogger());

            // 2. Configure your settings with the loggers you want to use and the settings for them
            context.Settings = new Dictionary<string, string>
            {
                { "inRiverCommunity.LoggerTypes", "inRiverCommunity.Logging.Core.Loggers.ConsoleAppLogger,inRiverCommunity.Logging.Core.Loggers.RollingFileLogger" },
                { "inRiverCommunity.RollingFileLogger.FilePath", @"C:\Temp\Logs\inRiverApp.{0}.{1}.log" }
            };

            // 3. Find and replace all existing "ontext.Log(LogLevel." with "ontext.LogPlus(LogLevel." and enjoy!
            context.LogPlus(LogLevel.Debug, "This is a test!");
        }

    }
}
```

### inRiver Extension
```
using inRiver.Remoting.Extension;
using inRiver.Remoting.Extension.Interface;
using inRiver.Remoting.Log;
using inRiverCommunity.Logging.Core;
using System.Collections.Generic;

namespace MyNamespace
{
    public class MyServerExtension : ILinkListener
    {
        public inRiverContext Context { get; set; }

        public Dictionary<string, string> DefaultSettings => new Dictionary<string, string>
        {
            // 1. Configure your settings with the loggers you want to use and the settings for them
            { "inRiverCommunity.LoggerTypes", "inRiverCommunity.Logging.Core.Loggers.ControlCenterLogger" }
            // TODO: Add your other default settings, feel free to check out the inRiverCommunity.Extensions helper for this. ;)
        };

        public string Test()
        {
            return "[something]";
        }

        public void LinkCreated(int linkId, int sourceId, int targetId, string linkTypeId, int? linkEntityId)
        {
            // 2. Find and replace all existing "ontext.Log(LogLevel." with "ontext.LogPlus(LogLevel." and enjoy!
            Context.LogPlus(LogLevel.Debug, "This is a test!");
        }

        public void LinkUpdated(int linkId, int sourceId, int targetId, string linkTypeId, int? linkEntityId) { }

        public void LinkDeleted(int linkId, int sourceId, int targetId, string linkTypeId, int? linkEntityId) { }

        public void LinkActivated(int linkId, int sourceId, int targetId, string linkTypeId, int? linkEntityId) { }

        public void LinkInactivated(int linkId, int sourceId, int targetId, string linkTypeId, int? linkEntityId) { }

    }
}
```


## How do I contribute

Feel free to submit an issue or create a pull request with a fix. All ideas and feedback are appreciated, just reach out to any of the contributors below. Thank you for the support!


## Contributors

* [Roy Eriksson](https://www.linkedin.com/in/roy-eriksson/)
* [Tobias Månsson](https://www.linkedin.com/in/tobiasmansson/)

Other people than mentioned above may have contributed to this project, have a look at the [contributors](https://github.com/inRiverCommunity/Extensions/graphs/contributors) page to see who they are.

*If you contributed to this project feel free to add your name to the list above.*


## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/inRiverCommunity/Logging/blob/master/LICENSE) file for details


## Acknowledgments

* Thanks to [inRiver](https://www.inriver.com/) and all the wonderful people there for allowing the inRiverCommunity project to exist!
* Thanks to the entire inRiver community for all the passion and engagement, you are the reason this project exists!