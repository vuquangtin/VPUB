using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldCommunication.Interface
{
    public interface IVoucherGift
    {
        VoucherGift InsertVoucherGift(string session, VoucherGift vouchergift);

        VoucherGift UpdateVoucherGift(string session, VoucherGift vouchergift);

        int RemoveVoucherGift(string session, long vouchergiftId);    

        List<VoucherGift> GetAllVourcher(string session);

        VoucherGift GetVourcherByVourcherId(string session, long vourId);

        List<VoucherGift> GetAllVourcherByOrgId(string session, long OrgId);

        List<VoucherGift> GetVoucherFilterList(string session, VoucherGiftFilterDto filter);

        List<VoucherGift> GetVoucherFilterListByOrgID(string session, long orgId, VoucherGiftFilterDto filter);

        //List<MobilePersonalizationDTO> GetVoucherListByVoucherID(string session, long voucherId);
        //List<MemberMobilePersonalizationDTO> GetRuleMemberListByVoucherID(string session, long voucherId);
        List<MemberMobilePersonalizationDTO> GetRuleMemberListByVoucherID(string session, long voucherId);

        int InsertRuleVoucher(string session, List<MemberMobilePersonalizationDTO> lstMemberMobilePer);

        int RemoveRuleVoucher(string session, List<MemberMobilePersonalizationDTO> lstMemberMobilePer);

    }
}
