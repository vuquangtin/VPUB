using CommonHelper.Config;
using JavaCommunication;
using sTimeKeeping.Interface;
using sTimeKeeping.Java;

namespace sTimeKeeping.Factory {
    public class TimeKeepingHolidayConfigFactory {
        private static TimeKeepingHolidayConfigFactory instance = new TimeKeepingHolidayConfigFactory();
        public static TimeKeepingHolidayConfigFactory Instance {
            get {
                if (null == instance) {
                    instance = new TimeKeepingHolidayConfigFactory();
                }

                return instance;
            }
        }

        private TimeKeepingHolidayConfigFactory() {

        }

        public ITimeKeepingHolidayConfig GetChannel() {
            switch (SystemSettings.Instance.TypeComm) {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaTimeKeepingHolidayConfig.Instance;
                default:
                    return JavaTimeKeepingHolidayConfig.Instance;
            }
        }
    }
}
