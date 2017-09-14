using sTimeKeeping.Interface;
using sTimeKeeping.Model;
using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Java
{
    /// <summary>
    ///  class JavaTimeKeepingTimeConfig : ITimeKeepingTimeConfig
    /// </summary>
    public class JavaTimeKeepingTimeConfig : ITimeKeepingTimeConfig
    {
        private static JavaTimeKeepingTimeConfig instance = new JavaTimeKeepingTimeConfig();
        public static JavaTimeKeepingTimeConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaTimeKeepingTimeConfig();
                }
                return instance;
            }
        }
        private JavaTimeKeepingTimeConfig()
        {
        }
        public int InsertListTimconfig(string session, List<TimeConfig> lstTimeConfig, long orgId)
        {
            return CommunicationTimeKeepingTimeConfig.Instance.InsertTimeConfig(session, lstTimeConfig, orgId);
        }
        public int updateTimeConfig(string session, TimeConfig timeConfig)
        {
            return CommunicationTimeKeepingTimeConfig.Instance.updateTimeConfig(session, timeConfig);
        }
        public int deleteTimeConfig(string session, long timeConfigId)
        {
            return CommunicationTimeKeepingTimeConfig.Instance.deleteTimeConfig(session, timeConfigId);
        }
        public TimeConfig getTimeConfigById(string session, long timeConfigId)
        {
            return CommunicationTimeKeepingTimeConfig.Instance.getTimeConfigById(session, timeConfigId);
        }

        public List<TimeConfig> GetListTimeConfigByOrgId(string session, long orgId)
        {
            return CommunicationTimeKeepingTimeConfig.Instance.getListTimeConfigByOrgCode(session, orgId);
        }
        public ConfigForStatisticDTO GetTimeConfigEventConfigByFilter(string session, long memberid, string date, long orgid)
        {
            return CommunicationTimeKeepingTimeConfig.Instance.GetTimeConfigEventConfigByFilter(session, memberid, date, orgid);
        }
    }
}
