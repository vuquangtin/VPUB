using sMeetingComponent.Interface;
using sMeetingComponent.JavaComunication;
using sMeetingComponent.Model;
using System.Collections.Generic;

namespace sMeetingComponent.Java
{
    public class JavaOrganizationMeeting : IOrganizationMeeting
    {
        private static JavaOrganizationMeeting instance = new JavaOrganizationMeeting();

        public static JavaOrganizationMeeting Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaOrganizationMeeting();
                }
                return instance;
            }
        }

        private JavaOrganizationMeeting()
        {
        }

        public List<OrganizationMeeting> getOrganization(string session)
        {
            return CommunicationOrganizationMeeting.Instance.getOrganization(session);
        }
        public List<OrganizationMeeting> getOrganization_ASC(string session)
        {
            return CommunicationOrganizationMeeting.Instance.getOrganization_ASC(session);
        }

    }
}
