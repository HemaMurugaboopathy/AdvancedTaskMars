using AdvancedTask.Data;
using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvancedTask.Pages.Components
{
    public class AddEditSkillComponent : CommonDriver
    {
        private IReadOnlyCollection<IWebElement> deleteButtons;
        private IWebElement AddSkillsTextbox;
        private IWebElement SkillLevelDropdown;
        private IWebElement AddButton;
        private IWebElement UpdateNewButton;
        private IWebElement CancelButtonElement;
        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;

        public void renderAddComponents()
        {
            try
            {
                AddSkillsTextbox = driver.FindElement(By.XPath("//input[@name='name']"));
                SkillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
                AddButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDeleteAllComponents()
        {
            try
            {
                deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='second']//i[@class='remove icon']"));
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Delete_All_Records()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='second']//i[@class='remove icon']", 4);
            }
            catch (WebDriverTimeoutException e)
            {
                return;
            }

            renderDeleteAllComponents();
            //Delete all records in the list

            foreach (IWebElement deleteButton in deleteButtons)
            {
                deleteButton.Click();

            }
        }

        public void Add_Skills(SkillsData skillsData)
        {
            renderAddComponents();

            //Enter the skills that needs to be added
            AddSkillsTextbox.SendKeys(skillsData.Skills);
            //Choose the language level
            SelectElement chooseSkillLevel = new SelectElement(SkillLevelDropdown);
            chooseSkillLevel.SelectByValue(skillsData.SkillLevel);
            //Click add new button after entering language and language level
            AddButton.Click();
            Thread.Sleep(5000);
        }
        public void Add_SkillsSpecial(SkillsData skillsData)
        {
            renderAddComponents();

            //Enter the skills that needs to be added
            AddSkillsTextbox.SendKeys(skillsData.Skills);
            //Choose the language level
            SelectElement chooseSkillLevel = new SelectElement(SkillLevelDropdown);
            chooseSkillLevel.SelectByValue(skillsData.SkillLevel);
            //Click add new button after entering language and language level
            AddButton.Click();
            Thread.Sleep(5000);
        }
        public void Add_SkillsMoreCharacters(SkillsData skillsData)
        {
            renderAddComponents();

            //Enter the skills that needs to be added
            AddSkillsTextbox.SendKeys(skillsData.Skills);
            //Choose the language level
            SelectElement chooseSkillLevel = new SelectElement(SkillLevelDropdown);
            chooseSkillLevel.SelectByValue(skillsData.SkillLevel);
            //Click add new button after entering language and language level
            AddButton.Click();
            Thread.Sleep(5000);
        }
        public void renderMessage()
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 6);
                messageWindow = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderCancelComponents()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Cancel']", 15);
                CancelButtonElement = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public string getCancel()
        {

            try
            {
                renderCancelComponents();
                //IWebElement CancelButtonElement = driver.FindElement(By.XPath("//input[@value='Cancel']"));
                return CancelButtonElement.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        public void renderUpdateComponents()
        {
            try
            {
                AddSkillsTextbox = driver.FindElement(By.XPath("//input[@name='name']"));
                SkillLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
                UpdateNewButton = driver.FindElement(By.XPath("//input[@value='Update']"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void Edit_Skills(SkillsData newSkillsData)
        {
            renderUpdateComponents();
            //Clear and enter the language that needs to be update
            AddSkillsTextbox.Clear();
            AddSkillsTextbox.SendKeys(newSkillsData.Skills);

            //Choose the language level
            SelectElement updateSkillLevel = new SelectElement(SkillLevelDropdown);
            updateSkillLevel.SelectByValue(newSkillsData.SkillLevel);
            UpdateNewButton.Click();
            Thread.Sleep(5000);
        }

        public string getMessage()
        {
            renderMessage();
            String message = messageWindow.Text;
            Wait.WaitToBeClickable(driver, "XPath", "//*[@class='ns-close']", 5);
            closeMessageIcon.Click();
            return message;
        }
    }
}

