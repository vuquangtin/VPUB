using CommonHelper.Config;
using JavaCommunication;
using sTimeKeeping.Interface;
using sTimeKeeping.Java;

namespace sTimeKeeping.Factory {
    public class TimeKeepingFormTimeKeepingFactory {
        private static TimeKeepingFormTimeKeepingFactory instance = new TimeKeepingFormTimeKeepingFactory();
        public static TimeKeepingFormTimeKeepingFactory Instance {
            get {
                if (null == instance) {
                    instance = new TimeKeepingFormTimeKeepingFactory();
                }

                return instance;
            }
        }

        private TimeKeepingFormTimeKeepingFactory() { }

        public ITimeKeepingFormTimeKeeping GetChannel() {
            switch (SystemSettings.Instance.TypeComm) {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaTimeKeepingFormTimeKeeping.Instance;
                default:
                    return JavaTimeKeepingFormTimeKeeping.Instance;
            }
        }
    }
}
