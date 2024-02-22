using AdvancedTask.Data;
using AdvancedTask.Pages;
using AdvancedTask.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Tests
{
    [TestFixture]
    public class profile_Tests: CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        ProfilePage profilePageObj = new ProfilePage();

        public profile_Tests()
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

            ////Education page object initialization and deifinition
            //profilePageObj.Profile(profileData profileData);
        }

        [Test, Description("Adding profile details")]
        public void Profile(int id)
        {
            profileData profileData = ProfileDataHelper
               .ReadProfileData(@"addProfileData.json")
               .FirstOrDefault(x => x.Id == id);
            profilePageObj.Profile(profileData);
        }

    }
}
