using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using sMeetingComponent.Constants;
using sMeetingComponent.WorkItems.ContactForWork;
using sMeetingComponent.WorkItems.ScheduleMeeting;
using sMeetingComponent.WorkItems.StatictisAttendMeeting;
using sMeetingComponent.WorkItems.StatisticForJournalist;
using sWorldModel;
using sWorldModel.TransportData;
using System.Collections.Generic;
using System.Resources;
using System.Windows.Forms;

namespace sMeetingComponent.WorkItems
{
    public class MeetingComponentWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;
        private ToolStripMenuItem mniMeeting, mniMeetingFunc;
        private ToolStripSeparator separator4;

        public MeetingComponentWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            AddMeetingMenuItems();
            SmartParts.AddNew<UsrListMeeting>(MenuNames.MenuMeetingItem);

            /// ẩn dời lịch họp
            //SmartParts.AddNew<UsrScheduleMeeting>(MenuNames.MenuMeetingItemScheduleAMeeting);

            SmartParts.AddNew<UsrAttendMeetingStatistics>(MenuNames.MenuMeetingItemStatistic);
            SmartParts.AddNew<UsrAttendMeetingStatisticsDetail>(MenuNames.MenuMeetingItemStatisticDetail);

            // thống kê đơn vị liên hệ trong sworld chưa có anh TEN chua
            SmartParts.AddNew<UsrContactForWordStatistics>(MenuNames.MenuMeetingItemStatisticContactWork);

            SmartParts.AddNew<UsrJournalistAttendMeeting>(MenuNames.MenuMeetingItemJournalistAttendMeeting);
            SmartParts.AddNew<UsrJournalistToAttendMeetingStatistics>(MenuNames.MenuMeetingItemStatisticOfJournalist);
            SmartParts.AddNew<UsrJournalistToAttendMeetingStatisticsDetail>(MenuNames.MenuMeetingItemStatisticDetailOfJournalist);

        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(MeetingCommandName.MenuMeeting);
        }

        private void AddMeetingMenuItems()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<PolicySworld> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<PolicySworld>;
            ResourceManager rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            bool isAddSeparator = false;
            mniMeeting = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMeeting));
            // kiểm soát hội họp
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MEETING_ITEM))
            {
                //  mniMeetingFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MeetingDefineName.MenuMeeting),null,mniMeeting_Clicked);
                // mniMeeting.DropDownItems.Add(mniMeetingFunc);
                mniMeetingFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMeetingItem));
                Commands[MeetingCommandName.ShowMeeting].AddInvoker(mniMeetingFunc, "Click");
                mniMeeting.DropDownItems.Add(mniMeetingFunc);
            }
            /// ẩn dời lịch họp
            // Dời lịch họp
            //if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MEETING_SCHEDULE))
            //{
            //    mniMeetingFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMeetingItemScheduleAMeeting));
            //    Commands[MeetingCommandName.ShowMeetingItemScheduleAMeeting].AddInvoker(mniMeetingFunc, "Click");
            //    mniMeeting.DropDownItems.Add(mniMeetingFunc);
            //}

            // thống kê hội họp
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MEETING_STATISTIC))
            {
                mniMeetingFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMeetingItemStatistic));
                Commands[MeetingCommandName.ShowMeetingStatistic].AddInvoker(mniMeetingFunc, "Click");
                mniMeeting.DropDownItems.Add(mniMeetingFunc);
            }

            // thống kê chi tiết hội họp
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MEETING_STATISTIC_DETAIL))
            {
                mniMeetingFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMeetingItemStatisticDetail));
                Commands[MeetingCommandName.ShowMeetingItemStatisticDetail].AddInvoker(mniMeetingFunc, "Click");
                mniMeeting.DropDownItems.Add(mniMeetingFunc);
                isAddSeparator = true;
            }

            //thống kê liên hệ công tác
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MEETING_STATISTIC_CONTACT_WORK))// phai them vao sư dúng khong? dạ
            {
                mniMeetingFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMeetingItemStatisticContactWork)); 
                //// o day sau loi? vao sư
                Commands[MeetingCommandName.ShowMenuMeetingItemStatisticContactWork].AddInvoker(mniMeetingFunc, "Click");
                mniMeeting.DropDownItems.Add(mniMeetingFunc);
                isAddSeparator = true;
            }
            if (isAddSeparator)
            {
                separator4 = new ToolStripSeparator();
                mniMeeting.DropDownItems.Add(separator4);
                isAddSeparator = false;
            }
            //kiểm soát báo chí
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MEETING_JOURNALIST_ATTENDMEETING))
            {
                mniMeetingFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMeetingItemJournalistAttendMeeting));
                Commands[MeetingCommandName.ShowMeetingItemJournalistAttendMeeting].AddInvoker(mniMeetingFunc, "Click");
                mniMeeting.DropDownItems.Add(mniMeetingFunc);
            }
            // thống kê báo chí tham dự họp
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MEETING_JOURNALIST_STATISTIC))
            {
                mniMeetingFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMeetingItemStatisticOfJournalist));
                Commands[MeetingCommandName.ShowMeetingItemStatisticOfJournalist].AddInvoker(mniMeetingFunc, "Click");
                mniMeeting.DropDownItems.Add(mniMeetingFunc);
            }

            // thống kê chi tiết báo chí tham dự họp
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MEETING_JOURNALIST_STATISTIC_DETAIL))
            {
                mniMeetingFunc = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuMeetingItemStatisticDetailOfJournalist));
                Commands[MeetingCommandName.ShowMeetingItemStatisticDetailOfJournalist].AddInvoker(mniMeetingFunc, "Click");
                mniMeeting.DropDownItems.Add(mniMeetingFunc);
                isAddSeparator = true;
            }
            if (mniMeeting.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mniMeeting);
                UIExtensionSites.RegisterSite(MenuNames.MenuMeeting, mniMeeting);
            }
        }

        //private void mniMeeting_Clicked(object sender, EventArgs e)
        //{
        //    Form1 form1 = new Form1();
        //    SmartParts.Add(form1);
        //    form1.ShowDialog();
        //    SmartParts.Remove(form1);
        //    form1.Dispose();
        //}
    }
}
