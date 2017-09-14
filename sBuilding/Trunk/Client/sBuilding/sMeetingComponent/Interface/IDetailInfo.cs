using sMeetingComponent.Model.CustomObj.EnterpriseHaveBarcode;
using sMeetingComponent.Model.CustomObj.PersonHaveBarcode;
using System;

namespace sMeetingComponent.Interface
{
    public interface IDetailInfo
    {
        MeetingInfoPartakerObj getDetailInfoByBarcode(string session, String barcode);
        DetailInfoEnterpriseOrgOther getDetailInfoByBarcodeOfEnterprise(string session, String barcode);
    }
}
