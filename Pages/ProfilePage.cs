using OpenQA.Selenium;
using AdvancedTask.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTask.Data;
using OpenQA.Selenium.DevTools;

namespace AdvancedTask.Pages
{
    public class ProfilePage: CommonDriver
    {
        //Find Element by ID
        private IWebElement availabilityEdit => driver.FindElement(By.XPath("//div[@class=\"extra content\"]/div[@class=\"ui list\"]/div[2]//i[@class='right floated outline small write icon']"));
        private IWebElement availabilityOption => driver.FindElement(By.XPath("//div[@class='ui list']//select[@class='ui right labeled dropdown' and @name='availabiltyType']"));
        private IWebElement hoursEdit => driver.FindElement(By.XPath("//div[@class=\"extra content\"]/div[@class=\"ui list\"]/div[3]//i[@class='right floated outline small write icon']"));
        private IWebElement hoursOption => driver.FindElement(By.XPath("//div[@class=\"right floated content\"]//select[@class='ui right labeled dropdown' and @name='availabiltyHour']"));
        private IWebElement earnTargetEdit => driver.FindElement(By.XPath("//div[@class=\"extra content\"]/div[@class=\"ui list\"]/div[4]//i[@class='right floated outline small write icon']"));
        private IWebElement earnTargetOption => driver.FindElement(By.XPath("//div[@class=\"right floated content\"]//select[@class='ui right labeled dropdown' and @name='availabiltyTarget']"));
        public void Profile(profileData profileData)
        {
            // Click the edit option in profile availability
            availabilityEdit.Click();

            // Create a SelectElement object using the WebElement
            //SelectElement selectLevelOption = new SelectElement(availabilityOption);

            // Select the option by its value
            //selectLevelOption.SelectByValue("Full Time");
            availabilityOption.SendKeys(profileData.Availability);

            Thread.Sleep(5000);
            // Click the edit option in profile availability
            hoursEdit.Click();

            //Select the hours option in profile hours
            hoursOption.SendKeys(profileData.Hours);

            Thread.Sleep(3000);
            // Click the edit option in profile earn target
            earnTargetEdit.Click();

            // Select the target option in earn target
            earnTargetOption.SendKeys(profileData.EarnTarget);
        }
    }
}
