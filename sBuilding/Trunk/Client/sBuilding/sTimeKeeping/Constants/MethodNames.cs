using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Constants
{
   public class MethodNames
    {  
       #region TimeKeeping

        public static String GET_SHIFT_BY_YEAR = @"GetTimesheetByYear";
        public static String GET_SHIFT_BY_MONTH = @"GetTimesheetByMonth";
        public static String GET_SHIFT_BY_DAY = @"GetTimesheetByDate";

        public static String INSERT_TIMEKEEPING_SHIFT = @"InsertTimeKeepingShift";
        public static String UPDATE_TIMEKEEPING_SHIFT = @"UpdateTimeKeepingShift";
        public static String DELETE_TIMEKEEPING_SHIFT = @"DeleteTimeKeepingShift";
        public static String GET_TIMEKEEPING_SHIFT_BY_SHIFTID = @"GetTimeKeepingShiftByShiftId";

        public static String INSERT_TIMEKEEPING_EVENT = @"InsertTimeKeepingEvent";
        public static String UPDATE_TIMEKEEPING_EVENT = @"UpdateTimeKeepingEvent";
        public static String DELETE_TIMEKEEPING_EVENT = @"DeleteTimeKeepingEvent";
        public static String GET_TIMEKEEPING_EVENT_BY_EVENTID = @"GetTimeKeepingEventByEventId";

        public static String INSERT_TIMEKEEPING_DEVICE_CONFIG = @"InsertTimeKeepingDeviceConfig";
        public static String UPDATE_TIMEKEEPING_DEVICE_CONFIG = @"UpdateTimeKeepingDeviceConfig";
        public static String DELETE_TIMEKEEPING_DEVICE_CONFIG = @"DeleteTimeKeepingDeviceConfig";
        public static String GET_TIMEKEEPING_DEVICE_CONFIG_BY_DECONFIGID = @"GetTimeKeepingDeviceByDeConfigId";

        public static String INSERT_TIMEKEEPING_TIME_CONFIG = @"InsertTimeKeepingTimeConfig";
        public static String UPDATE_TIMEKEEPING_TIME_CONFIG = @"UpdateTimeKeepingTimeConfig";
        public static String DELETE_TIMEKEEPING_TIME_CONFIG = @"DeleteTimeKeepingTimeConfig";
        public static String GET_TIMEKEEPING_TIME_CONFIG_BY_TICONFIG = @"GetTimeKeepingTimeConfigByTiConfigId";
        #endregion
    }
}
