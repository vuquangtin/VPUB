using System;
using System.Runtime.InteropServices;

namespace ScanComponent.LibPlusTek {
    internal class LibPlusTekWrapper {
        /// <summary>
        /// Load lib để kiểm tra xem có tìm được dll không
        /// </summary>
        /// <param name="pathDLL"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string pathDLL);

        /// <summary>
        /// Giải phóng dll
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr handler);

        /// <summary>
        /// Kết nối tới Camera.dll để tìm Function CAMERA_GetFunctionTable.
        /// Rồi gán qua method GetFunctionTable
        /// </summary>
        /// <returns></returns>
        [DllImport("Camera.dll", EntryPoint = "CAMERA_GetFunctionTable", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetFunctionTable();
    }
}
