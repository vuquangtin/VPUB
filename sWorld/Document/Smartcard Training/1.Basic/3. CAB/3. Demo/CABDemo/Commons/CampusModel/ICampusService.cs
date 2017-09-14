using CampusModel.Exceptions;
using CampusModel.Filters;
using CampusModel.Integrating;
using CampusModel.MethodData;
using CampusModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ServiceModel;

namespace CampusModel
{
    [ServiceContract]
    public interface ICampusService
    {
        #region Application

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<AppDto> GetAppList(string sessionId);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        AppDto GetTeacherProfileApp(string sessionId);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        AppDto AddApp(string sessionId, string appName, string appDescription, KeyDto newAppMasterKey, byte startSectorNumber, byte maxSectorUsed);

        #endregion

        #region Authentication

        /// <summary>
        /// Hàm đăng nhập dựa vào username và password
        /// </summary>
        /// <param name="userName">Tên tài khoản</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>Mã session nếu đăng nhập thành công</returns>
        [OperationContract(Name = "LoginUsingUserName")]
        [FaultContract(typeof(WcfServiceFault))]
        SessionDto Login(string userName, string password);

        /// <summary>
        /// Đăng xuất dựa vào mã session
        /// </summary>
        /// <param name="sessionId">Mã session của lần đăng nhập thành công trước đó</param>
        [OperationContract(Name = "LoginUsingSessionId")]
        [FaultContract(typeof(WcfServiceFault))]
        void Logout(string sessionId);

        #endregion

        #region Card

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<CardDto> GetCardList(string sessionId, CardFilterDto filter, int skip, int take, out int totalRecords);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        DataForImportCard CheckAndGetDataToImportCard(string sessionId, byte[] serialNumber, int cardType);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        CardDto ImportCard(string sessionId, byte[] serialNumber, int cardType, byte hmkAlias, byte dmkAlias);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> MarkBrokenCards(string sessionId, long[] cardIds);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> MarkLostCards(string sessionId, long[] cardIds);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> UnMarkBrokenCards(string sessionId, long[] cardIds);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> UnMarkLostCards(string sessionId, long[] cardIds);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        DataForClearCard CheckAndGetDataToClearCard(string sessionId, byte[] serialNumber, int cardType, byte curHmkAlias, byte curDmkAlias, List<AppMetadataDto> curAppList);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ClearCardData(string sessionId, byte[] serialNumber, byte hmkAlias, byte dmkAlias);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        DataForReadCard GetDataToReadCard(string sessionId, byte[] serialNumber, int cardType, List<AppMetadataDto> appMetadataList, byte curDmkAlias);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<CardStatisticsData> StatisticCardByPhysicalStatus(string sessionId);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<CardStatisticsData> StatisticCardByPersoStatus(string sessionId);

        #endregion

        #region Config
        #endregion

        #region Integrating

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void IntegrateDepartments(string sessionId, List<ALL_BO_MON> data);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void IntegrateFaculties(string sessionId, List<ALL_KHOA> data);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void IntegratePositions(string sessionId, List<ALL_CHUC_VU> data);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void IntegrateScales(string sessionId, List<ALL_NGACH> data);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void IntegrateTeachers(string sessionId, List<ALL_CBCNV> data);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<IntegratingLogDto> GetIntegratingLogList(string sessionId, IntegratingLogFilterDto filter, int skip, int take, out int totalRecords);

        #endregion

        #region Key

        //[OperationContract]
        //[FaultContract(typeof(WcfServiceFault))]
        //void ChangeHeaderMasterKey(string sessionId, string keyName, string keyDescription, string keyValue);

        //[OperationContract]
        //[FaultContract(typeof(WcfServiceFault))]
        //void ChangeDataMasterKey(string sessionId, string keyName, string keyDescription, string keyValue);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        string GetSvk(string sessionId);

        #endregion

        #region Personalization

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<PersonalizationDto> GetPersoList(string sessionId, PersoFilterDto filter, int skip, int take, out int totalRecords);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        DataForPersoCard CheckAndGetDataToPersoCard(string sessionId, long teacherId, byte[] serialNumber, byte hmkAlias, byte dmkAlias);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void PersoCard(string sessionId, long teacherId, string serialNumberHex);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> CancelPersoes(string sessionId, long[] persoIds, string cancelReason);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<FacultyDepartmentDto> GetFacultyList(string sessionId, FacultyFilterDto filter);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<TeacherDto> GetTeacherList(string sessionId, TeacherFilterDto filter, int skip, int take, out int totalRecords);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> LockPersoes(string sessionId, long[] persoIds, string lockReason);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> UnLockPersoes(string sessionId, long[] persoIds, string unlockReason);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        StringCollection ParseTeacherAppData(string sessionId, byte[] teacherAppDataBytes);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        DataForUpdateCard GetDataToUpdateCard(string sessionId, byte[] serialNumber);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void UpdateTeacherAppOfPerso(string sessionId, byte[] serialNumber, DateTime lastCardDataUpdate);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ValidatePerso(string sessionId, byte[] serialNumber);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> ExtendPerso(string sessionId, long[] persoIds, DateTime expirationDate);

        #endregion

        #region Statistics
        #endregion

        #region User

        /// <summary>
        /// Thêm một group mới vào hệ thống.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="name">Tên của role mới</param>
        /// <param name="description">Chú thích cho role mới</param>
        /// <param name="functionIds">Danh sách các hàm mà role có quyền thực hiện</param>
        /// <returns>Đối tượng role đã được tạo (nếu thành công)</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        GroupFunctionDto AddGroup(string sessionId, string name, string description, List<long> functions);

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
        [OperationContract(Name = "AddUserUsingNewPI")]
        [FaultContract(typeof(WcfServiceFault))]
        UserDto AddUser(string sessionId, string userName, string password, long groupId, PersonalInfoDto personalInfo);

        [OperationContract(Name = "AddUserUsingTeacherId")]
        [FaultContract(typeof(WcfServiceFault))]
        UserDto AddUser(string sessionId, string userName, string password, long groupId, long teacherId);

        /// <summary>
        /// Hàm này cho phép user tự đổi mật khẩu của mình.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="oldPassword">Mật khẩu cũ dưới dạng plain-text</param>
        /// <param name="newPassword">Mật khẩu mới dưới dạng plain-text</param>
        /// <param name="recordVersion">Record version của user phần đổi mật khẩu</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ChangePassword(string sessionId, string oldPassword, string newPassword);

        /// <summary>
        /// Hàm này cho phép thay đổi role của một user.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user sẽ được đổi nhóm</param>
        /// <param name="newGroupId">Mã nhóm mới</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ChangeUserGroup(string sessionId, long userId, long newGroupId);

        /// <summary>
        /// Hàm này cho phép user tự cập thông tin cá nhân của mình nếu thông tin 
        /// cá nhân đó không phải là trích xuất từ database của nhà trường.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user sẽ được cập nhật thông tin</param>
        /// <param name="newPersonalInfo">Thông tin cá nhân mới.</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ChangeUserPersonalInfo(string sessionId, long userId, PersonalInfoDto newPersonalInfo);

        /// <summary>
        /// Lấy về thông tin của group dựa vào id
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="groupId">Mã của group cần lấy thông tin</param>
        /// <returns>Thông tin của group cùng danh sách quyền</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        GroupFunctionDto GetGroupDetail(string sessionId, long groupId);

        /// <summary>
        /// Lấy về danh sách các nhóm hiện có trong hệ thống
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm nhóm</param>
        /// <returns>Danh sách nhóm thỏa điều kiện</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<GroupDto> GetGroupList(string sessionId, GroupFilterDto filter);

        /// <summary>
        /// Lấy về một số lần đăng nhập cuối cùng của user hiện tại
        /// </summary>
        /// <param name="sessionId">Mã session của user hiện tại</param>
        /// <param name="skip">Số record sẽ bỏ qua</param>
        /// <param name="take">Số record cần lấy về</param>
        /// <returns>Danh sách các lượt đăng nhập</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<LoginHistoryDto> GetLastLoginHistoryList(string sessionId, int skip, int take);

        /// <summary>
        /// Lấy ra danh sách lịch sử các lượt đăng nhập của tất cả user
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm</param>
        /// <returns>Danh sách các lượt đăng nhập</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<LoginHistoryDto> GetLoginHistoryList(string sessionId, LoginHistoryFilterDto filter, int skip, int take, out int totalRecords);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<Function> GetPermissionList(string sessionId);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        UserDto GetUserDetail(string sessionId, long userId);

        /// <summary>
        /// Lấy về danh sách user hiện có trong hệ thống dựa vào bộ lọc.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm</param>
        /// <returns>Danh sách user</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<UserDto> GetUserList(string sessionId, UserFilterDto filter, int skip, int take, out int totalRecords);

        /// <summary>
        /// Khóa một tài khoản (chuyển trạng thái sang LOCKED)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userIds">Danh sách các mã tài khoản cần khóa</param>
        /// <param name="lockReason">Lý do khóa tài khoản</param>
        /// <returns>Danh sách kết quả cho từng lượt khóa</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> LockUsers(string sessionId, long[] userIds);

        /// <summary>
        /// "Xóa" một group (chuyển flag = false)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="groupId">Mã của group cần "xóa"</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> RemoveGroups(string sessionId, long[] groupIds);

        /// <summary>
        /// "Xóa" một user (chuyển flag = false)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user cần "xóa"</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> RemoveUsers(string sessionId, long[] userIds);

        /// <summary>
        /// Cài lại mật khẩu của một user bất kỳ.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user cần cài lại mật khẩu</param>
        /// <param name="newPassword">Mật khẩu mới của user</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ResetPassword(string sessionId, long userId, string newPassword);

        /// <summary>
        /// Mở khóa một tài khoản bất kỳ (hủy trạng thái LOCKED)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userIds">Danh sách mã tài khoản cần hủy khóa</param>
        /// <param name="unlockReason">Lý do hủy khóa tài khoản</param>
        /// <returns>Danh sách kết quả tương ứng với từng lượt hủy khóa</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> UnLockUsers(string sessionId, long[] userIds);

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
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void UpdateGroup(string sessionId, long groupId, string newName, string newDescription, List<long> functions);

        #endregion
    }
}