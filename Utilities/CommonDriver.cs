using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AdvancedTask.Utilities
{
    [SetUpFixture]
    public class CommonDriver
    {
        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;

        [OneTimeSetUp]
        public static void ExtentStart()
        {
            if (extent == null)
            {
                extent = new ExtentReports();
                var SparkReporter = new ExtentSparkReporter("D:\\Hema\\IndustryConnect\\Internship\\AdvancedTask\\ExtentReports\\ExtentReport.html");
                extent.AttachReporter(SparkReporter);
            }
        }
        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            driver.Manage().Window.Maximize();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void TearDown()
        {
            //If tests fails capture screenshot
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string testName = TestContext.CurrentContext.Test.Name;
                test.Log(Status.Fail, $"Tests  '{testName}' failed");
                CaptureScreenshot(testName);
            }
            driver.Quit();
        }
        [OneTimeTearDown]
        public static void ExtentClose()
        {
            extent.Flush();
        }
        public void CaptureScreenshot(string testName)
        {
            string screenshotFileName = $"screenshot_{testName}";
            //Capture the screenshot
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();

            //Specify the path and filename for the screenshot with a timestamp
            string filepath = "D:\\Hema\\IndustryConnect\\Internship\\AdvancedTask\\Screenshot";
            string screenshotPath = Path.Combine(filepath, $"{screenshotFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

            // Ensure the directory exists before saving the screenshot
            Directory.CreateDirectory(filepath);

            // Save the screenshot
            screenshot.SaveAsFile(screenshotPath);
        }
    }
}
