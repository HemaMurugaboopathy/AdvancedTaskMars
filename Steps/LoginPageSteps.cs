using AdvancedTask.Pages;
using AdvancedTask.Pages.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Steps
{
    public class LoginPageSteps
    {
        
        ProfileLoginPageComponent ProfileLoginPageComponent;

        public LoginPageSteps()
        {
            
            ProfileLoginPageComponent = new ProfileLoginPageComponent();
        }
        public void SigninActions()
        {
            ProfileLoginPageComponent.SigninActions();
        }
        public void LoginActions()
        {
            ProfileLoginPageComponent.LoginActions();
        }
    }
}
