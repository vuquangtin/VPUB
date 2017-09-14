using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net.NetworkInformation;
using sAccessControl.View;
using sAccessControl.Enums;
using sAccessControl.Contants;
using sAccessControl.Utils;

namespace sAccessControl.Device.Camera.LibVLC
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

        public LibvlcMediaPlayer(LibvlcMedia media, IntPtr canvas)
        {
            handle = LibvlcWrapper.libvlc_media_player_new_from_media(media.Handle);
            if (handle == IntPtr.Zero)
            {
                throw new LibvlcException();
            }

            this.canvasHandle = canvas;
            LibvlcWrapper.libvlc_media_player_set_hwnd(handle, this.canvasHandle);
        }

        #endregion

        #region IVideoSource properties

        public CameraConnectionType ConnectionType
        {
            get { return CameraConnectionType.NetworkCameraViaRtsp; }
        }

        public string Source
        {
            get
            {
                IntPtr media = LibvlcWrapper.libvlc_media_player_get_media(handle);
                if (media == null)
                {
                    return null;
                }

                IntPtr mrl = LibvlcWrapper.libvlc_media_get_mrl(media);
                if (mrl == IntPtr.Zero)
                {
                    return null;
                }

                return Marshal.PtrToStringAnsi(mrl);
            }
            set
            {
                using (LibvlcMedia media = new LibvlcMedia(LibvlcInstance.GetInstance(), value))
                {
                    LibvlcWrapper.libvlc_media_player_set_media(handle, media.Handle);
                }
            }
        }

        public IntPtr Canvas
        {
            get
            {
                return canvasHandle;
            }
            set
            {
                canvasHandle = value;
                LibvlcWrapper.libvlc_media_player_set_hwnd(handle, canvasHandle);
            }
        }

        public bool IsPlaying
        {
            get
            {
                try
                {
                    return LibvlcWrapper.libvlc_media_player_is_playing(handle) == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("[{0}] Exception: {1}", DateTime.Now, ex.Message));
                    throw;
                }
            }
        }

        public bool IsDisposed
        {
            get { return disposed; }
        }

        #endregion

        #region IVideoSource events

        public event VideoSourceEventHandler Played;
        public event VideoSourceEventHandler Stopped;

        #endregion

        #region IVideoSource methods

        public void Play()
        {
            int ret = LibvlcWrapper.libvlc_media_player_play(handle);
            if (ret == -1)
            {
                throw new LibvlcException();
            }

            if (th_checkConnection == null || th_checkConnection.ThreadState == ThreadState.Aborted
                || th_checkConnection.ThreadState == ThreadState.Stopped)
            {
                th_checkConnection = new Thread(CheckConnectionWorker);
                flg_checkConnection = true;
                th_checkConnection.Start();
            }
        }

        private void CheckConnectionWorker()
        {
            const int timeOut = 10000; // LibVLC RTSP time-out
            int count = 1;
            bool timeOutPassed = false, connected = false;

            while (flg_checkConnection)
            {
                Thread.Sleep(VideoSourceContants.CheckConnectionDelayTime);

                if (IsPlaying)
                {
                    if (!connected)
                    {
                        connected = true;

                        if (Played != null)
                        {
                            Played(new VideoSourceEventArgs(canvasHandle));
                        }
                    }

                    Console.WriteLine(string.Format("Still executing at {0}", DateTime.Now));
                    continue;
                }

                if (timeOutPassed)
                {
                    LibvlcWrapper.libvlc_media_player_stop(handle);

                    if (Stopped != null)
                    {
                        Stopped(new VideoSourceEventArgs(canvasHandle));
                    }

                    break;
                }
                else
                {
                    if (count * VideoSourceContants.CheckConnectionDelayTime >= timeOut)
                    {
                        timeOutPassed = true;
                    }
                    else
                    {
                        ++count;
                    }
                }
            }
        }

        ///// <summary>
        ///// [22/12/2013] dung.nguyen: Cân nhắc dùng NetworkChange.NetworkAvailabilityChanged
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Camera_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        //{
        //    if (!e.IsAvailable)
        //    {
        //        LibvlcWrapper.libvlc_media_player_stop(handle);

        //        if (Stopped != null)
        //        {
        //            Stopped(new VideoSourceEventArgs(canvasHandle));
        //        }
        //    }
        //}

        public void Stop()
        {
            StopCheckConnectionThread();

            if (LibvlcWrapper.libvlc_media_player_is_playing(handle) == 1)
            {
                LibvlcWrapper.libvlc_media_player_stop(handle);
            }
        }

        private void StopCheckConnectionThread()
        {
            if (th_checkConnection != null)
            {
                flg_checkConnection = false;

                int delay = VideoSourceContants.CheckConnectionDelayTime / 2 + 10;
                int timeOut = 10, count = 0;
                bool stopped = false;

                do
                {
                    if (count > timeOut)
                    {
                        th_checkConnection.Abort();
                        break;
                    }

                    if (th_checkConnection.ThreadState == ThreadState.Aborted)
                    {
                        stopped = true;
                    }

                    if (th_checkConnection.ThreadState == ThreadState.Stopped)
                    {
                        stopped = true;
                    }

                    Thread.Sleep(delay);
                    ++count;
                }
                while (!stopped);

                th_checkConnection = null;
            }
        }

        public Image TakeSnapshot()
        {
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
                throw new VideoSourceException("Không chụp được hình xe, hãy thử lại");
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

        #endregion

        #region IDisposable methods

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            // Stop
            this.Stop();

            // Release resource
            LibvlcWrapper.libvlc_media_player_release(handle);

            disposed = true;
        }

        #endregion
    }
}