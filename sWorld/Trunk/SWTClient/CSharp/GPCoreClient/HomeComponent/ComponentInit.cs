using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using HomeComponent.WorkItems;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;

namespace HomeComponent
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        private eCashWorkItem eCashWorkItem;

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
            eCashWorkItem = new eCashWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(eCashWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            eCashWorkItem.Dispose();
        }
    }
}