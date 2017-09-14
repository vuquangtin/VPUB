using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using VoucherGiftCardComponent.WorkItems;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;

namespace VoucherGiftCardComponent
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        private VoucherGiftCardWorkItem voucherGiftCardWorkItem;

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
            voucherGiftCardWorkItem = new VoucherGiftCardWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(voucherGiftCardWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            voucherGiftCardWorkItem.Dispose();
        }
    }
}
