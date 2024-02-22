using AdvancedTask.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Pages
{
    public class SkillsPage: CommonDriver
    {
            //Finding elements by ID
            private IWebElement AddNewButtonElement => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
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
            public void Create_SkillsPage(string skills, string skillLevel)
            {
                //Create add new button
                AddNewButtonElement.Click();

                //Enter skill in place holder
                AddTextboxElement.SendKeys(skills);

                //Click dropdown icon to select level
                SelectElement chooseskillLevel = new SelectElement(SkillLevelDropdownElement);
                chooseskillLevel.SelectByValue(skillLevel);

                //Click to add in list
                AddButtonElement.Click();
            }

            public string getSkills(string skills)
            {
                Wait.WaitToExist(driver, "XPath", $"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{skills}']", 5);

                return NewSkillsElement(skills).Text;
            }
            public string getSkillLevel(string skillLevel)
            {
                Wait.WaitToExist(driver, "XPath", $"//div[@class='four wide column' and h3='Skills']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{skillLevel}']", 2);

                return NewSkillsLevelElement(skillLevel).Text;
            }
            public void Edit_SkillsPage(string existingSkills, String existingSkillsLevel)
            {
                By xPath = EditIconXPath(existingSkills);
                //Wait.WaitToBeClickable(driver, xPath, 5);

                //Click edit icon 
                IWebElement editIcon = driver.FindElement(xPath);
                editIcon.Click();
            }
            public void Update_SkillsPage(string newSkills, string newSkillLevel)
            {
                Wait.WaitToExist(driver, "XPath", "//input[@placeholder='Add Skill']", 5);

                //Edit the skill in the textbox
                EditTextBoxElement.Clear();
                EditTextBoxElement.SendKeys(newSkills);

                //Edit the skill level 
                SelectElement editlevelOption = new SelectElement(SkillLevelDropdownElement);
                editlevelOption.SelectByValue(newSkillLevel);

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
            public void Delete_SkillsPage(string existingSkill)
            {
                By xPath = DeleteIconXPath(existingSkill);
                //Wait.WaitToBeClickable(driver, xPath, 5);

                //Delete the skill
                IWebElement deleteIcon = driver.FindElement(xPath);
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
