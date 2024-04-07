using AdvancedTask.Pages.Components;

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
