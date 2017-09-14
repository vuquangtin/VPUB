using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using sWorldModel;
using sWorldModel.TransportData;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
//using UtilitiesMgtComponet.Constants;
using System.Resources;
using CommonHelper.Utils;
using System.Diagnostics;

namespace UtilitiesMgtComponet.WorkItems
{
    public class UtilitiesWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;

        private ToolStripMenuItem mnuSupport, mnuSystemInfo, mnuManual;
        private ToolStripSeparator separator1, separator2;
        private ResourceManager rm;
        public UtilitiesWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            
            AddUtilitiesMenuItem();
            //SmartParts.AddNew<UsrIntegratingLog>(ComponentNames.IntegratingLogComponent);
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(ExtensionSiteNames.MenuSupport);
        }

        private void AddUtilitiesMenuItem()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<Function> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<Function>;
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;

            mnuSupport = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuSupport));

            mnuSystemInfo = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuSystemInfo), null, mniAbout_Clicked);
            mnuSupport.DropDownItems.Add(mnuSystemInfo);

            mnuManual = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuManual), null, mnuManual_Clicked);
            mnuSupport.DropDownItems.Add(mnuManual);

            if (mnuSupport.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mnuSupport);
                UIExtensionSites.RegisterSite(ExtensionSiteNames.MenuSupport, mnuSupport);
            }
        }

        private void mniAbout_Clicked(object sender, EventArgs e)
        {
            FrmAboutSworld frmabout = new FrmAboutSworld(rm);
            frmabout.ShowDialog();
           
        }

        private void mnuManual_Clicked(object sender, EventArgs e)
        {
            Form a = new Form();
            Help.ShowHelp(a, "help.chm");

        }
    }
}
