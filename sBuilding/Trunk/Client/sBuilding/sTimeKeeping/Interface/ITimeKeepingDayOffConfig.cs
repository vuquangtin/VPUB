using sTimeKeeping.Model;
using sWorldModel.TransportData;
using System.Collections.Generic;

namespace sTimeKeeping.Interface {
    public interface ITimeKeepingDayOffConfig {
        // Interface cấu hình ngày nghỉ của nhân viên
        DayOffConfig updateDayOffConfig(string session, DayOffConfig doConfig);
        DayOffConfig insertOrUpdateDayOffByListMemberId(string session, DayOffConfig doConfig);
        int deleteDayOffConfig(string session, List<long> listDOConfigId);
        DayOffConfig getDayOffConfigById(string session, long doConfigId);
        List<DayOffConfig> filterListDayOffBySubOrgId(string session, string dateStart, string dateEnd, long subOrgId);
        DayOffConfig getDayOffByMemberIdAndDate(string session, long memberId, string date);
        Member getMemberById(string session, long memberId);
        List<Member> getMemberBySubOrgId(string session, long subOrgId);
        //trang.vo 
        /// <summary>
        /// import danh sach nghi phep cua mot thang
        /// </summary>
        /// <param name="session"></param>
        /// <param name="DayOffImportObject"></param>
        /// <returns></returns>
        List<DayOffImportObject> importDayOffList(string session, List<DayOffImportObject> DayOffImportObject);
    }
}
