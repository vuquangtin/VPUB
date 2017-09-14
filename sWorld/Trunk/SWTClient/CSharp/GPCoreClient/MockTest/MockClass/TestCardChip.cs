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

namespace MockTest.MockClass
{
    public class TestCardChip : ICardChip
    {
        private static TestCardChip instance = new TestCardChip();
        public static TestCardChip Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestCardChip();
                }
                return instance;
            }
        }
        private TestCardChip()
        {
        }

        public List<CardChipDto> GetCardChipList(string session, long masterId, long partnerId, CardFilterDto filter)
        {
            List<CardChipDto> result = new List<CardChipDto>();
            for (int i = 0; i < 360; i++)
            {
                CardChipDto cardChip = new CardChipDto();
                cardChip.SerialNumberHex = string.Format("mã thẻ {0}", i);
                cardChip.CardChipId = i;
                cardChip.TypeCard = 1;
                cardChip.PhysicalStatus = 1;
                cardChip.Personalized = true;
                result.Add(cardChip);
            }
            return result;
        }

        //public CardDto ImportCard(string session, byte[] serialNumber, int cardType, byte hmkAlias, byte dmkAlias) 
        //{
        //    return new CardDto();
        //}

        #region Master & Partner
        public ResultCheckCardDTO CheckAndGetMasterDataToImportCard(string session, long id, string serialnumbex, int cardtype, byte start, byte stop)
        {
            return HardCode.Instance.CheckAndGetMasterDataToImportCard(start, stop);
        }
        public int UpdateDataForCardBySerialAndMasterId(string session, long masterId,long partnerId, string serialnumber, int cardtype, int status)
        {
            return (int)Status.SUCCESS;
        }

        public ResultCheckCardDTO CheckAndGetPartnerDataToImportCard(string session, long id, string serialnumbex, int cardtype, byte start, byte stop)
        {
            return HardCode.Instance.CheckAndGetMasterDataToImportCard(start, stop);
        }
        public int UpdateDataForCardBySerialAndPartnerId(string session, long id, string serialnumber, int cardtype, int status)
        {
            return (int)Status.SUCCESS;
        }
        #endregion

        #region Card Status
        /// <summary>
        /// Cập nhật danh sách thẻ bị mất
        /// </summary>
        /// <param name="session"></param>
        /// <param name="CardChipIds">Id của thẻ trong hệ thống(List)</param>
        /// <returns></returns>
        public List<MethodResultDto> MarkBrokenCards(string session, long[] CardChipIds)
        {
            return new List<MethodResultDto>();
        }

        /// <summary>
        /// Cập nhật danh sách thẻ hủy đánh dấu hư 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="CardChipIds">Id của thẻ trong hệ thống(List)</param>
        /// <returns></returns>
        public List<MethodResultDto> MarkLostCards(string session, long[] CardChipIds)
        {
            return new List<MethodResultDto>();
        }

        /// <summary>
        /// Cập nhật danh sách thẻ bị mất
        /// </summary>
        /// <param name="session"></param>
        /// <param name="CardChipIds">Id của thẻ trong hệ thống(List)</param>
        /// <returns></returns>
        public List<MethodResultDto> UnMarkBrokenCards(string session, long[] CardChipIds)
        {
            return new List<MethodResultDto>();
        }

        /// <summary>
        /// Cập nhật danh sách thẻ hủy đánh dấu mất
        /// </summary>
        /// <param name="session"></param>
        /// <param name="CardChipIds">Id của thẻ trong hệ thống(List)</param>
        /// <returns></returns>
        public List<MethodResultDto> UnMarkLostCards(string session, long[] CardChipIds)
        {
            return new List<MethodResultDto>();
        }
        #endregion

        public List<CardStatisticsData> StatisticCardChipByStatus(string session, long masterId, long partnerId)
        {
            return new List<CardStatisticsData>();
        }

        public List<CardStatisticsData> StatisticCardChipByPersoStatus(string session)
        {
            return new List<CardStatisticsData>();
        }

        public List<KeyDTO> GetKeyClearEmptyCard(string session, long orgId, string serialNumber, int cartType)
        {
            return new List<KeyDTO>();
        }
    }
}
