using CommonHelper.Utils;
using System.Collections.Generic;
using System.Resources;

namespace sTimeKeeping.Model {
    public class TimeValue {
        public static int MINUTE = 0;
        public static int HOUR = 1;

        public static List<string> setTimeValue(ResourceManager rm) {
            List<string> listTime = new List<string>();

            listTime.Add(getLanguage(rm, "minute"));
            listTime.Add(getLanguage(rm, "hour"));

            return listTime;
        }

        public static string getLanguage(ResourceManager rm, string key) {
            string strValue = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, key);
            return strValue;
        }
    }
}
