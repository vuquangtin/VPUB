using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sBuildingCommunication.Define
{
    public class MessageValidates
    {
        public const  string NAME_VALIDATE = "Tên không được rỗng";
        public const string CancelGroup = "Bạn không thể hủy nhóm này";
        public const string AreYouCancelGroup = "Hủy nhóm này sẽ hủy tất cả các thành phần liên quan, Bạn nên cân nhắc kỹ trước khi hủy!";
        public const string CancelGroupSuccess = "Đã hủy nhóm thành công!";
        public const string CancelGroupFail = "Hủy nhóm thất bại";
        public const string CancelDeviceSuccess = "Đã hủy thiết bị thành công!";
        public const string CancelDeviceFail = "Hủy thiết bị thất bại";
        public const string AddDeviceSuccess = "Thêm thiết bị thành công!";
        public const string AddGroupSuccess = "Thêm nhóm thành công!";
        public const string AddMemberSuccess = "Thêm thành viên thành công!";
        public const string CancelmemberSuccess = "Xóa người dùng thành công";
        public const string CancelmemberFail = "Xóa người dùng thất bại";
        public const string AddDeviceFail = "Thêm thiết bị thất bại";
        public const string UpdateGroupSuccess = "Cập nhật nhóm thành công";
        public const string AddMemberFail = "Thêm thành viên thất bại"; 
    }
}
