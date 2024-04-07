using AdvancedTask.Utilities;
using OpenQA.Selenium;

namespace AdvancedTask.Pages.Components.Notifications
{
    public class NotificationOverviewComponent : CommonDriver
    {
        private IWebElement notificationDropdown;
        private IWebElement seeAllButton;

        public void renderNotificationDropDown()
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", "//div[@class=\"ui top left pointing dropdown item\"]", 8);
                notificationDropdown = driver.FindElement(By.XPath("//div[@class=\"ui top left pointing dropdown item\"]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSeeAllButton()
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", "//a[text()='See All...']", 8);
                seeAllButton = driver.FindElement(By.XPath("//a[text()='See All...']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void GoToNotificationDropdown()
        {
            renderNotificationDropDown();
            notificationDropdown.Click();
            renderSeeAllButton();
            seeAllButton.Click();
        }

    }
}
