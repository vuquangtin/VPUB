using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace sAccessControl.Device.Camera.DHVECSystem
{
    /// <summary>
    /// Class wrap các function của thư viện DHVECSystem.dll
    /// DH_VEC Video Compression Card System SDK Manual (Ver: 2.1 Build0729)
    /// 
    /// DSP: Digital Signal Processing
    /// </summary>
    internal class VecSystemWrapper
    {
        private const string DllName = "DHVECSystem.dll";

        /// <summary>
        /// Get DSP amount installed in the system.
        /// </summary>
        /// <returns>
        /// Get DSP amount installed in the system.
        /// DSP initialization failure occurred if the 
        /// return value is less than the installed DSP amount.
        /// </returns>
        [DllImport(DllName)]
        public static extern int GetTotalDSPs();

        /// <summary>
        /// To initialize DSP program, PCI driver program and SDK resources.
        /// </summary>
        /// <returns>
        /// Right: the card amount that have been successfully initialized.
        /// -1: failed
        /// </returns>
        [DllImport(DllName)]
        public static extern int InitDSPs();

        /// <summary>
        /// Call this function to clear the system after using PCI card.
        /// </summary>
        /// <returns>
        /// 0: succeeded
        /// -1: failed
        /// </returns>
        [DllImport(DllName)]
        public static extern int DeInitDSPs();

        /// <summary>
        /// Reset one DSP. Please note before calling this function, 
        /// please make sure DSP error can not be fixed via software 
        /// and then close corresponding resources.
        /// Call this function unless there is a must!
        /// </summary>
        /// <param name="DSPNumber">
        /// This parameter is the index of the DSP to be reset.
        /// The value ranges from 0 to N-1.
        /// N stands for the actual DSP amount in the system.
        /// </param>
        /// <returns>
        /// 0: succeeded
        /// -1: failed
        /// </returns>
        [DllImport(DllName)]
        public static extern int ResetDSPs(int DSPNumber);

        /// <summary>
        /// Get available channel amount in the system.
        /// </summary>
        /// <returns>
        /// Get channel amount in the system.
        /// DSP initialization failure occurred if the return value 
        /// is less than the installed channel amount.
        /// </returns>
        [DllImport(DllName)]
        public static extern int GetTotalChannels();

        /// <summary>
        /// Open channel to get handle of the channel object.
        /// All channel operations need to use this handle.
        /// </summary>
        /// <param name="iChannelNum">
        /// Channel global index in the system.
        /// The value ranges from 0 ~ N-1.
        /// N stands for channel amount in the system.
        /// </param>
        /// <returns>
        /// Return channel handle: succeeded
        /// -1: failed
        /// </returns>
        [DllImport(DllName)]
        public static extern IntPtr ChannelOpen(int iChannelNum);

        /// <summary>
        /// Close channel and release corresponding resources.
        /// </summary>
        /// <param name="hChannel">
        /// The value is the channel handle of calling ChannelOpen().
        /// </param>
        /// <returns>
        /// 0: succeeded
        /// -1: failed
        /// </returns>
        [DllImport(DllName)]
        public static extern int ChannelClose(IntPtr hChannel);

        /// <summary>
        /// Set preview overlay mode. System will enable or disable overlay mode
        /// when preview according to your setup here.
        /// Note:
        /// Since this function is to set a unique overlay symbol. So, before you
        /// call this function you need to close preview in all channels, otherwise
        /// the return will fail.
        /// </summary>
        /// <param name="bTrue">
        /// Preview mode:
        /// - TRUE: overlay mode
        /// - FALSE: non-overlay mode
        /// </param>
        /// <returns></returns>
        [DllImport(DllName)]
        public static extern int SetPreviewOverlayMode(bool bTrue);

        /// <summary>
        /// Enable video preview.
        /// If system failed to enable overlay preview mode, 
        /// SDK automatically switch to Off-screen mode to preview.
        /// Only support one channel area zoom one time, and also 
        /// the primary preview must be opened, the last channel 
        /// area zoom will be switched off if you switch on another 
        /// channel area zoom.
        /// </summary>
        /// <param name="hChannelHandle">
        /// The value is channel handle of calling ChannelOpen().
        /// </param>
        /// <param name="WndHandle">
        /// Window handle (refer to VideoFormat when use area zoom)
        /// </param>
        /// <param name="rect">
        /// Rectangle zone in window. If the parameter is NULL，
        /// it stands for video is displayed in client zone 
        /// (refer to VideoFormat when use area zoom)
        /// </param>
        /// <param name="bOverlay">
        /// Preview Overlay symbol. Now we use the symbol set by SetPreviewOverlayMode.
        /// </param>
        /// <param name="VideoFormat">
        /// Video format:
        /// - BYTE0: reserved(set 0)
        /// - BYTE1: preview resolution format
        /// - 1: QCIF
        /// - 2: CIF
        /// - 7: 4CIF
        /// - Else: calculate by the display region size
        /// - BYTE2: area zoom switch
        /// - 0x00: normal mode (start video preview)
        /// - 0x01: start area zoom
        /// Now WndHandle is the handle to a new window on witch zoom will
        /// display, not the window in normal mode. rect is the channel area 
        /// relative to normal mode window witch is to be zoomed, when NULL 
        /// the whole channel region is to be zoomed.
        /// </param>
        /// <param name="FrameRate">
        /// Frame rate value:
        /// - NTSC: 1, 2, 3, 4, 5, 6, 7, 10, 15, 30
        /// - PAL: 1, 2, 3, 4, 5, 6, 8, 12, 25
        /// To the HD signal, this param depends on the camera output framerate:
        /// - 720P25, 720P50, 1080I50, 1080P25
        /// - Same as PAL
        /// - 720P30, 720P60, 1080I60, 1080P30
        /// Same as NTSC.
        /// </param>
        /// <returns>
        /// 0: succeeded
        /// -1: failed
        /// </returns>
        [DllImport(DllName)]
        public static extern int StartVideoPreview(IntPtr hChannelHandle, IntPtr WndHandle, ref Rectangle rect, bool bOverlay, int VideoFormat, int FrameRate);

        /// <summary>
        /// Disable video preview.
        /// </summary>
        /// <param name="hChannelHandle">
        /// The value is channel handle of calling ChannelOpen()
        /// </param>
        /// <returns>
        /// 0: succeeded
        /// -1: failed
        /// </returns>
        [DllImport(DllName)]
        public static extern int StopVideoPreview(IntPtr hChannelHandle);

        /// <summary>
        /// Snapshot one JPEG picture.
        /// Note: Size is the ImageBuf size before calling, 
        /// and it stands for actual image byte amount after calling.
        /// </summary>
        /// <param name="hChannelHandle">
        /// The value is channel handle of calling
        /// </param>
        /// <param name="ImageBuf">
        /// JPEG data buffer.
        /// This parameter can not be NULL.
        /// </param>
        /// <param name="Size">
        /// Pointer of saving JPEG file size.
        /// This parameter can not be NULL.
        /// </param>
        /// <param name="nQuality">
        /// JPEG image quality (1~100. 1 stands for lowest level 
        /// and 100 stands for the highest level).
        /// </param>
        /// <returns>
        /// 0: succeeded
        /// -1: failed
        /// </returns>
        [DllImport(DllName)]
        public static extern int GetJpegImage(IntPtr hChannelHandle, out byte[] ImageBuf, out int Size, uint nQuality);

        /// <summary>
        /// To get video parameter.
        /// </summary>
        /// <param name="hChannelHandle">
        /// Channel handle of calling ChannelOpen().
        /// </param>
        /// <param name="VideoStandard">
        /// Save pointer of the video format.
        /// - 0x01：PAL
        /// - 0x02：NTSC
        /// - 0x03：720P
        /// - 0x04：1080I
        /// - 0x05：1080P
        /// This parameter can not be NULL.
        /// </param>
        /// <param name="Brightness">
        /// Saved brightness pointer. Returned value 0 ~ 255.
        /// This parameter can not be NULL.
        /// </param>
        /// <param name="Contrast">
        /// Saved contrast pointer. Returned value 0 ~ 255.
        /// This parameter can not be NULL.
        /// </param>
        /// <param name="Saturation">
        /// Saved saturation pointer. Returned value 0 ~ 255.
        /// This parameter can not be NULL.
        /// </param>
        /// <param name="Hue">
        /// Saved hue pointer. Returned value 0 ~ 255.
        /// This parameter can not be NULL.
        /// </param>
        /// <returns>
        /// 0: succeeded
        /// -1: failed
        /// </returns>
        [DllImport(DllName)]
        public static extern int GetVideoPara(IntPtr hChannelHandle, out VideoStandard_t VideoStandard, out int Brightness, out int Contrast, out int Saturation, out int Hue);

        /// <summary>
        /// Set video parameter.
        /// </summary>
        /// <param name="hChannelHandle">
        /// Channel handle of calling ChannelOpen().
        /// </param>
        /// <param name="Brightness">
        /// Brightness 0 ~ 255. Default value: 128.
        /// </param>
        /// <param name="Contrast">
        /// Contrast 0 ~ 255. Default value: 128.
        /// </param>
        /// <param name="Saturation">
        /// Saturation 0 ~ 255. Default value: 128.
        /// </param>
        /// <param name="Hue">
        /// Hue 0 ~ 255. Default value: 128.
        /// </param>
        /// <returns>
        /// 0: succeeded
        /// -1: failed
        /// </returns>
        [DllImport(DllName)]
        public static extern int SetVideoPara(IntPtr hChannelHandle, int Brightness, int Contrast, int Saturation, int Hue);

        /// <summary>
        /// To get SDK and DSP error report.
        /// </summary>
        /// <param name="hChannel">
        /// The value is the channel handle of calling ChannelOpen()
        /// </param>
        /// <param name="DspError">
        /// DSP error. This parameter can not be NULL.
        /// </param>
        /// <param name="SdkError">
        /// SDK error. This parameter can not be NULL.
        /// </param>
        /// <returns>
        /// 0: succeeded
        /// -1: failed
        /// </returns>
        [DllImport(DllName)]
        public static extern int GetLastErrorNum(IntPtr hChannel, out ulong[] DspError, out ulong[] SdkError);
    }
}