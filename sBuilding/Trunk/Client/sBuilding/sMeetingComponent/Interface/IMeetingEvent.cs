using sMeetingComponent.Model;
using sMeetingComponent.Model.CustomObj;
using System;
using System.Collections.Generic;

namespace sMeetingComponent.Interface
{
    public interface IMeetingEvent
    {
        List<EventMeeting> getEventMeetingListByDate(string session, String dateTime);
        EventMeeting getEventMeetingById(string session, long meetingId);
        EventMeetingObj getEventMeetingListByDateAndOrgIDAndMeetingName(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId, string nameMeeting);
        int updateEventMeeting(string session, EventMeeting eventMeeting);
    }
}
