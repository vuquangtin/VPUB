using JavaCommunication;
using JavaCommunication.Common;
using sMeetingComponent.Model;
using sNonResidentComponent.Constants;
using sNonResidentComponent.Model;
using sNonResidentComponent.Model.CustomObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.JavaComunication
{
    public class CommunicationSMeetingEvent : CommunicationCommon
    {
        private static CommunicationSMeetingEvent instance = new CommunicationSMeetingEvent();

        public static CommunicationSMeetingEvent Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationSMeetingEvent();
                }
                return instance;
            }
        }

        public CommunicationSMeetingEvent() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"nonresidentmeetingmg";
        }

        /// <summary>
        ///  //14: ADD THêm cuộc họp nội bộ
        /// insert attendmeeting
        /// thêm người tham dự cuộc họp
        /// <param name="session"></param>
        /// <param name="eventAttendMeeting"></param>
        /// <returns></returns>
        public int insertEventMeeting(string session, EventMeeting eventMeeting)
        {
            string parameters = Utilites.Instance.Paramater(session);

            try
            {
                return PostDataFromServer(session, NonResidentMethodNames.INSERT_MEETING, parameters, eventMeeting);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /// <summary>
        /// delete meeting
        ///  //13 DELETE : HỦY cuộc họp
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventMeetingId"></param>
        /// <returns></returns>
        public int deleteEventMeeting(string session, long eventMeetingId)
        {
            string parameters = Utilites.Instance.Paramater(session,eventMeetingId);

            try
            {
                return GetDataFromServer(session, NonResidentMethodNames.DELETE_MEETING, parameters);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        /// <summary>
        /// update info meeting
        /// //16:UPDATE Cập nhật thông tin cuộc họp
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventMeeting"></param>
        /// <returns></returns>
        public int updateEventMeeting(string session, EventMeeting eventMeeting)
        {
            string parameters = Utilites.Instance.Paramater(session);

            try
            {
                return PostDataFromServer(session, NonResidentMethodNames.UPDATET_MEETING, parameters, eventMeeting);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        /// <summary>
        /// get list meeting based on orgid
        /// lấy danh sách các cuộc họp theo orgid
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public List<EventMeeting> getEventMeetingListByOrgId(string session, long orgId)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId);

            try
            {
                return GetDataFromServer(session, NonResidentMethodNames.GET_NON_RESIDENT_MEETING_BY_ORGANIZATION_ID, parameters, new List<EventMeeting>().GetType()) as List<EventMeeting>;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// get meeting based on meetingid
        /// //5:GET Lấy thông tin cuộc họp khách vãng lai tham dự họp
        /// lấy thông tin 1 cuộc họp
        /// </summary>
        /// <param name="session"></param>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        public EventMeeting getEventMeetingById(string session, long meetingId)
        {
            string parameters = Utilites.Instance.Paramater(session, meetingId);

            try
            {
                return GetDataFromServer(session, NonResidentMethodNames.GET_NON_RESIDENT_MEETING_BY_ID, parameters, new EventMeeting().GetType()) as EventMeeting;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// manage : get list meeting based on (from, to, dateIn, dateIn2, organizationMeetingId, nameMeeting);
        ///   //12 MANAGE : Lấy danh sách thông tin cuộc họp
        /// danh sách thông tin của của cuoc hop chi tiết
        /// </summary>
        /// <param name="session"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <param name="organizationMeetingId"></param>
        /// <param name="nameMeeting"></param>
        /// <returns></returns>
        public NonResidentMeetingObj getEventMeetingListByDateAndOrgIDAndMeetingName(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId, string nameMeeting)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2, organizationMeetingId, nameMeeting);

            try
            {
                return GetDataFromServer(session, NonResidentMethodNames.GET_NON_RESIDENT_MEETING_BY_ORGANIZATION_MEETING_ID, parameters, new NonResidentMeetingObj().GetType()) as NonResidentMeetingObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
