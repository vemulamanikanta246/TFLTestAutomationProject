using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomationFramework.Base;
using TestAutomationFramework.Extensions;

namespace ApplicationTest.Pages
{
    internal class TFLhomePage : BasePage
    {
        public TFLhomePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }
        IWebElement btn_Acceptallcookies => _parallelConfig.Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        IWebElement btn_Done => _parallelConfig.Driver.FindElement(By.XPath("//button/strong[contains(text(),'Done')]"));
        IWebElement navbar_Planajourney => _parallelConfig.Driver.FindElement(By.XPath("//ul[@class='collapsible-menu clearfix']/li[@class='plan-journey']"));
        IWebElement tab_Recents => _parallelConfig.Driver.FindElement(By.XPath("//div[@id='recent-journeys']//a[contains(text(),'Recents')]"));
        IWebElement item_Recent_JourneyPlan => _parallelConfig.Driver.FindElement(By.XPath("//div[@id='recent-journeys']//a[@data-journey-type='recent']"));
        
        internal void CheckIfApplicationLanded()
        {
            btn_Acceptallcookies.AssertElementPresent();
        }
        internal void AcceptCookies()
        {
            btn_Acceptallcookies.Click();
            btn_Done.Click();
        }

        internal PlanaJourneyPage Navigate_To_PlanaJourney()
        {
            navbar_Planajourney.Click();
            return new PlanaJourneyPage(_parallelConfig);
        }

        internal void Click_Recents(string tab)
        {
            tab_Recents.Click();
        }

        internal JourneyResultsPage Select_Recent_JourneyPlan()
        {
            if (_parallelConfig.Driver.FindElements(By.XPath("//div[@id='jp-recent-content-home-']/a")).Count > 0)
            {
                item_Recent_JourneyPlan.Click();
            }
            return new JourneyResultsPage(_parallelConfig);
        }
    }
}
