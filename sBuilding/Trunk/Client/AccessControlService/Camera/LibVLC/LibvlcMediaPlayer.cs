using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net.NetworkInformation;
using CommonHelper.Utils;

namespace AccessControlService.Camera.LibVLC
{
    internal class LibvlcMediaPlayer : IVideoSource
    {
        #region Private properties

        private IntPtr handle;
        private IntPtr canvasHandle;
        private bool disposed;

        private Thread th_checkConnection = null;
        private volatile bool flg_checkConnection = false;

        #endregion

        #region Public constructor

        public LibvlcMediaPlayer(LibvlcMedia media)
        {
            handle = LibvlcWrapper.libvlc_media_player_new_from_media(media.Handle);
            if (handle == IntPtr.Zero)
            {
                throw new LibvlcException();
            }
            LibvlcWrapper.libvlc_media_player_set_hwnd(handle, this.canvasHandle);
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
                throw new VideoSourceException("Không chụp được hình, hãy thử lại");
            }
            File.Delete(filePath);
            return img;
        }

        private void TakeSnapshot(string filePath, uint width, uint height)
        {
            int ret = LibvlcWrapper.libvlc_video_take_snapshot(handle, 0, filePath, width, height);
            if (ret == -1)
            {
                throw new LibvlcException();
            }
        }

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }


            // Release resource
            LibvlcWrapper.libvlc_media_player_release(handle);
        }
    }
}