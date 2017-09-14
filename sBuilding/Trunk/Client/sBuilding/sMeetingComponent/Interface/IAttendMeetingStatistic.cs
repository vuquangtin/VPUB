using sMeetingComponent.Model.CustomObj.JournalistObjForStatictis;
using sMeetingComponent.Model.CustomObj.PersonInfoForStatictis;
using System;
using System.Collections.Generic;

namespace sMeetingComponent.Interface
{
    public interface IAttendMeetingStatistic
    {
        //THONG KE HOI HOP
        PersonAttendStatisticObj getListAttendMeetingStatisticByDate(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId, String nameMeeting);
        PersonAttendDetailObj getListAttendMeetingByMeetingidAndDate(string session, int from, int to, long meetingId);
        List<PersonAttendObj> getListAttendMeetingStatisticByDateAndOrgId(string session, String dateIn, String dateIn2, long organizationMeetingId);
        PersonAttendDetailObj getListPersonAttendDetailByDateAndOrgIdAndMeetingId(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId, long meetingId);

        //THONG KE BAO CHI
        JournalistAttendStatisticObj getListAttendMeetingJournalistStatisticByDate(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId, String nameMeeting);
        JournalistAttendStatisticDetailObj getListAttendMeetingJournalistByMeetingidAndDate(string session, int from, int to, long meetingId);
        JournalistAttendStatisticDetailObj getListPersonAttendDetailJournalistByDateAndOrgIdAndMeetingId(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId, long meetingId);

    }
}
