using JavaCommunication;
using JavaCommunication.Common;
using sNonResidentComponent.Constants;
using sNonResidentComponent.Model;
using System.Collections.Generic;

namespace sNonResidentComponent.JavaComunication {
    public class CommunicationNonResidentSubOrganization : CommunicationCommon {
        private static CommunicationNonResidentSubOrganization instance = new CommunicationNonResidentSubOrganization();

        public static CommunicationNonResidentSubOrganization Instance {
            get {
                if (null == instance)
                    instance = new CommunicationNonResidentSubOrganization();

                return instance;
            }
        }

        private CommunicationNonResidentSubOrganization() { }

        protected override void BaseURL() {
            base.BaseURL();
            _baseUrl += @"nonresidentsuborgmg";
        }

        public NonResidentSubOrganization Insert(string session, NonResidentSubOrganization nonResSubOrg) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, NonResidentMethodNames.INSERT_NON_RES_SUB_ORG, parameters, nonResSubOrg, new NonResidentSubOrganization().GetType()) as NonResidentSubOrganization;
        }

        public NonResidentSubOrganization Update(string session, NonResidentSubOrganization nonResSubOrg) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, NonResidentMethodNames.UPDATE_NON_RES_SUB_ORG, parameters, nonResSubOrg, new NonResidentSubOrganization().GetType()) as NonResidentSubOrganization;
        }

        public int Delete(string session, long nonSubOrgId) {
            string parameters = Utilites.Instance.Paramater(session, nonSubOrgId);
            return GetDataFromServer(session, NonResidentMethodNames.DELETE_NON_RES_SUB_ORG, parameters);
        }

        public NonResidentSubOrganization Get(string session, long nonSubOrgId) {
            string parameters = Utilites.Instance.Paramater(session, nonSubOrgId);
            return GetDataFromServer(session, NonResidentMethodNames.GET_NON_RES_SUB_ORG, parameters, new NonResidentSubOrganization().GetType()) as NonResidentSubOrganization;
        }

        public List<NonResidentSubOrganization> GetListAllSubOrg(string session, long nonOrgId) {
            string parameters = Utilites.Instance.Paramater(session, nonOrgId);
            return GetDataFromServer(session, NonResidentMethodNames.GET_LIST_ALL_NON_RES_SUB_ORG, parameters, new List<NonResidentSubOrganization>().GetType()) as List<NonResidentSubOrganization>;
        }
    }
}
