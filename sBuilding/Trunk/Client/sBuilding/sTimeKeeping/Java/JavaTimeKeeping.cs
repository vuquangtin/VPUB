using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Model
{
    /// <summary>
    /// class JavaTimeKeeping : ITimeKeeping
    /// </summary>
    public class JavaTimeKeeping : ITimeKeeping
    {
        private static JavaTimeKeeping instance = new JavaTimeKeeping();
        public static JavaTimeKeeping Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaTimeKeeping();
                }
                return instance;
            }
        }
        private JavaTimeKeeping()
        {
        }

        public List<Shift> GetDoorOutListByYear(string session, String year)
        {
            return CommunicationTimeKeeping.Instance.GetShiftListByYear(session, year);
        }
        public List<Shift> GetDoorOutListByMonth(string session, String year, String month)
        {
            return CommunicationTimeKeeping.Instance.GetShiftListByMonth(session, year, month);
        }
        public List<Shift> GetDoorOutListByDay(string session, String date, String serial, String deviceId)
        {
            return CommunicationTimeKeeping.Instance.GetShiftListByDay(session, date, serial, deviceId);
        }
        public MonthlyReport GetTimeKeepingMonthlyReport(string session, long nenberId, int year, int month)
        {
            return CommunicationTimeKeeping.Instance.GetTimeKeepingMonthlyReport(session, nenberId, year, month);
        }
        public List<MonthlyReport> GetTimeKeepingMonthlyReportList(string session, long orgId, long subOrgId, int year, int month)
        {
            return CommunicationTimeKeeping.Instance.GetTimeKeepingMonthlyReportList(session, orgId, subOrgId, year, month);
        }
        public List<MonthlyReport> GetTimeKeepingMonthlyReportListByDate(string session, long orgId, long subOrgId, string startDate, string endDate)
        {
            return CommunicationTimeKeeping.Instance.GetTimeKeepingMonthlyReportListByDate(session, orgId, subOrgId, startDate, endDate);
        }
        public int insertOrUpdateMonthlyReport(string session, string startDate, string endDate, List<long> listIdJson)
        {
            return CommunicationTimeKeeping.Instance.insertOrUpdateMonthlyReport(session, startDate, endDate, listIdJson);
        }
        public int insertMonthlyReportDefault(string session, long orgId, long subOrgId, long memberId, int year, int month)
        {
            return CommunicationTimeKeeping.Instance.insertMonthlyReportDefault(session, orgId, subOrgId, memberId, year, month);
        }
    }
}
