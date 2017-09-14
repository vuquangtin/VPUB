using CommonHelper.Config;
using JavaCommunication;
using sNonResidentComponent.Interface;
using sNonResidentComponent.Java;

namespace sNonResidentComponent.Factory
{
    public class RoomFactory
    {
        private static RoomFactory instance = new RoomFactory();

        public static RoomFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new RoomFactory();
                }
                return instance;
            }
        }

        private RoomFactory()
        { }

        public IRoom GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaRoom.Instance;
                default:
                    return JavaRoom.Instance;
            }
        }
    }
}
