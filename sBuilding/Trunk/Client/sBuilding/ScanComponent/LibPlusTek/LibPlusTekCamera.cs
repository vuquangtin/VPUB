using System;
using System.Runtime.InteropServices;

namespace ScanComponent.LibPlusTek {
    public class LibPlusTekCamera {
        public enum CAMERA_EVENT {
            CAMERA_EVENT_CAPTURE = 0,
            CAMERA_EVENT_STATUS
        }

        public enum CAMERA_TYPE {
            CAMERA_TYPE_PASSPORT = 0,
            CAMERA_TYPE_IDCARD
        }

        public enum CAMERA_STATUS {
            CAMERA_STATUS_START = 0,
            CAMERA_STATUS_STOP,
            CAMERA_STATUS_IDBACK_START,
            CAMERA_STATUS_IDBACK_STOP,
            CAMERA_STATUS_DEVICE_PLUG,
            CAMERA_STATUS_DEVICE_UNPLUG
        }

        public enum CAMERA_CAPTUREMODE {
            CAMERA_CAPTUREMODE_GIU = 0,
            CAMERA_CAPTUREMODE_GI,
            CAMERA_CAPTUREMODE_GU,
            CAMERA_CAPTUREMODE_G
        }

        public enum CAMERA_DPI {
            CAMERA_DPI_300 = 0,
            CAMERA_DPI_600
        }

        public enum CAMERA_FORMAT {
            CAMERA_FORMAT_JPG = 0,
            CAMERA_FORMAT_BMP
        }

        public enum CAMERA_ALIGN {
            CAMERA_ALIGN_LEFT = 0,
            CAMERA_ALIGN_RIGHT
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct CAPTURE_NAME {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ScanConstant.MAX_PATH)]
            public char[] szGeneral;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ScanConstant.MAX_PATH)]
            public char[] szIR;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ScanConstant.MAX_PATH)]
            public char[] szUV;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct CAPTURE_PARAM {
            public bool bLeft;
            public ushort wCaptureMode;
            public ushort wDpi;
            public ushort wFormat;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ScanConstant.MAX_PATH)]
            public string szSaveFolder;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class CAMERA_INFO {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
            public string Name;
            public ushort wIndex;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class CAMERA_LIST {
            public ushort wCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public CAMERA_INFO[] Caps;
        }

        public delegate bool PFNCK_EVENT(int iEvent, int iParam, IntPtr pUserData);

        public delegate bool pfnRegister();
        public delegate bool pfnUnregister();
        public delegate bool pfnGetCameraList(ref CAMERA_LIST ppList);
        public delegate bool pfnSetCamera(string lpName, PFNCK_EVENT pfn, IntPtr pUserData);
        public delegate bool pfnCloseCamera();
        public delegate bool pfnSetCaptureComplete(bool bFlag);
        public delegate bool pfnSetIDBack(bool bFlag);
        public delegate bool pfnSetParam(CAPTURE_PARAM Param);

        [StructLayout(LayoutKind.Sequential)]
        public class CAMERA_FUNCTION_TABLE {
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public pfnRegister Register;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public pfnUnregister Unregister;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public pfnGetCameraList GetCameraList;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public pfnSetCamera SetCamera;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public pfnCloseCamera CloseCamera;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public pfnSetCaptureComplete SetCaptureComplete;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public pfnSetIDBack SetIDBack;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public pfnSetParam SetParam;
        }
    }
}
