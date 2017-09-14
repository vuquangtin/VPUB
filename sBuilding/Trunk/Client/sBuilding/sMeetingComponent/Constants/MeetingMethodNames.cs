
namespace sMeetingComponent.Constants
{
    /// <summary>
    /// link service
    /// </summary>
    public class MeetingMethodNames
    {
        //1.GET lấy danh sách các cuộc họp trong ngày
        public static string GET_MEETING_BY_DATE = @"getmeetingbydate";//yyyy-MM-dd

        //2.CHECK kiểm tra thư mời họp dựa vào barcode để lấy thông tin
        public static string CHECK_INOUT_ATTENDMEETING = @"checkinoutattendmeeting";

        //3.CHECK kiểm tra xem  thẻ quét vào hôm nay có tham dự cuộc họp nào không (cập nhật thời gian) , (xem thông tin thẻ)
        public static string CHECK_INOUT_UPDATE_ATTENDMEETING = @"checkoutjournalist";

        //  get detail infomation by barcode
        //4.GET Lấy thông tin thư mời họp dựa vào barcode
        public static string GET_DETAIL_INFO_BY_BARCODE = @"getdetailinfobybarcode";

        //5.ADD Thêm thông tin người tham dự họp
        public static string INSERT_MEETING_ATTENDMEETING = @"insertattendmeeting";

        //org
        //6:GET lấy thông tin đơn vị
        public static string GET_LISTORGANIZATIONMG = @"getallorganizationmeeting";
        //6.1 GET danh sách Org ASC sắp xếp từ a -> z
        public static string GET_LISTORGANIZATIONMG_ASC = @"getallorganizationmeetingasc";

        //get joyrnalist by cardchip
        //7.1GET Đọc thông tin của thẻ xem có thông tin hay không
        public static string GET_JOURNALIST_BY_CARDCHIP = @"getjournalist";
        public static string CHECK_IS_DATE_EXPIRATED = @"checkisdateexpirated";
        //7:GET lấy thông tin các cuộc họp hôm nay, các cuộc họp nhà báo được vào
        public static string GET_LISTMEETING_JOURNALIST_BY_SERIALNUMBER_DATETIME = @"getjournalistobjbyserialanddate";

        //8:ADD Thêm danh sách các cuộc họp người đó tham dự
        public static string INSERT_ATTENDMEETING_JOURNALIST = @"insertattendmeetingjournalistobj";

        //insert thêm người đến liên hệ
        //9:INSERT Lưu thông tin liên hệ công tác
        public static string INSERT_CONTACT_FOR_WORK = @"insertsmeetingcontact";

        //10.ADD thêm danh sách các cuộc họp người đó ĐĂNG KÝ tham dự (không có thẻ, không có thư mời)
        public static string INSERT_MEETING_ATTENDMEETING_NOT_BARCODE = @"insertattendmeetingadd";

        //DOANH NGHIỆP CHƯA SỬ DỤNG
        //thông tin barcode cho doanh nghiep
        public static string GET_DETAIL_INFO_BY_BARCODE_ENTERPRISE = @"getdetailinfobybarcodeorgother";
        public static string INSERT_MEETING_ATTENDMEETING_ENTERPRISE = @"insertattendmeetingnonresident";
        //

        //THỐNG KÊ HỘI HỌP
        //11.STATISTIC Thống kê Lấy số lượng người tham dự họp
        public static string GET_LISTATTEND_MEETING_STATISTIC_BY_DATE = @"getattendmeetingstatisticobjbydate";
        //12:STATISTIC Thống kê : LẤy thông tin chi tiết người tham dự họp
        public static string GET_ATTEND_MEETING_STATISTIC_OBJ_BY_MEETING_ID = @"getattendmeetingstatisticobjbymeetingid";
        //13:STATISTIC LẤY THÔNG TIN CHI TIẾT CUỘC HỌP và số lượng người tham dự họp
        public static string GET_LISTATTEND_MEETING_STATISTIC_BY_DATE_ORGID = @"getattendmeetingstatisticbydate";
        //14:STATISTIC Thống kê CHI TIẾT HỘI HỌP : LẤy thông tin chi tiết người tham dự họp
        public static string GET_LISTATTEND_MEETING_STATISTIC_DETAIL_BY_DATE_ORGID_MEETINGID = @"getattendmeetingstatisticdetailbyorganizationmeetingidandmeetingid";

        //THỐNG KÊ BÁO CHÍ
        //15.STATISTIC Thống kê BÁO CHÍ Lấy số lượng người tham dự họp
        public static string GET_LISTATTEND_MEETING_STATISTIC_JOURNALIST_BY_DATE = @"getjournalistattendmeetingstatisticobjbydate";
        //16:STATISTIC THống kê BÁO CHÍ : LẤy thông tin chi tiết NHÀ BÁO người tham dự họp
        public static string GET_ATTEND_MEETING_STATISTIC_OBJ_JOURNALIST_BY_MEETING_ID = @"getjournalistattendmeetingstatisticobjbymeetingid";
        //17:STATISTIC THống kê CHI TIẾT HỘI HỌP : LẤy thông tin chi tiết người tham dự họp của BÁO CHÍ
        public static string GET_LISTATTEND_MEETING_STATISTIC_DETAIL_JOURNALIST_BY_DATE_ORGID_MEETINGID = @"getjournalistattendmeetingstatisticdetailbyorganizationmeetingidandmeetingid";

        //THỐNG KÊ ĐƠN VỊ LIÊN HỆ
        //18:STATISTIC Thống kê LIÊN HỆ CÔNG TÁC Lấy số lượng người đến liên hệ
        public static string GET_STATISTIC_CONTACTWORK_BY_DATE_ORG = @"smeetingcontactstatisticbydate";
        //19:STATISTIC THống kê LIÊN HỆ CÔNG TÁC: LẤy thông tin chi tiết người đến liên hệ
        public static string GET_DETAIL_STATISTIC_CONTACTWORK_BY_DATE_ORG = @"smeetingcontactstatisticbydateandorgid";

        //DỜI LỊCH HỌP
        //20:GET QUẢN lí thông tin cuộc họp theo điều kiện lọc
        public static string GET_NON_RESIDENT_MEETING_BY_ORGANIZATION_MEETING_ID = @"getmeetingbyorganizationmeetingidandmeetingname";
        //21.GET Xem thông tin cuộc họp
        public static string GET_NON_RESIDENT_MEETING_BY_ID = "getmeetingbyid";
        //22.UPDATE Cập Nhật thời gian cuộc họp
        public static string UPDATET_MEETING = @"updatemeetingsamesnonresident";
    }
}
