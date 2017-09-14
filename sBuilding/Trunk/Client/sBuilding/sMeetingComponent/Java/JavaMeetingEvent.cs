using sMeetingComponent.Interface;
using System;
using System.Collections.Generic;
using sMeetingComponent.Model;
using sMeetingComponent.JavaComunication;
using sMeetingComponent.Model.CustomObj;

namespace sMeetingComponent.Java
{
    public class JavaMeetingEvent : IMeetingEvent
    {
        private static JavaMeetingEvent instance = new JavaMeetingEvent();

        public static JavaMeetingEvent Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaMeetingEvent();
                }
                return instance;
            }
        }

        private JavaMeetingEvent()
        {
        }

        public List<EventMeeting> getEventMeetingListByDate(string session, String dateTime)
        {
            return CommunicationSMeetingEvent.Instance.getEventMeetingListByDate(session, dateTime);
        }


        //dời lich hop
        public int updateEventMeeting(string session, EventMeeting eventMeeting)
        {
            return CommunicationSMeetingEvent.Instance.updateEventMeeting(session, eventMeeting);
        }

        public EventMeeting getEventMeetingById(string session, long meetingId)
        {
            return CommunicationSMeetingEvent.Instance.getEventMeetingById(session, meetingId);
        }

        public EventMeetingObj getEventMeetingListByDateAndOrgIDAndMeetingName(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId, string nameMeeting)
        {
            return CommunicationSMeetingEvent.Instance.getEventMeetingListByDateAndOrgIDAndMeetingName(session, from, to, dateIn, dateIn2, organizationMeetingId, nameMeeting);
        }
    }
}
