using JavaCommunication;
using JavaCommunication.Common;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldModel.Filters;
using sWorldCommunication;

namespace JavaCommunication.Java
{
    public class JavaMagneticPersonalization : IMagneticPersonalization
    {
        private static JavaMagneticPersonalization instance = new JavaMagneticPersonalization();
        public static JavaMagneticPersonalization Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaMagneticPersonalization();
                }
                return instance;
            }
        }
        private JavaMagneticPersonalization()
        {
        }

        public PreGenerateData GetPreGenerateData(string session, long masterId, long partnerId, int flag)
        {
            return CommunicationCardMagnetic.Instance.GetPreGenerateData(session, masterId, partnerId, flag);
        }

        // Cá thể hóa thẻ từ
        public List<MemberDataExcelDto> SendDataToServerForGeneral(string session, PersoMagneticCardInforDTO data)
        {
            return CommunicationMagneticPersonalization.Instance.SendDataToServerForGeneral(session, data);
        }
        //public List<PreGenerateData> GenerateCardData(string session, string masterNumber, string partnerNumber, long count, PreGenerateData preData, List<PersoMagneticInfo> personalInfoList)
        //{
        //    return CommunicationCardMagnetic.Instance.GenerateCardData(session, masterNumber, partnerNumber, count, preData, personalInfoList);
        //}

        // Lưu thông tin cá thể hóa thẻ từ xuống Database
        public int SaveDataPresoCardMagnetic(string session, PersoMagneticCardInforDTO data)
        {
            return CommunicationMagneticPersonalization.Instance.SaveDataPresoCardMagnetic(session, data);
        }

        public int UpdateGroup(string session, GroupCustomerDto group)
        {
            return CommunicationManagerSystem.Instance.UpdateGroup(session, group);
        }

        public List<SubOrgCustomerDTO> GetSubOrgList(string session, long orgId, SubOrgFilterDto filter)
        {
            return CommunicationOrg.Instance.GetSubOrgList(session, orgId, filter);
        }

        //public List<CMSCardmagneticDto> GetCardMagneticList(string session, CardMagneticFilterDto filter)
        //{
        //    return new List<CMSCardmagneticDto>();
        //}

        public List<MemberMagneticPersoDTO> GetMemberList(string session, long subOrgId, MemberFilter filter)
        {
            return new List<MemberMagneticPersoDTO>();
        }

        public List<MemberMagneticPersoDTO> GetMemberPersoList(string session, long orgId, long subOrgId, PersoChipFilter filter)
        {
            return new List<MemberMagneticPersoDTO>();
        }

        public List<MagneticPersonalizationDTO> GetMemberMagneticList(string session, long orgId, long subOrgId, CardMagneticFilterDto filter)
        {
            return CommunicationMagneticPersonalization.Instance.GetMemberMagneticList(session, orgId, subOrgId, filter);
        }

        public List<CardmagneticDTO> GetMagneticList(string session, long masterId, long partnerId, CardMagneticFilterDto filter)
        {
            return CommunicationCardMagnetic.Instance.GetMagneticList(session,masterId,partnerId,filter);
        }

        public List<CardStatisticsData> StatisticCardMagneticStatus(string session, long orgId, long subOrgId, string prefix)
        {
            return CommunicationCardMagnetic.Instance.StatisticCardByPhysicalStatus(session, orgId, subOrgId, prefix);
        }

        public List<CardStatisticsData> StatisticCardByLogicalStatus(string session, long orgId, long subOrgId, int cardType)
        {
            return CommunicationCardMagnetic.Instance.StatisticCardByLogicalStatus(session, orgId, subOrgId, cardType);
        }

        public List<MagneticPersonalizationDTO> GetChangeStatusMagnetic(string session, byte status, string Reason, List<long> persoIds)
        {
            return CommunicationMagneticPersonalization.Instance.GetChangeStatusMagnetic(session, status, Reason, persoIds);
        }

        public List<CardmagneticDTO> GetChangeStatusPhysicalMagnetic(string session, byte status, string Reason, List<long> MagneticIds)
        {
            return CommunicationCardMagnetic.Instance.GetChangeStatusPhysicalMagnetic(session, status, Reason, MagneticIds);
        }

        /// <summary>
        /// Xóa thông tin thẻ trong bảng CardChip
        /// </summary>
        /// <param name="session"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public int ClearCardEmpty(string session, string serialNumber)
        {
            return CommunicationCardMagnetic.Instance.ClearCardEmpty(session, serialNumber);
        }
    }
}
