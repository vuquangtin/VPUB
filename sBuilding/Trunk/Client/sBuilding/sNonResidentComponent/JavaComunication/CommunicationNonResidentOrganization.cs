using JavaCommunication;
using JavaCommunication.Common;
using sNonResidentComponent.Constants;
using sNonResidentComponent.Model;
using System.Collections.Generic;

namespace sNonResidentComponent.JavaComunication {
    public class CommunicationNonResidentOrganization : CommunicationCommon {
        private static CommunicationNonResidentOrganization instance = new CommunicationNonResidentOrganization();

        public static CommunicationNonResidentOrganization Instance {
            get {
                if (null == instance)
                    instance = new CommunicationNonResidentOrganization();

                return instance;
            }
        }

        private CommunicationNonResidentOrganization() { }

        protected override void BaseURL() {
            base.BaseURL();
            _baseUrl += @"nonresidentorgmg";
        }

        public NonResidentOrganization Insert(string session, NonResidentOrganization nonResOrg) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, NonResidentMethodNames.INSERT_NON_RES_ORG, parameters, nonResOrg, new NonResidentOrganization().GetType()) as NonResidentOrganization;
        }

        public NonResidentOrganization Update(string session, NonResidentOrganization nonResOrg) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, NonResidentMethodNames.UPDATE_NON_RES_ORG, parameters, nonResOrg, new NonResidentOrganization().GetType()) as NonResidentOrganization;
        }

        public int Delete(string session, long nonOrgId) {
            string parameters = Utilites.Instance.Paramater(session, nonOrgId);
            return GetDataFromServer(session, NonResidentMethodNames.DELETE_NON_RES_ORG, parameters);
        }

        public NonResidentOrganization Get(string session, long nonOrgId) {
            string parameters = Utilites.Instance.Paramater(session, nonOrgId);
            return GetDataFromServer(session, NonResidentMethodNames.GET_NON_RES_ORG, parameters, new NonResidentOrganization().GetType()) as NonResidentOrganization;
        }

        public List<NonResidentOrganization> GetListAllOrg(string session, string orgCode) {
            string parameters = Utilites.Instance.Paramater(session, orgCode);
            return GetDataFromServer(session, NonResidentMethodNames.GET_LIST_ALL_NON_RES_ORG, parameters, new List<NonResidentOrganization>().GetType()) as List<NonResidentOrganization>;
        }
    }
}
