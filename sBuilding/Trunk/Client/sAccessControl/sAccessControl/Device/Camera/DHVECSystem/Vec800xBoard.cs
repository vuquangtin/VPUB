namespace sAccessControl.Device.Camera.DHVECSystem
{
    internal class Vec800xBoard
    {
        private static Vec800xBoard instance = null;
        private static readonly object InstanceLob = new object();
        private static readonly object InitLob = new object();

        private int totalChannels = 0;

        public Vec800xBoard()
        {
        }

        public static Vec800xBoard GetInstance()
        {
            if (instance == null)
            {
                lock (InstanceLob)
                {
                    if (instance == null)
                    {
                        instance = new Vec800xBoard();
                    }
                }
            }
            return instance;
        }

        public void Init()
        {
            // Dùng hàm đến số lượng DSP để kiểm tra đã Init hay chưa
            if (VecSystemWrapper.GetTotalDSPs() == 0)
            {
                lock (InitLob)
                {
                    if (VecSystemWrapper.GetTotalDSPs() == 0)
                    {
                        // Nếu chưa, gọi hàm Init
                        int retCode = VecSystemWrapper.InitDSPs();
                        if (retCode == -1)
                        {
                            throw new VideoSourceException("Không có Card DVR VEC800X nào được gắn vào máy tính!");
                        }

                        //totalChannels = VecSystemWrapper.GetTotalChannels();
                    }
                }
            }
        }
    }
}