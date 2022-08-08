using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using TestAutomationFramework.Base;
using NUnit.Framework;
using TestAutomationFramework.Helpers;
//Same parallel
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace ApplicationTest.Hooks
{

    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static ExtentKlovReporter klov;
        private readonly ParallelConfig _parallelConfig;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenarioName;
        public static string ScenarioName;
        private static TestInitializeHook testInitializeHook;

        public HookInitialize(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }


        [AfterStep]
        public void AfterEachStep()
        {

            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                //screenshot in the Base64 format
                var mediaEntity = _parallelConfig.CaptureScreenshotAndReturnModel(_scenarioContext.ScenarioInfo.Title.Trim());

                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
            }
            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }
        }

        [BeforeTestRun]
        public static void TestInitalize()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(@"C:\TFLTestAutomationProject\ExtentReport.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new AventStack.ExtentReports.ExtentReports();
            klov = new ExtentKlovReporter();
            extent.AttachReporter(htmlReporter);
        }


        [BeforeScenario]
        public void Initialize()
        {
            InitializeSettings();
            //Settings.ApplicationCon = Settings.ApplicationCon.DBConnect(Settings.AppConnectionString);

            //Get feature Name
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);

            //Create dynamic scenario name
            _currentScenarioName = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            ScenarioName = _scenarioContext.ScenarioInfo.Title;

            LogHelpers.CreateLogFile();
        }



        [AfterScenario]
        public void TestStop()
        {
            //DriverContext.Driver.Quit();
            //Flush report once test completes
            _parallelConfig.Driver.Close();
            _parallelConfig.Driver.Quit();
            //WebDriverExtensions.CloseAllWindowsExceptParentWindow(_parallelConfig.Driver);

            //Flush report once test completes
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeofreFeature()
        {
            //Create dynamic feature nema
            //featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //_parallelConfig.Driver.Close();
            //_parallelConfig.Driver.Quit();
            //Flush report once test completes
            extent.Flush();
        }


    }
}
