using JavaCommunication.Java;
using JavaCommunication;
using sWorldModel.Filters;
using sWorldModel.MethodData;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper.Config;
using sWorldCommunication;

namespace JavaCommunication.Factory
{
    public class CardChipFactory
    {
        private static CardChipFactory instance = new CardChipFactory();
        public static CardChipFactory Instance
        {
            get {
                if (instance == null){
                    instance = new CardChipFactory();
                }
                return instance;
            }
        }
        private CardChipFactory() { }

        public ICardChip GetChannel()
        
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                case TYPECOMM.JAVA:
                default:
                    return JavaCardChip.Instance;
            }
        }
    }
}
