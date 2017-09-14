using System;


namespace sNonResidentComponent.Constants {
    public class NonResidentMethodNames {
        //org
        //2. GET danh sách Org
        public static String GET_LISTORGANIZATIONMG = @"getallorganizationmeeting";
        //2.1 GET danh sách Org ASC sắp xếp từ a -> z
        public static String GET_LISTORGANIZATIONMG_ASC = @"getallorganizationmeetingasc";

        // 3.CHECK kiểm tra thông tin cửa thẻ khách vãng lai 
        public static String CHECK_INOUT_NONRESIDENT_BY_SERIALNUMBER = @"checkinoutnonresidentbyserialnumber";

        // 4.INSERT Lưu thông tin khách đến VPUB
        public static String INSERT_NONRESIDENT = @"insertnonresident";

        //5:GET Lấy thông tin cuộc họp khách vãng lai tham dự họp
        public static string GET_NON_RESIDENT_MEETING_BY_ID = "getnonresidentmeetingbyid";

        //6:UPDATE Cập nhật thời gian ra về
        public static String UPDATE_NONRESIDENT_BY_SERIALNUMBER_DATETIME = @"updatenonresidentbyserialnumberanddatetime";

        //7:UPDATE Cập nhật thông tin khách vãng lai
        public static String UPDATE_NONRESIDENT = @"updatenonresident";

        //THỐNG KÊ KHÁCH VÃNG LAI
        //:8 STATICTIS THỐNG KÊ số lượng khách vãng lai đến
        public static String GET_LISTNONRESIDENT_STATISTIC_BY_DATE = @"getlistnonresidentstatisticbydate";

        //9: STATICTIS : THÓNG KÊ chi tiết thông tin khách vãng lai đến
        public static String GET_LISTNONRESIDENT_BY_DATE_ORGID = @"getlistnonresidentbydateandorgid";//hien thu thông tin thống kê chi tiết khach vang lai theo ngay, orgid

        //10: STATICTIS THÔNG TIN CHI TIẾT KHÁCH VÃNG LAI
        public static String GET_LISTNONRESIDENT_BY_ORG_DATE = @"getlistnonresidentbyorgidanddate";

        //11:MANAGE Lấy thông tin khách vãng lai
        public static String GET_LISTNONRESIDENT_BY_DATE = @"getlistnonresidentbydate";//hien thu danh sach khach vang lai theo ngay

        //meeting
        //14:ADD THêm cuộc họp nội bộ
        public static string INSERT_MEETING = @"insertnonresidentmeeting";//insert cuộc họp ok
        //16:UPDATE Cập nhật thông tin cuộc họp
        public static string UPDATET_MEETING = @"updatenonresidentmeeting";
        //13 DELETE : HỦY cuộc họp
        public static string DELETE_MEETING = @"deletenonresidentmeeting";

        public static string GET_NON_RESIDENT_MEETING_BY_ORGANIZATION_ID = "getnonresidentmeetingbyorganizationmeetingid";

        //12 MANAGE : Lấy danh sách thông tin cuộc họp
        public static string GET_NON_RESIDENT_MEETING_BY_ORGANIZATION_MEETING_ID = @"getnonresidentmeetingbyorganizationmeetingidandmeetingname";//quản lí cuộc họp theo ngày, id đơn vị, tên cuộc họp

        //room
        //15:GET Lấy danh sách các phòng
        public static string GET_LISTROOM = @"getallroom";

        // NonResidentOrganization
        public static string INSERT_NON_RES_ORG = @"insertnonresorg";
        public static string UPDATE_NON_RES_ORG = @"updatenonresorg";
        public static string DELETE_NON_RES_ORG = @"deletenonresorg";
        public static string GET_NON_RES_ORG = @"getnonresorg";
        public static string GET_LIST_ALL_NON_RES_ORG = @"getlistallnonresorg";

        // NonResidentSubOrganization
        public static string INSERT_NON_RES_SUB_ORG = @"insertnonressubsorg";
        public static string UPDATE_NON_RES_SUB_ORG = @"updatenonressubsorg";
        public static string DELETE_NON_RES_SUB_ORG = @"deletenonressubsorg";
        public static string GET_NON_RES_SUB_ORG = @"getnonressubsorg";
        public static string GET_LIST_ALL_NON_RES_SUB_ORG = @"getlistallnonressubsorg";

        // NonResidentMemberMap
        public static string INSERT_NON_RES_MEMBER_MAP = @"insertnonresmemmap";
        public static string UPDATE_NON_RES_MEMBER_MAP = @"updatenonresmemmap";
        public static string DELETE_NON_RES_MEMBER_MAP = @"deletenonresmemmap";
        public static string GET_NON_RES_MEMBER_MAP = @"getnonresmemmap";
        public static string GET_LIST_ALL_NON_RES_MEMBER_MAP = @"getlistallnonresmemmap";
    }
}
