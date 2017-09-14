using System;
using System.Runtime.InteropServices;

namespace sAccessControl.Device.Reader.Pcsc
{
    /// <summary>
    /// Wraps the SCARD_IO_STRUCTURE
    ///  
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SCardIORequest
    {
        public UInt32 m_dwProtocol;
        public UInt32 m_cbPciLength;
    }
}
