using System.IO;
using System.Reflection;

namespace ScanComponent.LibPlusTek {
    public class ScanConstant {
        public const int MAX_PATH = 260;
        public const string DEVICE_NAME = "X100";

        public const string CAMERA_NAME_LIBRARY = "Camera.dll";
        public const string CAMERA_NAME_LIBRARY_ENTRY = "CAMERA_GetFunctionTable";
        public const string NONRES_IMAGE_TEMP = "NonResident_Image_Temp";
        public const string TEXT_READER_APPLICATION = "MRTDsReader\\MRTDsReader.exe";
        public const string JPG_EXTENSIONS = ".jpg";
        public const string TXT_EXTENSIONS = ".txt";
        public const string MRTDSREASER_STATUS_LOG_FILE = "MRTDSREASER_status.log";

        public static readonly string APPLICATION_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static readonly string DLL_PATH = APPLICATION_FOLDER + "\\" + CAMERA_NAME_LIBRARY;
        public static readonly string NONRES_IMAGE_TEMP_PATH = APPLICATION_FOLDER + "\\" + NONRES_IMAGE_TEMP;
        public static readonly string TEXT_READER_APPLICATION_PATH = APPLICATION_FOLDER + "\\" + TEXT_READER_APPLICATION;

        public const int G_CAPTURE_MODE = (int) LibPlusTekCamera.CAMERA_CAPTUREMODE.CAMERA_CAPTUREMODE_G;
        public const int THREE_HUNDRED_DPI = (int) LibPlusTekCamera.CAMERA_DPI.CAMERA_DPI_300;
        public const int JPG_FORMAT = (int) LibPlusTekCamera.CAMERA_FORMAT.CAMERA_FORMAT_JPG;
        public const bool ALIGN_LEFT = true;

        public const string CONNECTED_MESSAGE = "Thiết bị đã được kết nối.\nĐang chờ scan hình CMND/Passport";
        public const string DISCONNECTED_MESSAGE = "Không nhận được tín hiệu từ máy Scan";
        public const string DISCONNECTED_BY_USER_MESSAGE = "Đã ngưng nhận tín hiệu\ntheo yêu cầu của người dùng";
        public const string WAITING_FOR_ACQUIRING_MESSAGE = "Vui lòng đợi trong khi đang lấy hình ảnh CMND/Passport...";
        public const string ACQUIRING_SUCCESS_MESSAGE = "Lấy hình ảnh CMND/Passport hoàn tất.";
        public const string DEVICE_UNPLUG_MESSAGE = "Thiết bị chưa được cắm";
        //public const string SCAN_BACK_SIDE_MESSAGE = "Vui lòng lấy CMND ra và scan tiếp mặt sau.";

        // Tách dữ liệu text
        public const string FAMILY_NAME = "Familyname/";
        public const int FAMILY_NAME_LINE = 4;
        public const string GIVEN_NAME = "Givenname/";
        public const int GIVEN_NAME_LINE = 5;
        public const string SEX = "Sex/";
        public const int SEX_LINE = 9;
        public const string DOCUMENT_NUMBER = "DocumentNo./";
        public const string PERSONAL_NUMBER = "PersonalNo./";
        public const int DOCUMENT_NUMBER_LINE = 3;
        public const int PERSONAL_NUMBER_LINE = 8;
        public const string REC_DATA_ERROR = "CODE=0";
    }
}
