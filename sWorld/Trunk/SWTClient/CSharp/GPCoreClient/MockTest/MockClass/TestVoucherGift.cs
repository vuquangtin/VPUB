using MockTest.Data;
using sWorldModel.Filters;
using sWorldModel.MethodData;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldCommunication;
using sWorldCommunication.Interface;

namespace MockTest.MockClass
{
    public class TestVoucherGift : IVoucherGift
    {
        private static TestVoucherGift instance = new TestVoucherGift();
        public static TestVoucherGift Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestVoucherGift();
                }
                return instance;
            }
        }
        private TestVoucherGift()
        {
        }

        public VoucherGift InsertVoucherGift(string session, VoucherGift vouchergift)
        {
            return new VoucherGift();
        }

        public VoucherGift UpdateVoucherGift(string session, VoucherGift vouchergift)
        {
            return new VoucherGift();
        }

        public int RemoveVoucherGift(string session, long voucherId)
        {
            return (int)Status.SUCCESS;
        }

        public List<VoucherGift> GetAllVourcher(string session)
        {
            return new List<VoucherGift>();
        }

        public VoucherGift GetVourcherByVourcherId(string session, long vourId)
        {
            return new VoucherGift();
        }

        public List<VoucherGift> GetAllVourcherByOrgId(string session, long subOrgId)
        {
            return new List<VoucherGift>();
        }

        public List<VoucherGift> GetVoucherFilterList(string session, VoucherGiftFilterDto filter)
        {
            return new List<VoucherGift>();
        }

        public List<VoucherGift> GetVoucherFilterListByOrgID(string session, long orgId, VoucherGiftFilterDto filter)
        {
            return new List<VoucherGift>();
        }

        //public List<MobilePersonalizationDTO> GetVoucherListByVoucherID(string session, long voucherId)
        //{
        //    return new List<MobilePersonalizationDTO>();
        //}

        public List<MemberMobilePersonalizationDTO> GetRuleMemberListByVoucherID(string session, long voucherId)
        {
            return new List<MemberMobilePersonalizationDTO>();
        }

        public int InsertRuleVoucher(string session, List<MemberMobilePersonalizationDTO> lstMemberMobilePer)
        {
            return (int)Status.SUCCESS;
        }

        public int RemoveRuleVoucher(string session, List<MemberMobilePersonalizationDTO> lstMemberMobilePer)
        {
            return (int)Status.SUCCESS;
        }
    }
}
