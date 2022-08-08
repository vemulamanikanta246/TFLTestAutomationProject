using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomationFramework.Base;
using TestAutomationFramework.Extensions;

namespace ApplicationTest.Pages
{
    internal class PlanaJourneyPage : BasePage
    {
        public PlanaJourneyPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        IWebElement txt_From => _parallelConfig.Driver.FindElement(By.Id("InputFrom"));
        IWebElement error_From => _parallelConfig.Driver.FindElement(By.XPath("//span[@id='InputFrom-error']"));
        IWebElement error_To => _parallelConfig.Driver.FindElement(By.XPath("//span[@id='InputTo-error']"));
        IWebElement txt_To => _parallelConfig.Driver.FindElement(By.Id("InputTo"));
        IWebElement btn_PlanmyJourney => _parallelConfig.Driver.FindElement(By.CssSelector("input#plan-journey-button"));
        IWebElement link_Changetime => _parallelConfig.Driver.FindElement(By.XPath("//a[@class='change-departure-time']"));
        IWebElement select_Arriving => _parallelConfig.Driver.FindElement(By.XPath("//label[@for='arriving']"));
        IWebElement ddl_Day => _parallelConfig.Driver.FindElement(By.XPath("//select[@id='Date']"));
        IWebElement ddl_Time => _parallelConfig.Driver.FindElement(By.XPath("//select[@id='Time']"));

        public void Enter_Journey_Details(string from, string to)
        {
            txt_From.SendKeys(from);
            txt_To.SendKeys(to);
        }

        public JourneyResultsPage ClickPlanmyJourney()
        {
            btn_PlanmyJourney.Click();
            return new JourneyResultsPage(_parallelConfig);
        }

        public void ClickPlanmyJourney_ErrorValidation()
        {
            btn_PlanmyJourney.Click();
        }

        internal string Error_From()
        {
            WebDriverExtensions.WaitFor_ElementTobe_Visible(_parallelConfig.Driver, "//span[@id='InputFrom-error']");
            return error_From.Text;
        }

        internal string Error_To()
        {
            WebDriverExtensions.WaitFor_ElementTobe_Visible(_parallelConfig.Driver, "//span[@id='InputTo-error']");
            return error_To.Text;
        }

        internal void Select_Change_Time(string arriving, string day, string time)
        {
            link_Changetime.Click();
            select_Arriving.Click();
            WebElementExtensions.SelectDropDownList(ddl_Day, "Tomorrow");
            WebElementExtensions.SelectDropDownList(ddl_Time, "15:30");
        }
    }
}
