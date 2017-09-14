using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldModel.Filters;

namespace JavaCommunication.Common
{
    public class CommunicationCardMagnetic : CommunicationCommon
    {
        private static CommunicationCardMagnetic instance = new CommunicationCardMagnetic();
        public static CommunicationCardMagnetic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationCardMagnetic();
                }
                return instance;
            }
        }
        public CommunicationCardMagnetic() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"card";
        }

        public PreGenerateData GetPreGenerateData(string session, long masterId, long partnerId, int flag)
        {
            string parameters = Utilites.Instance.Paramater(session, masterId.ToString(), partnerId.ToString(), flag);
            PreGenerateData result = GetDataFromServer(session, MethodNames.GET_GENERATE_CARD_DATA, parameters, new PreGenerateData().GetType()) as PreGenerateData;
            return result;
        }

        public List<CardmagneticDTO> GetMagneticList(string session, long masterId, long partnerId, CardMagneticFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session, masterId, partnerId);
            var result = PostDataToServerObject(session, MethodNames.POST_LIST_MAGNETIC, parameters, filter, new List<CardmagneticDTO>().GetType()) as List<CardmagneticDTO>;
            return result;
        }

        //public List<PreGenerateData> GenerateCardData(string session, string masterNumber, string partnerNumber, long count, PreGenerateData preData, List<PersoMagneticInfo> personalInfoList)
        //{
        //    string parameters = Utilites.Instance.Paramater(session, masterNumber, partnerNumber, count.ToString());
        //    object obj = Utilites.Instance.ParObject(preData, personalInfoList);
        //    var result = PostDataToServerObject(session, MethodNames.POST_GENERATE_CARD_DATA, parameters, obj, new List<PreGenerateData>().GetType()) as List<PreGenerateData>;
        //    return result;
        //}

        //public int PresoCardMagnetic(string session, List<MemberDataExcelDto> cardPerDataList)
        //{
        //    string parameters = Utilites.Instance.Paramater(session);
        //    return PostDataFromServer(session, MethodNames.POST_PERSO_CARD_MAGNETIC, parameters, cardPerDataList);
        //}

        //public List<MemberDataExcelDto> SendDataToServerForGeneral(string session, PersoMagneticCardInforDTO data)
        //{
        //    string parameters = Utilites.Instance.Paramater(session);
        //    var result = PostDataToServerObject(session, MethodNames.POST_PERSO_DATA_4_GENERATE_CARD, parameters, data, new List<MemberDataExcelDto>().GetType()) as List<MemberDataExcelDto>;
        //    return result;
        //}

        // Lưu thông tin cá thể hóa thẻ từ xuống Database

        //public int SaveDataPresoCardMagnetic(string session, PersoMagneticCardInforDTO data)
        //{
        //    string parameters = Utilites.Instance.Paramater(session);
        //    return PostDataFromServer(session, MethodNames.POST_SAVE_PERSO_DATA_CARD_MAGNETIC, parameters, data);
        //}

        //public List<MagneticPersonalization> GetMemberMagneticList(string session, long orgId, long subOrgId, CardMagneticFilterDto filter)
        //{
        //    string parameters = Utilites.Instance.Paramater(session, orgId, subOrgId);
        //    var result = PostDataToServerObject(session, MethodNames.POST_MEMBER_LIST_PERSOMAGNETIC, parameters, filter, new List<MagneticPersonalization>().GetType()) as List<MagneticPersonalization>;
        //    return result;
        //}

        public List<CardStatisticsData> StatisticCardByPhysicalStatus(string session, long orgId, long subOrgId, string prefix)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId, subOrgId, prefix);
            var result = GetDataFromServer(session, MethodNames.GET_STATISTIC_STATUS_MAGNETIC, parameters, new List<CardStatisticsData>().GetType()) as List<CardStatisticsData>;
            return result;
        }

        public List<CardStatisticsData> StatisticCardByLogicalStatus(string session, long orgId, long subOrgId, int cardType)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId, subOrgId, cardType);
            var result = GetDataFromServer(session, MethodNames.GET_LOGICAL_STATUS_MAGNETIC, parameters, new List<CardStatisticsData>().GetType()) as List<CardStatisticsData>;
            return result;
        }


        public List<CardmagneticDTO> GetChangeStatusPhysicalMagnetic(string session, byte status, string Reason, List<long> MagneticIds)
        {
            string parameters = Utilites.Instance.Paramater(session, status, Reason);
            List<CardmagneticDTO> result = PostDataToServerObject(session, MethodNames.UPDATE_CARD_MAGNETIC_PHYSICALSTATUS, parameters, MagneticIds, new List<CardmagneticDTO>().GetType()) as List<CardmagneticDTO>;
            return result;
        }

        //CLEAR CARD EMPTY
        public int ClearCardEmpty(string session, string serialNumber)
        {
            string parameters = Utilites.Instance.Paramater(session, serialNumber);
            return GetDataFromServer(session, MethodNames.CLEAR_CARD_EMPTY, parameters);
        }

    }
}
