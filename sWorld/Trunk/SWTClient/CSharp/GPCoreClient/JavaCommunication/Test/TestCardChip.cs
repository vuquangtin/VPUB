using JavaCommunication;
using sWorldModel.Filters;
using sWorldModel.MethodData;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;

namespace JavaCommunication.Java
{
    public class TestCardChip : ICardChip
    {
        private static TestCardChip instance = new TestCardChip();
        public static TestCardChip Instance
        {
            get {
                if (instance == null){
                    instance = new TestCardChip();
                }
                return instance;
            }
        }
        private TestCardChip()
        {
        }

        public List<CardDto> GetCardList(string session, CardFilterDto filter, int skip, int take, out int totalRecords) 
        {
            totalRecords = 0;
            return new List<CardDto>();
        }

        public DataForImportCard CheckAndGetDataToImportCard(string session, byte[] serialNumber, int cardType) 
        {
            return new DataForImportCard();
        }

        public CardDto ImportCard(string session, byte[] serialNumber, int cardType, byte hmkAlias, byte dmkAlias)
        {
            return new CardDto();
        }

        public List<MethodResultDto> MarkBrokenCards(string session, long[] CardChipIds)
        {
            return new List<MethodResultDto>();
        }

        public List<MethodResultDto> MarkLostCards(string session, long[] CardChipIds)
        {
            return new List<MethodResultDto>();
        }

        public List<MethodResultDto> UnMarkBrokenCards(string session, long[] CardChipIds)
        {
            return new List<MethodResultDto>();
        }

        public List<MethodResultDto> UnMarkLostCards(string session, long[] CardChipIds)
        {
            return new List<MethodResultDto>();
        }

        public DataForClearCard CheckAndGetDataToClearCard(string session, byte[] serialNumber, int cardType, byte curHmkAlias, byte curDmkAlias, List<AppMetadataDto> curAppList)
        {
            return new DataForClearCard();
        }

        public void ClearCardData(string session, byte[] serialNumber, byte hmkAlias, byte dmkAlias)
        {
        }

        public DataForReadCard GetDataToReadCard(string session, byte[] serialNumber, int cardType, List<AppMetadataDto> appMetadataList, byte curDmkAlias)
        {
            return new DataForReadCard();
        }

        public List<CardStatisticsData> StatisticCardByPhysicalStatus(string session)
        {
            return new List<CardStatisticsData>();
        }

        public List<CardStatisticsData> StatisticCardByPersoStatus(string session)
        {
            return new List<CardStatisticsData>();
        }

        public ResultCheckCardDTO CheckAndGetMasterDataToImportCard(string session, long id, string serialnumbex, int cardtype, byte start, byte stop)
        {
            return new ResultCheckCardDTO();
        }

        public int UpdateDataForCardBySerialAnsMasterId(string session, long id, string serialnumber, int cardtype, int status)
        {
            return 1;
        }

        public DataToReadCardDTO GetKeyForReadCard(string session, string serialNumber, int cardType, List<int> list)
        {
            return null;
        }
    }
}
