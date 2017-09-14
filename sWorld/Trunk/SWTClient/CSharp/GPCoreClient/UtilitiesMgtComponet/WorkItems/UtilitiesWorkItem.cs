using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using UtilitiesMgtComponet.Constants;
using sWorldModel;
using sWorldModel.TransportData;

namespace UtilitiesMgtComponet.WorkItems
{
    public class UtilitiesWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;

        private ToolStripMenuItem mnuUtilities, mnuWirteKey, mnuClearEmptyCard;
        private ToolStripSeparator separator1, separator2;

        public UtilitiesWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            
            AddUtilitiesMenuItem();
            EnableMenuItems(false);
            //SmartParts.AddNew<UsrIntegratingLog>(ComponentNames.IntegratingLogComponent);
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(ExtensionSiteNames.MenuUtilities);
        }

        private void AddUtilitiesMenuItem()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<Function> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<Function>;

            mnuUtilities = new ToolStripMenuItem(MenuNames.MenuUtilities);

            if (permissions.Exists(e => e == Function.FUNC_CARD_IMPORT))
            {
                mnuWirteKey = new ToolStripMenuItem(MenuNames.MenuWirteKey, null, mniWritekey_Clicked);
                mnuUtilities.DropDownItems.Add(mnuWirteKey);
            }

            //chua tao function name
            if (permissions.Exists(e => e == Function.FUNC_MEMBER_VIEW))
            {
                mnuWirteKey = new ToolStripMenuItem(MenuNames.MenuClearEmptyCard);
                mnuUtilities.DropDownItems.Add(mnuWirteKey);
            }
         
            if (mnuUtilities.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mnuUtilities);
                UIExtensionSites.RegisterSite(ExtensionSiteNames.MenuUtilities, mnuUtilities);
            }
        }

        private void EnableMenuItems(bool enabled)
        {
            //if (mnuPersoCard != null)
            //{
            //    mnuPersoCard.Enabled = enabled;
            //}
        }

        //[EventSubscription(MemberEventTopicNames.MemberListShown)]
        //public void OnMemberListShown(object sender, EventArgs e)
        //{
        //    EnableMenuItems(true);
        //}

        //[EventSubscription(MemberEventTopicNames.MemberListHide)]
        //public void OnMemberListHide(object sender, EventArgs e)
        //{
        //    EnableMenuItems(false);
        //}

        private void mniWritekey_Clicked(object sender, EventArgs e)
        {
            FrmWriteMasterKey dialog = new FrmWriteMasterKey();
            SmartParts.Add(dialog);
            dialog.ShowDialog();
            SmartParts.Remove(dialog);
            dialog.Dispose();
        }
    }
}
