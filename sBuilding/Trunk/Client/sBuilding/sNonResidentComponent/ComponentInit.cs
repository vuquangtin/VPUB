using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;

using System.Threading.Tasks;
using System.Windows.Forms;
using sNonResidenComponent.WorkItems;

namespace sMeetingComponent
{ 
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;
        private NonResidentComponentWorkItem sNonResidentWorkItem;

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
            sNonResidentWorkItem = new NonResidentComponentWorkItem(rootWorkItem.Workspaces[WorkspaceName.MainWorkspace]);
            rootWorkItem.WorkItems.Add(sNonResidentWorkItem);
        }

        [EventSubscription(EventTopicNames.UserLoggedOut)]
        public void OnUserLoggedOut(object sender, EventArgs e)
        {
            sNonResidentWorkItem.Dispose();
        }
    }
}

