using TestAutomationFramework.Config;
using TestAutomationFramework.Helpers;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Remote;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace TestAutomationFramework.Base
{
    public class TestInitializeHook : Steps
    {

        private readonly ParallelConfig _parallelConfig;

        public TestInitializeHook(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set Log
            LogHelpers.CreateLogFile();

            //Open Browser
            OpenBrowser(GetBrowserOption(Settings.BrowserType));

            LogHelpers.Write("Initialized framework");

        }

        private void OpenBrowser(DriverOptions driverOptions)
        {
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:
                    break;
                case FirefoxOptions firefoxOptions:
                    break;
                case ChromeOptions chromeOptions:
                    var cloudOptions = new Dictionary<string, object>();
                    chromeOptions.AddAdditionalOption("cloud:options", cloudOptions);
                    _parallelConfig.Driver = new ChromeDriver();
                    break;
            }

            _parallelConfig.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(int.Parse(Settings.DefaultExplicitWait.ToString()));
            _parallelConfig.Driver.Manage().Window.Maximize();
            _parallelConfig.Driver.SwitchTo().ActiveElement();
            _parallelConfig.Driver.Manage().Cookies.DeleteAllCookies();           
        }

        public virtual void NaviateSite()
        {
            //DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Opened the browser !!!");
        }


        public DriverOptions GetBrowserOption(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    return new InternetExplorerOptions();
                case BrowserType.FireFox:
                    return new FirefoxOptions();
                case BrowserType.Chrome:
                    return new ChromeOptions();
                default:
                    return new ChromeOptions();
            }
        }
    }
}
