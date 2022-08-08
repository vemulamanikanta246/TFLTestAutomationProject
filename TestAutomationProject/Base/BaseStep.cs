using TestAutomationFramework.Config;
using TestAutomationFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestAutomationFramework.Base
{
    public class BaseStep : Base
    {
        public BaseStep(ParallelConfig parellelConfig) : base(parellelConfig)
        {
        }

        public virtual void NavigateSite(string url)
        {
            _parallelConfig.Driver.Navigate().GoToUrl(url);
        }
    }
}
