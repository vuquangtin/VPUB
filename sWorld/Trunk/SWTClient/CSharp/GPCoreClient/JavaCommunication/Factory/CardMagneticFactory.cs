using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldCommunication;
using CommonHelper.Config;
using JavaCommunication.Java;

namespace JavaCommunication.Factory
{
   public class CardMagneticFactory
    {
         private static CardMagneticFactory instance = new CardMagneticFactory();
        public static CardMagneticFactory Instance
        {
            get {
                if (instance == null){
                    instance = new CardMagneticFactory();
                }
                return instance;
            }
        }
        private CardMagneticFactory() { }

        public IMagneticPersonalization GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                case TYPECOMM.JAVA:
                default:
                    return JavaMagneticPersonalization.Instance;
            }
        }
    }
}
