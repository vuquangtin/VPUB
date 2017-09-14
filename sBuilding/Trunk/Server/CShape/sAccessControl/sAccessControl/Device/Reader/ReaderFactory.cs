using sAccessControl.Device.Reader.Pcsc;
using sAccessControl.Enums;

namespace sAccessControl.Device.Reader
{
    internal sealed class ReaderFactory
    {
        private static ReaderFactory instance = null;
        private static readonly object lob = new object();

        private ReaderFactory() { }

        public static ReaderFactory GetInstance()
        {
            if (instance == null)
            {
                lock (lob)
                {
                    if (instance == null)
                    {
                        instance = new ReaderFactory();
                    }
                }
            }
            return instance;
        }

        public IReader Register(ReaderType type, byte address, bool beepOnTag)
        {
            switch (type)
            {
                case ReaderType.PCSC:
                    return new PcscReader(address, beepOnTag);
                //case ReaderType.HF:
                //    return new HfReader(address, beepOnTag);
                default:
                    return null;
                    //throw new ParkingException(ErrorCodes.InvalidReaderType, string.Empty);
            }
        }
    }
}