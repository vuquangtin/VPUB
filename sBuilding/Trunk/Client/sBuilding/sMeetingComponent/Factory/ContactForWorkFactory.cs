using CommonHelper.Config;
using JavaCommunication;
using sMeetingComponent.Interface;
using sMeetingComponent.Java;

namespace sMeetingComponent.Factory
{
    public class ContactForWorkFactory
    {
        private static ContactForWorkFactory instance = new ContactForWorkFactory();

        public static ContactForWorkFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new ContactForWorkFactory();
                }
                return instance;
            }
        }

        private ContactForWorkFactory()
        { }

        public IContactForWork GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaContactForWork.Instance;
                default:
                    return JavaContactForWork.Instance;
            }
        }
    }
}
