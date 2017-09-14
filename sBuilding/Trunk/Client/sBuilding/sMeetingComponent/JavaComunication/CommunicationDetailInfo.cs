using JavaCommunication;
using JavaCommunication.Common;
using sMeetingComponent.Constants;
using sMeetingComponent.Model.CustomObj.EnterpriseHaveBarcode;
using sMeetingComponent.Model.CustomObj.PersonHaveBarcode;
using System;
namespace sMeetingComponent.JavaComunication
{
    public class CommunicationDetailInfo : CommunicationCommon
    {
        private static CommunicationDetailInfo instance = new CommunicationDetailInfo();

        public static CommunicationDetailInfo Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationDetailInfo();
                }
                return instance;
            }
        }

        public CommunicationDetailInfo() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"detailinfomg";
        }



        /// <summary>
        /// 4. Lấy thông tin thư mời họp dựa vào barcode
        /// get info invation based on barcode
        /// </summary>
        /// <param name="session"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public MeetingInfoPartakerObj getDetailInfoByBarcode(string session, String barcode)
        {
            string parameters = Utilites.Instance.Paramater(session, barcode);
            MeetingInfoPartakerObj result = null;
            try
            {
                result = GetDataFromServer(session, MeetingMethodNames.GET_DETAIL_INFO_BY_BARCODE, parameters, new MeetingInfoPartakerObj().GetType()) as MeetingInfoPartakerObj;
            }
            catch (Exception e)
            {
            }
            return result;
        }

        /// <summary>
        /// get info invation based on barcode for Enterprise
        /// </summary>
        /// <param name="session"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public DetailInfoEnterpriseOrgOther getDetailInfoByBarcodeOfEnterprise(string session, String barcode)
        {
            string parameters = Utilites.Instance.Paramater(session, barcode);
            DetailInfoEnterpriseOrgOther result = null;
            try
            {
                result = GetDataFromServer(session, MeetingMethodNames.GET_DETAIL_INFO_BY_BARCODE_ENTERPRISE, parameters, new DetailInfoEnterpriseOrgOther().GetType()) as DetailInfoEnterpriseOrgOther;
            }
            catch (Exception e)
            {
            }
            return result;
        }
    }
}
