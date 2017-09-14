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
    public class MagneticPersonalizationFactory
    {
       private static MagneticPersonalizationFactory instance = new MagneticPersonalizationFactory();
        public static MagneticPersonalizationFactory Instance
        {
            get {
                if (instance == null){
                    instance = new MagneticPersonalizationFactory();
                }
                return instance;
            }
        }
        private MagneticPersonalizationFactory() { }

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
