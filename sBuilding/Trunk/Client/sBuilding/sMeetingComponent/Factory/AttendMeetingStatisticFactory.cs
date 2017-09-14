using CommonHelper.Config;
using JavaCommunication;
using sMeetingComponent.Interface;
using sMeetingComponent.Java;

namespace sMeetingComponent.Factory
{
    public class AttendMeetingStatisticFactory
    {
        private static AttendMeetingStatisticFactory instance = new AttendMeetingStatisticFactory();

        public static AttendMeetingStatisticFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new AttendMeetingStatisticFactory();
                }
                return instance;
            }
        }

        private AttendMeetingStatisticFactory()
        { }

        public IAttendMeetingStatistic GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaAttendMeetingStatistic.Instance;
                default:
                    return JavaAttendMeetingStatistic.Instance;
            }
        }
    }
}
