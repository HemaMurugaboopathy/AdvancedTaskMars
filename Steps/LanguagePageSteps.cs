using AdvancedTask.AssertHelpers;
using AdvancedTask.Data;
using AdvancedTask.Pages.Components;
using AdvancedTask.Utilities;

namespace AdvancedTask.Steps
{
    public class LanguagePageSteps : CommonDriver
    {
        ProfileLanguageComponents ProfileLanguageComponents;
        AddEditDeleteLanguageComponent addEditDeleteLanguageComponent;

        public LanguagePageSteps()
        {
            ProfileLanguageComponents = new ProfileLanguageComponents();
            addEditDeleteLanguageComponent = new AddEditDeleteLanguageComponent();
        }

        public void Add_Language(int id)
        {
            // Read language data from the specified JSON file and retrieve the first item with a matching Id
            LanguageData languageData = JsonReader.loadData<LanguageData>(@"addLanguageData.json").FirstOrDefault(x => x.Id == id);
            ProfileLanguageComponents.Click_AddLanguage();
            addEditDeleteLanguageComponent.Add_Language(languageData);
            String acutalSuccessMessage = addEditDeleteLanguageComponent.getMessage();
            string expected = @".* has been added to your languages.*";
            LanguageAssertHelper.assertAddLanguageSuccessMessage(expected, acutalSuccessMessage);
        }
        public void Add_LanguageSpecial(int id)
        {
            // Read language data from the specified JSON file and retrieve the first item with a matching Id
            LanguageData languageData = JsonReader.loadData<LanguageData>(@"addLanguageData.json").FirstOrDefault(x => x.Id == id);
            ProfileLanguageComponents.Click_AddLanguage();
            addEditDeleteLanguageComponent.Add_LanguageSpecial(languageData);
            String acutalSuccessMessage = addEditDeleteLanguageComponent.getMessage();
            string expected = @".* has been added to your languages.*";
            LanguageAssertHelper.assertAddLanguageSuccessMessage(expected, acutalSuccessMessage);
        }
        public void Add_LanguageMoreCharacters(int id)
        {
             LanguageData languageData = JsonReader.loadData<LanguageData>(@"addLanguageData.json").FirstOrDefault(x => x.Id == id);
            ProfileLanguageComponents.Click_AddLanguage();
            addEditDeleteLanguageComponent.Add_LanguageMoreCharacters(languageData);
            String acutalSuccessMessage = addEditDeleteLanguageComponent.getMessage();
            string expected = @".* has been added to your languages.*";
            LanguageAssertHelper.assertAddLanguageSuccessMessage(expected, acutalSuccessMessage);
        }
        public void Add_EmptyTextLanguage(int id)
        {
            LanguageData languageData = JsonReader.loadData<LanguageData>(@"addLanguageData.json").FirstOrDefault(x => x.Id == id);
            ProfileLanguageComponents.Click_AddLanguage();
            addEditDeleteLanguageComponent.Add_Language(languageData);
            String acutalSuccessMessage = addEditDeleteLanguageComponent.getMessage();
            string expected = "Please enter language and level"; // Update this to the expected message    
            LanguageAssertHelper.assertAddEmptyLanguageSuccessMessage(expected, acutalSuccessMessage);
        }
        public void Edit_Language(int id)
        {
            LanguageData existingLanguageData = JsonReader.loadData<LanguageData>(@"addLanguageData.json").FirstOrDefault(x => x.Id == id);
            LanguageData newLanguageData = JsonReader.loadData<LanguageData>(@"editLanguageData.json").FirstOrDefault(x => x.Id == id);
            ProfileLanguageComponents.Click_UpdateLanguage(existingLanguageData);
            addEditDeleteLanguageComponent.Edit_Language(newLanguageData);
            String acutalSuccessMessage = addEditDeleteLanguageComponent.getMessage();
            string expected = @".* has been updated to your languages.*";
            LanguageAssertHelper.assertEditLanguageSuccessMessage(expected, acutalSuccessMessage);
        }
        public void Cancel_Language()
        {
            ProfileLanguageComponents.Click_AddLanguage();
            addEditDeleteLanguageComponent.getCancel();
        }
        public void Delete_Language(int id)
        {
            LanguageData languageData = JsonReader.loadData<LanguageData>(@"deleteLanguageData.json").FirstOrDefault(x => x.Id == id);
            ProfileLanguageComponents.Click_DeleteLanguage(languageData);
            String acutalSuccessMessage = addEditDeleteLanguageComponent.getMessage();
            string expected = @".* has been deleted from your languages.*";
            LanguageAssertHelper.assertDeleteLanguageSuccessMessage(expected, acutalSuccessMessage);
        }
        public void getMessage()
        {
            addEditDeleteLanguageComponent.getMessage();
        }
    }
}

