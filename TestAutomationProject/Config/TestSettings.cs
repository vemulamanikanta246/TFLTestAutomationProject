﻿using TestAutomationFramework.Base;
using Newtonsoft.Json;

namespace TestAutomationFramework.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("aut")]
        public string AUT { get; set; }


        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }


        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("isLog")]
        public string IsLog { get; set; }

        [JsonProperty("logPath")]
        public string LogPath { get; set; }

        [JsonProperty("defaultExplicitWait")]
        public string DefaultExplicitWait { get; set; }
        
    }
}
