using Common;
using Microsoft.Practices.CompositeUI;
using System;
using System.Windows.Forms;
namespace FormB
{
    public class frmAModuleInit : ModuleInit
    {
        private string btnShowFromBText = "Show Form B";
        private WorkItem parentWorkItem;

        [ServiceDependency]
        public WorkItem ParentWorkItem
        {
            set { parentWorkItem = value; }
        }

        public override void Load()
        {
            base.Load();
            //AddButtonShowFromB();
        }

        public void AddButtonShowFromB()
        {
            ToolStripMenuItem toolStripButton = new ToolStripMenuItem(btnShowFromBText, null, ShowFormB_Clicked);

            UIExtensionSite uiExtensionSite = parentWorkItem.UIExtensionSites[ComponentNames.MainMenu];
            uiExtensionSite.Add<ToolStripMenuItem>(toolStripButton);
        }

        public void ShowFormB_Clicked(object sender, EventArgs e)
        {
            frmB form = new frmB();
            form.ShowDialog();
        }
    }
}
