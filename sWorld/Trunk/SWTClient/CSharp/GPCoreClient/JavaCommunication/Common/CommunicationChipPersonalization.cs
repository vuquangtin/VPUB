using sWorldModel.Filters;
using sWorldModel.MethodData;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;

namespace JavaCommunication.Common
{
    public class CommunicationChipPersonalization: CommunicationCommon
    {
        private static CommunicationChipPersonalization instance = new CommunicationChipPersonalization();
        public static CommunicationChipPersonalization Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationChipPersonalization();
                }
                return instance;
            }
        }
        public CommunicationChipPersonalization() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"perso";
        }

        #region Status PersoCard

        public List<MethodResultDto> LockPersoes(string session, long[] ChipPersoIds, string lockReason)
        {
            string parameters = Utilites.Instance.Paramater(session, lockReason);
            List<MethodResultDto> result = PostDataToServerObject(session, MethodNames.LOCK_PERSOES, parameters, ChipPersoIds, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;
            return result;
        }

        public List<MethodResultDto> UnLockPersoes(string session, long[] ChipPersoIds, string unlockReason)
        {
            string parameters = Utilites.Instance.Paramater(session, unlockReason);
            List<MethodResultDto> result = PostDataToServerObject(session, MethodNames.UNLOCK_PERSOES, parameters, ChipPersoIds, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;
            return result;
        }

        public List<MethodResultDto> CancelPersoes(string session, long[] ChipPersoIds, string cancelReason)
        {
            string parameters = Utilites.Instance.Paramater(session, cancelReason);
            List<MethodResultDto> result = PostDataToServerObject(session, MethodNames.CANCEL_PERSOES, parameters, ChipPersoIds, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;
            return result;
        }

        public List<MethodResultDto> ExtendPerso(string session, long[] ChipPersoIds, string expirationDate)
        {
            string parameters = Utilites.Instance.Paramater(session, expirationDate);
            List<MethodResultDto> result = PostDataToServerObject(session, MethodNames.EXTEND_PERSO, parameters, ChipPersoIds, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;
            return result;
        }

        // Hàm thay đổi trạng thái tổng hợp
        public List<MemberCustomerDTO> GetChangeStatus(string session, byte status, string Reason, List<long> ChipPersoIds)
        {
            string parameters = Utilites.Instance.Paramater(session, Reason, status);
            List<MemberCustomerDTO> result = PostDataToServerObject(session, MethodNames.UPDATE_CARD_CHIP_STATUS, parameters, ChipPersoIds, new List<MemberCustomerDTO>().GetType()) as List<MemberCustomerDTO>;
            return result;
        }

        #endregion

        #region PersoCard

        //READ CARD
        public DataToReadCardDTO GetKeyForReadCard(string session, string serialNumber, int cardType, List<int> list)
        {
            string parameters = Utilites.Instance.Paramater(session, serialNumber, cardType);
            DataToReadCardDTO result = PostDataToServerObject(session, MethodNames.GET_KEY_FOR_READ_CARD, parameters, list, new DataToReadCardDTO().GetType()) as DataToReadCardDTO;
            return result;
        }

        public DataForReadCard GetDataToReadCard(string session, string serialNumber, int cardType, string memberData)
        {
            string parameters = Utilites.Instance.Paramater(session, serialNumber, cardType, memberData);
            DataForReadCard result = GetDataFromServer(session, MethodNames.GET_DATA_TO_READ_CARD, parameters, new DataForReadCard().GetType()) as DataForReadCard;
            return result;
        }

        /// <summary>
        /// check and get person data for writing
        /// </summary>
        /// <param name="session"></param>
        /// <param name="memberId"></param>
        /// <param name="serialNumber"></param>
        /// <param name="cardType"></param>
        /// <param name="sectorStart"></param>
        /// <param name="partnercode">to encrypt data</param>
        /// <returns></returns>
        public DataToWriteCardDTO CheckAndGetPersoData(string session, long memberId, string serialNumber, int cardType, byte sectorStart, string partnercode)
        {
            string parameters = Utilites.Instance.Paramater(session, memberId, serialNumber, cardType, sectorStart, partnercode);
            DataToWriteCardDTO result = GetDataFromServer(session, MethodNames.CHECK_AND_GET_PERSO_PERSO, parameters, new DataToWriteCardDTO().GetType()) as DataToWriteCardDTO;
            return result;
        }

        public int PersoCardChip(string session, long memberId, string serialNumberHex)
        {
            string parameters = Utilites.Instance.Paramater(session, memberId, serialNumberHex);
            return GetDataFromServer(session, MethodNames.PERSO_CARD_CHIP, parameters);
        }

        //CLEAR CARD DATA
        public int ClearCardData(string session, string serialNumber)
        {
            string parameters = Utilites.Instance.Paramater(session, serialNumber);
            return GetDataFromServer(session, MethodNames.CLEAR_CARD_DATA, parameters);
        }
        
       
        public DataToWriteCardDTO CheckAndGetAppDataToClearCard(string session, string serialNumber, int cardType, byte sectorStart, byte sectorStop, string issuer)
        {
            string parameters = Utilites.Instance.Paramater(session, serialNumber, cardType, sectorStart, sectorStop, issuer);
            DataToWriteCardDTO result = GetDataFromServer(session, MethodNames.CHECK_AND_GET_APP_DATA_TO_CLEAR_CARD, parameters, new DataToWriteCardDTO().GetType()) as DataToWriteCardDTO;
            return result;
        }

        //UPDATE CARD
        public DataToWriteCardDTO GetDataToUpdateCard(string session, string serialNumber, byte sectorStart, string issuer)
        {
            string parameters = Utilites.Instance.Paramater(session, serialNumber, sectorStart, issuer);
            DataToWriteCardDTO result = GetDataFromServer(session, MethodNames.GET_DATA_TO_UPDATE_CARD, parameters, new DataToWriteCardDTO().GetType()) as DataToWriteCardDTO;
            return result;
        }

        public int UpdateMemberAppOfPerso(string session, string serialNumber, string lastUpdateDate)
        {
            string parameters = Utilites.Instance.Paramater(session, serialNumber, lastUpdateDate);
            return GetDataFromServer(session, MethodNames.UPDATE_MEMBER_APP_OF_PERSO, parameters);
        }


        #endregion

        public List<CardStatisticsData> StatisticCardChipByStatus(string session, long masterId, long partnerId)
        {
            string parameters = Utilites.Instance.Paramater(session, masterId, partnerId);
            List<CardStatisticsData> result = GetDataFromServer(session, MethodNames.GET_STATISTIC_CARD_CHIP_BY_STATUS, parameters, new List<CardStatisticsData>().GetType()) as List<CardStatisticsData>;
            if (null == result) throw new Exception();

            return result;
        }

    }
}
