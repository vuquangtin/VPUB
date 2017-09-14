using CommonHelper.Config;
using JavaCommunication;
using sTimeKeeping.Interface;
using sTimeKeeping.Java;

namespace sTimeKeeping.Factory {
    public class TimeKeepingDayOffConfigFactory {
        private static TimeKeepingDayOffConfigFactory instance = new TimeKeepingDayOffConfigFactory();
        public static TimeKeepingDayOffConfigFactory Instance {
            get {
                if (null == instance) {
                    instance = new TimeKeepingDayOffConfigFactory();
                }

                return instance;
            }
        }

        private TimeKeepingDayOffConfigFactory() { }

        public ITimeKeepingDayOffConfig GetChannel() {
            switch (SystemSettings.Instance.TypeComm) {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaTimeKeepingDayOffConfig.Instance;
                default:
                    return JavaTimeKeepingDayOffConfig.Instance;
            }
        }
    }
}
