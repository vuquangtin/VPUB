using JavaCommunication.Common;
using sWorldCommunication.Interface;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Java
{
    public class JavaVoucherGift : IVoucherGift
    {
        private static JavaVoucherGift instance = new JavaVoucherGift();
        public static JavaVoucherGift Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaVoucherGift();
                }
                return instance;
            }
        }
        private JavaVoucherGift()
        {
        }

        public VoucherGift InsertVoucherGift(string session, VoucherGift vouchergift)
        {
            return CommunicationVoucherGift.Instance.InsertVoucherGift(session, vouchergift);
        }

        public VoucherGift UpdateVoucherGift(string session, VoucherGift vouchergift)
        {
            return CommunicationVoucherGift.Instance.UpdateVoucherGift(session, vouchergift);
        }

        public int RemoveVoucherGift(string session, long vouchergiftId)
        {
            return CommunicationVoucherGift.Instance.RemoveVoucherGift(session, vouchergiftId);
        }
        
        public List<VoucherGift> GetAllVourcher(string session)
        {
            return CommunicationVoucherGift.Instance.GetAllVourcher(session);
        }

        public VoucherGift GetVourcherByVourcherId(string session, long vourId)
        {
            return CommunicationVoucherGift.Instance.GetVourcherByVourcherId(session, vourId);
        }

        public List<VoucherGift> GetAllVourcherByOrgId(string session, long OrgId)
        {
            return CommunicationVoucherGift.Instance.GetAllVourcherByOrgId(session, OrgId);
        }

        public List<VoucherGift> GetVoucherFilterList(string session, VoucherGiftFilterDto filter)
        {
            return CommunicationVoucherGift.Instance.GetVoucherFilterList(session, filter);
        }

        public List<VoucherGift> GetVoucherFilterListByOrgID(string session, long orgId, VoucherGiftFilterDto filter)
        {
            return CommunicationVoucherGift.Instance.GetVoucherFilterListByOrgID(session, orgId, filter);
        }

        //public List<MobilePersonalizationDTO> GetVoucherListByVoucherID(string session, long voucherId)
        //{
        //    return CommunicationVoucherGift.Instance.GetVoucherListByVoucherId(session, voucherId);
        //}

        public List<MemberMobilePersonalizationDTO> GetRuleMemberListByVoucherID(string session, long voucherId)
        {
            return CommunicationVoucherGift.Instance.GetRuleMemberListByVoucherId(session, voucherId);
        }

        public int InsertRuleVoucher(string session, List<MemberMobilePersonalizationDTO> lstMemberMobilePer)
        {
            return CommunicationVoucherGift.Instance.InsertRuleVoucher(session, lstMemberMobilePer);
        }

        public int RemoveRuleVoucher(string session, List<MemberMobilePersonalizationDTO> lstMemberMobilePer)
        {
            return CommunicationVoucherGift.Instance.RemoveRuleVoucher(session, lstMemberMobilePer);
        }
    }
}
