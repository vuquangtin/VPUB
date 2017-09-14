using System;
using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using sMeetingComponent.WorkItems;

namespace sMeetingComponent
{ 
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        private MeetingComponentWorkItem sMeetingWorkItem;

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
            sMeetingWorkItem = new MeetingComponentWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(sMeetingWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            sMeetingWorkItem.Dispose();
        }
    }
}

