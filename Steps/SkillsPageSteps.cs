using AdvancedTask.AssertHelpers;
using AdvancedTask.Data;
using AdvancedTask.Pages.Components;
using AdvancedTask.Utilities;

namespace AdvancedTask.Steps
{
    public class SkillsPageSteps : CommonDriver
    {

        ProfileSkillsComponent ProfileSkillsComponent;
        AddEditSkillComponent addEditSkillComponent;

        public SkillsPageSteps()
        {
            ProfileSkillsComponent = new ProfileSkillsComponent();
            addEditSkillComponent = new AddEditSkillComponent();
        }

        public void Delete_All_Records()
        {
            addEditSkillComponent.Delete_All_Records();
        }
        public void Add_Skills(int id)
        {
            // Read skills data from the specified JSON file and retrieve the first item with a matching Id
            SkillsData skillsData = JsonReader.loadData<SkillsData>(@"addSkillsData.json").FirstOrDefault(x => x.Id == id);

            ProfileSkillsComponent.Click_AddSkills();
            addEditSkillComponent.Add_Skills(skillsData);
            String acutalSuccessMessage = addEditSkillComponent.getMessage();
            string expected = @".* has been added to your skills.*";
            SkillsAssertHelper.assertAddSkillsSuccessMessage(expected, acutalSuccessMessage);
        }
        public void Add_SkillsSpecial(int id)
        {
            // Read skills data from the specified JSON file and retrieve the first item with a matching Id
            SkillsData skillsData = JsonReader.loadData<SkillsData>(@"addSkillsData.json").FirstOrDefault(x => x.Id == id);

            ProfileSkillsComponent.Click_AddSkills();
            addEditSkillComponent.Add_SkillsSpecial(skillsData);

            String acutalSuccessMessage = addEditSkillComponent.getMessage();
            string expected = @".* has been added to your skills.*";
            SkillsAssertHelper.assertAddSkillsSuccessMessage(expected, acutalSuccessMessage);
        }
        public void Add_SkillsMoreCharacters(int id)
        {
            // Read skills data from the specified JSON file and retrieve the first item with a matching Id
            SkillsData skillsData = JsonReader.loadData<SkillsData>(@"addSkillsData.json").FirstOrDefault(x => x.Id == id);

            ProfileSkillsComponent.Click_AddSkills();
            addEditSkillComponent.Add_SkillsMoreCharacters(skillsData);
            String acutalSuccessMessage = addEditSkillComponent.getMessage();
            string expected = @".* has been added to your skills.*";
            SkillsAssertHelper.assertAddSkillsSuccessMessage(expected, acutalSuccessMessage);

        }
        public void Add_EmptySkill(int id)
        {
            SkillsData skillsData = JsonReader.loadData<SkillsData>(@"addSkillsData.json").FirstOrDefault(x => x.Id == id);
            ProfileSkillsComponent.Click_AddSkills();
            addEditSkillComponent.Add_Skills(skillsData);
            String acutalSuccessMessage = addEditSkillComponent.getMessage();
            string expected = "Please enter skill and experience level"; // Update this to the expected message    
            SkillsAssertHelper.assertAddEmptySkillsSuccessMessage(expected, acutalSuccessMessage);
        }
        public void Edit_Skills(int id)
        {
            SkillsData existingSkillsData = JsonReader.loadData<SkillsData>(@"addSkillsData.json").FirstOrDefault(x => x.Id == id);
            SkillsData newSkillsData = JsonReader.loadData<SkillsData>(@"editSkillsData.json").FirstOrDefault(x => x.Id == id);
            ProfileSkillsComponent.Click_UpdateSkills(existingSkillsData);
            addEditSkillComponent.Edit_Skills(newSkillsData);
            String acutalSuccessMessage = addEditSkillComponent.getMessage();
            string expected = @".* has been updated to your skills.*";
            SkillsAssertHelper.assertAddSkillsSuccessMessage(expected, acutalSuccessMessage);
        }

        public void Cancel_Skills()
        {
            ProfileSkillsComponent.Click_AddSkills();
            addEditSkillComponent.getCancel();
        }

        public void Delete_Skills(int id)
        {
            SkillsData skillsData = JsonReader.loadData<SkillsData>(@"deleteSkillsData.json").FirstOrDefault(x => x.Id == id);
            ProfileSkillsComponent.Click_DeleteSkills(skillsData);
            String acutalSuccessMessage = addEditSkillComponent.getMessage();
            string expected = @".* has been deleted*";
            SkillsAssertHelper.assertDeleteSkillsSuccessMessage(expected, acutalSuccessMessage);
        }
        public void getMessage()
        {
            addEditSkillComponent.getMessage();
        }
    }
}
