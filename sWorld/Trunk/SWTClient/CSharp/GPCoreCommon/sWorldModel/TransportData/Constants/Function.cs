using System;
using System.Collections.Generic;
using System.Linq;
using CommonHelper.Constants;

namespace sWorldModel.TransportData
{
    [Structured(100)]
    public enum Function : long
    {
        NULL = 0,

        MOD_CARD_CHIP_MGT = 100,
        FUNC_CHIP_MEMBER_PERSO_VIEW = 101,
        FUNC_CHIP_PERSO_VIEW = 102,
        FUNC_CHIP_CARD_VIEW = 103,
        FUNC_CHIP_CARD_STATISTICS_VIEW = 104,
        FUNC_CHIP_TOOLKIT_CLEAR_DATA = 105,
        FUNC_CHIP_TOOLKIT_READ_DATA = 106,
        FUNC_CHIP_TOOLKIT_UPDATE_DATA = 107,

        //MOD_CARD_MAGNETIC_MGT = 200,
        //FUNC_MAGNETIC_MEMBER_PERSO_VIEW = 201,
        //FUNC_MAGNETIC_PERSO_VIEW = 202,
        //FUNC_MAGNETIC_CARD_VIEW = 203,
        //FUNC_MAGNETIC_CARD_STATISTICS_VIEW = 204,

        MOD_MANGER_MGT = 300,
        FUNC_ORG_VIEW = 301,
        //FUNC_MASTER_OF_MASTER_VIEW = 302,
        //FUNC_ORG_ACQUIRER_VIEW = 303,
        FUNC_MEMBER_VIEW = 304,
        //FUNC_KEY_VIEW = 305,
        FUNC_TOOLKIT_WRITE_KEY_CARD = 306,
        FUNC_TOOLKIT_CLEAR_EMPTY_CARD = 307,
        FUNC_APP_VIEW = 309,
        FUNC_USER_VIEW = 310,
        FUNC_DEVICE_DOOR_MGT = 311,
        FUNC_IMPORT_CARD = 312,
        FUNC_EXPORT_CARD = 313,
        FUNC_MOVE_SUBORG_VIEW = 314,

        //MOD_ACCESS_CONTROL = 400,

        //FUNC_DOOR_STATISTICS = 402,
        //FUNC_UPDATE_MONTHLY_DEBT = 403,
        //FUNC_MANAGER_COSTSTATICS = 404,
        //FUNC_DEVICE_PERSO_MGT = 405,

        MOD_TIMEKEEPING = 500,

        FUNC_TIMEKEEPING_DEVICE_CONFIG = 501,
        FUNC_TIMEKEEPING_TIME_CONFIG = 502,
        FUNC_TIMEKEEPING_USER_TIME_CONFIG = 503,
        FUNC_USER_STATISTIC = 504,
        FUNC_MONTH_STATISTIC = 505,
        FUNC_DATE_STATISTIC = 506,
        FUNC_TIME_EVENT = 507,
        FUNC_TIMEKEEPING_HOLIDAY_CONFIG = 508,
        FUNC_TIMEKEEPING_GENERAL_CONFIG = 509,
        FUNC_TIMEKEEPING_DAY_OFF_CONFIG = 510,
        FUNC_FORM_TIMEKEEPING = 511,
        //FUNC_TIMEKEEPING = 512,
        //FUNC_TIME_MANAGER = 513,

        FUNC_MEETING = 600, //  kiêm soat hoi hop

        FUNC_MEETING_STATISTIC = 601, // thong ke hoi hop
        FUNC_MEETING_STATISTIC_DETAIL = 602, // thong ke chi tiet hoi hop
        FUNC_MEETING_SCHEDULE = 603, // doi lich hop
        FUNC_MEETING_JOURNALIST_ATTENDMEETING = 604, //kiem soat bao chi
        FUNC_MEETING_JOURNALIST_STATISTIC = 605, //thong ke bao chi tham du hop
        FUNC_MEETING_JOURNALIST_STATISTIC_DETAIL = 606, // thong ke chi tie bao chi tham du hop
        FUNC_MEETING_STATISTIC_CONTACT_WORK = 607, // thong ke lien he cong tac
        FUNC_MEETING_ITEM = 608,

        FUNC_NONRESIDENT = 700,
        FUNC_NONRESIDENT_MANAGEMEETING = 701,
        FUNC_NONRESIDENT_MANAGECARD = 702,
        FUNC_NONRESIDENT_STATISTIC = 703,
        FUNC_NONRESIDENT_STATISTIC_DETAIL = 704,
        //FUNC_NONRESIDENT_ADDMEETING = 705,
        FUNC_NONRESIDENT_ITEM = 706

    }

    public static class FunctionExtMethod
    {
        public static List<Function> GetAll()
        {
            return Enum.GetValues(typeof(Function)).Cast<Function>().ToList();
        }

        public static List<Function> GetModuleList()
        {
            Object[] attributeList = typeof(Function).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;

                List<Function> result = new List<Function>();
                Function[] functions = (Function[])Enum.GetValues(typeof(Function));
                long modIndex;

                foreach (Function f in functions)
                {
                    modIndex = (long)Convert.ChangeType(f, typeof(long));
                    if (f != Function.NULL && (modIndex % span) == 0)
                    {
                        result.Add(f);
                    }
                }
                return result;
            }
            else
            {
                return new List<Function>();
            }
        }

        public static List<Function> GetChildList(this Function parent)
        {
            List<Function> result = new List<Function>();
            Function[] functions = (Function[])Enum.GetValues(typeof(Function));
            Object[] attributeList = typeof(Function).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;
                long parentIndex, childIndex, index;

                foreach (Function f in functions)
                {
                    parentIndex = (long)Convert.ChangeType(parent, typeof(long));
                    childIndex = (long)Convert.ChangeType(f, typeof(long));
                    index = (childIndex / span) * span;
                    if (index == parentIndex && childIndex != parentIndex)
                    {
                        result.Add(f);
                    }
                }
                return result;
            }
            else
            {
                return new List<Function>();
            }
        }

        public static bool IsChildOf(this Function child, Function parent)
        {
            Object[] attributeList = typeof(Function).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;
                long parentIndex = (long)Convert.ChangeType(parent, typeof(long));
                long childIndex = (long)Convert.ChangeType(child, typeof(long));
                long index = (childIndex / span) * span;
                bool res = index == parentIndex && childIndex != parentIndex;
                return res;
            }

            return false;
        }

        public static bool IsParentOf(this Function parent, Function child)
        {
            return child.IsChildOf(parent);
        }

        public static Function GetParent(this Function child)
        {
            Object[] attributeList = typeof(Function).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;
                long childIndex = (long)Convert.ChangeType(child, typeof(long));
                long index = childIndex / span;
                long parentIndex = index * span;
                if (parentIndex == childIndex)
                {
                    return Function.NULL;
                }
                return (Function)(index * span);
            }
            return Function.NULL;
        }

        public static string GetName(this Function function)
        {
            switch (function)
            {
                case Function.MOD_CARD_CHIP_MGT:
                    return MenuNames.MenuCardChip;
                case Function.FUNC_CHIP_MEMBER_PERSO_VIEW:
                    return MenuNames.MenuCardPerso;
                case Function.FUNC_CHIP_PERSO_VIEW:
                    return MenuNames.MenuCardPersoManager;
                case Function.FUNC_CHIP_CARD_VIEW:
                    return MenuNames.MenuCardManager;
                case Function.FUNC_CHIP_CARD_STATISTICS_VIEW:
                    return MenuNames.MenuCardStatistics;

                case Function.FUNC_CHIP_TOOLKIT_READ_DATA:
                    return MenuNames.MenuReadCard;
                case Function.FUNC_CHIP_TOOLKIT_UPDATE_DATA:
                    return MenuNames.MenuUpdateCard;
                case Function.FUNC_CHIP_TOOLKIT_CLEAR_DATA:
                    return MenuNames.MenuClearCard;


                //case Function.FUNC_CHIP_TOOLKIT_CLEAR_DATA:
                //    return MenuNames.MenuReadCard;
                //case Function.FUNC_CHIP_TOOLKIT_READ_DATA:
                //    return MenuNames.MenuUpdateCard;
                //case Function.FUNC_CHIP_TOOLKIT_UPDATE_DATA:
                //    return MenuNames.MenuClearCard;


                //case Function.MOD_CARD_MAGNETIC_MGT:
                //    return MenuNames.MenuCardMagnetic;
                //case Function.FUNC_MAGNETIC_MEMBER_PERSO_VIEW:
                //    return MenuNames.MenuCardPerso;
                //case Function.FUNC_MAGNETIC_PERSO_VIEW:
                //    return MenuNames.MenuCardPersoManager;
                //case Function.FUNC_MAGNETIC_CARD_VIEW:
                //    return MenuNames.MenuCardManager;
                //case Function.FUNC_MAGNETIC_CARD_STATISTICS_VIEW:
                //    return MenuNames.MenuCardStatistics;

                case Function.MOD_MANGER_MGT:
                    return MenuNames.MenuManager;
                case Function.FUNC_ORG_VIEW:
                    return MenuNames.MenuOrgManager;
                //case Function.FUNC_MASTER_OF_MASTER_VIEW:
                //    return MenuNames.MenuPartnerOfMasterManager;
                //case Function.FUNC_ORG_ACQUIRER_VIEW:
                //    return MenuNames.MenuOrgAcquirerManager;
                case Function.FUNC_MEMBER_VIEW:
                    return MenuNames.MenuMemberManager;
                //case Function.FUNC_KEY_VIEW:
                //    return MenuNames.MenuKeyManager;
                case Function.FUNC_TOOLKIT_WRITE_KEY_CARD:
                    return MenuNames.MenuWirteKey;
                case Function.FUNC_TOOLKIT_CLEAR_EMPTY_CARD:
                    return MenuNames.MenuClearEmptyCard;
                case Function.FUNC_APP_VIEW:
                    return MenuNames.MenuAppManager;
                case Function.FUNC_USER_VIEW:
                    return MenuNames.MenuUserManager;
                case Function.FUNC_DEVICE_DOOR_MGT:
                    return MenuNames.MenuDeviceDoorManager;
                case Function.FUNC_IMPORT_CARD:
                    return MenuNames.MenuImportCardFromExcel;
                case Function.FUNC_EXPORT_CARD:
                    return MenuNames.MenuExportCard;

                //case Function.MOD_ACCESS_CONTROL:
                //    return MenuNames.MenuAccess;
                //case Function.FUNC_DEVICE_DOOR_MGT:
                //    return MenuNames.MenuDeviceDoorManager;
                //case Function.FUNC_DOOR_STATISTICS:
                //    return MenuNames.MenuDoorInStatistics;
                //case Function.FUNC_UPDATE_MONTHLY_DEBT:
                //    return MenuNames.MenuManagerCostStatistics;
                //case Function.FUNC_MANAGER_COSTSTATICS:
                //    return MenuNames.MenuAccessConfig;
                //case Function.FUNC_DEVICE_PERSO_MGT:
                //    return MenuNames.MenuDevicePersoMgt;

                case Function.MOD_TIMEKEEPING:
                    return MenuNames.MenuTimeKeeping;
                case Function.FUNC_TIMEKEEPING_DEVICE_CONFIG:
                    return MenuNames.MenuDeviceConfig;
                case Function.FUNC_TIMEKEEPING_TIME_CONFIG:
                    return MenuNames.MenuTimeConfig;
                case Function.FUNC_TIMEKEEPING_USER_TIME_CONFIG:
                    return MenuNames.MenuUserTimeConfig;
                case Function.FUNC_TIME_EVENT:
                    return MenuNames.MenuTimeEvent;
                case Function.FUNC_USER_STATISTIC:
                    return MenuNames.MenuUserStatistic;
                case Function.FUNC_MONTH_STATISTIC:
                    return MenuNames.MenuMonthStatistic;
                case Function.FUNC_DATE_STATISTIC:
                    return MenuNames.MenuDateStatistic;
                case Function.FUNC_TIMEKEEPING_HOLIDAY_CONFIG:
                    return MenuNames.MenuHolidayConfig;
                case Function.FUNC_TIMEKEEPING_GENERAL_CONFIG:
                    return MenuNames.MenuGeneralConfig;
                case Function.FUNC_TIMEKEEPING_DAY_OFF_CONFIG:
                    return MenuNames.MenuDayOffConfig;
                case Function.FUNC_FORM_TIMEKEEPING:
                    return MenuNames.MenuFormTimeKeeping;

                case Function.FUNC_MEETING:
                    return MenuNames.MenuMeeting;
                case Function.FUNC_MEETING_SCHEDULE:
                    return MenuNames.MenuMeetingItemScheduleAMeeting;
                case Function.FUNC_MEETING_STATISTIC:
                    return MenuNames.MenuMeetingItemStatistic;
                case Function.FUNC_MEETING_STATISTIC_DETAIL:
                    return MenuNames.MenuMeetingItemStatisticDetail;
                case Function.FUNC_MEETING_JOURNALIST_ATTENDMEETING:
                    return MenuNames.MenuMeetingItemJournalistAttendMeeting;
                case Function.FUNC_MEETING_JOURNALIST_STATISTIC:
                    return MenuNames.MenuMeetingItemStatisticOfJournalist;
                case Function.FUNC_MEETING_JOURNALIST_STATISTIC_DETAIL:
                    return MenuNames.MenuMeetingItemStatisticDetailOfJournalist;
                case Function.FUNC_MEETING_ITEM:
                    return MenuNames.MenuMeetingItem;
                case Function.FUNC_MEETING_STATISTIC_CONTACT_WORK:
                    return MenuNames.MenuMeetingItemStatisticContactWork;

                case Function.FUNC_NONRESIDENT:
                    return MenuNames.MenuNonResident;
                case Function.FUNC_NONRESIDENT_ITEM:
                    return MenuNames.MenuNonResidentItem;
                case Function.FUNC_NONRESIDENT_MANAGECARD:
                    return MenuNames.MenuManageCardNonResidentItem;
                case Function.FUNC_NONRESIDENT_STATISTIC:
                    return MenuNames.MenuNonResidentStatisticItem;
                case Function.FUNC_NONRESIDENT_STATISTIC_DETAIL:
                    return MenuNames.MenuNonResidentStatisticDetailItem;
                //case Function.FUNC_NONRESIDENT_ADDMEETING:
                //    return MenuNames.MenuAddMeetingItem;
                case Function.FUNC_NONRESIDENT_MANAGEMEETING:
                    return MenuNames.MenuManageMeetingItem;

                default:
                    return "N/A";
            }
        }

        public static string GetDescription(this Function function)
        {
            switch (function)
            {
                case Function.MOD_CARD_CHIP_MGT:
                    return "Quản lý thẻ chíp.";
                case Function.FUNC_CHIP_MEMBER_PERSO_VIEW:
                    return "Chức năng này cho phép người dùng phát hành thẻ chíp cho thành viên.";
                case Function.FUNC_CHIP_PERSO_VIEW:
                    return "Chức năng này cho phép người dùng xem danh sách tổng quát tất cả lượt phát hành, lẫn thông tin chi tiết của một lượt phát hành bất kỳ.";
                case Function.FUNC_CHIP_CARD_VIEW:
                    return "Quản lý các thẻ chíp đã nhập vào hệ thống.";
                case Function.FUNC_CHIP_CARD_STATISTICS_VIEW:
                    return "Chức năng này cho phép người dùng xem thống kê phát hành thẻ chíp.";
                case Function.FUNC_CHIP_TOOLKIT_READ_DATA:
                    return "Chức năng này cho phép người dùng đọc thông tin thành viên được lưu trên thẻ chíp.";
                case Function.FUNC_CHIP_TOOLKIT_UPDATE_DATA:
                    return "Chức năng này cho phép người dùng đồng bộ dữ liệu hiện có trên thẻ với dữ liệu trong hệ thống.";
                case Function.FUNC_CHIP_TOOLKIT_CLEAR_DATA:
                    return "Chức năng này cho phép người dùng xóa toàn bộ dữ liệu phát hành trên thẻ chíp.";

                //case Function.FUNC_CHIP_TOOLKIT_CLEAR_DATA:
                //    return "Chức năng này cho phép người dùng xóa toàn bộ dữ liệu phát hành trên thẻ chíp.";
                //case Function.FUNC_CHIP_TOOLKIT_READ_DATA:
                //    return "Chức năng này cho phép người dùng đọc thông tin thành viên được lưu trên thẻ chíp.";
                //case Function.FUNC_CHIP_TOOLKIT_UPDATE_DATA:
                //    return "Chức năng này cho phép người dùng đồng bộ dữ liệu hiện có trên thẻ với dữ liệu trong hệ thống.";
                //case Function.MOD_CARD_MAGNETIC_MGT:
                //    return "Quản lý thẻ từ.";
                //case Function.FUNC_MAGNETIC_MEMBER_PERSO_VIEW:
                //    return "Chức năng này cho phép người dùng phát hành thẻ từ cho thành viên.";
                //case Function.FUNC_MAGNETIC_PERSO_VIEW:
                //    return "Chức năng này cho phép người dùng xem danh sách tổng quát tất cả lượt phát hành, lẫn thông tin chi tiết của một lượt phát hành bất kỳ.";
                //case Function.FUNC_MAGNETIC_CARD_VIEW:
                //    return "Quản lý các thẻ từ đã nhập vào hệ thống.";
                //case Function.FUNC_MAGNETIC_CARD_STATISTICS_VIEW:
                //    return "Chức năng này cho phép người dùng xem thống kê phát hành thẻ từ.";

                case Function.MOD_MANGER_MGT:
                    return "Quản lý.";
                case Function.FUNC_ORG_VIEW:
                    return "Chức năng này cho phép người dùng thực hiện các thao tác thêm, sửa, xóa thông tin tổ chức và tố chức con.";
                //case Function.FUNC_MASTER_OF_MASTER_VIEW:
                //    return "Chức năng này cho phép người dùng chọn tổ chức phát hành và tổ chức đồng phát hành thẻ.";
                //case Function.FUNC_ORG_ACQUIRER_VIEW:
                //    return "Chức năng này cho phép người dùng chọn tổ chức phát hành và tổ chức đồng chấp nhận thẻ.";
                case Function.FUNC_MEMBER_VIEW:
                    return "Chức năng này cho phép người dùng thực hiện các thao tác thêm, sửa, xóa thông tin thành viên.";
                //case Function.FUNC_KEY_VIEW:
                //    return "Chức năng này cho phép người dùng thực hiện các thao tác thêm, sửa, xóa thông tin khóa.";
                case Function.FUNC_TOOLKIT_WRITE_KEY_CARD:
                    return "Chức năng này cho phép người dùng thực hiện nhập khóa vào thẻ và cập nhật vào hệ thống.";
                case Function.FUNC_TOOLKIT_CLEAR_EMPTY_CARD:
                    return "Chức năng này cho phép người dùng thực hiện xóa trắng thẻ.";
                case Function.FUNC_APP_VIEW:
                    return "Chức năng này cho phép người dùng thực hiện các thao tác thêm, sửa, xóa thông tin ứng dụng.";
                case Function.FUNC_USER_VIEW:
                    return "Chức năng này cho phép người dùng thực hiện các thao tác thêm, sửa, xóa thông tin tài khoản, cập nhật trạng thái của tài khoản.";
                case Function.FUNC_DEVICE_DOOR_MGT:
                    return "Chức năng này cho phép người dùng quản lý các thiết bị trong hệ thống";
                case Function.FUNC_IMPORT_CARD:
                    return "Chức năng này cho phép người dùng nhập dữ liệu thẻ từ hệ thống";
                case Function.FUNC_EXPORT_CARD:
                    return "Chức năng này cho phép người dùng xuất dữ liệu thẻ ra file excel";

                //case Function.MOD_ACCESS_CONTROL:
                //    return "Vào/Ra cửa";
                //case Function.FUNC_DEVICE_DOOR_MGT:
                //    return "Chức năng này cho phép người dùng thực hiện các thao tác thêm, sửa, xóa thông tin thiết bị vào/ra cửa.";
                //case Function.FUNC_DOOR_STATISTICS:
                //    return "Chức năng này cho phép người dùng xem thống kê vào/ra cửa";
                //case Function.FUNC_UPDATE_MONTHLY_DEBT:
                //    return "Chức năng này dùng để cập nhật số ngày nợ quá hạn vào hệ thống";
                //case Function.FUNC_MANAGER_COSTSTATICS:
                //    return "Chức năng này cho phép người dùng xem lịch sử cập nhật nợ phí quản lý và tiền nước.";
                //case Function.FUNC_DEVICE_PERSO_MGT:
                //    return "Chức năng này dùng để cấp phát quyền truy cập vào các khu vực trong hệ thống";

                case Function.MOD_TIMEKEEPING:
                    return "Chấm công";
                case Function.FUNC_TIMEKEEPING_DEVICE_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình thiết bị chấm công";
                case Function.FUNC_TIMEKEEPING_TIME_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình thời gian chấm công";
                case Function.FUNC_TIMEKEEPING_USER_TIME_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình thời gian chấm công cho từng người";
                case Function.FUNC_TIME_EVENT:
                    return "Chức năng này cho phép người dùng cấu hình sự kiện";
                case Function.FUNC_USER_STATISTIC:
                    return "Chức năng này cho phép người dùng thống kê chấm công theo cá nhân";
                case Function.FUNC_MONTH_STATISTIC:
                    return "Chức năng này cho phép người dùng thống kê chấm công theo tháng";
                case Function.FUNC_DATE_STATISTIC:
                    return "Chức năng này cho phép người dùng thống kê chấm công theo ngày";
                case Function.FUNC_TIMEKEEPING_HOLIDAY_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình ngày lễ";
                case Function.FUNC_TIMEKEEPING_GENERAL_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình chung";
                case Function.FUNC_TIMEKEEPING_DAY_OFF_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình ngày nghỉ";
                case Function.FUNC_FORM_TIMEKEEPING:
                    return "Chức năng này cho phép người dùng chấm công khi quên thẻ";

                case Function.FUNC_MEETING:
                    return "Quản lý hội họp";
                case Function.FUNC_MEETING_ITEM:
                    return "Chức năng này cho phép người dùng kiểm soát hội họp";
                case Function.FUNC_MEETING_SCHEDULE:
                    return "Chức năng này cho phép người dùng dời lịch họp";
                case Function.FUNC_MEETING_STATISTIC:
                    return "Chức năng này cho phép người dùng thống kê hội họp";
                case Function.FUNC_MEETING_STATISTIC_DETAIL:
                    return "Chức năng này cho phép người dùng thống kê chi tiết hội họp";
                case Function.FUNC_MEETING_JOURNALIST_ATTENDMEETING:
                    return "Chức năng này cho phép người dùng kiểm soát báo chí";
                case Function.FUNC_MEETING_JOURNALIST_STATISTIC:
                    return "Chức năng này cho phép người dùng thống kê báo chí tham dự họp";
                case Function.FUNC_MEETING_JOURNALIST_STATISTIC_DETAIL:
                    return "Chức năng này cho phép người dùng thống kê chi tiết báo chí tham dự họp";
                case Function.FUNC_MEETING_STATISTIC_CONTACT_WORK:
                    return "Chức năng này cho phép người dùng thống kê liên hệ công tác";

                case Function.FUNC_NONRESIDENT:
                    return "Quản lý Khách vãng lai";
                case Function.FUNC_NONRESIDENT_ITEM:
                    return "Chức năng này cho phép người dùng kiểm tra khách vãng lai";
                case Function.FUNC_NONRESIDENT_MANAGECARD:
                    return "Chức năng này cho phép người quản lí phát hành thẻ khách vãng lai";
                case Function.FUNC_NONRESIDENT_STATISTIC:
                    return "Chức năng này cho phép người dùng thống kê khách vãng lai";
                case Function.FUNC_NONRESIDENT_STATISTIC_DETAIL:
                    return "Chức năng này cho phép người dùng thống kê chi tiết khách vãng lai";
                //case Function.FUNC_NONRESIDENT_ADDMEETING:
                //    return "Chức năng này cho phép người dùng thêm cuộc họp";
                case Function.FUNC_NONRESIDENT_MANAGEMEETING:
                    return "Chức năng này cho phép người dùng quản lí cuộc họp";

                default:
                    return "N/A";
            }
        }

        public static Function ToFunction(long longValue)
        {
            return (Function)longValue;
        }
    }

    [AttributeUsage(AttributeTargets.Enum)]
    public class StructuredAttribute : Attribute
    {
        public long span;

        public long Span
        {
            get { return span; }
            set { span = value; }
        }

        public StructuredAttribute(long span)
        {
            this.span = span;
        }
    }
}
