using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using sNonResidentComponent.Constants;
using sNonResidentComponent.WorkItems;
using sNonResidentComponent.WorkItems.ManageMeeting;
using sNonResidentComponent.WorkItems.StatisticForNonresident;
using sWorldModel;
using sWorldModel.TransportData;
using System.Collections.Generic;
using System.Resources;
using System.Windows.Forms;

namespace sNonResidenComponent.WorkItems
{
    public class NonResidentComponentWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;
        private ToolStripMenuItem mniNonresident, mniNonresidentFunc;
        private ToolStripSeparator separator4;

        public NonResidentComponentWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
          
            SmartParts.AddNew<UsrAddNonResident>(MenuNames.MenuNonResidentItem);
            SmartParts.AddNew<UsrManageCardNonResident>(MenuNames.MenuManageCardNonResidentItem);
            SmartParts.AddNew<UsrNonResidentStatistics>(MenuNames.MenuNonResidentStatisticItem);
            SmartParts.AddNew<UsrNonResidentStatisticsDetail>(MenuNames.MenuNonResidentStatisticDetailItem);

            SmartParts.AddNew<UsrManageMeeting>(MenuNames.MenuManageMeetingItem);

            AddMeetingMenuItems();
        }
        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(NonResidentCommandName.MenuNonResident);
        }

        private void AddMeetingMenuItems()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<PolicySworld> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<PolicySworld>;
            ResourceManager rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;

            bool isAddSeparator = false;
            mniNonresident = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuNonResident));
            // kiểm soát khách vãng lai
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_NONRESIDENT_ITEM))
            {
                mniNonresidentFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuNonResidentItem));
                Commands[NonResidentCommandName.ShowNonResident].AddInvoker(mniNonresidentFunc, "Click");
                mniNonresident.DropDownItems.Add(mniNonresidentFunc);
            }

            //quản lí phát hành thẻ khách vãng lai
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_NONRESIDENT_MANAGECARD))
            {
                mniNonresidentFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuManageCardNonResidentItem));
                Commands[NonResidentCommandName.ShowManageCardNonResident].AddInvoker(mniNonresidentFunc, "Click");
                mniNonresident.DropDownItems.Add(mniNonresidentFunc);
            }
            //thống kê khách vãng lai
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_NONRESIDENT_STATISTIC))
            {
                mniNonresidentFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuNonResidentStatisticItem));
                Commands[NonResidentCommandName.ShowNonResidentStatistic].AddInvoker(mniNonresidentFunc, "Click");
                mniNonresident.DropDownItems.Add(mniNonresidentFunc);
            }

            //thống kê chi tiết khách vãng lai
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_NONRESIDENT_STATISTIC_DETAIL))
            {
                mniNonresidentFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuNonResidentStatisticDetailItem));
                Commands[NonResidentCommandName.ShowNonResidentStatisticDetail].AddInvoker(mniNonresidentFunc, "Click");
                mniNonresident.DropDownItems.Add(mniNonresidentFunc);
                isAddSeparator = true;
            }

            if (isAddSeparator)
            {
                separator4 = new ToolStripSeparator();
                mniNonresident.DropDownItems.Add(separator4);
                isAddSeparator = false;
            }

            //quản lí cuộc họp
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_NONRESIDENT_MANAGEMEETING))
            {
                mniNonresidentFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuManageMeetingItem));
                Commands[NonResidentCommandName.ShowManageMeeting].AddInvoker(mniNonresidentFunc, "Click");
                mniNonresident.DropDownItems.Add(mniNonresidentFunc);
            }

            if (mniNonresident.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mniNonresident);
                //   UIExtensionSites.RegisterSite(ExtensionSiteNames.MenuAccess, mniNonresident);
                //UIExtensionSites.RegisterSite(NonResidentDefineName.MenuNonResident, mniNonresident);

                UIExtensionSites.RegisterSite(MenuNames.MenuNonResident, mniNonresident);
            }
        }

        //private void mniNonresident_Clicked(object sender, EventArgs e)
        //{
        //    FrmAddNonResident form1 = new FrmAddNonResident();
        //    SmartParts.Add(form1);
        //    form1.ShowDialog();
        //    SmartParts.Remove(form1);
        //    form1.Dispose();
        //}
    }
}
