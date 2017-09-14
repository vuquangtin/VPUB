using sWorldModel.Filters;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;

namespace sWorldCommunication
{
    public interface IManagerSystem
    {
        /// <summary>
        /// Lấy thông tin của nhóm chức năng
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="groupId">Id của nhóm chức năng</param>
        /// <returns>Thông tin của nhóm chức năng</returns>
        GroupCustomerDto GetGroupById(string session, long groupId);

        /// <summary>
        /// Lấy danh sách nhóm chức năng
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>Danh sách nhóm chức năng</returns>
        List<GroupDto> GetGroupList(string session, GroupFilterDto filter);

        /// <summary>
        /// Thêm nhóm chức năng
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="group">Thông tin của nhóm chức năng</param>
        /// <returns>Thông tin nhóm chức năng</returns>
        GroupCustomerDto AddGroup(string session, GroupCustomerDto group);

        /// <summary>
        /// Cập nhật nhóm chức năng
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="group">Thông tin của nhóm chức năng</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int UpdateGroup(string session, GroupCustomerDto group);

        /// <summary>
        /// Xóa thông tin nhóm chức năng
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="groupId">Id của nhóm chức năng</param>
        /// <returns>Danh sách kết quả đã được xử lý</returns>
        List<MethodResultDto> RemoveGroups(string session, long groupId);

        /// <summary>
        /// Lấy danh sách tài khoản
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>Danh sách tài khoản</returns>
        List<UserSworld> GetUserList(string session, UserFilterDto filter);

        /// <summary>
        /// Lấy thông tin của tài khoản
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="userId">Id của tài khoản</param>
        /// <returns>Thông tin tài khoản</returns>
        UserSworld GetUserById(string session, long userId);

        /// <summary>
        /// Thêm thông tin tài khoản
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="user">Thông tin tài khoản</param>
        /// <returns>Thông tin tài khoản</returns>
        UserSworld AddUser(string session, UserSworld user);

        /// <summary>
        /// Cập nhật thông tin tài khoản
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="user">Thông tin tài khoản</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int UpdateUser(string session, UserSworld user);

        /// <summary>
        /// Chuyển tài khoản sang nhóm chức năng khác
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="userId">Id của tài khoản</param>
        /// <param name="newGroupId">Id của nhóm chức năng mới</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int ChangeUserGroup(string session, long userId, long newGroupId);

        /// <summary>
        /// Đổi mật khẩu của tài khoản
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="oldPassword">Mật khẩu cũ</param>
        /// <param name="newPassword">Mật khẩu mới</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int ChangePassword(string session,string oldPassword, string newPassword);

        /// <summary>
        /// Cập nhật mật khẩu mới của tài khoản
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="userId">Id của tài khoản</param>
        /// <param name="newPassword">Mật khẩu mới</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int ResetPassword(string session, long userId, string newPassword);

        /// <summary>
        /// Cập nhật tình trạng khóa cho danh sách tài khoản
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="userIds">Danh sách Id của tài khoản</param>
        /// <returns>Danh sách kết quả đã được xử lý</returns>
        List<MethodResultDto> LockUsers(string session, long[] userIds);

        /// <summary>
        /// Cập nhật tình trạng mở khóa cho danh sách tài khoản
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="userIds">Danh sách Id của tài khoản</param>
        /// <returns>Danh sách kết quả đã được xử lý</returns>
        List<MethodResultDto> UnLockUsers(string session, long[] userIds);

        /// <summary>
        /// Xóa danh sách tài khoản
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="userIds">Danh sách Id của tài khoản</param>
        /// <returns>Danh sách kết quả đã được xử lý</returns>
        List<MethodResultDto> RemoveUsers(string session, long[] userIds);

        /// <summary>
        /// Lấy danh sách lịch sử đăng nhập
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>Danh sách lịch sử đăng nhập</returns>
        List<LoginHistoryDTO> GetLoginHistoryList(string session, LoginHistoryFilterDto filter);

        /// <summary>
        /// Lấy danh sách chức năng của tài khoản được sử dụng
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="userId">Id của tài khoản</param>
        /// <returns>Danh sách chức năng của tài khoản được sử dụng</returns>
        List<PolicySworld> GetPermissionList(string session, long userId);

        /// <summary>
        /// Lấy danh sách tất cả chức năng
        /// </summary>
        /// <returns>Danh sách tất cả chức năng</returns>
        List<PolicySworld> GetAllPermissionList();

        /// <summary>
        /// Thêm thông tin tài khoản
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="userName">Tên tài khoản</param>
        /// <param name="password">Mật khẩu</param>
        /// <param name="groupId">Id của nhóm chức năng</param>
        /// <param name="teacherId"></param>
        /// <returns>Thông tin tài khoản</returns>
        UserSworld AddUser(string session, string userName, string password, long groupId, long teacherId);

        /// <summary>
        /// chưa được sử dụng
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        List<LoginHistoryDTO> GetLastLoginHistoryList(string session, int skip, int take);
    }
}
