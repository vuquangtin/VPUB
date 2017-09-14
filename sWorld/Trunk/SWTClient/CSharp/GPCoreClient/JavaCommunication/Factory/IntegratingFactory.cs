using JavaCommunication.Java;
using JavaCommunication;
using sWorldModel.Filters;
using sWorldModel.Integrating;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper.Config;
using sWorldCommunication;


namespace JavaCommunication.Factory
{
    public class IntegratingFactory
    {
        private static IntegratingFactory instance = new IntegratingFactory();
        public static IntegratingFactory Instance
        {
            get {
                if (instance == null){
                    instance = new IntegratingFactory();
                }
                return instance;
            }
        }
        private IntegratingFactory() { }

        public IIntegrating GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                case TYPECOMM.JAVA:
                default:
                    return JavaIntegrating.Instance;
            }
        }
    }
}
