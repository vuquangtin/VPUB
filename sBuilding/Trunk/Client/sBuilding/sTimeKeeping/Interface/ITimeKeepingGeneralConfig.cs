using sTimeKeeping.Model;

namespace sTimeKeeping.Interface {
    public interface ITimeKeepingGeneralConfig {
        // Interface cấu hình chung
        GeneralConfig updateGeneralConfig(string session, GeneralConfig gConfig);
        GeneralConfig getGeneralConfigByOrgId(string session, long orgId);
    }
}
