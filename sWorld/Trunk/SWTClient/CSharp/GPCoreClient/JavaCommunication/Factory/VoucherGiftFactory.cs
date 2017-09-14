using CommonHelper.Config;
using JavaCommunication.Java;
using sWorldCommunication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Factory
{
    public class VoucherGiftFactory
    {
        private static VoucherGiftFactory instance = new VoucherGiftFactory();
        public static VoucherGiftFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VoucherGiftFactory();
                }
                return instance;
            }
        }
        private VoucherGiftFactory()
        {

        }

        public IVoucherGift GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    //return TestApplication.Instance;
                    return null;
                case TYPECOMM.JAVA:
                    return JavaVoucherGift.Instance;
                default:
                    return JavaVoucherGift.Instance;
            }
        }
    }
}
