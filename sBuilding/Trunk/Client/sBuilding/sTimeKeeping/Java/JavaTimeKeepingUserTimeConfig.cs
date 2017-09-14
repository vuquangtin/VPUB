using sTimeKeeping.Interface;
using sTimeKeeping.JavaComunication;
using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Java
{
    /// <summary>
    /// class JavaTimeKeepingUserTimeConfig : ITimeKeepingUserTimeConfig
    /// </summary>
    public class JavaTimeKeepingUserTimeConfig : ITimeKeepingUserTimeConfig
    {
        private static JavaTimeKeepingUserTimeConfig instance = new JavaTimeKeepingUserTimeConfig();
        public static JavaTimeKeepingUserTimeConfig Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new JavaTimeKeepingUserTimeConfig();
                }

                return instance;
            }
        }

        private JavaTimeKeepingUserTimeConfig() { }

        public int insert(string session, UserTimeConfig userTimeConfig)
        {
            return CommunicationTimeKeepingUserTimeConfig.Instance.insert(session, userTimeConfig);
        }

        public int update(string session, UserTimeConfig userTimeConfig)
        {
            return CommunicationTimeKeepingUserTimeConfig.Instance.update(session, userTimeConfig);
        }

        public int delete(string session, List<long> shList)
        {
            return CommunicationTimeKeepingUserTimeConfig.Instance.delete(session, shList);
        }

        public UserTimeConfig getUserTimeConfigById(string session, long id)
        {
            return CommunicationTimeKeepingUserTimeConfig.Instance.getUserTimeConfigById(session, id);
        }

        public List<List<UserTimeConfig>> getListUserTimeConfigByMemberId(string session, long orgId, List<long> memberId)
        {
            return CommunicationTimeKeepingUserTimeConfig.Instance.getListUserTimeConfigByMemberId(session, orgId, memberId);
        }
    }
}
