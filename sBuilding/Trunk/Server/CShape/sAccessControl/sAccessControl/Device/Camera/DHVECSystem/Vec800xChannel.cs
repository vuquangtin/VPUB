using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using sAccessControl.View;
using System.IO;
using sAccessControl.Enums;
using sAccessControl.Utils;

namespace sAccessControl.Device.Camera.DHVECSystem
{
    internal class Vec800xChannel : IVideoSource
    {
        #region Private properties

        private uint channel;
        private IntPtr channelHandle;
        private IntPtr canvasHandle;
        private Rectangle canvasBounds;

        private bool isPlaying = false;
        private bool isDisposed = false;

        #endregion

        #region Public constructor

        public Vec800xChannel(uint channel, IntPtr canvasHandle, Rectangle canvasBounds)
        {
            Vec800xBoard.GetInstance().Init();

            this.channel = channel;
            this.canvasHandle = canvasHandle;
            this.canvasBounds = canvasBounds;
        }

        #endregion

        #region IVideoSource events

        public event VideoSourceEventHandler Played;
        public event VideoSourceEventHandler Stopped;

        #endregion

        #region IVideoSource properties

        public CameraConnectionType ConnectionType
        {
            //get { return CameraConnectionType.CcdCameraViaVec800x; }
            get { throw new NotImplementedException(); }
        }

        public string Source
        {
            get
            {
                return channel.ToString();
            }
            set
            {
                channel = uint.Parse(value);
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
                Stop();
                Play();
            }
        }

        public bool IsPlaying
        {
            get { return isPlaying; }
        }

        public bool IsDisposed
        {
            get { return isDisposed; }
        }

        #endregion

        #region IVideoSource methods

        public void Play()
        {
            channelHandle = VecSystemWrapper.ChannelOpen((int)channel);
            int retCode = VecSystemWrapper.StartVideoPreview(channelHandle, canvasHandle, ref canvasBounds, false, 8, 25);

            if (retCode == -1)
            {
                //ulong[] dspErrors, sdkErrors;
                //VecSystemWrapper.GetLastErrorNum(channelHandle, out dspErrors, out sdkErrors);

                if (Stopped != null)
                {
                    Stopped(new VideoSourceEventArgs(canvasHandle));
                }
            }
            else
            {
                if (Played != null)
                {
                    Played(new VideoSourceEventArgs(canvasHandle));
                }
            }
        }

        public void Stop()
        {
            int retCode = VecSystemWrapper.StopVideoPreview(channelHandle);
        }

        public Image TakeSnapshot()
        {
            int imgSize = 0;
            byte[] imgBuffer = null;
            uint imgQuality = 100U;

            int retCode = VecSystemWrapper.GetJpegImage(channelHandle, out imgBuffer, out imgSize, imgQuality);
            if (retCode == -1)
            {
                throw new VideoSourceException("VEC800X Error: Take snapshot failed!");
            }

            return ImageUtils.ByteArrayToImage(imgBuffer);
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Stop();
            isDisposed = true;
        }

        #endregion
    }
}
