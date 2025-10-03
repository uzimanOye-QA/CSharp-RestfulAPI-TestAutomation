
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using Newtonsoft.Json;
using NUnit.Framework;
using Reqnroll;
using RestfulAPITestAutomationFramework.Model;
using RestfulAPITestAutomationFramework.SetUp;
using System;
using System.IO;
//using TechTalk.SpecFlow;


namespace RestfulAPITestAutomationFramework.StepDefinitions

{

    [Binding]
    public class CommonStep
    {
       

        private readonly Context context;

        private static ExtentReports? report;
        private static ExtentTest? feature;
        private ExtentTest? scenario;
        private readonly ScenarioContext scenarioContext;


        public CommonStep(Context _context, ScenarioContext _scenarioContext )
        {
            context = _context;

            scenarioContext = _scenarioContext;
        }

        [Given("that RestfulBooker web services with resource (.*) is loaded for GET call")]
        public void GivenThatRestfulBookerWebServicesIsLoadedForGETCall(string resource)
        {
            context.GetMethod(resource);
        }

        [Given("that RestfulBooker web services with resource (.*) is loaded for POST call")]
        public void GivenThatRestfulBookerWebServicesIsLoadedForPOSTCall(string resource)
        {
           
            //context.PostMethod(resource );
        }

        [Given("that RestfulBooker web services with resource (.*) is loaded for PUT call")]
        public void GivenThatRestfulBookerWebServicesIsLoadedForPUTCall(string resource)
        {

            
        }

        [Given("that RestfulBooker web services with resource (.*) is loaded for DELETE call")]
        public void GivenThatRestfulBookerWebServicesIsLoadedForDELETECall(string resource)
        {

            context.DeleteMethod(resource);
        }

        [Then("the status code must be equal to (.*)")]
        public void ThenTheStatusCodeMustBeEqualToCreated(string statusCode)
        {
            Assert.IsTrue(statusCode.Equals(context.statusCode), $"Expected status code: {statusCode} but found: {context.statusCode}");

        }


        [BeforeTestRun]
        public static void ReportGenerator()
        {
            string reportPath = Path.Combine(Directory.GetCurrentDirectory(), "ApiTestResult.html");

            var htmlReporter = new ExtentSparkReporter(reportPath);

            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = "RestfulBooker API Automation Report";
            htmlReporter.Config.ReportName = "API Regression Tests";
            report = new ExtentReports();
            report.AttachReporter(htmlReporter);

            report.AddSystemInfo("Host Name", "Local Host");
            report.AddSystemInfo("Environment", "QA");
            report.AddSystemInfo("User", "Usman A. Oyedele");

        }




            [AfterTestRun]

        public static void ReportCleaner()

        {

            report?.Flush();

        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (report == null)
                throw new Exception("Extent report is not initialized. Call ReportGenerator first.");

            feature = report.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }




        [BeforeScenario]
        public void SetupScenario()
        {
            if (feature == null)
                throw new Exception("Feature node not initialized.");

            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }


      


        [AfterStep]
        public void StepsInTheReport1()
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepText = scenarioContext.StepContext.StepInfo.Text;

            if (scenario == null) return;

            if (scenarioContext.TestError == null)
            {
                switch (stepType)
                {
                    case "Given": scenario.CreateNode<Given>(stepText).Pass("Passed"); break;
                    case "When": scenario.CreateNode<When>(stepText).Pass("Passed"); break;
                    case "Then": scenario.CreateNode<Then>(stepText).Pass("Passed"); break;
                }
            }
            else
            {
                switch (stepType)
                {
                    case "Given": scenario.CreateNode<Given>(stepText).Fail(scenarioContext.TestError.Message); break;
                    case "When": scenario.CreateNode<When>(stepText).Fail(scenarioContext.TestError.Message); break;
                    case "Then": scenario.CreateNode<Then>(stepText).Fail(scenarioContext.TestError.Message); break;
                }
                scenario.Log(Status.Fail, scenarioContext.TestError.StackTrace);
            }
        }







        [AfterScenario]
        public void CloseScenario()
        {
            if (scenarioContext.TestError != null)
            {
                string scenarioName = scenarioContext.ScenarioInfo.Title;
                scenario?.Log(Status.Fail, $"Scenario failed: {scenarioName}");
                scenario?.Log(Status.Fail, scenarioContext.TestError.StackTrace);
                context.SaveApiLogAsImage(scenarioName);

            }
            else
            {
                string scenarioName = scenarioContext.ScenarioInfo.Title;
                scenario?.Log(Status.Pass, "Scenario passed successfully.");
                context.SaveApiLog(scenarioName);

            }
        }




        [AfterStep]
        public void StepsInTheReport()
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepText = scenarioContext.StepContext.StepInfo.Text;

            if (scenario == null) return;

            if (scenarioContext.TestError == null)
            {
                switch (stepType)
                {
                    case "Given": scenario.CreateNode<Given>(stepText); break;
                    case "When": scenario.CreateNode<When>(stepText); break;
                    case "Then": scenario.CreateNode<Then>(stepText); break;
                }
            }
            else
            {
                switch (stepType)
                {
                    case "Given": scenario.CreateNode<Given>(stepText).Fail(scenarioContext.TestError.Message); break;
                    case "When": scenario.CreateNode<When>(stepText).Fail(scenarioContext.TestError.Message); break;
                    case "Then": scenario.CreateNode<Then>(stepText).Fail(scenarioContext.TestError.Message); break;
                }

                scenario.Log(Status.Fail, scenarioContext.TestError.StackTrace);

                context.SaveApiLogAsImage(scenarioContext.ScenarioInfo.Title);
            }
        }



    }
}
