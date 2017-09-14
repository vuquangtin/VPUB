using System;
using Microsoft.Practices.CompositeUI.WinForms;
using Microsoft.Practices.CompositeUI;
using Common;

namespace CABDemo
{
    class Program : FormShellApplication<WorkItem, Login>
    {
        [STAThread]
        static void Main()
        {
            new Program().Run();
        }

        protected override void AfterShellCreated()
        {
            base.AfterShellCreated();
            RootWorkItem.Items.Add(this.Shell, ComponentNames.LoginForm);
            RootWorkItem.Items.AddNew<MainForm>(ComponentNames.MainForm);
            //RootWorkItem.Items.Add(this.Shell.tabWorkspace, ComponentNames.MainWorkspace);
            //RootWorkItem.UIExtensionSites.RegisterSite(ComponentNames.MainMenu, this.Shell.menuBar);
        }
    }
}
