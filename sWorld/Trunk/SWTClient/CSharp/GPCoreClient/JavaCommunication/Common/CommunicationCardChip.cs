using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldModel.Model;
using sWorldModel.Filters;

namespace JavaCommunication.Common
{
    public class CommunicationCardChip : CommunicationCommon
    {
        private static CommunicationCardChip instance = new CommunicationCardChip();
        public static CommunicationCardChip Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationCardChip();
                }
                return instance;
            }
        }
        public CommunicationCardChip() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"card";
        }

        public List<CardChipDto> GetCardChipList(string session, long masterId, long partnerId, CardFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session, masterId, partnerId);
            List<CardChipDto> result = PostDataToServerObject(session, MethodNames.GET_CARD_CHIP_LIST, parameters, filter, new List<CardChipDto>().GetType()) as List<CardChipDto>;
            if (null == result) throw new Exception();

            return result;
        }
        public List<CardChipDto> GetCardChipListExport(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<CardChipDto> result = GetDataFromServer(session, MethodNames.GET_CARD_CHIP_LIST_EXPORT, parameters, new List<CardChipDto>().GetType()) as List<CardChipDto>;
            if (null == result) throw new Exception();

            return result;
        }

        public ResultCheckCardDTO GetKeyMasterBySerianumberAndMasterId(string session, long id, string serialnumber, int cardtype, byte start, byte stop)
        {
            string parameters = Utilites.Instance.Paramater(session, id, serialnumber, cardtype, start, stop);
            ResultCheckCardDTO result = GetDataFromServer(session, MethodNames.CHECK_ADN_GET_MASTERDATA_4_CARD_CHIP, parameters, new ResultCheckCardDTO().GetType()) as ResultCheckCardDTO;
            if (null == result) throw new Exception();

            return result;
        }

        public int UpdateDataForCardBySerialAnsMasterId(string session, long masterId, long partnerId, string serialnumber, int cardtype, int status)
        {
            string parameters = Utilites.Instance.Paramater(session, masterId, partnerId, serialnumber, cardtype, status);
            return GetDataFromServer(session, MethodNames.UPDATE_CARD_DATA_OF_MASTER, parameters);
        }

        public ResultCheckCardDTO CheckAndGetPartnerDataToImportCard(string session, long id, string serialNumber, int cardtype, byte start, byte stop)
        {
            string parameters = Utilites.Instance.Paramater(session, id, serialNumber, cardtype, start, stop);
            ResultCheckCardDTO result = GetDataFromServer(session, MethodNames.CHECK_ADN_GET_PARTNERDATA_4_CARD_CHIP, parameters, new ResultCheckCardDTO().GetType()) as ResultCheckCardDTO;
            if (null == result) throw new Exception();

            return result;
        }

        public int UpdateDataForCardBySerialAndPartnerId(string session, long id, string serialnumber, int cardtype, int status)
        {
            string parameters = Utilites.Instance.Paramater(session, id, serialnumber, cardtype, status);
            return GetDataFromServer(session, MethodNames.UPDATE_CARD_DATA_OF_PARTNER, parameters);
        }

        public List<MethodResultDto> MarkBrokenCards(string session, long[] CardChipIds)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<MethodResultDto> result = PostDataToServerObject(session, MethodNames.MARK_BROKEN_CARDS, parameters, CardChipIds, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;
            if (null == result) throw new Exception();

            return result;
        }

        public List<MethodResultDto> MarkLostCards(string session, long[] CardChipIds)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<MethodResultDto> result = PostDataToServerObject(session, MethodNames.MARK_LOST_CARDS, parameters, CardChipIds, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;
            if (null == result) throw new Exception();

            return result;
        }

        public List<MethodResultDto> UnMarkBrokenCards(string session, long[] CardChipIds)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<MethodResultDto> result = PostDataToServerObject(session, MethodNames.UNMARK_BROKEN_CARDS, parameters, CardChipIds, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;
            if (null == result) throw new Exception();

            return result;
        }

        public List<MethodResultDto> UnMarkLostCards(string session, long[] CardChipIds)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<MethodResultDto> result = PostDataToServerObject(session, MethodNames.UNMARK_LOST_CARDS, parameters, CardChipIds, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;
            if (null == result) throw new Exception();

            return result;
        }

        public DataToReadCardDTO GetKeyForReadCard(string session, string serialnumber, int cardtype, List<int> list)
        {
            string parameters = Utilites.Instance.Paramater(session, serialnumber, cardtype);
            DataToReadCardDTO result = PostDataToServerObject(session, MethodNames.CHECK_ADN_GET_MASTERDATA_4_CARD_CHIP, parameters, list, new DataToReadCardDTO().GetType()) as DataToReadCardDTO;
            if (null == result) throw new Exception();

            return result;
        }

        

        public List<CardStatisticsData> StatisticCardChipByPersoStatus(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<CardStatisticsData> result = GetDataFromServer(session, MethodNames.CHECK_ADN_GET_MASTERDATA_4_CARD_CHIP, parameters, new List<CardStatisticsData>().GetType()) as List<CardStatisticsData>;
            if (null == result) throw new Exception();

            return result;
        }

        public List<KeyDTO> GetKeyClearEmptyCard(string session,long orgId, string serialNumber, int cartType)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId, serialNumber, cartType);
            List<KeyDTO> result = GetDataFromServer(session, MethodNames.CLEAR_EMPTY_CARD, parameters, new List<KeyDTO>().GetType()) as List<KeyDTO>;
            
            return result;
        }
        public int ImportListCard(string session, String username, List<CardChipDto> lstCardChip)
        {
            string parameters = Utilites.Instance.Paramater(session, username);
            return PostDataFromServer(session, MethodNames.IMPORT_lIST_CARD, parameters, lstCardChip);
        }
        public List<CardChipDto> GetCardChipListExport(string session, long orgId)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId);
            List<CardChipDto> result = GetDataFromServer(session, MethodNames.GET_CARD_CHIP_LIST_BY_ORG_PARTNER, parameters, new List<CardChipDto>().GetType()) as List<CardChipDto>;

            return result;
        }
        

    }
}
