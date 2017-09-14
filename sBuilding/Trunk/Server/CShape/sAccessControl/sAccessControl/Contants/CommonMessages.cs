using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sAccessControl.Contants
{
    public static class CommonMessages
    {
        public const string TimeOutExceptionMessage = "Hết thời gian kết nối đến máy trung tâm, xin hãy thử lại.";
        public const string CommunicationExceptionMessage = "Không thể kết nối đến máy trung tâm, hãy kiểm tra lại đường truyền mạng.";
        public const string FaultExceptionMessage = "Xảy ra lỗi trong quá trình xử lý của máy trung tâm.";
        public const string CardReadyInfor = "Tổ chức phát hành thẻ đã được xác định. Bạn phải xóa thông tin trước khi thực hiện thao tác này.";
        public const string CanNotLogin = "Không đăng nhập được vào sector ";
        public const string CanNotWrite = "Không ghi được dữ liệu vào sector ";

        public const string CanNotWriteKey = "Không ghi được khóa vào sector ";
        public const string CanNotWriteHeader = "Không ghi được khóa vào header";
        public const string CanNotWriteDataHeader = "Không ghi được dữ liệu vào header";
        public const string WrongData = "Dữ liệu không phải được gửi từ server";
        public const string CanNotWriteCardToSystem = "Không thể ghi dữ liệu của thẻ vào hệ thống";
        public const string CanNotClearCardToSystem = "Không thể xóa dữ liệu của thẻ khỏi hệ thống";
        public const string WrongLicense = "License thẻ không hợp lệ";
        public const string CanNotRead = "Không đọc được license trên thẻ";
        public const string CanNotReadHeader = "Không đăng nhập được vào header";

        public const string CanNotWriteData = "Thẻ chưa được ghi thông tin";

        public const string LoginFail = "Tài khoản hoặc mật khẩu không đúng. Vui lòng kiểm tra cấu hình hệ thống";
        public const string LoginProcess = "Đang đăng nhập vào hệ thống. Vui lòng chờ đợi ...";
    }
}
