using AdvancedTask.Data;
using AdvancedTask.Pages;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V119.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Tests
{
    [TestFixture]
    public class Language_Tests: CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        ProfilePage profilePageObj = new ProfilePage();
        LanguagePage languagePageObj = new LanguagePage();
        public static ExtentTest test;
        public static ExtentReports extent;

        public Language_Tests()
        {
            loginPageObj = new LoginPage();
            profilePageObj = new ProfilePage();
            languagePageObj = new LanguagePage();
        }

        [SetUp]
        public void LoginSetUp()
        {
            //Open Chrome browser
            Initialize();

            //Login page object initialization and definition
            loginPageObj.LoginActions();
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {

            // Create a new instance of ExtentReports to manage test reports
            extent = new ExtentReports();

            // Create a new ExtentSparkReporter to define the HTML report file path and configuration
            var sparkReporter = new ExtentSparkReporter(@"D:\Hema\IndustryConnect\Internship\AdvancedTask\ExtentReports\LanguageReport.html");

            // Attach the ExtentSparkReporter to the ExtentReports instance for report generation
            extent.AttachReporter(sparkReporter);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            // Flush the ExtentReports instance to finalize and write all information to the report files
            extent.Flush();
        }

        [Test, Order(1), Description("Deleting all records before entering any details")]
        public void Delete_All()
        {
            // Create a new test
            test = extent.CreateTest("DeleteAllLanguage").Info("Test Started");

            // Call the Delete_All method on the languagePageObj to perform the deletion operation
            languagePageObj.Delete_All_Records();

            // Log a pass status for the test and add a corresponding log message
            test.Log(Status.Pass, "Delete all language passed");
        }

        [Test, Order(2), Description("This test is creating a new languaage")]
        [TestCase(1)]
        public void Add_Language(int id)
        {
            // Create a new test and log the test start information
            test = extent.CreateTest("AddLanguage").Info("Test Started");

            // Read education data from the specified JSON file and retrieve the first item with a matching Id
            LanguageData languageData = LanguageDataHelper
                .ReadLanguageData(@"addLanguageData.json")
                .FirstOrDefault(x => x.Id == id);

            // Call the Add_Education method on the educationPageObj to perform the add operation
            languagePageObj.Add_Language(languageData);

            // Get the actual message from the educationPageObj
            string actualMessage = languagePageObj.getMessage();

            //Access education configuration settings
            string newLanguage = languagePageObj.getLanguage(languageData.Language);
            string newLanguageLevel = languagePageObj.getLanguageLevel(languageData.LanguageLevel);
            
            Assert.That(newLanguage == languageData.Language, "Actual language and expected language do not match");
            Assert.That(newLanguageLevel == languageData.LanguageLevel, "Actual languageLevel and expected languageLevel do not match");
            
            // Log a pass status for the test and add a corresponding log message
            test.Log(Status.Info, "Add language started");
        }
        
        [Test, Order(3), Description("This test is adding a new language with special characters")]
        [TestCase(2)]
        public void Add_LanguageSpecial(int id)
        {
            // Capture a screenshot with a specified name 
            CaptureScreenshot("ScreenshotName");

            // Create a new test and log the test start information
            test = extent.CreateTest("AddLanguageWithSpecialCharacters").Info("Test Started");

            // Read education data from the specified JSON file and retrieve the first item with a matching Id
            LanguageData languageData = LanguageDataHelper
               .ReadLanguageData(@"addLanguageData.json")
               .FirstOrDefault(x => x.Id == id);

            languagePageObj.Add_Language(languageData);

            // Arrange
            string actualMessage = languagePageObj.getMessage();

            string expectedMessagePattern = @".* has been added to your languages.*";

            // Perform the assertion using a regular expression
            Assert.That(actualMessage, Does.Match(expectedMessagePattern), $"Actual message '{actualMessage}' does not match the expected pattern '{expectedMessagePattern}'");

            // Log a pass status for the test and add a corresponding log message
            test.Log(Status.Fail, "Language failed: ");
            Console.WriteLine(actualMessage);
            CaptureScreenshot("SpecialCharactersFailed");
        }

        [Test, Order(4), Description("This test is adding a new Language with empty text box")]
        [TestCase(3)]
        public void Add_LanguageEmptyTextbox(int id)
        {
            // Capture a screenshot with a specified name 
            CaptureScreenshot("ScreenshotName");

            // Create a new test and log the test start information
            test = extent.CreateTest("AddLanguageWithEmptyTextbox").Info("Test Started");

            
            // Read education data from the specified JSON file and retrieve the first item with a matching Id
            LanguageData languageData = LanguageDataHelper
               .ReadLanguageData(@"addLanguageData.json")
               .FirstOrDefault(x => x.Id == id);

            languagePageObj.Add_Language(languageData);

            // Arrange
            string actualMessage = languagePageObj.getMessage();
            string expectedMessage = "Please enter language and level"; // Update this to the expected message
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Actual message '{actualMessage}' does not match expected message '{expectedMessage}'");

            // Log a pass status for the test and add a corresponding log message
            test.Log(Status.Fail, "Language failed: ");

            CaptureScreenshot("EmptyTextBoxFailed");
        }

        [Test, Order(5), Description("This test is adding a new Language with more characters")]
        [TestCase(4)]
        public void Add_LanguageMoreCharacters(int id)
        {
            // Capture a screenshot with a specified name 
            CaptureScreenshot("ScreenshotName");

            // Create a new test and log the test start information
            test = extent.CreateTest("AddLanguageWithMoreCharacters").Info("Test Started");
            // Read education data from the specified JSON file and retrieve the first item with a matching Id
            LanguageData languageData = LanguageDataHelper
                  .ReadLanguageData(@"addLanguageData.json")
                  .FirstOrDefault(x => x.Id == id);

            languagePageObj.Add_Language(languageData);

            // Arrange
            string actualMessage = languagePageObj.getMessage();
            string expectedMessagePattern = @".* has been added to your languages.*";

            // Perform the assertion using a regular expression
            Assert.That(actualMessage, Does.Match(expectedMessagePattern), $"Actual message '{actualMessage}' does not match the expected pattern '{expectedMessagePattern}'");

            // Log a pass status for the test and add a corresponding log message
            test.Log(Status.Fail, "Education failed: ");
            Console.WriteLine(actualMessage);
            CaptureScreenshot("MoreCharactersFailed");
        }
        [Test, Order(6), Description("This is editing an existing language")]
        [TestCase(1)]
        public void Edit_Language(int id)
        {
            // Read certification data from the specified JSON file and retrieve the first item with a matching Id
            LanguageData existingLanguageData = LanguageDataHelper
                .ReadLanguageData(@"addLanguageData.json")
                .FirstOrDefault(x => x.Id == id);
            LanguageData newLanguageData = LanguageDataHelper
              .ReadLanguageData(@"editLanguageData.json")
            .FirstOrDefault(x => x.Id == id);

            // Create a new test and log the test start information
            test = extent.CreateTest("EditLanguage").Info("Test Started");
            languagePageObj.Edit_Language(existingLanguageData, newLanguageData);

            //Access certification configuration settings
            string updatedLanguage = languagePageObj.getLanguage(newLanguageData.Language);
            string updatedLanguageLevel = languagePageObj.getLanguageLevel(newLanguageData.LanguageLevel);
            
            Assert.That(updatedLanguage == newLanguageData.Language, "Actual language and expected language does not match");
            Assert.That(updatedLanguageLevel == newLanguageData.LanguageLevel, "Actual language level and expected language level does not match");
          
        }

        [Test, Order(7), Description("Cancel when editing")]
        [TestCase(1)]
        public void Cancel_Language(int id)
        {
            // Create a new test and log the test start information
            test = extent.CreateTest("CancelLanguage").Info("Test Started");

            string cancelLanguage = languagePageObj.getCancel();
            Assert.That(string.IsNullOrEmpty(cancelLanguage), Is.True, "Cancelled successfully");

            // Log a pass status for the test and add a corresponding log message
            test.Log(Status.Info, "Cancelled Successfully: ");
        }


        [Test, Order(8), Description("This is deleting an existing language")]
        [TestCase(1)]
        public void Delete_language(int id)
        {
            test = extent.CreateTest("DeleteLanguage").Info("Test Started");

            // Read certification data from the specified JSON file and retrieve the first item with a matching Id
             LanguageData languageData = LanguageDataHelper
                  .ReadLanguageData(@"deleteLanguageData.json")
                  .FirstOrDefault(x => x.Id == id);

            languagePageObj.Delete_Language(languageData);

            // Create a new test and log the test start information
            test = extent.CreateTest("DeleteLanguage").Info("Test Started");
            
            // Log a pass status for the test and add a corresponding log message
            test.Log(Status.Info, "Delete language started");
        }

        [TearDown]
        public void LanguageTearDown()
        {
            driver.Quit();
        }
    }
}
