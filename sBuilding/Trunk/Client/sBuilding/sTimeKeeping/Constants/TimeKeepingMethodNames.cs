namespace sTimeKeeping.Constants {
    /// <summary>
    /// TimeKeepingMethodNames
    /// </summary>
    public class TimeKeepingMethodNames
    {
        #region MONTHLY

        // MONTHLY
        public static string GET_SHIFT_BY_YEAR = @"gettimesheetbyyear";
        public static string GET_SHIFT_BY_MONTH = @"gettimesheetbymonth";
        public static string GET_SHIFT_BY_DAY = @"gettimesheetbydate";
        public static string GET_TIMEKEEPING_MONTHLY_REPORT = @"gettimekeepingmonthlyreport";
        public static string GET_TIMEKEEPING_MONTHLY_REPORT_LIST = @"gettimekeepingmonthlyreportlist";
        public static string GET_TIMEKEEPING_MONTHLY_REPORT_LIST_BY_DATE = @"gettimekeepingmonthlyreportlistbydate";
        public static string INSERT_TIMEKEEPING_MONTHLY_REPORT_BY_LIST_ID = @"inserttimekeepngmonthlyreportbylistid";
        public static string INSERT_TIMEKEEPING_MONTHLY_REPORT_DEFAULT = @"inserttimekeepngmonthlyreportdefault";

        #endregion

        #region SHIFT

        public static string INSERT_TIMEKEEPING_SHIFT = @"inserttimekeepingshift";
        public static string UPDATE_TIMEKEEPING_SHIFT = @"updatetimekeepingshift";
        public static string DELETE_TIMEKEEPING_SHIFT = @"eletetimekeepingshift";
        public static string GET_TIMEKEEPING_SHIFT_BY_SHIFTID = @"gettimekeepingshiftbyid";
        public static string GET_TIMEKEEPING_SHIFT_LIST_BY_FILTER = @"gettimekeepingshiftlistbyfilter";
        public static string GET_TIMEKEEPING_SHIFT_LIST = @"gettimekeepingshift";
        public static string Get_SHIFT_IMAGE_BY_SHIFTID = @"getShiftImageByShiftId";
        public static string INSERT_SHIFT_IMAGE = @"inserttimekeepingshiftimage";

        #endregion

        #region EVENT

        public static string INSERT_TIMEKEEPING_EVENT = @"inserttimekeepingevent";
        public static string INSERT_TIMEKEEPING_EVENT_LIST = @"inserttimekeepingeventlist";
        public static string INSERT_TIMEKEEPING_LIST_EVENT_MEMBER = @"inserttimekeepingeventmemberlist";
        public static string INSERT_TIMEKEEPING_EVENT_MEMBER_LIST_DTO = @"inserttimekeepingeventmemberlistdto";
        public static string UPDATE_TIMEKEEPING_EVENT = @"updatetimeKeepingevent";
        public static string DELETE_TIMEKEEPING_EVENT = @"deletetimeKeepingevent";
        public static string DELETE_TIMEKEEPING_EVENT_LIST = @"deletetimeKeepingeventlist";
        public static string DELETE_TIMEKEEPING_EVENT_MEMBER_LIST = @"deletetimeKeepingeventmemberlistbyid";
        public static string GET_TIMEKEEPING_EVENT_BY_EVENTID = @"gettimekeepingeventbyid";
        public static string GET_TIMEKEEPING_EVENT_LIST_BY_ORGID = @"gettimekeepingeventlistbyorgid";
        public static string GET_TIMEKEEPING_EVENT_LIST_BY_SUBORGID = @"gettimekeepingeventlistbysuborgid";
        public static string CHECK_CONFLICT_EVENT = @"checkconflictevent";
        public static string IMPORT_lIST_EVENT = @"importlistevent";

        public static string GET_TIMEKEEPING_EVENT_MEMBER_BY_EVENTID = @"gettimekeepingeventmemberlistbyeventid";

        #endregion

        #region TIMEKEEPING_DEVICE_CONFIG

        public static string INSERT_TIMEKEEPING_DEVICE_CONFIG = @"inserttimekeepingdeviceconfig";
        public static string UPDATE_TIMEKEEPING_DEVICE_CONFIG = @"updatetimekeepingdeviceconfig";
        public static string DELETE_TIMEKEEPING_DEVICE_CONFIG = @"deletetimekeepingdeviceconfig";
        public static string GET_TIMEKEEPING_DEVICE_CONFIG_BY_DECONFIGID = @"gettimekeepingdeviceconfigbyid";
        public static string INSERT_DEVICE_CONFIG_BY_ORG_ID = @"InsertDeviceConfigByOrgId";
        public static string DELETE_LIST_DEVICE_CONFIG = @"DeleteListDeviceConfig";
        public static string GET_LIST_DEVICECONFIG_BY_ORG_ID = @"GetListDeviceConfigByOrgId";
        public static string CHECK_DEVICE_IP_CONFIG = @"checkdeviceipconfig";

        #endregion

        #region TIMEKEEPING_TIME_CONFIG

        public static string INSERT_TIMEKEEPING_TIME_CONFIG = @"inserttimekeepingtimeconfig";
        public static string INSERT_TIMEKEEPING_LIST_TIME_CONFIG = @"inserttimekeepinglisttimeconfig";

        public static string UPDATE_TIMEKEEPING_TIME_CONFIG = @"updatetimekeepingtimeconfig";
        public static string DELETE_TIMEKEEPING_TIME_CONFIG = @"deletetimekeepingtimeconfig";
        public static string GET_TIMEKEEPING_TIME_CONFIG_BY_TICONFIG = @"gettimekeepingtimeconfigbyid";
        public static string GET_TIMEKEEPING_TIME_CONFIG_LIST_DAYOFWEEK = @"gettimekeepingtimeconfiglistbydayofweek";
        public static string GET_TIMEKEEPING_TIME_CONFIG_LIST_ORG_ID = @"gettimekeepingtimeconfiglistbyorgid";
        public static string GET_TIME_CONFIG_EVENT_CONFIG_BY_FILTER = @"gettimeconfigeventconfigbyfilter";

        #endregion

        #region TIMEKEEPING_USER_TIME_CONFIG
        // user time config
        public static string GET_TIMEKEEPING_USER_TIME_CONFIG_BY_ID = @"gettimekeepingusertimeconfigbyid";
        public static string GET_TIMEKEEPING_USER_TIME_CONFIG_LIST = @"gettimekeepingusertimeconfiglist";
        public static string INSERT_TIMEKEEPING_USER_TIME_CONFIG = @"inserttimekeepingusertimeconfig";
        public static string UPDATE_TIMEKEEPING_USER_TIME_CONFIG = @"updatetimekeepingusertimeconfig";
        public static string DELETE_TIMEKEEPING_USER_TIME_CONFIG = @"deletetimekeepingusertimeconfig";

        #endregion

        #region HOLIDAY_CONFIG
        // holiday_config
        public static string INSERT_TIMEKEEPING_HOLIDAY_CONFIG = @"inserttimekeepingholidayconfig";
        public static string UPDATE_TIMEKEEPING_HOLIDAY_CONFIG = @"updatetimekeepingholidayconfig";
        public static string DELETE_TIMEKEEPING_HOLIDAY_CONFIG = @"deletetimekeepingholidayconfig";
        public static string GET_TIMEKEEPING_HOLIDAY_CONFIG = @"gettimekeepingholidayconfigbyid";
        public static string CHECK_HOLIDAY = @"checkholiday";
        public static string FILTER_TIMEKEEPING_LIST_HOLIDAY_CONFIG_ORG_ID = @"filtertimekeepinglistholidaybyorgid";
        public static string GET_HOLIDAY_LIST_BY_ORGID_YEAR = @"getholidaybyorgidandyear";

        #endregion

        #region COLOR_CONFIG
        // color_config
        public static string UPDATE_TIMEKEEPING_COLOR_CONFIG = @"updatetimekeepingcolorconfig";
        public static string GET_TIMEKEEPING_COLOR_CONFIG = @"gettimekeepingcolorconfigbyid";
        public static string GET_TIMEKEEPING_LIST_COLOR_CONFIG_ORG_ID = @"gettimekeepinglistcolorbyorgid";

        #endregion

        #region GENERAL_CONFIG
        // general_config
        public static string UPDATE_TIMEKEEPING_GENERAL_CONFIG = @"updatetimekeepinggeneralconfig";
        public static string GET_TIMEKEEPING_GENERAL_CONFIG_ORG_ID = @"gettimekeepinggeneralconfigbyorgid";

        #endregion

        #region DAY_OFF_CONFIG
        // day_off_config
        public static string UPDATE_TIMEKEEPING_DAY_OFF_CONFIG = @"updatetimekeepingdayoffconfig";
        public static string INSERT_OR_UPDATE_DAY_OFF_MEMBER_ID = @"insertorupdatedayoffbylistmemberid";
        public static string DELETE_TIMEKEEPING_DAY_OFF_CONFIG = @"deletetimekeepingdayoffconfig";
        public static string GET_TIMEKEEPING_DAY_OFF_CONFIG = @"gettimekeepingdayoffconfigbyid";
        public static string GET_DAY_OFF_MEMBER_ID_DATE = @"getdayoffbymemberidanddate";
        public static string FILTER_TIMEKEEPING_LIST_DAY_OFF_CONFIG_SUB_ORG_ID = @"filtertimekeepinglistdayoffbysuborgid";
        public static string IMPORT_lIST_DAY_OFF = @"importlistdayoff";

        #endregion

        #region time_keeping_without_card
        // time_keeping_without_card
        public static string GET_LIST_CHIP_PERSONALIZATION_CUSTOM = @"getlistchipperscustom";
        public static string GET_LIST_MEMBER_CUSTOM = @"getlistmembercustom";

        #endregion

        #region load member
        // load member
        public static string GET_MEMBER = @"getmemberbyid";
        public static string GET_MEMBER_LIST_SUB_ORG_ID = @"getmemberlistbysuborgid";
        #endregion
    }
}
