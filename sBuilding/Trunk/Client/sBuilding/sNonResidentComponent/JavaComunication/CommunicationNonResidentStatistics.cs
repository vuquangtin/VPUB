using JavaCommunication;
using JavaCommunication.Common;
using sNonResidentComponent.Constants;
using sNonResidentComponent.Model;
using sNonResidentComponent.Model.CustomObj;
using sNonResidentComponent.Model.CustomObj.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.JavaComunication
{
    public class CommunicationNonResidentStatistics : CommunicationCommon
    {
        private static CommunicationNonResidentStatistics instance = new CommunicationNonResidentStatistics();

        public static CommunicationNonResidentStatistics Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationNonResidentStatistics();
                }
                return instance;
            }
        }

        public CommunicationNonResidentStatistics() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"nonresidentstatisticmg";
        }

        /// <summary>
        /// //:8 STATICTIS THỐNG KÊ số lượng khách vãng lai đến
        /// get list number nonresident by from date to date
        /// <param name="session"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <returns></returns>
        public NonResidentStatisticObj getListNonresidentStatisticByDate(string session, int from, int to, String dateIn, String dateIn2)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2);

            try
            {
                return GetDataFromServer(session, NonResidentMethodNames.GET_LISTNONRESIDENT_STATISTIC_BY_DATE, parameters, new NonResidentStatisticObj().GetType()) as NonResidentStatisticObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// /10: STATICTIS THÔNG TIN CHI TIẾT KHÁCH VÃNG LAI
        /// get list detail info nonresident list by from date to date  : orgid
        /// <param name="session"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <returns></returns>
        public List<NonResidentObj> getListNonresidentByOrgidAndDate(string session, int from, int to, String dateIn, String dateIn2, long orgId)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2, orgId);

            try
            {
                return GetDataFromServer(session, NonResidentMethodNames.GET_LISTNONRESIDENT_BY_ORG_DATE, parameters, new List<NonResidentObj>().GetType()) as List<NonResidentObj>;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// manage : list info nonresident based on from date to date
        /// //11:MANAGE Lấy thông tin khách vãng lai
        ///quản lí thông tin chi tiết của khách vãng lai
        /// </summary>
        /// <param name="session"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <returns></returns>
        public NonResidentStatisticDetailObj getListNonresidentByDate(string session, int from, int to, String dateIn, String dateIn2) { 
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2);

            try
            {
                return GetDataFromServer(session, NonResidentMethodNames.GET_LISTNONRESIDENT_BY_DATE, parameters, new NonResidentStatisticDetailObj().GetType()) as NonResidentStatisticDetailObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// statis: get list detail info nonresident based on ( from, to, dateIn, dateIn2, orgId);
        /// //9: STATICTIS : THÓNG KÊ chi tiết thông tin khách vãng lai đến
        /// thông tin chi tiết của khách vãng lai
        /// </summary>
        /// <param name="session"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public NonResidentStatisticDetailObj getListNonresidentByDateAndOrgId(string session, int from, int to, String dateIn, String dateIn2, long orgId, long subOrgId, int isPeople)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2, orgId, subOrgId, isPeople);

            try
            {
                return GetDataFromServer(session, NonResidentMethodNames.GET_LISTNONRESIDENT_BY_DATE_ORGID, parameters, new NonResidentStatisticDetailObj().GetType()) as NonResidentStatisticDetailObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
