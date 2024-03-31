using AdvancedTask.Pages.Components;
using AdvancedTask.Steps;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace AdvancedTask.Tests
{
    [TestFixture]
    public class Skills_Tests: CommonDriver
    {
        LoginPageSteps loginPageSteps;
        ProfileSkillsComponent profileSkillsComponent;
        ProfileMenuTabComponents profileMenuTabComponents;
        AddEditSkillComponent addEditSkillComponent;
        SkillsPageSteps skillsPageSteps;

        public Skills_Tests()
        {
            loginPageSteps = new LoginPageSteps();
            profileMenuTabComponents = new ProfileMenuTabComponents();
            profileSkillsComponent = new ProfileSkillsComponent();
            skillsPageSteps = new SkillsPageSteps();
            addEditSkillComponent = new AddEditSkillComponent();
        }
        [SetUp]
        public void LoginSetUp()
        {
            //Login page object initialization and definition
            loginPageSteps.SigninActions();
            loginPageSteps.LoginActions();
            profileMenuTabComponents.GoToSkillsPage();
        }

        [Test, Order(1), Description("Deleting all records before entering any details")]
        public void Delete_All()
        {
            addEditSkillComponent.Delete_All_Records();
        }

        [Test, Order(2), Description("This test is creating a new skills")]
        [TestCase(1)]
        public void Add_Skills(int id)
        {
             skillsPageSteps.Add_Skills(id);
        }

        [Test, Order(3), Description("This test is adding a new skill with special characters")]
        [TestCase(2)]
        public void Add_SkillsSpecial(int id)
        {
             skillsPageSteps.Add_Skills(id);
        }

        [Test, Order(4), Description("This test is adding a new skill with empty text box")]
        [TestCase(3)]
        public void Add_SkillEmptyTextbox(int id)
        {
            skillsPageSteps.Add_EmptySkill(id);
        }

        [Test, Order(5), Description("This test is adding a new Skill with more characters")]
        [TestCase(4)]
        public void Add_SkillMoreCharacters(int id)
        {
            skillsPageSteps.Add_Skills(id);
        }
        [Test, Order(6), Description("This is editing an existing skill")]
        [TestCase(1)]
        public void Edit_Skills(int id)
        {
            skillsPageSteps.Edit_Skills(id);
         }

        [Test, Order(7), Description("Cancel when editing")]
        [TestCase(1)]
        public void Cancel_Skills(int id)
        {
            skillsPageSteps.Cancel_Skills();
        }

        [Test, Order(8), Description("This is deleting an existing skills")]
        [TestCase(1)]
        public void Delete_SkillsPage(int id)
        {
            skillsPageSteps.Delete_Skills(id);
        }
    }
}
