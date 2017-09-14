using JavaCommunication;
using JavaCommunication.Common;
using sTimeKeeping.Constants;
using sTimeKeeping.Model;
using sWorldModel.TransportData;
using System.Collections.Generic;

namespace sTimeKeeping.JavaComunication {
    public class CommunicationTimeKeepingDayOffConfig : CommunicationCommon {
        private static CommunicationTimeKeepingDayOffConfig instance = new CommunicationTimeKeepingDayOffConfig();
        public static CommunicationTimeKeepingDayOffConfig Instance {
            get {
                if (null == instance) {
                    instance = new CommunicationTimeKeepingDayOffConfig();
                }

                return instance;
            }
        }

        private CommunicationTimeKeepingDayOffConfig() { }

        protected override void BaseURL() {
            base.BaseURL();
            _baseUrl += @"timekeepingdayoffconfigmgt";
        }

        public DayOffConfig updateDayOffConfig(string session, DayOffConfig doConfig) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, TimeKeepingMethodNames.UPDATE_TIMEKEEPING_DAY_OFF_CONFIG, parameters, doConfig, new DayOffConfig().GetType()) as DayOffConfig;
        }

        public DayOffConfig insertOrUpdateDayOffByListMemberId(string session, DayOffConfig doConfig) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, TimeKeepingMethodNames.INSERT_OR_UPDATE_DAY_OFF_MEMBER_ID, parameters, doConfig, new DayOffConfig().GetType()) as DayOffConfig;
        }

        public int deleteDayOffConfig(string session, List<long> listDOConfigId) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.DELETE_TIMEKEEPING_DAY_OFF_CONFIG, parameters, listDOConfigId);
        }

        public DayOffConfig getDayOffConfigById(string session, long doConfigId) {
            string parameters = Utilites.Instance.Paramater(session, doConfigId);
            return GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_DAY_OFF_CONFIG, parameters, new DayOffConfig().GetType()) as DayOffConfig;
        }

        public List<DayOffConfig> filterListDayOffBySubOrgId(string session, string dateStart, string dateEnd, long subOrgId) {
            string parameters = Utilites.Instance.Paramater(session, dateStart, dateEnd, subOrgId);
            return GetDataFromServer(session, TimeKeepingMethodNames.FILTER_TIMEKEEPING_LIST_DAY_OFF_CONFIG_SUB_ORG_ID, parameters, new List<DayOffConfig>().GetType()) as List<DayOffConfig>;
        }

        public DayOffConfig getDayOffByMemberIdAndDate(string session, long memberId, string date) {
            string parameters = Utilites.Instance.Paramater(session, memberId, date);
            return GetDataFromServer(session, TimeKeepingMethodNames.GET_DAY_OFF_MEMBER_ID_DATE, parameters, new DayOffConfig().GetType()) as DayOffConfig;
        }

        public Member getMemberById(string session, long memberId) {
            string parameters = Utilites.Instance.Paramater(session, memberId);
            return GetDataFromServer(session, TimeKeepingMethodNames.GET_MEMBER, parameters, new Member().GetType()) as Member;
        }

        public List<Member> getMemberBySubOrgId(string session, long subOrgId) {
            string parameters = Utilites.Instance.Paramater(session, subOrgId);
            return GetDataFromServer(session, TimeKeepingMethodNames.GET_MEMBER_LIST_SUB_ORG_ID, parameters, new List<Member>().GetType()) as List<Member>;
        }
        //trang.vo
        /// <summary>
        /// import danh sach nghi phep cua mot thang
        /// </summary>
        /// <param name="session"></param>
        /// <param name="DayOffImportObject"></param>
        /// <returns></returns>
        public List<DayOffImportObject> importDayOffList(string session, List<DayOffImportObject> DayOffImportObject)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<DayOffImportObject> result = PostDataToServerObject(session, TimeKeepingMethodNames.IMPORT_lIST_DAY_OFF, parameters, DayOffImportObject, new List<DayOffImportObject>().GetType()) as List<DayOffImportObject>;
            return result;
        }
    }
}
