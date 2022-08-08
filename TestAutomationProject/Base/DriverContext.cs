using OpenQA.Selenium;

namespace TestAutomationFramework.Base
{
    public class DriverContext
    {
        private static IWebDriver _driver;
        public readonly ParallelConfig _parellelConfig;

        public DriverContext(ParallelConfig parellelConfig)
        {
            _parellelConfig = parellelConfig;
        }


        public void GoToUrl(string url)
        {
            _parellelConfig.Driver.Url = url;
        }


        public static Browser Browser { get; set; }

        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }
    }
}
