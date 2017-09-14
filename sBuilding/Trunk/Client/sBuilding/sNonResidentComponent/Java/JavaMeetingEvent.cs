using sMeetingComponent.Model;
using sNonResidentComponent.Interface;
using sNonResidentComponent.JavaComunication;
using sNonResidentComponent.Model;
using sNonResidentComponent.Model.CustomObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Java
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

        public int insertEventMeeting(string session, EventMeeting eventMeeting)
        {
            return CommunicationSMeetingEvent.Instance.insertEventMeeting(session, eventMeeting);
        }

        public int updateEventMeeting(string session, EventMeeting eventMeeting)
        {
            return CommunicationSMeetingEvent.Instance.updateEventMeeting(session, eventMeeting);
        }

        public int deleteEventMeeting(string session, long eventMeetingId)
        {
            return CommunicationSMeetingEvent.Instance.deleteEventMeeting(session, eventMeetingId);
        }

        public List<EventMeeting> getEventMeetingListByOrgId(string session, long orgId)
        {
            return CommunicationSMeetingEvent.Instance.getEventMeetingListByOrgId(session, orgId);

        }

        public EventMeeting getEventMeetingById(string session, long meetingId)
        {
            return CommunicationSMeetingEvent.Instance.getEventMeetingById(session, meetingId);
        }

        public NonResidentMeetingObj getEventMeetingListByDateAndOrgIDAndMeetingName(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId, string nameMeeting)
        {
            return CommunicationSMeetingEvent.Instance.getEventMeetingListByDateAndOrgIDAndMeetingName(session, from, to, dateIn, dateIn2, organizationMeetingId, nameMeeting);
        }
    }
}
