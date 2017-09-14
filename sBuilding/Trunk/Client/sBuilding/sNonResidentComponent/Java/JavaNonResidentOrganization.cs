using sNonResidentComponent.Interface;
using sNonResidentComponent.JavaComunication;
using sNonResidentComponent.Model;
using System.Collections.Generic;

namespace sNonResidentComponent.Java {
    public class JavaNonResidentOrganization : INonResidentOrganization {
        private static JavaNonResidentOrganization instance = new JavaNonResidentOrganization();
        public static JavaNonResidentOrganization Instance {
            get {
                if (null == instance) {
                    instance = new JavaNonResidentOrganization();
                }

                return instance;
            }
        }

        private JavaNonResidentOrganization() { }

        public NonResidentOrganization Insert(string session, NonResidentOrganization nonResOrg) {
            return CommunicationNonResidentOrganization.Instance.Insert(session, nonResOrg);
        }

        public NonResidentOrganization Update(string session, NonResidentOrganization nonResOrg) {
            return CommunicationNonResidentOrganization.Instance.Update(session, nonResOrg);
        }

        public int Delete(string session, long nonOrgId) {
            return CommunicationNonResidentOrganization.Instance.Delete(session, nonOrgId);
        }

        public NonResidentOrganization Get(string session, long nonOrgId) {
            return CommunicationNonResidentOrganization.Instance.Get(session, nonOrgId);
        }

        public List<NonResidentOrganization> GetListAllOrg(string session, string orgCode) {
            return CommunicationNonResidentOrganization.Instance.GetListAllOrg(session, orgCode);
        }
    }
}
