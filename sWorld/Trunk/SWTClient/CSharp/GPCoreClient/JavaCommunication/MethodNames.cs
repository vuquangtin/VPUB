using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication
{
    public class MethodNames
    {
        public static readonly String LOGIN = @"login";
        public static readonly String GET_LOGOUT = @"logout";

        public static readonly String GET_MASTER_DATA_BY_KEY = @"GetMasterDataByKey";
        public static readonly String GET_PARTNER_DATA_BY_KEY = @"GetPartnerDataByKey";

        //public static readonly String GET_SUB_ORG_LIST_DATA_BY_ORGID = @"GetSubOrgListDataByOrgId";
        //public static readonly String GET_MEMBER_LIST_DATA_BY_SUBORGID = @"GetMemberListDataBySubOrgId";
        //public static readonly String GET_PERSO_LIST_DATA_BY_ORGID_SUBORGID = @"GetPersoListDataByOrgIdSubOrgId";
        //public static readonly String GET_AND_CHECK_PERSO_CARD = @"CheckAndGetDataToPersoCard";
        //public static readonly String GET_PERSO_CARD_CHIP = @"PersoCardChip";
        //public static readonly String GET_UPDATE_MEMBER_APP_OF_PERSO = @"UpdateMemberAppOfPerso";

        public static readonly String GET_PER_GENERATE_DATA = @"GetPreGenerateData";
        public static readonly String POST_GENERATE_CARD_DATA = @"PostGenerateCardData";
        public static readonly String POST_PERSO_CARD_MAGNETIC = @"PostPresoCardMagnetic";


        #region Master And Parner
        public static readonly String CHECK_ADN_GET_MASTERDATA_4_CARD_CHIP = @"CheckAndGetMasterDataToImportCard";
        public static readonly String UPDATE_CARD_DATA_OF_MASTER = @"UpdateDataForCardBySerialAndMasterId";

        public static readonly String CHECK_ADN_GET_PARTNERDATA_4_CARD_CHIP = @"CheckAndGetPartnerDataToImportCard";
        public static readonly String UPDATE_CARD_DATA_OF_PARTNER = @"UpdateDataForCardBySerialAndPartnerId";
        #endregion

        #region QUAN LY VONG DOI CUA THE

        public static readonly String GET_SUBORG_BY_ORGID = @"GetSubOrgList";
        public static readonly String GET_MEMBER_PERSO_LIST = @"GetMemberPersoList";
        public static readonly String GET_MEMBER_BY_SUBORGID = @"GetMemberList";
        public static readonly String GET_MEMBER_BY_CODE = @"getmemberbycode";
        
        public static readonly String GET_MEMBER_LIST = @"GetMemberListBySubOrgId";

        // Các trạng thái tương ứng với thành viên
        public static readonly String CANCEL_PERSOES = @"CancelPersoes";
        public static readonly String LOCK_PERSOES = @"LockPersoes";
        public static readonly String UNLOCK_PERSOES = @"UnLockPersoes";
        public static readonly String EXTEND_PERSO = @"ExtendPerso";

        // Các trạng thái tương ứng với thẻ
        public static readonly String MARK_BROKEN_CARDS = @"MarkBrokenCards";
        public static readonly String UNMARK_BROKEN_CARDS = @"UnMarkBrokenCards";
        public static readonly String MARK_LOST_CARDS = @"MarkLostCards";
        public static readonly String UNMARK_LOST_CARDS = @"UnMarkBrokenCards";

        public static readonly String GET_CARD_CHIP_LIST = @"GetCardChipList";
        public static readonly String GET_CARD_CHIP_LIST_EXPORT = @"GetCardChipListExport";
        public static readonly String GET_CARD_CHIP_LIST_BY_ORG_PARTNER = @"getcardchipbyorgpartner";

        public static readonly String GET_STATISTIC_CARD_CHIP_BY_STATUS = @"StatisticCardChipByStatus";
        public static readonly String GET_STATISTIC_CARD_CHIP_BY_PERSO_STATUS = @"StatisticCardChipByPersoStatus";
        public static readonly String CLEAR_EMPTY_CARD = @"ClearEmptyCard";
        public static readonly String IMPORT_lIST_CARD = @"importlistcardfromexcel";

        #endregion

        #region QUẢN TRỊ HỆ THỐNG

        public static readonly String GET_GROUP_LIST = @"GetGroupList";
        public static readonly String GET_GROUP_BY_ID = @"GetGroupById";
        public static readonly String ADD_GROUP = @"AddGroup";
        public static readonly String UPDATE_GROUP = @"UpdateGroup";
        public static readonly String REMOVE_GROUPS = @"RemoveGroups";

        public static readonly String GET_USER_LIST = @"GetUserList";
        public static readonly String GET_USER_BY_ID = @"GetUserById";
        public static readonly String ADD_USER = @"AddUser";
        public static readonly String UPDATE_USER = @"UpdateUser";
        public static readonly String CHANGE_USER_GROUP = @"ChangeUserGroup";
        public static readonly String CHANGE_PASSWORD = @"ChangePassword";
        public static readonly String RESET_PASSWORD = @"ResetPassword";
        public static readonly String LOCK_USERS = @"LockUsers";
        public static readonly String UNLOCK_USERS = @"UnLockUsers";
        public static readonly String REMOVE_USERS = @"RemoveUsers";
        public static readonly String GET_lOGIN_HISTORY_LIST = @"GetLoginHistoryList";
        public static readonly String GET_PERMISSION_LIST = @"GetPermissionList";

        #endregion

        #region QUẢN LÝ DANH SÁCH PHÁT HÀNH THẺ TỪ

        public static readonly String GET_SUB_ORG_LIST_MAGNETIC = @"GetSubOrgList";
        public static readonly String POST_MEMBER_LIST_PERSOMAGNETIC = @"GetMemberMagneticList";
        public static readonly String POST_LIST_MAGNETIC = @"GetMagneticList";

        # endregion

        #region  QUẢN LÝ THỐNG KÊ THẺ TỪ

        public static readonly String GET_STATISTIC_STATUS_MAGNETIC = @"StatisticCardMagneticStatus";
        public static readonly String GET_LOGICAL_STATUS_MAGNETIC = @"StatisticCardByLogicalStatus";

        #endregion

        #region QUẢN LÝ PHÁT HÀNH THẺ TỪ

        public static readonly String GET_MASTERINFO = @"GetMasterInfo";
        public static readonly String GET_PARTNERINFO = @"GetPartnerInfo";
        public static readonly String GET_GENERATE_CARD_DATA = @"GetPreGenerateData";
        public static readonly String POST_PERSO_DATA_4_GENERATE_CARD = @"PostPersoData4GenerateCard";

        #region THAY ĐỔI TRẠNG THÁI THẺ TỪ

        // Thay đổi trạng thái phát hành
        public static readonly String UPDATE_CARD_MAGNETIC_STATUS = @"GetChangeStatusMagnetic";

        // Thay đổi trạng thái vật lý
        public static readonly String UPDATE_CARD_MAGNETIC_PHYSICALSTATUS = @"GetChangeStatusPhysicalMagnetic";

        #endregion


        #region LƯU THÔNG TIN CÁ THẺ HÓA THẺ TỪ XUỐNG DATABSE

        public static readonly String POST_SAVE_PERSO_DATA_CARD_MAGNETIC = @"SaveDataPresoCardMagnetic";

        #endregion

        #endregion

        #region QUAN LY APPLICATION

        //APP DATA
        public static readonly String GET_APP_DATA_LIST = @"GetAppDataList";
        public static readonly String GET_APP_BY_ID = @"GetAppByAppId";
        public static readonly String INSERT_APP = @"InsertApp";
        public static readonly String UPDATE_APP = @"UpdateApp";
        public static readonly String DELETEAPP = @"DeleteApp";

        #endregion

        #region PHÁT HÀNH THẺ CHIP CHO THÀNH VIÊN

        //PERSO CARD
        public static readonly String CHECK_AND_GET_APP_DATA_TO_PERSO_CARD = @"CheckAndGetAppDataToPersoCard";

        public static readonly String CHECK_AND_GET_PERSO_PERSO = @"CheckAndGetPersonData";
        public static readonly String PERSO_CARD_CHIP = @"PersoCardChip";
        //READ CARD
        public static readonly String GET_KEY_FOR_READ_CARD = @"GetKeyForReadCard";
        public static readonly String GET_DATA_TO_READ_CARD = @"GetDataToReadCard";
        //UPDATE CARD
        public static readonly String GET_DATA_TO_UPDATE_CARD = @"GetDataToUpdateCard";
        public static readonly String UPDATE_MEMBER_APP_OF_PERSO = @"UpdateMemberAppOfPerso";
        //CLEAR CARD
        public static readonly String CLEAR_CARD_DATA = @"ClearCardData";
        public static readonly String CLEAR_CARD_EMPTY = @"ClearEmptyCardChip";
        public static readonly String CHECK_AND_GET_APP_DATA_TO_CLEAR_CARD = @"CheckAndGetAppDataToClearCard";

        // Thay đổi trạng thái thẻ chip

        public static readonly String UPDATE_CARD_CHIP_STATUS = @"GetChangeStatus";


        #endregion

        #region QUẢN LÝ ORAGANIZATION

        public static readonly String POST_ORG_LIST = @"GetOrgList";
        public static readonly String GET_ALL_ORG_LIST = @"GetAllOrgList";
        public static readonly String GET_MASTER_LIST = @"GetMasterList";
        public static readonly String GET_PARTNER_LIST = @"GetPartnerList";
        public static readonly String GET_PARTNER_ACQUIRER_LIST = @"GetPartnerAcquirerList";

        public static readonly String INSERT_PARTNER_OF_MASTER = @"InsertPartnerOfMaster";
        public static readonly String INSERT_ORG_ACQUIRER = @"InsertOrgAcquirer";

        public static readonly String DELETE_PARTNER_OF_MASTER = @"DeletePartnerOfMaster";
        public static readonly String DELETE_ORG_ACQUIRER = @"DeleteOrgAcquirer";

        public static readonly String GET_ORG_BY_ID = @"GetOrgById";
        public static readonly String ADD_ORG = @"AddOrg";
        public static readonly String UPDATE_ORG = @"UpdateOrg";
        public static readonly String REMOVE_ORG = @"DeleteOrg";

        public static readonly String POST_SUB_ORG_LIST = @"GetSubOrgListByOrgID";
        public static readonly String GET_SUB_ORG_BY_ID = @"GetSubOrgByID";
        public static readonly String ADD_SUB_ORG = @"InsertSugOrganization";
        public static readonly String UPDATE_SUB_ORG = @"UpdateSugOrganization";
        public static readonly String REMOVE_SUB_ORG = @"DeleteSugOrganization";

        public static readonly String IMPORT_MEMBER_DATA = @"ImportMemberData";

        public static readonly String GET_MEMBER_BY_ID = @"GetMemberByMemId";
        public static readonly String ADD_MEMBER = @"InsertMember";
        public static readonly String UPDATE_MEMBER = @"UpdateMember";
        public static readonly String REMOVE_MEMBER = @"DeleteMember";
        public static readonly String GET_MEMBER_BY_TOTAL_COUNT = @"getmemberlistbytotalcount";
        public static readonly String GET_MEMBER_COUNT = @"getmembercount";

        public static readonly String GET_MEM_RELATIVE_BY_ID = @"GetMemberRelativeById";
        public static readonly String INSERT_MEM_RELATIVE = @"InsertMemberRelative";
        public static readonly String UPDATE_MEM_RELATIVE = @"UpdateMemberRelative";
        public static readonly String DELETE_MEM_RELATIVE = @"DeleteMemberRelative";
        public static readonly String GET_ALL_MEM_RELATIVE = @"GetMemberRelativeByMemberId";

        #endregion

        #region ATTENDANCE

        //insert Attendance 
        public static String INSERT_ATTENDANCE = @"InsertAttendance";

        //update Attendance 
        public static String UPDATE_ATTENDANCE = @"UpdateAttendance";

        //delete Attendance 
        public static String DELETE_ATTENDANCE = @"DeleteAttendance";

        //get all Attendance 
        public static String GET_ALL_ATTENDANCE = @"GetAllAttendance";

        public static String GET_ATTENDANCE_BY_ID = @"GetAttendanceById";

        //get by memberId Attendance 
        public static String GET_BY_MEMBER_ID_ATTENDANCE = @"GetByMemberIdAttendance";

        //get by memberId and dateOut Attendance 
        public static String GET_BY_MEMBER_ID_AND_DATE_OUT_ATTENDANCE = @"GetByMemberIdAndDateOutAttendance";

        #endregion

        #region VOUCHERGIFT

        //insert
        public static String INSERT_VOUCHER = @"InsertVourcher";

        //update
        public static String UPDATE_VOUCHER = @"UpdateVourcher";

        //delete
        public static String DELETE_VOUCHER = @"DeleteVourcher";

        //get all 
        public static String GET_ALL_VOUCHER = @"GetAllVourcher";

        //get by Id GetVourcherByVourcherId
        public static String GET_ALLVOUCHER_BY_SUBORG_ID_VOUCHER = @"GetAllVourcherBySubOrgId";

        //get by Id  GetVourcherByVourcherId
        public static String GET_VOUCHER_BY_VOUCHER_ID = @"GetVourcherByVourcherId";

        //get by Id  GetVourcherByVourcherId
        public static String GET_VOUCHER_BY_VOUCHER_FILTER = @"GetVourcherByVourcherFiler";

        //get by Id  GetVourcherByVourcherId
        public static String GET_VOUCHER_BY_VOUCHER_FILTER_ID = @"GetVoucherFilterListByOrgID";

        //get by Id  GetVourcherByVourcherId
        public static String GET_VOUCHER_BY_VOUCHER_SUB_FILTER_ID = @"GetVoucherFilterListByVoucherID";

        //get by Id  GetVourcherByVourcherId
        public static String GET_VOUCHERLIST_BY_VOUCHER_ID = @"GetVoucherListByVoucherID";

        //get by Id  GetVourcherByVourcherId
        public static String    INSERT_VOUCHER_MOBILE_PERSON = @"InsertVoucherMobilePerson";

        //get by Id  GetVourcherByVourcherId
        public static String REMOVE_VOUCHER_MOBILE_PERSON = @"RemoveVoucherMobilePerson";
        //get by memberId and dateOut Attenda
        //public static String GET_BY_MEMBER_ID_AND_DATE_OUT_ATTENDANCE = @"GetByMemberIdAndDateOutAttendance";

        #endregion

        #region eCash
                                    
        
        public static String VALIDATE_CARD = @"checkAvailableCard";
        public static String getGroupItemByConfig = @"GetItemByConfig";
        //pay IN   
        public static String GET_DATA_PAYIN_WRITE_TO_CARD = @"GetDataPayInWriteToCard";
        public static String UPDATE_STATUS_PAYIN = @"UpdateStatusPayIn";
        //pay IN

        //pay OUT
        public static String GET_DATA_PAYOUT_WRITE_TO_CARD = @"getDataPayOutCard";
        public static String UPDATE_STATUS_PAYOUT = @"updateStatusPayOutLog";
        //pay OUT

        //insert card config
        public static String INSERT_ECASHCONFIG = @"InsertConfig";

        //update card config
        public static String UPDATE_ECASHCONFIG = @"UpdateConfig";

        //delete card config
        public static String DELETE_ECASHCONFIG = @"DeleteConfig";

        //get all  card config
        public static String GET_ALL_ECASHCONFIG = @"GetAllConfig";
        
        //get by Id card config
        public static String GET_ECASHCONFIG_BY_ID = @"GetConfigByCofigId";
        //
        public static String GetConfigFilterListByConfigId = @"GetConfigFilterListByConfigId";



        //begin group item
        //insert card group item
        public static String INSERT_ECASHGROUP = @"InsertGroupItem";

        //update card group item
        public static String UPDATE_ECASHGROUP = @"UpdateGroupItem";

        //delete card group item
        public static String DELETE_ECASHGROUP = @"DeleteGroupItem";

        //get all  card group item
        public static String GET_ALL_ECASHGROUP = @"GetAllGroupItem";
        //
        public static String GetGroupItemByGroupItemId = @"GetGroupItemByGroupItemId";

        //get by Id  get group by OrgId
        public static String GetGroupItemFilterListByGroupId = @"GetGroupItemFilterListByGroupId";
        //end group item


        //BEGIN ITEM
        //insert card item
        public static String INSERT_ECASHITEM = @"InsertItem";

        //update card item
        public static String UPDATE_ECASHITEM = @"UpdateItem";

        //delete card item
        public static String DELETE_ECASHITEM = @"DeleteItem";

        //get all  card item
        public static String GET_ALL_ECASHITEM = @"GetAllItem";
        //
        public static String GetItemByItemId = @"GetItemByItemId";
        //
        public static String GetItemByGroupItemId = @"GetItemByGroupItemId";
        //                                                  
        public static String GetItemFilterListByGroupId = @"GetItemFilterListByGroupId";
        //END ITEM
        //
        public static String GetPayInRequestFilterByPayInRequestId = @"GetPayInRequestFilterByPayInRequestId";
        //
        //
        public static String GetPayOutRequestFilterByPayOutRequestId = @"GetPayOutRequestFilterByPayOutRequestId";
        //
        #endregion

        #region Begin Config Apartment

        //insert card config
        public static String INSERT_CONFIG_APARTMENT = @"inserconfigapartment";

        //update card config
        public static String UPDATE_CONFIG_APARTMENT = @"updateconfigapartment";

        //delete card config
        public static String DELETE_CONFIG_APARTMENT = @"deleteconfigapartment";

        //
        public static String GET_CONFIG_APARTMENT_BY_ID = @"getConfigapartmentbyid";
        //
        public static String GET_All_CONFIG_APARTMENT = @"getallConfigapartment";
        //
        public static String GET_CONFIG_APARTMENT_FILTER_LIST_BY_MANACOSTS_ID = @"getconfigapartmentfilterlistbymanacostsid";
        //end group item

        //fILE

        public static String INSERT_FILE_EXCEL = @"insertfileexcel";
        public static String GET_MANAGER_COST_BY_SUBORGID = @"getManagerCostBySubOrgId";
        public static String GET_MANAGER_COST_LIST_BY_SUBORGID = @"getManagerCostListBySubOrgId";
        #endregion end Config Apartment

        #region Access

        public static String GET_DEVICE_DOOR_LIST = @"GetDeviceDoorList";
        public static String GET_DEVICE_DOOR_BY_ID = @"GetDeviceDoorById";
        public static String INSERT_DEVICE_DOOR = @"InsertDeviceDoor";
        public static String UPDATE_DEVICE_DOOR = @"UpdateDeviceDoor";
        public static String DELETE_DEVICE_DOOR = @"DeleteDeviceDoor";


        public static String ACCESS_PROCESS = @"AccessProcess";
        public static String LOAD_ACCESS_CONFIG = @"LoadAccessConfig";
	    public static String UPDATE_ACCESS_CONFIG = @"UpdateAccessConfig";

        public static String GET_DOOR_OUT_LIST = @"GetDoorOutList";
        public static String GET_DOOR_OUT_BY_ID = @"GetDoorOutById";
        public static String GROUP_LIST_DEVICE = @"GroupListDevice";

        #endregion

        #region TimeKeeping

        public static String GET_DOOR_OUT_YEAR = @"GetTimesheetByYear";
        public static String GET_DOOR_OUT_MONTH = @"GetTimesheetByMonth";
        public static String GET_DOOR_OUT_DAY = @"GetTimesheetByDate";

        #endregion

        // Move Sub-Organization
        public static readonly string GET_LIST_SUBORG = @"getsuborg";
	    public static readonly string GET_LIST_MEMBER = @"getmember";
	    public static readonly string MOVE_MEMBER_SUBORG = @"movemembersuborg";
    }
}
