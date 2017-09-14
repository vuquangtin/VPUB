using MockTest.Data;
using sWorldCommunication.Interface;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockTest.MockClass
{
    public class TestECash : IeCash
    {
        private static TestECash instance = new TestECash();
        public static TestECash Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestECash();
                }
                return instance;
            }
        }
        private TestECash()
        {
        }
        //begin Card_Config
        public List<GroupItemConfig> getGroupItemByConfig(string session,long Orgcode)
        {
            return new List<GroupItemConfig>();
        }
        public Config_card InsertEcashConfig(string session, Config_card Config_card)
        {
            return new Config_card();
        }

        public Config_card UpdateEcashConfig(string session, Config_card Config_card)
        {
            return new Config_card();
        }

        public int RemoveEcashConfig(string session, long ecashconfigId)
        {
            return (int)Status.SUCCESS;
        }

        public List<Config_card> GetAllEcashConfig(string session)
        {
            return new List<Config_card>();
        }
        public Config_card GetEcashConfigById(string session, long vourId)
        {
            return new Config_card();
        }
        public List<Config_card> GetConfigFilterListByConfigId(string session, long ecashconfigId,EcashConfigFilterDto filter)
        {
            return new List<Config_card>();
        }
        //end card_config

        //begin group item
        public GroupDto InsertGroupItem(string session, GroupDto groupitem)
        {
            return new GroupDto();
        }

        public GroupDto UpdateGroupItem(string session, GroupDto groupitem)
        {
            return new GroupDto();
        }

        public int DeleteGroupItem(string session, long groupitemId)
        {
            return (int)Status.SUCCESS;
        }

        public List<GroupDto> GetAllGroupItem(string session)
        {
            return new List<GroupDto>();
        }
        public GroupDto GetGroupItemByGroupItemId(string session, long groupitemid)
        {
            return new GroupDto();
        }
        public List<GroupDto> GetGroupItemFilterListByGroupId(string session, long orgId, GroupItemFilterDto filter)
        {
            return new List<GroupDto>();
        }

        //end group item

        //BEGFIN ITEM
        public ItemDto InsertItem(string session, ItemDto item)
        {
            return new ItemDto();
        }

        public ItemDto UpdateItem(string session, ItemDto item)
        {
            return new ItemDto();
        }

        public int DeleteItem(string session, long itemId)
        {
            return (int)Status.SUCCESS;
        }

        public List<ItemDto> GetAllItem(string session)
        {
            return new List<ItemDto>();
        }
        public ItemDto GetItemByItemId(string session, long itemid)
        {
            return new ItemDto();
        }
        public List<ItemDto> GetItemByGroupItemId(string session, long itemid)
        {
            return new List<ItemDto>();
        }
        public List<ItemDto> GetItemFilterListByGroupId(string session, long itemid, ItemFilterDto filter)
        {
            return new List<ItemDto>();
        }
        //END ITEM

        //BEGIN PAYIN

      
        public int ValidateCard(string session, string serialNumber, string dataPayIn, string dataPayOut,string code)
        {
            return 0;
        }

        public PayInDto GetDataPayInWriteToCard(string session, PayInDto payinDto, int cardType)
        {
            return new PayInDto();
        }

        public int UpdateStatusPayIn(string session,PayInDto payInData, string field)
        {
            return 0;
        }

        public List<PayOutDto> GetDataPayOutWriteToCard(string session, List<PayOutDto> payoutDto, int cardType)
        {
            return new List<PayOutDto>();
        }

        public int UpdateStatusPayOut(string session, List<PayOutDto> payOut, string field)
        {
            return 0;
        }

        public List<PayInStatisticDto> GetPayInRequestFilterByPayInRequestId(string session, long payinRequestId, StatisticTouUpFilter filter)
        {
            return new List<PayInStatisticDto>();
        }
        public List<PayOutStatisticDto> GetPayOutRequestFilterByPayOutRequestId(string session, long payinRequestId, StatisticDeductFilter filter)
        {
            return new List<PayOutStatisticDto>();
        }
        //END PAYIN
    }
}
