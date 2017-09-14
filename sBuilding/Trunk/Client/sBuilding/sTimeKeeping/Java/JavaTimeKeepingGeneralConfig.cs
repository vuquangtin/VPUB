using sTimeKeeping.Interface;
using sTimeKeeping.JavaComunication;
using sTimeKeeping.Model;

namespace sTimeKeeping.Java {
    public class JavaTimeKeepingGeneralConfig : ITimeKeepingGeneralConfig {
        private static JavaTimeKeepingGeneralConfig instance = new JavaTimeKeepingGeneralConfig();
        public static JavaTimeKeepingGeneralConfig Instance {
            get {
                if (null == instance) {
                    instance = new JavaTimeKeepingGeneralConfig();
                }

                return instance;
            }
        }

        private JavaTimeKeepingGeneralConfig() { }

        public GeneralConfig updateGeneralConfig(string session, GeneralConfig gConfig) {
            return CommunicationTimeKeepingGeneralConfig.Instance.updateGeneralConfig(session, gConfig);
        }

        public GeneralConfig getGeneralConfigByOrgId(string session, long orgId) {
            return CommunicationTimeKeepingGeneralConfig.Instance.getGeneralConfigByOrgId(session, orgId);
        }
    }
}
