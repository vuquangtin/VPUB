using System;
using System.Runtime.InteropServices;

namespace sAccessControl.Device.Reader.Pcsc
{
    public static class WinSCardWrapper
    {
        private const string DllName = "winscard.dll";

        /// <summary>
        /// Native SCardGetStatusChanged from winscard.dll
        /// </summary>
        /// <param name="hContext"></param>
        /// <param name="dwTimeout"></param>
        /// <param name="rgReaderStates"></param>
        /// <param name="cReaders"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        internal static extern int SCardGetStatusChange(UInt32 hContext,
            UInt32 dwTimeout,
            [In, Out] SCardReaderState[] rgReaderStates,
            UInt32 cReaders);

        /// <summary>
        /// Native SCardListReaders function from winscard.dll
        /// </summary>
        /// <param name="hContext"></param>
        /// <param name="mszGroups"></param>
        /// <param name="mszReaders"></param>
        /// <param name="pcchReaders"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        internal static extern int SCardListReaders(UInt32 hContext,
            [MarshalAs(UnmanagedType.LPTStr)] string mszGroups,
            IntPtr mszReaders,
            out UInt32 pcchReaders);

        /// <summary>
        /// Native SCardEstablishContext function from winscard.dll
        /// </summary>
        /// <param name="dwScope"></param>
        /// <param name="pvReserved1"></param>
        /// <param name="pvReserved2"></param>
        /// <param name="phContext"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        internal static extern int SCardEstablishContext(UInt32 dwScope,
            IntPtr pvReserved1,
            IntPtr pvReserved2,
            IntPtr phContext);

        /// <summary>
        /// Native SCardReleaseContext function from winscard.dll
        /// </summary>
        /// <param name="hContext"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        internal static extern int SCardReleaseContext(UInt32 hContext);

        /// <summary>
        /// Native SCardConnect function from winscard.dll
        /// </summary>
        /// <param name="hContext"></param>
        /// <param name="szReader"></param>
        /// <param name="dwShareMode"></param>
        /// <param name="dwPreferredProtocols"></param>
        /// <param name="phCard"></param>
        /// <param name="pdwActiveProtocol"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int SCardConnect(UInt32 hContext,
            [MarshalAs(UnmanagedType.LPTStr)] string szReader,
            UInt32 dwShareMode,
            UInt32 dwPreferredProtocols,
            IntPtr phCard,
            IntPtr pdwActiveProtocol);

        /// <summary>
        /// Native SCardDisconnect function from winscard.dll
        /// </summary>
        /// <param name="hCard"></param>
        /// <param name="dwDisposition"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        internal static extern int SCardDisconnect(UInt32 hCard,
            UInt32 dwDisposition);

        /// <summary>
        /// Native SCardTransmit function from winscard.dll
        /// </summary>
        /// <param name="hCard"></param>
        /// <param name="pioSendPci"></param>
        /// <param name="pbSendBuffer"></param>
        /// <param name="cbSendLength"></param>
        /// <param name="pioRecvPci"></param>
        /// <param name="pbRecvBuffer"></param>
        /// <param name="pcbRecvLength"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        internal static extern int SCardTransmit(UInt32 hCard,
            [In] ref SCardIORequest pioSendPci,
            byte[] pbSendBuffer,
            UInt32 cbSendLength,
            IntPtr pioRecvPci,
            [Out] byte[] pbRecvBuffer,
            out UInt32 pcbRecvLength
            );

        /// <summary>
        /// Native SCardBeginTransaction function of winscard.dll
        /// </summary>
        /// <param name="hContext"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        internal static extern int SCardBeginTransaction(UInt32 hContext);

        /// <summary>
        /// Native SCardEndTransaction function of winscard.dll
        /// </summary>
        /// <param name="hContext"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        internal static extern int SCardEndTransaction(UInt32 hContext, UInt32 dwDisposition);

        [DllImport(DllName, SetLastError = true)]
        internal static extern int SCardGetAttrib(UInt32 hCard,
            UInt32 dwAttribId,
            [Out] byte[] pbAttr,
            out UInt32 pcbAttrLen);
    }
}
