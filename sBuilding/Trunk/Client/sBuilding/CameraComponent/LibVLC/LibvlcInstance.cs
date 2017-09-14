using System;
using System.Threading;

namespace CameraComponent.LibVLC
{
    /// <summary>
    /// Chỉ cần 1 VLC Instance cho toàn bộ chương trình.
    /// Nếu chương trình có nhiều hơn 1 camera thì mỗi camera
    /// tương ứng với 1 đối tượng VLC Media
    /// </summary>
    internal class LibvlcInstance : IDisposable
    {
        private static LibvlcInstance instance = null;
        private static readonly object lob = new object();
        private IntPtr handle;

        // Lưu ý: các thông số này có thay đổi thao phiên bản libvlc
        // Đây là các thông số phù hợp với libvlc 2.1.0
        private readonly string[] args = new string[]
        {
            "-I", 
            "dummy", 
            "--no-snapshot-preview",
            "--ignore-config", 
            "--network-caching=500", /*+ LocalConfigsManager.Instance.CameraCachingTime,*/
            "--no-osd",
            "--no-video-title-show",
        };

        private LibvlcInstance()
        {
            handle = LibvlcWrapper.libvlc_new(args.Length, args);
            if (handle == IntPtr.Zero)
            {
                throw new LibvlcException("Cannot create new instance of libvlc library!");
            }
        }

        public static LibvlcInstance GetInstance()
        {
            if (instance == null)
            {
                lock (lob)
                {
                    if (instance == null)
                    {
                        instance = new LibvlcInstance();
                    }
                }
            }
            return instance;
        }

        public IntPtr Handle
        {
            get { return handle; }
        }

        public void Dispose()
        {
            LibvlcWrapper.libvlc_release(handle);
        }
    }
}