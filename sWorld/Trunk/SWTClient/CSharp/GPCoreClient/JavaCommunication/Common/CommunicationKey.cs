using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Common
{
    public class CommunicationKey : CommunicationCommon
    {
        private static CommunicationKey instance = new CommunicationKey();
        public static CommunicationKey Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationKey();
                }
                return instance;
            }
        }
        public CommunicationKey() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"key";
        }

        public MasterInfo GetMasterInfo(string session, string code)
        {
            string parameters = Utilites.Instance.Paramater(session, code);
            var result = GetDataFromServer(MethodNames.GET_MASTER_DATA_BY_KEY, parameters, new ResultObject().GetType()) as ResultObject;
            return result.obj as MasterInfo;
        }

        public List<PartnerInfo> GetPartnerInfo(string session, long masterId, string code)
        {
            string parameters = Utilites.Instance.Paramater(session, masterId.ToString(), code);
            var result = GetDataFromServer(MethodNames.GET_PARTNER_DATA_BY_KEY, parameters, new ResultObject().GetType()) as ResultObject;
            return result.obj as List<PartnerInfo>;
        }
    }
}
