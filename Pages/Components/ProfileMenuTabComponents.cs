using AdvancedTask.Utilities;
using OpenQA.Selenium;

namespace AdvancedTask.Pages.Components
{
    public class ProfileMenuTabComponents: CommonDriver
    {
        private IWebElement skillsTab;
        private IWebElement ShareSkillTab;
        private IWebElement SearchSkillTab;

        public void renderComponents()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Skills']", 8);
                skillsTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
                ShareSkillTab = driver.FindElement(By.XPath("//a[text()='Share Skill']"));
                SearchSkillTab = driver.FindElement(By.XPath("//i[@class='search link icon']"));
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element not found: " + ex.Message);
                // Optionally, you can rethrow the exception if needed:
                // throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void GoToSkillsPage()
        {
            renderComponents();
              Thread.Sleep(6000);
                //Navigate to skills page          
                skillsTab.Click();
                Thread.Sleep(4000);
        }
    

        public void GoToShareSkill()
        {
            renderComponents();
            Thread.Sleep(4000);
            //Navigate to share skill page           
            ShareSkillTab.Click();
        }

        public void GoToSearchSkill()
        {
            renderComponents();
            Thread.Sleep(4000);
            //Navigate to search skills page           
            SearchSkillTab.Click();
        }
    }
}
