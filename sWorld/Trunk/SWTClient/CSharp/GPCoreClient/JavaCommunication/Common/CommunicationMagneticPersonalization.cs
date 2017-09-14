using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldModel.Filters;

namespace JavaCommunication.Common
{
    public class CommunicationMagneticPersonalization : CommunicationCommon
    {
        private static CommunicationMagneticPersonalization instance = new CommunicationMagneticPersonalization();
        public static CommunicationMagneticPersonalization Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationMagneticPersonalization();
                }
                return instance;
            }
        }
        public CommunicationMagneticPersonalization() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"perso";
        }

        public List<MemberDataExcelDto> SendDataToServerForGeneral(string session, PersoMagneticCardInforDTO data)
        {
            string parameters = Utilites.Instance.Paramater(session);
            var result = PostDataToServerObject(session, MethodNames.POST_PERSO_DATA_4_GENERATE_CARD, parameters, data, new List<MemberDataExcelDto>().GetType()) as List<MemberDataExcelDto>;
            return result;
        }

        // Lưu thông tin cá thể hóa thẻ từ xuống Database

        public int SaveDataPresoCardMagnetic(string session, PersoMagneticCardInforDTO data)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.POST_SAVE_PERSO_DATA_CARD_MAGNETIC, parameters, data);
        }

        public List<MagneticPersonalizationDTO> GetMemberMagneticList(string session, long orgId, long subOrgId, CardMagneticFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId, subOrgId);
            var result = PostDataToServerObject(session, MethodNames.POST_MEMBER_LIST_PERSOMAGNETIC, parameters, filter, new List<MagneticPersonalizationDTO>().GetType()) as List<MagneticPersonalizationDTO>;
            return result;
        }

        public List<MagneticPersonalizationDTO> GetChangeStatusMagnetic(string session, byte status, string Reason, List<long> persoIds)
        {
            string parameters = Utilites.Instance.Paramater(session, Reason, status);
            List<MagneticPersonalizationDTO> result = PostDataToServerObject(session, MethodNames.UPDATE_CARD_MAGNETIC_STATUS, parameters, persoIds, new List<MagneticPersonalizationDTO>().GetType()) as List<MagneticPersonalizationDTO>;
            return result;
        }

        //public List<CardmagneticDTO> GetChangeStatusPhysicalMagnetic(string session, byte status, string Reason, List<long> MagneticIds)
        //{
        //    string parameters = Utilites.Instance.Paramater(session, Reason, status);
        //    List<CardmagneticDTO> result = PostDataToServerObject(session, MethodNames.UPDATE_CARD_MAGNETIC_PHYSICALSTATUS, parameters, MagneticIds, new List<CardmagneticDTO>().GetType()) as List<CardmagneticDTO>;
        //    return result;
        //}


    }
}
