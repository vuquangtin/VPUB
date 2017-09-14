using sTimeKeeping.Interface;
using sTimeKeeping.JavaComunication;
using sTimeKeeping.Model;
using System.Collections.Generic;

namespace sTimeKeeping.Java {
    public class JavaTimeKeepingColorConfig : ITimeKeepingColorConfig {
        private static JavaTimeKeepingColorConfig instance = new JavaTimeKeepingColorConfig();
        public static JavaTimeKeepingColorConfig Instance {
            get {
                if (null == instance) {
                    instance = new JavaTimeKeepingColorConfig();
                }

                return instance;
            }
        }

        private JavaTimeKeepingColorConfig() { }

        public ColorConfig updateColorConfig(string session, ColorConfig cConfig) {
            return CommunicationTimeKeepingColorConfig.Instance.updateColorConfig(session, cConfig);
        }

        public ColorConfig getColorConfigById(string session, long colorConfigId) {
            return CommunicationTimeKeepingColorConfig.Instance.getColorConfigById(session, colorConfigId);
        }

        public List<ColorConfig> getColorConfigListByOrgId(string session, long orgId) {
            return CommunicationTimeKeepingColorConfig.Instance.getColorListByOrgId(session, orgId);
        }
    }
}
