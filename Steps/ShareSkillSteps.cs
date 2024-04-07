using AdvancedTask.AssertHelpers;
using AdvancedTask.Data;
using AdvancedTask.Pages;
using AdvancedTask.Pages.Components;
using AdvancedTask.Utilities;

namespace AdvancedTask.Steps
{
    public class ShareSkillSteps: CommonDriver
    {
        ShareSkillOverviewComponent shareSkillOverviewComponent;
        AddEditShareSkillComponent addEditShareSkillComponent;

        public ShareSkillSteps()
        {
            shareSkillOverviewComponent = new ShareSkillOverviewComponent();
            addEditShareSkillComponent = new AddEditShareSkillComponent();
        }

        public void Add_ShareSkill(int id)
        {
            ShareSkillData shareSkillData = JsonReader.loadData<ShareSkillData>(@"addShareSkillData.json").FirstOrDefault(x => x.Id == id);
            shareSkillOverviewComponent.clickShareSkillButton();
            addEditShareSkillComponent.Add_ShareSkill(shareSkillData);
            shareSkillOverviewComponent.clickManageListings();
            string newTitle = addEditShareSkillComponent.getTitle(shareSkillData.Title);
            ShareSkillAssertHelper.assertAddShareSkillSuccessMessage(shareSkillData.Title, newTitle);
        }

        public void Edit_ShareSkill(int id)
        {
            // Read share skill data from the specified JSON file and retrieve the first item with a matching Id
            ShareSkillData existingShareSkillData = JsonReader.loadData<ShareSkillData>(@"addShareSkillData.json").FirstOrDefault(x => x.Id == id);
            ShareSkillData newShareSkillData = JsonReader.loadData<ShareSkillData>(@"editShareSkillData.json").FirstOrDefault(x => x.Id == id);
            shareSkillOverviewComponent.clickManageListings();
            shareSkillOverviewComponent.clickUpdateButton(existingShareSkillData);
            addEditShareSkillComponent.Edit_ShareSkill(newShareSkillData);
            shareSkillOverviewComponent.clickManageListings(); 
        }
        public void Delete_ShareSkill(int id)
        {
            ShareSkillData shareSkillData = JsonReader.loadData<ShareSkillData>(@"deleteShareSkillData.json").FirstOrDefault(x => x.Id == id);
            shareSkillOverviewComponent.clickManageListings();
            shareSkillOverviewComponent.clickDeleteButton(shareSkillData);
            String actualMessage = addEditShareSkillComponent.getMessage();
            string expected = @".* has been deleted *";
            ShareSkillAssertHelper.assertDeleteShareSkillSuccessMessage(expected, actualMessage);
        }
    }
}
