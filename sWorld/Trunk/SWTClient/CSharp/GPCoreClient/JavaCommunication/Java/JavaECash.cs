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
    public class JavaECash : IeCash
    {
        private static JavaECash instance = new JavaECash();
        public static JavaECash Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaECash();
                }
                return instance;
            }
        }
        private JavaECash()
        {
        }
        //thêm xóa sửa eacashconfig
        public Config_card InsertEcashConfig(string session, Config_card eacshconfig)
        {
            return CommunicationECash.Instance.InsertEcashConfig(session, eacshconfig);
        }

        public Config_card UpdateEcashConfig(string session, Config_card eacshconfig)
        {
            return CommunicationECash.Instance.UpdateEcashConfig(session, eacshconfig);
        }

        public int RemoveEcashConfig(string session, long eacshconfigId)
        {
            return CommunicationECash.Instance.RemoveEcashConfig(session, eacshconfigId);
        }
        public List<GroupItemConfig> getGroupItemByConfig(string session,long Orgcode)
        {
            return CommunicationECash.Instance.getGroupItemByConfig(session, Orgcode);
        }
       
        public List<Config_card> GetAllEcashConfig(string session)
        {
            return CommunicationECash.Instance.GetAllEcashConfig(session);
        }
        public Config_card GetEcashConfigById(string session, long ecashconfigId)
        {
            return CommunicationECash.Instance.GetEcashConfigById(session, ecashconfigId);
        }
        public List<Config_card> GetConfigFilterListByConfigId(string session,long ecashconfigId,EcashConfigFilterDto filter)
        {
            return CommunicationECash.Instance.GetConfigFilterListByConfigId(session, ecashconfigId,filter);
        }
        //end card config

        //begin group item
        public   GroupDto InsertGroupItem(string session, GroupDto ecashgroupitem)
        {
            return CommunicationECash.Instance.InsertGroupItem(session, ecashgroupitem);
        }
    
        public GroupDto UpdateGroupItem(string session, GroupDto ecashgroupitem)
        {
            return CommunicationECash.Instance.UpdateGroupItem(session, ecashgroupitem);
        }

        public  int DeleteGroupItem(string session, long ecashgroupitemId)
        {
            return CommunicationECash.Instance.DeleteGroupItem(session, ecashgroupitemId);
        }

       
        public List<GroupDto> GetAllGroupItem(string session)
        {
            return CommunicationECash.Instance.GetAllGroupItem(session);
        }
        public GroupDto GetGroupItemByGroupItemId(string session, long ecashgroupId)
        {
            return CommunicationECash.Instance.GetGroupItemByGroupItemId(session, ecashgroupId);
        }

        public List<GroupDto> GetGroupItemFilterListByGroupId(string session, long orgId, GroupItemFilterDto filter)
        {
            return CommunicationECash.Instance.GetGroupItemFilterListByGroupId(session, orgId, filter);
        }
        //end group item

        //BEGIB ITEM
        public ItemDto InsertItem(string session, ItemDto ecashitem)
        {
            return CommunicationECash.Instance.InsertItem(session, ecashitem);
        }

        public ItemDto UpdateItem(string session, ItemDto ecashitem)
        {
            return CommunicationECash.Instance.UpdateItem(session, ecashitem);
        }

        public int DeleteItem(string session, long ecashitemId)
        {
            return CommunicationECash.Instance.DeleteItem(session, ecashitemId);
        }
               
        public   List<ItemDto> GetAllItem(string session)
        {
            return CommunicationECash.Instance.GetAllItem(session);
        }
        public ItemDto GetItemByItemId(string session, long ecashitemId)
        {
            return CommunicationECash.Instance.GetItemByItemId(session, ecashitemId);
        }
        public List<ItemDto> GetItemByGroupItemId(string session, long ecashgroupId)
        {
            return CommunicationECash.Instance.GetItemByGroupItemId(session, ecashgroupId);
        }
        public List<ItemDto> GetItemFilterListByGroupId(string session, long ecashgroupId, ItemFilterDto filter)
        {
            return CommunicationECash.Instance.GetItemFilterListByGroupId(session, ecashgroupId, filter);
        }
        //END ITEM
        public int ValidateCard(string session, string serialNumber, string dataPayIn, string dataPayOut,string code)
        {
            return CommunicationECash.Instance.ValidateCard(session, serialNumber, dataPayIn, dataPayOut,code);
        }

        public PayInDto GetDataPayInWriteToCard(string session,PayInDto payinDto,int cardType)
        {
            return CommunicationECash.Instance.GetDataPayInWriteToCard(session, payinDto,cardType);
        }

        public int UpdateStatusPayIn(string session, PayInDto payInData, string field)
        {
            return CommunicationECash.Instance.UpdateStatusPayIn(session, payInData, field);
        }

        public List<PayOutDto> GetDataPayOutWriteToCard(string session, List<PayOutDto> PayOut, int cardType)
        {
            return CommunicationECash.Instance.GetDataPayOutWriteToCard(session, PayOut, cardType);
        }
        public int UpdateStatusPayOut(string session, List<PayOutDto> payOut, string field)
        {
            return CommunicationECash.Instance.UpdateStatusPayOut(session, payOut, field);
        }
        public List<PayInStatisticDto> GetPayInRequestFilterByPayInRequestId(string session, long payinRequestId, StatisticTouUpFilter filter)
        {
            return CommunicationECash.Instance.GetPayInRequestFilterByPayInRequestId(session, payinRequestId, filter);
        }
        public List<PayOutStatisticDto> GetPayOutRequestFilterByPayOutRequestId(string session, long payinRequestId, StatisticDeductFilter filter)
        {
            return CommunicationECash.Instance.GetPayOutRequestFilterByPayOutRequestId(session, payinRequestId, filter);
        }

    }
}
