using sMeetingComponent.Interface;
using sMeetingComponent.JavaComunication;
using sMeetingComponent.Model.CustomObj.ContactForWorkObj;

namespace sMeetingComponent.Java
{
    public class JavaContactForWork : IContactForWork
    {
        private static JavaContactForWork instance = new JavaContactForWork();

        public static JavaContactForWork Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaContactForWork();
                }
                return instance;
            }
        }

        private JavaContactForWork()
        {
        }

        public SmeetingContactStatisticObj getListSmeetingContactStatisticStatisticByDateAndOrgId(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId)
        {
            return CommunicationContactForWork.Instance.getListSmeetingContactStatisticStatisticByDateAndOrgId( session,  from,  to,  dateIn,  dateIn2,  organizationMeetingId);
        }

        public SmeetingContactStatisticDetailObj getListSmeetingContactStatisticDetaItByDateAndOrgId(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId)
        {
            return CommunicationContactForWork.Instance.getListSmeetingContactStatisticDetaItByDateAndOrgId(session, from, to, dateIn, dateIn2, organizationMeetingId);
        }

        public int insertContactForWork(string session, SmeetingContactStatistic smeetingContactStatistic)
        {
            return CommunicationContactForWork.Instance.insertContactForWork(session, smeetingContactStatistic);
        }
    }
}
