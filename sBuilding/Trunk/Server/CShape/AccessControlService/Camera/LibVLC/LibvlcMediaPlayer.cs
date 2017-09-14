using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net.NetworkInformation;
using CommonHelper.Utils;
using System.Timers;
using System.Configuration;

namespace AccessControlService.Camera.LibVLC
{
    internal class LibvlcMediaPlayer : IVideoSource
    {
        #region Private properties

        private static IntPtr handle;
        private IntPtr canvasHandle;
        private bool disposed;

        private Thread th_checkConnection = null;
        private volatile bool flg_checkConnection = false;

        private static System.Timers.Timer aTimer;
        private static string source = ConfigurationManager.AppSettings["camera_address"];

        #endregion

        #region Public constructor

        public LibvlcMediaPlayer(LibvlcMedia media)
        {
            handle = LibvlcWrapper.libvlc_media_player_new_from_media(media.Handle);
            LibvlcWrapper.libvlc_media_player_play(handle);
            if (handle == IntPtr.Zero)
            {
                //throw new LibvlcException();
            }
            //SetTimer();
            //LibvlcWrapper.libvlc_media_player_set_hwnd(handle, this.canvasHandle);
        }

        #endregion



        public Image TakeSnapshot()
        {
            // tạo config cho biến nay trong file app.config
            // public static readonly string SnapshotDirPath = Application.StartupPath + Path.DirectorySeparatorChar + "Snapshot" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(VideoSourceContants.SnapshotDirPath))
            {
                Directory.CreateDirectory(VideoSourceContants.SnapshotDirPath);
            }

            string filePath = VideoSourceContants.SnapshotDirPath + Guid.NewGuid().ToString() + "." + VideoSourceContants.ImageExtension;
            TakeSnapshot(filePath, VideoSourceContants.SnapshotWidth, VideoSourceContants.SnapshotHeight);

            Image img;
            try
            {
                img = ImageUtils.LoadImageFromFile(filePath);
            }
            catch (FileNotFoundException)
            {
                // Đôi khi hàm LoadImageFromFile tung lỗi FileNotFoundException
                // nhưng không rõ nguyên nhân do VLC hay do code sai.
                Console.WriteLine("Không chụp được hình");
                throw new VideoSourceException("Không chụp được hình, hãy thử lại");
            }
            File.Delete(filePath);
            return img;
        }

        private void TakeSnapshot(string filePath, uint width, uint height)
        {
            int ret = LibvlcWrapper.libvlc_video_take_snapshot(handle, 0, filePath, width, height);
        }

        public void Dispose()
        {
            LibvlcWrapper.libvlc_media_player_release(handle);
        }

        public bool CheckIsPlay()
        {
            if (LibvlcWrapper.libvlc_media_player_is_playing(handle) != 1)
            {
                return false;
            }
            return true;
        }
    }
}