using ApplicationTest.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutomationFramework.Base;

namespace ApplicationTest.Steps
{
    [Binding]
    public class PlanaJourneySteps : BaseStep
    {
        //Context injection
        private readonly ParallelConfig _parallelConfig;

        public PlanaJourneySteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [When(@"Enter valid journey details From and To")]
        public void WhenEnterValidJourneyDetailsFromAndTo(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _parallelConfig.CurrentPage.As<PlanaJourneyPage>().Enter_Journey_Details(data.From, data.To);
        }

        [When(@"Without enter journey details Submit Plan my journey")]
        public void WhenWithoutEnterJourneyDetailsSubmitPlanMyJourney()
        {
            _parallelConfig.CurrentPage.As<PlanaJourneyPage>().ClickPlanmyJourney_ErrorValidation();
        }

        [Then(@"Verify error messages (.*) and (.*) are displayed")]
        public void ThenVerifyErrorMessagesTheFromFieldIsRequired_AndTheToFieldIsRequired_AreDisplayed(string message1, string message2)
        {
            Assert.AreEqual(message1, _parallelConfig.CurrentPage.As<PlanaJourneyPage>().Error_From());
            Assert.AreEqual(message2, _parallelConfig.CurrentPage.As<PlanaJourneyPage>().Error_To());
        }

        [When(@"Change time (.*), (.*), (.*) in Plan a journey page")]
        public void WhenChangeTimeArrivingTomorrow(string arriring, string day, string time)
        {
            _parallelConfig.CurrentPage.As<PlanaJourneyPage>().Select_Change_Time(arriring, day, time);
        }


    }
}
