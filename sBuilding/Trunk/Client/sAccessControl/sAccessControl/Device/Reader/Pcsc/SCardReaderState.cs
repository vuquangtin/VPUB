using System;
using System.Runtime.InteropServices;

namespace sAccessControl.Device.Reader.Pcsc
{
    /// <summary>
    /// Wraps theSCARD_READERSTATE structure of PC/SC
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SCardReaderState
    {
        public string m_szReader;
        public IntPtr m_pvUserData;
        public UInt32 m_dwCurrentState;
        public UInt32 m_dwEventState;
        public UInt32 m_cbAtr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_rgbAtr;
    }
}
