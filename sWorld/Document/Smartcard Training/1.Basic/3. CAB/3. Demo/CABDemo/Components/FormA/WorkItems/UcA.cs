using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;


namespace FormA
{
    //[SmartPart]
    public partial class UcA : UserControl
    {
        #region Properties

        private FormAWordItem workItem;
        [ServiceDependency]
        public FormAWordItem WorkItem
        {
            set { workItem = value; }
        }

        #endregion

        public UcA()
        {
            InitializeComponent();
        }

        #region CAB events

        [CommandHandler(ComponentNames.CommandUCFormA)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UcA uc = workItem.Items.Get<UcA>(ComponentNames.ShowUCFormA);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UcA>(ComponentNames.ShowUCFormA);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UcA>(ComponentNames.ShowUCFormA);
            }

            workItem.Workspaces[ComponentNames.MainWorkspace].Show(uc);
            uc.Parent.Text = "Show UC Form A";
        }

        #endregion
    }
}
