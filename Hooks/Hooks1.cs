using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProjectDemo.Utlities;
using TechTalk.SpecFlow;
using Feature = AventStack.ExtentReports.Gherkin.Model.Feature;

namespace SpecFlowProjectDemo.Hooks
{
    [Binding]
    public  class Hooks1 : reports
    {
        
        public readonly IObjectContainer container;
        public Hooks1(IObjectContainer _container) 
        { 
            container = _container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
           ExtentReportTearDown();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
           feature = extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }
        public IWebDriver driver;
        [BeforeScenario]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            if (TestContext.Parameters["browser"].ToString().Equals("chrome"))
            {
                driver = new ChromeDriver();
            }
            
            container.RegisterInstanceAs<IWebDriver>(driver);

            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = container.Resolve<IWebDriver>();
            if(driver != null)
            {
                driver.Quit();
            }
        }
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = container.Resolve<IWebDriver>();

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(stepName);
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message);
                    //MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message);
                       // MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message);
                        //MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message);
                       // MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
    }
}