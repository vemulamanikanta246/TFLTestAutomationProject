using ApplicationTest.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestAutomationFramework.Base;

namespace ApplicationTest.Steps
{
    [Binding]
    internal class TFLHomepageStep : BaseStep
    {
        //Context injection
        private readonly ParallelConfig _parallelConfig;

        public TFLHomepageStep(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        [When(@"Select recent journey plan")]
        public void WhenSelectRecentJourneyPlan()
        {
            _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<TFLhomePage>().Select_Recent_JourneyPlan();
        }


    }
}
