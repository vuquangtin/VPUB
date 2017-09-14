using CommonHelper.Config;
using JavaCommunication;
using sBuildingCommunication.Interface;
using sBuildingCommunication.Java;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sBuildingCommunication.Factory
{
    public class AccessFactory
    {
        private static AccessFactory instance = new AccessFactory();
        public static AccessFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccessFactory();
                }
                return instance;
            }
        }
        private AccessFactory()
        {

        }

        public IAccess GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    //return TestApplication.Instance;
                    return null;
                case TYPECOMM.JAVA:
                    return JavaAccess.Instance;
                default:
                    return JavaAccess.Instance;

            }
        }
    }
}

