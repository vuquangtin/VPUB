using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CommonHelper.Constants;
using CommonHelper.Utils;
using ReaderManager;
using ReaderManager.Enum;
using ReaderManager.Model;
using ReaderManager.Reader.Pcsc;
using sWorldModel.TransportData;

namespace CardChipService.Card
{
    public class DesfireEVWrapper
    {

        private const int NUMBER_KEY = 16;
        
        /// <summary>
        /// write license data using in application
        /// </summary>
        /// <param name="keypair">used to create application id</param>
        /// <param name="msg">output message</param>
        /// <returns></returns>
        public static bool WriteLicenseData(IReader reader, byte start, byte stop, ResultCheckCardDTO keypair, out string msg)
        {
            msg = String.Empty;
            bool result = false;

            //convert license to byte[]
            byte[] licensedata = StringUtils.HexStringToByteArray(keypair.License);

            /* close because do not use
            //prepare key data
            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();

            // keya using to comm setting
            for (byte s = start; s <= stop; s++)
            {
                byte[] keyB = StringUtils.HexStringToByteArray(keypair.ListSectorKeyPair(s).KeyB);
                dic_sectors.Add(s, keyB);
            }
            */
            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();
            ActionObject dataObj = new ActionObject(dic_sectors, ACTION_MODE.WRITE_LICENSE_DATA_TO_DESFIRE);
            if (start == 0)
                dataObj.Mode = ACTION_MODE.WRITE_SWT_LICENSE_TO_DESFIRE;
            if(start == 4)
                dataObj.Mode = ACTION_MODE.WRITE_PARTNER_LICENSE_TO_DESFIRE;

            result = reader.WriteLicense(dataObj, licensedata);

            if (!result)
            {
                msg = "CanNotWrite";
                return result;
            }
            return result;
        }


        public static bool ClearPersoData(IReader reader, DataToWriteCardDTO keydata, out string msg)
        {
            msg = String.Empty;
            // Check if teacher app metadat exists on card
            if (keydata == null)
                return false;
            
            Dictionary<byte, byte[]> sector_data = new Dictionary<byte, byte[]>();
            ActionObject dataObj = new ActionObject(sector_data, ACTION_MODE.CLEAR_PERSO_ON_DESFIRE);
            return reader.WriteData(dataObj, null);

        }
       
        public static bool ClearApplicationData(IReader reader, DataToWriteCardDTO keydata, out string msg)
        {
            msg = String.Empty;
            // Check if teacher app metadat exists on card
            if (keydata == null)
                return false;
            /*
            // created key
            keydata.CreateDic();

            var sectors = keydata.DicSectorKeyPair.Keys;
            Dictionary<byte, byte[]> sector_data = new Dictionary<byte, byte[]>();
            bool result = false;
            foreach (byte s in sectors)
            {
                if (s == CardConfigration.HEADER_POSSITION)
                    continue;
                byte[] keyB = StringUtils.HexStringToByteArray(keydata.ListSectorKeyPair(s).KeyB);
                sector_data.Add(s, keyB);
                ActionObject dataObj = new ActionObject(sector_data, ACTION_MODE.CLEAR_APPLICATION_ON_DESFIRE);
                result = reader.WriteData(dataObj, null);
                if (result)
                    continue;
            }
            */
            Dictionary<byte, byte[]> sector_data = new Dictionary<byte, byte[]>();
            ActionObject dataObj = new ActionObject(sector_data, ACTION_MODE.CLEAR_APPLICATION_ON_DESFIRE);
            return reader.WriteData(dataObj, null);

        }

        public static bool ClearTheAllApplication(IReader reader, DataToWriteCardDTO keydata, out string msg, bool isPartner)
        {
            msg = String.Empty;
            // Check if teacher app metadat exists on card
            if (keydata == null)
                return false;
            /* 
             * close because do not use
            // created key
            keydata.CreateDic();

            var sectors = keydata.DicSectorKeyPair.Keys;
            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();
            
            foreach (byte s in sectors)
            {
                byte[] keyB = StringUtils.HexStringToByteArray(keydata.ListSectorKeyPair(s).KeyB);
                dic_sectors.Add(s, keyB);

            }
            */
            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();
            ActionObject writeObj = new ActionObject(dic_sectors, ACTION_MODE.CLEAR_ALL_APPLICATION_ON_DESFIRE);
            return reader.WriteData(writeObj, null);
        }

        public static bool WriteApplicationData(IReader reader, DataToWriteCardDTO keyAnddata, out string msg)
        {
            msg = String.Empty;

            // Check if teacher app metadat exists on card
            if (keyAnddata == null)
                return false;
            // Close because do not use
            /*
            // created key
            keyAnddata.CreateDic();
            if (keyAnddata.DicSectorKeyPair == null || keyAnddata.DicSectorKeyPair.Count == 0)
                return false;


            var sectors = keyAnddata.DicSectorKeyPair.Keys;
            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();

            foreach (byte s in sectors)
            {
                if (s == CardConfigration.HEADER_POSSITION)
                    continue;

                byte[] keyB = StringUtils.HexStringToByteArray(keyAnddata.ListSectorKeyPair(s).KeyB);
                dic_sectors.Add(s, keyB);
            }
            */
            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();
            ActionObject writeObj = new ActionObject(dic_sectors, ACTION_MODE.WRITE_APP_DATA_TO_DESFIRE);
            byte[] data = Encoding.UTF8.GetBytes(keyAnddata.Data);
            return reader.WriteData(writeObj, data);
        }

        public static bool ReadPersoData(IReader reader, DataToReadCardDTO key, out byte[] appdata, out string msg)
        {
            msg = String.Empty;
            // Check if teacher app metadat exists on card
            if (key == null)
            {
                appdata = null;
                msg = "CanNotWriteData";
                return false;
            }
            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();

            int datasize = 0; // the value using in desfire wrapper
            ActionObject readObj = new ActionObject(dic_sectors, datasize, ACTION_MODE.READ_PERSON_DATA_ON_DESFIRE);

            // Read sector data
            if (!reader.ReadData(readObj, out appdata))
            {
                appdata = new byte[] { 0x00 };
                return false;
            }

            return true;
        }

        public static bool ReadApplicationData(IReader reader, DataToReadCardDTO key, out byte[] appdata, out string msg)
        {
            msg = String.Empty;
            // Check if teacher app metadat exists on card
            if (key == null)
            {
                appdata = null;
                msg = "CanNotWriteData";
                return false;
            }
            
            //Close when close
            /*
            // created key
            key.CreateDic();
            if (key.DicSectorKeyPair == null || key.DicSectorKeyPair.Count == 0)
            {
                appdata = null;
                msg = "CanNotWriteData";
                return false;
            }

            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();

            int datasize = 0;
            foreach (byte tmp in key.DicSectorKeyPair.Keys)
            {
                if (tmp == CardConfigration.HEADER_POSSITION)
                    continue;
                byte[] keyB = StringUtils.HexStringToByteArray(key.ListSectorKeyPair(tmp).KeyB);
                dic_sectors.Add(tmp, keyB);
            }

             */
            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();

            int datasize = 0; // the value using in desfire wrapper
            ActionObject readObj = new ActionObject(dic_sectors, datasize, ACTION_MODE.READ_APPLICATION_DATA_ON_DESFIRE);

            // Read sector data
            if (!reader.ReadData(readObj, out appdata))
            {
                appdata = new byte[] { 0x00 };
                return false;
            }

            return true;
        }

        public static List<int> KeysRequestForReadData()
        {
            List<int> result = new List<int>();
            for (int i = 0; i < NUMBER_KEY; i++)
            {
                result.Add(i);
            }
            return result;
        }
        public static bool HasPartner(IReader reader)
        {
            byte[] headerdata = new byte[100];
            HeaderObject obj = new HeaderObject(ACTION_MODE.READ_HEADER_DATA_ON_DESFIRE);
            return reader.ReadHeader(obj, out headerdata);
            
        }

        public static bool ReadLicense(IReader reader, Object obj, out byte[] license)
        {
            return reader.ReadLicense(obj, out license);
        }

        internal static bool WritePersoData(IReader reader, DataToWriteCardDTO keyAnddata, out string msg)
        {
            msg = String.Empty;

            // Check if teacher app metadat exists on card
            if (keyAnddata == null)
                return false;
            
            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();
            ActionObject writeObj = new ActionObject(dic_sectors, ACTION_MODE.WRITE_PERSO_DATA_TO_DESFIRE);
            byte[] data = Encoding.UTF8.GetBytes(keyAnddata.Data);
            return reader.WriteData(writeObj, data);
        }
    }
}
