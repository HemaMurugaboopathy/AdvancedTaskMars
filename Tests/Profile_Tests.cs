using AdvancedTask.Data;
using AdvancedTask.Pages;
using AdvancedTask.Utilities;
using NUnit.Framework;

namespace AdvancedTask.Tests
{
    [TestFixture]
    public class Profile_Tests: CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        ProfilePage profilePageObj = new ProfilePage();

        public Profile_Tests()
        {
            loginPageObj = new LoginPage();
            profilePageObj = new ProfilePage();
        }

        [SetUp]
        public void LoginSetUp()
        {
            //Open Chrome browser
            Initialize();

            //Login page object initialization and definition
            loginPageObj.LoginActions();
       
        }

        [Test, Order(1), Description("Adding profile details")]
        [TestCase(1)]
        public void Add_Profile(int id)
        {
            profileData profileData = ProfileDataHelper
               .ReadProfileData(@"addProfileData.json")
               .FirstOrDefault(x => x.Id == id);
            profilePageObj.Add_Profile(profileData);      
        }
        public void ProfileTearDown()
        {
            driver.Quit();
        }

    }
}
