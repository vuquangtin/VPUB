using sMeetingComponent.Model;
using sNonResidentComponent.Model;
using sNonResidentComponent.Model.CustomObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Interface
{
    public interface IMeetingEvent
    {
        int insertEventMeeting(string session, EventMeeting eventMeeting);
        int updateEventMeeting(string session, EventMeeting eventMeeting);
        int deleteEventMeeting(string session, long eventMeetingId);
        List<EventMeeting> getEventMeetingListByOrgId(string session, long orgId);
        EventMeeting getEventMeetingById(string session, long meetingId);
        NonResidentMeetingObj getEventMeetingListByDateAndOrgIDAndMeetingName(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId, string nameMeeting);
    }
}
