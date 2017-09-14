using CommonHelper.Config;
using JavaCommunication;
using sMeetingComponent.Interface;
using sMeetingComponent.Java;

namespace sMeetingComponent.Factory
{
    public class OrganizationMeetingFactory
    {
        private static OrganizationMeetingFactory instance = new OrganizationMeetingFactory();

        public static OrganizationMeetingFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new OrganizationMeetingFactory();
                }
                return instance;
            }
        }

        private OrganizationMeetingFactory()
        { }

        public IOrganizationMeeting GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaOrganizationMeeting.Instance;
                default:
                    return JavaOrganizationMeeting.Instance;
            }
        }
    }
}
