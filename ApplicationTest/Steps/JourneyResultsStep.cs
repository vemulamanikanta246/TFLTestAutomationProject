using ApplicationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestAutomationFramework.Base;

namespace ApplicationTest.Steps
{
    [Binding]
    internal class JourneyResultsStep : BaseStep
    {
        //Context injection
        private readonly ParallelConfig _parallelConfig;
        public JourneyResultsStep(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [Then(@"Verify landed on Journey results page")]
        public void ThenVerifyLandedOnJourneyResultsPage()
        {
            _parallelConfig.CurrentPage.As<JourneyResultsPage>().Check_If_Landed_on_Journey_results();
        }


        [Then(@"Verify Fastest by public transport is displayed")]
        public void ThenVerifyFastestByPublicTransportIsDisplayed()
        {
            _parallelConfig.CurrentPage.As<JourneyResultsPage>().Check_header_Fastest_by_public_transport();
        }

        [Then(@"Verify error message (.*) is displayed")]
        public void ThenVerifyErrorMessageSorryWeCanTFindAJourneyMatchingYourCriteriaIsDisplayed(string message)
        {
            _parallelConfig.CurrentPage.As<JourneyResultsPage>().Check_Error_invalid_journey_planned(message);
        }

        [When(@"Edit journey")]
        public void WhenEditJourney()
        {
            _parallelConfig.CurrentPage.As<JourneyResultsPage>().Click_Edit_Journey();
        }

        [When(@"Change time (.*), (.*), (.*) in Journey results page")]
        public void WhenChangeTimeArrivingTomorrowInJourneyResultsPage(string arriving, string day, string time)
        {
            _parallelConfig.CurrentPage.As<JourneyResultsPage>().Select_Change_Time(arriving, day, time);
        }

    }
}
