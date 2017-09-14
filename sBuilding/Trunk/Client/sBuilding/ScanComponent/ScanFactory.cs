using System;
using ScanComponent.LibPlusTek;
using System.Runtime.InteropServices;
using System.IO;

namespace ScanComponent {
    public sealed class ScanFactory : AScan {
        //bool isFlip = false; // Kiểm tra nếu là ID card thì phải scan 2 mặt

        private static LibPlusTekCamera.PFNCK_EVENT EventCallBack;

        private static ScanFactory instance;
        private static readonly object lob = new object();

        /// <summary>
        /// Event scan xong
        /// </summary>
        /// <param name="strMessage"></param>
        public delegate void StopHandler(string strMessage);
        public event StopHandler EventStopHandler;

        public ScanFactory() {

        }

        public static ScanFactory GetInstance() {
            if (instance == null) {
                lock (lob) {
                    if (instance == null) {
                        instance = new ScanFactory();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Ngắt kết nối thiết bị khi có lệnh hoặc thoát chương trình
        /// </summary>
        public override void CloseScanDevice() {
            scanFunctionTable.CloseCamera();
            scanFunctionTable.Unregister();
            isCameraStarted = false;
            scanFunctionTable = null;
        }

        /// <summary>
        /// Method lấy thiết bị trong file camera.ini để xử lý
        /// </summary>
        /// <returns></returns>
        public override bool GetScanDeviceList() {
            bool isRegisted = false;

            if (LoadScanDLL()) {
                if (scanFunctionTable.Register()) {
                    isRegisted = true;
                }
            }

            return isRegisted;
        }

        /// <summary>
        /// Method load camera dll file
        /// </summary>
        /// <returns></returns>
        public override bool LoadScanDLL() {
            LibPlusTekInstance instance = LibPlusTekInstance.GetInstance();
            IntPtr handle = instance.Handle;

            if (handle != IntPtr.Zero) {
                scanFunctionTable = (LibPlusTekCamera.CAMERA_FUNCTION_TABLE) Marshal.PtrToStructure(handle,
                   typeof(LibPlusTekCamera.CAMERA_FUNCTION_TABLE));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Một lần quét xong
        /// </summary>
        /// <param name="isComplete"></param>
        public override void SetScanComplete(bool isComplete) {
            scanFunctionTable.SetCaptureComplete(isComplete);

            if (isComplete) {
                EventStopHandler(ScanConstant.ACQUIRING_SUCCESS_MESSAGE);
            }
        }

        /// <summary>
        /// Set thiết bị scan, sự kiện call back mỗi khi đưa vào scan
        /// </summary>
        /// <returns></returns>
        public override bool SetScanDevice() {
            EventCallBack = new LibPlusTekCamera.PFNCK_EVENT(ScanCallBackEvent); // Fix CallbackOnCollectedDelegate
            return scanFunctionTable.SetCamera(ScanConstant.DEVICE_NAME, EventCallBack, new IntPtr());
        }

        /// <summary>
        /// Đối với các loại giấy tờ khác Passport thì phải scan 2 mặt
        /// </summary>
        /// <param name="isFlip"></param>
        public override void SetIDBack(bool isFlip) {
            scanFunctionTable.SetIDBack(isFlip);
        }

        /// <summary>
        /// Set thông số cho máy scan
        /// </summary>
        /// <param name="Param"></param>
        public override void SetParam(LibPlusTekCamera.CAPTURE_PARAM Param) {
            scanFunctionTable.SetParam(Param);
        }

        /// <summary>
        /// Tạm ngưng scan khi quét xong một lượt
        /// </summary>
        public override void StopScanDevice() {
            scanFunctionTable.CloseCamera();
            isCameraStarted = false;
        }

        private bool ScanCallBackEvent(int iEvent, int iParam, IntPtr dataHandler) {
            switch (iEvent) {
                case (int) LibPlusTekCamera.CAMERA_EVENT.CAMERA_EVENT_CAPTURE:
                    LibPlusTekCamera.CAPTURE_NAME captureName;
                    captureName = (LibPlusTekCamera.CAPTURE_NAME) Marshal.PtrToStructure(dataHandler,
                        typeof(LibPlusTekCamera.CAPTURE_NAME));

                    switch (iParam) {
                        case (int) LibPlusTekCamera.CAMERA_TYPE.CAMERA_TYPE_PASSPORT:
                            Passport(captureName.szGeneral, captureName.szIR, captureName.szUV);
                            break;
                        case (int) LibPlusTekCamera.CAMERA_TYPE.CAMERA_TYPE_IDCARD:
                            //Passport(captureName.szGeneral, captureName.szIR, captureName.szUV);
                            IDCard(captureName.szGeneral, captureName.szIR, captureName.szUV);
                            break;
                    }
                    break;
                case (int) LibPlusTekCamera.CAMERA_EVENT.CAMERA_EVENT_STATUS:
                    switch (iParam) {
                        case (int) LibPlusTekCamera.CAMERA_STATUS.CAMERA_STATUS_START:
                            StatusStart((int) LibPlusTekCamera.CAMERA_STATUS.CAMERA_STATUS_START);
                            break;
                        case (int) LibPlusTekCamera.CAMERA_STATUS.CAMERA_STATUS_STOP:
                            StatusStop();
                            break;
                        case (int) LibPlusTekCamera.CAMERA_STATUS.CAMERA_STATUS_IDBACK_START:
                            StatusStart((int) LibPlusTekCamera.CAMERA_STATUS.CAMERA_STATUS_IDBACK_START);
                            break;
                        case (int) LibPlusTekCamera.CAMERA_STATUS.CAMERA_STATUS_IDBACK_STOP:
                            StatusStop();
                            break;
                        case (int) LibPlusTekCamera.CAMERA_STATUS.CAMERA_STATUS_DEVICE_PLUG:
                            Plug();
                            break;
                        case (int) LibPlusTekCamera.CAMERA_STATUS.CAMERA_STATUS_DEVICE_UNPLUG:
                            Unplug();
                            break;
                    }
                    break;
            }

            return true;
        }

        /// <summary>
        /// Method bắt sự kiện scan Passport
        /// </summary>
        /// <param name="lpGeneral"></param>
        /// <param name="lpIR"></param>
        /// <param name="lpUV"></param>
        private void Passport(char[] lpGeneral, char[] lpIR, char[] lpUV) {
            isPassport = true;
            SetScanComplete(true);
        }

        /// <summary>
        /// Method bắt sự kiện scan IDCard
        /// </summary>
        /// <param name="lpGeneral"></param>
        /// <param name="lpIR"></param>
        /// <param name="lpUV"></param>
        private void IDCard(char[] lpGeneral, char[] lpIR, char[] lpUV) {
            // Tạm thời scan 1 mặt ID card
            //if (!isFlip) {
            //    scanFunctionTable.SetIDBack(true);
            //}

            isPassport = false;
            SetScanComplete(true);
            //isFlip = !isFlip;
        }

        public bool StatusStart(int wType) {
            if (wType == (int) LibPlusTekCamera.CAMERA_STATUS.CAMERA_STATUS_START) {
                EventStopHandler(ScanConstant.WAITING_FOR_ACQUIRING_MESSAGE);
            } else {
                // EventStopHandler(ScanConstant.SCAN_BACK_SIDE_MESSAGE); // Tạm thời scan 1 mặt ID card
            }

            return true;
        }

        public bool StatusStop() {
            return true;
        }

        public bool Plug() {
            EventStopHandler(ScanConstant.CONNECTED_MESSAGE);
            return true;
        }

        public bool Unplug() {
            EventStopHandler(ScanConstant.DEVICE_UNPLUG_MESSAGE);
            return true;
        }

        /// <summary>
        /// Set up device và param trong một method
        /// </summary>
        public override void SetupAll() {
            // Create folder temp trong folder của chương trình để lưu hình cmnd/paskhách vãng lai
            string saveFolderPath = ScanConstant.NONRES_IMAGE_TEMP_PATH;
            if (!Directory.Exists(saveFolderPath)) {
                Directory.CreateDirectory(saveFolderPath);
            }

            LibPlusTekCamera.CAPTURE_PARAM Param;

            Param.wCaptureMode = ScanConstant.G_CAPTURE_MODE;
            Param.wDpi = ScanConstant.THREE_HUNDRED_DPI;
            Param.wFormat = ScanConstant.JPG_FORMAT;
            Param.bLeft = ScanConstant.ALIGN_LEFT;
            Param.szSaveFolder = saveFolderPath;

            SetParam(Param);
            if (SetScanDevice()) {
                isCameraStarted = true;
                return;
            } else {
                isCameraStarted = false;
            }

            isPassport = false;
        }

        /// <summary>
        /// Get chuỗi dữ liệu được tách ra trong hình
        /// </summary>
        /// <returns></returns>
        public override string GetDataBySubString(string mainString, string removeString) {
            if (mainString.Length > removeString.Length) {
                return mainString.Substring(removeString.Length, mainString.Length - removeString.Length);
            }

            return String.Empty;
        }
    }
}
