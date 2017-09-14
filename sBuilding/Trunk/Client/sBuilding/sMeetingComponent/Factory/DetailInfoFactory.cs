using CommonHelper.Config;
using JavaCommunication;
using sMeetingComponent.Interface;
using sMeetingComponent.Java;
namespace sMeetingComponent.Factory
{
   public class DetailInfoFactory
    {
        private static DetailInfoFactory instance = new DetailInfoFactory();

        public static DetailInfoFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new DetailInfoFactory();
                }
                return instance;
            }
        }

        private DetailInfoFactory()
        { }

        public IDetailInfo GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaDetailInfo.Instance;
                default:
                    return JavaDetailInfo.Instance;
            }
        }
    }
}
