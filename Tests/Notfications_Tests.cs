using AdvancedTask.Steps;
using AdvancedTask.Utilities;
using NUnit.Framework;

namespace AdvancedTask.Tests
{
    [TestFixture]
    public class Notfications_Tests: CommonDriver
    {
        LoginPageSteps loginPageSteps;
        NotificationSteps notificationSteps;
 
        public Notfications_Tests()
        {
            loginPageSteps = new LoginPageSteps();
            notificationSteps = new NotificationSteps();
        }

        [SetUp]
        public void LoginSetup()
        {
         //Login page object initialization and definition
            loginPageSteps.SigninActions();
            loginPageSteps.LoginActions();
        }
 
        [Test, Order(1), Description("This test is selecting load more oprtion")]
        public void Load_More()
        {
            notificationSteps.loadMoreNotification();
        }
        [Test, Order(1), Description("This test is selecting show less oprtion")]
        public void Show_Less()
        {
            notificationSteps.showLessNotification();
        }
        [Test, Order(2), Description("This test is selecting all the notification")]
        public void Select_All()
        {
            notificationSteps.selectAllNotification();
        }
        [Test, Order(3), Description("This test is unselecting all the notofication")]
        public void Unselect_All()
        {
            notificationSteps.unSelectAllNotification();
        }
        [Test, Order(4), Description("This test is deleting all the notofication")]
        public void Delete_Selection()
        {
            notificationSteps.deleteNotification();
        }
        [Test, Order(5), Description("This test is mark as read the notofication")]
        public void MarkAsRead_Selection()
        {
            notificationSteps.markAsReadNotification();
        }
    }
}
