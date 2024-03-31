using AdvancedTask.Data;
using AdvancedTask.Utilities;
using OpenQA.Selenium;

namespace AdvancedTask.Pages.Components
{
    public class ProfileLanguageComponents : CommonDriver
    {
        private IWebElement AddNewButton;
        private IWebElement UpdateButton;
        private IWebElement DeleteButton;

        public void renderAddComponents()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']/div", 8);
                AddNewButton = driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Languages']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']/div"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderUpdateComponents(string existingLanguage, string existingLanguageLevel)
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", $"//div[@data-tab='first']//tr[td[1]='{existingLanguage}' and td[2]='{existingLanguageLevel}']//td[last()]/span[1]", 8);
                UpdateButton = driver.FindElement(By.XPath($"//div[@data-tab='first']//tr[td[1]='{existingLanguage}' and td[2]='{existingLanguageLevel}']//td[last()]/span[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDeleteComponents(string language, string languageLevel)
        {

            try
            {
                Wait.WaitToBeClickable(driver, "XPath", $"//div[@data-tab='first']//tr[td[1]='{language}' and td[2]='{languageLevel}']//td[last()]/span[2]", 9);
                DeleteButton = driver.FindElement(By.XPath($"//div[@data-tab='first']//tr[td[1]='{language}' and td[2]='{languageLevel}']//td[last()]/span[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Click_AddLanguage()
        {
            renderAddComponents();
            //Click add new button
            AddNewButton.Click();
        }
        public void Click_UpdateLanguage(LanguageData existingLanguageData)
        {
            string existingLanguage = existingLanguageData.Language;
            string existingLanguageLevel = existingLanguageData.LanguageLevel;
            Thread.Sleep(4000);
            renderUpdateComponents(existingLanguage, existingLanguageLevel);
            Thread.Sleep(8000);
            UpdateButton.Click();
        }
        public void Click_DeleteLanguage(LanguageData languageData)
        {
            string language = languageData.Language;
            string languageLevel = languageData.LanguageLevel;
            Thread.Sleep(4000);
            renderDeleteComponents(language, languageLevel);
            DeleteButton.Click();
            Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }
    }
}
