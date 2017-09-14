using CommonHelper.Config;
using JavaCommunication;
using sTimeKeeping.Interface;
using sTimeKeeping.Java;

namespace sTimeKeeping.Factory {
    public class TimeKeepingColorConfigFactory {
        private static TimeKeepingColorConfigFactory instance = new TimeKeepingColorConfigFactory();
        public static TimeKeepingColorConfigFactory Instance {
            get {
                if (null == instance) {
                    instance = new TimeKeepingColorConfigFactory();
                }

                return instance;
            }
        }

        private TimeKeepingColorConfigFactory() {

        }

        public ITimeKeepingColorConfig GetChannel() {
            switch (SystemSettings.Instance.TypeComm) {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaTimeKeepingColorConfig.Instance;
                default:
                    return JavaTimeKeepingColorConfig.Instance;
            }
        }
    }
}
