using sNonResidentComponent.Interface;
using sNonResidentComponent.JavaComunication;
using sNonResidentComponent.Model;
using sNonResidentComponent.Model.Old;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Java
{
    public class JavaOrganizationMg : IOrganizationMg
    {
        private static JavaOrganizationMg instance = new JavaOrganizationMg();

        public static JavaOrganizationMg Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaOrganizationMg();
                }
                return instance;
            }
        }

        private JavaOrganizationMg()
        {
        }

        public List<OrganizationMg> getOrganization(string session)
        {
            return CommunicationOrganizationMg.Instance.getOrganization(session);
        }
        public List<OrganizationMg> getOrganization_ASC(string session)
        {
            return CommunicationOrganizationMg.Instance.getOrganization_ASC(session);

        }
    }
}
