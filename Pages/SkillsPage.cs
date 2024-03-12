using AdvancedTask.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTask.Data;

namespace AdvancedTask.Pages
{
    public class SkillsPage: CommonDriver
    {
            //Finding elements by ID
            private IWebElement AddNewButtonElement => driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//div[@class=\"ui teal button\"]"));
            private IWebElement AddTextboxElement => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            private IWebElement SkillLevelDropdownElement => driver.FindElement(By.XPath("//select[@name='level']"));
            private IWebElement AddButtonElement => driver.FindElement(By.XPath("//input[@value='Add']"));

            private Func<string, IWebElement> NewSkillsElement = skills => driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{skills}']"));

            private Func<string, IWebElement> NewSkillsLevelElement = skillLevel => driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{skillLevel}']"));

            private Func<string, By> EditIconXPath = existingSkills => By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingSkills}']/following-sibling::td[last()]/span[1]");
            private IWebElement EditTextBoxElement => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));

            private IWebElement UpdateButtonElement => driver.FindElement(By.XPath("//input[@value='Update']"));
            private Func<string, IWebElement> UpdatedSkillElement = skills => driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[contains(text(), '{skills}')]"));
            private IWebElement SuccessMessageElement => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            private Func<string, By> DeleteIconXPath = existingSkill => By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingSkill}']/following-sibling::td[last()]/span[@class='button'][2]");
        private IWebElement cancelButton => driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//input[@value='Cancel']"));

        public void Delete_All()
            {
                try
                {
                    Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='second']//i[@class='remove icon']", 8);
                }
                catch (WebDriverTimeoutException e)
                {
                    return;
                }
                IReadOnlyCollection<IWebElement> deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='second']//i[@class='remove icon']"));
                //Delete all records in the list
                foreach (IWebElement deleteButton in deleteButtons)
                {
                    deleteButton.Click();
                }
            }
            public void Create_SkillsPage(SkillsData skillsData)
            {

                  //Create add new button
                AddNewButtonElement.Click();

                //Enter skill in place holder
                AddTextboxElement.SendKeys(skillsData.Skills);

                //Click dropdown icon to select level
                SelectElement chooseskillLevel = new SelectElement(SkillLevelDropdownElement);
                chooseskillLevel.SelectByValue(skillsData.SkillLevel);

                //Click to add in list
                AddButtonElement.Click();
            }

            public string getSkills(string Skills)
            {
                Wait.WaitToExist(driver, "XPath", $"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{Skills}']", 5);

                return NewSkillsElement(Skills).Text;
            }
            public string getSkillLevel(string SkillLevel)
            {
                Wait.WaitToExist(driver, "XPath", $"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{SkillLevel}']", 2);

                return NewSkillsLevelElement(SkillLevel).Text;
            }
            public void Edit_SkillsPage(SkillsData existingSkillsData, SkillsData newSkillsData)
            {

            //Click the edit icon that needs to be updated
            IWebElement EditButton = driver.FindElement(By.XPath($"//div[@data-tab='second']//tr[td[1]='{existingSkillsData.Skills}' and td[2]='{existingSkillsData.SkillLevel}']//td[last()]/span[1]"));
            EditButton.Click();

            Wait.WaitToExist(driver, "XPath", "//input[@placeholder='Add Skill']", 5);

                //Edit the skill in the textbox
                EditTextBoxElement.Clear();
                EditTextBoxElement.SendKeys(newSkillsData.Skills);

                //Edit the skill level 
                SelectElement editlevelOption = new SelectElement(SkillLevelDropdownElement);
                editlevelOption.SelectByValue(newSkillsData.SkillLevel);

                //Update the skill
                UpdateButtonElement.Click();
            }
            public string getUpdatedSkills(string skills)
            {
                try
                {
                    //IWebElement newSkills = driver.FindElement(By.XPath($"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[contains(text(), '{skills}')]"));
                    return UpdatedSkillElement(skills).Text;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }

        public string getCancel()
        {
            try
            {
                return cancelButton.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public void Delete_SkillsPage(SkillsData existingSkillsData)
        {
            Thread.Sleep(6000);
            string xpath = $@"//div[@data-tab='second']//tr[td[1]='{existingSkillsData.Skills}' and td[2]='{existingSkillsData.SkillLevel}']//td[last()]/span[2]";

            IWebElement deleteIcon = driver.FindElement(By.XPath(xpath));
            deleteIcon.Click();
        }
        public string getMessage()
        {
             Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 2);

             //Get the text message after entering skill and skill level
             return SuccessMessageElement.Text;
        }     
    }
}
