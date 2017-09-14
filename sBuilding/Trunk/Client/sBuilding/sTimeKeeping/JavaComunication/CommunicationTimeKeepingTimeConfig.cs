using JavaCommunication;
using JavaCommunication.Common;
using sTimeKeeping.Constants;
using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Model
{
    /// <summary>
    /// class CommunicationTimeKeepingTimeConfig  : CommunicationCommon
    /// </summary>
    public class CommunicationTimeKeepingTimeConfig  : CommunicationCommon
    {
      private static CommunicationTimeKeepingTimeConfig instance = new CommunicationTimeKeepingTimeConfig();

        public static CommunicationTimeKeepingTimeConfig Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationTimeKeepingTimeConfig();
                }
                return instance;
            }
        }

        public CommunicationTimeKeepingTimeConfig() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"timekeepingconfigmgt";
        }
        /// <summary>
        /// insert Time Config
        /// </summary>
        /// <param name="session"></param>
        /// <param name="timeConfig"></param>
        /// <returns></returns>
        public int insertTimeConfig(string session, TimeConfig timeConfig)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_TIME_CONFIG, parameters, timeConfig);
        }
        /// <summary>
        /// Insert list Time Config by orgId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="lstTimeconfig"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public int InsertTimeConfig(string session, List<TimeConfig> lstTimeconfig, long orgId)
        {
            string parameters = Utilites.Instance.Paramater(session,orgId);
            return PostDataFromServer(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_LIST_TIME_CONFIG, parameters, lstTimeconfig);
        }
        /// <summary>
        /// update Time Config
        /// </summary>
        /// <param name="session"></param>
        /// <param name="timeConfig"></param>
        /// <returns></returns>
        public int updateTimeConfig(string session, TimeConfig timeConfig) 
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.UPDATE_TIMEKEEPING_TIME_CONFIG, parameters, timeConfig);
        }
        /// <summary>
        /// delete Time Config
        /// </summary>
        /// <param name="session"></param>
        /// <param name="timeConfigId"></param>
        /// <returns></returns>
        public int deleteTimeConfig(string session, long timeConfigId)
        {
            string parameters = Utilites.Instance.Paramater(session, timeConfigId);
            return GetDataFromServer(session, TimeKeepingMethodNames.DELETE_TIMEKEEPING_TIME_CONFIG, parameters);
        }
        /// <summary>
        /// get Time Config By Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="timeConfigId"></param>
        /// <returns></returns>
        public TimeConfig getTimeConfigById(string session, long timeConfigId)
        {
            string parameters = Utilites.Instance.Paramater(session, timeConfigId);
            TimeConfig result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_TIME_CONFIG_BY_TICONFIG, parameters, new TimeConfig().GetType()) as TimeConfig;
            return result;
        }
        /// <summary>
        /// get List Time Config By Org Id and day Of Week
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public List<TimeConfig> getListTimeConfigByOrgCode(string session, long orgId, string dayOfWeek)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId, dayOfWeek);
            List<TimeConfig> result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_TIME_CONFIG_LIST_DAYOFWEEK, parameters, new List<TimeConfig>().GetType()) as List<TimeConfig>;
            return result;
        }
        /// <summary>
        /// get List Time Config By Org Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public List<TimeConfig> getListTimeConfigByOrgCode(string session, long orgId)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId);
            List<TimeConfig> result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_TIME_CONFIG_LIST_ORG_ID, parameters, new List<TimeConfig>().GetType()) as List<TimeConfig>;
            return result;
        }
        /// <summary>
        /// Get Time Config Event Config By Filter (return ve session working & list event)
        /// </summary>
        /// <param name="session"></param>
        /// <param name="memberid"></param>
        /// <param name="date"></param>
        /// <param name="orgid"></param>
        /// <returns>session working & list event</returns>
        public ConfigForStatisticDTO GetTimeConfigEventConfigByFilter(string session, long memberid, string date, long orgid)
        {
            string parameters = Utilites.Instance.Paramater(session, memberid, date, orgid);
            ConfigForStatisticDTO result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIME_CONFIG_EVENT_CONFIG_BY_FILTER, parameters, new ConfigForStatisticDTO().GetType()) as ConfigForStatisticDTO;
            return result;
        }
    }
}
