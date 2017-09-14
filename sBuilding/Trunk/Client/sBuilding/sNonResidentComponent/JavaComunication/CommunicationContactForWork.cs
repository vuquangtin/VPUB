using JavaCommunication;
using JavaCommunication.Common;
using sMeetingComponent.Constants;
using sMeetingComponent.Model.CustomObj.ContactForWorkObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.JavaComunication
{
    public class CommunicationContactForWork : CommunicationCommon
    {

        private static CommunicationContactForWork instance = new CommunicationContactForWork();

        public static CommunicationContactForWork Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationContactForWork();
                }
                return instance;
            }
        }

        public CommunicationContactForWork() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"smeetingcontactstatisticnonresidentmg";
        }
      

        //thong ke lien he cong tac
        public SmeetingContactStatisticObj getListSmeetingContactStatisticStatisticByDateAndOrgId(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2, organizationMeetingId);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_STATISTIC_CONTACTWORK_BY_DATE_ORG, parameters, new SmeetingContactStatisticObj().GetType()) as SmeetingContactStatisticObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //lưu thông tin liên hệ công tác
        public int insertContactForWork(string session, SmeetingContactStatistic smeetingContactStatistic)
        {
            string parameters = Utilites.Instance.Paramater(session);

            int i = 0;
            try
            {
                i = PostDataFromServer(session, MeetingMethodNames.INSERT_CONTACT_FOR_WORK, parameters, smeetingContactStatistic);
            }
            catch (Exception e)
            {
            }
            return i;
        }

        //thong tin chi tiet nguoi lien he cong tac
        public SmeetingContactStatisticDetailObj getListSmeetingContactStatisticDetaItByDateAndOrgId(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2, organizationMeetingId);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_DETAIL_STATISTIC_CONTACTWORK_BY_DATE_ORG, parameters, new SmeetingContactStatisticDetailObj().GetType()) as SmeetingContactStatisticDetailObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
