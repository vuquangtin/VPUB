using JavaCommunication;
using JavaCommunication.Common;
using sTimeKeeping.Constants;
using sTimeKeeping.Model;
using System;
using System.Collections.Generic;

namespace sTimeKeeping.JavaComunication {
    public class CommunicationTimeKeepingHolidayConfig : CommunicationCommon {
        private static CommunicationTimeKeepingHolidayConfig instance = new CommunicationTimeKeepingHolidayConfig();

        public static CommunicationTimeKeepingHolidayConfig Instance {
            get {
                if (null == instance)
                    instance = new CommunicationTimeKeepingHolidayConfig();
                return instance;
            }
        }

        private CommunicationTimeKeepingHolidayConfig() { }

        protected override void BaseURL() {
            base.BaseURL();
            _baseUrl += @"timekeepingholidaymgt";
        }

        public HolidayConfig insertHolidayConfig(string session, HolidayConfig hConfig) {
            string parameters = Utilites.Instance.Paramater(session, hConfig.orgId);
            return PostDataToServerObject(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_HOLIDAY_CONFIG, parameters, hConfig, new HolidayConfig().GetType()) as HolidayConfig;
        }

        public HolidayConfig updateHolidayConfig(string session, HolidayConfig hConfig) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, TimeKeepingMethodNames.UPDATE_TIMEKEEPING_HOLIDAY_CONFIG, parameters, hConfig, new HolidayConfig().GetType()) as HolidayConfig;
        }

        public int deleteHolidayConfigById(string session, List<long> listHolidayId) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.DELETE_TIMEKEEPING_HOLIDAY_CONFIG, parameters, listHolidayId);
        }

        public HolidayConfig getHolidayConfigById(string session, long holidayId) {
            string parameters = Utilites.Instance.Paramater(session, holidayId);
            return GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_HOLIDAY_CONFIG, parameters, new HolidayConfig().GetType()) as HolidayConfig;
        }

        public int checkHoliday(string session, DateTime dateCheck, long orgId) {
            string parameters = Utilites.Instance.Paramater(session, dateCheck.ToString("ddMMyyyy"), orgId);
            return GetDataFromServer(session, TimeKeepingMethodNames.CHECK_HOLIDAY, parameters);
        }

        public List<HolidayConfig> filterHolidayListByOrgId(string session, string dateStart, string dateEnd, long orgId) {
            string parameters = Utilites.Instance.Paramater(session, dateStart, dateEnd, orgId);
            return GetDataFromServer(session, TimeKeepingMethodNames.FILTER_TIMEKEEPING_LIST_HOLIDAY_CONFIG_ORG_ID, parameters, new List<HolidayConfig>().GetType()) as List<HolidayConfig>;
        }

        // trang.vo
        /// <summary>
        /// get HolidayList By OrgId for 1 Year
        /// </summary>
        /// <param name="session"></param>
        /// <param name="year"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public List<HolidayConfig> getHolidayListByOrgIdAndYear(string session, int year, long orgId)
        {
            string parameters = Utilites.Instance.Paramater(session, year, orgId);
            return GetDataFromServer(session, TimeKeepingMethodNames.GET_HOLIDAY_LIST_BY_ORGID_YEAR, parameters, new List<HolidayConfig>().GetType()) as List<HolidayConfig>;
        }
    }
}
