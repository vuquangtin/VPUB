using CommonHelper.Config;
using JavaCommunication;
using sNonResidentComponent.Interface;
using sNonResidentComponent.Java;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Factory
{
    public class NonResidentFactory
    {
        private static NonResidentFactory instance = new NonResidentFactory();

        public static NonResidentFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new NonResidentFactory();
                }
                return instance;
            }
        }

        private NonResidentFactory()
        { }

        public INonResident GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaNonResident.Instance;
                default:
                    return JavaNonResident.Instance;
            }
        }
    }
}
