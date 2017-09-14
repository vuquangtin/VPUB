using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.Integrating;
using sWorldModel.MethodData;
using sWorldModel.TransportData;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ServiceModel;

namespace sWorldModel
{
    [ServiceContract]
    public interface IsWorldService
    {
        #region Application

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<AMSAppDto> GetAppList(string session);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        AMSAppDto GetTeacherProfileApp(string session);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        AMSAppDto AddApp(string session, string appName, string appDescription, KeyDTO newAppMasterKey, byte startSectorNumber, byte maxSectorUsed);

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
        SessionDTO Login(string userName, string password);

        /// <summary>
        /// Đăng xuất dựa vào mã session
        /// </summary>
        /// <param name="sessionId">Mã session của lần đăng nhập thành công trước đó</param>
        [OperationContract(Name = "LoginUsingSessionId")]
        [FaultContract(typeof(WcfServiceFault))]
        void Logout(string session);

        #endregion

        #region Card

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<CardDto> GetCardList(string session, CardFilterDto filter, int skip, int take, out int totalRecords);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        DataForImportCard CheckAndGetDataToImportCard(string session, byte[] serialNumber, int cardType);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        CardDto ImportCard(string session, byte[] serialNumber, int cardType, byte hmkAlias, byte dmkAlias);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> MarkBrokenCards(string session, long[] cardIds);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> MarkLostCards(string session, long[] cardIds);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> UnMarkBrokenCards(string session, long[] cardIds);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> UnMarkLostCards(string session, long[] cardIds);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        DataForClearCard CheckAndGetDataToClearCard(string session, byte[] serialNumber, int cardType, byte curHmkAlias, byte curDmkAlias, List<AppMetadataDto> curAppList);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ClearCardData(string session, byte[] serialNumber, byte hmkAlias, byte dmkAlias);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        DataForReadCard GetDataToReadCard(string session, byte[] serialNumber, int cardType, List<AppMetadataDto> appMetadataList, byte curDmkAlias);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<CardStatisticsData> StatisticCardByPhysicalStatus(string session);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<CardStatisticsData> StatisticCardByPersoStatus(string session);

        #endregion

        #region Config
        #endregion

        #region Integrating

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void IntegrateDepartments(string session, List<ALL_BO_MON> data);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void IntegrateFaculties(string session, List<ALL_KHOA> data);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void IntegratePositions(string session, List<ALL_CHUC_VU> data);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void IntegrateScales(string session, List<ALL_NGACH> data);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void IntegrateTeachers(string session, List<ALL_CBCNV> data);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<IntegratingLogDto> GetIntegratingLogList(string session, IntegratingLogFilterDto filter, int skip, int take, out int totalRecords);

        #endregion

        #region Key

        //[OperationContract]
        //[FaultContract(typeof(WcfServiceFault))]
        //void ChangeHeaderMasterKey(string session, string keyName, string keyDescription, string keyValue);

        //[OperationContract]
        //[FaultContract(typeof(WcfServiceFault))]
        //void ChangeDataMasterKey(string session, string keyName, string keyDescription, string keyValue);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        string GetSvk(string session);

        #endregion

        #region Personalization

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<Personalization> GetPersoList(string session, PersoFilter filter, int skip, int take, out int totalRecords);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        DataForPersoCard CheckAndGetDataToPersoCard(string session, long teacherId, byte[] serialNumber, byte hmkAlias, byte dmkAlias);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void PersoCard(string session, long teacherId, string serialNumberHex);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> CancelPersoes(string session, long[] persoIds, string cancelReason);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<FacultyDepartmentDto> GetFacultyList(string session, FacultyFilterDto filter);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MemberDTO> GetTeacherList(string session, MemberFilter filter, int skip, int take, out int totalRecords);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> LockPersoes(string session, long[] persoIds, string lockReason);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> UnLockPersoes(string session, long[] persoIds, string unlockReason);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        StringCollection ParseTeacherAppData(string session, byte[] teacherAppDataBytes);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        DataForUpdateCard GetDataToUpdateCard(string session, byte[] serialNumber);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void UpdateTeacherAppOfPerso(string session, byte[] serialNumber, DateTime lastCardDataUpdate);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ValidatePerso(string session, byte[] serialNumber);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> ExtendPerso(string session, long[] persoIds, DateTime expirationDate);

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
        GroupCustomerDto AddGroup(string session, string name, string description, List<long> functions);

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
        UserDTO AddUser(string session, string userName, string password, long groupId, UserDTO personalInfo);

        [OperationContract(Name = "AddUserUsingTeacherId")]
        [FaultContract(typeof(WcfServiceFault))]
        UserDTO AddUser(string session, string userName, string password, long groupId, long teacherId);

        /// <summary>
        /// Hàm này cho phép user tự đổi mật khẩu của mình.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="oldPassword">Mật khẩu cũ dưới dạng plain-text</param>
        /// <param name="newPassword">Mật khẩu mới dưới dạng plain-text</param>
        /// <param name="recordVersion">Record version của user phần đổi mật khẩu</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ChangePassword(string session, string oldPassword, string newPassword);

        /// <summary>
        /// Hàm này cho phép thay đổi role của một user.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user sẽ được đổi nhóm</param>
        /// <param name="newGroupId">Mã nhóm mới</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ChangeUserGroup(string session, long userId, long newGroupId);

        /// <summary>
        /// Hàm này cho phép user tự cập thông tin cá nhân của mình nếu thông tin 
        /// cá nhân đó không phải là trích xuất từ database của nhà trường.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user sẽ được cập nhật thông tin</param>
        /// <param name="newPersonalInfo">Thông tin cá nhân mới.</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ChangeUserPersonalInfo(string session, long userId, UserDTO newPersonalInfo);

        /// <summary>
        /// Lấy về thông tin của group dựa vào id
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="groupId">Mã của group cần lấy thông tin</param>
        /// <returns>Thông tin của group cùng danh sách quyền</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        GroupCustomerDto GetGroupDetail(string session, long groupId);

        /// <summary>
        /// Lấy về danh sách các nhóm hiện có trong hệ thống
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm nhóm</param>
        /// <returns>Danh sách nhóm thỏa điều kiện</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<GroupDto> GetGroupList(string session, GroupFilterDto filter);

        /// <summary>
        /// Lấy về một số lần đăng nhập cuối cùng của user hiện tại
        /// </summary>
        /// <param name="sessionId">Mã session của user hiện tại</param>
        /// <param name="skip">Số record sẽ bỏ qua</param>
        /// <param name="take">Số record cần lấy về</param>
        /// <returns>Danh sách các lượt đăng nhập</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<LoginHistoryDto> GetLastLoginHistoryList(string session, int skip, int take);

        /// <summary>
        /// Lấy ra danh sách lịch sử các lượt đăng nhập của tất cả user
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm</param>
        /// <returns>Danh sách các lượt đăng nhập</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<LoginHistoryDto> GetLoginHistoryList(string session, LoginHistoryFilterDto filter, int skip, int take, out int totalRecords);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<Function> GetPermissionList(string session);

        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        UserDTO GetUserDetail(string session, long userId);

        /// <summary>
        /// Lấy về danh sách user hiện có trong hệ thống dựa vào bộ lọc.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="filter">Bộ lọc tìm kiếm</param>
        /// <returns>Danh sách user</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<UserDTO> GetUserList(string session, UserFilterDto filter, int skip, int take, out int totalRecords);

        /// <summary>
        /// Khóa một tài khoản (chuyển trạng thái sang LOCKED)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userIds">Danh sách các mã tài khoản cần khóa</param>
        /// <param name="lockReason">Lý do khóa tài khoản</param>
        /// <returns>Danh sách kết quả cho từng lượt khóa</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> LockUsers(string session, long[] userIds);

        /// <summary>
        /// "Xóa" một group (chuyển flag = false)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="groupId">Mã của group cần "xóa"</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> RemoveGroups(string session, long[] groupIds);

        /// <summary>
        /// "Xóa" một user (chuyển flag = false)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user cần "xóa"</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> RemoveUsers(string session, long[] userIds);

        /// <summary>
        /// Cài lại mật khẩu của một user bất kỳ.
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userId">Mã của user cần cài lại mật khẩu</param>
        /// <param name="newPassword">Mật khẩu mới của user</param>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        void ResetPassword(string session, long userId, string newPassword);

        /// <summary>
        /// Mở khóa một tài khoản bất kỳ (hủy trạng thái LOCKED)
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="userIds">Danh sách mã tài khoản cần hủy khóa</param>
        /// <param name="unlockReason">Lý do hủy khóa tài khoản</param>
        /// <returns>Danh sách kết quả tương ứng với từng lượt hủy khóa</returns>
        [OperationContract]
        [FaultContract(typeof(WcfServiceFault))]
        List<MethodResultDto> UnLockUsers(string session, long[] userIds);

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
        void UpdateGroup(string session, long groupId, string newName, string newDescription, List<long> functions);

        #endregion
    }
}