using AdvancedTask.Utilities;
using OpenQA.Selenium;

namespace AdvancedTask.Pages.Components.Notifications
{
    public class NotificationComponent: CommonDriver
    {
        private IWebElement selectCheckbox;
        private IWebElement selectAllButton;
        private IWebElement unSelectAllButton;
        private IWebElement deleteButton;
        private IWebElement markAsReadButton;
        private IWebElement loadMoreButton;
        private IWebElement showLessButton;
        private IWebElement Message;
        private IReadOnlyCollection<IWebElement> CheckBoxSelected;


        public void renderLoadMoreButton()
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", "//a[@class='ui button']", 20);
                loadMoreButton = driver.FindElement(By.XPath("//a[@class='ui button']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderShowLessButton()
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", "//a[text()='...Show Less']", 10);
                showLessButton = driver.FindElement(By.XPath("//a[text()='...Show Less']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSelectCheckbox()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "(//div[@class='one wide column']/input[@type='checkbox'])[1]", 8);
                selectCheckbox = driver.FindElement(By.XPath("(//div[@class='one wide column']/input[@type='checkbox'])[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDeleteButton()
        {
            try
            {
                deleteButton = driver.FindElement(By.XPath("//div[@data-tooltip=\"Delete selection\"]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderMessage()
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 4);
                Message = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderMarkAsRead()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//i[@class='check square icon']", 4);
                markAsReadButton = driver.FindElement(By.XPath("//i[@class='check square icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSelectAll()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tooltip='Select all']", 20);
                selectAllButton = driver.FindElement(By.XPath("//div[@data-tooltip='Select all']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderUnSelectAll()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tooltip='Unselect all']", 20);
                unSelectAllButton = driver.FindElement(By.XPath("//div[@data-tooltip='Unselect all']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSelectedCheckbox()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//input[@type='checkbox']", 4);
                CheckBoxSelected = driver.FindElements(By.XPath("//input[@type='checkbox']"));
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void LoadMoreNotification()
        {
            renderLoadMoreButton();
            loadMoreButton.Click();
        }
        public void ShowLessNotification()
        {
            renderLoadMoreButton();
            loadMoreButton.Click();
            renderShowLessButton();
            Thread.Sleep(15000);
            showLessButton.Click();
        }
        public void SelectAllNotification()
        {
            renderSelectAll();
            selectAllButton.Click();
        }
        public void MarkAsReadNotification()
        {
            renderSelectCheckbox();
            selectCheckbox.Click();
            renderMarkAsRead();
            markAsReadButton.Click();
        }
        public void UnSelectAllNotification()
        {
            Thread.Sleep(15000);
            renderSelectAll();
            selectAllButton.Click();
            renderUnSelectAll();
            unSelectAllButton.Click();
        }
        public void DeleteNotification()
        {
            renderSelectCheckbox();
            selectCheckbox.Click();
            renderDeleteButton();
            deleteButton.Click();
        }
        public string getMessage()
        {
            renderMessage();
            return Message.Text;
        }
        public List<IWebElement> SelectedCheckbox()
        {
            renderSelectedCheckbox();
            if (CheckBoxSelected == null)
            {
                // If SkillList is null, return an empty list
                return new List<IWebElement>();
            }
            return new List<IWebElement>(CheckBoxSelected);
        }

    }
}
