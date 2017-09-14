using sNonResidentComponent.Interface;
using sNonResidentComponent.JavaComunication;
using sNonResidentComponent.Model;
using System.Collections.Generic;

namespace sNonResidentComponent.Java {
    public class JavaNonResidentSubOrganization : INonResidentSubOrganization {
        private static JavaNonResidentSubOrganization instance = new JavaNonResidentSubOrganization();
        public static JavaNonResidentSubOrganization Instance {
            get {
                if (null == instance) {
                    instance = new JavaNonResidentSubOrganization();
                }

                return instance;
            }
        }

        private JavaNonResidentSubOrganization() { }

        public NonResidentSubOrganization Insert(string session, NonResidentSubOrganization nonResSubOrg) {
            return CommunicationNonResidentSubOrganization.Instance.Insert(session, nonResSubOrg);
        }

        public NonResidentSubOrganization Update(string session, NonResidentSubOrganization nonResSubOrg) {
            return CommunicationNonResidentSubOrganization.Instance.Update(session, nonResSubOrg);
        }

        public int Delete(string session, long nonSubOrgId) {
            return CommunicationNonResidentSubOrganization.Instance.Delete(session, nonSubOrgId);
        }

        public NonResidentSubOrganization Get(string session, long nonSubOrgId) {
            return CommunicationNonResidentSubOrganization.Instance.Get(session, nonSubOrgId);
        }

        public List<NonResidentSubOrganization> GetListAllSubOrg(string session, long nonOrgId) {
            return CommunicationNonResidentSubOrganization.Instance.GetListAllSubOrg(session, nonOrgId);
        }
    }
}
