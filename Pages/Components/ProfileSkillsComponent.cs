using AdvancedTask.Data;
using AdvancedTask.Utilities;
using OpenQA.Selenium;

namespace AdvancedTask.Pages.Components
{
    public class ProfileSkillsComponent : CommonDriver
    {
        private IWebElement AddNewButton;
        private IWebElement UpdateButton;
        private IWebElement DeleteButton;

        public void renderAddComponents()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']/div", 8);
                AddNewButton = driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']/div"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderUpdateComponents(string existingSkills, string existingSkillLevel)
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", $"//div[@data-tab='second']//tr[td[1]='{existingSkills}' and td[2]='{existingSkillLevel}']//td[last()]/span[1]", 8);
                UpdateButton = driver.FindElement(By.XPath($"//div[@data-tab='second']//tr[td[1]='{existingSkills}' and td[2]='{existingSkillLevel}']//td[last()]/span[1]"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderDeleteButton(string skill, string skillLevel)
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", $"//div[@data-tab='second']//tr[td[1]='{skill}' and td[2]='{skillLevel}']//td[last()]/span[2]", 10);
                DeleteButton = driver.FindElement(By.XPath($"//div[@data-tab='second']//tr[td[1]='{skill}' and td[2]='{skillLevel}']//td[last()]/span[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Click_AddSkills()
        {
            renderAddComponents();
            //Click add new button
            AddNewButton.Click();
        }
        public void Click_UpdateSkills(SkillsData existingSkillsData)
        {
            string existingSkills = existingSkillsData.Skills;
            string existingSkillLevel = existingSkillsData.SkillLevel;
            Thread.Sleep(4000);
            renderUpdateComponents(existingSkills, existingSkillLevel);
            Thread.Sleep(8000);
            UpdateButton.Click();
        }
        public void Click_DeleteSkills(SkillsData skillsData)
        {
            string skill = skillsData.Skills;
            string skillLevel = skillsData.SkillLevel;
            Thread.Sleep(4000);
            renderDeleteButton(skill, skillLevel);
            DeleteButton.Click();
            Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 4);

        }

    }
}
