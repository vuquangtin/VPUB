using CommonHelper.Config;
using JavaCommunication;
using sNonResidentComponent.Interface;
using sNonResidentComponent.Java;

namespace sNonResidentComponent.Factory {
    public class NonResidentOrganizationFactory {
        private static NonResidentOrganizationFactory instance = new NonResidentOrganizationFactory();
        public static NonResidentOrganizationFactory Instance {
            get {
                if (null == instance) {
                    instance = new NonResidentOrganizationFactory();
                }

                return instance;
            }
        }

        private NonResidentOrganizationFactory() { }

        public INonResidentOrganization GetChannel() {
            switch (SystemSettings.Instance.TypeComm) {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaNonResidentOrganization.Instance;
                default:
                    return JavaNonResidentOrganization.Instance;
            }
        }
    }
}
