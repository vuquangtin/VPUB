using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sAccessControl.Device.Camera
{
    internal delegate void VideoSourceEventHandler(VideoSourceEventArgs e);

    internal class VideoSourceEventArgs : EventArgs
    {
        public IntPtr CanvasHandle { get; private set; }

        public VideoSourceEventArgs(IntPtr canvasHandle)
        {
            this.CanvasHandle = canvasHandle;
        }
    }
}
