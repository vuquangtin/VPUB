using CommonHelper.Constants;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using sWorldModel.TransportData;
using AttendanceComponent.Constants;
using SystemMgtComponent.WorkItems;
using System.Resources;
using CommonHelper.Utils;

namespace AttendanceComponent.WorkItems
{
    public class AttendanceWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;

        private ToolStripMenuItem mniAttendance, mniAttendanceHistory, mniOtherContact;

        private ToolStripSeparator separator1, separator2, separator3;

        public AttendanceWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AddCardMenuItems();
            EnableMenuItems(false);
            SmartParts.AddNew<UcAttendanceHistory>(ComponentNames.AttendanceMgtComponent);
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(ExtensionSiteNames.MenuAttendance);
        }

        private void AddCardMenuItems()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<PolicySworld> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<PolicySworld>;
            ResourceManager rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;

            mniAttendance = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuAttendance));
            bool isAddSeparator = false;


            mniOtherContact = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuRelatives), null, mniMenuRelatives_Clicked);
            mniAttendance.DropDownItems.Add(mniOtherContact);

            //if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_CHIP_CARD_VIEW))
            //{
            mniAttendanceHistory = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuAttendanceHistory));
            Commands[AttendanceCommandNames.ShowAttendanceMgtMain].AddInvoker(mniAttendanceHistory, "Click");
            mniAttendance.DropDownItems.Add(mniAttendanceHistory);
            //isAddSeparator = true;
            //}


            if (mniAttendance.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mniAttendance);
                UIExtensionSites.RegisterSite(ExtensionSiteNames.MenuCardChip, mniAttendance);
            }
        }

        private void EnableMenuItems(bool enabled)
        {
        }

        private void mniMenuRelatives_Clicked(object sender, EventArgs e)
        {
            frmAddOrEditContact dialog = new frmAddOrEditContact();
            SmartParts.Add(dialog);
            dialog.ShowDialog();
            SmartParts.Remove(dialog);
            dialog.Dispose();
        }
    }
}
