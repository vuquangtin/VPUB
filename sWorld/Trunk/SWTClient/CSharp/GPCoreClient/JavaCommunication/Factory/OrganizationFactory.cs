using JavaCommunication.Java;
using JavaCommunication;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper.Config;
using sWorldCommunication;


namespace JavaCommunication.Factory
{
    public class OrganizationFactory
    {
        private static OrganizationFactory instance = new OrganizationFactory();
        public static OrganizationFactory Instance
        {
            get {
                if (instance == null){
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
