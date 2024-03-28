using AdvancedTask.Data;
using AdvancedTask.Pages;
using AdvancedTask.Pages.Components.ProfileAboutMe;
using AdvancedTask.Steps;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace AdvancedTask.Tests
{
    [TestFixture]
    public class Profile_Tests: CommonDriver
    {
        LoginPageSteps loginPageSteps;
        ProfileComponent profileComponent;
        ProfilePageSteps profilePageSteps;
        public static ExtentTest test;
        public static ExtentReports extent;

        public Profile_Tests()
        {
            loginPageSteps = new LoginPageSteps();
            profilePageSteps = new ProfilePageSteps();
        }

        [SetUp]
        public void LoginSetUp()
        {
            //Open Chrome browser
            Initialize();

            //Login page object initialization and definition
            loginPageSteps.SigninActions();
            loginPageSteps.LoginActions();
       
        }
        [OneTimeSetUp]
        public void ExtentStart()
        {

            // Create a new instance of ExtentReports to manage test reports
            extent = new ExtentReports();

            // Create a new ExtentSparkReporter to define the HTML report file path and configuration
            var sparkReporter = new ExtentSparkReporter(@"D:\Hema\IndustryConnect\Internship\AdvancedTask\ExtentReports\SearchSkillReport.html");

            // Attach the ExtentSparkReporter to the ExtentReports instance for report generation
            extent.AttachReporter(sparkReporter);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            // Flush the ExtentReports instance to finalize and write all information to the report files
            extent.Flush();
        }

        [Test, Order(1), Description("Updating availability details")]
        [TestCase(1)]
        public void Edit_Availability(int id)
        {
            profilePageSteps.editAvailability(id);
         }

        [Test, Order(2), Description("Updating hours details")]
        [TestCase(1)]
        public void Edit_Hours(int id)
        {
            profilePageSteps.editHour(id);
        }

        [Test, Order(3), Description("Updating earn target details")]
        [TestCase(1)]
        public void Edit_EarnTarget(int id)
        {
            profilePageSteps.editEarnTarget(id);
 
        }

        public void ProfileTearDown()
        {
            driver.Quit();
        }

    }
}
