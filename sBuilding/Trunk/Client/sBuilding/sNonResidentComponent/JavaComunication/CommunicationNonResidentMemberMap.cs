using JavaCommunication;
using JavaCommunication.Common;
using sNonResidentComponent.Constants;
using sNonResidentComponent.Model;
using sNonResidentComponent.Model.CustomObj;
using System.Collections.Generic;

namespace sNonResidentComponent.JavaComunication {
    public class CommunicationNonResidentMemberMap : CommunicationCommon {
        private static CommunicationNonResidentMemberMap instance = new CommunicationNonResidentMemberMap();

        public static CommunicationNonResidentMemberMap Instance {
            get {
                if (null == instance)
                    instance = new CommunicationNonResidentMemberMap();

                return instance;
            }
        }

        private CommunicationNonResidentMemberMap() { }

        protected override void BaseURL() {
            base.BaseURL();
            _baseUrl += @"nonresidentmemmapmg";
        }

        public NonResidentMemberMap Insert(string session, NonResidentMemberMap nonResMemMap) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, NonResidentMethodNames.INSERT_NON_RES_MEMBER_MAP, parameters, nonResMemMap, new NonResidentMemberMap().GetType()) as NonResidentMemberMap;
        }

        public NonResidentMemberMap Update(string session, NonResidentMemberMap nonResMemMap) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, NonResidentMethodNames.UPDATE_NON_RES_MEMBER_MAP, parameters, nonResMemMap, new NonResidentMemberMap().GetType()) as NonResidentMemberMap;
        }

        public int Delete(string session, long nonMemMapId) {
            string parameters = Utilites.Instance.Paramater(session, nonMemMapId);
            return GetDataFromServer(session, NonResidentMethodNames.DELETE_NON_RES_MEMBER_MAP, parameters);
        }

        public NonResidentMemberMap Get(string session, long nonMemMapId) {
            string parameters = Utilites.Instance.Paramater(session, nonMemMapId);
            return GetDataFromServer(session, NonResidentMethodNames.GET_NON_RES_MEMBER_MAP, parameters, new NonResidentMemberMap().GetType()) as NonResidentMemberMap;
        }

        public List<NonResidentMemberMapCustom> GetListAllMemMap(string session, long nonOrgId) {
            string parameters = Utilites.Instance.Paramater(session, nonOrgId);
            return GetDataFromServer(session, NonResidentMethodNames.GET_LIST_ALL_NON_RES_MEMBER_MAP, parameters, new List<NonResidentMemberMapCustom>().GetType()) as List<NonResidentMemberMapCustom>;
        }
    }
}
