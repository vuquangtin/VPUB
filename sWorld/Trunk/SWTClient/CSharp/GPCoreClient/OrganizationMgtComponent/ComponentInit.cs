using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using Microsoft.Practices.ObjectBuilder;
using SystemMgtComponent.WorkItems;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;

namespace SystemMgtComponent
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        private SystemWorkItem organizationWorkItem;

        [InjectionConstructor]
        public ComponentInit([ServiceDependency]WorkItem rootWorkItem)
        {
            this.rootWorkItem = rootWorkItem;
        }

        public override void Load()
        {
            base.Load();
        }

        [EventSubscription(EventTopicNames.UserLoggedIn)]
        public void OnUserLoggedIn(object sender, EventArgs e)
        {
            organizationWorkItem = new SystemWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(organizationWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            organizationWorkItem.Dispose();
        }
    }
}