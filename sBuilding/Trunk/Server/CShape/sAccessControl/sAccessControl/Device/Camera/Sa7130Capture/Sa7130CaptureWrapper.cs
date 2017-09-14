using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace sAccessControl.Device.Camera.Sa7130Capture
{
    /// <summary>
    /// Class wrap các function của thư viện Sa7130Capture.dll (NV700X SDK v8.9)
    /// </summary>
    internal class Sa7130CaptureWrapper
    {
        private const string DllName = "Sa7130Capture.dll";

        /// <summary>
        /// The InitDSPs function initializes all the boards those are plugged. 
        /// The application software must call this function to make the board work.
        /// </summary>
        /// <param name="hOverlayWnd">
        /// The handle of preview video window
        /// <returns>
        /// If the function succeeds, the return value > 0.
        /// If the function fails, the  return value  is <= 0.
        /// </returns>
        [DllImport(DllName)]
        public static extern int InitDSPs(IntPtr hOverlayWnd);

        /// <summary>
        /// The DeInitDSPs function closes the function of the boards and should be called when the application software exits.
        /// </summary>
        /// <returns>
        /// The return value is the count of closing DSPs
        /// </returns>
        [DllImport(DllName)]
        public static extern int DeInitDSPs();

        /// <summary>
        /// This function is the same as GetTotalChannels.
        /// </summary>
        /// <returns>
        /// The function also gets the available number of encode channel
        /// </returns>
        [DllImport(DllName)]
        public static extern int GetTotalDSPs();

        /// <summary>
        /// Get the available number of channels.
        /// </summary>
        /// <returns>
        /// The function gets the available number of encode and preview channels.
        /// </returns>
        [DllImport(DllName)]
        public static extern int GetTotalChannels();

        /// <summary>
        /// Open and get the handle, all operation relative to channel must use the channel handle.
        /// </summary>
        /// <param name="ChannelNum">
        /// Channel number zero-based index
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is valid handle.
        /// If the function fails, the return value is 0xFFFFFFFF.
        /// </returns>
        [DllImport(DllName)]
        public static extern IntPtr ChannelOpen(int ChannelNum);

        /// <summary>
        /// Close the handle.
        /// </summary>
        /// <param name="hChannelHandle"></param>
        /// <returns>
        /// If the function succeeds, the return value is 0.
        /// </returns>
        [DllImport(DllName)]
        public static extern int ChannelClose(IntPtr hChannelHandle);

        /// <summary>
        /// Start video preview for each channel.
        /// 
        /// The overlay preview mode is used. The third parameter of function StartVideoPreview() 
        /// should be the client rectangle of video preview window that is relative to the main 
        /// window of application. The application can draw lines and strings on the overlay surface 
        /// directly. With the overlay preview mode, the CPU usage will be very low.
        /// 
        /// Notice: While start video preview, the background color of preview window must be set 
        /// to RGB(255,0,255).
        /// </summary>
        /// <param name="hChannelHandle">
        /// Channel Handle
        /// </param>
        /// <param name="WndHandle">
        /// Window Handle
        /// </param>
        /// <param name="rect">
        /// Rectangle area in window
        /// </param>
        /// <param name="bOverlay">
        /// Reserved
        /// </param>
        /// <param name="VideoFormat">
        /// Reserved
        /// </param>
        /// <param name="FrameRate">
        /// Reserved
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is 0.
        /// </returns>
        [DllImport(DllName)]
        public static extern int StartVideoPreview(IntPtr hChannelHandle, IntPtr WndHandle, ref Rectangle rect, Boolean bOverlay, int VideoFormat, int FrameRate);

        /// <summary>
        /// Stop video preview
        /// </summary>
        /// <param name="hChannelHandle">
        /// Channel Handle
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is 0.
        /// If the function fails, the return value is the error code.
        /// </returns>
        [DllImport(DllName)]
        public static extern int StopVideoPreview(IntPtr hChannelHandle);

        /// <summary>
        /// While the handle of overlay preview window and the size or position is changed, 
        /// this function must be called. Overlay window is the large window which includes 
        /// multidisplay little windows. We may have only one Overlay window, multidisplay 
        /// little windows must be set in it.
        /// </summary>
        /// <param name="hOverlayWnd">
        /// Handle of the Video Overlay Preview Window (WndHandle in function StartVideoPreview)
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is 0.
        /// If the function fails, the return value is the error code.
        /// </returns>
        [DllImport(DllName)]
        public static extern int UpdateOvelayWnd(IntPtr hOverlayWnd);

        /// <summary>
        /// Save the captured picture to JPEG file.
        /// </summary>
        /// <param name="hChannelHandle">
        /// Channel Handle
        /// </param>
        /// <param name="lpFileName">
        /// JPEG File Name
        /// </param>
        /// <param name="dwQuality">
        /// JPEG picture quality, which ranges from 1 to 100, the greater the value is, 
        /// the better quality the JPEG picture returned (80 by default).
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is 0.
        /// If the function fails, the return value is the error code.
        /// </returns>
        [DllImport(DllName)]
        public static extern int SaveToJpegFile(IntPtr hChannelHandle, string lpFileName, int dwQuality);

        /// <summary>
        /// Save the captured picture to BMP file.
        /// </summary>
        /// <param name="hChannelHandle">
        /// Channel Handle
        /// </param>
        /// <param name="FileName">
        /// BMP	File Name
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is 0.
        /// If the function fails, the return value is the error code.
        /// </returns>
        [DllImport(DllName)]
        public static extern int SaveToBMPFile(IntPtr hChannelHandle, string FileName);
    }
}