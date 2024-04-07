using AdvancedTask.Data;
using AdvancedTask.Utilities;
using OpenQA.Selenium;

namespace AdvancedTask.Pages.Components
{
    public class ShareSkillOverviewComponent: CommonDriver
    {
        private IWebElement ShareSkillButton;
        private IWebElement ManageListingsTab;
        private IWebElement UpdateButton;
        private IWebElement DeleteButton;
        private IWebElement YesButton;

        public void renderShareSkill()
        {
            try
            {
                ShareSkillButton = driver.FindElement(By.XPath("//a[text()='Share Skill']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderManageListings()
        {
            try
            {
                ManageListingsTab = driver.FindElement(By.XPath("//a[text()='Manage Listings']")); ShareSkillButton = driver.FindElement(By.XPath("//a[text()='Share Skill']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderUpdateButton(string existingTitle)
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", $"//td[text()='{existingTitle}']/following-sibling::td/div/button[@class='ui button']/i[@class='outline write icon']", 9);
                UpdateButton = driver.FindElement(By.XPath($"//td[text()='{existingTitle}']/following-sibling::td/div/button[@class='ui button']/i[@class='outline write icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDeleteButton(string title)
        {
            try
            {
                DeleteButton = driver.FindElement(By.XPath($"//td[text()='{title}']/following-sibling::td/div/button[@class='ui button']/i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderYesButton()
        {
            try
            {
                YesButton = driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickShareSkillButton()
        {
            Thread.Sleep(5000);
            renderShareSkill();
            ShareSkillButton.Click();
        }
        public void clickManageListings()
        {
            Thread.Sleep(5000);
            renderManageListings();
            ManageListingsTab.Click();         
        }
        public void clickUpdateButton(ShareSkillData existingShareSkillData)
        {
            String existingTitle = existingShareSkillData.Title;
            Thread.Sleep(5000);
            renderUpdateButton(existingTitle);
            Thread.Sleep(8000);
            UpdateButton.Click();               
        }
        public void clickDeleteButton(ShareSkillData shareSkillData)
        {
            String title = shareSkillData.Title;
            Thread.Sleep(5000);
            renderDeleteButton(title);
            DeleteButton.Click();
            renderYesButton();
            YesButton.Click();
        }

    }
}
