using System;

namespace CameraComponent
{
    public delegate void VideoSourceEventHandler(VideoSourceEventArgs e);

    public class VideoSourceEventArgs : EventArgs
    {
        public IntPtr CanvasHandle { get; private set; }

        public VideoSourceEventArgs(IntPtr canvasHandle)
        {
            this.CanvasHandle = canvasHandle;
        }
    }
}