using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Reader.Pcsc
{
    public class DesfireErrorCode
    {

        public const ushort SUCCESS_CODE = 37120;   // 0x91 00
        public const byte OK = 0x00;
        public const byte OUT_OF_EEPROM_ERROR = 0x0E;
        public const byte ILLIGAL_COMMAND_CODE = 0x0C;
        public const byte INTEGRITY_ERROR = 0x0E;
        public const byte NO_SUCH_KEY = 0x40;
        public const byte LENGHT_ERROR = 0x7E;
        public const byte PERMISSION_DENIED = 0x9D;
        public const byte PARAMETER_ERROR = 0x9E;
        public const byte APPLICATION_NOT_FOUND = 0xA0;
        public const byte APPL_INTERGITY_ERROR = 0xA1;
        public const byte APPLICATION_ERROR = 0xAE;
        public const byte ADDITIONAL_FRAME = 0xAF;
        public const byte BOUNDARY_ERROR = 0xBE;
        public const byte PICC_INTEGRITY_ERROR = 0xC1;
        public const byte COUNT_ERROR = 0xCE;
        public const byte DUPLICATE_ERROR = 0xDE;
        public const byte EEFROM_ERROR = 0xEE;
        public const byte FILE_NOT_FOUND = 0xF0;
        public const byte FILE_INTEGRITY_ERROR = 0xF1;
        public const byte DESFIRE_RESULT = 0x91;


    }

    public class CMDMF3ICD40{
        public const byte AUTHENTICATION = 0X0A;
        public const byte CHANGE_KEY_SETTINGS = 0X54;
        public const byte GET_KEY_SETTINGS = 0X45;
        public const byte CHANGE_KEY = 0XC4;
        public const byte GET_KEY_VERSTION = 0X64;

        //APPLICATION COMMAND

        public const byte CREATE_APPL = 0XCA;
        public const byte DELETE_APPL = 0XDA;
        public const byte GET_APPL_IDS = 0X6A;
        public const byte SELECT_APPL = 0X5A;
        public const byte FORMAT_PICC = 0XFA;
        public const byte GET_VERSION = 0X60;

        // FILE COMMAND
        public const byte GET_FILE_IDS = 0X6F;
        public const byte GET_FILE_SETTINGS = 0XF5;
        public const byte CHANGE_FILE_SETTINGS = 0X5F;
        public const byte CREATE_STD_DATA_FILE = 0XCD;
        public const byte CREATE_BACKUP_FILE = 0XCB;
        public const byte CREATE_VALUE_FILE = 0XCC;
        public const byte CREATE_LINEAR_RECORD_FLIE = 0XC1;
        public const byte CREATE_CYCLIC_RECORD_FLIE = 0XC0;
        public const byte DELETE_FILE = 0XDF;

        //DATA COMMAND
        public const byte READ_DATA = 0XBD;
        public const byte WRITE_DATA = 0X3D;
        public const byte GET_VALUE = 0X6C;
        public const byte CREDIT = 0XDC;
        public const byte LIMITED_CREDIT = 0X1C;
        public const byte WRITE_RECORD = 0X3B;
        public const byte READ_RECORDS = 0XBB;
        public const byte CLREAR_RECORD_FILE = 0XEB;
        public const byte COMMIT_TRANSACTION = 0XC7;
        
    }
}
