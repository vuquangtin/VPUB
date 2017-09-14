using System;

namespace ScanComponent {
    public abstract class AScan {
        public abstract bool LoadScanDLL();
        
        public IntPtr scan;
        public LibPlusTek.LibPlusTekCamera.CAMERA_FUNCTION_TABLE scanFunctionTable;
        public bool isCameraStarted;
        public bool isPassport;

        public abstract bool GetScanDeviceList();
        public abstract void CloseScanDevice();
        public abstract bool SetScanDevice();
        public abstract void StopScanDevice();
        public abstract void SetScanComplete(bool isComplete);
        public abstract void SetIDBack(bool isFlip);
        public abstract void SetParam(LibPlusTek.LibPlusTekCamera.CAPTURE_PARAM Param);
        public abstract void SetupAll();
        public abstract string GetDataBySubString(string mainString, string removeString);
    }
}
