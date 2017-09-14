using sMeetingComponent.Model.CustomObj;
using sMeetingComponent.Model.CustomObj.InfoJournalistObj;
using System;

namespace sMeetingComponent.Interface {
    public interface IJournalist {
        Journalist getJournalistByCardChip(string session, String cardchip);
        MeetingInfoJournalistObj getListMeetingJournalistObjByCardChip(string session, String cardchip, String datetime);//, int previousMinutes);
        int insertAttendMeetingJournalist(string session, MeetingInfoJournalistObj listMeetingJournalistObj);
        int isDateExpirated(string session, string serialNumber);
        NumberObj checkInOutUpdateAttendMeetingJournalist(string session, String cardchip, String datetime);
    }
}
