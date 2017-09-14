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
    ///  class CommunicationTimeKeepingShift : CommunicationCommon
    /// </summary>
    public class CommunicationTimeKeepingShift : CommunicationCommon
    {
        private static CommunicationTimeKeepingShift instance = new CommunicationTimeKeepingShift();

        public static CommunicationTimeKeepingShift Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationTimeKeepingShift();
                }
                return instance;
            }
        }

        public CommunicationTimeKeepingShift() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"timekeepingshiftmgt";
        }
        /// <summary>
        /// insert Shift
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public Shift insertShift(string session, Shift shift)
        {
            string parameters = Utilites.Instance.Paramater(session);
            Shift result = PostDataToServerObject(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_SHIFT, parameters, shift, new Shift().GetType()) as Shift;
            return result;
        }
        /// <summary>
        /// update Shift
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        public Shift updateShift(string session, Shift shift)
        {
            string parameters = Utilites.Instance.Paramater(session);
            Shift result = PostDataToServerObject(session, TimeKeepingMethodNames.UPDATE_TIMEKEEPING_SHIFT, parameters, shift, new Shift().GetType()) as Shift;
            return result;
        }
        /// <summary>
        /// delete Shift
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shiftId"></param>
        /// <returns></returns>
        public int deleteShift(string session, long shiftId)
        {
            string parameters = Utilites.Instance.Paramater(session, shiftId);
            return GetDataFromServer(session, TimeKeepingMethodNames.DELETE_TIMEKEEPING_SHIFT, parameters);
        }
        /// <summary>
        /// get Shift By Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shiftId"></param>
        /// <returns></returns>
        public Shift getShiftById(string session, long shiftId)
        {
            string parameters = Utilites.Instance.Paramater(session, shiftId);
            Shift result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_SHIFT_BY_SHIFTID, parameters, new Shift().GetType()) as Shift;
            return result;
        }
        /// <summary>
        /// get Shift List By Shift Filter
        /// </summary>
        /// <param name="session"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Shift> getShiftListByShiftFilter(string session, ShiftFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, TimeKeepingMethodNames.GET_TIMEKEEPING_SHIFT_LIST_BY_FILTER, parameters, filter, new List<Shift>().GetType()) as List<Shift>;
        }
        /// <summary>
        /// get Shift Image By Shift Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="shiftId"></param>
        /// <returns></returns>
        public TimeKeepingImage getShiftImageByShiftId(string session, long shiftId)
        {
            TimeKeepingImage result;
            string parameters = Utilites.Instance.Paramater(session, shiftId);
            result = GetDataFromServer(session, TimeKeepingMethodNames.Get_SHIFT_IMAGE_BY_SHIFTID, parameters, new TimeKeepingImage().GetType()) as TimeKeepingImage;
            return result;
        }
        /// <summary>
        /// insert Shift Image
        /// </summary>
        /// <param name="session"></param>
        /// <param name="id"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        public int insertShiftImage(string session, long id, TimeKeepingImage image)
        {
            string parameters = Utilites.Instance.Paramater(session, id);
            return PostDataFromServer(session, TimeKeepingMethodNames.INSERT_SHIFT_IMAGE, parameters, image);
        }
        /// <summary>
        /// get Shift by dateBegin, dateEnd, list MemberId, orgId and subOrgId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <param name="listMemberId"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <returns></returns>
        public List<Shift> getShift(string session, string dateBegin, string dateEnd, string listMemberId, long orgId, long subOrgId)
        {
            List<Shift> result = null;
            string parameters = Utilites.Instance.Paramater(session, dateBegin, dateEnd, listMemberId, orgId, subOrgId);
            result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_SHIFT_LIST, parameters, new List<Shift>().GetType()) as List<Shift>;
            return result;
        }

    }
}
