using sTimeKeeping.Model;
using System;
using System.Collections.Generic;

namespace sTimeKeeping.Interface {
    public interface ITimeKeepingHolidayConfig {
        // Interface cấu hình ngày lễ
        HolidayConfig insertHolidayConfig(string session, HolidayConfig hConfig);
        HolidayConfig updateHolidayConfig(string session, HolidayConfig hConfig);
        int deleteHolidayConfigById(string session, List<long> listHolidayId);
        HolidayConfig getHolidayConfigById(string session, long holidayId);
        int checkHoliday(string session, DateTime dateCheck, long orgId);
        List<HolidayConfig> filterHolidayListByOrgId(string session, string dateStart, string dateEnd, long orgId);
        
        // trang.vo
        /// <summary>
        /// get HolidayList By OrgId for 1 Year
        /// </summary>
        /// <param name="session"></param>
        /// <param name="year"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        List<HolidayConfig> getHolidayListByOrgIdAndYear(string session, int year, long orgId);
    }
}
