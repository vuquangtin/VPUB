using sMeetingComponent.Interface;
using System;
using System.Collections.Generic;
using sMeetingComponent.JavaComunication;
using sMeetingComponent.Model.CustomObj.JournalistObjForStatictis;
using sMeetingComponent.Model.CustomObj.PersonInfoForStatictis;

namespace sMeetingComponent.Java
{
    public class JavaAttendMeetingStatistic : IAttendMeetingStatistic
    {
        private static JavaAttendMeetingStatistic instance = new JavaAttendMeetingStatistic();

        public static JavaAttendMeetingStatistic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaAttendMeetingStatistic();
                }
                return instance;
            }
        }

        private JavaAttendMeetingStatistic()
        {
        }

        public PersonAttendDetailObj getListAttendMeetingByMeetingidAndDate(string session, int from, int to, long meetingId)
        {
            return CommunicationAttendMeetingStatistic.Instance.getListAttendMeetingByMeetingidAndDate(session,  from,  to, meetingId);
        }

        public PersonAttendStatisticObj getListAttendMeetingStatisticByDate(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId, String nameMeeting) {
            return CommunicationAttendMeetingStatistic.Instance.getListAttendMeetingStatisticByDate(session, from, to, dateIn, dateIn2 , organizationMeetingId,  nameMeeting);
        }

        public List<PersonAttendObj> getListAttendMeetingStatisticByDateAndOrgId(string session, String dateIn, String dateIn2, long organizationMeetingId) {
            return CommunicationAttendMeetingStatistic.Instance.getListAttendMeetingStatisticByDateAndOrgId(session, dateIn, dateIn2, organizationMeetingId);
        }

        public PersonAttendDetailObj getListPersonAttendDetailByDateAndOrgIdAndMeetingId(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId, long meetingId)
        {
            return CommunicationAttendMeetingStatistic.Instance.getListPersonAttendDetailByDateAndOrgIdAndMeetingId(session, from, to, dateIn, dateIn2, organizationMeetingId, meetingId);
        }

        // thong ke bao chi
        public JournalistAttendStatisticObj getListAttendMeetingJournalistStatisticByDate(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId, string nameMeeting)
        {
            return CommunicationAttendMeetingStatistic.Instance.getListAttendMeetingJournalistStatisticByDate(session, from, to, dateIn, dateIn2, organizationMeetingId, nameMeeting);
        }

        public JournalistAttendStatisticDetailObj getListAttendMeetingJournalistByMeetingidAndDate(string session, int from, int to, long meetingId)
        {
            return CommunicationAttendMeetingStatistic.Instance.getListAttendMeetingJournalistByMeetingidAndDate(session, from, to, meetingId);
        }

        public JournalistAttendStatisticDetailObj getListPersonAttendDetailJournalistByDateAndOrgIdAndMeetingId(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId, long meetingId)
        {
            return CommunicationAttendMeetingStatistic.Instance.getListPersonAttendDetailJournalistByDateAndOrgIdAndMeetingId(session, from, to, dateIn, dateIn2, organizationMeetingId, meetingId);
        }
    }
}
