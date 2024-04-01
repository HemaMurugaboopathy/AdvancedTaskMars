using AdvancedTask.Data;
using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvancedTask.Pages.Components
{
    public class AddEditDeleteLanguageComponent: CommonDriver
    {
        private IReadOnlyCollection<IWebElement> deleteButtons;
        private IWebElement AddLanguageTextbox;
        private IWebElement LanguageLevelDropdown;
        private IWebElement AddButton;
        private IWebElement UpdateNewButton;
        private IWebElement CancelButtonElement;
        private IWebElement messageWindow;
        private IWebElement closeMessageIcon;

        public void renderAddComponents()
        {
            try
            {
                AddLanguageTextbox = driver.FindElement(By.XPath("//input[@name='name']"));
                LanguageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
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
                deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='first']//span[@class='button']/i[@class='remove icon']"));
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
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='first']//span[@class='button']/i[@class='remove icon']", 15);
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


        public void Add_Language(LanguageData languageData)
        {
            renderAddComponents();
            //Enter the language that needs to be added
            AddLanguageTextbox.SendKeys(languageData.Language);
            //Choose the language level
            SelectElement chooseLanguageLevel = new SelectElement(LanguageLevelDropdown);
            chooseLanguageLevel.SelectByValue(languageData.LanguageLevel);
            //Click add new button after entering language and language level
            AddButton.Click();
            Thread.Sleep(5000);
        }
        public void Add_LanguageSpecial(LanguageData languageData)
        {
            renderAddComponents();
            //Enter the language that needs to be added
            AddLanguageTextbox.SendKeys(languageData.Language);
            //Choose the language level
            SelectElement chooseLanguageLevel = new SelectElement(LanguageLevelDropdown);
            chooseLanguageLevel.SelectByValue(languageData.LanguageLevel);
            //Click add new button after entering language and language level
            AddButton.Click();
            Thread.Sleep(5000);
        }
        public void Add_LanguageMoreCharacters(LanguageData languageData)
        {
            renderAddComponents();

            //Enter the language that needs to be added
            AddLanguageTextbox.SendKeys(languageData.Language);
            //Choose the language level
            SelectElement chooseLanguageLevel = new SelectElement(LanguageLevelDropdown);
            chooseLanguageLevel.SelectByValue(languageData.LanguageLevel);
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
                AddLanguageTextbox = driver.FindElement(By.XPath("//input[@name='name']"));
                LanguageLevelDropdown = driver.FindElement(By.XPath("//select[@name='level']"));
                UpdateNewButton = driver.FindElement(By.XPath("//input[@value='Update']"));
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Edit_Language(LanguageData newLanguageData)
        {
            renderUpdateComponents();
            //Clear and enter the language that needs to be update
            AddLanguageTextbox.Clear();
            AddLanguageTextbox.SendKeys(newLanguageData.Language);
            //Choose the language level
            SelectElement updateLanguageLevel = new SelectElement(LanguageLevelDropdown);
            updateLanguageLevel.SelectByValue(newLanguageData.LanguageLevel);
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

