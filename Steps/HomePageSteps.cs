using AdvancedTask.Pages;
using AdvancedTask.Pages.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
