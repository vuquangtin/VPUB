using CommonHelper.Config;
using JavaCommunication;
using sNonResidentComponent.Interface;
using sNonResidentComponent.Java;

namespace sNonResidentComponent.Factory {
    public class NonResidentSubOrganizationFactory {
        private static NonResidentSubOrganizationFactory instance = new NonResidentSubOrganizationFactory();
        public static NonResidentSubOrganizationFactory Instance {
            get {
                if (null == instance) {
                    instance = new NonResidentSubOrganizationFactory();
                }

                return instance;
            }
        }

        private NonResidentSubOrganizationFactory() { }

        public INonResidentSubOrganization GetChannel() {
            switch (SystemSettings.Instance.TypeComm) {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaNonResidentSubOrganization.Instance;
                default:
                    return JavaNonResidentSubOrganization.Instance;
            }
        }
    }
}
