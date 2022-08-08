using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomationFramework.Base;
using TestAutomationFramework.Extensions;

namespace ApplicationTest.Pages
{
    internal class JourneyResultsPage : BasePage
    {
        public JourneyResultsPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        IWebElement header_Journey_results => _parallelConfig.Driver.FindElement(By.XPath("//h1/span[contains(text(),'Journey results')]"));
        IWebElement header_Fastest_by_public_transport => _parallelConfig.Driver.FindElement(By.XPath("//h2[contains(text(),'Fastest by public transport')]"));
        IWebElement error_invalid_journey_planned => _parallelConfig.Driver.FindElement(By.XPath("//li[@class='field-validation-error']"));
        IWebElement link_Edit_Journey => _parallelConfig.Driver.FindElement(By.XPath("//a[@class='edit-journey']"));
        IWebElement btn_Update_Journey => _parallelConfig.Driver.FindElement(By.XPath("//input[@id='plan-journey-button']"));
        IWebElement link_Changetime => _parallelConfig.Driver.FindElement(By.XPath("//a[@class='change-departure-time']"));
        IWebElement select_Arriving => _parallelConfig.Driver.FindElement(By.XPath("//label[@for='arriving']"));
        IWebElement ddl_Day => _parallelConfig.Driver.FindElement(By.XPath("//select[@id='Date']"));
        IWebElement ddl_Time => _parallelConfig.Driver.FindElement(By.XPath("//select[@id='Time']"));
        IWebElement navbar_Home => _parallelConfig.Driver.FindElement(By.XPath("//span[contains(text(),'Home')]"));

        internal void Check_If_Landed_on_Journey_results()
        {
            WebDriverExtensions.WaitForPageLoaded(_parallelConfig.Driver);
            header_Journey_results.AssertElementPresent();
        }

        internal void Check_header_Fastest_by_public_transport()
        {
            WebDriverExtensions.WaitFor_ElementTobe_Visible(_parallelConfig.Driver, "//h2[contains(text(),'Fastest by public transport')]");
            header_Fastest_by_public_transport.AssertElementPresent();
        }

        internal void Check_Error_invalid_journey_planned(string message)
        {
            WebDriverExtensions.WaitFor_ElementTobe_Visible(_parallelConfig.Driver, "//li[@class='field-validation-error']");
            Assert.AreEqual(message, error_invalid_journey_planned.Text);
        }

        internal void Click_Edit_Journey()
        {
            link_Edit_Journey.Click();
        }

        internal void Select_Change_Time(string arriving, string day, string time)
        {
            WebDriverExtensions.WaitFor_ElementTobe_Visible(_parallelConfig.Driver, "//label[@for='arriving']");
            select_Arriving.Click();
            WebElementExtensions.SelectDropDownList(ddl_Day, "Tomorrow");
            WebElementExtensions.SelectDropDownList(ddl_Time, "15:30");
        }

        public TFLhomePage Click_Home(string home)
        {
            navbar_Home.Click();
            return new TFLhomePage(_parallelConfig);
        }
    }
}
