using JavaCommunication;
using sWorldModel.Filters;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using JavaCommunication.Common;
using sWorldCommunication;


namespace JavaCommunication.Java
{
    public class JavaManegerSystem : IManagerSystem
    {
        private static JavaManegerSystem instance = new JavaManegerSystem();
        public static JavaManegerSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaManegerSystem();
                }
                return instance;
            }
        }
        private JavaManegerSystem()
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
        public GroupCustomerDto AddGroup(string session, GroupCustomerDto group)
        {
            return CommunicationManagerSystem.Instance.AddGroup(session, group);
        }

        /// <summary>
        /// Thêm thông tin cho User
        /// </summary>
        /// <param name="session"></param>
        /// <param name="user">thông tin cho User</param>
        /// <returns></returns>
        public UserSworld AddUser(string session, UserSworld user)
        {
            return CommunicationManagerSystem.Instance.AddUser( session, user);
        }

        public UserSworld AddUser(string session, string userName, string password, long groupId, long memberId)
        {
            return new UserSworld();
        }

        /// <summary>
        /// Hàm này cho phép user tự đổi mật khẩu của mình.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="oldPassword">Mật khẩu cũ dưới dạng plain-text</param>
        /// <param name="newPassword">Mật khẩu mới dưới dạng plain-text</param>
        /// <param name="recordVersion">Record version của user phần đổi mật khẩu</param>
        public int ChangePassword(string session, string oldPassword, string newPassword)
        {
            return CommunicationManagerSystem.Instance.ChangePassword( session, oldPassword, newPassword);
        }

        /// <summary>
        /// Hàm này cho phép thay đổi role của một user.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user sẽ được đổi nhóm</param>
        /// <param name="newGroupId">Mã nhóm mới</param>
        public int ChangeUserGroup(string session, long userId, long newGroupId)
        {
            return CommunicationManagerSystem.Instance.ChangeUserGroup(session, userId, newGroupId);
        }

        /// <summary>
        /// Hàm này cho phép user tự cập thông tin cá nhân của mình nếu thông tin 
        /// cá nhân đó không phải là trích xuất từ database của nhà trường.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user sẽ được cập nhật thông tin</param>
        /// <param name="userNew">Thông tin cá nhân mới.</param>
        public int UpdateUser(string session, UserSworld userNew)
        {
            return CommunicationManagerSystem.Instance.UpdateUser(session, userNew);
        }

        /// <summary>
        /// Lấy về thông tin của group dựa vào id
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="groupId">Mã của group cần lấy thông tin</param>
        /// <returns>Thông tin của group cùng danh sách quyền</returns>
        public GroupCustomerDto GetGroupById(string session, long groupId)
        {
            return CommunicationManagerSystem.Instance.GetGroupById(session, groupId);
        }

        /// <summary>
        /// Lấy về danh sách các nhóm hiện có trong hệ thống
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm nhóm</param>
        /// <returns>Danh sách nhóm thỏa điều kiện</returns>
        public List<GroupDto> GetGroupList(string session, GroupFilterDto filter)
        {
            return CommunicationManagerSystem.Instance.GetGroupList(session, filter);
        }

        /// <summary>
        /// Lấy về một số lần đăng nhập cuối cùng của user hiện tại
        /// </summary>
        /// <param name="sessionId">Mã session của user hiện tại</param>
        /// <param name="skip">Số record sẽ bỏ qua</param>
        /// <param name="take">Số record cần lấy về</param>
        /// <returns>Danh sách các lượt đăng nhập</returns>
        public List<LoginHistoryDTO> GetLastLoginHistoryList(string session, int skip, int take)
        {
            return new List<LoginHistoryDTO>();
        }

        /// <summary>
        /// Lấy ra danh sách lịch sử các lượt đăng nhập của tất cả user
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm</param>
        /// <returns>Danh sách các lượt đăng nhập</returns>
        public List<LoginHistoryDTO> GetLoginHistoryList(string session, LoginHistoryFilterDto filter)
        {
            return new List<LoginHistoryDTO>();
        }

        public List<PolicySworld> GetPermissionList(string session, long userId)
        {
            return CommunicationManagerSystem.Instance.GetPermissionList(session, userId);
        }

        public UserSworld GetUserById(string session, long userId)
        {
            return CommunicationManagerSystem.Instance.GetUserById( session, userId);
        }

        /// <summary>
        /// Lấy về danh sách user hiện có trong hệ thống dựa vào bộ lọc.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm</param>
        /// <returns>Danh sách user</returns>
        public List<UserSworld> GetUserList(string session, UserFilterDto filter)
        {
            return CommunicationManagerSystem.Instance.GetUserList(session, filter);
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
            return CommunicationManagerSystem.Instance.LockUsers(session, userIds);
        }

        /// <summary>
        /// "Xóa" một group (chuyển flag = false)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="groupId">Mã của group cần "xóa"</param>
        public List<MethodResultDto> RemoveGroups(string session, long groupId)
        {
            return CommunicationManagerSystem.Instance.RemoveGroups(session,groupId);
        }

        /// <summary>
        /// "Xóa" một user (chuyển flag = false)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user cần "xóa"</param>
        public List<MethodResultDto> RemoveUsers(string session, long[] userIds)
        {
            return CommunicationManagerSystem.Instance.RemoveUsers(session,userIds);
        }

        /// <summary>
        /// Cài lại mật khẩu của một user bất kỳ.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user cần cài lại mật khẩu</param>
        /// <param name="newPassword">Mật khẩu mới của user</param>
        public int ResetPassword(string session, long userId, string newPassword)
        {
            return CommunicationManagerSystem.Instance.ResetPassword(session,userId,newPassword);
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
            return CommunicationManagerSystem.Instance.UnLockUsers(session,userIds);
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
        public int UpdateGroup(string session, GroupCustomerDto group)
        {
            return CommunicationManagerSystem.Instance.UpdateGroup(session,group);
        }

        public List<PolicySworld> GetAllPermissionList() 
        {
            var permissions = FunctionExtMethod.GetAll();
            List<PolicySworld> result = new List<PolicySworld>();
            foreach (Function p in permissions)
            {
                result.Add(new PolicySworld() { ModuleId = (int)p });
            }
            return result;
        }
    }
}
