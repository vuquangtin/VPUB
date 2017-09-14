using sMeetingComponent.Interface;
using sMeetingComponent.JavaComunication;
using sMeetingComponent.Model.CustomObj;
using sMeetingComponent.Model.CustomObj.InfoJournalistObj;
using System;

namespace sMeetingComponent.Java
{
    public class JavaJournalist : IJournalist
    {
        private static JavaJournalist instance = new JavaJournalist();

        public static JavaJournalist Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaJournalist();
                }
                return instance;
            }
        }

        private JavaJournalist()
        {
        }

        public Journalist getJournalistByCardChip(string session, String cardchip)
        {
            return CommunicationJournalist.Instance.getJournalistByCardChip(session, cardchip);
        }

        public MeetingInfoJournalistObj getListMeetingJournalistObjByCardChip(string session, String cardchip, String datetime)//, int previousMinutes)
        {
            return CommunicationJournalist.Instance.getListMeetingJournalistObjByCardChip(session, cardchip, datetime);//, previousMinutes);
        }

        public int isDateExpirated(string session, string serialNumber) {
            return CommunicationJournalist.Instance.isDateExpirated(session, serialNumber);
        }

        public NumberObj checkInOutUpdateAttendMeetingJournalist(string session, String cardchip, String datetime)
        {
            return CommunicationJournalist.Instance.checkInOutUpdateAttendMeetingJournalist(session, cardchip, datetime);
        }

        public int insertAttendMeetingJournalist(string session, MeetingInfoJournalistObj listMeetingJournalistObj)
        {
            return CommunicationJournalist.Instance.insertAttendMeetingJournalist(session, listMeetingJournalistObj);
        }
    }
}
