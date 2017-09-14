using sMeetingComponent.Model.CustomObj.ContactForWorkObj;
using System;

namespace sMeetingComponent.Interface
{
    public interface IContactForWork
    {
        int insertContactForWork(string session, SmeetingContactStatistic smeetingContactStatistic);
        //THONG KE LIEN HE CONG TAC
        SmeetingContactStatisticObj getListSmeetingContactStatisticStatisticByDateAndOrgId(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId);
        SmeetingContactStatisticDetailObj getListSmeetingContactStatisticDetaItByDateAndOrgId(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId);
    }
}
