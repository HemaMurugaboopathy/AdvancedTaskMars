using AdvancedTask.Steps;
using AdvancedTask.Utilities;
using NUnit.Framework;

namespace AdvancedTask.Tests
{
    [TestFixture]
    public class Profile_Tests: CommonDriver
    {
        LoginPageSteps loginPageSteps;
        ProfilePageSteps profilePageSteps;
 
        public Profile_Tests()
        {
            loginPageSteps = new LoginPageSteps();
            profilePageSteps = new ProfilePageSteps();
        }

        [SetUp]
        public void LoginSetUp()
        {
            //Login page object initialization and definition
            loginPageSteps.SigninActions();
            loginPageSteps.LoginActions();       
        }
 
        [Test, Order(1), Description("Updating availability details")]
        [TestCase(1)]
        public void Edit_Availability(int id)
        {
            profilePageSteps.editAvailability(id);
        }

        [Test, Order(2), Description("Updating hours details")]
        [TestCase(1)]
        public void Edit_Hours(int id)
        {
            profilePageSteps.editHour(id);
        }

        [Test, Order(3), Description("Updating earn target details")]
        [TestCase(1)]
        public void Edit_EarnTarget(int id)
        {
            profilePageSteps.editEarnTarget(id);
        }
    }
}
