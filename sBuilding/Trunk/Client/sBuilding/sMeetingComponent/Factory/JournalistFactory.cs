using CommonHelper.Config;
using JavaCommunication;
using sMeetingComponent.Interface;
using sMeetingComponent.Java;

namespace sMeetingComponent.Factory
{
    public class JournalistFactory
    {
        private static JournalistFactory instance = new JournalistFactory();

        public static JournalistFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new JournalistFactory();
                }
                return instance;
            }
        }

        private JournalistFactory()
        { }

        public IJournalist GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaJournalist.Instance;
                default:
                    return JavaJournalist.Instance;
            }
        }
    }
}
