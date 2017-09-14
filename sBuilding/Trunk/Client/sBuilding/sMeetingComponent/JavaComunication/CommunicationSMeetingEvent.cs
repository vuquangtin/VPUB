using JavaCommunication;
using JavaCommunication.Common;
using sMeetingComponent.Constants;
using sMeetingComponent.Model;
using sMeetingComponent.Model.CustomObj;
using System;
using System.Collections.Generic;

namespace sMeetingComponent.JavaComunication
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
            _baseUrl += @"meetingmg";
        }

        /// <summary>
        ///  1. lấy thông tin cuộc họp trong ngày
        ///  get list meeting by date yyyy-dd-mm
        /// </summary>
        /// <param name="session"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public List<EventMeeting> getEventMeetingListByDate(string session, String dateTime)
        {
            string parameters = Utilites.Instance.Paramater(session, dateTime);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_MEETING_BY_DATE, parameters, new List<EventMeeting>().GetType()) as List<EventMeeting>;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //--------------------------------------------DỜI LỊCH HỌP---------------------------------------
        /// <summary>
        /// MANAGE: list meeting
        /// 20: QUẢN lí thông tin cuộc họp theo điều kiện lọc
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
        public EventMeetingObj getEventMeetingListByDateAndOrgIDAndMeetingName(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId, string nameMeeting)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2, organizationMeetingId, nameMeeting);

            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_NON_RESIDENT_MEETING_BY_ORGANIZATION_MEETING_ID, parameters, new EventMeetingObj().GetType()) as EventMeetingObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 21. Xem thông tin cuộc họp
        /// lấy thông tin 1 cuộc họp
        /// Show info meeting based on meetingID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        public EventMeeting getEventMeetingById(string session, long meetingId)
        {
            string parameters = Utilites.Instance.Paramater(session, meetingId);

            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_NON_RESIDENT_MEETING_BY_ID, parameters, new EventMeeting().GetType()) as EventMeeting;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 22. Cập Nhật thời gian cuộc họp
        /// cập nhật thông tin cuộc họp : dời lịch họp
        /// Update info meeting 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventMeeting"></param>
        /// <returns></returns>
        public int updateEventMeeting(string session, EventMeeting eventMeeting)
        {
            string parameters = Utilites.Instance.Paramater(session);

            try
            {
                return PostDataFromServer(session, MeetingMethodNames.UPDATET_MEETING, parameters, eventMeeting);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
