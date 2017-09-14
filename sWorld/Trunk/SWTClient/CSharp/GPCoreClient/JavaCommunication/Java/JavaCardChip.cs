using JavaCommunication;
using sWorldModel.Filters;
using sWorldModel.MethodData;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using JavaCommunication.Common;
using sWorldCommunication;

namespace JavaCommunication.Java
{
    public class JavaCardChip : ICardChip
    {
        private static JavaCardChip instance = new JavaCardChip();
        public static JavaCardChip Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaCardChip();
                }
                return instance;
            }
        }
        private JavaCardChip()
        {
        }

        public ResultCheckCardDTO CheckAndGetMasterDataToImportCard(string session, long id, string serialnumbex, int cardtype, byte start, byte stop)
        {
            return CommunicationCardChip.Instance.GetKeyMasterBySerianumberAndMasterId(session, id, serialnumbex, cardtype, start, stop);
        }

        public int UpdateDataForCardBySerialAndMasterId(string session, long masterId, long partnerId, string serialnumber, int cardtype, int status)
        {
            return CommunicationCardChip.Instance.UpdateDataForCardBySerialAnsMasterId(session, masterId, partnerId, serialnumber, cardtype, status);
        }

        public ResultCheckCardDTO CheckAndGetPartnerDataToImportCard(string session, long id, string serialnumbex, int cardtype, byte start, byte stop)
        {
            return CommunicationCardChip.Instance.CheckAndGetPartnerDataToImportCard(session, id, serialnumbex, cardtype, start, stop);
        }

        public int UpdateDataForCardBySerialAndPartnerId(string session, long id, string serialnumber, int cardtype, int status)
        {
            return CommunicationCardChip.Instance.UpdateDataForCardBySerialAndPartnerId(session, id, serialnumber, cardtype, status);
        }

        public DataToReadCardDTO GetKeyForReadCard(string session, string serialNumber, int cardType, List<int> list)
        {
            return CommunicationCardChip.Instance.GetKeyForReadCard(session, serialNumber, cardType, list);
        }

        public DataToReadCardDTO GetKeyForWriteCard(string session, string serialNumber, int cardType, List<int> list)
        {
            return CommunicationCardChip.Instance.GetKeyForReadCard(session, serialNumber, cardType, list);
        }

        public List<CardChipDto> GetCardChipList(string session, long masterId, long partnerId, CardFilterDto filter)
        {
            return CommunicationCardChip.Instance.GetCardChipList(session, masterId, partnerId, filter);
        }
        public List<CardChipDto> GetCardChipListExport(string session)
        {
            return CommunicationCardChip.Instance.GetCardChipListExport(session);
        }
        //public CardDto ImportCard(string session, byte[] serialNumber, int cardType, byte hmkAlias, byte dmkAlias)
        //{
        //    return new CardDto();
        //}

        public List<MethodResultDto> MarkBrokenCards(string session, long[] CardChipIds)
        {
            return CommunicationCardChip.Instance.MarkBrokenCards(session, CardChipIds);
        }

        public List<MethodResultDto> MarkLostCards(string session, long[] CardChipIds)
        {
            return CommunicationCardChip.Instance.MarkLostCards(session, CardChipIds);
        }

        public List<MethodResultDto> UnMarkBrokenCards(string session, long[] CardChipIds)
        {
            return CommunicationCardChip.Instance.UnMarkBrokenCards(session, CardChipIds);
        }

        public List<MethodResultDto> UnMarkLostCards(string session, long[] CardChipIds)
        {
            return CommunicationCardChip.Instance.UnMarkLostCards(session, CardChipIds);
        }

        public List<CardStatisticsData> StatisticCardChipByStatus(string session, long masterId, long partnerId)
        {
            return CommunicationChipPersonalization.Instance.StatisticCardChipByStatus(session, masterId, partnerId);
        }

        public List<CardStatisticsData> StatisticCardChipByPersoStatus(string session)
        {
            return CommunicationCardChip.Instance.StatisticCardChipByPersoStatus(session);
        }

        public List<KeyDTO> GetKeyClearEmptyCard(string session, long orgId, string serialNumber, int cartType)
        {
            return CommunicationCardChip.Instance.GetKeyClearEmptyCard(session, orgId, serialNumber, cartType);
        }
        public int ImportListCard(string session, string username, List<CardChipDto> lstCardChip)
        {
            return CommunicationCardChip.Instance.ImportListCard(session, username, lstCardChip);
        }
        public List<CardChipDto> GetCardChipListExport(string session, long OrgId)
        {
            return CommunicationCardChip.Instance.GetCardChipListExport(session, OrgId);
        }
        
    } 
}
