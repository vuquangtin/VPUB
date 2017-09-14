using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Common
{
    public class CommunicationVoucherGift : CommunicationCommon
    {
        private static CommunicationVoucherGift instance = new CommunicationVoucherGift();
        public static CommunicationVoucherGift Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationVoucherGift();
                }
                return instance;
            }
        }

        public CommunicationVoucherGift() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"other";
        }

        public VoucherGift InsertVoucherGift(string session, VoucherGift vouchergift)
        {       
            string parameters = Utilites.Instance.Paramater(session);
            VoucherGift result = PostDataToServerObject(session, MethodNames.INSERT_VOUCHER, parameters, vouchergift, new VoucherGift().GetType()) as VoucherGift;
            //if (null == result) throw new Exception();
            return result;
        }

        public VoucherGift UpdateVoucherGift(string session, VoucherGift vouchergift)
        {
            string parameters = Utilites.Instance.Paramater(session);
            VoucherGift result = PostDataToServerObject(session, MethodNames.UPDATE_VOUCHER, parameters, vouchergift, new VoucherGift().GetType()) as VoucherGift;
            //if (null == result) throw new Exception();
            return result;
        }

        public int RemoveVoucherGift(string session, long voucherId)
        {
            string parameters = Utilites.Instance.Paramater(session, voucherId);
            return GetDataFromServer(session, MethodNames.DELETE_VOUCHER, parameters);
        }

        public List<VoucherGift> GetAllVourcher(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<VoucherGift> result = GetDataFromServer(session, MethodNames.GET_ALL_VOUCHER, parameters, new List<VoucherGift>().GetType()) as List<VoucherGift>;
            //if (null == result) throw new Exception();
            return result;
        }

        public VoucherGift GetVourcherByVourcherId(string session, long vourId)
        {
            string parameters = Utilites.Instance.Paramater(session, vourId);
            VoucherGift result = GetDataFromServer(session, MethodNames.GET_VOUCHER_BY_VOUCHER_ID, parameters, new VoucherGift().GetType()) as VoucherGift;
            //if (null == result) throw new Exception();
            return result;
        }

        public List<VoucherGift> GetAllVourcherByOrgId(string session, long OrgId)
        {
            string parameters = Utilites.Instance.Paramater(session, OrgId);
            List<VoucherGift> result = GetDataFromServer(session, MethodNames.GET_VOUCHER_BY_VOUCHER_ID, parameters, new List<VoucherGift>().GetType()) as List<VoucherGift>;
            //if (null == result) throw new Exception();
            return result;
        }

        public List<VoucherGift> GetVoucherFilterList(string session, VoucherGiftFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session);
            var result = PostDataToServerObject(session, MethodNames.GET_VOUCHER_BY_VOUCHER_FILTER, parameters, filter, new List<VoucherGift>().GetType()) as List<VoucherGift>;
            return result;
        }

        public List<VoucherGift> GetVoucherFilterListByOrgID(string session, long orgId, VoucherGiftFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId);
            var result = PostDataToServerObject(session, MethodNames.GET_VOUCHER_BY_VOUCHER_FILTER_ID, parameters, filter, new List<VoucherGift>().GetType()) as List<VoucherGift>;
            return result;
        }

        //public List<MobilePersonalizationDTO> GetVoucherListByVoucherId(string session, long voucherId)
        //{
        //    string parameters = Utilites.Instance.Paramater(session, voucherId);
        //    var result = GetDataFromServer(session, MethodNames.GET_VOUCHERLIST_BY_VOUCHER_ID, parameters, new List<MobilePersonalizationDTO>().GetType()) as List<MobilePersonalizationDTO>;
        //    if (null == result) throw new Exception();
        //    return result;
        //}

        public List<MemberMobilePersonalizationDTO> GetRuleMemberListByVoucherId(string session, long voucherId)
        {
            string parameters = Utilites.Instance.Paramater(session, voucherId);
            var result = GetDataFromServer(session, MethodNames.GET_VOUCHERLIST_BY_VOUCHER_ID, parameters, new List<MemberMobilePersonalizationDTO>().GetType()) as List<MemberMobilePersonalizationDTO>;
            //if (null == result) throw new Exception();
            return result;
        }

        public int InsertRuleVoucher(string session, List<MemberMobilePersonalizationDTO> lstMemberMobilePer)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.INSERT_VOUCHER_MOBILE_PERSON, parameters, lstMemberMobilePer);
        }

        public int RemoveRuleVoucher(string session, List<MemberMobilePersonalizationDTO> lstMemberMobilePer)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.REMOVE_VOUCHER_MOBILE_PERSON, parameters, lstMemberMobilePer);
        }
    }
}
