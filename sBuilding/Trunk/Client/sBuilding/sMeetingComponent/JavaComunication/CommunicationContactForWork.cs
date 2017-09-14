using JavaCommunication;
using JavaCommunication.Common;
using sMeetingComponent.Constants;
using sMeetingComponent.Model.CustomObj.ContactForWorkObj;
using System;

namespace sMeetingComponent.JavaComunication
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
            _baseUrl += @"smeetingcontactstatisticmg";
        }

        //--------------------------------------------THÔNG  KÊ LIÊN HỆ CÔNG TÁC ---------------------------------------
        /// <summary>
        /// 18: Thống kê LIÊN HỆ CÔNG TÁC Lấy số lượng người đến liên hệ
        /// statictis : get list number contact based on orgid
        /// </summary>
        /// <param name="session"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <param name="organizationMeetingId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 9: Lưu thông tin liên hệ công tác
        /// insert info when person contact
        /// </summary>
        /// <param name="session"></param>
        /// <param name="smeetingContactStatistic"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 19: THống kê LIÊN HỆ CÔNG TÁC: LẤy thông tin chi tiết người đến liên hệ
        ///  thong tin chi tiet nguoi lien he cong tac
        ///  statictis : get list info detail contact based on orgid
        /// <param name="session"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <param name="organizationMeetingId"></param>
        /// <returns></returns>
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
