using System;
using System.Runtime.InteropServices;

namespace AccessControlService.Camera.LibVLC
{
    internal sealed class LibvlcException : VideoSourceException
    {
        public LibvlcException()
            : base(GetLibvlcErrorMessage())
        {
            
        }

        public LibvlcException(string message) : base(message)
        {
        }

        private static string GetLibvlcErrorMessage()
        {
            IntPtr errorPointer = LibvlcWrapper.libvlc_errmsg();
            return (errorPointer == IntPtr.Zero) ? "N/A" : Marshal.PtrToStringAnsi(errorPointer);
        }
    }
}