using sTimeKeeping.Interface;
using sTimeKeeping.JavaComunication;
using sTimeKeeping.Model;
using sWorldModel.TransportData;
using System.Collections.Generic;

namespace sTimeKeeping.Java {
    public class JavaTimeKeepingDayOffConfig : ITimeKeepingDayOffConfig {
        private static JavaTimeKeepingDayOffConfig instance = new JavaTimeKeepingDayOffConfig();
        public static JavaTimeKeepingDayOffConfig Instance {
            get {
                if (null == instance) {
                    instance = new JavaTimeKeepingDayOffConfig();
                }

                return instance;
            }
        }

        private JavaTimeKeepingDayOffConfig() { }

        public DayOffConfig updateDayOffConfig(string session, DayOffConfig doConfig) {
            return CommunicationTimeKeepingDayOffConfig.Instance.updateDayOffConfig(session, doConfig);
        }

        public DayOffConfig insertOrUpdateDayOffByListMemberId(string session, DayOffConfig doConfig) {
            return CommunicationTimeKeepingDayOffConfig.Instance.insertOrUpdateDayOffByListMemberId(session, doConfig);
        }

        public int deleteDayOffConfig(string session, List<long> listDOConfigId) {
            return CommunicationTimeKeepingDayOffConfig.Instance.deleteDayOffConfig(session, listDOConfigId);
        }

        public DayOffConfig getDayOffConfigById(string session, long doConfigId) {
            return CommunicationTimeKeepingDayOffConfig.Instance.getDayOffConfigById(session, doConfigId);
        }

        public List<DayOffConfig> filterListDayOffBySubOrgId(string session, string dateStart, string dateEnd, long subOrgId) {
            return CommunicationTimeKeepingDayOffConfig.Instance.filterListDayOffBySubOrgId(session, dateStart, dateEnd, subOrgId);
        }

        public DayOffConfig getDayOffByMemberIdAndDate(string session, long memberId, string date) {
            return CommunicationTimeKeepingDayOffConfig.Instance.getDayOffByMemberIdAndDate(session, memberId, date);
        }

        public Member getMemberById(string session, long memberId) {
            return CommunicationTimeKeepingDayOffConfig.Instance.getMemberById(session, memberId);
        }

        public List<Member> getMemberBySubOrgId(string session, long subOrgId) {
            return CommunicationTimeKeepingDayOffConfig.Instance.getMemberBySubOrgId(session, subOrgId);
        }
        //ham import danh sach nghi phep cua mot thang
        public List<DayOffImportObject> importDayOffList(string session, List<DayOffImportObject> DayOffImportObject) 
        {
             return CommunicationTimeKeepingDayOffConfig.Instance.importDayOffList(session, DayOffImportObject);
        }
    }
}
