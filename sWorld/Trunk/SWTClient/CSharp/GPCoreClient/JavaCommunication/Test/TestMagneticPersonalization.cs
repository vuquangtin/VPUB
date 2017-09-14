using JavaCommunication;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using JavaCommunication.Test;
using sWorldModel.Filters;

namespace JavaCommunication.Java
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

        public int PresoCardMagnetic(string session, List<MagneticPersData> cardPerDataList) 
        {
            return 0;
        }

        public List<CMSCardmagneticDto> GetCardMagneticList(string session, CardMagneticFilterDto filter)
        { 
            return HardCode.Instance.GetCardMagneticList();    
        }

        public List<SubOrgCustomerDTO> GetSubOrgList(string session, long orgId, SubOrgFilterDto filter)
        {
            return HardCode.Instance.GetSubOrgList();
        }

        public List<MemberMagneticPersoDTO> GetMemberList(string session, long subOrgId, MemberFilter filter)
        {
            return new List<MemberMagneticPersoDTO>();

        }

        public List<MemberMagneticPersoDTO> GetMemberPersoList(string session, long orgId, long subOrgId, PersoFilter filter)
        {
            return new List<MemberMagneticPersoDTO>();
        }

        public List<MemberMagneticPersoDTO> GetMemberPersoMagneticList(string session, long orgId, long subOrgId, CardMagneticFilterDto filter)
        {
            return HardCode.Instance.GetMemberMagneticList(filter);
        }

        //public List<MemberCustomerDTO> GetMemberPersoList(string session, long orgId, long subOrgId, PersoFilter filter)
        //{
        //    return HardCode.Instance.GetMemberList();
        //}
        //List<MemberCustomerDTO> GetMemberPersoList(string session, long orgId, long subOrgId, PersoFilter filter);

  
}

    
}
