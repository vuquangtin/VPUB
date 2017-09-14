using JavaCommunication;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using JavaCommunication.Test;

namespace JavaCommunication.Java
{
    public class TestKey : Organization
    {
        private static TestKey instance = new TestKey();
        public static TestKey Instance
        {
            get {
                if (instance == null){
                    instance = new TestKey();
                }
                return instance;
            }
        }
        private TestKey()
        {
        }

        public string GetSvk(string session) 
        {
            return string.Empty;
        }

        public MasterInfoDTO GetMasterInfo(string session, string code)
        {
            if (string.IsNullOrEmpty(code))
                return new MasterInfoDTO();
            if (code.Equals(SystemCode.MasterCode))
                return new MasterInfoDTO();
            return HardCode.Instance.GetMasterInfoDto(code);
        }

        public List<PartnerInfoDTO> GetPartnerInfo(string session, long masterId, string code)
        {
            if (string.IsNullOrEmpty(code))
                return new List<PartnerInfoDTO>();
            if (code.Equals(SystemCode.PartnerCode))
                return new List<PartnerInfoDTO>();
            return HardCode.Instance.GetPartnerInfoDto(code);
            //return null;
        }

        public ResultCheckCardDTO CheckAndGetMasterDataToImportCard(string session, long id, string aa, int card, byte st, byte top)
        {
            return null;
        }
    }
}
