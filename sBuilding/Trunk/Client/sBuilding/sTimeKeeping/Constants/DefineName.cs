using System;

namespace sTimeKeeping.Constants {
    public class DefineName {
        // menu name cho sTimekeeping
        public static readonly string MenuTimeKeeping = @"MenuTimeKeeping"; // @"Chấm công"
        public static readonly string MenuDeviceConfig = @"MenuDeviceConfig"; //@"Cấu hình thiết bị chấm công"
        public static readonly string MenuTimeConfig = @"MenuTimeConfig"; //@"Cấu hình thời gian chấm công"
        public static readonly string MenuUserTimeConfig = @"MenuUserTimeConfig"; //@"Cấu hình thời gian chấm công cho từng người"
        public static readonly string MenuHolidayConfig = @"MenuHolidayConfig"; //@"Cấu hình ngày lễ"
        public static readonly string MenuGeneralConfig = @"MenuGeneralConfig"; //@"Cấu hình chung"
        public static readonly string MenuDayOffConfig = @"MenuDayOffConfig"; //@"Cấu hình ngày nghỉ"
        public static readonly string MenuTimeEvent = @"MenuTimeEvent"; //@"Cấu hình sự kiện"
        public static readonly string MenuMonthStatistic = @"MenuMonthStatistic"; //@"Thống kê chấm công theo tháng"
        public static readonly string MenuUserStatistic = @"MenuUserStatistic"; //@"Thống kê chấm công theo cá nhân"
        public static readonly string MenuDateStatistic = @"MenuDateStatistic"; //@"Thống kê chấm công theo ngày"
        //public static readonly String MenuFormTimeKeeping = @"MenuFormTimeKeeping"; //@"Form Time Keeping"     // Đóng code để sau này có cần màn hình cảm ứng riêng
        public static readonly string MenuTimeKeepingWithoutCard = @"MenuTimeKeepingWithoutCard"; //@"Chấm công không cần thẻ"

        // component name cho sTimekeeping 
        // thêm mới cho chức năng chấm công
        public const string TimeKeeping = "TimeKeeping";
        public const string DeviceConfig = "DeviceConfig";
        public const string TimeConfig = "TimeConfig";
        public const string UserTimeConfig = "UserTimeConfig";
        public const string HolidayConfig = "HolidayConfig";
        public const string GeneralConfig = "GeneralConfig";
        public const string DayOffConfig = "DayOffConfig";
        public const string TimeEvent = "TimekeepingEvent";
        public const string UserStatistic = "UserStatistic";
        public const string MonthStatistic = "MonthStatistic";
        public const string DateStatistic = "DateStatistic";
        //public const string FormTimeKeeping = "FormTimeKeeping";      // Đóng code để sau này có cần màn hình cảm ứng riêng
        public const string TimeKeepingWithoutCard = "TimeKeepingWithoutCard";
    }
}
