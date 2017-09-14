using JavaCommunication.Java;
using JavaCommunication;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper.Config;

namespace JavaCommunication.Factory
{
    public class KeyFactory
    {
        private static KeyFactory instance = new KeyFactory();
        public static KeyFactory Instance
        {
            get {
                if (instance == null){
                    instance = new KeyFactory();
                }
                return instance;
            }
        }
        private KeyFactory() { }

        public IKey GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return TestKey.Instance;
                case TYPECOMM.JAVA:
                    return JavaKey.Instance;
                default:
                    return TestKey.Instance;
            }
        }
    }
}
