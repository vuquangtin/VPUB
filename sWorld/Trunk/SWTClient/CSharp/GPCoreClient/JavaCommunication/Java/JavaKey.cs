using JavaCommunication;
using JavaCommunication;
using JavaCommunication.Common;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Java
{
    public class JavaKey : IKey
    {
        private static JavaKey instance = new JavaKey();
        public static JavaKey Instance
        {
            get {
                if (instance == null){
                    instance = new JavaKey();
                }
                return instance;
            }
        }
        private JavaKey()
        {
        }

        public string GetSvk(string session) 
        {
            return string.Empty;
        }

        public MasterInfo GetMasterInfo(string session, string code)
        {
            return CommunicationKey.Instance.GetMasterInfo(session,code);
        }

        public List<PartnerInfo> GetPartnerInfo(string session, long masterId, string code)
        {
            return CommunicationKey.Instance.GetPartnerInfo(session, masterId, code);
        }	
    }
}
