using AdvancedTask.Pages.Components;

namespace AdvancedTask.Steps
{
    public class HomePageSteps
    {
        private ProfileMenuTabComponents profileMenuTabComponents;

        public HomePageSteps()
        {
            profileMenuTabComponents = new ProfileMenuTabComponents();
        }

        public void GoToSkillsPage()
        {
            profileMenuTabComponents.GoToSkillsPage();
        }

        public void GoToShareSkill()
        {
            profileMenuTabComponents.GoToShareSkill();   
        }

        public void GoToSearchSkill()
        {
            profileMenuTabComponents.GoToSearchSkill();
        }
    }
}
