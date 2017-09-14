using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Interface
{
    /// <summary>
    /// interface ITimeKeepingTimeConfig
    /// </summary>
    public interface ITimeKeepingTimeConfig
    {
        /// <summary>
        /// Insert ListTimconfig
        /// </summary>
        /// <param name="session"></param>
        /// <param name="timeConfig"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        int InsertListTimconfig(string session, List<TimeConfig> timeConfig, long orgId);
        /// <summary>
        /// update TimeConfig
        /// </summary>
        /// <param name="session"></param>
        /// <param name="timeConfig"></param>
        /// <returns></returns>
        int updateTimeConfig(string session, TimeConfig timeConfig);
        /// <summary>
        /// delete TimeConfig
        /// </summary>
        /// <param name="session"></param>
        /// <param name="timeConfigId"></param>
        /// <returns></returns>
        int deleteTimeConfig(string session, long timeConfigId);
        /// <summary>
        /// get TimeConfig By Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="timeConfigId"></param>
        /// <returns></returns>
        TimeConfig getTimeConfigById(string session, long timeConfigId);
        /// <summary>
        /// Get List TimeConfig By OrgId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        List<TimeConfig> GetListTimeConfigByOrgId(string session, long orgId);
        /// <summary>
        /// Get TimeConfig & EventConfig By Filter for 1 member 1 date
        /// </summary>
        /// <param name="session"></param>
        /// <param name="memberid"></param>
        /// <param name="date"></param>
        /// <param name="orgid"></param>
        /// <returns>ConfigForStatisticDTO chua sessionWorking & list event</returns>
        ConfigForStatisticDTO GetTimeConfigEventConfigByFilter(string session, long memberid, string date, long orgid);
    }
}
