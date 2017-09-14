package com.sworld.common;

import javax.ws.rs.core.MediaType;

public class Defines {
	public static final String APPLICATION_JSON = MediaType.APPLICATION_JSON + "; charset=utf-8";
	public static final String AUTHENTICATION = "/auth";
	public static final String KMS = "/kms";
	public static final String ORG = "/org";
	public static final String PERSO = "/perso";
	public static final String CARD = "/card";
	public static final String STR_DEFULT ="";
	public static final String CONFIG = "/config";
	public static final String OTHER = "/other";
	public static final String SYNC = "/sync";
	public static final String AMS = "/app";
	public static final String DEVICE = "/device";
	
	
	//public static final String ECASH = "/ecashs";
	//public static final String SaiGonPearl = "/SaiGonPearls";
	
	
	//authentication
	public static final String PEMISSION = "/pemission";
	public static final String LOGIN = "/login";
	public static final String LOGIN_UBND = "/loginubnd";
	public static final String LOGOUT = "/logout";
	public static final String GET_USER_BY_ID = "/getuserbyid";
	
	// MasterInfor GetMasterDataByKey( String session, String code );
	public static final String GET_MASTER_DATA_BY_KEY = "/GetMasterDataByKey";

	// List<PartnerInfoDto> GetPartnerDataByKey( String session, int masterid,
	// String code )
	public static final String GET_PARTNER_DATA_BY_KEY = "/GetPartnerDataByKey";
	
	public static final String GET_MEMBER_BY_CODE = "/getmemberbycode";

	// List<SubOrgCustomer> GetSubOrgListDataByOrgId(String session, int orgId,
	// SubOrgFilter filter)
	public static final String GET_SUBORG_DATA_BY_ORG_ID = "/GetSubOrgListDataByOrgId";

	// List<MemberDto> GetMemberListDataBySubOrgId(String session, int subOrgId,
	// MemberFilter filter)
	public static final String GET_MEMBER_DATA_BY_SUBORG_ID = "/GetMemberListDataBySubOrgId";

	// List<PersonalizationDto> GetPersoListDataByOrgIdSubOrgId(String session,
	// int orgId, int subOrgId, PersoFilter filter)
	public static final String GET_PERSO_DATA_BY_ORG_ID_SUBORG_ID = "/GetPersoListDataByOrgIdSubOrgId";

	// DataForPersoCard CheckAndGetDataToPersoCard(string session, int memberid,
	// byte[] serialNumber, byte hmkAlias, byte dmkAlias)
	// public static final String CHECK_GET_DATA_FOR_PERSO_CARD
	// ="/CheckAndGetDataToPersoCard";

	// int PersoCardChip(string sessionId, long memberId, string
	// serialNumberHex)
	public static final String PERSO_CARD_CHIP = "/PersoCardChip"; // xong

	// int UpdateMemberAppOfPerso(string sessionId, byte[] serialNumber, string
	// lastUpdateDate)
	public static final String UPDATE_DATE_MEMBER_APP_OF_PERSO = "/UpdateMemberAppOfPerso";// chua
																							// lam

	// PreGenerateDataDto GetPreGenerateData(string sessionId, long masterId,
	// long partnerId, int flag)
	public static final String GET_DATE_FOR_GENERATE_SERIAL = "/GetPreGenerateData";

	// List<CardPerDataMagneticDto> GenerateCardData(string masterNumber, string
	// partnerNumber, int count, PreGenerateDataDto preData,
	// List<PersonalInfoDto> personalInfoList);
	public static final String GENERATE_SERIAL_CARD_DATA = "/GenerateCardData";

	// int PresoCardMagnetic(string sessionId,List<CardPerDataMagneticDto>
	// cardPerDataList)
	public static final String PRESO_CARD_MAGNETIC = "/PresoCardMagnetic";

	// ResultCheckCardDTO CheckAndGetMasterDataToImportCard(string session, long
	// id, string serialnumbex, int cardtype);
	public static final String CHECK_ADN_GET_MASTERDATA_4_CARD_CHIP = "/CheckAndGetMasterDataToImportCard";

	// UpdateDataForCardBySerialAndMasterId(string session, long id, string
	// serialnumber, int cardtype, int status)
	public static final String UPDATE_CARD_DATA_OF_MASTER = "/UpdateDataForCardBySerialAndMasterId";

	// List<MemberCardDTO> GetMemberList(string session, long subOrgId,
	// MemberFilter filter);
	public static final String GET_MEMBER_BY_SUBORGID = "/GetMemberList";

	// List<MethodResultDto> CancelPersoes(string session, long[] ChipPersoId,
	// string cancelReason);
	public static final String CANCEL_PERSO_BY_PERSOID = "/CancelPersoes";

	// List<MethodResultDto> LockPersoes(string session, long[] ChipPersoId,
	// string lockReason);
	public static final String LOCK_PERSO_BY_PERSOID = "/LockPersoes";

	// List<MethodResultDto> UnLockPersoes(string session, long[] ChipPersoId,
	// string unlockReason);
	public static final String UNLOCK_PERSO_BY_PERSOID = "/UnLockPersoes";

	// List<MethodResultDto> ExtendPerso(string session, long[] ChipPersoId,
	// DateTime expirationDate);
	public static final String EXTEND_PERSO_BY_PERSOID = "/ExtendPerso";

	// List<MethodResultDto> MarkBrokenCards(string session, long[]
	// CardChipIds);
	public static final String MARK_BROKEN_CARDS_BY_CARDCHIPID = "/MarkBrokenCards";

	// List<MethodResultDto> UnMarkBrokenCards(string session, long[]
	// CardChipIds);
	public static final String UNMARK_BROKEN_CARDS_BY_CARDCHIPID = "/UnMarkBrokenCards";

	// List<MethodResultDto> MarkLostCards(string session, long[] CardChipIds);
	public static final String MARK_LOST_CARDS_BY_CARDCHIPID = "/MarkLostCards";

	// List<MethodResultDto> UnMarkLostCards(string session, long[]
	// CardChipIds);
	public static final String UNMARK_LOST_CARDS_BY_CARDCHIPID = "/UnMarkLostCards";

	// List<SubOrgCustomerDTO> GetSubOrgList(string session, long orgId,
	// SubOrgFilterDto filter);
	public static final String GET_SUBORG_BY_ORGID = "/GetSubOrgList";

	// List<MemberCustomerDTO> GetMemberPersoList(string session, long orgId,
	// long subOrgId, PersoFilter filter);
	public static final String GET_MEMBERPERSO_BY_ORGID_SUBORGID = "/GetMemberPersoList";

	// List<MemberCustomerDTO> GetMemberList(string session, long subOrgId,
	// MemberFilter filter);
	public static final String GET_MEMBERLIST_BY_SUBORGID = "/GetMemberListBySubOrgId";

	// List<GroupDto> GetGroupList(string session, GroupFilterDto filter);
	public static final String GET_GROUP_LIST = "/GetGroupList";

	// GroupFunctionDto GetGroupById(string session, long groupId);
	public static final String GET_GROUP_BY_GROUPID = "/GetGroupById";

	// GroupCustomerDto AddGroup(string session, GroupCustomerDto group);
	public static final String ADD_GROUP = "/AddGroup";

	// int UpdateGroup(string session, GroupCustomerDto group);
	public static final String UPDATE_GROUP = "/UpdateGroup";

	// List<MethodResultDto> RemoveGroups(string session, long groupId);
	public static final String REMOVE_GROUP = "/RemoveGroups";

	// List<User> GetUserList(string session, UserFilterDto filter);
	public static final String GET_USER_LIST = "/GetUserList";

	// User GetUserById(string session, long userId);
	public static final String GET_USER_BY_USERID = "/GetUserById";

	// User AddUser(string session, User user);
	public static final String ADD_USER = "/AddUser";

	// int UpdateUser(string session, User user);
	public static final String UPDATE_USER = "/UpdateUser";

	// int ChangeUserGroup(string session, long userId, long newGroupId);
	public static final String CHANGE_USER_GROUP = "/ChangeUserGroup";

	// int ResetPassword(string session, long userId, string newPassword);
	public static final String RESET_PASSWORD = "/ResetPassword";

	// List<MethodResultDto> LockUsers(string session, long[] userIds);
	public static final String LOCK_USER = "/LockUsers";

	// List<MethodResultDto> UnLockUsers(string session, long[] userIds);
	public static final String UNLOCK_USER = "/UnLockUsers";

	// List<MethodResultDto> RemoveUsers(string session, long[] userIds);
	public static final String REMOVE_USER = "/RemoveUsers";

	// List<LoginHistoryDTO> GetLoginHistoryList(string session,
	// LoginHistoryFilterDto filter);
	public static final String GET_LOGIN_HISTORY = "/GetLoginHistoryList";

	// List<MemberMagneticPersoDTO> GetMemberPersoMagneticList(string session,
	// long orgId, long subOrgId, CardMagneticFilterDto filter);
	public static final String GET_MEMBER_PERSO_MAGNETIC_LIST = "/GetMemberPersoMagneticList"; 

	// int PresoCardMagnetic(string session, List<MagneticPersData>
	// cardPerDataList);
	public static final String PERSO_CARDMAGNETIC = "/PresoCardMagnetic"; 

	// ResultCheckCardDTO CheckAndGetPartnerDataToImportCard(string session,
	// long id, string serialnumbex, int cardtype, byte start, byte stop);
	public static final String CHECK_AND_GET_PARTNER_DATA_TO_IMPORT_CARD = "/CheckAndGetPartnerDataToImportCard";

	// int UpdateDataForCardBySerialAndPartnerId(string session, long id, string
	// serialnumber, int cardtype, int status);
	public static final String UPDATE_DATA_FOR_CARD_BY_SERIAL_AND_PARTNERID = "/UpdateDataForCardBySerialAndPartnerId";

	// DataToReadCardDTO GetKeyForReadCard(string session, string serialNumber,
	// int cardType, List<int> list);
	public static final String GET_KEY_FOR_READ_CARD = "/GetKeyForReadCard";

	// DataToWriteCardDTO CheckAndGetAppDataToPersoCard(string session, long
	// memberId, string serialNumber, int cardType, byte sectorData);
	public static final String CHECK_AND_GET_APP_DATA_TO_PERSO_CARD = "/CheckAndGetAppDataToPersoCard";

	
	public static final String CHECK_AND_GET_PERSO_DATA = "/CheckAndGetPersonData";
	
	// int ClearCardData(string session, string serialNumber);xong
	public static final String CLEAR_CARD_DATA = "/ClearCardData";

	// DataForReadCard GetDataToReadCard(string session, string serialNumber,
	// int cardType, String memberData);
	public static final String GET_DATA_TO_READ_CARD = "/GetDataToReadCard";

	// DataToWriteCardDTO GetDataToUpdateCard(string session, string
	// serialNumber, byte sectorStart);
	public static final String GET_DATA_TO_UPDATE_CARD = "/GetDataToUpdateCard";

	// int UpdateMemberAppOfPerso(string session, string serialNumber, string
	// lastUpdateDate);
	public static final String UPDATE_MEMBER_APP_OF_PERSO = "/UpdateMemberAppOfPerso";

	// DataToWriteCardDTO CheckAndGetAppDataToClearCard(string session, string
	// serialNumber, int cardType, byte sectorStart, byte sectorStop);
	public static final String CHECK_AND_GET_APP_DATA_TO_CLEAR_CARD = "/CheckAndGetAppDataToClearCard";

	// cai nay a da lam roi nhung khi e update ve thi lai ko co nen e lam lai
	public static final String POST_PERSO_DATA_4_GENERATE_CARD = "/PostPersoData4GenerateCard";

	// int SaveDataPresoCardMagnetic(string session, PersoMagneticCardInforDTO
	// data);
	public static final String SAVE_DATA_PERSO_CARD_MAGNETIC = "/SaveDataPresoCardMagnetic";

	// List<App> GetAppList(string session, long orgId, long subOrgId)
	public static final String GET_APP_DATA_LIST = "/GetAppDataList";

	// List<OrgCustomerDto> GetOrgList(string session, OrgFilterDto filter);
	public static final String GET_ORG_LIST = "/GetOrgList";

	// Organization GetOrgById(string session, long OrgId);
	public static final String GET_ORG_BY_ORG_ID = "/GetOrgById";

	// int AddOrg(string session, Organization org);
	public static final String ADD_ORG = "/AddOrg";

	// public int ImportMemberData(string session, List<Member> MemberList)
	public static final String IMPORT_MEMBER_DATA = "/ImportMemberData";

	// int UpdateOrg(string session, Organization org);
	public static final String UPDATE_ORG = "/UpdateOrg";

	// int DeleteOrg(string session, long orgid);
	public static final String DELETE_ORG = "/DeleteOrg";

	// int InsertApp(string session, App app);
	public static final String INSERT_APP = "/InsertApp";

	// int UpdateApp(string session, App app);
	public static final String UPDATE_APP = "/UpdateApp";

	// int DeleteApp(string session, long appId);
	public static final String DELETE_APP = "/DeleteApp";

	// public List<CardChip> GetCardChipList(string session, CardFilterDto filter)
	public static final String GET_CARD_CHIP_LIST = "/GetCardChipList";

	// List<MemberMagneticPersoDTO> GetMemberMagneticList(string session, long
	// orgId, long subOrgId, CardMagneticFilterDto filter);
	public static final String GET_MEMBER_MAGNETIC_LIST = "/GetMemberMagneticList";

	// List<MemberCustomerDTO> GetChangeStatus(string session, long[]
	// ChipPersoIds, byte status, string Reason);
	public static final String GET_CHANGE_STATUS = "/GetChangeStatus";

	// int InsertSugOrganization(String session, SubOrganization suborg);
	public static final String INSERT_SUBORGANIZATION = "/InsertSugOrganization";

	// int UpdateSugOrganization(String session, SubOrganization suborg);
	public static final String UPDATE_SUBORGANIZATION = "/UpdateSugOrganization";

	// int DeleteSugOrganization(String session, long suborgid);
	public static final String DELETE_SUBORGANIZATION = "/DeleteSugOrganization";

	// SubOrganization GetSubOrgByID(String session, long suborgid);
	public static final String GET_SUB_ORG_BY_ID = "/GetSubOrgByID";

	// int InsertMember(String session, Member mem)
	public static final String INSERT_MEMBER = "/InsertMember";

	// int UpdateMember(String session, Member mem)
	public static final String UPDATE_MEMBER = "/UpdateMember";

	// int DeleteMember(String session, long memid)
	public static final String DELETE_MEMBER = "/DeleteMember";

	// Member GetMemberByMemId(String session, long memid)
	public static final String GET_MEMBER_BY_MEM_ID = "/GetMemberByMemId";
	
	//List<SubOrganization> GetSubOrgListByOrgID(String session, long orgid, OrgFilterDto filter);
	public static final String GET_SUB_ORG_LIST_BY_ORG_ID = "/GetSubOrgListByOrgID";
	
	//List<CardStatisticsData> StatisticCardMagneticStatus(string session, long orgId, long subOrgId, int cardType);
	public static final String STATISTIC_CARD_MAGNETIC_STATUS = "/StatisticCardMagneticStatus";
	
	//App GetAppByAppId(String session, long appid)
	public static final String GET_APP_BY_APP_ID = "/GetAppByAppId";
	
	//List<CmsOrgCustomerDto> GetAllOrgList(string session);
	public static final String GET_ALL_ORG_LIST = "/GetAllOrgList";
	
	// List<CmsOrgCustomerDto> GetMasterList(string session);
	public static final String GET_MASTER_LIST = "/GetMasterList";
	
	// List<CmsOrgCustomerDto> GetPartnerList(string session, long masterId, OrgFilterDto filter);
	public static final String GET_PARTNER_LIST = "/GetPartnerList";
	
	//int InsertPartnerOfMaster(string session,long masterId, List<long> partnerIdList);
	public static final String INSERT_PARTNER_OF_MASTER = "/InsertPartnerOfMaster";
	
	// int InsertOrgAcquirer(string session, long masterId, List<long> partnerIdList);
	public static final String INSERT_ORG_ACQUIRER = "/InsertOrgAcquirer";
	
	//int DeletePartnerOfMaster(string session, long masterId, List<long> partnerIdList);
	public static final String DELETE_PARTNER_OF_MASTER = "/DeletePartnerOfMaster";
	
	// int DeleteOrgAcquirer(string session, long masterId, List<long> partnerIdList);
	public static final String DELETE_ORG_ACQUIRER = "/DeleteOrgAcquirer";
	
	//List<Acquirer> GetPartnerAcquirerList(String session)
	public static final String GET_PARTNER_ACQUIRER_LIST = "/GetPartnerAcquirerList";
	
	// List<Policy> GetPermissionList(string session,long userId)
	public static final String GET_PERMISSION_LIST = "/GetPermissionList";
	
	//List<MagneticPersonalization> GetChangeStatusMagnetic(string session, byte status, string Reason, List<long> persoIds);
	public static final String GET_CHANGE_STATUS_MAGNETIC = "/GetChangeStatusMagnetic";
	
	//List<CardStatisticsData> StatisticCardChipByStatus(string session);
	public static final String STATISTIC_CARDCHIP_BY_STATUS = "/StatisticCardChipByStatus";
	
	//List<MagneticListDTO> GetMagneticList(string session, long orgId, long subOrgId, CardMagneticFilterDto filter);
	public static final String GET_MAGNETIC_LIST = "/GetMagneticList";
	
	//List<CardmagneticDTO> GetChangeStatusPhysicalMagnetic(string session, byte status, string Reason, List<long> MagneticIds);
	public static final String GET_CHANGESTATUS_MAGNETIC = "/GetChangeStatusPhysicalMagnetic";
	
	//Clear Card Data, clear ChipPersonalization
	public static final String CLEAR_EMPTY_CARD = "/ClearEmptyCard";
	
	//Clear Card Chip, clear CardChip
	public static final String CLEAR_EMPTY_CARDCHIP = "/ClearEmptyCardChip";
	
	//Import dữ liệu từ file excel
	public static final String IMPORT_CARD_FROM_EXCEL = "/importlistcardfromexcel";
	
	//get list card chip for export
	public static final String GET_CARD_CHIP_LIST_EXPORT = "/GetCardChipListExport";
	public static final String GET_CARD_CHIP_LIST_BY_ORG_PARTNER = "/getcardchipbyorgpartner";
	
	//Device Manager
	public static final String INSERT_DEVICE_DOOR = "/InsertDeviceDoor";
	public static final String UPDATE_DEVICE_DOOR = "/UpdateDeviceDoor";
	public static final String DELETE_DEVICE_DOOR = "/DeleteDeviceDoor";
	public static final String GET_DEVICE_DOOR_BY_ID = "/GetDeviceDoorById";
	public static final String GET_DEVICE_DOOR_LIST = "/GetDeviceDoorList";
	
	// trang.vo
	// thong ke cham cong
	public static final String GET_MEMBER_BY_TOTAL_COUNT = "/getmemberlistbytotalcount";
	public static final String GET_MEMBER_COUNT = "/getmembercount";
	
	// Move Sub-Organization
	public static final String GET_LIST_SUBORG = "/getsuborg";
	public static final String GET_LIST_MEMBER = "/getmember";
	public static final String MOVE_MEMBER_SUBORG = "/movemembersuborg";
}

