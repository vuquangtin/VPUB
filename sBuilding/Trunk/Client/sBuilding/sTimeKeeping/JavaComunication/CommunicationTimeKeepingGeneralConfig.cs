using JavaCommunication;
using JavaCommunication.Common;
using sTimeKeeping.Constants;
using sTimeKeeping.Model;

namespace sTimeKeeping.JavaComunication {
    public class CommunicationTimeKeepingGeneralConfig : CommunicationCommon {
        private static CommunicationTimeKeepingGeneralConfig instance = new CommunicationTimeKeepingGeneralConfig();

        public static CommunicationTimeKeepingGeneralConfig Instance {
            get {
                if (null == instance) {
                    instance = new CommunicationTimeKeepingGeneralConfig();
                }

                return instance;
            }
        }

        private CommunicationTimeKeepingGeneralConfig() { }

        protected override void BaseURL() {
            base.BaseURL();
            _baseUrl += @"timekeepinggeneralconfigmgt";
        }

        public GeneralConfig updateGeneralConfig(string session, GeneralConfig gConfig) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, TimeKeepingMethodNames.UPDATE_TIMEKEEPING_GENERAL_CONFIG, parameters, gConfig, new GeneralConfig().GetType()) as GeneralConfig;
        }

        public GeneralConfig getGeneralConfigByOrgId(string session, long orgId) {
            string parameters = Utilites.Instance.Paramater(session, orgId);
            return GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_GENERAL_CONFIG_ORG_ID, parameters, new GeneralConfig().GetType()) as GeneralConfig;
        }
    }
}
