using CommonHelper.Config;
using JavaCommunication;
using sMeetingComponent.Interface;
using sMeetingComponent.Java;

namespace sMeetingComponent.Factory
{
    public class AttendMeetingFactory
    {
        private static AttendMeetingFactory instance = new AttendMeetingFactory();

        public static AttendMeetingFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new AttendMeetingFactory();
                }
                return instance;
            }
        }

        private AttendMeetingFactory()
        { }

        public IAttendMeeting GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaAttendMeeting.Instance;
                default:
                    return JavaAttendMeeting.Instance;
            }
        }
    }
}
