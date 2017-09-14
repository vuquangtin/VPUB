using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Model
{
    /// <summary>
    /// interface ITimeKeeping
    /// </summary>
    public interface ITimeKeeping
    {
        /// <summary>
        /// Get DoorOutList By Year
        /// </summary>
        /// <param name="session"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        List<Shift> GetDoorOutListByYear(string session, String year);
        /// <summary>
        /// Get DoorOutList By Month
        /// </summary>
        /// <param name="session"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        List<Shift> GetDoorOutListByMonth(string session, String year, String month);
        /// <summary>
        /// Get DoorOutList By Day
        /// </summary>
        /// <param name="session"></param>
        /// <param name="date"></param>
        /// <param name="serial"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        List<Shift> GetDoorOutListByDay(string session, String date, String serial, String deviceId);
        /// <summary>
        /// Get TimeKeepingMonthlyReport by memberId, year and month
        /// </summary>
        /// <param name="session"></param>
        /// <param name="memberId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        MonthlyReport GetTimeKeepingMonthlyReport(string session, long memberId, int year, int month);
        /// <summary>
        /// Get TimeKeepingMonthlyReport List by orgid, subOrgId, year and month
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        List<MonthlyReport> GetTimeKeepingMonthlyReportList(string session, long orgId, long subOrgId, int year, int month);
        /// <summary>
        /// Get TimeKeepingMonthlyReport List By startDate and endDate
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<MonthlyReport> GetTimeKeepingMonthlyReportListByDate(string session, long orgId, long subOrgId, string startDate, string endDate);
        /// <summary>
        /// insert Or Update MonthlyReport
        /// </summary>
        /// <param name="session"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="listIdJson"> list memberid</param>
        /// <returns></returns>
        int insertOrUpdateMonthlyReport(string session, string startDate, string endDate, List<long> listIdJson);
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
        int insertMonthlyReportDefault(string session, long orgId, long subOrgId, long memberId, int year, int month);
    }
}
