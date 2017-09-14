using CommonHelper.Utils;
using System.Resources;

namespace sTimeKeeping.Model {
    // Quy định trạng thái ngày nghỉ
    public enum DOStatus : int {
        half_day_off = 1,
        full_day_off = 2,
    }
    class DayOffStatus {
        public static string getDayOffStatus(DOStatus status, ResourceManager rm) {
            switch (status) {
                case DOStatus.half_day_off:
                    return getLanguage(rm, "half_day_off");
                case DOStatus.full_day_off:
                    return getLanguage(rm, "full_day_off");
                default:
                    return "";
            }
        }

        public static string getLanguage(ResourceManager rm, string key) {
            string strValue = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, key);
            return strValue;
        }
    }
}
