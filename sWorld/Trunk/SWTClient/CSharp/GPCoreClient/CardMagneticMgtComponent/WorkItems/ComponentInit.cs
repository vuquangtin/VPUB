using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;
using CardMagneticMgtComponent.WorkItems;

namespace CommonHelper
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        private CardMagneticWorkItem cardMagneticWorkItem;

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
            cardMagneticWorkItem = new CardMagneticWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(cardMagneticWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            cardMagneticWorkItem.Dispose();
        }
    }
}
