namespace PredefinedCassie
{
    using Exiled.API.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel;

    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("If you set it to false, all predefined cassies will not have the starting and ending sound and noise between them")]
        public bool AreCassiesNoisy { get; set; } = true;

        public Dictionary<string, string> PredefiniedCassies { get; set; } = new Dictionary<string, string>
        {
            { "example", "containment breach detected" },
            { "example2", "bell_start containment breach detected bell_end" }
        };
    }
}