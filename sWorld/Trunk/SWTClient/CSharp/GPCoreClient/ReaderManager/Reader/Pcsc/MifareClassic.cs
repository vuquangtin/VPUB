using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CommonHelper.Constants;
using CommonHelper.Utils;
using ReaderLibrary;
using ReaderManager.Enum;
using ReaderManager.Model;
using ReaderManager.Pcsc;
using sWorldModel.TransportData;

namespace ReaderManager.Reader.Pcsc
{
    public class MifareClassic
    {
        #region private properties

        private CardManager cm = null;
        private string currentReaderName;
        private bool runReaderDetectionLoop = false;

        private APDUCommand CMD_LOAD_KEY = new APDUCommand(0xFF, 0x82, 0x00, 0x00, null, 0x06);
        private APDUCommand CMD_AUTH = new APDUCommand(0xFF, 0x86, 0x00, 0x00, null, 0x05);
        private APDUCommand CMD_READ_BLOCK = new APDUCommand(0xFF, 0xB0, 0x00, 0x00, null, 0x10);
        private APDUCommand CMD_WRITE_BLOCK = new APDUCommand(0xFF, 0xD6, 0x00, 0x00, null, 0x10);
        private APDUCommand CMD_GET_CARD_TYPE = new APDUCommand();

        private readonly APDUCommand CommandGetUid = new APDUCommand(0xFF, 0xCA, 0x00, 0x00, null, 0x04);
        private readonly APDUCommand CommandBeep = new APDUCommand(0xFF, 0x00, 0x40, 0xCF, new byte[] { 0x02, 0x00, 0x01, 0x01 }, 0x04);
        private APDUResponse respond = null;

        private readonly byte[] DEFAULT_KEY = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        private readonly byte[] DEFAULT_ACCESS_CONDITION = new byte[] { 0xFF, 0x07, 0x80, 0x69 };
        private readonly byte[] SCAMPUS_ACCESS_CONDITION = new byte[] { 0x78, 0x77, 0x88, 0x69 };

        private byte readerOrderNumber;

        private bool isBuzzerDisabled = false;
        private bool isBeepOnTagDetected = false;
        private const ushort SUCCESSCODE = 36864;   // 0x9000
        private const ushort FAILEDCODE = 25344;    // 0x6300
        private const ushort DESFIRE_SUCCESSCODE = 37295; //0x91AF

        public event TagDetectedEventHandler TagDetected;
        public event EventHandler TagRemoved;
        public event EventHandler ReaderUnplugged;
        public event EventHandler ReaderPlugged;
        public event EventHandler ReaderNotPresent;

        //return data to form after reading card
        public event DelegateCardDataHandler ReturnCardData;
        public event DisconnectedHandler Disconnected
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        #endregion

        public MifareClassic(byte readerOrderNumber, bool beepOnTag)
        {
            this.readerOrderNumber = readerOrderNumber;
            this.isBeepOnTagDetected = beepOnTag;

        }

        public MifareClassic(CardManager cmobj)
        {
            cm = cmobj;
            this.TagDetected += OnTagDetected;
            this.TagRemoved += OnTagRemoved;
            this.ReaderNotPresent += OnReaderNotPresent;
            this.ReaderUnplugged += OnReaderUnplugged;
            this.ReaderPlugged += OnReaderPlugged;
        }

        /// <summary>
        /// Khi tag thẻ nhận được 2 tham số này đưa vào đối tượng và chuyển đối tượng này qua form xử lý(1/7/2016-ten)
        /// </summary>
        /// <param name="cardType">card type</param>
        /// <param name="serialNumber">serial card</param>
        private void OnTagDetected(int cardType, byte[] serialNumber)
        {
            DataCardObject obj = new DataCardObject(cardType, serialNumber);
            obj.eventType = DataCardObject.TAG_DETECTED;
            ReturnCardData(obj);
        }

        /// <summary>
        /// Gửi mã TAG_REMOVED eventType sang form nhận để xử lý
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTagRemoved(object sender, EventArgs e)
        {
            DataCardObject obj = new DataCardObject();
            obj.eventType = DataCardObject.TAG_REMOVED;
            ReturnCardData(obj);
        }

        /// <summary>
        ///Gửi mã READER_UNPLUGGED  sang form nhận để xử lý 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnReaderUnplugged(object sender, EventArgs e)
        {
            DataCardObject obj = new DataCardObject();
            obj.eventType = DataCardObject.READER_UNPLUGGED;

            //call delegate to send data to form
            ReturnCardData(obj);
        }

        /// <summary>
        /// Gửi mã READER_PLUGGED  sang form nhận để xử lý 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnReaderPlugged(object sender, EventArgs e)
        {
            DataCardObject obj = new DataCardObject();
            obj.eventType = DataCardObject.READER_PLUGGED;
            ReturnCardData(obj);
        }

        /// <summary>
        /// Gửi mã READER_NOT_PRESENT  sang form nhận để xử lý 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnReaderNotPresent(object sender, EventArgs e)
        {
            DataCardObject obj = new DataCardObject();
            obj.eventType = DataCardObject.READER_NOT_PRESENT;
            ReturnCardData(obj);
        }

        /// <summary>
        /// read data using key default in authentication step
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="data"></param>
        /// <param name="useKeyA"></param>
        /// <returns></returns>
        private bool ReadDataOnSectorUsingKeyDefault(byte sector, out byte[] data, bool useKeyA = true)
        {
            return ReadDataOnSectorUsingKey(sector, DEFAULT_KEY, out data, useKeyA);
        }

        /// <summary>
        /// read data using user key in authentication step
        /// </summary>
        /// <param name="sector">index of sector where you want to read data</param>
        /// <param name="keyA">key use to authenticate</param>
        /// <param name="data">buffer using to outputdata</param>
        /// <param name="useKeyA">default is true using keyA default to authenticate . If false is using keyB default to authenticate</param>
        /// <returns>true if successul read  else false</returns>
        private bool ReadDataOnSectorUsingKey(byte sector, byte[] keyA, out byte[] data, bool useKeyA = true)
        {
            bool result = false;
            data = new byte[MifareClassicParams.DetermineDataSectorCapacity(sector)];
            byte[] temp = null;

            // Login with sector key A
            if (Authenticate(sector, keyA, useKeyA))
            {
                // Read sector data
                if (ReadSector(sector, out temp))
                {
                    if (sector == 0)
                    {
                        // 16 byte đầu tiên của sector 0 chứa dữ liệu NSX
                        Array.Copy(temp, 16, data, 0, 32);
                    }
                    else
                    {
                        Array.Copy(temp, 0, data, 0, 48);
                    }
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// beep
        /// </summary>
        /// <param name="numRepeat"></param>
        private void Beep(byte numRepeat)
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

        /// <summary>
        /// write data to sector using key
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="sector_data"></param>
        /// <param name="KeyB"></param>
        /// <param name="useKeyA"></param>
        /// <returns></returns>
        private bool WriteDataOnSectorWithAuthetication(byte sector, byte[] data, byte[] key, bool useKeyA)
        {
            //try to authenticate and write data to sector using key B 
            bool result = Authenticate(sector, key, useKeyA);
            if (result)
                result = WriteSector(sector, data);

            return result;
        }

        /// <summary>
        /// write data and Key B on sector
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="authenKey"></param>
        /// <param name="userkeyA"></param>
        /// <returns></returns>
        private bool WriteDataAndKeyBOnSector(byte sector, byte[] data, byte[] key, byte[] authenKey, bool userkeyA)
        {
            // using key B
            bool result = WriteDataOnSectorWithAuthetication(sector, data, authenKey, userkeyA);
            if (result)
            {
                result = WriteKeyB(sector, key);
            }

            return result;
        }

        /// <summary>
        /// clear key in card
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool ClearKeyOnSector(byte sector, byte[] key)
        {
            //using keyB
            bool result = Authenticate(sector, key, false);
            if (result)
            {
                result = WriteDefaultKeys(sector);
            }
            if (!result)
            {
                result = Authenticate(sector, DEFAULT_KEY, true);
                if (result)
                    result = WriteDefaultKeys(sector);
            }
            return result;
        }

        // <summary>
        /// write data to sector and key B to sector
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool WriteDataAnKeyInSector(byte sector, byte[] keyB, byte[] data)
        {
            // using key B
            bool result = WriteDataAndKeyBOnSector(sector, data, keyB, keyB, false);
            if (!result)
            {
                //using keyA default
                result = WriteDataAndKeyBOnSector(sector, data, keyB, DEFAULT_KEY, true);
                if (!result)
                {
                    
                    result = WriteDataAndKeyBOnSector(sector, data, keyB, DEFAULT_KEY, false);    
                }
            }

            return result;

        }

        #region IReader properties

        public ReaderType Type
        {
            get { return ReaderType.PCSC; }
        }

        public byte Address
        {
            get
            {
                return this.readerOrderNumber;
            }
        }

        public bool BeepOnTagDetected
        {
            get
            {
                return isBeepOnTagDetected;
            }
        }

        #endregion

        #region Utilities

        #region  Private function

        private bool Authenticate(byte sector, byte[] key, bool isKeyA)
        {

            // Get block numbers of sector
            byte[] blockNumbers = GetBlockNumbersOfSector(sector);

            // Load key to reader at position 0x00
            CMD_LOAD_KEY.Data = key;
            try
            {
                respond = cm.Transmit(CMD_LOAD_KEY);
            }
            catch (SmartCardException)
            {
                return false;
            }
            if (respond.Status != SUCCESSCODE)
            {
                return false;
            }

            // Authenticate with card using key at position 0x00
            byte[] authDataBytes = new byte[] { 0x01, 0x00, blockNumbers[0], (byte)(isKeyA ? 0x60 : 0x61), 0x00 };
            CMD_AUTH.Data = authDataBytes;
            respond = cm.Transmit(CMD_AUTH);
            try
            {
                return (respond.Status == SUCCESSCODE) ? true : false;

            }
            catch (SmartCardException)
            {
                return false;
            }
        }


        private bool ReadBlock(byte block, out byte[] blockData)
        {
            // P2 is block number to be accessed
            CMD_READ_BLOCK.P2 = block;

            try
            {
                respond = cm.Transmit(CMD_READ_BLOCK);
            }
            catch (SmartCardException)
            {
                blockData = null;
                return false;
            }
            blockData = respond.Data;
            return respond.Status == SUCCESSCODE;
        }

        /// <summary>
        /// Read data block of sector (not trailer block)
        /// </summary>
        private bool ReadSector(byte sector, out byte[] sectorData)
        {
            byte[] blockNumbers = GetBlockNumbersOfSector(sector);
            int trailerBlockPos = blockNumbers.Length - 1;

            // trailerBlockPos value is equal to the number of data blocks
            sectorData = new byte[trailerBlockPos * MifareClassicParams.BLOCK_SIZE];

            // Iterate through each block
            byte[] blockData;
            for (byte i = blockNumbers[0], j = 0; i < blockNumbers[trailerBlockPos]; i++, j++)
            {
                if (ReadBlock(i, out blockData))
                {
                    Array.Copy(respond.Data, 0, sectorData, j * MifareClassicParams.BLOCK_SIZE, MifareClassicParams.BLOCK_SIZE);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        // Nhận vào sector index trả ra index các block nó chứa
        private byte[] GetBlockNumbersOfSector(byte sector)
        {
            byte blocksPerSector;
            byte minBlockNumber;

            if (sector <= 31)
            {
                blocksPerSector = 4;
                minBlockNumber = (byte)(sector * blocksPerSector);
            }
            else if (sector <= 39)
            {
                blocksPerSector = 16;
                minBlockNumber = (byte)(128 + (sector - 32) * blocksPerSector); // 128 = 32 sectors * 4 blocks
            }
            else
            {
                throw new SmartCardException(ScErrorCodes.OUT_OF_SECTOR, sector.ToString());
            }

            byte[] blockNumbers = new byte[blocksPerSector];
            for (byte i = 0; i < blocksPerSector; i++)
            {
                blockNumbers[i] = (byte)(minBlockNumber + i);
            }
            return blockNumbers;
        }

        // Nhận vào sector index trả ra trailer block index của nó.
        private byte GetTrailerBlockNumber(byte sector)
        {
            if (sector <= 31)
            {
                return (byte)(sector * 4 + 3);
            }
            else if (sector <= 39)
            {
                return (byte)(sector * 16 + 3);
            }
            else
            {
                throw new SmartCardException(ScErrorCodes.OUT_OF_SECTOR, sector.ToString());
            }
        }

        // Nhận vào index sector a và sector b, trả ra tổng số byte dữ liệu có thể ghi được ở giữa (ko tính sector b).
        private int GetByteTotalBySector(byte sectorStart, byte sectorStop)
        {
            int byteDataTotal = 0;
            for (byte index = sectorStart; index < sectorStop; index++)
            {
                byteDataTotal += MifareClassicParams.DetermineDataSectorCapacity(index);
            }
            return byteDataTotal;
        }

        /// <summary>
        /// prepare data for writing to sector
        /// </summary>
        /// <param name="dataStr"></param>
        /// <param name="sector"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        private byte[] PrepareData4WriteOnSector(byte[] data, byte sector, ref int offset)
        {
            if (data.Length <= 0)
                return null;

            byte[] sectorData = null;

            //lấy dung lượng byte của sector
            int sectorSize = MifareClassicParams.DetermineDataSectorCapacity(sector);

            int len = data.Length - offset;

            if (len > sectorSize)
            {
                sectorData = new byte[sectorSize];
                Array.Copy(data, offset, sectorData, 0, sectorSize);
            }
            else if (len > 0)
            {
                sectorData = new byte[len];
                Array.Copy(data, offset, sectorData, 0, len);
            }
            else
                sectorData = new byte[sectorSize];
            offset += sectorSize;

            return sectorData;
        }

        private bool WriteBlock(byte block, byte[] blockData)
        {
            // Check if data length is greater than block size
            if (blockData.Length > MifareClassicParams.BLOCK_SIZE)
            {
                throw new SmartCardException(ScErrorCodes.INVALID_ARGUMENT, "blockData");
            }

            // Pad right with zero if data length less than BLOCK_SIZE
            if (blockData.Length < MifareClassicParams.BLOCK_SIZE)
            {
                byte[] temp = blockData;
                blockData = new byte[MifareClassicParams.BLOCK_SIZE];
                temp.CopyTo(blockData, 0);
            }

            // P2 is block number to be accessed
            CMD_WRITE_BLOCK.P2 = block;
            CMD_WRITE_BLOCK.Data = blockData;
            CMD_WRITE_BLOCK.Length = (byte)blockData.Length;
            try
            {
                respond = cm.Transmit(CMD_WRITE_BLOCK);
            }
            catch (SmartCardException)
            {
                return false;
            }
            return respond.Status == SUCCESSCODE;
        }

        private bool WriteSector(byte sector, byte[] sectorData)
        {
            // Check if data bytes is null
            if (sectorData == null)
            {
                throw new ScException(ScErrorCodes.INVALID_ARGUMENT, "sectorData");
            }

            // Check if data bytes's length is greater than the actual capacity of sector
            byte[] blockNumbers = GetBlockNumbersOfSector(sector);
            int trailerBlockPos = blockNumbers.Length - 1;

            // trailerBlockPos value is equal to the number of data blocks
            if (sectorData.Length > MifareClassicParams.DetermineDataSectorCapacity(sector))
            {
                throw new ScException(ScErrorCodes.INVALID_ARGUMENT, "sectorData");
            }

            byte[] blockData;
            int offset = 0;
            int len = sectorData.Length;

            // Write data to sector
            for (byte i = blockNumbers[0]; i < blockNumbers[trailerBlockPos]; i++)
            {
                // Block 0 chứa dữ liệu của NSX -> không được phép ghi đè
                if (sector == 0 && i == 0)
                {
                    continue;
                }

                blockData = len <= MifareClassicParams.BLOCK_SIZE ? new byte[len] : new byte[MifareClassicParams.BLOCK_SIZE];
                Array.Copy(sectorData, offset, blockData, 0, blockData.Length);

                if (WriteBlock(i, blockData))
                {
                    len -= blockData.Length;
                    offset += blockData.Length;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private bool WriteSectorKeys(byte sector, byte[] newKeyA, byte[] newKeyB, byte[] accessCondition)
        {
            if (newKeyA == null || newKeyA.Length != 6)
            {
                throw new SmartCardException(ScErrorCodes.INVALID_ARGUMENT, "newKeyA");
            }
            if (newKeyB == null || newKeyB.Length != 6)
            {
                throw new SmartCardException(ScErrorCodes.INVALID_ARGUMENT, "newKeyB");
            }

            byte[] trailerBlockData = new byte[16];
            newKeyA.CopyTo(trailerBlockData, 0);
            accessCondition.CopyTo(trailerBlockData, 6);
            newKeyB.CopyTo(trailerBlockData, 10);

            byte trailerBlockNumber = GetTrailerBlockNumber(sector);

            return WriteBlock(trailerBlockNumber, trailerBlockData);
        }

        private bool WriteDataKeys(byte sector, byte[] newKeyA, byte[] newKeyB)
        {
            return WriteSectorKeys(sector, newKeyA, newKeyB, SCAMPUS_ACCESS_CONDITION);
        }

        private bool WriteKeyA(byte sector, byte[] newKeyA)
        {
            return WriteSectorKeys(sector, newKeyA, DEFAULT_KEY, SCAMPUS_ACCESS_CONDITION);
        }

        private bool WriteKeyB(byte sector, byte[] newKeyB)
        {
            return WriteSectorKeys(sector, DEFAULT_KEY, newKeyB, SCAMPUS_ACCESS_CONDITION);
        }

        private bool WriteDefaultKeys(byte sector)
        {
            return WriteSectorKeys(sector, DEFAULT_KEY, DEFAULT_KEY, DEFAULT_ACCESS_CONDITION);
        }

        /// <summary>
        /// clear data on sector
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool ClearDataOnSector(byte sector, byte[] key, byte[] data)
        {
            // using key B
            bool result = WriteDataOnSectorWithAuthetication(sector, data, key, false);
            if (result)
            {
                result = WriteDefaultKeys(sector);
            }

            if (!result)
            {
                result = WriteDataOnSectorWithAuthetication(sector, data, DEFAULT_KEY, true);

                if (result)
                {
                    result = WriteDefaultKeys(sector);
                }
            }
            return result;
        }

        private bool ClearAllOnSector(byte sector, byte[] key, byte[] data)
        {
            // using key B
            bool result = WriteDataOnSectorWithAuthetication(sector, data, key, false);
            if (result)
            {
                result = WriteDefaultKeys(sector);
            }

            if (!result)
            {
                result = WriteDataOnSectorWithAuthetication(sector, data, DEFAULT_KEY, true);

                if (result)
                {
                    result = WriteDefaultKeys(sector);
                }
            }

            if (!result)
            {
                result = WriteDataOnSectorWithAuthetication(sector, data, DEFAULT_KEY, false);

                if (result)
                {
                    result = WriteDefaultKeys(sector);
                }
            }

            if (!result)
            {
                result = WriteDataOnSectorWithAuthetication(sector, data, key, true);

                if (result)
                {
                    result = WriteDefaultKeys(sector);
                }
            }

            return result;
        }

        #endregion


        // tạo key map <sector index , cặp key>
        private Dictionary<byte, SectorKeyPairDTO> CreateDic(List<KeyDTO> keyList)
        {
            Dictionary<byte, SectorKeyPairDTO> dicSectorKeyPair = new Dictionary<byte, SectorKeyPairDTO>();
            if (keyList != null)
            {
                dicSectorKeyPair = new Dictionary<byte, SectorKeyPairDTO>();
                foreach (KeyDTO key in keyList)
                {
                    dicSectorKeyPair.Add(key.Alias, key.Key);
                }
            }
            return dicSectorKeyPair;
        }


        private bool WriteDataOrKeyToHeader(byte[] data, ACTION_MODE writeMode = ACTION_MODE.WRITE_DATA)
        {
            switch (writeMode)
            {
                case ACTION_MODE.WRITE_KEYA_DEFAULT: // using keyA default
                    return WriteKeyA(MifareClassicParams.HEADER_POSITION, DEFAULT_KEY);
                    break;
                case ACTION_MODE.WRITE_KEYA: // using keyA default
                    return WriteKeyA(MifareClassicParams.HEADER_POSITION, data);
                    break;
                case ACTION_MODE.WRITE_KEYB_DEFAULT: // using keyB default
                    return WriteKeyB(MifareClassicParams.HEADER_POSITION, DEFAULT_KEY);
                    break;
                case ACTION_MODE.WRITE_KEYB: // using keyB
                    return WriteKeyB(MifareClassicParams.HEADER_POSITION, data);
                    break;
                default:
                    return WriteSector(MifareClassicParams.HEADER_POSITION, data);
                    break;
            }
            return false;
        }

        #endregion

        
        #region IReader functions

        
        
        /// <summary>
        /// Đọc license thẻ
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="license"></param>
        /// <returns></returns>
        public bool ReadLicense(Object obj, out byte[] license)
        {
            // parse thành đối tượng LicenseReader
            LicenseReader licenseobj = (LicenseReader)obj;

            license = new byte[MifareClassicParams.LICENSE_LENGTH];
            int offset = 0;
            byte[] temp = null;

            byte swt = 0;
            //this is swt license
            if (licenseobj.currentLicense == LicenseReader.SWT)
                swt = 0;
            else
                swt = 6;

            for (byte s = licenseobj.start; s <= licenseobj.stop; s++)
            {
                // authentication on sector
                if (Authenticate(s, DEFAULT_KEY, true))
                {
                    // read value on sector
                    if (ReadSector(s, out temp))
                    {
                        // Kiểm tra License đang gọi là license nào và so sánh sector == 0 hoặc == 6
                        if (s == swt)
                        {
                            // 16 byte đầu tiên của sector 0 chứa dữ liệu NSX
                            Array.Copy(temp, (swt == 0 ? 16 : 0), license, offset, 32);
                            offset += 32;
                        }
                        else
                        {
                            Array.Copy(temp, 0, license, offset, 48);
                            offset += 48;
                        }
                    }
                }


            }
            return true;
        }
        
        /// <summary>
        /// Read data from card
        /// </summary>
        /// <param name="obj">ccongifuration object. It depents on card type</param>
        /// <param name="data">data from card</param>
        /// <returns></returns>
        public bool ReadData(Object obj, out byte[] data)
        {
            ActionObject actionObj = (ActionObject)obj;
            Dictionary<byte, byte[]> sectors = actionObj.Sectors;
            data = new byte[actionObj.DataSize];
            bool result = false;
            int offset = 0;
            foreach (byte sector in sectors.Keys)
            {
                byte[] sectorData;
                result = false;
                result = ReadDataOnSectorUsingKeyDefault(sector, out sectorData);
                if (result)
                {
                    sectorData.CopyTo(data, offset);
                    offset += MifareClassicParams.DetermineDataSectorCapacity(sector);
                    continue;
                }

                //using key A
                result = ReadDataOnSectorUsingKey(sector, sectors[sector], out sectorData);
                if (result)
                {
                    sectorData.CopyTo(data, offset);
                    offset += MifareClassicParams.DetermineDataSectorCapacity(sector);
                    continue;
                }

                //using key B
                result = ReadDataOnSectorUsingKey(sector, sectors[sector], out sectorData, false);
                if (result)
                {
                    sectorData.CopyTo(data, offset);
                    offset += MifareClassicParams.DetermineDataSectorCapacity(sector);
                    continue;
                }

                // read keyB default
                result = ReadDataOnSectorUsingKeyDefault(sector, out sectorData, false);
                if (result)
                {
                    sectorData.CopyTo(data, offset);
                    offset += MifareClassicParams.DetermineDataSectorCapacity(sector);
                    continue;
                }
            }
            return result;
        }

        /// <summary>
        /// write data
        /// </summary>
        /// <param name="Obj"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool WriteData(Object Obj, byte[] data)
        {
            // Parse Obj thành Obj ListKey
            bool result = false;
            int offset = 0;
            ActionObject writeObj = (ActionObject)Obj;
            
            foreach(KeyValuePair<byte, byte[]> item in writeObj.Sectors){
                //prepare data for writing on sector
                byte sector = item.Key;
                byte[] sector_data = PrepareData4WriteOnSector(data, sector, ref offset);
                byte[] KeyB = item.Value;
                result = WriteDataOnSector(sector, KeyB, sector_data, writeObj.Mode);

                if (result)
                    continue;
                else
                    return result;
            }
            
            return result;
        }

        /// <summary>
        /// write data on sector
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool WriteDataOnSector(byte sector, byte[] Key, byte[] data, ACTION_MODE mode)
        {
            bool result = false;

            switch (mode)
            {
                case ACTION_MODE.CLEAR_DATA:
                    result = ClearDataOnSector(sector, Key, data);
                    break;
                case ACTION_MODE.CLEAR_UP_CARD:
                    result = ClearAllOnSector(sector, Key, data);
                    break;
                case ACTION_MODE.CLEAR_KEY:
                    result = ClearKeyOnSector(sector, Key);
                    break;
                case ACTION_MODE.WRITE_DATA:
                case ACTION_MODE.WRITE_DATA_AND_HEADER:
                case ACTION_MODE.WRITE_LICENSE_DATA:
                case ACTION_MODE.WRITE_APP_DATA:
                    result = WriteDataAnKeyInSector(sector, Key, data);
                    break;
                default:
                    break;
            }
            return result;
        }

        #endregion

        /// <summary>
        /// write byte to header
        /// </summary>
        /// <param name="obj">null: write header data to header sector. another way is write header key to header sector</param>
        /// <param name="headerData"></param>
        /// <returns></returns>
        public bool WriteHeader(Object obj, byte[] headerData)
        {
            HeaderObject Obj = (HeaderObject)obj;
            return WriteDataAnKeyInSector(Obj.Sector, Obj.Key, headerData);
        }

        public bool WriteLicense(Object obj, byte[] headerData)
        {
            HeaderObject Obj = (HeaderObject)obj;
            return WriteDataAnKeyInSector(Obj.Sector, Obj.Key, headerData);
        }

        /// <summary>
        /// read header data
        /// </summary>
        /// <param name="headerData"></param>
        /// <returns></returns>
        public bool ReadHeader(Object obj, out byte[] headerData)
        {
            HeaderObject headerObj = (HeaderObject)obj;
            return ReadDataOnSectorUsingKeyDefault(headerObj.Sector, out headerData);
        }

        /// <summary>
        /// get serial number
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool GetSerialNumber(Object obj, out string uid)
        {
            uid = null;
            try
            {
                respond = cm.Transmit(CommandGetUid);
                if (respond.Status == SUCCESSCODE && respond.Data != null && respond.Data.Length == 4)
                {
                    uid = StringUtils.ByteArrayToHexString(respond.Data);
                    return true;
                }
            }
            catch (SmartCardException)
            {
                return false;
            }

            return false;
        }

    }
}
