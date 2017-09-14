using CommonHelper.Config;
using JavaCommunication;
using sNonResidentComponent.Interface;
using sNonResidentComponent.Java;

namespace sNonResidentComponent.Factory
{
    public class OrganizationMgFactory
    {
        private static OrganizationMgFactory instance = new OrganizationMgFactory();

        public static OrganizationMgFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new OrganizationMgFactory();
                }
                return instance;
            }
        }

        private OrganizationMgFactory()
        { }

        public IOrganizationMg GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaOrganizationMg.Instance;
                default:
                    return JavaOrganizationMg.Instance;
            }
        }
    }
}
