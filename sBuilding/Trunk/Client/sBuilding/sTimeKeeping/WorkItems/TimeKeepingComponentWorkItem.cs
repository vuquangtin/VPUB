using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using sTimeKeeping.Constants;
using sWorldModel;
using sWorldModel.TransportData;
using System.Collections.Generic;
using System.Resources;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems {
    /// <summary>
    /// class TimeKeepingComponentWorkItem : WorkItem 
    /// </summary>
    public class TimeKeepingComponentWorkItem : WorkItem {
        private IWorkspace mainWorkspace;

        private ToolStripMenuItem mniTimeKeeping, mniDoorTimeKeeping,
            mniTimeConfig, mniHolidayConfig, mniGeneralConfig, mniDayOffConfig, mniTimeKeepingWithoutCard;

        //  private ToolStripSeparator separator1, separator2, separator3;

        public TimeKeepingComponentWorkItem(IWorkspace mainWorkspace) {
            this.mainWorkspace = mainWorkspace;
        }
        /// <summary>
        /// override void OnInitialized
        /// </summary>
        protected override void OnInitialized() {
            base.OnInitialized();

            AddTimeKeepingMenuItems();
            EnableMenuItems(false);

            SmartParts.AddNew<UsrGeneralConfig>(DefineName.GeneralConfig);
            SmartParts.AddNew<UsrUserStatistic>(DefineName.UserStatistic);
            SmartParts.AddNew<UsrMonthStatistic>(DefineName.MonthStatistic);
            SmartParts.AddNew<UsrDateStatistic>(DefineName.DateStatistic);
            SmartParts.AddNew<UsrTimeEvent>(DefineName.TimeEvent);
            SmartParts.AddNew<UsrDeviceConfig>(DefineName.DeviceConfig);
            SmartParts.AddNew<UsrTimeConfig>(DefineName.TimeConfig);
            SmartParts.AddNew<UsrUserTimeConfig>(DefineName.UserTimeConfig);
            SmartParts.AddNew<UsrHolidayConfig>(DefineName.HolidayConfig);
            SmartParts.AddNew<UsrDayOffConfig>(DefineName.DayOffConfig);
            //SmartParts.AddNew<FrmTimeKeeping>(DefineName.FormTimeKeeping);        // Đóng code để sau này có cần màn hình cảm ứng riêng
            SmartParts.AddNew<UsrTimeKeepingWithoutCard>(DefineName.TimeKeepingWithoutCard);
        }

        /// <summary>
        /// override void OnDisposed
        /// </summary>
        protected override void OnDisposed() {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(TimeCommandName.MenuTimekeeping);
        }

        /// <summary>
        /// Add TimeKeeping Menu Items
        /// </summary>
        private void AddTimeKeepingMenuItems() {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<PolicySworld> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<PolicySworld>;
            ResourceManager rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;

            mniTimeKeeping = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuTimeKeeping));

            //cấu hình chung
            if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_TIMEKEEPING_GENERAL_CONFIG)) {
                mniGeneralConfig = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuGeneralConfig));
                Commands[TimeCommandName.ShowGeneralConfig].AddInvoker(mniGeneralConfig, "Click");
                mniTimeKeeping.DropDownItems.Add(mniGeneralConfig);
            }
            //cấu hình thiết bị
            if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_TIMEKEEPING_DEVICE_CONFIG)) {
                mniTimeConfig = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuDeviceConfig));
                Commands[TimeCommandName.ShowDeviceConfig].AddInvoker(mniTimeConfig, "Click");
                mniTimeKeeping.DropDownItems.Add(mniTimeConfig);
            }
            //cấu hình thời gian chấm công
            if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_TIMEKEEPING_TIME_CONFIG)) {
                mniTimeConfig = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuTimeConfig));
                Commands[TimeCommandName.ShowTimeConfig].AddInvoker(mniTimeConfig, "Click");
                mniTimeKeeping.DropDownItems.Add(mniTimeConfig);
            }
            //cấu hình thời gian chấm công cho từng người
            //if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_TIMEKEEPING_USER_TIME_CONFIG)) {
            //    mniTimeConfig = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuUserTimeConfig));
            //    Commands[TimeCommandName.ShowUserTimeConfig].AddInvoker(mniTimeConfig, "Click");
            //    mniTimeKeeping.DropDownItems.Add(mniTimeConfig);
            //}
            //cấu hình ngày lễ
            if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_TIMEKEEPING_HOLIDAY_CONFIG)) {
                mniHolidayConfig = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuHolidayConfig));
                Commands[TimeCommandName.ShowHolidayConfig].AddInvoker(mniHolidayConfig, "Click");
                mniTimeKeeping.DropDownItems.Add(mniHolidayConfig);
            }
            //cấu hình sự kiện
            if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_TIME_EVENT)) {
                mniDoorTimeKeeping = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuTimeEvent));
                Commands[TimeCommandName.ShowTimeEvent].AddInvoker(mniDoorTimeKeeping, "Click");
                mniTimeKeeping.DropDownItems.Add(mniDoorTimeKeeping);
            }
            //cấu hình ngày nghỉ nhân viên
            if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_TIMEKEEPING_DAY_OFF_CONFIG)) {
                mniDayOffConfig = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuDayOffConfig));
                Commands[TimeCommandName.ShowDayOffConfig].AddInvoker(mniDayOffConfig, "Click");
                mniTimeKeeping.DropDownItems.Add(mniDayOffConfig);
            }
            //thống kê theo user
            if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_USER_STATISTIC)) {
                mniDoorTimeKeeping = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuUserStatistic));
                Commands[TimeCommandName.ShowUserStatistic].AddInvoker(mniDoorTimeKeeping, "Click");
                mniTimeKeeping.DropDownItems.Add(mniDoorTimeKeeping);
            }
            //thống kê theo ngày
            if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_DATE_STATISTIC)) {
                mniDoorTimeKeeping = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuDateStatistic));
                Commands[TimeCommandName.ShowDateStatistic].AddInvoker(mniDoorTimeKeeping, "Click");
                mniTimeKeeping.DropDownItems.Add(mniDoorTimeKeeping);
            }
            //thống kê theo tháng
            if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_MONTH_STATISTIC)) {
                mniDoorTimeKeeping = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuMonthStatistic));
                Commands[TimeCommandName.ShowMonthStatistic].AddInvoker(mniDoorTimeKeeping, "Click");
                mniTimeKeeping.DropDownItems.Add(mniDoorTimeKeeping);
            }

            //// Chấm công màn hình cảm ứng
            //if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_FORM_TIMEKEEPING)) {
            //    mniFormTimeKeeping = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuFormTimeKeeping));
            //    Commands[TimeCommandName.ShowFormTimeKeeping].AddInvoker(mniFormTimeKeeping, "Click");
            //    mniTimeKeeping.DropDownItems.Add(mniFormTimeKeeping);
            //}       // Đóng code để sau này có cần màn hình cảm ứng riêng

            // Usr chấm công không cần thẻ
            if (permissions.Exists(e => FunctionTimeKeepingExtMethod.ToFunction(e.ModuleId) == FunctionTimeKeeping.FUNC_TIMEKEEPING_WITHOUT_CARD)) {
                mniTimeKeepingWithoutCard = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuTimeKeepingWithoutCard));
                Commands[TimeCommandName.ShowTimeKeepingWithoutCard].AddInvoker(mniTimeKeepingWithoutCard, "Click");
                mniTimeKeeping.DropDownItems.Add(mniTimeKeepingWithoutCard);
            }

            if (mniTimeKeeping.DropDownItems.Count > 0) {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mniTimeKeeping);
                UIExtensionSites.RegisterSite(TimeCommandName.MenuTimekeeping, mniTimeKeeping);
            }
        }
        private void EnableMenuItems(bool enabled) {
        }

    }
}
