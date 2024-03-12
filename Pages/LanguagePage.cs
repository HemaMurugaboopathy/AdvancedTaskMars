using AdvancedTask.Data;
using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine;

namespace AdvancedTask.Pages
{
    public class LanguagePage : CommonDriver
    {
            private IWebElement AddNewButton => driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']/div"));
            private IWebElement AddLanguageTextbox => driver.FindElement(By.XPath("//input[@name='name']"));
            private IWebElement LanguageLevelDropdown => driver.FindElement(By.XPath("//select[@name='level']"));
            private IWebElement AddButton => driver.FindElement(By.XPath("//input[@value='Add']"));
            private IWebElement SuccessMessage => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            private IWebElement UpdateLanguage => driver.FindElement(By.XPath("//input[@name='name']"));
            private IWebElement UpdateLevelDropdown => driver.FindElement(By.XPath("//select[@name='level']"));
            private IWebElement UpdateNewButton => driver.FindElement(By.XPath("//input[@value='Update']"));
            private Func<string, By> NewLanguageElement = Language => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{Language}']");
            private Func<string, By> NewLanguageLevelElement = LanguageLevel => By.XPath($"//div[@class='twelve wide column scrollTable']//td[text()='{LanguageLevel}']");
                        
            private Func<string, By> DeleteIconXPath = existingLanguage => By.XPath($"//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//td[text()='{existingLanguage}']/following-sibling::td[last()]/span[2]");
            private IWebElement cancelButton => driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Language']/following-sibling::div[@class='twelve wide column scrollTable']//input[@value='Cancel']"));

        public void Delete_All_Records()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='first']//i[@class='remove icon']", 8);
            }
            catch (WebDriverTimeoutException e)
            {
                return;
            }

            IReadOnlyCollection<IWebElement> deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='first']//i[@class='remove icon']"));
            //Delete all records in the list
            foreach (IWebElement deleteButton in deleteButtons)
            {
                deleteButton.Click();
            }
        }
        
         public void Add_Language(LanguageData languageData)
         {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']/div", 5);
            
                //Click add new button
                AddNewButton.Click();

                //Enter the language that needs to be added
                AddLanguageTextbox.SendKeys(languageData.Language);

                //Choose the language level
                SelectElement chooseLanguageLevel = new SelectElement(LanguageLevelDropdown);
                chooseLanguageLevel.SelectByValue(languageData.LanguageLevel);

                //Click add new button after entering language and language level
                AddButton.Click();
         }

         public string getLanguage(string Language)
         {
                By languageBy = NewLanguageElement(Language);

                Wait.WaitToBeClickable(driver,"XPath" ,$"//div[@class='twelve wide column scrollTable']//td[text()='{Language}']", 5);

                IWebElement newLanguage = driver.FindElement(languageBy);
                return newLanguage.Text;
         }

          public string getLanguageLevel(string LanguageLevel)
          {
                By languageLevelBy = NewLanguageLevelElement(LanguageLevel);
                IWebElement newLanguageLevel = driver.FindElement(languageLevelBy);
                return newLanguageLevel.Text;
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

         public void Edit_Language(LanguageData existingLanguageData, LanguageData newLanguageData)
         {
                Wait.WaitToBeClickable(driver, "XPath", $"//div[@data-tab='first']//tr[td[1]='{existingLanguageData.Language}' and td[2]='{existingLanguageData.LanguageLevel}']//td[last()]/span[1]", 5);
                //Thread.Sleep(6000);
                //Click the edit icon that needs to be updated
                IWebElement EditButton = driver.FindElement(By.XPath($"//div[@data-tab='first']//tr[td[1]='{existingLanguageData.Language}' and td[2]='{existingLanguageData.LanguageLevel}']//td[last()]/span[1]"));
                EditButton.Click();
           
                //Clear and enter the language that needs to be updated
                UpdateLanguage.Clear();
                UpdateLanguage.SendKeys(newLanguageData.Language);

                //Choose the language level
                SelectElement updateLanguageLevel = new SelectElement(UpdateLevelDropdown);
                updateLanguageLevel.SelectByValue(newLanguageData.LanguageLevel);

                //Click Update button after updating language and language level
                UpdateNewButton.Click();
         }

        public void Delete_Language(LanguageData existingLanguageData)
        {
            //Wait.WaitToBeClickable(driver, "XPath", $"//div[@data-tab='first']//tr[td[1]='{existingLanguageData.Language}' and td[2]='{existingLanguageData.LanguageLevel}']//td[last()]/span[2]", 5);
            Thread.Sleep(6000);
            //Click the edit icon that needs to be updated
            IWebElement DeleteButton = driver.FindElement(By.XPath($"//div[@data-tab='first']//tr[td[1]='{existingLanguageData.Language}']//td[last()]/span[2]"));
            DeleteButton.Click();
        }

        public string getMessage()
          {
                Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 2);

                //Get the text message after entering language and language level
                return SuccessMessage.Text;
          }
        
    }
}