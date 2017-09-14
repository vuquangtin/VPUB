using sTimeKeeping.Model;
using System.Collections.Generic;

namespace sTimeKeeping.Interface {
    public interface ITimeKeepingColorConfig {
        // Interface cấu hình màu
        ColorConfig updateColorConfig(string session, ColorConfig cConfig);
        ColorConfig getColorConfigById(string session, long colorConfigId);
        List<ColorConfig> getColorConfigListByOrgId(string session, long orgId);
    }
}
