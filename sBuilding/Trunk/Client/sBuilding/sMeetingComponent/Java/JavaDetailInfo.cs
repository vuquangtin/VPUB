using sMeetingComponent.Interface;
using sMeetingComponent.JavaComunication;
using sMeetingComponent.Model.CustomObj.EnterpriseHaveBarcode;
using sMeetingComponent.Model.CustomObj.PersonHaveBarcode;
using System;

namespace sMeetingComponent.Java
{
    public class JavaDetailInfo : IDetailInfo
    {
        private static JavaDetailInfo instance = new JavaDetailInfo();

        public static JavaDetailInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaDetailInfo();
                }
                return instance;
            }
        }

        private JavaDetailInfo()
        {
        }

        public MeetingInfoPartakerObj getDetailInfoByBarcode(string session, string barcode)
        {
            return CommunicationDetailInfo.Instance.getDetailInfoByBarcode(session, barcode);
        }

        public DetailInfoEnterpriseOrgOther getDetailInfoByBarcodeOfEnterprise(string session, String barcode)
        {
            return CommunicationDetailInfo.Instance.getDetailInfoByBarcodeOfEnterprise(session, barcode);
        }
    }
}
