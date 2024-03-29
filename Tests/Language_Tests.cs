using AdvancedTask.Pages.Components;
using AdvancedTask.Steps;
using AdvancedTask.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace AdvancedTask.Tests
{
    [TestFixture]
    public class Language_Tests: CommonDriver
    {
        LoginPageSteps loginPageSteps;
        ProfileLanguageComponents profileLanguageComponents;
        AddEditDeleteLanguageComponent addEditDeleteLanguageComponent;
        LanguagePageSteps languagePageSteps;
        public Language_Tests()
        {
            loginPageSteps = new LoginPageSteps();
            languagePageSteps = new LanguagePageSteps();
            profileLanguageComponents = new ProfileLanguageComponents();
            addEditDeleteLanguageComponent = new AddEditDeleteLanguageComponent();
        }
        [SetUp]
        public void LoginSetUp()
        {
            //Login page object initialization and definition
            loginPageSteps.SigninActions();
            loginPageSteps.LoginActions();
        }

        [Test, Order(1), Description("Deleting all records before entering any details")]
        public void Delete_All()
        {
            addEditDeleteLanguageComponent.Delete_All_Records();
        }

        [Test, Order(2), Description("This test is creating a new languaage")]
        [TestCase(1)]
         public void Add_Language(int id)
        {
            languagePageSteps.Add_Language(id);            
        }
        
        [Test, Order(3), Description("This test is adding a new language with special characters")]
        [TestCase(2)]
        public void Add_LanguageSpecial(int id)
        {
            languagePageSteps.Add_LanguageSpecial(id);
        }

        [Test, Order(4), Description("This test is adding a new Language with empty text box")]
        [TestCase(3)]
        public void Add_LanguageEmptyTextbox(int id)
        {
             languagePageSteps.Add_EmptyTextLanguage(id);
        }

        [Test, Order(5), Description("This test is adding a new Language with more characters")]
        [TestCase(4)]
        public void Add_LanguageMoreCharacters(int id)
        {
            languagePageSteps.Add_LanguageMoreCharacters(id);
        }

        [Test, Order(6), Description("This is editing an existing language")]
        [TestCase(1)]
        public void Edit_Language(int id)
        {
             languagePageSteps.Edit_Language(id);
        }

        [Test, Order(7), Description("Cancel when editing")]
        public void Cancel_Language()
        {
            languagePageSteps.Cancel_Language();
        }

        [Test, Order(8), Description("This is deleting an existing language")]
        [TestCase(1)]
        public void Delete_language(int id)
        {
            languagePageSteps.Delete_Language(id);
        }
    }
}
