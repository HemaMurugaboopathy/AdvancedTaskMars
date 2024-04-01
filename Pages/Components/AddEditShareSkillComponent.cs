using AdvancedTask.Data;
using AdvancedTask.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdvancedTask.Pages
{
    public class AddEditShareSkillComponent : CommonDriver
    {
        private IWebElement titleTextBox;
        private IWebElement descriptionTextBox;
        private IWebElement categoryOption;
        private IWebElement subcategoryOption;
        private IWebElement tagTextBox;
        private IWebElement serviceOption;
        private IWebElement locationOption;
        private IWebElement startDate;
        private IWebElement endDate;
        private IWebElement timeCheckbox;
        private IWebElement startTime;
        private IWebElement endTime;
        private IWebElement skillTradeOption;
        private IWebElement creditTextbox;
        private IWebElement activeOption;
        private IWebElement saveButton;
        private IWebElement newTitle;
        private IWebElement successMessage;

        public void renderAddComponents()
        {
            try
            {
                titleTextBox = driver.FindElement(By.XPath("//input[@name=\"title\"]"));
                descriptionTextBox = driver.FindElement(By.XPath("//textarea[@name=\"description\"]"));
                tagTextBox = driver.FindElement(By.XPath("//input[@placeholder=\"Add new tag\"]"));
                serviceOption = driver.FindElement(By.XPath("//input[@type='radio' and @name='serviceType' and @value='1']"));
                locationOption = driver.FindElement(By.XPath("//input[@type='radio' and @name='locationType' and @value='1']"));
                startDate = driver.FindElement(By.XPath("//input[@name='startDate']"));
                endDate = driver.FindElement(By.XPath("//input[@name='endDate']"));
                timeCheckbox = driver.FindElement(By.XPath("//input[@name='Available' and @type='checkbox' and @index='3']"));
                startTime = driver.FindElement(By.XPath("//input[@name='StartTime' and @index='3']"));
                endTime = driver.FindElement(By.XPath("//input[@name='EndTime' and @index='3']"));
                skillTradeOption = driver.FindElement(By.XPath("//input[@name='skillTrades' and @type='radio' and @value='false']"));
                activeOption = driver.FindElement(By.XPath("//input[@name='isActive' and @type='radio' and @value='true']"));
                saveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderCategory()
        {
            try
            {
                categoryOption = driver.FindElement(By.XPath("//select[@name=\"categoryId\"]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSubCategory()
        {
            try
            {
                subcategoryOption = driver.FindElement(By.XPath("//select[@name=\"subcategoryId\"]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderCredit()
        {
            try
            {
                creditTextbox = driver.FindElement(By.XPath("//input[@placeholder=\"Amount\"]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderTitle(string title)
        {
            try
            {
                newTitle = driver.FindElement(By.XPath($"//td[@class='four wide'][text()='{title}'][1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Add_ShareSkill(ShareSkillData shareSkillData)
        {
            renderAddComponents();
            titleTextBox.SendKeys(shareSkillData.Title);
            descriptionTextBox.SendKeys(shareSkillData.Description);
            renderCategory();
            SelectElement categoryOPtion = new SelectElement(categoryOption);
            categoryOPtion.SelectByText(shareSkillData.Category);
            renderSubCategory();
            SelectElement subcategoryDropdown = new SelectElement(subcategoryOption);
            subcategoryDropdown.SelectByText(shareSkillData.Subcategory);

            tagTextBox.SendKeys(shareSkillData.Tags);
            tagTextBox.SendKeys(Keys.Enter);
            serviceOption.Click();
            locationOption.Click();
            startDate.SendKeys(shareSkillData.StartDate);
            endDate.SendKeys(shareSkillData.EndDate);

            timeCheckbox.Click();
            startTime.SendKeys(shareSkillData.StartTime);
            endTime.SendKeys(shareSkillData.EndTime);
            skillTradeOption.Click();
            renderCredit();
            creditTextbox.SendKeys(shareSkillData.Credit);
            activeOption.SendKeys(shareSkillData.Active);
            saveButton.Click();
        }

        public string getTitle(string title)
        {
            Thread.Sleep(4000);
            renderTitle(title);
            return newTitle.Text;
        }
        public void renderUpdateComponents()
        {
            Wait.WaitToExist(driver, "XPath", "//input[@name=\"title\"]", 30);
            titleTextBox = driver.FindElement(By.XPath("//input[@name=\"title\"]"));
            descriptionTextBox = driver.FindElement(By.XPath("//textarea[@name=\"description\"]"));
            saveButton = driver.FindElement(By.XPath("//input[@value='Save']"));

        }
        public void Edit_ShareSkill(ShareSkillData newshareSkillData)
        {
            renderUpdateComponents();
            Thread.Sleep(8000);
            titleTextBox.Clear();
            titleTextBox.SendKeys(newshareSkillData.Title);

            descriptionTextBox.Clear();
            descriptionTextBox.SendKeys(newshareSkillData.Description);
            saveButton.Click();
        }
        public void renderMessage()
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 4);
                successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public string getMessage()
        {
            renderMessage();
            return successMessage.Text;
        }
    }
}
