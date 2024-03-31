using AdvancedTask.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;

namespace AdvancedTask.Pages
{
    public class SearchSkillComponent : CommonDriver
    {
        private IWebElement searchskillsTextBox;
        private IWebElement searchIcon;
        private IWebElement SelectCategory;
        private IWebElement SelectSubcategory;
        private IWebElement filterOPtion;
        private IWebElement Message;

        public void renderSearchskill()
        {
            try
            {
                searchskillsTextBox = driver.FindElement(By.XPath("(//div[@class='ui small icon input search-box']//input[@placeholder='Search skills'])"));
                searchIcon = driver.FindElement(By.XPath("//div[@class='ui small icon input search-box']//i[@class=\"search link icon\"]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void renderSearchskillCategory()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Programming & Tech']", 8);
                SelectCategory = driver.FindElement(By.XPath("//a[text()='Programming & Tech']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderSearchskillSubCategory()
        {
            try
            {
                SelectSubcategory = driver.FindElement(By.XPath("//a[text()='QA']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderSearchskillFilter()
        {
            try
            {
                filterOPtion = driver.FindElement(By.XPath("//button[text()=\"Online\"]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderAddMessage()
        {
            try
            {
                Message = driver.FindElement(By.XPath("//div[@class='ui grid']/h3"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Click_SearchIcon()
        {
            Thread.Sleep(4000);
            renderSearchskill();
            searchIcon.Click();
            searchskillsTextBox.SendKeys("ISTQB");
            searchIcon.Click();

        }
        public void SearchSkill_ByCategory()
        {
            renderSearchskillCategory();
            SelectCategory.Click();

        }
        public void SearchSkill_BySubCategory()
        {
            renderSearchskillSubCategory();
            SelectCategory.Click();
            SelectSubcategory.Click();

        }

        public void filter()
        {
            renderSearchskillFilter();
            searchIcon.Click();
            filterOPtion.Click();
        }
    }
}
