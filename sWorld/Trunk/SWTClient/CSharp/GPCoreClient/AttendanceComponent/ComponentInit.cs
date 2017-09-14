using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using AttendanceComponent.WorkItems;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;

namespace DemoComponent
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        private AttendanceWorkItem attendanceWorkItem;

        [ServiceDependency]
        public WorkItem RootWorkItem
        {
            set
            {
                if (rootWorkItem == value)
                    return;
                rootWorkItem = value;
            }
        }

        public override void Load()
        {
            base.Load();
        }

        [EventSubscription(EventTopicNames.UserLoggedIn)]
        public void OnUserLoggedIn(object sender, EventArgs e)
        {
            attendanceWorkItem = new AttendanceWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(attendanceWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            attendanceWorkItem.Dispose();
        }
    }
}
