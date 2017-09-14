using JavaCommunication.Java;
using JavaCommunication;
using sWorldModel.Filters;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper.Config;
using sWorldCommunication;

namespace JavaCommunication.Factory
{
    public class ManagerSystemFactory
    {
       private static ManagerSystemFactory instance = new ManagerSystemFactory();
        public static ManagerSystemFactory Instance
        {
            get {
                if (instance == null){
                    instance = new ManagerSystemFactory();
                }
                return instance;
            }
        }
        private ManagerSystemFactory() { }

        public IManagerSystem GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                case TYPECOMM.JAVA:
                default:
                    return JavaManegerSystem.Instance;
            }
        }
    }
}
