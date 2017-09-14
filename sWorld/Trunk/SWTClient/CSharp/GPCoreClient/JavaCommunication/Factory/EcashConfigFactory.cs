using CommonHelper.Config;
using JavaCommunication.Java;
using sWorldCommunication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Factory
{
   public class EcashConfigFactory
    {
        private static EcashConfigFactory instance = new EcashConfigFactory();
        public static EcashConfigFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EcashConfigFactory();
                }
                return instance;
            }
        }
        private EcashConfigFactory()
        {

        }

        public IeCash GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    //return TestApplication.Instance;
                       return null;
                case TYPECOMM.JAVA:
                    return JavaECash.Instance;
                default:
                   return JavaECash.Instance;
                
            }
        }
    }
}
