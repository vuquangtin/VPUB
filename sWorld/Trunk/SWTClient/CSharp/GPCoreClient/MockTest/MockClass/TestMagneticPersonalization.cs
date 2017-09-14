using MockTest.Data;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using MockTest.MockClass;
using sWorldModel.Filters;
using sWorldCommunication;

namespace MockTest.MockClass
{
    public class TestMagneticPersonalization : IMagneticPersonalization
    {
        private static TestMagneticPersonalization instance = new TestMagneticPersonalization();
        public static TestMagneticPersonalization Instance
        {
            get {
                if (instance == null){
                    instance = new TestMagneticPersonalization();
                }
                return instance;
            }
        }
        private TestMagneticPersonalization()
        {
        }

        public PreGenerateData GetPreGenerateData(string session, long masterId, long partnerId, int flag) 
        {
            return HardCode.Instance.GetPreGenerateDataDto();
        }

        public List<PreGenerateData> GenerateCardData(string session, string masterNumber, string partnerNumber, long count, PreGenerateData preData, List<PersoMagneticInfo> personalInfoList)
        {
            return new List<PreGenerateData>();
        }

        public int SaveDataPresoCardMagnetic(string session, PersoMagneticCardInforDTO data) 
        {
            return 0;
        }

        //public List<CMSCardmagneticDto> GetCardMagneticList(string session, CardMagneticFilterDto filter)
        //{ 
        //    return HardCode.Instance.GetCardMagneticList();    
        //}

        public List<SubOrgCustomerDTO> GetSubOrgList(string session, long orgId, SubOrgFilterDto filter)
        {
            return HardCode.Instance.GetSubOrgList(orgId);
        }

        public List<MemberMagneticPersoDTO> GetMemberList(string session, long subOrgId, MemberFilter filter)
        {
            return new List<MemberMagneticPersoDTO>();

        }

        public List<MemberMagneticPersoDTO> GetMemberPersoList(string session, long orgId, long subOrgId, PersoChipFilter filter)
        {
            return new List<MemberMagneticPersoDTO>();
        }

        public List<MemberMagneticPersoDTO> GetMemberPersoMagneticList(string session, long orgId, long subOrgId, CardMagneticFilterDto filter)
        {
            return new List<MemberMagneticPersoDTO>();
        }

        public List<CardStatisticsData> StatisticCardByPhysicalStatus(string session)
        {
            return HardCode.Instance.StatisticCardByPhysicalStatus();
            
        }

        public List<CardStatisticsData> StatisticCardByLogicalStatus(string session)
        {
            return new List<CardStatisticsData>();
        }

        public List<MemberDataExcelDto> SendDataToServerForGeneral(string session, PersoMagneticCardInforDTO data)
        {
            return new List<MemberDataExcelDto>();


        }
        //public List<MemberCustomerDTO> GetMemberPersoList(string session, long orgId, long subOrgId, PersoFilter filter)
        //{
        //    return HardCode.Instance.GetMemberList();
        //}

       public List<MagneticPersonalizationDTO> GetMemberMagneticList(string session, long orgId, long subOrgId, CardMagneticFilterDto filter)
        {
            return new List<MagneticPersonalizationDTO>();
        }

       public List<CardmagneticDTO> GetMagneticList(string session, long masterId, long partnerId, CardMagneticFilterDto filter)
       {
           return new List<CardmagneticDTO>();

       }

       public List<CardStatisticsData> StatisticCardMagneticStatus(string session, long orgId, long subOrgId, string prefix)
       {
           return new List<CardStatisticsData>();
       }

       public List<CardStatisticsData> StatisticCardByLogicalStatus(string session, long orgId, long subOrgId, int cardType)
       {
           return new List<CardStatisticsData>();
       }

       public List<MagneticPersonalizationDTO> GetChangeStatusMagnetic(string session, byte status, string Reason, List<long> persoIds)
       {
           return new List<MagneticPersonalizationDTO>();
       }

       public List<CardmagneticDTO> GetChangeStatusPhysicalMagnetic(string session, byte status, string Reason, List<long> MagneticIds)
       {
           return new List<CardmagneticDTO>();
       }
    }

    
}
