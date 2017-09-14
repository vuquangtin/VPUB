using CommonHelper.Config;
using JavaCommunication;
using sTimeKeeping.Interface;
using sTimeKeeping.Java;

namespace sTimeKeeping.Factory {
    public class TimeKeepingGeneralConfigFactory {
        private static TimeKeepingGeneralConfigFactory instance = new TimeKeepingGeneralConfigFactory();
        public static TimeKeepingGeneralConfigFactory Instance {
            get {
                if (null == instance) {
                    instance = new TimeKeepingGeneralConfigFactory();
                }

                return instance;
            }
        }

        private TimeKeepingGeneralConfigFactory() { }

        public ITimeKeepingGeneralConfig GetChannel() {
            switch (SystemSettings.Instance.TypeComm) {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaTimeKeepingGeneralConfig.Instance;
                default:
                    return JavaTimeKeepingGeneralConfig.Instance;
            }
        }
    }
}
