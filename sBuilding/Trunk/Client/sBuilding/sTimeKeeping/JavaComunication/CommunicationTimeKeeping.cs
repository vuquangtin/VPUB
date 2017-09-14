using JavaCommunication;
using JavaCommunication.Common;
using sTimeKeeping.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Model
{
    /// <summary>
    /// class CommunicationTimeKeeping : CommunicationCommon
    /// </summary>
    public class CommunicationTimeKeeping : CommunicationCommon
    {
        private static CommunicationTimeKeeping instance = new CommunicationTimeKeeping();

        public static CommunicationTimeKeeping Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationTimeKeeping();
                }
                return instance;
            }
        }

        public CommunicationTimeKeeping() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"timekeepingmgt";
        }
        /// <summary>
        /// Get Shift List By Year
        /// </summary>
        /// <param name="session"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<Shift> GetShiftListByYear(string session, String year)
        {
            string parameters = Utilites.Instance.Paramater(session, year);
            List<Shift> result = GetDataFromServer(session, TimeKeepingMethodNames.GET_SHIFT_BY_YEAR, parameters, new List<Shift>().GetType()) as List<Shift>;
            if (null == result) throw new Exception();

            return result;
        }
        /// <summary>
        /// Get Shift List By Month
        /// </summary>
        /// <param name="session"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public List<Shift> GetShiftListByMonth(string session, String year, String month)
        {
            string parameters = Utilites.Instance.Paramater(session, year, month);
            List<Shift> result = GetDataFromServer(session, TimeKeepingMethodNames.GET_SHIFT_BY_MONTH, parameters, new List<Shift>().GetType()) as List<Shift>;
            if (null == result) throw new Exception();

            return result;
        }
        /// <summary>
        /// Get Shift List By Day
        /// </summary>
        /// <param name="session"></param>
        /// <param name="date"></param>
        /// <param name="serial"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public List<Shift> GetShiftListByDay(string session, String date, String serial, String deviceId)
        {
            string parameters = Utilites.Instance.Paramater(session, date, serial, deviceId);
            List<Shift> result = GetDataFromServer(session, TimeKeepingMethodNames.GET_SHIFT_BY_DAY, parameters, new List<Shift>().GetType()) as List<Shift>;
            return result;
        }
        /// <summary>
        /// Get TimeKeeping Monthly Report by memberId, year and month
        /// </summary>
        /// <param name="session"></param>
        /// <param name="memberId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public MonthlyReport GetTimeKeepingMonthlyReport(string session, long memberId, int year, int month)
        {
            string parameters = Utilites.Instance.Paramater(session, memberId, year, month);
            MonthlyReport result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_MONTHLY_REPORT, parameters, new MonthlyReport().GetType()) as MonthlyReport;
            return result;
        }
        /// <summary>
        /// Get TimeKeeping Monthly Report List by orgId, subOrgId, year and month
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public List<MonthlyReport> GetTimeKeepingMonthlyReportList(string session, long orgId, long subOrgId, int year, int month)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId, subOrgId, year, month);
            List<MonthlyReport> result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_MONTHLY_REPORT_LIST, parameters, new List<MonthlyReport>().GetType()) as List<MonthlyReport>;
            return result;
        }
        /// <summary>
        ///  Get TimeKeeping Monthly Report List By Date
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<MonthlyReport> GetTimeKeepingMonthlyReportListByDate(string session, long orgId, long subOrgId, string startDate, string endDate)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId, subOrgId, startDate, endDate);
            List<MonthlyReport> result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_MONTHLY_REPORT_LIST_BY_DATE, parameters, new List<MonthlyReport>().GetType()) as List<MonthlyReport>;
            return result;
        }
        /// <summary>
        /// insert Or Update Monthly Report
        /// </summary>
        /// <param name="session"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="listIdJson"></param>
        /// <returns></returns>
        public int insertOrUpdateMonthlyReport(string session, string startDate, string endDate, List<long> listIdJson)
        {
            string parameters = Utilites.Instance.Paramater(session, startDate, endDate);
            int result = PostDataFromServer(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_MONTHLY_REPORT_BY_LIST_ID, parameters, listIdJson);
            return result;
        }
        /// <summary>
        /// insert MonthlyReport Default (gia tri mac dinh : -1)
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <param name="memberId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public int insertMonthlyReportDefault(string session, long orgId, long subOrgId, long memberId, int year, int month)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId, subOrgId, memberId, year, month);
            int result = GetDataFromServer(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_MONTHLY_REPORT_DEFAULT, parameters);
            return result;
        }
    }
}
