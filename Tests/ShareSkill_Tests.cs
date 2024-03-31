using AdvancedTask.Data;
using AdvancedTask.Pages;
using AdvancedTask.Pages.Components;
using AdvancedTask.Steps;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace AdvancedTask.Tests
{
    [TestFixture]
    public class ShareSkill_Tests: CommonDriver
    {
        LoginPageSteps loginPageSteps;
        ProfileMenuTabComponents profileMenuTabComponents;
        ShareSkillSteps shareSkillSteps;
  
        public ShareSkill_Tests()
        {
            loginPageSteps = new LoginPageSteps();
            profileMenuTabComponents = new ProfileMenuTabComponents();
            shareSkillSteps = new ShareSkillSteps();
        }
        [SetUp]
        public void LoginSetUp()
        {
            //Login page object initialization and definition
            loginPageSteps.SigninActions();
            loginPageSteps.LoginActions();
            profileMenuTabComponents.GoToShareSkill();
        }

        [Test, Order(1), Description("Adding share skill")]
        [TestCase(1)]
        public void Add_ShareSkill(int id)
        {
             shareSkillSteps.Add_ShareSkill(id);
        }

        [Test, Order(2), Description("Editing share skill")]
        [TestCase(1)]
        public void Edit_ShareSkill(int id)
        {
            shareSkillSteps.Edit_ShareSkill(id);
        }

        [Test, Order(3), Description("Deleting share skill")]
        [TestCase(1)]
        public void Delete_ShareSkill(int id)
        {
            shareSkillSteps.Delete_ShareSkill(id);
        }
    }
}
