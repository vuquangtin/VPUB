using System;
using System.Runtime.InteropServices;

namespace sAccessControl.Device.Camera.LibVLC
{
    /// <summary>
    /// Class wrap các function của thư viện libvlc.dll phiên bản 2.1.0
    /// </summary>
    internal class LibvlcWrapper
    {
        /// <summary>
        /// Create and initialize a libvlc instance. This functions accept a list of 
        /// "command line" arguments similar to the main(). These arguments affect 
        /// the LibVLC instance default configuration.
        /// 
        /// Version: Arguments are meant to be passed from the command line to LibVLC, 
        /// just like VLC media player does. The list of valid arguments depends on 
        /// the LibVLC version, the operating system and platform, and set of available 
        /// LibVLC plugins. Invalid or unsupported arguments will cause the function 
        /// to fail (i.e. return NULL). Also, some arguments may alter the behaviour 
        /// or otherwise interfere with other LibVLC functions.
        /// 
        /// Warning: There is absolutely no warranty or promise of forward, backward 
        /// and cross-platform compatibility with regards to libvlc_new() arguments. 
        /// We recommend that you do not use them, other than when debugging.
        /// </summary>
        /// <param name="argc">the number of arguments (should be 0)</param>
        /// <param name="argv">list of arguments (should be NULL)</param>
        /// <returns>the libvlc instance or NULL in case of error</returns>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_new(int argc, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] String[] argv);

        /// <summary>
        /// Decrement the reference count of a libvlc instance, and destroy it if it reaches zero.
        /// </summary>
        /// <param name="instance">the instance to destroy</param>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_release(IntPtr instance);

        /// <summary>
        /// Create a media with a certain given media resource location, for instance a valid URL. 
        /// 
        /// Note: To refer to a local file with this function, the file:// URI syntax must be used 
        /// (see IETF RFC3986). We recommend using libvlc_media_new_path() instead when dealing 
        /// with local files.
        /// </summary>
        /// <param name="p_instance">the instance</param>
        /// <param name="psz_mrl">the media location</param>
        /// <returns>the newly created media or NULL on error</returns>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_new_location(IntPtr p_instance, [MarshalAs(UnmanagedType.LPStr)] string psz_mrl);

        /// <summary>
        /// Get the media resource locator (mrl) from a media descriptor object.
        /// </summary>
        /// <param name="p_md">a media descriptor object</param>
        /// <returns>string with mrl of media descriptor object</returns>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_get_mrl(IntPtr p_md);

        /// <summary>
        /// Decrement the reference count of a media descriptor object.
        /// If the reference count is 0, then this will release the media 
        /// descriptor object. It will send out an libvlc_MediaFreed event 
        /// to all listeners. If the media descriptor object has been released 
        /// it should not be used again.
        /// </summary>
        /// <param name="p_md">the media descriptor</param>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_release(IntPtr p_md);

        /// <summary>
        /// Create a Media Player object from a Media.
        /// </summary>
        /// <param name="p_md">the media. Afterwards the p_md can be safely destroyed.</param>
        /// <returns>a new media player object, or NULL on error.</returns>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_player_new_from_media(IntPtr p_md);

        /// <summary>
        /// Release a media_player after use Decrement the reference count of 
        /// a media player object. If the reference count is 0, then this will 
        /// release the media player object. If the media player object has been 
        /// released, then it should not be used again.
        /// </summary>
        /// <param name="p_mi">the Media Player to free</param>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_release(IntPtr p_mi);

        /// <summary>
        /// Set a Win32/Win64 API window handle (HWND) where the media player 
        /// should render its video output. If LibVLC was built without Win32/Win64 
        /// API output support, then this has no effects.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <param name="drawable">windows handle of the drawable</param>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_set_hwnd(IntPtr p_mi, IntPtr drawable);

        /// <summary>
        /// Get the media used by the media_player.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>
        /// the media associated with p_mi, or NULL if no media is associated
        /// </returns>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_media_player_get_media(IntPtr p_mi);

        /// <summary>
        /// Set the media that will be used by the media_player.
        /// If any, previous media will be released.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <param name="p_md">the Media. Afterwards the p_md can be safely destroyed.</param>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_set_media(IntPtr p_mi, IntPtr p_md);

        /// <summary>
        /// Play.
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>
        /// 0 if playback started (and was already started), or -1 on error.
        /// </returns>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_play(IntPtr p_mi);

        /// <summary>
        /// is_playing
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        /// <returns>1 if the media player is playing, 0 otherwise</returns>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_media_player_is_playing(IntPtr p_mi);

        /// <summary>
        /// Toggle pause (no effect if there is no media)
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_pause(IntPtr p_mi);

        /// <summary>
        /// Pause or resume (no effect if there is no media)
        /// </summary>
        /// <param name="mp">the Media Player</param>
        /// <param name="do_pause">play/resume if zero, pause if non-zero</param>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_set_pause(IntPtr mp, int do_pause);

        /// <summary>
        /// Stop (no effect if there is no media)
        /// </summary>
        /// <param name="p_mi">the Media Player</param>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_media_player_stop(IntPtr p_mi);

        /// <summary>
        /// Take a snapshot of the current video window. If i_width AND i_height is 0, 
        /// original size is used. If i_width XOR i_height is 0, original aspect-ratio is preserved.
        /// </summary>
        /// <param name="p_mi">media player instance</param>
        /// <param name="num">number of video output (typically 0 for the first/only one)</param>
        /// <param name="psz_filepath">the path where to save the screenshot to</param>
        /// <param name="i_width">the snapshot's width</param>
        /// <param name="i_height">the snapshot's height</param>
        /// <returns>0 on success, -1 if the video was not found</returns>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int libvlc_video_take_snapshot(IntPtr p_mi, int num, [MarshalAs(UnmanagedType.LPStr)] string psz_filepath, uint i_width, uint i_height);

        /// <summary>
        /// Clears the LibVLC error status for the current thread. This is optional.
        /// By default, the error status is automatically overridden when a new error 
        /// occurs, and destroyed when the thread exits.
        /// </summary>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void libvlc_clearerr();

        /// <summary>
        /// A human-readable error message for the last LibVLC error in the calling thread.
        /// The resulting string is valid until another error occurs (at least until the 
        /// next LibVLC call).
        /// 
        /// Warning: This will be NULL if there was no error.
        /// </summary>
        /// <returns></returns>
        [DllImport("libvlc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr libvlc_errmsg();
    }
}