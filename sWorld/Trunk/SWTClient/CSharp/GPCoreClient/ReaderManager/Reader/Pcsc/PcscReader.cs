using System.Threading;
using ReaderManager.Model;
using System;

using System.Collections.Generic;
using sWorldModel.TransportData;
using CommonHelper.Utils;
using System.Text;
using CommonHelper.Constants;
using ReaderLibrary;
using CommonControls;
using System.Linq;
using ReaderManager.Enum;
using ReaderManager.Contants;
using ReaderManager.Reader.Pcsc;

namespace ReaderManager.Pcsc
{

    /// <summary>
    /// Lớp hiện thực cho các đầu đọc hỗ trợ PC/SC
    /// </summary>
    public class PcscReader : IReader
    {
        #region private properties

        private CardManager cm = new CardManager();
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

        public PcscReader(byte readerOrderNumber, bool beepOnTag)
        {
            this.readerOrderNumber = readerOrderNumber;
            this.isBeepOnTagDetected = beepOnTag;

        }

        public PcscReader()
        {
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
            //call delegate to send data to form
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
            try
            {

                DataCardObject obj = new DataCardObject();
                obj.eventType = DataCardObject.READER_UNPLUGGED;

                //call delegate to send data to form
                ReturnCardData(obj);

                DisconnectFromReader();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Gửi mã READER_PLUGGED  sang form nhận để xử lý 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnReaderPlugged(object sender, EventArgs e)
        {
            try
            {
                DataCardObject obj = new DataCardObject();
                obj.eventType = DataCardObject.READER_PLUGGED;
                ReturnCardData(obj);
            }
            catch (Exception ex)
            {
            }
            
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

        private void DisconnectFromReader()
        {
            try
            {
                if (runReaderDetectionLoop)
                {
                    runReaderDetectionLoop = false;
                }
                else
                {
                    cm.Disconnect(DISCONNECT.UNPOWER);
                    UnsubscribeEvents();
                    cm.StopCardEvents();
                }
            }
            catch (ScException) { }
            finally
            {
                currentReaderName = null;
            }
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


        #region Hàm kết nối đầu đọc, đọc thông tin

        /// <summary>
        /// check current reader
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool hasCurrentReader(string name)
        {
            // Liệt kê danh sách các reader được kết nối với máy tính. 
            // Mỗi reader được định danh bằng: <reader-name> <port-number>. 
            // Ví dụ: SCM Microsystems Inc. SCL011G Contactless Reader 0
            // fill all card reader
            List<string> listReader = FindAllCardReader();

            if (null != listReader && listReader.Contains(name))
                return true;

            return false;
        }

        /// <summary>
        /// connect to reader and create some event of reader
        /// </summary>
        /// <returns></returns>
        private bool ConnectToReader()
        {
            try
            {
                cm.StopCardEvents();
                cm.StartCardEvents(currentReaderName);
                SubscribeEvents();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void OnCardRemovedHandler(object sender, EventArgs e)
        {
            if (TagRemoved != null)
            {
                TagRemoved(this, EventArgs.Empty);
            }
        }

        private void OnReaderUnpluggedHandler(object s, EventArgs e)
        {
            if (ReaderUnplugged != null)
            {
                ReaderUnplugged(this, EventArgs.Empty);
            }
            DisconnectFromReader();
        }

        private void UnsubscribeEvents()
        {
            cm.CardInserted -= OnCardInsertedHandler;
            cm.CardRemoved -= OnCardRemovedHandler;
            cm.ReaderUnplugged -= OnReaderUnpluggedHandler;
        }

        private void OnCardInsertedHandler(short cardType, byte[] serialNumber)
        {
            if (TagDetected != null)
            {
                TagDetected(cardType, serialNumber);
            }
        }

        private void SubscribeEvents()
        {
            cm.CardInserted += OnCardInsertedHandler;
            cm.CardRemoved += OnCardRemovedHandler;
            cm.ReaderUnplugged += OnReaderUnpluggedHandler;
        }

        #endregion

        #region IReader functions

        public List<string> FindAllCardReader()
        {
            string[] temp = cm.ListReaders();

            return temp != null ? new List<string>(cm.ListReaders()) : null;
        }

        /// <summary>
        /// Connect to card reader
        /// </summary>
        /// <param name="obj">name of card reader</param>
        /// <returns></returns>
        public bool Connect(Object obj)
        {
            // Disconnect if connected
            string name = (string)obj;
            Disconnect(null);


            // Liệt kê danh sách các reader được kết nối với máy tính. 
            // Mỗi reader được định danh bằng: <reader-name> <order-number>. 
            // Ví dụ: SCM Microsystems Inc. SCL011G Contactless Reader 0
            List<string> listreaders = FindAllCardReader();

            // Nếu có đầu đọc kết nối đến máy tính, listReaders sẽ không null
            if (listreaders.Count > 0 && listreaders.Contains(name))
            {
                currentReaderName = name; // save current reader name .
                return true;
            }

            return false;
        }

        /// <summary>
        /// Disconnect reader
        /// </summary>
        /// <param name="obj"></param>
        public void Disconnect(Object obj)
        {
            try
            {
                if (runReaderDetectionLoop)
                {
                    runReaderDetectionLoop = false;
                }
                else
                {
                    cm.Disconnect(DISCONNECT.UNPOWER);
                    UnsubscribeEvents();
                    cm.StopCardEvents();
                }
            }
            catch (ScException) { }
            finally
            {
                currentReaderName = null;
            }
        }

        /// <summary>
        /// Alert signal when new card detected
        /// <param name="obj"></param>
        public void AlertSignalOnTagDetected(Object obj)
        {
            byte numRepeat = (bool)obj ? (byte)1 : (byte)2;
            Beep(numRepeat);
        }

        /// <summary>
        /// waitting card 
        /// </summary>
        /// <param name="obj"></param>
        public void WaittingCard(Object obj)
        {

            WaitingCardObject cardControl = (WaitingCardObject)obj;
            if (null != cardControl && cardControl.CurrentReaderName != "")
                this.currentReaderName = cardControl.CurrentReaderName;

            Thread th = new Thread(() =>
            {
                runReaderDetectionLoop = true;
                int sleepDuration = 800;
                int maxLoop = 30;
                int count = 0;

                while (runReaderDetectionLoop)
                {
                    if (count++ == maxLoop)
                    {
                        if (ReaderNotPresent != null)
                        {
                            this.ReaderNotPresent(this, EventArgs.Empty);
                        }
                        runReaderDetectionLoop = false;
                        return;
                    }

                    // Liệt kê danh sách các reader được kết nối với máy tính. 
                    // Mỗi reader được định danh bằng: <reader-name> <port-number>. 
                    // Ví dụ: SCM Microsystems Inc. SCL011G Contactless Reader 0
                    if (hasCurrentReader(currentReaderName))
                    {
                        // try to connect reader
                        if (ConnectToReader())
                        {
                            if (ReaderPlugged != null)
                            {
                                ReaderPlugged(this, EventArgs.Empty);
                            }
                            runReaderDetectionLoop = false;
                            return;
                        }
                    }

                    Thread.Sleep(sleepDuration);
                }
            });
            th.Start();
        }

        /// <summary>
        /// detection is started
        /// </summary>
        /// <param name="obj"></param>
        public void StartCardDetection(Object obj)
        {
            if (currentReaderName == null)
            {
                throw new ReaderException("Chưa kết nối với đầu đọc thẻ!");
            }

            cm.StopCardEvents();
            cm.StartCardEvents(currentReaderName);
        }

        /// <summary>
        /// detection is stopped
        /// </summary>
        /// <param name="obj"></param>
        public void StopCardDetection(Object obj)
        {
            cm.StopCardEvents();
        }
        
        //TODO: move to mifare classic wrapper
        private bool ReadLicenseOnMifareClassic(LicenseReader licenseobj, out byte[] license)
        {
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
        /// Đọc license thẻ
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="license"></param>
        /// <returns></returns>
        public bool ReadLicense(Object obj, out byte[] license)
        {
            // parse thành đối tượng LicenseReader
            LicenseReader licenseobj = (LicenseReader)obj;
            bool result = false;
            switch (licenseobj.Mode)
            {
                case ACTION_MODE.READ_LICENSE_ON_DESFIRE:
                    result = DesfireAPDUWrapper.Instance.ReadLicense(cm, licenseobj, out license);
                    break;
                default:
                    result = ReadLicenseOnMifareClassic(licenseobj, out license);
                    break;
            }

            return result;

        }

        //TODO move to mifare classic wrapper
        private bool ReadDataOnMifareClassic(ActionObject actionObj, out byte[] data)
        {
         
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
        /// Read data from card
        /// </summary>
        /// <param name="obj">ccongifuration object. It depents on card type</param>
        /// <param name="data">data from card</param>
        /// <returns></returns>
        public bool ReadData(Object obj, out byte[] data)
        {
            bool result = false;
            data = null;
            ActionObject actionObj = (ActionObject)obj;
            switch (actionObj.Mode)
            {
                case ACTION_MODE.READ_PERSON_DATA_ON_DESFIRE:
                    result = DesfireAPDUWrapper.Instance.ReadPersoData(cm, actionObj.Sectors, out data);
                    break;
                case ACTION_MODE.READ_APPLICATION_DATA_ON_DESFIRE:
                   // result = DesfireAPDUWrapper.Instance.ReadApplicationData(cm, actionObj.Sectors, out data);
                    break;
                default:
                    result = ReadDataOnMifareClassic(actionObj, out data);
                    break;

            }

            return result;

        }

        /// <summary>
        /// TODO: move to class for mifare classic card
        /// </summary>
        /// <returns></returns>
        private bool WriteDataToMifareClassic(Dictionary<byte, byte[]> dic_sector, byte[] data, ACTION_MODE mode)
        {
            bool result = false;
            int offset = 0;
            foreach (KeyValuePair<byte, byte[]> item in dic_sector)
            {
                //prepare data for writing on sector
               
                
                byte sector = item.Key;
                byte[] sector_data = PrepareData4WriteOnSector(data, sector, ref offset);
                byte[] KeyB = item.Value;
                result = WriteDataOnSector(sector, KeyB, sector_data, mode);

                if (result)
                    continue;
                else
                    return result;
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
            ActionObject writeObj = (ActionObject)Obj;

            switch (writeObj.Mode)
            {
                case ACTION_MODE.CLEAR_PERSO_ON_DESFIRE:
                    result = DesfireAPDUWrapper.Instance.ClearPersoData(cm, writeObj.Sectors);
                    break;

                case ACTION_MODE.CLEAR_APPLICATION_ON_DESFIRE:
                    //result = DesfireAPDUWrapper.Instance.ClearApplicationData(cm, writeObj.Sectors);
                    break;
                case ACTION_MODE.CLEAR_ALL_APPLICATION_ON_DESFIRE:
                    result = DesfireAPDUWrapper.Instance.ClearTheAllApplication(cm, writeObj.Sectors);
                    break;
                
                case ACTION_MODE.WRITE_APP_DATA_TO_DESFIRE:
                    //result = DesfireAPDUWrapper.Instance.WriteApplicationData(cm, writeObj.Sectors, data);
                    break;
                case ACTION_MODE.WRITE_PERSO_DATA_TO_DESFIRE:
                    result = DesfireAPDUWrapper.Instance.WritePersoData(cm, writeObj.Sectors, data);
                    break;
                default:
                    result = WriteDataToMifareClassic(writeObj.Sectors, data, writeObj.Mode);
                    break;
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

        /// <summary>
        /// write license data 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="headerData"></param>
        /// <returns></returns>
        public bool WriteLicense(Object obj, byte[] licensedata)
        {
            
            ActionObject licenseObj = (ActionObject)obj;
            bool result = false;
            switch (licenseObj.Mode)
            {
                case ACTION_MODE.WRITE_SWT_LICENSE_TO_DESFIRE:
                    result = DesfireAPDUWrapper.Instance.WriteApplicationSWTLicense(cm, licenseObj.Sectors, licensedata);
                    break;
                case ACTION_MODE.WRITE_PARTNER_LICENSE_TO_DESFIRE:
                    result = DesfireAPDUWrapper.Instance.WriteApplicationPartnerLicense(cm, licenseObj.Sectors, licensedata);
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// read header data
        /// </summary>
        /// <param name="headerData"></param>
        /// <returns></returns>
        public bool ReadHeader(Object obj, out byte[] headerData)
        {
            HeaderObject headerObj = (HeaderObject)obj;
            bool result = false;
            switch (headerObj.Mode)
            {
                case ACTION_MODE.READ_HEADER_DATA_ON_DESFIRE:
                    headerData = null;
                    result = DesfireAPDUWrapper.Instance.HasPartner(cm);
                    break;
                default:
                    result = ReadDataOnSectorUsingKeyDefault(headerObj.Sector, out headerData);
                    break; 
            }
            return result;
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

        /*
        public String DeleteFile(byte fid)
        {
            if (DesfireAPDUWrapper.Instance.DeleteFile(cm, fid))
                return "OKIE";

            return "FAILED";
        }
         */


        public String Authentication(byte[] aid)
        {
            bool result = DesfireAPDUWrapper.Instance.Authentication(cm, 0x00);

            if (result)
                return "OKIE";

            return "FAILED";
        }

        #region Testing only
        

        public bool CreateApplication(byte[] aid, byte setting)
        {
            return DesfireAPDUWrapper.Instance. CreateApplication(cm, aid, setting, 0x01);

        }

        public String GetApplication()
        {
            byte[] data = DesfireAPDUWrapper.Instance.GetApplicationIDs(cm);
            return StringUtils.ByteArrayToHexString(data);
        }
        public String SelectApplication(byte[] aid)
        {
            byte[] result = new byte[2];
            APDUCommand cmd = new APDUCommand(0x90, 0x5A, 0x00, 0x00, aid, 0x00);
            APDUResponse respond = cm.TransmitDesFire(cmd);
            try
            {
                result[0] = respond.SW1;
                result[1] = respond.SW2;
                if (respond.Status == 37120)
                    return StringUtils.ByteArrayToHexString(respond.Data);
                
            }
            catch (Exception ex)
            {

            }

            return StringUtils.ByteArrayToHexString(result);
        }

        public String CreateFile(byte fid, int size)
        {
            byte com_setting = 0x00;
            byte[] access_right = { 0xEE, 0xEE };
            byte[] temp = BitConverter.GetBytes(size);
            //byte[] file_size = new byte[] { temp[2], temp[1], temp[0] };
            byte[] file_size = new byte[] { temp[0], temp[1], temp[2] };
            bool result = DesfireAPDUWrapper.Instance.CreadStandardDataFile(cm, fid, com_setting, access_right, file_size);
            if (result)
                return "OKIE";

            return "FAILED";

        }

        public String GetAID()
        {
            byte[] data = DesfireAPDUWrapper.Instance.GetApplicationIDs(cm);
            if (null != data)
                return StringUtils.ByteArrayToHexString(data);

            return "NULL DATA";
        }


        public String ReadFile(byte fid, int size)
        {
            byte[] offset = { 0x00, 0x00, 0x00 };

            byte[] data = DesfireAPDUWrapper.Instance.ReadData(cm, fid, offset, size);

            if (null != data)
                return StringUtils.ByteArrayToHexString(data);

            return "NULL DATA";
        }

        public byte[] GetFID()
        {
            byte[] data = null;
            APDUCommand cmd = new APDUCommand(0x90, 0x6F, 0x00, 0x00, null, 0x00);
            APDUResponse respond = cm.TransmitDesFire(cmd);
            try
            {
                if (respond.Status == 37120)
                {
                    data = new byte[respond.Data.Length];
                    Array.Copy(respond.Data, data, respond.Data.Length);
                }
            }
            catch (Exception ex)
            {
            }

            return data;
        }

        public String GetKeySetting()
        {
            byte[] data = null;// DesfireAPDUWrapper.Instance.GetKeySetting(cm);
            if (null != data)
                return StringUtils.ByteArrayToHexString(data);

            return "NULL DATA";
        }
        public String GetKeyVersion(byte key)
        {
            byte[] data = null;// DesfireAPDUWrapper.Instance.GetKeyVersion(cm, key);
            if (null != data)
                return StringUtils.ByteArrayToHexString(data);

            return "NULL DATA";
        }

        public String SelectFile(byte[] fid)
        {
            byte[] data = null;//DesfireAPDUWrapper.Instance.SelectFile(cm, fid);
            if (null != data)
                return StringUtils.ByteArrayToHexString(data);

            return "NULL DATA";
        }

        public String GetFileSetting(byte fid)
        {
            byte[] data = null;
            APDUCommand cmd = new APDUCommand(0x90, 0xF5, 0x00, 0x00, null, 0x00);
            cmd.Data = new byte[1];
            cmd.Data[0] = fid;
            APDUResponse respond = cm.TransmitDesFire(cmd);
            try
            {
                if (respond.Status == 37120)
                {
                    data = new byte[respond.Data.Length];
                    Array.Copy(respond.Data, data, respond.Data.Length);
                }
            }
            catch (Exception ex)
            {
            }
            if (null != data)
                return StringUtils.ByteArrayToHexString(data);

            return "NULL DATA";
        }

        public String FormatPICC()
        {
            byte[] data = null;// DesfireAPDUWrapper.Instance.FormatPICC(cm);
            if (null != data)
                return StringUtils.ByteArrayToHexString(data);

            return "NULL DATA";
        }

      
        public String GetSettingAppMasterKey(byte[] aid)
        {
            byte[] data = null;// DesfireAPDUWrapper.Instance.GetSettingAppMasterKey(cm, aid);
            if (null != data)
                return StringUtils.ByteArrayToHexString(data);

            return "NULL DATA";
        }

        public bool WriteDataTeset(byte fino, byte[] data)
        {
            APDUCommand CMD_WRITE_DATA = new APDUCommand(0x90, 0x3D, 0x00, 0x00, null, 0x00);
            APDUCommand CMD_ADDITIONAL_FRAME = new APDUCommand(0x90, 0xAF, 0x00, 0x00, null, 0x00);
            byte[] offset = new byte[] { 0x00, 0x00, 0x00 };
            
            byte[] temp = BitConverter.GetBytes(data.Length);
            byte[] length = new byte[] { temp[0], temp[1], temp[2] };

            int BLOCK_SIZE = 32;
            int nextOffSet = data.Length - BLOCK_SIZE;
            int datalength = data.Length;
            if (nextOffSet > BLOCK_SIZE)
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

            index = datalength;
            APDUResponse respond = cm.TransmitDesFire(CMD_WRITE_DATA);
            while (respond.SW1 == DesfireErrorCode.DESFIRE_RESULT && respond.SW2 == DesfireErrorCode.ADDITIONAL_FRAME && nextOffSet > 0)
            {
                if (nextOffSet > 59)
                {
                    CMD_ADDITIONAL_FRAME.Data = new byte[59];
                    Array.Copy(data, index, CMD_ADDITIONAL_FRAME.Data, 0, 59);
                    nextOffSet -= 59;
                    index += 59;
                }
                else
                {
                    CMD_ADDITIONAL_FRAME.Data = new byte[nextOffSet];
                    Array.Copy(data, index, CMD_ADDITIONAL_FRAME.Data, 0, nextOffSet);
                    index += nextOffSet;
                }
                respond = cm.TransmitDesFire(CMD_ADDITIONAL_FRAME);
            }

            if (respond.SW1 == DesfireErrorCode.DESFIRE_RESULT && respond.SW2 == DesfireErrorCode.ADDITIONAL_FRAME)
                return true;

            return false;
        }


        public String ReadDataTest(byte[] aid, byte fid, int size)
        {
            ActionObject obj = new ActionObject(null, ACTION_MODE.READ_LICENSE_ON_DESFIRE);
            LicenseReader licenseReader = new LicenseReader(1, 0, 0);
            byte[] data;

            DesfireAPDUWrapper.Instance.ReadLicense(cm, licenseReader, out data);

            String result = data.Length + "- " + StringUtils.ByteArrayToHexString(data);
            return result;

        }

        #endregion

        public void SetFreesParking()
        {
            DesfireAPDUWrapper.Instance.SetFreesParking(cm);
        }
    }
}