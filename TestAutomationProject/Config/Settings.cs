using TestAutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Config
{
    public class Settings
    {
        public static string  TestType { get; set; }

        public static string AUT { get; set; }

        public static BrowserType BrowserType { get; set; }

        public static string IsLog { get; set; }

        public static string LogPath { get; set; }
        public static string DefaultExplicitWait { get; set; }

    }
}
