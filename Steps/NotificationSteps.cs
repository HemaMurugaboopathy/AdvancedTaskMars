using AdvancedTask.Pages.Components.Notifications;
using AdvancedTask.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Steps
{
    public class NotificationSteps: CommonDriver
    {
        NotificationOverviewComponent notificationOverviewComponent;
        NotificationComponent notificationComponent;

        public NotificationSteps()
        {
            notificationOverviewComponent = new NotificationOverviewComponent();
            notificationComponent = new NotificationComponent();
        }
        public void loadMoreNotification()
        {
            notificationOverviewComponent.GoToNotificationDropdown();
            notificationComponent.LoadMoreNotification();
        }
        public void showLessNotification()
        {
            notificationOverviewComponent.GoToNotificationDropdown();   
            notificationComponent.ShowLessNotification();
        }
        public void deleteNotification()
        {
            notificationOverviewComponent.GoToNotificationDropdown();
            notificationComponent.DeleteNotification();
        }
        public void markAsReadNotification()
        {
            notificationOverviewComponent.GoToNotificationDropdown();   
            notificationComponent.MarkAsReadNotification();
        }
        public void selectAllNotification()
        {
            notificationOverviewComponent.GoToNotificationDropdown();
            notificationComponent.SelectAllNotification();
        }
        public void unSelectAllNotification()
        {
            notificationOverviewComponent.GoToNotificationDropdown();
            notificationComponent.UnSelectAllNotification();
        }

    }
}
