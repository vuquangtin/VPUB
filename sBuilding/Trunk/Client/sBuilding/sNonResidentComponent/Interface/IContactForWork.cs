using sMeetingComponent.Model.CustomObj.ContactForWorkObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Interface
{
    public interface IContactForWork
    {
        //THONG KE LIEN HE CONG TAC
        SmeetingContactStatisticObj getListSmeetingContactStatisticStatisticByDateAndOrgId(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId);
        SmeetingContactStatisticDetailObj getListSmeetingContactStatisticDetaItByDateAndOrgId(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId);

        int insertContactForWork(string session, SmeetingContactStatistic smeetingContactStatistic);
    }
}
