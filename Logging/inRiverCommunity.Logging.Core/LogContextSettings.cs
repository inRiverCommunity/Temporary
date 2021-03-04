using inRiverCommunity.Extensions.Core.Settings;
using System.Collections.Generic;

namespace inRiverCommunity.Logging.Core
{
    public class LogContextSettings
    {


        [ExtensionSetting(
            Name = "inRiverCommunity.Loggers",
            CollectionDelimiter = ",", // It's mandatory to specify a delimiter for string lists, there's no default delimiter.
            CollectionTrimValues = true, // Set this if you want to 'string.Trim()' entered values.
            CollectionRemoveEmptyValues = true // Set this if you want to remove empty values.
        )]
        public List<string> Loggers { get; set; }


    }
}
