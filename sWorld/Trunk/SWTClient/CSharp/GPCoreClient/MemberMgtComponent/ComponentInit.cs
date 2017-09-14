using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using Microsoft.Practices.ObjectBuilder;
using MemberMgtComponent.WorkItems;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;

namespace MemberMgtComponent
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        private MemberWorkItem memberWorkItem;

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
            memberWorkItem = new MemberWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(memberWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            memberWorkItem.Dispose();
        }
    }
}