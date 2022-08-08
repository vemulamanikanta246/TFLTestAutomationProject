using System;
using System.IO;
using TestAutomationFramework.Base;
using Microsoft.Extensions.Configuration;

namespace TestAutomationFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            IConfigurationRoot configurationRoot = builder.Build();


            Settings.AUT = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUT;
            Settings.TestType = configurationRoot.GetSection("testSettings").Get<TestSettings>().TestType;
            Settings.IsLog = configurationRoot.GetSection("testSettings").Get<TestSettings>().IsLog;
            Settings.LogPath = configurationRoot.GetSection("testSettings").Get<TestSettings>().LogPath;
            Settings.BrowserType = configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser;
            Settings.DefaultExplicitWait = configurationRoot.GetSection("testSettings").Get<TestSettings>().DefaultExplicitWait;
        }

    }
}
