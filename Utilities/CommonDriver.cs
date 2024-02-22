using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Utilities
{
    public class CommonDriver
    {
        public const string Url = "http://localhost:5000/";
        public static IWebDriver driver;

        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();
        }
        public void Close()
        {
            driver.Quit();
        }
        public static void CaptureScreenshot(string screenshotName)
        {
            //Capture the screenshot
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();

            //Specify the path and filename for the screenshot with a timestamp
            string filepath = "D:\\Hema\\IndustryConnect\\Internship\\AdvancedTask\\Screenshot";
            string screenshotPath = Path.Combine(filepath, $"{screenshotName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            //screenshot.SaveAsFile(screenshotPath);

            // Ensure the directory exists before saving the screenshot
            Directory.CreateDirectory(filepath);

            // Save the screenshot
            screenshot.SaveAsFile(screenshotPath);
        }
    }
}
