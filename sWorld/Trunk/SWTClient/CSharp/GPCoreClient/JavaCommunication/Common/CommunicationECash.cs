using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Common
{
    public class CommunicationECash: CommunicationCommon
    {
        private static CommunicationECash instance = new CommunicationECash();
        public static CommunicationECash Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationECash();
                }
                return instance;
            }
        }
        public CommunicationECash() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"ecashs";
        }

        //các hàm card config

        public List<GroupItemConfig> getGroupItemByConfig(string session,long Orgcode)
        {
            string parameters = Utilites.Instance.Paramater(session,Orgcode);
            List<GroupItemConfig> result = GetDataFromServer(session, MethodNames.getGroupItemByConfig, parameters, new List<GroupItemConfig>().GetType()) as List<GroupItemConfig>;
            //if (null == result) throw new Exception();
            return result;
        }
        public Config_card InsertEcashConfig(string session, Config_card ecashconfig)
        {
            string parameters = Utilites.Instance.Paramater(session);
            Config_card result = PostDataToServerObject(session, MethodNames.INSERT_ECASHCONFIG, parameters, ecashconfig, new Config_card().GetType()) as Config_card;
            //if (null == result) throw new Exception();
            return result;
        }

        public Config_card UpdateEcashConfig(string session, Config_card ecashconfig)
        {
            string parameters = Utilites.Instance.Paramater(session);
            Config_card result = PostDataToServerObject(session, MethodNames.UPDATE_ECASHCONFIG, parameters, ecashconfig, new Config_card().GetType()) as Config_card;
            //if (null == result) throw new Exception();
            return result;
        }

        public int RemoveEcashConfig(string session, long ecashconfigId)
        {
            string parameters = Utilites.Instance.Paramater(session, ecashconfigId);
            return GetDataFromServer(session, MethodNames.DELETE_ECASHCONFIG, parameters);
        }
     
        public List<Config_card> GetAllEcashConfig(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<Config_card> result = GetDataFromServer(session, MethodNames.GET_ALL_ECASHCONFIG, parameters, new List<Config_card>().GetType()) as List<Config_card>;
            //if (null == result) throw new Exception();
            return result;
        }
        public Config_card GetEcashConfigById(string session, long ecashconfigId)
        {
            string parameters = Utilites.Instance.Paramater(session, ecashconfigId);
            Config_card result = GetDataFromServer(session, MethodNames.GET_ECASHCONFIG_BY_ID, parameters, new Config_card().GetType()) as Config_card;
            //if (null == result) throw new Exception();
            return result;
        }
        public List<Config_card> GetConfigFilterListByConfigId(string session, long ecashconfigId,EcashConfigFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session,ecashconfigId);
            List<Config_card> result = PostDataToServerObject(session, MethodNames.GetConfigFilterListByConfigId, parameters, filter,new List<Config_card>().GetType()) as List<Config_card>;
            //if (null == result) throw new Exception();
            return result;
        }
        //public VoucherGift GetEcashById(string session, long vourId)
        //{
        //    string parameters = Utilites.Instance.Paramater(session, vourId);
        //    VoucherGift result = GetDataFromServer(session, MethodNames.GET_VOUCHER_BY_VOUCHER_ID, parameters, new VoucherGift().GetType()) as VoucherGift;
        //    //if (null == result) throw new Exception();
        //    return result;
        //}
        //

        //end card config

        //begin group item
        public GroupDto InsertGroupItem(string session, GroupDto ecashgroupitem)
        {
            string parameters = Utilites.Instance.Paramater(session);
            GroupDto result = PostDataToServerObject(session, MethodNames.INSERT_ECASHGROUP, parameters, ecashgroupitem, new GroupDto().GetType()) as GroupDto;
            
            return result;
        }

        public GroupDto UpdateGroupItem(string session, GroupDto ecashgroupitem)
        {
            string parameters = Utilites.Instance.Paramater(session);
            GroupDto result = PostDataToServerObject(session, MethodNames.UPDATE_ECASHGROUP, parameters, ecashgroupitem, new GroupDto().GetType()) as GroupDto;
           
            return result;
        }

        public GroupDto GetGroupItemByGroupItemId(string session, long ecashgroupitemId)
        {
            string parameters = Utilites.Instance.Paramater(session, ecashgroupitemId);
            GroupDto result = GetDataFromServer(session, MethodNames.GetGroupItemByGroupItemId, parameters, new GroupDto().GetType()) as GroupDto;

            return result;
        }
        public int DeleteGroupItem(string session, long ecashgroupitemId)
        {
            string parameters = Utilites.Instance.Paramater(session, ecashgroupitemId);
            return GetDataFromServer(session, MethodNames.DELETE_ECASHGROUP, parameters);
        }

        public List<GroupDto> GetAllGroupItem(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<GroupDto> result = GetDataFromServer(session, MethodNames.GET_ALL_ECASHGROUP, parameters, new List<GroupDto>().GetType()) as List<GroupDto>;
         
            return result;
        }
        public List<GroupDto> GetGroupItemFilterListByGroupId(string session, long orgId, GroupItemFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId);
            var result = PostDataToServerObject(session, MethodNames.GetGroupItemFilterListByGroupId, parameters, filter, new List<GroupDto>().GetType()) as List<GroupDto>;
            return result;
        }
     
        //end group item

        //BEGIN ITEM
        public ItemDto InsertItem(string session, ItemDto ecashconfig)
        {
            string parameters = Utilites.Instance.Paramater(session);
            ItemDto result = PostDataToServerObject(session, MethodNames.INSERT_ECASHITEM, parameters, ecashconfig, new ItemDto().GetType()) as ItemDto;

            return result;
        }

        public ItemDto UpdateItem(string session, ItemDto ecashconfig)
        {
            string parameters = Utilites.Instance.Paramater(session);
            ItemDto result = PostDataToServerObject(session, MethodNames.UPDATE_ECASHITEM, parameters, ecashconfig, new ItemDto().GetType()) as ItemDto;

            return result;
        }
        public List<ItemDto> GetItemByGroupItemId(string session, long ecashgroupId)
        {
            string parameters = Utilites.Instance.Paramater(session, ecashgroupId);
            List<ItemDto> result = GetDataFromServer(session, MethodNames.GetItemByGroupItemId, parameters, new List<ItemDto>().GetType()) as List<ItemDto>;

            return result;
        }
        public ItemDto GetItemByItemId(string session, long ecashitemId)
        {
            string parameters = Utilites.Instance.Paramater(session, ecashitemId);
            ItemDto result = GetDataFromServer(session, MethodNames.GetItemByItemId, parameters, new ItemDto().GetType()) as ItemDto;

            return result;
        }
        public int DeleteItem(string session, long ecashconfigId)
        {
            string parameters = Utilites.Instance.Paramater(session, ecashconfigId);
            return GetDataFromServer(session, MethodNames.DELETE_ECASHITEM, parameters);
        }
        
        public List<ItemDto> GetAllItem(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<ItemDto> result = GetDataFromServer(session, MethodNames.GET_ALL_ECASHITEM, parameters, new List<ItemDto>().GetType()) as List<ItemDto>;

            return result;
        }
        public List<ItemDto> GetItemFilterListByGroupId(string session, long ecashgroupId, ItemFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session,ecashgroupId);
            var result = PostDataToServerObject(session, MethodNames.GetItemFilterListByGroupId, parameters, filter, new List<ItemDto>().GetType()) as List<ItemDto>;

            return result;
        }

        //END ITEM


        //BEGIN PAYIN
        
        public int ValidateCard(string session, string serialNumber, string dataPayIn, string dataPayOut,string code)
        {
            string parameters = Utilites.Instance.Paramater(session,  serialNumber,  dataPayIn,  dataPayOut, code);
            return GetDataObjectFromServer(session, MethodNames.VALIDATE_CARD, parameters);
        }

        public PayInDto GetDataPayInWriteToCard(string session, PayInDto payinDto, int cardType)
        {
            string parameters = Utilites.Instance.Paramater(session, cardType);
            PayInDto result = PostDataToServerObject(session, MethodNames.GET_DATA_PAYIN_WRITE_TO_CARD, parameters, payinDto, new PayInDto().GetType()) as PayInDto;
            if (null == result) throw new Exception();

            return result;
        }

        public int UpdateStatusPayIn(string session, PayInDto payinDto, string field)
        {
            string parameters = Utilites.Instance.Paramater(session,field);
            return PostDataFromServer(session, MethodNames.UPDATE_STATUS_PAYIN, parameters, payinDto);
        }

        public List<PayOutDto> GetDataPayOutWriteToCard(string session, List<PayOutDto> payoutList, int cardType)
        {
            string parameters = Utilites.Instance.Paramater(session, cardType);
            List<PayOutDto> result = PostDataToServerObject(session, MethodNames.GET_DATA_PAYOUT_WRITE_TO_CARD, parameters, payoutList, new List<PayOutDto>().GetType()) as List<PayOutDto>;
            //if (null == result) throw new Exception();

            return result;
        }

        public int UpdateStatusPayOut(string session, List<PayOutDto> payoutList, string field)
        {
            string parameters = Utilites.Instance.Paramater(session, field);
            return PostDataFromServer(session, MethodNames.UPDATE_STATUS_PAYOUT, parameters, payoutList);
        }
        public List<PayInStatisticDto> GetPayInRequestFilterByPayInRequestId(string session, long payinRequestId, StatisticTouUpFilter filter)
        {
            string parameters = Utilites.Instance.Paramater(session,payinRequestId);
            var result = PostDataToServerObject(session, MethodNames.GetPayInRequestFilterByPayInRequestId, parameters, filter, new List<PayInStatisticDto>().GetType()) as List<PayInStatisticDto>;

            return result;
        }
        public List<PayOutStatisticDto> GetPayOutRequestFilterByPayOutRequestId(string session, long payoutRequestId, StatisticDeductFilter filter)
        {
            string parameters = Utilites.Instance.Paramater(session, payoutRequestId);
            var result = PostDataToServerObject(session, MethodNames.GetPayOutRequestFilterByPayOutRequestId, parameters, filter, new List<PayOutStatisticDto>().GetType()) as List<PayOutStatisticDto>;

            return result;
        }
        //END PAYIN
    }
}
