using JavaCommunication.Java;
using sWorldModel.Filters;
using sWorldModel.MethodData;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using CommonHelper.Config;
using sWorldCommunication;


namespace JavaCommunication.Factory
{
    public class ChipPersonalizationFactory
    {
        private static ChipPersonalizationFactory instance = new ChipPersonalizationFactory();
        public static ChipPersonalizationFactory Instance
        {
            get {
                if (instance == null){
                    instance = new ChipPersonalizationFactory();
                }
                return instance;
            }
        }
        private ChipPersonalizationFactory() { }

        public IChipPersonalization GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                case TYPECOMM.JAVA:
                default:
                    return JavaChipPersonalization.Instance;
            }
        }
    }
}
