using JavaCommunication;
using sWorldModel.Filters;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using JavaCommunication.Test;

namespace JavaCommunication.Java
{
    public class TestUser : IManagerSystem
    {
        private static TestUser instance = new TestUser();
        public static TestUser Instance
        {
            get {
                if (instance == null){
                    instance = new TestUser();
                }
                return instance;
            }
        }
        private TestUser()
        {
        }

        /// <summary>
        /// Thêm một group mới vào hệ thống.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="name">Tên của role mới</param>
        /// <param name="description">Chú thích cho role mới</param>
        /// <param name="functionIds">Danh sách các hàm mà role có quyền thực hiện</param>
        /// <returns>Đối tượng role đã được tạo (nếu thành công)</returns>
        public GroupFunctionDto AddGroup(string session, string name, string description, List<long> functions) 
        {
            return new GroupFunctionDto();
        }

        /// <summary>
        /// Hàm này cho phép thêm một user mới vào hệ thống.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userName">Tên user mới</param>
        /// <param name="password">Mật khẩu của user mới</param>
        /// <param name="groupId">Mã role mà user mới thuộc về</param>
        /// <param name="personalInfo">Mã đối tượng chứa thông tin cá nhân của 
        /// user mới</param>
        /// <returns>Đối tượng user đã được tạo</returns>
        public UserDto AddUser(string session, string userName, string password, long groupId, PersonalInfo personalInfo)
        {
            return new UserDto();
        }

        public UserDto AddUser(string session, string userName, string password, long groupId, long teacherId)
        {
            return new UserDto();
        }

        /// <summary>
        /// Hàm này cho phép user tự đổi mật khẩu của mình.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="oldPassword">Mật khẩu cũ dưới dạng plain-text</param>
        /// <param name="newPassword">Mật khẩu mới dưới dạng plain-text</param>
        /// <param name="recordVersion">Record version của user phần đổi mật khẩu</param>
        public void ChangePassword(string session, string oldPassword, string newPassword)
        {
        }

        /// <summary>
        /// Hàm này cho phép thay đổi role của một user.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user sẽ được đổi nhóm</param>
        /// <param name="newGroupId">Mã nhóm mới</param>
        public void ChangeUserGroup(string session, long userId, long newGroupId)
        {
        }

        /// <summary>
        /// Hàm này cho phép user tự cập thông tin cá nhân của mình nếu thông tin 
        /// cá nhân đó không phải là trích xuất từ database của nhà trường.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user sẽ được cập nhật thông tin</param>
        /// <param name="newPersonalInfo">Thông tin cá nhân mới.</param>
        public void ChangeUserPersonalInfo(string session, long userId, PersonalInfo newPersonalInfo)
        {
        }

        /// <summary>
        /// Lấy về thông tin của group dựa vào id
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="groupId">Mã của group cần lấy thông tin</param>
        /// <returns>Thông tin của group cùng danh sách quyền</returns>
        public GroupFunctionDto GetGroupDetail(string session, long groupId)
        {
            return new GroupFunctionDto();
        }

        /// <summary>
        /// Lấy về danh sách các nhóm hiện có trong hệ thống
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm nhóm</param>
        /// <returns>Danh sách nhóm thỏa điều kiện</returns>
        public List<GroupDto> GetGroupList(string session, GroupFilterDto filter)
        {
            return new List<GroupDto>();
        }

        /// <summary>
        /// Lấy về một số lần đăng nhập cuối cùng của user hiện tại
        /// </summary>
        /// <param name="sessionId">Mã session của user hiện tại</param>
        /// <param name="skip">Số record sẽ bỏ qua</param>
        /// <param name="take">Số record cần lấy về</param>
        /// <returns>Danh sách các lượt đăng nhập</returns>
        public List<LoginHistoryDto> GetLastLoginHistoryList(string session, int skip, int take)
        {
            return new List<LoginHistoryDto>();
        }

        /// <summary>
        /// Lấy ra danh sách lịch sử các lượt đăng nhập của tất cả user
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm</param>
        /// <returns>Danh sách các lượt đăng nhập</returns>
        public List<LoginHistoryDto> GetLoginHistoryList(string session, LoginHistoryFilterDto filter, int skip, int take, out int totalRecords)
        {
            totalRecords = 0;
            return new List<LoginHistoryDto>();
        }

        public List<Function> GetPermissionList(string session)
        {
            return HardCode.Instance.LoadPermissionList();
        }

        public UserDto GetUserDetail(string session, long userId)
        {
            return new UserDto();
        }

        /// <summary>
        /// Lấy về danh sách user hiện có trong hệ thống dựa vào bộ lọc.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm</param>
        /// <returns>Danh sách user</returns>
        public List<UserDto> GetUserList(string session, UserFilterDto filter, int skip, int take, out int totalRecords)
        {
            totalRecords = 0;
            return new List<UserDto>();
        }

        /// <summary>
        /// Khóa một tài khoản (chuyển trạng thái sang LOCKED)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userIds">Danh sách các mã tài khoản cần khóa</param>
        /// <param name="lockReason">Lý do khóa tài khoản</param>
        /// <returns>Danh sách kết quả cho từng lượt khóa</returns>
        public List<MethodResultDto> LockUsers(string session, long[] userIds)
        {
            return new List<MethodResultDto>();
        }

        /// <summary>
        /// "Xóa" một group (chuyển flag = false)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="groupId">Mã của group cần "xóa"</param>
        public List<MethodResultDto> RemoveGroups(string session, long[] groupIds)
        {
            return new List<MethodResultDto>();
        }

        /// <summary>
        /// "Xóa" một user (chuyển flag = false)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user cần "xóa"</param>
        public List<MethodResultDto> RemoveUsers(string session, long[] userIds)
        {
            return new List<MethodResultDto>();
        }

        /// <summary>
        /// Cài lại mật khẩu của một user bất kỳ.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user cần cài lại mật khẩu</param>
        /// <param name="newPassword">Mật khẩu mới của user</param>
        public void ResetPassword(string session, long userId, string newPassword)
        {
        }

        /// <summary>
        /// Mở khóa một tài khoản bất kỳ (hủy trạng thái LOCKED)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userIds">Danh sách mã tài khoản cần hủy khóa</param>
        /// <param name="unlockReason">Lý do hủy khóa tài khoản</param>
        /// <returns>Danh sách kết quả tương ứng với từng lượt hủy khóa</returns>
        public List<MethodResultDto> UnLockUsers(string session, long[] userIds)
        {
            return new List<MethodResultDto>();
        }

        /// <summary>
        /// Đổi thông tin của một role bất kỳ.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="groupId">Mã của role cần thay đổi thông tin</param>
        /// <param name="newName">Tên mới của role; null nếu không cần thay đổi</param>
        /// <param name="newDescription">Chú thích mới của role; null nếu không cần
        /// thay đổi</param>
        /// <param name="functionIds">Danh sách các hàm mà group được quyền;
        /// null nếu không cần thay đổi</param>
        public void UpdateGroup(string session, long groupId, string newName, string newDescription, List<long> functions)
        {
        }
    }
}
