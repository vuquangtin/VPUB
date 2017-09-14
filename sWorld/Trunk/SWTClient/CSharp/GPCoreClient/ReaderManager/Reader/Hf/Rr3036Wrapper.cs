using System.Runtime.InteropServices;

namespace ParkingProcessComponent.Device.Reader.Hf
{
    internal class Rr3036Wrapper
    {
        private const string DLLNAME = "BasicB.DLL";

        #region Reader-defined commands

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetReaderInformation(ref byte ComAddr, byte[] VersionInfo, ref byte ReaderType, byte[] TrType, ref byte InventoryScanTime, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int OpenComPort(int Port, ref byte ComAddr, ref int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int CloseComPort();

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int AutoOpenComPort(ref int Port, ref byte ComAddr, ref int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int CloseSpecComPort(int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int CloseRf(ref byte ComAddr, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int OpenRf(ref byte ComAddr, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteComAdr(ref byte ComAddr, ref byte NewComAddr, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteInventoryScanTime(ref byte ComAddr, ref byte InventoryScanTime, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ChangeTo15693(ref byte ComAddr, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ChangeTo14443A(ref byte ComAddr, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ChangeTo14443B(ref byte ComAddr, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetLED(ref byte ComAddr, byte OpenTime, byte CloseTime, byte RepeatCount, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetBeep(ref byte ComAddr, byte OpenTime, byte CloseTime, byte RepeatCount, int FrmHandle);

        #endregion

        #region ISO15693 protocol commands

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int Inventory(ref byte ComAddr, ref byte State, ref byte AFI, byte[] DSFIDAndUID, ref byte CardNum, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int StayQuiet(ref byte ComAddr, byte[] UID, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ReadSingleBlock(ref byte ComAddr, ref byte State, byte[] UID, byte BlockNum, ref byte BlockSecStatus, byte[] Data, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteSingleBlock(ref byte ComAddr, ref byte State, byte[] UID, byte BlockNum, byte[] Data, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int LockBlock(ref byte ComAddr, ref byte State, byte[] UID, byte BlockNum, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ReadMultipleBlock(ref byte ComAddr, ref byte State, byte[] UID, byte BlockNum, byte BlockCount, byte[] BlockSecStatus, byte[] Data, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int Select(ref byte ComAddr, byte[] UID, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ResetToReady(ref byte ComAddr, ref byte State, byte[] UID, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteAFI(ref byte ComAddr, ref byte State, byte[] UID, byte AFI, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int LockAFI(ref byte ComAddr, ref byte State, byte[] UID, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteDSFID(ref byte ComAddr, ref byte State, byte[] UID, byte DSFID, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int LockDSFID(ref byte ComAddr, ref byte State, byte[] UID, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetSystemInformation(ref byte ComAddr, ref byte State, byte[] UIDI, ref byte InformationFlag, byte[] UIDO, ref byte DSFID, ref byte AFI, byte[] MemorySize, ref byte ICReference, ref byte ErrorCode, int FrmHandle);

        #endregion

        #region ISO14443A protocol commands

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443ARequest(ref byte ComAddr, byte Mode, byte[] Tagtype, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AAnticoll(ref byte ComAddr, byte Reserved, byte[] UID, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AAnticoll2(ref byte ComAddr, byte EnColl, byte Reserved, byte[] UID, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AULAnticoll(ref byte ComAddr, byte Reserved, byte[] UID, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443ASelect(ref byte ComAddr, byte[] UID, ref byte Size, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AAuthentication(ref byte ComAddr, byte Mode, byte SecNum, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AAuthentication2(ref byte ComAddr, byte Mode, byte AccessSector, byte KeySector, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AAuthKey(ref byte ComAddr, byte Mode, byte AuthSector, byte[] Key, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AHalt(ref byte ComAddr, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443ARead(ref byte ComAddr, byte BlockNum, byte[] ReadData, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AWrite(ref byte ComAddr, byte BlockNum, byte[] WrittenData, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AULWrite(ref byte ComAddr, byte ULPage, byte[] Data, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AInitValue(ref byte ComAddr, byte BlockNum, byte[] InitValueData, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AReadValue(ref byte ComAddr, byte BlockNum, byte[] Value, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AIncrement(ref byte ComAddr, byte BlockNum, byte[] IncrementData, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443ADecrement(ref byte ComAddr, byte BlockNum, byte[] DecrementData, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443ARestore(ref byte ComAddr, byte BlockNum, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443ATransfer(ref byte ComAddr, byte BlockNum, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443ALoadKey(ref byte ComAddr, byte Mode, byte SecNum, byte[] Key, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443ACheckWrite(ref byte ComAddr, byte[] UID, byte Mode, byte BlockNum, byte[] Data, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AReadE2(ref byte ComAddr, byte StartAddr, byte DataLength, byte[] ReadE2Data, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AWriteE2(ref byte ComAddr, byte E2Addr, byte DataLength, byte[] Data, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443AValue(ref byte ComAddr, byte Mode, byte SourceAddr, byte[] ValueData, byte TargetAddr, ref byte ErrorCode, int FrmHandle);

        #endregion

        #region ISO14443B protocol commands

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443BRequest(ref byte ComAddr, byte Mode, byte AFI, byte[] PUPI, byte[] ApplicationData, byte[] ProtocolInfo, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443BAnticoll(ref byte ComAddr, byte Mode, byte AFI, byte[] PUPI, byte[] ApplicationData, byte[] ProtocolInfo, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443BSelect(ref byte ComAddr, byte[] PUPI, byte CID, byte param1, byte param2, byte param3, byte param4, ref byte CIDO, ref byte MBLI, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443BHalt(ref byte ComAddr, byte[] PUPI, ref byte ErrorCode, int FrmHandle);

        [DllImport(DLLNAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO14443BTransparentCmd(ref byte ComAddr, byte Time_M, byte Time_N, byte CMD_Length, byte RSP_Length, byte[] CMD_Data, byte[] RSP_Data, ref byte ErrorCode, int FrmHandle);

        #endregion

        #region Status/Error codes

        public const byte OK = 0x00;
        //public const byte lengthError = 0x01;
        //public const byte operationNotSupport = 0x02;
        public const byte dataRangError = 0x03;
        public const byte cmdNotOperation = 0x04;
        public const byte RfClosed = 0x05;
        public const byte EEPROM = 0x06;
        public const byte timeOut = 0x0a;
        public const byte moreUID = 0x0b;
        public const byte ISOError = 0x0c;
        public const byte noElectronicTag = 0x0e;
        //public const byte operationError = 0x0f;
        public const byte cmdNotSupport = 0x01;
        public const byte cmdNotIdentify = 0x02;
        public const byte unknownError = 0x0f;
        public const byte blockError = 0x10;
        public const byte blockLockedAndCntLock = 0x11;
        public const byte blockLockedAndCntWrite = 0x12;
        public const byte blockCntOperate = 0x13;
        public const byte blockCntLock = 0x14;
        public const byte communicationErr = 0x30;
        public const byte retCRCErr = 0x31;
        public const byte retDataErr = 0x32;
        public const byte communicationBusy = 0x33;
        public const byte executeCmdBusy = 0x34;
        public const byte comPortOpened = 0x35;
        public const byte comPortClose = 0x36;
        public const byte invalidHandle = 0x37;
        public const byte invalidPort = 0x38;

        public static string GetErrorMessage(byte errorCode)
        {
            switch (errorCode)
            {
                case OK:
                    return string.Empty;
                case dataRangError:
                    return "";
                case cmdNotOperation:
                    return "";
                case RfClosed:
                    return "Bộ phận phát sóng của đầu đọc đã bị đóng";
                case EEPROM:
                    return "";
                case timeOut:
                    return "Hết thời gian thực thi lệnh (time-out)";
                case moreUID:
                    return "";
                case ISOError:
                    return "";
                case noElectronicTag:
                    return "Không có thẻ hiện diện trong vùng đọc";
                case cmdNotSupport:
                    return "Lệnh không được đầu đọc hỗ trợ";
                case cmdNotIdentify:
                    return "";
                case blockError:
                    return "";
                case blockLockedAndCntLock:
                    return "";
                case blockLockedAndCntWrite:
                    return "";
                case blockCntOperate:
                    return "";
                case blockCntLock:
                    return "";
                case communicationErr:
                    return "";
                case retCRCErr:
                    return "";
                case retDataErr:
                    return "";
                case communicationBusy:
                    return "";
                case executeCmdBusy:
                    return "";
                case comPortOpened:
                    return "Cổng COM đã được mở từ trước";
                case comPortClose:
                    return "Cổng COM đã bị đóng";
                case invalidHandle:
                    return "invalidHandle";
                case invalidPort:
                    return "Thông số cổng COM không hợp lệ";
                case unknownError:
                default:
                    return "Lỗi không xác định được nguyên nhân";
            }
        }

        #endregion
    }
}