using System;
using System.Threading;
using CameraComponent.Model;
using CameraComponent.View;
using CameraComponent.LibVLC;
using System.Collections.Generic;

namespace CameraComponent
{
    public sealed class VideoSourceFactory
    {
        private static VideoSourceFactory instance;
        private static readonly object lob = new object();
        private static bool isFirstRegistration = true;

        private VideoSourceFactory()
        {
        }

        public static VideoSourceFactory GetInstance()
        {
            if (instance == null)
            {
                lock (lob)
                {
                    if (instance == null)
                    {
                        instance = new VideoSourceFactory();
                    }
                }
            }
            return instance;
        }

        private List<IVideoSource> HandlerVideo = new List<IVideoSource>();
        //private IVideoSource videoSource = null;

        public void Close()
        {
            foreach(IVideoSource handle in HandlerVideo)
            {

                if (null != handle)
                    handle.Stop();
            }
        }
        public IVideoSource Register(CameraConnectionType connectionType, string source, UsrCameraCanvas canvas)
        {
            switch (connectionType)
            {
                case CameraConnectionType.NetworkCameraViaRtsp:
#if(DEBUG)
                    Console.WriteLine();
                    Console.WriteLine("Regsiter video source: " + source);
                    int t = Environment.TickCount;
#endif
                    if (string.IsNullOrWhiteSpace(source) ||
                        !source.StartsWith("rtsp://", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return null;
                    }

                    LibvlcInstance vlcInstance = null;

                    if (isFirstRegistration)
                    {
                        Thread th = new Thread(() =>
                        {
                            vlcInstance = LibvlcInstance.GetInstance();
                        });
                        th.Start();
                        th.Join();
                    }
                    else
                    {
                        vlcInstance = LibvlcInstance.GetInstance();
                    }
#if(DEBUG)
                    Console.WriteLine(string.Format("Create VLC instance in {0} ms", Environment.TickCount - t));
                    t = Environment.TickCount;
#endif
                    LibvlcMedia vlcMedia = new LibvlcMedia(vlcInstance, source);
#if(DEBUG)
                    Console.WriteLine(string.Format("Create VLC media in {0} ms", Environment.TickCount - t));
                    t = Environment.TickCount;
#endif
                    try
                    {
                         IVideoSource videoSource = new LibvlcMediaPlayer(vlcMedia, canvas.Handle);
                        HandlerVideo.Add(videoSource);
                        return videoSource;
                    }
                    finally
                    {
#if(DEBUG)
                        Console.WriteLine(string.Format("Create VLC media player in {0} ms", Environment.TickCount - t));
                        t = Environment.TickCount;
#endif
                        vlcMedia.Dispose();
#if(DEBUG)
                        Console.WriteLine(string.Format("Dispose VLC media in {0} ms", Environment.TickCount - t));
#endif
                    }

                //case CameraConnectionType.CcdCameraViaVec800x:
                //    return new Vec800xChannel(uint.Parse(source.Trim()), canvas.Handle, canvas.Bounds);

                default:
                    throw new VideoSourceException("Kiểu kết nối camera không được hỗ trợ");
            }
        }
    }
}