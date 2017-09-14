using Common;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using System;
using System.Windows.Forms;
namespace FormA
{
    public class ComponentInit : ModuleInit
    {
        #region Properties

        private FormAWordItem formAWordItem;
        private WorkItem rootWorkItem;

        [ServiceDependency]
        public WorkItem RootWorkItem
        {
            set { rootWorkItem = value; }
        }

        #endregion

        public override void Load()
        {
            base.Load();
        }

        [EventSubscription(ComponentNames.UserLoggedIn)]
        public void OnUserLoggedIn(object sender, EventArgs e)
        {
            formAWordItem = new FormAWordItem(rootWorkItem.Workspaces[ComponentNames.MainWorkspace]);
            rootWorkItem.WorkItems.Add(formAWordItem);
        }

        [EventSubscription(ComponentNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            formAWordItem.Dispose();
        }
    }
}
