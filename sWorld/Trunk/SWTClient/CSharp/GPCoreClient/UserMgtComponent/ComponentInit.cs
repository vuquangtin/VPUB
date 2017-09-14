using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using Microsoft.Practices.ObjectBuilder;
using UserMgtComponent.WorkItems;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;

namespace UserMgtComponent
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        private UserWorkItem userWorkItem;

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
            userWorkItem = new UserWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(userWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            userWorkItem.Dispose();
        }
    }
}