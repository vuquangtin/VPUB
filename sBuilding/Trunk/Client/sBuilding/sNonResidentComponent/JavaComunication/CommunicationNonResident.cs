using JavaCommunication;
using JavaCommunication.Common;
using sMeetingComponent.Model;
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
    public class CommunicationNonResident : CommunicationCommon
    {
        private static CommunicationNonResident instance = new CommunicationNonResident();

        public static CommunicationNonResident Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationNonResident();
                }
                return instance;
            }
        }

        public CommunicationNonResident() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"nonresidentmg";
        }

        /// <summary>
        /// insert nonresident
        ///  4.INSERT Lưu thông tin khách đến VPUB
        /// <param name="session"></param>
        /// <param name="nonResident"></param>
        /// <returns></returns>
        public NonResidentObj insertNonResident(string session, NonResidentObj nonResident)
        {
            string parameters = Utilites.Instance.Paramater(session);

            try
            {
                return PostDataToServerObject(session, NonResidentMethodNames.INSERT_NONRESIDENT, parameters, nonResident, new NonResidentObj().GetType()) as NonResidentObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// //6:UPDATE Cập nhật thời gian ra về
        /// update end time of nonresident
        /// <param name="session"></param>
        /// <param name="nonResident"></param>
        /// <returns></returns>
        public int updateNonResidentBySerialnumberAndDateTime(string session, NonResident nonResident)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, NonResidentMethodNames.UPDATE_NONRESIDENT_BY_SERIALNUMBER_DATETIME, parameters, nonResident);
        }

        /// <summary>
        /// update info of nonresident
        /// //7:UPDATE Cập nhật thông tin khách vãng lai
        /// </summary>
        /// <param name="session"></param>
        /// <param name="nonResident"></param>
        /// <returns></returns>
        public NonResident updateInfoNonResident(string session, NonResident nonResident)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, NonResidentMethodNames.UPDATE_NONRESIDENT, parameters, nonResident, new NonResident().GetType()) as NonResident;
        }

        /// <summary>
        /// check input/out nonresident by serialnumber
        ///  3.CHECK kiểm tra thông tin cửa thẻ khách vãng lai 
        /// <param name="session"></param>
        /// <param name="serialnumber"></param>
        /// <returns></returns>
        public NonResidentObj checkInOutNonResidentBySerialnumber(string session, string serialnumber)
        {
            string parameters = Utilites.Instance.Paramater(session, serialnumber);

            NonResidentObj result = null;
            try
            {
                result = GetDataFromServer(session, NonResidentMethodNames.CHECK_INOUT_NONRESIDENT_BY_SERIALNUMBER, parameters, new NonResidentObj().GetType()) as NonResidentObj;
            }
            catch (Exception e)
            {
            };
            return result;
        }
    }
}
