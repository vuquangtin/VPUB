using sTimeKeeping.Interface;
using System.Collections.Generic;
using sTimeKeeping.Model;
using sTimeKeeping.JavaComunication;
using System;

namespace sTimeKeeping.Java {
    public class JavaTimeKeepingHolidayConfig : ITimeKeepingHolidayConfig {
        private static JavaTimeKeepingHolidayConfig instance = new JavaTimeKeepingHolidayConfig();
        public static JavaTimeKeepingHolidayConfig Instance {
            get {
                if (null == instance) {
                    instance = new JavaTimeKeepingHolidayConfig();
                }

                return instance;
            }
        }

        private JavaTimeKeepingHolidayConfig() { }

        public HolidayConfig insertHolidayConfig(string session, HolidayConfig hConfig) {
            return CommunicationTimeKeepingHolidayConfig.Instance.insertHolidayConfig(session, hConfig);
        }

        public HolidayConfig updateHolidayConfig(string session, HolidayConfig hConfig) {
            return CommunicationTimeKeepingHolidayConfig.Instance.updateHolidayConfig(session, hConfig);
        }

        public int deleteHolidayConfigById(string session, List<long> listHolidayId) {
            return CommunicationTimeKeepingHolidayConfig.Instance.deleteHolidayConfigById(session, listHolidayId);
        }

        public HolidayConfig getHolidayConfigById(string session, long holidayId) {
            return CommunicationTimeKeepingHolidayConfig.Instance.getHolidayConfigById(session, holidayId);
        }
        
        public int checkHoliday(string session, DateTime dateCheck, long orgId) {
            return CommunicationTimeKeepingHolidayConfig.Instance.checkHoliday(session, dateCheck, orgId);
        }

        public List<HolidayConfig> filterHolidayListByOrgId(string session, string dateStart, string dateEnd, long orgId) {
            return CommunicationTimeKeepingHolidayConfig.Instance.filterHolidayListByOrgId(session, dateStart, dateEnd, orgId);
        }

        public List<HolidayConfig> getHolidayListByOrgIdAndYear(string session, int year, long orgId)
        {
            return CommunicationTimeKeepingHolidayConfig.Instance.getHolidayListByOrgIdAndYear(session, year, orgId);
        }
      
    }
}
