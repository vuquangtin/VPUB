using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;
using CardChipMgtComponent.WorkItems;

namespace CardChipMgtComponent
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        private CardWorkItem cardWorkItem;

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
            cardWorkItem = new CardWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(cardWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            cardWorkItem.Dispose();
        }
    }
}