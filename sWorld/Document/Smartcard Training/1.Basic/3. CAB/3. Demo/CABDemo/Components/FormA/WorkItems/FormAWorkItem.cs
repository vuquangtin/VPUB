using Common;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormA
{
    public class FormAWordItem : WorkItem
    {
        #region Properties

        private IWorkspace mainWorkspace;
        private ToolStripMenuItem tsmiShowFormA;
        private ToolStripMenuItem tsmiShowUcA;
        private string btnShowFromAText = "Show Form A";
        private string btnShowUcFromAText = "Show UC Form A";

        #endregion

        public FormAWordItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AddButtonShowFromA();
            SmartParts.AddNew<UcA>(ComponentNames.ShowUCFormA);
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(ComponentNames.MainMenu);
        }

        public void AddButtonShowFromA()
        {
            UIExtensionSite uiExtensionSite = UIExtensionSites[ComponentNames.MainMenu];

            //add button show user control
            ToolStripMenuItem toolStripButtonUc = new ToolStripMenuItem(btnShowUcFromAText);
            Commands[ComponentNames.CommandUCFormA].AddInvoker(toolStripButtonUc, "Click");
            uiExtensionSite.Add<ToolStripMenuItem>(toolStripButtonUc);
            UIExtensionSites.RegisterSite(ComponentNames.ShowUCFormA, toolStripButtonUc);

            //add button show dialog form A
            ToolStripMenuItem toolStripButton = new ToolStripMenuItem(btnShowFromAText, null, ShowFormA_Clicked);
            uiExtensionSite.Add<ToolStripMenuItem>(toolStripButton);
            UIExtensionSites.RegisterSite(ComponentNames.ShowFormA, toolStripButton);
        }

        private void ShowFormA_Clicked(object sender, EventArgs e)
        {
            frmA form = new frmA();
            form.ShowDialog();
        }
    }
}
