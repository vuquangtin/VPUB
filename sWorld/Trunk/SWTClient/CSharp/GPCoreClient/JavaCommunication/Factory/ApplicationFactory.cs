using CommonHelper.Config;
using JavaCommunication.Java;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldCommunication;

namespace JavaCommunication.Factory
{
    public class ApplicationFactory
    {
        private static ApplicationFactory instance = new ApplicationFactory();
        public static ApplicationFactory Instance
        {
            get {
                if (instance == null){
                    instance = new ApplicationFactory();
                }
                return instance;
            }
        }
        private ApplicationFactory()
        {

        }

        public IApplication GetChannel() 
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                case TYPECOMM.JAVA:
                default:
                    return JavaApplication.Instance;
            }
        }
    }
}
