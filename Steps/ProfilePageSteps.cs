using AdvancedTask.AssertHelpers;
using AdvancedTask.Data;
using AdvancedTask.Pages.Components.ProfileAboutMe;
using AdvancedTask.Utilities;

namespace AdvancedTask.Steps
{
    public class ProfilePageSteps: CommonDriver
    {
        ProfileComponent ProfileComponent;

        public ProfilePageSteps()
        {
            ProfileComponent = new ProfileComponent();
        }

        public void editAvailability(int id)
        {
            profileData profileData = ProfileDataHelper.ReadProfileData(@"addProfileData.json").FirstOrDefault(x => x.Id == id);
            ProfileComponent.Edit_Availability(profileData);
            String acutalSuccessMessage = ProfileComponent.getMessage();
            string expected = "Availability updated";
            ProfileAssertHelper.assertProfileSuccessMessage(expected, acutalSuccessMessage);
        }
        public void editHour(int id)
        {
            profileData profileData = ProfileDataHelper.ReadProfileData(@"addProfileData.json").FirstOrDefault(x => x.Id == id);
            ProfileComponent.Edit_Hours(profileData);
            String acutalSuccessMessage = ProfileComponent.getMessage();
            string expected = "Availability updated";
            ProfileAssertHelper.assertProfileSuccessMessage(expected, acutalSuccessMessage);
        }
        public void editEarnTarget(int id)
        {
            profileData profileData = ProfileDataHelper.ReadProfileData(@"addProfileData.json").FirstOrDefault(x => x.Id == id);
            ProfileComponent.Edit_EarnTarget(profileData);
            String acutalSuccessMessage = ProfileComponent.getMessage();
            string expected = "Availability updated";
            ProfileAssertHelper.assertProfileSuccessMessage(expected, acutalSuccessMessage);
        }


    }
}
