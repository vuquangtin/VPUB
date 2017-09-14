package com.sworld.timekeeping.common;

import javax.ws.rs.core.MediaType;

public class TimeKeepingDefines {
	public static final String APPLICATION_JSON = MediaType.APPLICATION_JSON + "; charset=utf-8";

	public static final String TIMEKEEPING_IMAGE_DIR = "/ImageTimeKeeping";

	public static final String TIMEKEEPINGMANAGER = "/timekeepingmgt";
	public static final String TIMEKEEPINGSHIFTMANAGER = "/timekeepingshiftmgt";
	public static final String TIMEKEEPINGEVENTMANAGER = "/timekeepingeventmgt";
	public static final String TIMEKEEPINGCONFIGMANAGER = "/timekeepingconfigmgt";
	public static final String TIMEKEEPINGHOLIDAYMANAGER = "/timekeepingholidaymgt";
	public static final String TIMEKEEPINGCOLORMANAGER = "/timekeepingcolormgt";
	public static final String TIMEKEEPINGGENERALCONFIGMANAGER = "/timekeepinggeneralconfigmgt";
	public static final String TIMEKEEPINGDAYOFFCONFIGMANAGER = "/timekeepingdayoffconfigmgt";
	public static final String TIMEKEEPINGFORMTIMEKEEPINGMANAGER = "/timekeepingformtimekeepingmgt";

	// load member
	public static final String GET_MEMBER = "/getmemberbyid";
	public static final String GET_MEMBER_LIST_SUB_ORG_ID = "/getmemberlistbysuborgid";

	// timeKeeping
	public static final String GET_TIMESHEET_BY_DATE = "/gettimesheetbydate";
	public static final String GET_TIMESHEET_BY_YEAR = "/gettimesheetbyyear";
	public static final String GET_TIMESHEET_BY_MONTH = "/gettimesheetbymonth";
	public static final String GET_TIMEKEEPING_MONTHLY_REPORT = "/gettimekeepingmonthlyreport";
	public static final String GET_TIMEKEEPING_MONTHLY_REPORT_LIST = "/gettimekeepingmonthlyreportlist";
	public static final String GET_TIMEKEEPING_MONTHLY_REPORT_LIST_BY_DATE = "/gettimekeepingmonthlyreportlistbydate";
	public static final String INSERT_TIMEKEEPING_MONTHLY_REPORT_DEFAULT = "/inserttimekeepngmonthlyreportdefault";
	public static final String INSERT_TIMEKEEPING_MONTHLY_REPORT_BY_LIST_ID = "/inserttimekeepngmonthlyreportbylistid";
	public static final String UPDATE_TIMEKEEPING_MONTHLY_REPORT_BY_MONTH = "/updatetimekeepngmonthlyreportbymonth";

	// shift
	public static final String GET_TIMEKEEPING_SHIFT = "/gettimekeepingshiftbyid";
	public static final String GET_TIMEKEEPING_SHIFT_LIST_BY_FILTER = "/gettimekeepingshiftlistbyfilter";
	public static final String GET_TIMEKEEPING_SHIFT_LIST = "/gettimekeepingshift";
	public static final String Get_SHIFT_IMAGE_BY_SHIFTID = "/getShiftImageByShiftId";
	public static final String INSERT_TIMEKEEPING_SHIFT = "/inserttimekeepingshift";
	public static final String INSERT_TIMEKEEPING_SHIFT_STRING = "/inserttimekeepingshiftstring";
	public static final String INSERT_SHIFT_IMAGE = "/inserttimekeepingshiftimage";
	public static final String INSERT_SHIFT_IMAGE_STRING = "/inserttimekeepingshiftimagestring";
	public static final String UPDATE_TIMEKEEPING_SHIFT = "/updatetimekeepingshift";
	public static final String DELETE_TIMEKEEPING_SHIFT = "/eletetimekeepingshift";

	// event
	public static final String GET_TIMEKEEPING_EVENT_BY_EVENTID = "/gettimekeepingeventbyid";
	public static final String GET_TIMEKEEPING_EVENT_LIST_BY_ORGID = "/gettimekeepingeventlistbyorgid";
	public static final String GET_TIMEKEEPING_EVENT_LIST_BY_SUBORGID = "/gettimekeepingeventlistbysuborgid";
	public static final String INSERT_TIMEKEEPING_EVENT = "/inserttimekeepingevent";
	public static final String INSERT_TIMEKEEPING_EVENT_LIST = "/inserttimekeepingeventlist";
	public static final String UPDATE_TIMEKEEPING_EVENT = "/updatetimeKeepingevent";
	public static final String DELETE_TIMEKEEPING_EVENT = "/deletetimeKeepingevent";
	public static final String DELETE_TIMEKEEPING_EVENT_LIST = "/deletetimeKeepingeventlist";
	public static final String GET_TIMEKEEPING_EVENT_LIST_BY_MEMID = "/gettimekeepingeventbymemberid";
	public static final String CHECK_CONFLICT_EVENT = "/checkconflictevent";
	public static final String IMPORT_lIST_EVENT = "/importlistevent";

	// eventmember
	public static final String GET_TIMEKEEPING_EVENT_MEMBER_LIST_BY_EVENTID = "/gettimekeepingeventmemberlistbyeventid";
	// xoa list eventmember bang list id eventmember
	public static final String DELETE_EVENT_MEMBER_LIST = "/deletetimeKeepingeventmemberlistbyid";
	// insert event member
	public static final String INSERT_TIMEKEEPING_EVENT_MEMBER_LIST = "/inserttimekeepingeventmemberlist";
	// gui len list member theo event
	public static final String INSERT_TIMEKEEPING_EVENT_MEMBER_LIST_DTO = "/inserttimekeepingeventmemberlistdto";
	// get len danh sach event theo filter
	public static final String GET_TIME_CONFIG_EVENT_CONFIG_BY_FILTER = "/gettimeconfigeventconfigbyfilter";

	// device_config
	public static final String GET_TIMEKEEPING_DEVICE_CONFIG = "/gettimekeepingdeviceconfigbyid";
	public static final String INSERT_TIMEKEEPING_DEVICE_CONFIG = "/inserttimekeepingdeviceconfig";
	public static final String UPDATE_TIMEKEEPING_DEVICE_CONFIG = "/updatetimekeepingdeviceconfig";
	public static final String DELETE_TIMEKEEPING_DEVICE_CONFIG = "/deletetimekeepingdeviceconfig";
	public static final String INSERT_TIMEKEEPING_DEVICE_CONFIG_BY_ORG_ID = "/InsertDeviceConfigByOrgId";
	public static final String GET_LIST_DEVICECONFIG_BY_ORG_ID = "/GetListDeviceConfigByOrgId";
	public static final String DELETE_LIST_DEVICE_CONFIG = "/DeleteListDeviceConfig";
	public static final String CHECK_DEVICE_IP_CONFIG = "/checkdeviceipconfig";

	// time_config
	public static final String GET_TIMEKEEPING_TIME_CONFIG = "/gettimekeepingtimeconfigbyid";
	public static final String INSERT_TIMEKEEPING_TIME_CONFIG = "/inserttimekeepingtimeconfig";
	public static final String INSERT_TIMEKEEPING_LIST_TIME_CONFIG = "/inserttimekeepinglisttimeconfig";
	public static final String UPDATE_TIMEKEEPING_TIME_CONFIG = "/updatetimekeepingtimeconfig";
	public static final String DELETE_TIMEKEEPING_TIME_CONFIG = "/deletetimekeepingtimeconfig";
	public static final String GET_TIMEKEEPING_TIME_CONFIG_LIST_DAYOFWEEK = "/gettimekeepingtimeconfiglistbydayofweek";
	public static final String GET_TIMEKEEPING_TIME_CONFIG_LIST_ORG_ID = "/gettimekeepingtimeconfiglistbyorgid";

	// user time config
	public static final String GET_TIMEKEEPING_USER_TIME_CONFIG_BY_ID = "/gettimekeepingusertimeconfigbyid";
	public static final String GET_TIMEKEEPING_USER_TIME_CONFIG_LIST = "/gettimekeepingusertimeconfiglist";
	public static final String INSERT_TIMEKEEPING_USER_TIME_CONFIG = "/inserttimekeepingusertimeconfig";
	public static final String UPDATE_TIMEKEEPING_USER_TIME_CONFIG = "/updatetimekeepingusertimeconfig";
	public static final String DELETE_TIMEKEEPING_USER_TIME_CONFIG = "/deletetimekeepingusertimeconfig";

	// holiday_config
	public static final String INSERT_TIMEKEEPING_HOLIDAY_CONFIG = "/inserttimekeepingholidayconfig";
	public static final String UPDATE_TIMEKEEPING_HOLIDAY_CONFIG = "/updatetimekeepingholidayconfig";
	public static final String DELETE_TIMEKEEPING_HOLIDAY_CONFIG = "/deletetimekeepingholidayconfig";
	public static final String GET_TIMEKEEPING_HOLIDAY_CONFIG = "/gettimekeepingholidayconfigbyid";
	public static final String CHECK_HOLIDAY = "/checkholiday";
	public static final String FILTER_TIMEKEEPING_LIST_HOLIDAY_CONFIG_ORG_ID = "/filtertimekeepinglistholidaybyorgid";
	public static final String GET_HOLIDAY_LIST_BY_ORGID_YEAR = "/getholidaybyorgidandyear";

	// color_config
	public static final String UPDATE_TIMEKEEPING_COLOR_CONFIG = "/updatetimekeepingcolorconfig";
	public static final String GET_TIMEKEEPING_COLOR_CONFIG = "/gettimekeepingcolorconfigbyid";
	public static final String GET_TIMEKEEPING_LIST_COLOR_CONFIG_ORG_ID = "/gettimekeepinglistcolorbyorgid";

	// general_config
	public static final String UPDATE_TIMEKEEPING_GENERAL_CONFIG = "/updatetimekeepinggeneralconfig";
	public static final String GET_TIMEKEEPING_GENERAL_CONFIG_ORG_ID = "/gettimekeepinggeneralconfigbyorgid";

	// day_off_config
	public static final String UPDATE_TIMEKEEPING_DAY_OFF_CONFIG = "/updatetimekeepingdayoffconfig";
	public static final String INSERT_OR_UPDATE_DAY_OFF_MEMBER_ID = "/insertorupdatedayoffbylistmemberid";
	public static final String DELETE_TIMEKEEPING_DAY_OFF_CONFIG = "/deletetimekeepingdayoffconfig";
	public static final String GET_TIMEKEEPING_DAY_OFF_CONFIG = "/gettimekeepingdayoffconfigbyid";
	public static final String GET_DAY_OFF_MEMBER_ID_DATE = "/getdayoffbymemberidanddate";
	public static final String FILTER_TIMEKEEPING_LIST_DAY_OFF_CONFIG_SUB_ORG_ID = "/filtertimekeepinglistdayoffbysuborgid";
	public static final String IMPORT_lIST_DAY_OFF = "/importlistdayoff";
	
	// form_time_keeping
	public static final String GET_LIST_CHIP_PERSONALIZATION_CUSTOM = "/getlistchipperscustom";
	public static final String GET_LIST_MEMBER_CUSTOM = "/getlistmembercustom";
}