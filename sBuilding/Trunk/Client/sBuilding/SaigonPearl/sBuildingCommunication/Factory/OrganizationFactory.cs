using CommonHelper.Config;
using JavaCommunication;
using JavaCommunication.Java;
using sWorldCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sBuildingCommunication.Factory
{
    public class OrganizationFactory
    {
        private static OrganizationFactory instance = new OrganizationFactory();
        public static OrganizationFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrganizationFactory();
                }
                return instance;
            }
        }
        private OrganizationFactory() { }

        public IOrganization GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                case TYPECOMM.JAVA:
                default:
                    return JavaOrganization.Instance;
            }
        }
    }
}
