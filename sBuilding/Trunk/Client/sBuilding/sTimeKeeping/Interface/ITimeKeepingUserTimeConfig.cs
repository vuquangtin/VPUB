using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Interface
{
    /// <summary>
    /// interface ITimeKeepingUserTimeConfig
    /// </summary>
    public interface ITimeKeepingUserTimeConfig
    {
        /// <summary>
        /// insert UserTimeConfig
        /// </summary>
        /// <param name="session"></param>
        /// <param name="userTimeConfig"></param>
        /// <returns></returns>
        int insert(string session, UserTimeConfig userTimeConfig);
        /// <summary>
        /// update UserTimeConfig
        /// </summary>
        /// <param name="session"></param>
        /// <param name="userTimeConfig"></param>
        /// <returns></returns>
        int update(string session, UserTimeConfig userTimeConfig);
        /// <summary>
        /// delete UserTimeConfig
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shList"></param>
        /// <returns></returns>
        int delete(string session, List<long> shList);
        /// <summary>
        /// get UserTimeConfig By Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        UserTimeConfig getUserTimeConfigById(string session, long id);
        /// <summary>
        /// get List UserTimeConfig By MemberId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        List<List<UserTimeConfig>> getListUserTimeConfigByMemberId(string session, long orgId, List<long> memberId);
    }
}
