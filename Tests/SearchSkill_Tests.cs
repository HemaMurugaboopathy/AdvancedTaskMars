using AdvancedTask.Steps;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace AdvancedTask.Tests
{
    [TestFixture]
    public class SearchSkill_Tests : CommonDriver
    {
        LoginPageSteps loginPageSteps;
        HomePageSteps homePageSteps;
        SearchSkillSteps searchSkillSteps;
  
        public SearchSkill_Tests()
        {
            loginPageSteps = new LoginPageSteps();
            homePageSteps = new HomePageSteps();
            searchSkillSteps = new SearchSkillSteps();
        }
        [SetUp]
        public void LoginSetUp()
        {
            //Login page object initialization and definition
            loginPageSteps.SigninActions();
            loginPageSteps.LoginActions();
            homePageSteps.GoToSearchSkill();
        }

        [Test, Order(1), Description("Search skill by category")]
        public void SearchSkill_ByCategory()
        {
             searchSkillSteps.SearchSkill_ByCategory();
        }
        [Test, Order(2), Description("Search skill by sub category")]
        public void SearchSkill_BySubCategory()
        {
             searchSkillSteps.SearchSkill_BySubCategory();
        }

        [Test, Order(3), Description("Filter by Online or onsite")]
        public void Filter()
        {
             searchSkillSteps.SearchSkill_ByFilter();
        }
    }
}
