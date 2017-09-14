using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper.Utils;
using ReaderManager.Model;
using ReaderManager.Pcsc;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

namespace ReaderManager.Reader.Pcsc
{
    public class DesfireAPDUWrapper
    {
        private static DesfireAPDUWrapper instance = null;
        public static DesfireAPDUWrapper Instance
        {
            get
            {
                if (instance == null)
                    instance = new DesfireAPDUWrapper();

                return instance;
            }
        }
        private APDUCommand CMD_AUTHENTICATION = new APDUCommand(0x90, 0x0A, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_CHANGE_KEY_SETTINGS = new APDUCommand(0x90, 0x54, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_GET_KEY_SETTINGS = new APDUCommand(0x90, 0x45, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_CHANGE_KEY = new APDUCommand(0x90, 0xC4, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_GET_KEY_VERSTION = new APDUCommand(0x90, 0x64, 0x00, 0x00, null, 0x00);

        //APPLICATION COMMAND

        private APDUCommand CMD_CREATE_APPL = new APDUCommand(0x90, 0xCA, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_DELETE_APPL = new APDUCommand(0x90, 0xDA, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_GET_APPL_IDS = new APDUCommand(0x90, 0x6A, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_SELECT_APPL = new APDUCommand(0x90, 0x5A, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_FORMAT_PICC = new APDUCommand(0x90, 0xFA, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_GET_VERSION = new APDUCommand(0x90, 0x60, 0x00, 0x00, null, 0x00);

        // FILE COMMAND
        private APDUCommand CMD_GET_FILE_IDS = new APDUCommand(0x90, 0x6F, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_GET_FILE_SETTINGS = new APDUCommand(0x90, 0xF5, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_CHANGE_FILE_SETTINGS = new APDUCommand(0x90, 0x5F, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_CREATE_STD_DATA_FILE = new APDUCommand(0x90, 0xCD, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_CREATE_BACKUP_FILE = new APDUCommand(0x90, 0xCB, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_CREATE_VALUE_FILE = new APDUCommand(0x90, 0xCC, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_CREATE_LINEAR_RECORD_FLIE = new APDUCommand(0x90, 0xC1, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_CREATE_CYCLIC_RECORD_FLIE = new APDUCommand(0x90, 0xC0, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_DELETE_FILE = new APDUCommand(0x90, 0xDF, 0x00, 0x00, null, 0x00);

        //DATA COMMAND
        private APDUCommand CMD_READ_DATA = new APDUCommand(0x90, 0xBD, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_WRITE_DATA = new APDUCommand(0x90, 0x3D, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_GET_VALUE = new APDUCommand(0x90, 0x6C, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_CREDIT = new APDUCommand(0x90, 0xDC, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_LIMITED_CREDIT = new APDUCommand(0x90, 0x1C, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_WRITE_RECORD = new APDUCommand(0x90, 0x3B, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_READ_RECORDS = new APDUCommand(0x90, 0xBB, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_CLREAR_RECORD_FILE = new APDUCommand(0x90, 0xEB, 0x00, 0x00, null, 0x00);
        private APDUCommand CMD_COMMIT_TRANSACTION = new APDUCommand(0x90, 0xC7, 0x00, 0x00, null, 0x00);

        private APDUCommand CMD_ADDITIONAL_FRAME = new APDUCommand(0x90, 0xAF, 0x00, 0x00, null, 0x00);
        private byte[] DEFAULT_KEY_8 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        private byte[] DEFAULT_KEY_16 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        private byte[] MY_KEY = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x04, 0x06, 0x07 };


        private byte[] SWT_AID = { 0x00, 0x01, 0x02 };
        private byte SWT_LICENSE_FID =  0x01 ;
        private byte[] PARTNER_AID = {0x04, 0x05, 0x06 };
        private byte PARTNER_LICENSE_FID =  0x01 ;
        private byte[] MEMBER_AID = { 0x08, 0x09, 0x0A };
        private byte MEMBER_FID = 0x01;
        
        private byte[] APP_PERSO_AID = { 0x0B, 0x0C, 0x0D };
        private byte APP_PERSON_FID = 0x01;

        //private byte[] APP_AID = {0x0B, 0x0C, 0x0E};
        //private byte APP_FID = 0x01;
        private int APP_FILE_SIZE = 1024;
        private int SP_APP_FILE_SIZE = 2;
        private int LICENSE_FILE_SIZE = 128;
        private byte[] DELETE_VALUE = Encoding.ASCII.GetBytes("deleted");

        #region sParking
        // beep
        private readonly APDUCommand CommandBeep = new APDUCommand(0xFF, 0x00, 0x40, 0xCF, new byte[] { 0x02, 0x00, 0x01, 0x01 }, 0x04);
        // application id of sParking
        private byte[] SPK_SWT_AID = { 0x06, 0x06, 0x06 };
        // file id of sParking
        private byte SPK_SWT_FID = 0x02;
        // 
        private byte[] SPK_SWT_DATA_FOR_FREE = { 0x01 };
        
        #endregion

        private byte[] DEFAULT_LENGHT = {0x00, 0x40, 0x00};
        
        private byte[] Encrypt2(byte[] data, byte[] key)
        {
            // The plain string to encrypt
            string plaintextString = "This is an encryption test";

            // Binary representation of plain text string
            byte[] plaintextBytes = (new UnicodeEncoding()).GetBytes(plaintextString);
            DES.IsWeakKey(DEFAULT_KEY_8);
            // Encrypt using DES
            SymmetricAlgorithm sa = DES.Create();
            sa.IV = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt, sa.CreateEncryptor(), CryptoStreamMode.Write);
            csEncrypt.Write(plaintextBytes, 0, plaintextBytes.Length);
            csEncrypt.Close();
            byte[] encryptedTextBytes = msEncrypt.ToArray();
            msEncrypt.Close();

            return encryptedTextBytes;
        }

        private byte[] Decrypt2(byte[] data, byte[] key)
        {

            byte[] encryptedTextBytes = Encrypt2(data, key);
            byte[] temp = new byte[encryptedTextBytes.Length];
            Array.Copy(encryptedTextBytes, temp, encryptedTextBytes.Length);
            DES.IsWeakKey(DEFAULT_KEY_8);

            SymmetricAlgorithm sa = DES.Create();
            sa.IV = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            MemoryStream msDecrypt = new MemoryStream(temp);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, sa.CreateDecryptor(), CryptoStreamMode.Read);
            byte[] decryptedTextBytes = new Byte[encryptedTextBytes.Length];
            csDecrypt.Read(decryptedTextBytes, 0, encryptedTextBytes.Length);
            csDecrypt.Close();
            msDecrypt.Close();

            string decryptedTextString = (new UnicodeEncoding()).GetString(decryptedTextBytes);

            System.Console.WriteLine("Decrypt test: " + StringUtils.ByteArrayToHexString(decryptedTextBytes));

            return decryptedTextBytes;
        }

        private byte[] Decrypt(byte[] data, byte[] key)
        {
          //  byte[] res = Encrypt2(data, key);

            Decrypt2(data, key);


            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            
            DES.IsWeakKey(DEFAULT_KEY_8);
            
            //set secret key for DES algorithm
            // set initialization vector
            cryptoProvider.IV = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            cryptoProvider.Mode = CipherMode.CBC;
            cryptoProvider.Padding = PaddingMode.Zeros;

            ICryptoTransform transform = cryptoProvider.CreateDecryptor();

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptostreamDecr = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            if (cryptostreamDecr == null)
                return null;

            byte[] descrypt = new byte[8];
            cryptostreamDecr.Write(data, 0, data.Length);
            cryptostreamDecr.FlushFinalBlock();
            return memoryStream.ToArray();
        }

        private byte[] Encrypt(byte[] data, byte[] key)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            DES.IsWeakKey(DEFAULT_KEY_8);

            //set secret key for DES algorithm
            // set initialization vector
            cryptoProvider.IV = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            cryptoProvider.Mode = CipherMode.CBC;
            cryptoProvider.Padding = PaddingMode.Zeros;

            ICryptoTransform transform = cryptoProvider.CreateEncryptor();

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptostreamDecr = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            if (cryptostreamDecr == null)
                return null;

            cryptostreamDecr.Write(data, 0, data.Length);
            cryptostreamDecr.FlushFinalBlock();
            return memoryStream.ToArray();
        }

        
        /// <summary>
        /// Change key settings 
        /// PICC master key setting
        /// The order of bit in key setting by: Bit 7   6   5   4   3   2   1   0
        /// On PICC level: (AID = 0x00)
        ///     Bit 7 -> Bit 4 = 0;
        ///     Bit 3 = 0 - cannot change anymore | 1 - can change with PICC master key
        ///     Bit 2 = 0 - create/ delete application is permitted only with master key authentication | 
        ///             1 - create appl. without master key authentication / delete appl. requires 
        ///     Bit 1 = 0 - successdul master key is required for executing the GetApplicationIDS and GetKeySettings
        ///             1 - GetApplicationIDs and GetKeySettings is not required master key
        ///     Bit 0 = 0 - cannot change masterkey | 1 - can change masterjey
        /// 
        /// Application level (AID != 0x00)
        ///     Bit 7 -> Bit 4: 0x0: Application master key authentication is necessary to change any key
        ///                     0x1 ... 0xD: Authentication with specified key is necessary to change any key
        ///                     0xE: Authentication with the key to change 
        ///     Bit 3: = 0: cannot change anymore
        ///              1: can change if authenticated with the application master key
        ///     Bit 2: = 0: create/delete file is permitted only with application master key
        ///              1: create/delete file is permitted without authentication
        ///     Bit 1: = 0: application master key is required for executing the GetFileIDs, GetFileSettings and GetKeySettings commands
        ///              1: not reruired
        ///     Bit 0: = 0: application master key is not changeable anymore
        ///              1: application master key is changeable.
        /// 
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="keysettings"></param>
        /// <returns></returns>
        private bool ChangeKeySettings(CardManager cm, byte[] aid, byte keysettings)
        {
            bool result = false;

            if (keysettings != 0x00)
                CMD_AUTHENTICATION.Data = new byte[1] { keysettings };

            APDUResponse respond = cm.TransmitDesFire(CMD_CHANGE_KEY_SETTINGS);

            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                result = true;
            }
            else
            {
                result = false;
                Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
            }

            return result;
        }

        /// <summary>
        /// get key setting
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        private byte[] GetKeySettings(CardManager cm)
        {
            byte[] keySetting = null;
            APDUResponse respond = cm.TransmitDesFire(CMD_GET_KEY_SETTINGS);
            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                keySetting = new byte[respond.Data.Length];
                Array.Copy(respond.Data, keySetting, respond.Data.Length);
            }
            return keySetting;
        }

        /// <summary>
        /// change key
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        private bool ChangeKey(CardManager cm, byte[] keys)
        {
            bool result = false;
            if(keys.Length >0){
                CMD_CHANGE_KEY.Data = new byte[keys.Length];
                Array.Copy(keys, CMD_CHANGE_KEY.Data, keys.Length);
            }

            APDUResponse respond = cm.TransmitDesFire(CMD_CHANGE_KEY);

            result = (respond.Status == DesfireErrorCode.SUCCESS_CODE);

            return result;
        }
        /// <summary>
        /// get keys version
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="keyno"></param>
        /// <returns></returns>
        private byte[] GetKeyVersion(CardManager cm, byte keyno)
        {
            byte[] keyVersion = null;
            CMD_GET_KEY_VERSTION.Data = new byte[] { keyno };
            APDUResponse respond = cm.TransmitDesFire(CMD_GET_KEY_VERSTION);
            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                keyVersion = new byte[respond.Data.Length];
                Array.Copy(respond.Data, keyVersion, respond.Data.Length);
            }

            return keyVersion;

        }

        /// <summary>
        /// create application
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="aid"></param>
        /// <param name="keysetting"></param>
        /// <param name="numofkey"></param>
        /// <returns></returns>
        public bool CreateApplication(CardManager cm, byte[] aid, byte keysetting, byte numofkey)
        {
            bool result = false;
            CMD_CREATE_APPL.Data = new byte[5];
            Array.Copy(aid, 0, CMD_CREATE_APPL.Data, 0, 3);
            CMD_CREATE_APPL.Data[3] = keysetting;
            CMD_CREATE_APPL.Data[4] = numofkey;
            APDUResponse respond = cm.TransmitDesFire(CMD_CREATE_APPL);
            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                result = true;
            }
            else
            {
                result = false;
                Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
            }

            return result;
            
        }

        /// <summary>
        /// delete application
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        private bool DeleteApplication(CardManager cm, byte[] aid)
        {
            bool result = false;
            CMD_CREATE_APPL.Data = new byte[3];
            Array.Copy(aid, 0, CMD_CREATE_APPL.Data, 0, 3);
            APDUResponse respond = cm.TransmitDesFire(CMD_DELETE_APPL);
            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                result = true;
            }
            else
            {
                result = false;
                Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
            }

            return result;
        }

        /// <summary>
        /// get application ids
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public byte[] GetApplicationIDs(CardManager cm)
        {
            byte[] temp = new byte[64];
            byte[] result = null;

            APDUResponse respond = cm.TransmitDesFire(CMD_GET_APPL_IDS);
            int offset = 0;
            try
            {
                while (respond.SW1 == DesfireErrorCode.DESFIRE_RESULT && respond.SW2 == DesfireErrorCode.ADDITIONAL_FRAME)
                {
                    Array.Copy(respond.Data, 0, temp, offset, respond.Data.Length);
                    offset += respond.Data.Length;
                    respond = cm.TransmitDesFire(CMD_ADDITIONAL_FRAME);
                }

                Array.Copy(respond.Data, 0, temp, offset, respond.Data.Length);
                offset += respond.Data.Length;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            result = new byte[offset];
            Array.Copy(temp, 0, result, 0, offset);
            return result;
        }

        /// <summary>
        /// select application
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        private bool SelectApplication(CardManager cm, byte[] aid)
        {
            bool result = false;
            CMD_SELECT_APPL.Data = new byte[aid.Length];
            Array.Copy(aid, CMD_SELECT_APPL.Data, aid.Length);
            APDUResponse respond = cm.TransmitDesFire(CMD_SELECT_APPL);
            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                result = true;
            }
            else
            {
                result = false;
                Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
            }

            return result;
        }
        /// <summary>
        /// format PICC
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        private bool  FormatPICC(CardManager cm)
        {
            bool result = false;;
            APDUResponse respond = cm.TransmitDesFire(CMD_FORMAT_PICC);
            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                result = true;
            }
            else
            {
                result = false;
                Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
            }

            return result;
        }
        /// <summary>
        /// get card version
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        private byte[] GetVersion(CardManager cm)
        {
            byte[] temp = new byte[254];
            byte[] result = null;

            APDUResponse respond = cm.TransmitDesFire(CMD_GET_VERSION);
            int offset = 0;
            try
            {
                while (respond.SW1 == DesfireErrorCode.DESFIRE_RESULT && respond.SW2 == DesfireErrorCode.ADDITIONAL_FRAME)
                {
                    Array.Copy(respond.Data, 0, temp, offset, respond.Data.Length);
                    offset += respond.Data.Length;
                    respond = cm.TransmitDesFire(CMD_ADDITIONAL_FRAME);
                }

                Array.Copy(respond.Data, 0, temp, offset, respond.Data.Length);
                offset += respond.Data.Length;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
            result = new byte[offset];
            Array.Copy(temp, 0, result, 0, offset);
            return result;
        }

        /// <summary>
        /// Get all activiti files on select application
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        private byte[] GetFileIDs(CardManager cm)
        {
            byte[] result = null;
            try
            {
                APDUResponse respond = cm.TransmitDesFire(CMD_GET_FILE_IDS);
                if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
                {
                    // vu.pham: do not exist file => respond.Status = SUCCESS => respond.Data = null => error
                    if (respond.Data != null)
                    {
                        result = new byte[respond.Data.Length];
                        Array.Copy(respond.Data, 0, result, 0, respond.Data.Length);
                    }
                }
                else
                {
                    Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
                }

            }
            catch (Exception ex)
            {
            }
            return result;
        }

        /// <summary>
        /// get file settings
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="fileno"></param>
        /// <returns></returns>
        private byte[] GetFileSettings(CardManager cm, byte fileno)
        {
            byte[] result = null;
            CMD_GET_FILE_SETTINGS.Data = new byte[] { fileno };
            APDUResponse respond = cm.TransmitDesFire(CMD_GET_FILE_SETTINGS);
            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                result = new byte[respond.Data.Length];
                Array.Copy(respond.Data, 0, result, 0, respond.Data.Length);
            }
            else
            {
                Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
            }

            return result;
        }

        /// <summary>
        /// change setting of card
        /// </summary>
        /// <param name="cm"></param>
        private void ChangeFileSettings(CardManager cm)
        {
            //TODO: implement
            throw new NotImplementedException();
        }

        /// <summary>
        /// create standard file
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="fileno"></param>
        /// <param name="comset"></param>
        /// <param name="accessright"></param>
        /// <param name="filesize"></param>
        /// <returns></returns>
        public bool CreadStandardDataFile(CardManager cm, byte fileno, byte comset, byte[] accessright, byte[] filesize)
        {
            bool result = false;
            CMD_CREATE_STD_DATA_FILE.Data = new byte[7];

            CMD_CREATE_STD_DATA_FILE.Data[0] = fileno;

            CMD_CREATE_STD_DATA_FILE.Data[1] = comset;

            CMD_CREATE_STD_DATA_FILE.Data[2] = accessright[0];
            CMD_CREATE_STD_DATA_FILE.Data[3] = accessright[1];

            CMD_CREATE_STD_DATA_FILE.Data[4] = filesize[0];
            CMD_CREATE_STD_DATA_FILE.Data[5] = filesize[1];
            CMD_CREATE_STD_DATA_FILE.Data[6] = filesize[2];

            APDUResponse respond = cm.TransmitDesFire(CMD_CREATE_STD_DATA_FILE);
            if (respond.SW1 == DesfireErrorCode.DESFIRE_RESULT && (respond.SW2 == DesfireErrorCode.DUPLICATE_ERROR || respond.SW2 == DesfireErrorCode.OK))
            {
                result = true;
            }
            else
            {
                Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
            }
            return result;

        }

        /// <summary>
        /// create backup file
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="fileno"></param>
        /// <param name="comset"></param>
        /// <param name="accessright"></param>
        /// <param name="filesize"></param>
        /// <returns></returns>
        public bool CreateBackupFile(CardManager cm, byte fileno, byte comset, byte[] accessright, byte[] filesize)
        {
            bool result = false;
            CMD_CREATE_BACKUP_FILE.Data = new byte[7];

            CMD_CREATE_BACKUP_FILE.Data[0] = fileno;

            CMD_CREATE_BACKUP_FILE.Data[1] = comset;

            CMD_CREATE_BACKUP_FILE.Data[2] = accessright[0];
            CMD_CREATE_BACKUP_FILE.Data[3] = accessright[1];

            CMD_CREATE_BACKUP_FILE.Data[4] = filesize[0];
            CMD_CREATE_BACKUP_FILE.Data[5] = filesize[1];
            CMD_CREATE_BACKUP_FILE.Data[6] = filesize[2];

            APDUResponse respond = cm.TransmitDesFire(CMD_CREATE_BACKUP_FILE);
            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                result = respond.Status == DesfireErrorCode.SUCCESS_CODE;
            }
            else
            {
                Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
            }
            return result;
        }

        /// <summary>
        /// create value file
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="aid"></param>
        /// <param name="fileno"></param>
        /// <param name="comset"></param>
        /// <param name="accessright"></param>
        /// <param name="filesize"></param>
        /// <param name="lowerlimit"></param>
        /// <param name="upperlimit"></param>
        /// <param name="value"></param>
        /// <param name="creditenable"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public bool CreateValueFile(CardManager cm, byte[] aid, byte fileno, byte comset, byte[] accessright, byte[] filesize, byte[] lowerlimit, byte[] upperlimit, byte[] value, byte creditenable, int length)
        {
            bool result = false;
            CMD_CREATE_VALUE_FILE.Data = new byte[length];
            CMD_CREATE_VALUE_FILE.Data[0] = fileno;
            CMD_CREATE_VALUE_FILE.Data[1] = comset;
            
            CMD_CREATE_VALUE_FILE.Data[2] = accessright[0];
            CMD_CREATE_VALUE_FILE.Data[3] = accessright[1];
            int offset = 4;
            Array.Copy(lowerlimit, 0, CMD_CREATE_VALUE_FILE.Data, offset, lowerlimit.Length);
            offset = offset + lowerlimit.Length;
            Array.Copy(upperlimit, 0, CMD_CREATE_VALUE_FILE.Data, offset, upperlimit.Length);
            offset = offset + upperlimit.Length;
            Array.Copy(value, 0, CMD_CREATE_VALUE_FILE.Data, offset, value.Length);
            offset = offset + value.Length;
            CMD_CREATE_VALUE_FILE.Data[offset] = creditenable;

            APDUResponse respond = cm.TransmitDesFire(CMD_CREATE_VALUE_FILE);
            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                result = respond.Status == DesfireErrorCode.SUCCESS_CODE;
            }
            else
            {
                Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
            }

            return result;

        }

        /// <summary>
        /// create linear record file
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="fileno"></param>
        /// <param name="comset"></param>
        /// <param name="accessright"></param>
        /// <param name="recordsize"></param>
        /// <param name="maxnumofrecord"></param>
        /// <param name="lenght"></param>
        /// <returns></returns>
        private bool CreateLinearRecordFile(CardManager cm, byte fileno, byte comset, byte[] accessright, byte[] recordsize, byte[] maxnumofrecord, int lenght)
        {
            bool result = false;
            CMD_CREATE_LINEAR_RECORD_FLIE.Data = new byte[lenght];
            CMD_CREATE_LINEAR_RECORD_FLIE.Data[0] = fileno;
            CMD_CREATE_LINEAR_RECORD_FLIE.Data[1] = comset;

            CMD_CREATE_LINEAR_RECORD_FLIE.Data[2] = accessright[0];
            CMD_CREATE_LINEAR_RECORD_FLIE.Data[3] = accessright[1];
            
            int offset = 4;
            Array.Copy(recordsize, 0, CMD_CREATE_LINEAR_RECORD_FLIE.Data, offset, recordsize.Length);
            offset = offset + recordsize.Length;

            Array.Copy(maxnumofrecord, 0, CMD_CREATE_LINEAR_RECORD_FLIE.Data, offset, maxnumofrecord.Length);

            APDUResponse respond = cm.TransmitDesFire(CMD_CREATE_LINEAR_RECORD_FLIE);
            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                result = respond.Status == DesfireErrorCode.SUCCESS_CODE;
            }
            else
            {
                Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
            }
            return result;

        }

        /// <summary>
        /// create cyclic record file
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="fileno"></param>
        /// <param name="comset"></param>
        /// <param name="accessright"></param>
        /// <param name="recordsize"></param>
        /// <param name="maxnumofrecord"></param>
        /// <param name="lenght"></param>
        /// <returns></returns>
        private bool CreateCyclicRecordFile(CardManager cm, byte fileno, byte comset, byte[] accessright, byte[] recordsize, byte[] maxnumofrecord, int lenght)
        {
            bool result = false;
            CMD_CREATE_CYCLIC_RECORD_FLIE.Data = new byte[lenght];
            CMD_CREATE_CYCLIC_RECORD_FLIE.Data[0] = fileno;
            CMD_CREATE_CYCLIC_RECORD_FLIE.Data[1] = comset;

            CMD_CREATE_CYCLIC_RECORD_FLIE.Data[2] = accessright[0];
            CMD_CREATE_CYCLIC_RECORD_FLIE.Data[3] = accessright[1];
            
            int offset = 4;
            Array.Copy(recordsize, 0, CMD_CREATE_CYCLIC_RECORD_FLIE.Data, offset, recordsize.Length);
            offset = offset + recordsize.Length;

            Array.Copy(maxnumofrecord, 0, CMD_CREATE_CYCLIC_RECORD_FLIE.Data, offset, maxnumofrecord.Length);

            APDUResponse respond = cm.TransmitDesFire(CMD_CREATE_CYCLIC_RECORD_FLIE);
            if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
            {
                result = respond.Status == DesfireErrorCode.SUCCESS_CODE;
            }
            else
            {
                Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
            }
            return result;

        }

        /// <summary>
        /// read data on file
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="fino"></param>
        /// <param name="offset"></param>
        /// <param name="datasize"></param>
        /// <returns></returns>
        public byte[] ReadData(CardManager cm, byte fid, byte[] offset, int size)
        {
            
            byte[] data = new byte[size];

            CMD_READ_DATA.Data = new byte[7];
            CMD_READ_DATA.Data[0] = fid;
            CMD_READ_DATA.Data[1] = 0x00;
            CMD_READ_DATA.Data[2] = 0x00;
            CMD_READ_DATA.Data[3] = 0x00;

            byte[] temp = BitConverter.GetBytes(size);
            byte[] length = new byte[] { temp[0], temp[1], temp[2] };

            CMD_READ_DATA.Data[4] = temp[0];
            CMD_READ_DATA.Data[5] = temp[1];
            CMD_READ_DATA.Data[6] = temp[2];
            APDUResponse respond = cm.TransmitDesFire(CMD_READ_DATA);
            APDUCommand CMD_ADD_FRAME = new APDUCommand(0x90, 0xAF, 0x00, 0x00, null, 0x00);
            int index = 0;
            bool result = false;
            while (respond.SW1 == DesfireErrorCode.DESFIRE_RESULT && respond.SW2 == DesfireErrorCode.ADDITIONAL_FRAME)
            {
                result = StopRead(respond.Data);
                if (result)
                    break;

                Array.Copy(respond.Data, 0, data, index, respond.Data.Length);
                index += respond.Data.Length;
               
                respond = cm.TransmitDesFire(CMD_ADD_FRAME);
            }

            if (!result)
            {
                if (respond.SW1 == DesfireErrorCode.DESFIRE_RESULT && respond.SW2 == DesfireErrorCode.OK)
                    Array.Copy(respond.Data, 0, data, index, respond.Data.Length);
            }
            return data;
        }

        private bool StopRead(byte[] comparevalue)
        {
            byte[] partent = new byte[58];
            return partent.SequenceEqual(comparevalue); 
        }
        /// <summary>
        /// write data to file with offset
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="fino"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool WriteData(CardManager cm, byte fino, byte[] offset, byte[] length, byte[] data)
        {
            int BLOCK_SIZE = 32;
            int nextOffSet = data.Length - BLOCK_SIZE;
            int datalength = data.Length;
            if (nextOffSet > 0)
            {
                datalength = BLOCK_SIZE;
                CMD_WRITE_DATA.Data = new byte[BLOCK_SIZE];
            }

            CMD_WRITE_DATA.Data = new byte[1 + offset.Length + length.Length + datalength];

            CMD_WRITE_DATA.Data[0] = fino;
            int index = 1;
            Array.Copy(offset, 0, CMD_WRITE_DATA.Data, index, offset.Length);
            index += offset.Length;
            Array.Copy(length, 0, CMD_WRITE_DATA.Data, index, length.Length);
            index += length.Length;
            Array.Copy(data, 0, CMD_WRITE_DATA.Data, index, datalength);

            //send to card
            APDUResponse respond = cm.TransmitDesFire(CMD_WRITE_DATA);

            index = datalength;
            while (respond.SW1 == DesfireErrorCode.DESFIRE_RESULT && respond.SW2 == DesfireErrorCode.ADDITIONAL_FRAME && nextOffSet > 0)
            {
                if (nextOffSet > BLOCK_SIZE)
                {
                    CMD_ADDITIONAL_FRAME.Data = new byte[BLOCK_SIZE];
                    Array.Copy(data, index, CMD_ADDITIONAL_FRAME.Data, 0, BLOCK_SIZE);
                    nextOffSet -= BLOCK_SIZE;
                    index += BLOCK_SIZE;
                }
                else
                {
                    CMD_ADDITIONAL_FRAME.Data = new byte[nextOffSet];
                    Array.Copy(data, index, CMD_ADDITIONAL_FRAME.Data, 0, nextOffSet);
                    index += nextOffSet;
                }
                respond = cm.TransmitDesFire(CMD_ADDITIONAL_FRAME);
            }

            return (respond.SW1 == DesfireErrorCode.DESFIRE_RESULT && respond.SW2 == DesfireErrorCode.OK);
                

        }
        /// <summary>
        /// write data to file
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="fid"></param>
        /// <param name="data"></param>
        /// <param name="lenght"></param>
        /// <returns></returns>
        private bool WriteData(CardManager cm, byte fid, byte[] data, int lenght)
        {
            byte[] offset = new byte[] { 0x00, 0x00, 0x00 };
            byte[] temp = BitConverter.GetBytes(lenght);
            byte[] le = new byte[]{ temp[0], temp[1], temp[2]};

            return WriteData(cm, fid, offset, le, data);
        }

        #region export function for PcscReader class

        /// <summary>
        /// authentication card
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="keyno"></param>
        /// <returns></returns>
        public bool Authentication(CardManager cm, byte keyno)
        {
            bool result = false;

            //if (keyno != 0x00)
            CMD_AUTHENTICATION.Data = new byte[] { keyno };

            APDUResponse respond = cm.TransmitDesFire(CMD_AUTHENTICATION);
            try
            {
                byte[] data = new byte[8] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88 };

                System.Console.WriteLine("test data: " + StringUtils.ByteArrayToHexString(data));

                byte[] EnTest = Encrypt(data, new byte[] { 0x00 });
                System.Console.WriteLine("Encrypt test data: " + StringUtils.ByteArrayToHexString(EnTest));

                byte[] DeTest = Decrypt(EnTest, new byte[] { 0x00 });

                System.Console.WriteLine("Decrypt test data: " + StringUtils.ByteArrayToHexString(DeTest));

                while (respond.SW1 == DesfireErrorCode.DESFIRE_RESULT && respond.SW2 == DesfireErrorCode.ADDITIONAL_FRAME)
                {

                    System.Console.WriteLine("Encrypt data 1: " + StringUtils.ByteArrayToHexString(respond.Data));
                    byte[] RndB = Decrypt(respond.Data, new byte[] { 0x00 });

                    System.Console.WriteLine("Decrypt data 1: " + StringUtils.ByteArrayToHexString(RndB));

                    byte[] tryEncrypt = Encrypt(RndB, new byte[] { 0x00 });

                    System.Console.WriteLine("Encrypt data 2: " + StringUtils.ByteArrayToHexString(tryEncrypt));

                    byte[] RndBTemp = Decrypt(tryEncrypt, new byte[] { 0x00 });

                    System.Console.WriteLine("Decrypt data 2: " + StringUtils.ByteArrayToHexString(RndBTemp));

                    byte[] shifted_RndB = new byte[8];
                    for (int i = 1; i < 8; i++)
                    {
                        shifted_RndB[i - 1] = RndB[i];
                    }
                    shifted_RndB[7] = RndB[0];
                    CMD_ADDITIONAL_FRAME.Data = new byte[16];

                    Array.Copy(MY_KEY, 0, CMD_ADDITIONAL_FRAME.Data, 0, 8);
                    Array.Copy(RndB, 1, CMD_ADDITIONAL_FRAME.Data, 8, 7);
                    CMD_ADDITIONAL_FRAME.Data[15] = RndB[0];

                    respond = cm.TransmitDesFire(CMD_ADDITIONAL_FRAME);
                }

                if (respond.Status == DesfireErrorCode.SUCCESS_CODE)
                {
                    result = true;
                }
                else
                {
                    result = false;
                    Console.Out.WriteLine(StringUtils.ByteArrayToHexString(new byte[] { respond.SW2 }));
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Clear data file
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        /*
        public bool ClearApplicationData(CardManager cm, Dictionary<byte, byte[]> aid)
        {
            return ClearData(cm, APP_AID, APP_FID, APP_FILE_SIZE);
        }
         */


        /// <summary>
        /// Clear data file
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        public bool ClearPersoData(CardManager cm, Dictionary<byte, byte[]> aid)
        {
            return ClearData(cm, APP_PERSO_AID, APP_PERSON_FID, APP_FILE_SIZE);
        }

        private bool ClearData(CardManager cm, byte[] aid, byte fid, int lenght)
        {
            // select application 
            bool result = SelectApplication(cm, aid);
            if (!result)
                return true;

            byte[] fids = GetFileIDs(cm);
            if (null == fids || fids.Length < 1 || fids[0] != SWT_LICENSE_FID)
                return true;

            byte[] data = new byte[lenght];
            if(lenght > DELETE_VALUE.Length)
                Array.Copy(DELETE_VALUE, 0, data, 0, DELETE_VALUE.Length);

            result = WriteData(cm, fid, data, lenght);

            return result;
        }
        /// <summary>
        /// delete all file on card
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        public bool ClearTheAllApplication(CardManager cm, Dictionary<byte, byte[]> aid)
        {
            // select swt application
            bool result = ClearData(cm, SWT_AID, SWT_LICENSE_FID, LICENSE_FILE_SIZE);

            //select partner application
            result = ClearData(cm, PARTNER_AID, PARTNER_LICENSE_FID, LICENSE_FILE_SIZE);

            // select application data
            result = ClearData(cm, APP_PERSO_AID, APP_PERSON_FID, APP_FILE_SIZE);
           
            return result;
        }

        /// <summary>
        /// write swt license on card
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="dic"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool WriteApplicationSWTLicense(CardManager cm, Dictionary<byte, byte[]> dic, byte[] data)
        {
            
            //check have application

            bool result = SelectApplication(cm, SWT_AID);
            if (!result)
            {
                // does not  have SWT App
                byte keySetting = 0x0F; // free access
                byte numberofkey = 0x01; // one key number
                result = CreateApplication(cm, SWT_AID, keySetting, numberofkey);
                if (result)
                {
                    result = SelectApplication(cm, SWT_AID);
                }
            }

            if (result)
            {
                    
                    byte[] fids = GetFileIDs(cm);
                    if (null == fids || fids.Length < 1 || fids[0] != SWT_LICENSE_FID)
                    {
                        byte com_setting = 0x00;
                        byte[] access_right = { 0xEE, 0xEE };

                        byte[] temp = BitConverter.GetBytes(LICENSE_FILE_SIZE);
                        byte[] file_size = new byte[] { temp[0], temp[1], temp[2] };

                        //create stard file
                        result = CreadStandardDataFile(cm, SWT_LICENSE_FID, com_setting, access_right, file_size);
                    }

                    if (result)
                    {
                        //select file
                        result = WriteData(cm, SWT_LICENSE_FID, data, data.Length);
                    }
                 
            }

            return result;
        }
        /// <summary>
        /// write partner license on card
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="aid"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool WriteApplicationPartnerLicense(CardManager cm, Dictionary<byte, byte[]> aid, byte[] data)
        {
            //check have application

            bool result = SelectApplication(cm, PARTNER_AID);
            if (!result)
            {
                // does not  have SWT App
                byte keySetting = 0x0F; // free access
                byte numberofkey = 0x01; // one key number
                result = CreateApplication(cm, PARTNER_AID, keySetting, numberofkey);
                if (result)
                {
                    result = SelectApplication(cm, PARTNER_AID);
                }
            }

            if (result)
            {
                //try to create file with swt file num
                //select application
                byte[] fids = GetFileIDs(cm);
                if (null == fids || fids.Length < 1 || fids[0] != PARTNER_LICENSE_FID)
                {

                    byte com_setting = 0x00;
                    byte[] access_right = { 0xEE, 0xEE };

                    byte[] temp = BitConverter.GetBytes(LICENSE_FILE_SIZE);
                    byte[] file_size = new byte[] { temp[0], temp[1], temp[2] };

                    //create stard file
                    result = CreadStandardDataFile(cm, PARTNER_LICENSE_FID, com_setting, access_right, file_size);
                }
             
                if (result)
                {
                    //select file
                    result = WriteData(cm, PARTNER_LICENSE_FID, data, data.Length);

                }
            }

            return result;
        }

        /// <summary>
        /// write application data on card
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="aid"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool WritePersoData(CardManager cm, Dictionary<byte, byte[]> aid, byte[] data)
        {
            //check have application
            bool result = SelectApplication(cm, APP_PERSO_AID);
            if (!result)
            {
                // does not  have application for data
                byte keySetting = 0x0F; // free access
                byte numberofkey = 0x01; // one key number
                result = CreateApplication(cm, APP_PERSO_AID, keySetting, numberofkey);

                if (result)
                    result = SelectApplication(cm, APP_PERSO_AID);
            }

            if (result)
            {
                byte com_setting = 0x00;
                byte[] access_right = { 0xEE, 0xEE };

                byte[] temp = BitConverter.GetBytes(APP_FILE_SIZE);

                byte[] file_size = new byte[] { temp[0], temp[1], temp[2] };

                byte[] fids = GetFileIDs(cm);
                if (null == fids || fids.Length <= 0)
                {
                    result = CreadStandardDataFile(cm, APP_PERSON_FID, com_setting, access_right, file_size); //create stard file
                }

                if (result)
                {
                    //select file
                    result = WriteData(cm, APP_PERSON_FID, data, data.Length);

                }
            }

            return result;
        }

        /// <summary>
        /// write application data on card
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="aid"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /*
        public bool WriteApplicationData(CardManager cm, Dictionary<byte, byte[]> aid, byte[] data)
        {
            //check have application
            bool result = SelectApplication(cm, APP_AID);
            if (!result)
            {
                // does not  have application for data
                byte keySetting = 0x0F; // free access
                byte numberofkey = 0x01; // one key number
                result = CreateApplication(cm, APP_AID, keySetting, numberofkey);

                if(result)
                    result = SelectApplication(cm, APP_AID);
            }

            if (result)
            {
                byte com_setting = 0x00;
                byte[] access_right = { 0xEE, 0xEE };

                byte[] temp = BitConverter.GetBytes(APP_FILE_SIZE);

                byte[] file_size = new byte[] { temp[0], temp[1], temp[2] };

                byte[] fids= GetFileIDs(cm);
                if (null == fids || fids.Length <= 0)
                {
                    result = CreadStandardDataFile(cm, APP_FID, com_setting, access_right, file_size); //create stard file
                }
                
                if (result)
                {
                    //select file
                    result = WriteData(cm, APP_FID, data, data.Length);

                }
            }

            return result;
        }
         
        */

        public bool ReadPersoData(CardManager cm, Dictionary<byte, byte[]> aid, out byte[] data)
        {
            bool result = SelectApplication(cm, APP_PERSO_AID);
            data = null;
            if (result)
            {
                byte[] offset = new byte[] { 0x00, 0x00, 0x00 };

                byte[] temp = BitConverter.GetBytes(APP_FILE_SIZE);
                byte[] file_size = new byte[] { temp[0], temp[1], temp[2] };

                data = ReadData(cm, APP_PERSON_FID, offset, APP_FILE_SIZE);
            }
            return result;
        }

        /// <summary>
        /// read application data on card
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="aid"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /*
        public bool ReadApplicationData(CardManager cm, Dictionary<byte, byte[]> aid, out byte[] data)
        {
            bool result = SelectApplication(cm, APP_AID);
            data = null;
            if (result)
            {
                byte[] offset = new byte[] { 0x00, 0x00, 0x00 };

                byte[] temp = BitConverter.GetBytes(APP_FILE_SIZE);
                byte[] file_size = new byte[] { temp[0], temp[1], temp[2] };

                data = ReadData(cm, APP_FID, offset, APP_FILE_SIZE);
            }
            return result;
        }
        */
        /// <summary>
        /// check parter owner card
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public bool HasPartner(CardManager cm)
        {
            bool result = SelectApplication(cm, PARTNER_AID);
            if (result)
            {
                byte[] fids = GetFileIDs(cm);
                if (null == fids)
                    result = false;
            }
            return result;
        }

        /// <summary>
        /// read license: swt and partner
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="obj"></param>
        /// <param name="outdata"></param>
        /// <returns></returns>
        public bool ReadLicense(CardManager cm, LicenseReader obj, out byte[] outdata)
        {
            bool result = false;
            outdata = null;
            switch(obj.currentLicense){
                case LicenseReader.SWT:
                    // select swt aid
                    result = SelectApplication(cm, SWT_AID);
                    if (result)
                    {
                        byte[] offset = new byte[]{0x00, 0x00, 0x00};
                        outdata = ReadData(cm, SWT_LICENSE_FID, offset, LICENSE_FILE_SIZE);
                    }
                    break;
                case LicenseReader.PARTNER:
                    result = SelectApplication(cm, PARTNER_AID);
                    if (result)
                    {
                        byte[] offset = new byte[]{0x00, 0x00, 0x00};
                        outdata = ReadData(cm, PARTNER_LICENSE_FID, offset, LICENSE_FILE_SIZE);
                    }
                    break;
                default:
                    break;

            }
            return result;
            
        }

        #endregion

        #region sParking
        public void SetFreesParking(CardManager cm)
        {
            try
            {
                //check have application
                bool result = SelectApplication(cm, SPK_SWT_AID);
                if (!result)
                {
                    // does not have SPK SWT App
                    byte keySetting = 0x0F; // free access
                    byte numberofkey = 0x01; // one key number
                    CreateApplication(cm, SPK_SWT_AID, keySetting, numberofkey);
                    result = SelectApplication(cm, SPK_SWT_AID);
                }

                if (result)
                {
                    byte com_setting = 0x00;
                    byte[] access_right = { 0xEE, 0xEE };

                    byte[] temp = BitConverter.GetBytes(SP_APP_FILE_SIZE);

                    byte[] file_size = new byte[] { temp[0], temp[1], temp[2] };

                    byte[] fids = GetFileIDs(cm);
                    if (null == fids || fids.Length <= 0 || !fids.Contains(SPK_SWT_FID))
                    {
                        CreadStandardDataFile(cm, SPK_SWT_FID, com_setting, access_right, file_size); //create stard file
                    }
                    //write data to sParking file
                    result = WriteData(cm, SPK_SWT_FID, SPK_SWT_DATA_FOR_FREE, SPK_SWT_DATA_FOR_FREE.Length);
                    if (result)
                    {
                        Beep(cm, 1);
                    }
                }
            }
            catch (Exception e) { }

        }

        public void Beep(CardManager cm, byte numRepeat)
        {
            try
            {
                while (numRepeat-- > 0)
                {
                    cm.Transmit(CommandBeep);
                    Thread.Sleep(150);
                }
            }
            catch (SmartCardException)
            {
                return;
            }
        }
        #endregion

    }
}
