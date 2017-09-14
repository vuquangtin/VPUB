using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using ReaderManager;
using ReaderManager.Enum;
using ReaderManager.Model;
using sWorldModel.TransportData;

namespace CardChipService.Card
{
    public class MifareClassicWrapper
    {

        private static readonly byte BEGIN_SECTOR_DATA_NOTPARTNER = 4;//khi master va partner trung nhau
        private static readonly byte BEGIN_SECTOR_DATA_HASPARTNER = 7;//khi master va partner khac nhau
        private static readonly byte partner = 0xAA;
        private static readonly byte master = 0x00;
        private static readonly string DEFAULT_KEY = "ffffffffffff";
        
        /// <summary>
        /// clear application data on card using specifi card reader
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="keydata"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool ClearAppData(IReader reader, DataToWriteCardDTO keydata, out string msg)
        {
            msg = String.Empty;
            // Check if teacher app metadat exists on card
            if (keydata == null)
                return false;

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
                ActionObject dataObj = new ActionObject(sector_data, ACTION_MODE.CLEAR_UP_CARD);

                int datasize = MifareClassicParams.DetermineDataSectorCapacity(s);
                byte[] data = new byte[datasize];
                result = reader.WriteData(dataObj, data);


                if (result)
                    continue;
            }
            return result;
        }

        /// <summary>
        /// clear all data on card
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="keydata"></param>
        /// <param name="msg"></param>
        /// <param name="isPartner"></param>
        /// <returns></returns>
        public static bool ClearUpAllData(IReader reader, DataToWriteCardDTO keydata, out string msg, bool isPartner)
        {
            msg = String.Empty;
            // Check if teacher app metadat exists on card
            if (keydata == null)
                return false;

            // created key
            keydata.CreateDic();

            var sectors = keydata.DicSectorKeyPair.Keys;

            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();
            int datasize = 0;
            foreach (byte s in sectors)
            {
                byte[] keyB = StringUtils.HexStringToByteArray(keydata.ListSectorKeyPair(s).KeyB);
                dic_sectors.Add(s, keyB);

                datasize += MifareClassicParams.DetermineDataSectorCapacity(s);
            }

            ActionObject writeObj = new ActionObject(dic_sectors, ACTION_MODE.CLEAR_UP_CARD);
            byte[] data = new byte[datasize];
            return reader.WriteData(writeObj, data);

        }

        /// <summary>
        /// write app data
        /// </summary>
        /// <param name="keyAnddata"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool WriteAppData(IReader reader, DataToWriteCardDTO keyAnddata, out string msg)
        {
            msg = String.Empty;

            // Check if teacher app metadat exists on card
            if (keyAnddata == null)
                return false;

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

            ActionObject writeObj = new ActionObject(dic_sectors, ACTION_MODE.WRITE_APP_DATA);
            byte[] data = Encoding.ASCII.GetBytes(keyAnddata.Data);
            return reader.WriteData(writeObj, data);
        }


        public static bool ReadAppData(IReader reader, DataToReadCardDTO key, byte[] headerData, out byte[] appdata, out string msg)
        {
            msg = String.Empty;
            // Check if teacher app metadat exists on card
            if (key == null)
            {
                appdata = null;
                msg = "CanNotWriteData";
                return false;
            }
            // created key
            key.CreateDic();
            if (key.DicSectorKeyPair == null || key.DicSectorKeyPair.Count == 0)
            {
                appdata = null;
                msg = "CanNotWriteData";
                return false;
            }
            
            byte totalSectorData = headerData[1];
            byte sectorBegin = headerData[0] == master ? BEGIN_SECTOR_DATA_NOTPARTNER : BEGIN_SECTOR_DATA_HASPARTNER;
            byte sectorEnd = (byte)(totalSectorData + sectorBegin);

            appdata = new byte[totalSectorData * MifareClassicParams.SECTOR_SIZE];
            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();

            int datasize = 0;
            foreach (byte tmp in key.DicSectorKeyPair.Keys)
            {
                if (tmp == CardConfigration.HEADER_POSSITION)
                    continue;
                byte[] keyB = StringUtils.HexStringToByteArray(key.ListSectorKeyPair(tmp).KeyB);
                datasize += MifareClassicParams.DetermineDataSectorCapacity(tmp);
                dic_sectors.Add(tmp, keyB);
            }

            ActionObject readObj = new ActionObject(dic_sectors, datasize, ACTION_MODE.READ_DATA);

            // Read sector data
            if (!reader.ReadData(readObj, out appdata))
            {
                appdata = new byte[] { 0x00 };
                return false;
            }

            return true;
        }

        public static bool WriteLicenseData(IReader reader, byte start, byte stop, ResultCheckCardDTO resultKeyPair, out String msg)
        {
            msg = String.Empty;
            bool result = false;
            //convert license to byte[]
            byte[] licensedata = StringUtils.HexStringToByteArray(resultKeyPair.License);

            // created key pair 

            Dictionary<byte, byte[]> dic_sectors = new Dictionary<byte, byte[]>();
            for (byte s = start; s <= stop; s++)
            {
                byte[] keyB = StringUtils.HexStringToByteArray(resultKeyPair.ListSectorKeyPair(s).KeyB);
                dic_sectors.Add(s, keyB);
            }

            ActionObject dataObj = new ActionObject(dic_sectors, ACTION_MODE.WRITE_LICENSE_DATA);
            result = reader.WriteData(dataObj, licensedata);
            if (!result)
            {
                msg = "CanNotWrite";
                return result;
            }
            return result;

        }


        public static bool ReadHeaderData(IReader reader, out byte[] headerData, out string msg)
        {
            msg = String.Empty;
            HeaderObject headerObj = new HeaderObject(CardConfigration.HEADER_POSSITION, null, null);
            bool result = reader.ReadHeader(headerObj, out headerData);
            if (!result)
                msg = "CannotReadHeader";

            return result;
        }

        public static bool WriteHeaderData(IReader reader, bool IsMaster, List<KeyDTO> keydata, out string msg)
        {
            msg = String.Empty;
            // Check if teacher app metadat exists on card
            if (keydata == null)
            {
                msg = "CanNotWriteData";
                return false;
            }
            KeyDTO headerKey = keydata.FirstOrDefault(k => k.Alias == CardConfigration.HEADER_POSSITION);
            List<KeyDTO> dataKey = keydata.Where(s => s.Alias != 3).ToList();

            byte[] KeyB = StringUtils.HexStringToByteArray(headerKey.Key.KeyB);
            byte[] data = new byte[MifareClassicParams.SECTOR_SIZE];
            byte[] keyReadData = WriteBitArrayToByteHeader(keydata);

            //Cập nhật byte để biết thẻ có partner hay k?
            data[0] = IsMaster ? master : partner; // has partner
            data[1] = (byte)keydata.Count; // the number sector have data
            data[2] = (byte)(keyReadData.Length + 3); // byte vi tri thu 3
            Array.Copy(keyReadData, 0, data, 3, keyReadData.Length);

            //TODO: write data to header and key to header
            HeaderObject headerObj = new HeaderObject(CardConfigration.HEADER_POSSITION, KeyB, data);

            bool result = reader.WriteHeader(headerObj, data);

            return result;
        }

        /// <summary>
        /// update header data
        /// </summary>
        /// <param name="headerData"></param>
        /// <param name="headerKeyB"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool UpdateHeaderData(IReader reader, byte[] headerData, byte[] headerKeyB, out string msg)
        {
            msg = String.Empty;
            byte[] data = new byte[MifareClassicParams.SECTOR_SIZE];

            //TODO Write update data on card

            HeaderObject headerObj = new HeaderObject(MifareClassicParams.HEADER_POSITION, headerKeyB, headerData);
            bool result = reader.WriteHeader(headerObj, data);
            if (!result)
            {
                msg = "CanNotWrite";
                return false;
            }

            return result;
        }


        public static List<int> NeedRequestKeyReadData(byte[] headerData)
        {
            List<int> lsresult = new List<int>();
            byte sectorBegin = headerData[0] == master ? BEGIN_SECTOR_DATA_NOTPARTNER : BEGIN_SECTOR_DATA_HASPARTNER;
            if (headerData.Length > 2)
            {
                for (byte i = 3; i < headerData[2]; i++)
                {
                    BitArray arrbit = new BitArray(new byte[] { headerData[i] });
                    for (byte j = 0; j < 8; j++)
                    {
                        if (arrbit.Get(j))
                        {
                            lsresult.Add((i - 3) * 8 + j + sectorBegin);
                        }
                    }
                }
            }

            return lsresult;
        }

        //lay sector bat dau va sector ket thuc de ghi data
        public static void IdentifyBeginSectorFromHeaderData(byte[] headerData, out byte sectorBegin, out byte sectorEnd)
        {
            sectorBegin = sectorEnd = 0;
            if (headerData.Length > 3)
            {
                byte sectorDataTotal = headerData[1];
                sectorBegin = headerData[0] == master ? BEGIN_SECTOR_DATA_NOTPARTNER : BEGIN_SECTOR_DATA_HASPARTNER;
                sectorEnd = (byte)(sectorBegin + sectorDataTotal);
            }
        }

        /// <summary>
        /// lay thong tin HMK_ALIAS, DMKA_ALIAS, DMKB_ALIAS, PVK_ALIAS
        /// de ghi vao the
        /// </summary>
        /// <param name="headerData"></param>
        public static bool GetDataHerder(ref byte[] headerData)
        {
            byte[] data = new byte[4];
            if (headerData.Length > 0)
            {
                byte sectorReadData = headerData[2];
                if (sectorReadData > 0)
                {
                    Array.Copy(headerData, 3 + sectorReadData, data, 0, 4);
                    headerData = data;
                    return true;
                }
            }
            return false;
        }


        public static bool HasPartner(byte[] headerdata)
        {
            if (headerdata.Length > 0 && headerdata[0] == partner)
                return true;

            return false;
        }

        public static bool ReadLicense(IReader reader, Object obj, out byte[] license)
        {
            return reader.ReadLicense(obj, out license);
        }

        private static byte[] WriteBitArrayToByteHeader(List<KeyDTO> keyDataList)
        {
            if (keyDataList.Count <= 0)
                return null;

            int coutData = keyDataList.Count,
                lenghtByteHeader = (coutData / 8) + (coutData % 8 == 0 ? 0 : 1);
            byte[] byteHeader = new byte[lenghtByteHeader];
            BitArray arrbit = new BitArray(byteHeader);
            for (int index = 0; index < coutData; index++)
            {
                if (keyDataList[index].Key.KeyA != DEFAULT_KEY)
                    arrbit.Set(index, true);
            }

            return ConvertToByte(arrbit, lenghtByteHeader);
        }

        private static byte[] ConvertToByte(BitArray bits, int count)
        {

            if (bits.Count <= 0)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[count];
            bits.CopyTo(bytes, 0);
            return bytes;
        }

    }
}
