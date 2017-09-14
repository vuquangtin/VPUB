using System;
using System.Collections.Generic;
using System.Text;
using sWorldModel.Model;
using JavaCommunication.Java;
using JavaCommunication;
using CommonHelper.Config;
using sWorldCommunication;

namespace JavaCommunication.Factory
{
    public class AuthenticationFactory
    {
        private static AuthenticationFactory instance = new AuthenticationFactory();
        public static AuthenticationFactory Instance
        {
            get {
                if (instance == null){
                    instance = new AuthenticationFactory();
                }
                return instance;
            }
        }
        private AuthenticationFactory() { }

        public IAuthentication GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                case TYPECOMM.JAVA:
                default:
                    return JavaAuthentication.Instance;
            }
        }
    }
}
