using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;
using UtilitiesMgtComponet.WorkItems;

namespace MemberMgtComponent
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        private UtilitiesWorkItem utilitiesWorkItem;

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
            utilitiesWorkItem = new UtilitiesWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(utilitiesWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            utilitiesWorkItem.Dispose();
        }
    }
}