using sMeetingComponent.Interface;
using sMeetingComponent.Java;
using CommonHelper.Config;
using JavaCommunication;
namespace sMeetingComponent.Factory
{
    public class MeetingEventFactory
    {
        private static MeetingEventFactory instance = new MeetingEventFactory();

        public static MeetingEventFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new MeetingEventFactory();
                }
                return instance;
            }
        }

        private MeetingEventFactory()
        { }

        public IMeetingEvent GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaMeetingEvent.Instance;
                default:
                    return JavaMeetingEvent.Instance;
            }
        }
    }
}
