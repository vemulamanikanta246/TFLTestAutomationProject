using ApplicationTest.Hooks;
using ApplicationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestAutomationFramework.Base;
using TestAutomationFramework.Config;

namespace ApplicationTest.Steps
{
    [Binding]
    internal class ExtendedSteps : BaseStep
    {
        //Context injection
        private readonly ParallelConfig _parallelConfig;
        
        public ExtendedSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [Given(@"Navigate to the application")]
        public void GivenNavigateToTheApplication()
        {
            NavigateSite(Settings.AUT);
            _parallelConfig.CurrentPage = new TFLhomePage(_parallelConfig);
            _parallelConfig.CurrentPage.As<TFLhomePage>().CheckIfApplicationLanded();
            _parallelConfig.CurrentPage.As<TFLhomePage>().AcceptCookies();
        }

        [Given(@"Navigate to tab (.*)")]
        public void GivenNavigateToTabPlanAJourney(string navBar)
        {
            switch (navBar)
            {
                case "Plan a journey":
                    _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<TFLhomePage>().Navigate_To_PlanaJourney();
                    break;
                default:
                    break;
            }
        }

        [When(@"Submit (.*)")]
        public void WhenSubmit(string button)
        {
            switch (button)
            {
                case "Plan my journey":
                    _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<PlanaJourneyPage>().ClickPlanmyJourney();
                    break;
                default:
                    break;
            }
        }

        [When(@"Navigate to (.*)")]
        public void WhenNavigateToHome(string page)
        {
            switch (page)
            {
                case "Home":
                    _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<JourneyResultsPage>().Click_Home(page);
                    break;
                default:
                    break;
            }
        }

        [When(@"Click (.*) tab")]
        public void WhenClickRecentsTab(string tab)
        {
            switch (tab)
            {
                case "Recents":
                    _parallelConfig.CurrentPage.As<TFLhomePage>().Click_Recents(tab);
                    break;
                default:
                    break;
            }
        }
    }
}
