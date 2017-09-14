package com.sworld.saigonpearl.common;

import javax.ws.rs.core.MediaType;

public class SaigonPearlDefines {
	public static final String APPLICATION_JSON = MediaType.APPLICATION_JSON + "; charset=utf-8";

	public static final String Access = "/access";
	public static final String SaiGonPearl = "/SaiGonPearls";
	public static final int SAIGON_PEARL_CODE = 12121212;

	public static final String CHECK_AVAILABLE_CARD = "/checkAvailableCard";
	public static final String GET_DATA_PAYIN_CARD = "/GetDataPayInWriteToCard";
	public static final String UPDATE_STATUS_PAYIN_LOG = "/UpdateStatusPayIn";

	public static final String GET_DATA_PAYOUT_CARD = "/getDataPayOutCard";
	public static final String UPDATE_STATUS_PAYOUT_LOG = "/updateStatusPayOutLog";
	public static final String CLEAR_EMPTY_CARD = "/ClearEmptyCard";

	public static final String INSERT_CONFIG_APARTMENT = "/inserconfigapartment";
	public static final String UPDATE_CONFIG_APARTMENT = "/updateconfigapartment";
	public static final String DELETE_CONFIG_APARTMENT = "/deleteconfigapartment";
	public static final String GET_CONFIG_APARTMENT_BY_ID = "/getConfigapartmentbyid";
	public static final String GET_ALL_CONFIG_APARTMENT = "/getallConfigapartment";
	public static final String GET_CONFIG_APARTMENT_FILTER_LIST_BY_CONFIGID = "/getconfigapartmentfilterlistbymanacostsid";

	// File Excel
	public static final String INSERT_FILE_EXCEL = "/insertfileexcel";
	public static final String GET_MANAGER_COST_BY_SUBORGID = "/getManagerCostBySubOrgId";
	public static final String GET_MANAGER_COST_LIST_BY_SUBORGID = "/getManagerCostListBySubOrgId";


	public static final String ACCESS_PROCESS = "/AccessProcess";
	public static final String ACCESS_PROCESS_NOMAL = "/AccessProcessNomal";
	public static final String ACCESS_PROCESS_OBJECT_STRING = "/AccessProcessString";
	

	public static final String LOAD_ACCESS_CONFIG = "/LoadAccessConfig";
	public static final String UPDATE_ACCESS_CONFIG = "/UpdateAccessConfig";

	public static final String GET_DOOR_IN_LIST = "/GetDoorInList";
	public static final String GET_DOOR_IN_BY_ID = "/GetDoorInById";
	public static final String INSERT_DOOR_IN = "/InsertDoorIn";
	public static final String UPDATE_DOOR_IN = "/UpdateDoorIn";
	public static final String DELETE_DOOR_IN = "/DeleteDoorIn";

	public static final String GET_DOOR_OUT_LIST = "/GetDoorOutList";
	public static final String GET_DOOR_OUT_BY_ID = "/GetDoorOutById";
	public static final String INSERT_DOOR_OUT = "/InsertDoorOut";
	public static final String UPDATE_DOOR_OUT = "/UpdateDoorOut";
	public static final String DELETE_DOOR_OUT = "/DeleteDoorOut";
	public static final String GROUP_LIST_DEVICE = "/GroupListDevice";
	// TimeKeeping
	public static final String GET_TIMESHEET_BY_DATE = "/GetTimesheetByDate";
	public static final String GET_TIMESHEET_BY_YEAR = "/GetTimesheetByYear";
	public static final String GET_TIMESHEET_BY_MONTH = "/GetTimesheetByMonth";
	public static final String GET_MONTH = "/GetMonth";
	public static final String GET_YEAR = "/GetYear";
	public static final String GET_DAY = "/GetDay";

	// Access controll
	public static final String GET_DEVICEDOOR_GROUP_LIST = "/GetDeviceDoorGroupList";
	public static final String INSERT_DEVICEDOOR_GROUP = "/InsertDeviceDoorGroup";
	public static final String UPDATE_DEVICEDOOR_GROUP = "/UpdateDeviceDoorGroup";
	public static final String GET_DEVICEDOOR_GROUP_BY_ID = "/GetDeviceDoorGroupById";
	public static final String DELETE_DEVICEDOOR_GROUP = "/DeleteDoorGroupList";
	public static final String GET_DEVICE_DOOR_LIST_BY_GROUP_ID = "/GetDeviceDoorListByGroupId";
	public static final String GET_ALL_MEMBER = "/GetAllMember";
	public static final String INSERT_LIST_DEVICEDOOR_BY_GROUPID = "/InsertListDeviceDoorByGroupId";
	public static final String DELETE_LIST_DEVICEDOOR_BY_GROUPID = "/DeleteListDeviceDoorByGroupId";

	// role
	public static final String GET_PERSONALIZATION_LIST = "/GetPersonalizationList";
	public static final String GET_ROLE_LIST = "/GetRoleList";
	public static final String INSERT_ROLE = "/InsertRole";
	public static final String UPDATE_ROLE = "/UpdateRole";
	public static final String GET_ROLE_BY_ID = "/GetRoleById";
	public static final String DELETE_ROLE = "/DeleteRole";
	public static final String GET_LIST_MEMBER_BY_LIST_SUBORG_ID = "/getlistmemberbylistsuborgid";
	public static final String GET_PERSONALIZATION_BY_ROLE_ID = "/GetPersonalizationByRoleId";
	public static final String INSERT_PERSONALIZATION_BY_ROLEID = "/InsertPersonalizationByRoleId";

	public static final String DELETE_LIST_MEMBER_FROM_GROUP = "DeleteListMemberFromGroup";
	public static final String INSERT_ROLE_DEVICE_DOORGROUP = "InsertRoleDeviceDoorGroup";
	public static final String GET_DEVICEDOOR_GROUP_LIST_BY_ROLEID = "GetDeviceDoorGroupListByRoleId";
	public static final String DELETE_ROLE_DEVICE_DOOR_GROUP = "DeleteRoleDeviceDoorGroup";
}