using sTimeKeeping.Interface;
using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Java
{
    /// <summary>
    /// class JavaTimeKeepingShift : ITimeKeepingShift
    /// </summary>
    public class JavaTimeKeepingShift : ITimeKeepingShift
    {
        private static JavaTimeKeepingShift instance = new JavaTimeKeepingShift();
        public static JavaTimeKeepingShift Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaTimeKeepingShift();
                }
                return instance;
            }
        }
        private JavaTimeKeepingShift()
        {
        }
        public Shift insertShift(string session, Shift shift)
        {
            return CommunicationTimeKeepingShift.Instance.insertShift(session, shift);
        }
        public Shift updateShift(string session, Shift shift)
        {
            return CommunicationTimeKeepingShift.Instance.updateShift(session, shift);
        }
        public int deleteShift(string session, long shiftId)
        {
            return CommunicationTimeKeepingShift.Instance.deleteShift(session, shiftId);
        }
        public Shift getShiftById(string session, long shiftId)
        {
            return CommunicationTimeKeepingShift.Instance.getShiftById(session, shiftId);
        }
        public List<Shift> getShiftListByShiftFilter(string session, ShiftFilterDto filter)
        {
            return CommunicationTimeKeepingShift.Instance.getShiftListByShiftFilter(session, filter);
        }
        public TimeKeepingImage getShiftImageByShiftId(string session, long shiftId)
        {
            return CommunicationTimeKeepingShift.Instance.getShiftImageByShiftId(session, shiftId);
        }

        public int insertShiftImage(string session, long id, TimeKeepingImage image)
        {
            return CommunicationTimeKeepingShift.Instance.insertShiftImage(session, id, image);
        }

        public List<Shift> getShift(string session, string dateBegin, string dateEnd, String listMemberId, long orgId, long subOrgId)
        {
            return CommunicationTimeKeepingShift.Instance.getShift(session, dateBegin, dateEnd, listMemberId, orgId, subOrgId);
        }
    }
}
