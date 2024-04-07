using AdvancedTask.Data;
using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvancedTask.Pages.Components.ProfileAboutMe
{
    public class ProfileComponent : CommonDriver
    {
        private IWebElement availabilityEdit;
        private IWebElement availabilityOption;
        private IWebElement hoursEdit;
        private IWebElement hoursOption;
        private IWebElement earnTargetEdit;
        private IWebElement earnTargetOption;
        private IWebElement Message;

        public void renderAvailableEdit()
        {

            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class=\"extra content\"]//div[@class=\"ui list\"]//div[2]//i[@class=\"right floated outline small write icon\"]", 7);
                availabilityEdit = driver.FindElement(By.XPath("//div[@class=\"extra content\"]//div[@class=\"ui list\"]//div[2]//i[@class=\"right floated outline small write icon\"]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAvailableOption()
        {

            try
            {
                availabilityOption = driver.FindElement(By.XPath("//select[@class='ui right labeled dropdown' and @name='availabiltyType']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderHoursEdit()
        {

            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class=\"extra content\"]/div[@class=\"ui list\"]/div[3]//i[@class='right floated outline small write icon']", 8);
                hoursEdit = driver.FindElement(By.XPath("//div[@class=\"extra content\"]/div[@class=\"ui list\"]/div[3]//i[@class='right floated outline small write icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderHoursOption()
        {

            try
            {
                hoursOption = driver.FindElement(By.XPath("//div[@class=\"right floated content\"]//select[@class='ui right labeled dropdown' and @name='availabiltyHour']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderEarnTargetEdit()
        {

            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class=\"extra content\"]/div[@class=\"ui list\"]/div[4]//i[@class='right floated outline small write icon']", 8);
                earnTargetEdit = driver.FindElement(By.XPath("//div[@class=\"extra content\"]/div[@class=\"ui list\"]/div[4]//i[@class='right floated outline small write icon']"));
             }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderEarnTargetOption()
        {

            try
            {
                 earnTargetOption = driver.FindElement(By.XPath("//div[@class=\"right floated content\"]//select[@class='ui right labeled dropdown' and @name='availabiltyTarget']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Edit_Availability(profileData profileData)
        {
            renderAvailableEdit();
            availabilityEdit.Click();
            renderAvailableOption();
            SelectElement selectLevelOption = new SelectElement(availabilityOption);
            selectLevelOption.SelectByText(profileData.Availability);
        }
        public void Edit_Hours(profileData profileData)
        {
           renderHoursEdit();
            hoursEdit.Click();
            renderHoursOption();
            SelectElement selectHoursOption = new SelectElement(hoursOption);
            selectHoursOption.SelectByText(profileData.Hours);
        }
        public void Edit_EarnTarget(profileData profileData)
        {
            renderEarnTargetEdit();
            earnTargetEdit.Click();
            renderEarnTargetOption();
            SelectElement selectEarnTargetOption = new SelectElement(earnTargetOption);
            selectEarnTargetOption.SelectByText(profileData.EarnTarget);
        }
        public void renderSuccessMessage()
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 4);
                Message = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public string getMessage()
        {
            renderSuccessMessage();
            return Message.Text;
        }

    }
}

