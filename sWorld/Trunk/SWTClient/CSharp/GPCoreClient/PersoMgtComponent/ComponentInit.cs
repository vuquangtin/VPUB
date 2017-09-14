using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using PersoMgtComponent.WorkItems;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;

namespace PersoMgtComponent
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        [ServiceDependency]
        public WorkItem RootWorkItem
        {
            set { rootWorkItem = value; }
        }

        private PersoWorkItem persoWorkItem;

        public override void Load()
        {
            base.Load();
        }

        [EventSubscription(EventTopicNames.UserLoggedIn)]
        public void OnUserLoggedIn(object sender, EventArgs e)
        {
            persoWorkItem = new PersoWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(persoWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            persoWorkItem.Dispose();
        }
    }
}
