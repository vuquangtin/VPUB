using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sWorldModel;
using sWorldModel.TransportData;
using System.Resources;
using CommonHelper.Utils;
using System;
using sAccessComponent.Constants;
using sBuildingCommunication.Define;
using CommonHelper.Constants;

namespace sAccessComponent.WorkItems
{
    public class AccessComponentWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;

        private ToolStripMenuItem mniSaiGonPearl, mniDeviceDoorMgt,mniDeviceDoorGroup,mniMemberGroup,mniConfigAccess, mniDoorInStatistics, mniConfig, mniManagerCost;

        private ToolStripSeparator separator1, separator2, separator3;

        public AccessComponentWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SmartParts.AddNew<UsrDeviceDoorGroupMgt>(ComponentName.DeviceDoorGroupMgt);
            SmartParts.AddNew<UsrMemberGroupMgt>(ComponentName.MemberGroupMgt);
            SmartParts.AddNew <UsrConfigAccessControll>(ComponentName.ConfigAccessControll);
            SmartParts.AddNew<UsrDeviceDoorGroupMgt>(ComponentName.DeviceDoorGroupMgt);
            SmartParts.AddNew<UsrDoorInStatistics>(ComponentNames.DoorInStatistics);
            SmartParts.AddNew<UsrManagerCostStatistics>(ComponentNames.ManagerCostStatistics);

            AddSaiGonPearlMenuItems();
            EnableMenuItems(false);
        }
        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(ExtensionSiteNames.MenuAccess);

        }
        private void AddSaiGonPearlMenuItems()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<PolicySworld> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<PolicySworld>;
            ResourceManager rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;

            mniSaiGonPearl = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuAccess));
            //menu nhom devicedoor
            if (permissions.Exists(e => FunctionExtMethods.ToFunction(e.ModuleId) == Functions.FUNC_GROUP_DEVICE_DOOR_MGT))
            {
                mniDeviceDoorGroup = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuName.MenugGroupDeviceDoorManager));
                Commands[AccessCommandNames.ShowGroupDeviceDoorMgtMain].AddInvoker(mniDeviceDoorGroup, "Click");
                mniSaiGonPearl.DropDownItems.Add(mniDeviceDoorGroup);
            }
            //menu nhom nguoi dung
            if (permissions.Exists(e => FunctionExtMethods.ToFunction(e.ModuleId) == Functions.FUNC_MEMBER_GROUP_MGT))
            {
                mniMemberGroup = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuName.MenuMemberGroupManager));
                Commands[AccessCommandNames.ShowMemberGroupMgtMain].AddInvoker(mniMemberGroup, "Click");
                mniSaiGonPearl.DropDownItems.Add(mniMemberGroup);
            }
            // cau hinh ra vao cua
            if (permissions.Exists(e => FunctionExtMethods.ToFunction(e.ModuleId) == Functions.FUNC_CONFIG_ACCESS_CONTROLL))
            {
                mniConfig = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuName.MenuConfigAccessControll));
                Commands[AccessCommandNames.ShowConfigAccessControll].AddInvoker(mniConfig, "Click");
                mniSaiGonPearl.DropDownItems.Add(mniConfig);
            }
          
            //if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_DOOR_STATISTICS))
            //{
            //    mniDoorInStatistics = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuDoorInStatistics));
            //    Commands[AccessCommandNames.ShowDoorInStatistics].AddInvoker(mniDoorInStatistics, "Click");
            //    mniSaiGonPearl.DropDownItems.Add(mniDoorInStatistics);
            //}

            //if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MANAGER_COSTSTATICS))
            //{
            //    mniManagerCost = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuManagerCostStatistics));
            //    Commands[AccessCommandNames.ShowManagerCostStatistics].AddInvoker(mniManagerCost, "Click");
            //    mniSaiGonPearl.DropDownItems.Add(mniManagerCost);
            //}

            //if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_UPDATE_MONTHLY_DEBT))
            //{
            //    separator2 = new ToolStripSeparator();
            //    mniSaiGonPearl.DropDownItems.Add(separator2);

            //    mniConfig = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuAccessConfig), null, mniAccessConfig_Clicked);
            //    mniSaiGonPearl.DropDownItems.Add(mniConfig);

            //}

            if (mniSaiGonPearl.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mniSaiGonPearl);
                UIExtensionSites.RegisterSite(ExtensionSiteNames.MenuAccess, mniSaiGonPearl);
            }

        }
        private void EnableMenuItems(bool enabled)
        {
        }

        private void mniAccessConfig_Clicked(object sender, EventArgs e)
        {
            FrmAddOrEditMontlyDebt dialog = new FrmAddOrEditMontlyDebt();
            SmartParts.Add(dialog);
            dialog.ShowDialog();
            SmartParts.Remove(dialog);
            dialog.Dispose();
        }
    }
}
