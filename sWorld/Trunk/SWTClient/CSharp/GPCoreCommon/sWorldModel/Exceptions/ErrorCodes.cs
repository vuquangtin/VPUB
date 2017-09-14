namespace sWorldModel.Exceptions
{
    /// <summary>
    /// Danh sách các mã lỗi mà server có thể trả về. Mã lỗi gồm 4 ký tự số
    /// bao gồm: 2 ký tự đầu đại diện cho module, 2 ký tự sau đại diện cho
    /// lỗi xảy ra trong phạm vi module đó. Cụ thể:
    /// <list type="bullte">
    ///     <item>
    ///         <description>
    ///         Từ 1000 - 1099: các lỗi chung
    ///         </description>
    ///     </item>
    ///     <item>
    ///         <description>
    ///         Từ 1100 - 1199: các lỗi liên quan đến quản lý người dùng
    ///         </description>
    ///     </item>
    ///     <item>
    ///         <description>
    ///         Từ 1200 - 1299: các lỗi liên quan đến phát hành thẻ
    ///         </description>
    ///     </item>
    /// </list>
    /// </summary>
    public static class ErrorCodes
    {
        #region Common errors

        public const int OPERATION_SUCCESS = 1000;
        public const int UNKNOWN_ERROR = 1001;
        public const int METHOD_NOT_SUPPORTED = 1002;

        public const int RECORD_NOT_FOUND = 1010;
        public const int RECORD_ALREADY_EXISTS = 1011;
        public const int MODIFY_INTEGRATED_DATA = 1012;
        public const int UPDATE_RECORD_FOUND = 1013;

        public const int NULL_ARGUMENT = 1020;
        public const int INVALID_ARGUMENT = 1021;

        public const int OPTIMISTIC_CONCURRENCY = 1030;

        #endregion

        #region User management

        public const int SESSION_EXPIRED = 1100;
        public const int LOGIN_FAILED = 1101;
        public const int NOT_HAVE_PERMISSION = 1102;
        public const int SESSION_NOT_FOUND = 1103;

        public const int USER_LOCKED = 1110;
        public const int USER_CANCELED = 1111;
        public const int USER_NOT_LOCKED = 1112;
        public const int USER_NOT_FOUND = 1113;
        public const int GROUP_NOT_FOUND = 1114;
        public const int FUNCTION_NOT_FOUND = 1115;
        public const int UPDATE_ROOT_USER = 1116;
        public const int GROUP_CANCELED = 1117;

        public const int PASSWORD_TOO_SHORT = 1120;
        public const int PASSWORD_TOO_LONG = 1121;
        public const int PASSWORD_TOO_WEAK = 1122;
        public const int USERNAME_TAKEN = 1123;
        public const int USERNAME_TOO_SHORT = 1124;
        public const int USERNAME_TOO_LONG = 1125;
        public const int PASSWORD_NOT_MATCH = 1126;
        public const int GROUPNAME_TAKEN = 1127;
        public const int GROUPNAME_INVALID = 1128;

        #endregion

        #region Perso management

        public const int CARD_LOST = 1201;
        public const int CARD_BROKEN = 1202;
        public const int CARD_NOT_FOUND = 1203;
        public const int CARD_PERSONALIZED = 1204;
        public const int CARD_NOT_LOST = 1206;
        public const int CARD_NOT_BROKEN = 1207;
        public const int CARD_NOT_PERSONALIZED = 1208;
        public const int CARD_ALREADY_EXISTS = 1211;
        public const int CARD_TYPE_UNSUPPORTED = 1212;

        public const int PERSO_UNREGISTERED = 1220;
        public const int PERSO_LOCKED = 1221;
        public const int PERSO_CANCELED = 1222;
        public const int PERSO_NOT_FOUND = 1223;
        public const int PERSO_NOT_LOCKED = 1224;
        public const int PERSO_NOT_CANCELED = 1225;
        public const int PERSO_REGISTERED = 1226;
        public const int TEACHER_PROFILE_APP_NOT_PRESENT = 1227;
        public const int PERSO_EXPIRED = 1228;
        public const int PERSO_NOT_EXPIRED = 1229;
        public const int PERSO_NOT_EXTENDED = 1230;
        public const int INVALID_EXPIRATION_DATE = 1231;

        public const int MEMBER_NOT_FOUND = 1240;
        public const int MEMBER_PERSONALIZED = 1241;
        public const int FACULTY_NOT_FOUND = 1242;
        public const int DEPARTMENT_NOT_FOUND = 1243;
        public const int MEMBER_NOT_WORKING = 1244;
        public const int MEMBER_WORKING_ABROAD = 1245;
        public const int MEMBER_CONTRACT_END = 1246;

        #endregion

        #region CardApp management

        public const int KEY_NOT_FOUND = 1300;
        public const int KEY_LENGTH_INVALID = 1301;
        public const int MAXIMUM_KEY_REACH = 1302;

        public const int APP_NOT_FOUND = 1310;
        public const int INVALID_START_SECTOR = 1311;
        public const int NOT_ENOUGH_SECTOR_FOR_APP_REGISTRATION = 1312;

        #endregion

        #region SMS Gaywate

        public const int OUT_OF_QUOTA = -3;
        public const int NOT_ENOUGH_PARAMS = -4;
        public const int RECIPIENT_INVALID = -5;
        public const int MESSAGE_IS_NULL = -6;
        public const int BRANDNAME_IS_NULL = -7;
        public const int IP_ADDRESS_INVALID = -8;
        public const int BRANDNAME_NOT_REGISTER = -9;
        public const int RECIPIENT_NOT_RECEIVER_SMS_MESSAGE = -10;
        public const int USES_POSTPAID = -11;
        public const int BRANDNAME_HAS_EXISTED_IN_SYSTEM = -12;
        public const int IP_HAS_EXISTED_IN_SYSTEM = -13;
        public const int OUT_OF_LENGHT_MESSAGE = -14;
        public const int NOT_SUPPORT_TELCOS = -15;
        public const int AUTHENTICATION_FAILD = -17;
        public const int BRANDNAME_EXISTED = -20;
        public const int OUT_OF_LIMIT_RECIPIENT = -21;

        #endregion

        public static string GetErrorMessage(int errorCode)
        {
            switch(errorCode)
            {
                case OPERATION_SUCCESS:
                    return "Thành công";
                case UNKNOWN_ERROR:
                    return "Lỗi không xác định được nguyên nhân";
                case METHOD_NOT_SUPPORTED:
                    return "Phương thức chưa được hỗ trợ";
                case RECORD_NOT_FOUND:
                    return "Dữ liệu không tồn tại trong hệ thống";
                case RECORD_ALREADY_EXISTS:
                    return "Dữ liệu đã tồn tại trong hệ thống";
                case MODIFY_INTEGRATED_DATA:
                    return "Không được phép thay đổi dữ liệu tích hợp từ database của nhà trường";
                case NULL_ARGUMENT:
                    return "Dữ liệu đầu vào không được phép rỗng";
                case INVALID_ARGUMENT:
                    return "Dữ liệu đầu vào không hợp lệ";
                case OPTIMISTIC_CONCURRENCY:
                    return "Phiên bản dữ liệu không đồng bộ";
                case UPDATE_RECORD_FOUND:
                    return "Cập nhật dữ liệu không thành công";
                    

                case SESSION_EXPIRED:
                    return "Phiên làm việc đã hết hạn, hãy đăng nhập lại";
                case LOGIN_FAILED:
                    return "Đăng nhập thất bại";
                case NOT_HAVE_PERMISSION:
                    return "Bạn không có quyền thực hiện chức năng này";
                case SESSION_NOT_FOUND:
                    return "Không tìm thấy phiên làm việc, hãy đăng nhập lại";
                case USER_LOCKED:
                    return "Tài khoản đã bị khóa";
                case USER_CANCELED:
                    return "Tài khoản đã bị hủy";
                case USER_NOT_LOCKED:
                    return "Tài khoản chưa bị khóa";
                case USER_NOT_FOUND:
                    return "Tài khoản không tồn tại trong hệ thống";
                case GROUP_NOT_FOUND:
                    return "Nhóm không tồn tại trong hệ thống";
                case FUNCTION_NOT_FOUND:
                    return "Chức năng không tồn tại trong hệ thống";
                case UPDATE_ROOT_USER:
                    return "Không được phép cập nhật tài khoản có quyền cao nhất";
                case GROUP_CANCELED:
                    return "Nhóm đã bị hủy";

                case PASSWORD_TOO_SHORT:
                    return "Mật khẩu quá ngắn";
                case PASSWORD_TOO_LONG:
                    return "Mật khẩu quá dài";
                case PASSWORD_TOO_WEAK:
                    return "Mật khẩu quá yếu";
                case USERNAME_TAKEN:
                    return "Tên tài khoản đã tồn tại";
                case USERNAME_TOO_SHORT:
                    return "Tên tài khoản quá ngắn";
                case USERNAME_TOO_LONG:
                    return "Tên tài khoản quá dài";
                case PASSWORD_NOT_MATCH:
                    return "Mật khẩu không đúng";
                case GROUPNAME_TAKEN:
                    return "Tên nhóm đã tồn tại";
                case GROUPNAME_INVALID:
                    return "Tên nhóm không hợp lệ";

                case CARD_LOST:
                    return "Thẻ đã bị đánh dấu mất";
                case CARD_BROKEN:
                    return "Thẻ đã bị đánh dấu hư";
                case CARD_NOT_FOUND:
                    return "Thẻ không tồn tại trong hệ thống";
                case CARD_PERSONALIZED:
                    return "Thẻ đã được phát hành";
                case CARD_NOT_LOST:
                    return "Thẻ chưa bị đánh dấu mất";
                case CARD_NOT_BROKEN:
                    return "Thẻ chưa bị đánh dấu hư";
                case CARD_NOT_PERSONALIZED:
                    return "Thẻ chưa được phát hành";
                case CARD_ALREADY_EXISTS:
                    return "Thẻ đã tồn tại trong hệ thống";
                case CARD_TYPE_UNSUPPORTED:
                    return "Loại thẻ không được hỗ trợ";

                case PERSO_UNREGISTERED:
                    return "Chưa đăng ký giữ chỗ cho lượt phát hành";
                case PERSO_LOCKED:
                    return "Lượt phát hành đã bị khóa";
                case PERSO_CANCELED:
                    return "Lượt phát hành đã bị hủy";
                case PERSO_NOT_FOUND:
                    return "Lượt phát hành không tồn tại trong hệ thống";
                case PERSO_NOT_LOCKED:
                    return "Lượt phát hành chưa bị khóa";
                case PERSO_NOT_CANCELED:
                    return "Lượt phát hành chưa bị hủy";
                case PERSO_REGISTERED:
                    return "Lượt phát hành đã được đăng ký giữ chỗ";
                case TEACHER_PROFILE_APP_NOT_PRESENT:
                    return "Thẻ không chứa thông tin thành viên";
                case PERSO_EXPIRED:
                    return "Lượt phát hành đã hết hạn";
                case PERSO_NOT_EXPIRED:
                    return "Lượt phát hành chưa hết hạn";
                case PERSO_NOT_EXTENDED:
                    return "Lượt phát hành chưa được gia hạn";
                case INVALID_EXPIRATION_DATE:
                    return "Ngày hết hạn không hợp lệ";

                case MEMBER_NOT_FOUND:
                    return "Thành viên không tồn tại trong hệ thống";
                case MEMBER_PERSONALIZED:
                    return "Thành viên đã được cấp thẻ";
                case FACULTY_NOT_FOUND:
                    return "Khoa không tồn tại trong hệ thống";
                case DEPARTMENT_NOT_FOUND:
                    return "Bộ môn không tồn tại trong hệ thống";
                case MEMBER_NOT_WORKING:
                    return "Thành viên đã nghỉ việc";
                case MEMBER_WORKING_ABROAD:
                    return "Thành viên đang công tác nước ngoài";
                case MEMBER_CONTRACT_END:
                    return "Thành viên đã hết hạn hợp đồng";

                case KEY_NOT_FOUND:
                    return "Khóa không tồn tại trong hệ thống";
                case KEY_LENGTH_INVALID:
                    return "Chiều dài khóa không hợp lệ";
                case MAXIMUM_KEY_REACH:
                    return "Đạt đến số lượng khóa tối đa mà hệ thống cho phép";

                case APP_NOT_FOUND:
                    return "Ứng dụng không tồn tại trong hệ thống";
                case INVALID_START_SECTOR:
                    return "Vị trí sector bắt đầu không hợp lệ";
                case NOT_ENOUGH_SECTOR_FOR_APP_REGISTRATION:
                    return "Không đủ sector để đăng ký ứng dụng";

                default:
                    return "N/A";
            }
        }
    }
}
