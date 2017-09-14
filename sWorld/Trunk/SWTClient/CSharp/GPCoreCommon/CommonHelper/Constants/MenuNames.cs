using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonHelper.Constants
{
    public class MenuNames
    {
        public static readonly String MenuHome = @"MenuHome";//@"Hệ thống";
        public static readonly String MenuChangePassword = @"MenuChangePassword";//@"Đổi mật khẩu";
        public static readonly String MenuUpdateUser = @"MenuUpdateUser";//@"Cập nhật thông tin cá nhân";
        public static readonly String MenuLogout = @"MenuLogout";//@"Đăng xuất";
        public static readonly String MenuExit = @"MenuExit";//@"Thoát";


        public static readonly String MenuManager = @"MenuManager";//@"Quản lý";
        public static readonly String MenuOrgManager = @"MenuOrgManager";//@"Tổ chức";
        public static readonly String MenuPartnerOfMasterManager = @"MenuPartnerOfMasterManager";//@"Tổ chức liên kết phát hành thẻ";
        public static readonly String MenuOrgAcquirerManager = @"MenuOrgAcquirerManager";//@"Tổ chức chấp nhận thẻ";
        public static readonly String MenuMemberManager = @"MenuMemberManager";//@"Thành viên";
        public static readonly String MenuKeyManager = @"MenuKeyManager";//@"Khóa";
        public static readonly String MenuWirteKey = @"MenuWirteKey";//@"Cài khóa và Nhập thẻ...";
        public static readonly String MenuClearEmptyCard = @"MenuClearEmptyCard";//@"Xóa trắng thẻ...";
        public static readonly String MenuAppManager = @"MenuAppManager";//@"Ứng dụng trên thẻ";
        public static readonly String MenuUserManager = @"MenuUserManager";//@"Nhóm - tài khoản";
        public static readonly String MenuMoveSubOrg = @"MenuMoveSubOrg";//@"Chuyển phòng ban";

        public static readonly String MenuImportCardFromExcel = @"MenuImportCardFromExcel";//@"Nhập thông tin thẻ";
        public static readonly String MenuExportCard = @"MenuExportCard";//@"Xuất dữ liệu thẻ";

        public static readonly String MenuCardChip = @"MenuCardChip";//@"Thẻ chíp";
        public static readonly String MenuCardPerso = @"MenuCardPerso";//@"Cấp phát thẻ";
        public static readonly String MenuCardPersoManager = @"MenuCardPersoManager";//@"Quản lý phát hành";
        public static readonly String MenuCardManager = @"MenuCardManager";//@"Quản lý thẻ";
        public static readonly String MenuCardStatistics = @"MenuCardStatistics";//@"Thống kê thẻ";
        public static readonly String MenuReadCard = @"MenuReadCard";//@"Đọc dữ liệu thẻ...";
        public static readonly String MenuUpdateCard = @"MenuUpdateCard";//@"Đồng bộ dữ liệu thẻ...";
        public static readonly String MenuClearCard = @"MenuClearCard";//@"Xóa dữ liệu thẻ...";

        public static readonly String MenuCardMagnetic = @"MenuCardMagnetic";//@"Thẻ từ";

        public static readonly String MenuAttendance = @"MenuAttendance";//@"Quét thẻ vào/ra";
        public static readonly String MenuRelatives = @"MenuRelatives";//@"Người liên hệ";
        public static readonly String MenuAttendanceHistory = @"MenuAttendanceHistory";//@"Thống kê quét thẻ vào/ra";

        public static readonly String MenuSupport = @"MenuSupport";//@"Trợ giúp";
        public static readonly String MenuSystemInfo = @"MenuSystemInfo";//@"Thông tin chương trình";
        public static readonly String MenuManual = @"MenuManual";//@"Hướng dẫn sử dụng";

        public static readonly String MenuUtilities = @"MenuUtilities";//@"Tiện ích";

        public static readonly String MenuVoucherCard = @"MenuVoucherCard";//@"Quản lý phiếu";
        public static readonly String MenuVoucherCardCreateRule = @"MenuVoucherCardCreateRule";//@"Tạo phiếu";
        public static readonly String MenuVoucherCardConfigRule = @"MenuVoucherCardConfigRule";//@"Cấu hình phiếu";        

        public static readonly String MeneCash = @"MeneCash";//@"Nap tru tien";
        public static readonly String MenuEcashConfig = @"MenuEcashConfig";//@"Cấu hình giao dich"; 
        public static readonly String MenuEcashGroupItem = @"MenuEcashGroupItem";//@"Nhóm theo danh muc";
        public static readonly String MenuEcashTopUp = @"MenuEcashTopUp";//@"Nạp tiền"; 
        public static readonly String MenuEcashDeDuct = @"MenuEcashDeDuct";//@"Trừ tiền"; 
        public static readonly String CloseEcashDeDuct = @"CloseEcashDeDuct";//@"rừ tiền";
        public static readonly String MenuPayIn = @"MenuPayIn";//@"Nạp Tiền cho thẻ";
        public static readonly String MenuPayOut = @"MenuPayOut";//@"Trừ Tiền trong thẻ";
        public static readonly String MenuEcashStatisticTopUp = @"MenuEcashStatisticTopUp";//@"Thống kê nạp tiền"; 
        public static readonly String MenuEcashStatisticDeduct = @"MenuEcashStatisticDeduct";//@"Thống kê trừ tiền";
        //sai gon pearl
        public static readonly String MenuAccess = @"MenuAccess";//@"Quản Lý chung cư";
        public static readonly String MenuDeviceDoorManager = @"MenuDeviceDoorManager";//@"Thông tin thiết bị vào/ra"; 
        public static readonly String MenuDoorInStatistics = @"MenuDoorInStatistics";//@"Thống kê vào/ra cửa"
        public static readonly String MenuManagerCostStatistics = @"MenuManagerCostStatistics";//@"Lịch sử cập nhật nợ phí"
        public static readonly String MenuDevicePersoMgt = @"MenuDevicePersoManager";//@"Cấp phát thẻ cho thiết bị"

        public static readonly String MenuImportExcelApartent = @"ImportExcelApartent";//@"Cấu hình";
        public static readonly String MenuAccessConfig = @"MenuAccessConfig";//@"Cấu hình"
        //
        public static readonly String MenuTimeKeeping = @"MenuTimeKeeping";//@"Chấm công"
        public static readonly String MenuTimeLogging = @"MenuTimeLogging";//@"Nhật ký vảo/ra cửa"
        public static readonly String MenuTimeManager = @"MenuTimeManager";//@"Quản lý thời gian"

        // menu name cho sTimekeeping
        public static readonly String MenuDeviceConfig = @"MenuDeviceConfig";//@"Cấu hình thiết bị chấm công"
        public static readonly String MenuTimeConfig = @"MenuTimeConfig";//@"Cấu hình thời gian chấm công"
        public static readonly String MenuUserTimeConfig = @"MenuUserTimeConfig";//@"Cấu hình thời gian chấm công cho từng người"
        public static readonly String MenuHolidayConfig = @"MenuHolidayConfig";//@"Cấu hình ngày lễ"
        public static readonly String MenuGeneralConfig = @"MenuGeneralConfig";//@"Cấu hình chung"
        public static readonly String MenuDayOffConfig = @"MenuDayOffConfig";//@"Cấu hình ngày nghỉ"
        public static readonly String MenuTimeEvent = @"MenuTimeEvent";//@"Cấu hình sự kiện"
        public static readonly String MenuMonthStatistic = @"MenuMonthStatistic";//@"Thống kê chấm công theo tháng"
        public static readonly String MenuUserStatistic = @"MenuUserStatistic";//@"Thống kê chấm công theo cá nhân"
        public static readonly String MenuDateStatistic = @"MenuDateStatistic";//@"Thống kê chấm công theo ngày"
        public static readonly String MenuFormTimeKeeping = @"MenuFormTimeKeeping";//@"Form Time Keeping"

        // menu name cho NonResident
        public static readonly String MenuNonResident = @"MenuNonResident";//@"Quản lý Khách vãng lai"
        public static readonly String MenuNonResidentItem = @"MenuNonResidentItem";// @"Kiểm soát khách vãng lai"
        public static readonly String MenuManageCardNonResidentItem = @"MenuManageCardNonResidentItem";// @"Quản lí phát hành thẻ khách vãng lai"
        //public static readonly String MenuAddMeetingItem = @"MenuAddMeetingItem";// @"Thêm cuộc họp"
        public static readonly String MenuManageMeetingItem = @"MenuManageMeetingItem";// @"Quản lí cuộc họp"
        public static readonly String MenuNonResidentStatisticItem = @"MenuNonResidentStatisticItem";//@"Thống kê khách vãng lai"
        public static readonly String MenuNonResidentStatisticDetailItem = @"MenuNonResidentStatisticDetailItem";//@"Thống kê chi tiết khách vãng lai"

        // menu name cho sMeeting
        public static readonly string MenuMeeting = @"MenuMeeting";//@"Quản lí hội họp"
        public static readonly string MenuMeetingItem = @"MenuMeetingItem";// @"Kiểm soát hội họp"
        public static readonly string MenuMeetingItemStatistic = @"MenuMeetingItemStatistic";//@"Thống kê hội họp"
        public static readonly string MenuMeetingItemStatisticDetail = @"MenuMeetingItemStatisticDetail";//@"Thống kê chi tiết hội họp"
        public static readonly string MenuMeetingItemScheduleAMeeting = @"MenuMeetingItemScheduleAMeeting";//@"Dời lịch họp"
        public static readonly string MenuMeetingItemStatisticContactWork = @"MenuMeetingItemStatisticContactWork";// Thong ke lien he cong tac

        public static readonly string MenuMeetingItemJournalistAttendMeeting = @"MenuMeetingItemJournalistAttendMeeting";//Kiểm soát báo chí
        public static readonly string MenuMeetingItemStatisticOfJournalist = @"MenuMeetingItemStatisticOfJournalist";//Thống kê báo chí tham dự họp
        public static readonly string MenuMeetingItemStatisticDetailOfJournalist = @"MenuMeetingItemStatisticDetailOfJournalist";//Thống kê chi tiết báo chí tham dự họp
    }


}
