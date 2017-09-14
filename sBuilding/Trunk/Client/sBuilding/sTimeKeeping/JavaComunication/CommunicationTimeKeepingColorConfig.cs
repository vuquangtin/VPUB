using JavaCommunication;
using JavaCommunication.Common;
using sTimeKeeping.Constants;
using sTimeKeeping.Model;
using System.Collections.Generic;

namespace sTimeKeeping.JavaComunication {
    public class CommunicationTimeKeepingColorConfig : CommunicationCommon {
        private static CommunicationTimeKeepingColorConfig instance = new CommunicationTimeKeepingColorConfig();

        public static CommunicationTimeKeepingColorConfig Instance {
            get {
                if (null == instance)
                    instance = new CommunicationTimeKeepingColorConfig();

                return instance;
            }
        }

        private CommunicationTimeKeepingColorConfig() { }

        protected override void BaseURL() {
            base.BaseURL();
            _baseUrl += @"timekeepingcolormgt";
        }

        public ColorConfig updateColorConfig(string session, ColorConfig cConfig) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, TimeKeepingMethodNames.UPDATE_TIMEKEEPING_COLOR_CONFIG, parameters, cConfig, new ColorConfig().GetType()) as ColorConfig;
        }

        public ColorConfig getColorConfigById(string session, long colorConfigId) {
            string parameters = Utilites.Instance.Paramater(session, colorConfigId);
            return GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_COLOR_CONFIG, parameters, new ColorConfig().GetType()) as ColorConfig;
        }

        public List<ColorConfig> getColorListByOrgId(string session, long orgId) {
            string parameters = Utilites.Instance.Paramater(session, orgId);
            return GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_LIST_COLOR_CONFIG_ORG_ID, parameters, new List<ColorConfig>().GetType()) as List<ColorConfig>;
        }
    }
}
