using AdvancedTask.Pages;
using AdvancedTask.Utilities;

namespace AdvancedTask.Steps
{
    public class SearchSkillSteps: CommonDriver
    {
        SearchSkillComponent searchSkillComponent;

        public SearchSkillSteps()
        {
            searchSkillComponent = new SearchSkillComponent();
        }

        public void SearchSkill_ByCategory()
        {
            searchSkillComponent.Click_SearchIcon();
            searchSkillComponent.SearchSkill_ByCategory(); 
        }
        public void SearchSkill_BySubCategory()
        {
            searchSkillComponent.Click_SearchIcon();
            searchSkillComponent.SearchSkill_ByCategory();
            searchSkillComponent.SearchSkill_BySubCategory();
        }
 
        public void SearchSkill_ByFilter()
        {
            searchSkillComponent.Click_SearchIcon();
            searchSkillComponent.filter();
        }
    }
}
