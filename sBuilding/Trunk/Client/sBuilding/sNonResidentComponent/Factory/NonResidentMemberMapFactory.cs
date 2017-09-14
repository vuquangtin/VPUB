using CommonHelper.Config;
using JavaCommunication;
using sNonResidentComponent.Interface;
using sNonResidentComponent.Java;

namespace sNonResidentComponent.Factory {
    public class NonResidentMemberMapFactory {
        private static NonResidentMemberMapFactory instance = new NonResidentMemberMapFactory();
        public static NonResidentMemberMapFactory Instance {
            get {
                if (null == instance) {
                    instance = new NonResidentMemberMapFactory();
                }

                return instance;
            }
        }

        private NonResidentMemberMapFactory() { }

        public INonResidentMemberMap GetChannel() {
            switch (SystemSettings.Instance.TypeComm) {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaNonResidentMemberMap.Instance;
                default:
                    return JavaNonResidentMemberMap.Instance;
            }
        }
    }
}
