using System;

namespace AccessControlService.Camera.LibVLC
{
    internal class LibvlcMedia : IDisposable
    {
        private IntPtr handle;

        public LibvlcMedia(LibvlcInstance instance, string uri)
        {
            handle = LibvlcWrapper.libvlc_media_new_location(instance.Handle, uri);
            if (handle == IntPtr.Zero)
            {
                throw new LibvlcException();
            }
        }

        public IntPtr Handle
        {
            get { return this.handle; }
        }

        public void Dispose()
        {
            LibvlcWrapper.libvlc_media_release(handle);
        }
    }
}