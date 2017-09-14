using CommonHelper.Constants;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using sWorldModel.TransportData;
using SystemMgtComponent.WorkItems.Users;
using SystemMgtComponent.WorkItems.MasterAndPartner;
using SystemMgtComponent.WorkItems.OrgAcquirerManager;
using SystemMgtComponent.WorkItems.CardIntegratingExcel;
using SystemMgtComponent.WorkItems.ExportDataCard;
using SystemMgtComponent.Constants;
using SystemMgtComponent.WorkItems.ImportCard;
using System.Resources;
using CommonHelper.Utils;
using SystemMgtComponent.WorkItems.ClearCard;
using SystemMgtComponent.WorkItems.MoveSubOrganizationForPerson;

namespace SystemMgtComponent.WorkItems
{
    public class SystemWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;

        // menu items
        private ToolStripMenuItem mniOrganization, mniOrgManager, mniDeviceDoorMgt, mniSubOrgManager,
            mniOrgAcquirer, mniMemberManager, mniKeyManager, mniAppManager, mniUserManager,
            mniExcel, mniExport, mniMoveSubOrg;
        private ToolStripSeparator separator1, separator2, separator3, separator4, separator5;

        public SystemWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AddOrgMenuItems();
            EnableMenuItems(false);
            SmartParts.AddNew<UsrOrganizationMgtMain>(ComponentNames.OrganizationMgtComponent);
            SmartParts.AddNew<UsrApplicationMgtMain>(ComponentNames.ApplicationMgtComponent);
            SmartParts.AddNew<UsrUserMgtMain>(ComponentNames.UserMgtComponent);
            SmartParts.AddNew<UsrMemberMgtMain>(ComponentNames.MemberMgtComponent);
            SmartParts.AddNew<UsrMasterAndPartnerMgtMain>(ComponentNames.PartnerOfMasterMgtComponent);
            SmartParts.AddNew<UsrOrgAcquirerManagerMgtMain>(ComponentNames.OrgAcquirerMgtComponent);
            SmartParts.AddNew<UsrDeviceDoorMgtMain>(ComponentNames.DeviceDoorMgtMain);
            SmartParts.AddNew<UsrExportDataCard>(ComponentNames.ExportDataCard);
            SmartParts.AddNew<FrmMoveSubOrgForMember>(ComponentNames.FrmMoveSubOrgForMember);
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(ExtensionSiteNames.MenuSystem);
        }

        /// <summary>
        /// create menu items
        /// </summary>
        private void AddOrgMenuItems()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<PolicySworld> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<PolicySworld>;
            ResourceManager rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;

            // create item for magnetic card
            mniOrganization = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuManager));
            bool isAddSeparator = false;
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_ORG_VIEW))
            {
                mniOrgManager = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuOrgManager));
                Commands[OrganizationCommandNames.ShowOrganizationMgtMain].AddInvoker(mniOrgManager, "Click");
                mniOrganization.DropDownItems.Add(mniOrgManager);
                isAddSeparator = true;
            }          

            //chua thay doi function name
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MEMBER_VIEW))
            {
                mniMemberManager = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMemberManager));
                Commands[OrganizationCommandNames.ShowMemberMgtMain].AddInvoker(mniMemberManager, "Click");
                mniOrganization.DropDownItems.Add(mniMemberManager);
                isAddSeparator = true;
            }

            // Di chuyển phòng ban
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MOVE_SUBORG_VIEW)) {
                mniMoveSubOrg = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMoveSubOrg), null, mniMoveSubOrg_Click);
                mniOrganization.DropDownItems.Add(mniMoveSubOrg);
                isAddSeparator = true;
            }

            if (isAddSeparator)
            {
                separator1 = new ToolStripSeparator();
                mniOrganization.DropDownItems.Add(separator1);
                isAddSeparator = false;
            }


            if (isAddSeparator)
            {
                separator2 = new ToolStripSeparator();
                mniOrganization.DropDownItems.Add(separator2);
                isAddSeparator = false;
            }
#if SWT
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_TOOLKIT_WRITE_KEY_CARD))
            {
                mniKeyManager = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuWirteKey), null, mniWritekey_Clicked);
                mniOrganization.DropDownItems.Add(mniKeyManager);
                isAddSeparator = true;
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_TOOLKIT_CLEAR_EMPTY_CARD))
            {
                mniKeyManager = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuClearEmptyCard), null, mniClearEmptyCard);
                mniOrganization.DropDownItems.Add(mniKeyManager);
                isAddSeparator = true;
            }
#endif
            if (isAddSeparator)
            {
                separator3 = new ToolStripSeparator();
                mniOrganization.DropDownItems.Add(separator3);
                isAddSeparator = false;
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_APP_VIEW))
            {
                mniAppManager = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuAppManager));
                Commands[OrganizationCommandNames.ShowApplicationMgtMain].AddInvoker(mniAppManager, "Click");
                mniOrganization.DropDownItems.Add(mniAppManager);
                isAddSeparator = true;
            }
            if (isAddSeparator)
            {
                separator4 = new ToolStripSeparator();
                mniOrganization.DropDownItems.Add(separator4);
                isAddSeparator = false;
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_USER_VIEW))
            {
                mniUserManager = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuUserManager));
                Commands[UserCommandNames.ShowUserMgtMain].AddInvoker(mniUserManager, "Click");
                mniOrganization.DropDownItems.Add(mniUserManager);
                isAddSeparator = true;
            }

            //device
            if (isAddSeparator)
            {
                separator4 = new ToolStripSeparator();
                mniOrganization.DropDownItems.Add(separator4);
                isAddSeparator = false;
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_DEVICE_DOOR_MGT))
            {
                mniDeviceDoorMgt = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuDeviceDoorManager));
                Commands[OrganizationCommandNames.ShowDeviceDoorMgtMain].AddInvoker(mniDeviceDoorMgt, "Click");
                mniOrganization.DropDownItems.Add(mniDeviceDoorMgt);
            }
            if (isAddSeparator)
            {
                separator5 = new ToolStripSeparator();
                mniOrganization.DropDownItems.Add(separator5);
                isAddSeparator = false;
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_IMPORT_CARD))
            {
                mniKeyManager = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuImportCardFromExcel), null, mniImportCard);
                mniOrganization.DropDownItems.Add(mniKeyManager);
                isAddSeparator = true;
            }
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_EXPORT_CARD))
            {
                mniExport = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuExportCard));
                Commands[OrganizationCommandNames.ShowExportCard].AddInvoker(mniExport, "Click");
                mniOrganization.DropDownItems.Add(mniExport);
            }

            ////End Form Excel

            if (mniOrganization.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mniOrganization);
                UIExtensionSites.RegisterSite(ExtensionSiteNames.MenuSystem, mniOrganization);
            }
        }


        /// <summary>
        /// ????
        /// </summary>
        /// <param name="enabled"></param>
        private void EnableMenuItems(bool enabled)
        {
            ///TODO: implement
        }

        private void mniMoveSubOrg_Click(object sender, EventArgs e) {
            FrmMoveSubOrgForMember dialog_MSO = new FrmMoveSubOrgForMember();
            SmartParts.Add(dialog_MSO);
            dialog_MSO.ShowDialog();
            SmartParts.Remove(dialog_MSO);
            dialog_MSO.Dispose();
        }


        private void mniWritekey_Clicked(object sender, EventArgs e)
        {
            FrmWriteMasterKey dialog = new FrmWriteMasterKey();
            SmartParts.Add(dialog);
            dialog.ShowDialog();
            SmartParts.Remove(dialog);
            dialog.Dispose();
        }

        private void mniClearEmptyCard(object sender, EventArgs e)
        {
            FrmClearEmptyCard dialog = new FrmClearEmptyCard();
            SmartParts.Add(dialog);
            dialog.ShowDialog();
            SmartParts.Remove(dialog);
            dialog.Dispose();
        }
        private void mniImportCard(object sender, EventArgs e)
        {
            FrmImportDataCard dialog = new FrmImportDataCard();
            SmartParts.Add(dialog);
            dialog.ShowDialog();
            SmartParts.Remove(dialog);
            dialog.Dispose();
        }
        //private void mniExportCard(object sender, EventArgs e)
        //{
        //    FrmExportDataCard dialog = new FrmExportDataCard();
        //    SmartParts.Add(dialog);
        //    dialog.ShowDialog();
        //    SmartParts.Remove(dialog);
        //    dialog.Dispose();
        //}
        
        [EventSubscription(OrganizationEventTopicNames.OrganiztionMgtMainShown)]
        public void OnOrgMgtMainShown(object sender, EventArgs e)
        {
            EnableMenuItems(true);
        }
        [EventSubscription(OrganizationEventTopicNames.ApplicationMgtMainShown)]
        public void OnApplicationMgtMainShown(object sender, EventArgs e)
        {
            EnableMenuItems(true);
        }

        [EventSubscription(UserEventTopicNames.UserListShown)]
        public void OnAUserMgtMainShown(object sender, EventArgs e)
        {
            EnableMenuItems(true);
        }
    }

}
