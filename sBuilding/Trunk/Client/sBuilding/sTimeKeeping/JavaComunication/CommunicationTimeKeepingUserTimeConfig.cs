using sBuildingCommunication;
using sBuildingCommunication.Common;
using sTimeKeeping.Constants;
using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.JavaComunication
{
    /// <summary>
    /// class CommunicationTimeKeepingUserTimeConfig : CommunicationCommon
    /// </summary>
    public class CommunicationTimeKeepingUserTimeConfig : CommunicationCommon
    {
        private static CommunicationTimeKeepingUserTimeConfig instance = new CommunicationTimeKeepingUserTimeConfig();

        public static CommunicationTimeKeepingUserTimeConfig Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationTimeKeepingUserTimeConfig();
                }
                return instance;
            }
        }

        public CommunicationTimeKeepingUserTimeConfig() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"timekeepingconfigmgt";
        }
        /// <summary>
        /// insert User Time Config
        /// </summary>
        /// <param name="session"></param>
        /// <param name="userTimeConfig"></param>
        /// <returns></returns>
        public int insert(string session, UserTimeConfig userTimeConfig)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_USER_TIME_CONFIG, parameters, userTimeConfig);
        }
        /// <summary>
        /// update User Time Config
        /// </summary>
        /// <param name="session"></param>
        /// <param name="userTimeConfig"></param>
        /// <returns></returns>
        public int update(string session, UserTimeConfig userTimeConfig)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.UPDATE_TIMEKEEPING_USER_TIME_CONFIG, parameters, userTimeConfig);
        }
        /// <summary>
        /// delete User Time Config
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shList"></param>
        /// <returns></returns>
        public int delete(string session, List<long> shList)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.DELETE_TIMEKEEPING_USER_TIME_CONFIG, parameters, shList);
        }
        /// <summary>
        /// get User Time Config By Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserTimeConfig getUserTimeConfigById(string session, long id)
        {
            string parameters = Utilites.Instance.Paramater(session, id);
            UserTimeConfig result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_USER_TIME_CONFIG_BY_ID, parameters, new UserTimeConfig().GetType()) as UserTimeConfig;
            return result;
        }
        /// <summary>
        /// get List User Time Config By Member Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<List<UserTimeConfig>> getListUserTimeConfigByMemberId(string session, long orgId, List<long> memberId)
        {
             string parameters = Utilites.Instance.Paramater(session, orgId);
           List<List<UserTimeConfig>> listUserTimeConfig =  PostDataToServerObject(session, TimeKeepingMethodNames.GET_TIMEKEEPING_USER_TIME_CONFIG_LIST, parameters, memberId, new List<List<UserTimeConfig>>().GetType()) as List<List<UserTimeConfig>>;
           return listUserTimeConfig;
        }

    }
}
