using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Interface
{
    /// <summary>
    /// interface ITimeKeepingShift
    /// </summary>
    public interface ITimeKeepingShift
    {
        /// <summary>
        /// insert Shift
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        Shift insertShift(string session, Shift shift);
        /// <summary>
        /// update Shift
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        Shift updateShift(string session, Shift shift);
        /// <summary>
        /// delete Shift by shiftid
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shiftId"></param>
        /// <returns></returns>
        int deleteShift(string session, long shiftId);
        /// <summary>
        /// get Shift By Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shiftId"></param>
        /// <returns></returns>
        Shift getShiftById(string session, long shiftId);
        /// <summary>
        /// get ShiftList By Shift Filter
        /// </summary>
        /// <param name="session"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<Shift> getShiftListByShiftFilter(string session, ShiftFilterDto filter);
        /// <summary>
        /// get Shift Image By ShiftId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shiftId"></param>
        /// <returns></returns>
        TimeKeepingImage getShiftImageByShiftId(string session, long shiftId);
        /// <summary>
        /// insert Shift Image
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <param name="image">TimeKeepingImage image use to insert</param>
        /// <returns></returns>
        int insertShiftImage(string session, long id, TimeKeepingImage image);
        /// <summary>
        /// getShift
        /// </summary>
        /// <param name="session"></param>
        /// <param name="dateBegin"> dateBegin</param>
        /// <param name="dateEnd">dateEnd</param>
        /// <param name="listMemberId">list MemberId</param>
        /// <param name="orgId">orgId</param>
        /// <param name="subOrgId">subOrgId</param>
        /// <returns></returns>
        List<Shift> getShift(string session, string dateBegin, string dateEnd, String listMemberId, long orgId, long subOrgId);
    }
}
