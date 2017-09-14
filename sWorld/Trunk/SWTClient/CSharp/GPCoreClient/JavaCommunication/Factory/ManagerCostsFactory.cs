using CommonHelper.Config;
using JavaCommunication.Java;
using sWorldCommunication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Factory
{
    public class ManagerCostsFactory
    {
        private static ManagerCostsFactory instance = new ManagerCostsFactory();

        public static ManagerCostsFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManagerCostsFactory();
                }
                return instance;
            }
        }
        private ManagerCostsFactory()
        {

        }

        public IManagerCosts GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    //return TestApplication.Instance;
                    return null;
                case TYPECOMM.JAVA:
                    return JavaManagerCosts.Instance;
                default:
                    return JavaManagerCosts.Instance;

            }
        }
    }
}
