using CommonHelper.Utils;
using System.Resources;

namespace sTimeKeeping.Model {
    // Quy định tên sự kiện
    public enum ColorEventId : long {
        stripe = 0,
        event_day = 1,
        day_work_time = 2,
        late = 3,
        off_half = 4,
        off_day = 5,
        holiday = 6,
        break_time = 7
    }
    public class ColorEventName {
        public static string getColorEventName(ColorEventId cen, ResourceManager rm) {
            switch (cen) {
                case ColorEventId.event_day:
                    return getLanguage(rm, "event_day");
                case ColorEventId.day_work_time:
                    return getLanguage(rm, "day_work_time");
                case ColorEventId.late:
                    return getLanguage(rm, "late");
                case ColorEventId.off_half:
                    return getLanguage(rm, "off_half");
                case ColorEventId.off_day:
                    return getLanguage(rm, "off_day");
                case ColorEventId.holiday:
                    return getLanguage(rm, "holiday");
                case ColorEventId.break_time:
                    return getLanguage(rm, "break_time");
                default:
                    return null;
            }
        }

        public static string getLanguage(ResourceManager rm, string key) {
            string strValue = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, key);
            return strValue;
        }
    }
}