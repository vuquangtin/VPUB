using System;
using System.Collections.Generic;
using System.Text;
using CommonHelper.Utils;
using ReaderManager.Model;
using ReaderLibrary;
using sWorldModel.TransportData;
using System.Threading;

namespace ReaderManager.Pcsc
{
    public class PcscReaderNew : IReader
    {

        #region private properties

        private CardManager cm = new CardManager();
        private string currentReaderAlias;
        private bool runReaderDetectionLoop = false;

        private APDUCommand CMD_LOAD_KEY = new APDUCommand(0xFF, 0x82, 0x00, 0x00, null, 0x06);
        private APDUCommand CMD_AUTH = new APDUCommand(0xFF, 0x86, 0x00, 0x00, null, 0x05);
        private APDUCommand CMD_READ_BLOCK = new APDUCommand(0xFF, 0xB0, 0x00, 0x00, null, 0x10);
        private APDUCommand CMD_WRITE_BLOCK = new APDUCommand(0xFF, 0xD6, 0x00, 0x00, null, 0x10);
        private readonly APDUCommand CommandGetUid = new APDUCommand(0xFF, 0xCA, 0x00, 0x00, null, 0x04);
        private readonly APDUCommand CommandDisableBuzzer = new APDUCommand(0xFF, 0x00, 0x52, 0x00, null, 0x00);
        private readonly APDUCommand CommandEnableBuzzer = new APDUCommand(0xFF, 0x00, 0x52, 0xFF, null, 0x00);
        private readonly APDUCommand CommandBeep = new APDUCommand(0xFF, 0x00, 0x40, 0xCF, new byte[] { 0x02, 0x00, 0x01, 0x01 }, 0x04);
        private APDUResponse respond = null;


        private readonly byte[] DEFAULT_KEY = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        private readonly byte[] DEFAULT_ACCESS_CONDITION = new byte[] { 0xFF, 0x07, 0x80, 0x69 };
        private readonly byte[] SCAMPUS_ACCESS_CONDITION = new byte[] { 0x78, 0x77, 0x88, 0x69 };

        private byte readerOrderNumber;
        private string readerAlias = null;

        private bool isBuzzerDisabled = false;
        private bool isBeepOnTagDetected = false;

        public event TagDetectedEventHandler TagDetected;
        public event EventHandler TagRemoved;
        public event EventHandler ReaderUnplugged;
        public event EventHandler ReaderPlugged;
        public event EventHandler ReaderNotPresent;


        private const ushort SuccessCode = 36864;   // 0x9000
        private const ushort FailedCode = 25344;    // 0x6300


        #endregion

        #region constructor

        public PcscReaderNew(byte readerOrderNumber, bool beepOnTag)
        {
            this.readerOrderNumber = readerOrderNumber;
            this.isBeepOnTagDetected = beepOnTag;

        }

        #endregion

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

        #region IReader events

        public event DisconnectedHandler Disconnected;

        #endregion

        #region IReader methods

        public List<string> findAllCardReader()
        {
            return new List<string>(cm.ListReaders());
        }

        public bool Connect(Object obj)
        {
            // Disconnect if connected
            string name = (string)obj;
            Disconnect(null);


            // Liệt kê danh sách các reader được kết nối với máy tính. 
            // Mỗi reader được định danh bằng: <reader-name> <order-number>. 
            // Ví dụ: SCM Microsystems Inc. SCL011G Contactless Reader 0
            List<string> listreaders = findAllCardReader();

            // Nếu có đầu đọc kết nối đến máy tính, listReaders sẽ không null
            if (listreaders.Count > 0 && listreaders.Contains(name))
            {
                readerAlias = name;
                return true;
            }

            return false;
        }

        public void Disconnect(Object obj)
        {
            try
            {
                cm.Disconnect(DISCONNECT.UNPOWER);
                cm.StopCardEvents();
                readerAlias = null;
            }
            catch (SmartCardException ex)
            {
                throw new ReaderException(ex.Message);
            }
        }

        public bool AlertSignalOnTagDetected(Object obj)
        {
            byte numRepeat = (bool)obj ? (byte)1 : (byte)2;
            Beep(numRepeat);
            return true;
        }

        public void Beep(byte numRepeat)
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

        public void StartCardDetection(Object obj)
        {
            if (readerAlias == null)
            {
                throw new ReaderException("Chưa kết nối với đầu đọc thẻ!");
            }

            cm.StopCardEvents();
            cm.StartCardEvents(readerAlias);
        }

        public void StopCardDetection(Object obj)
        {
            cm.StopCardEvents();
        }

        /// <summary>
        /// Đọc license thẻ
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="license"></param>
        /// <returns></returns>
        public bool ReadLicense(Object Obj, out byte[] License)
        {
            // parse thành đối tượng LicenseReader
            int LicenseType = ((LicenseReader)Obj).CurrentLicense;

            License = new byte[MifareClassicParams.LICENSE_LENGTH];
            int offset = 0;
            byte[] temp = null;

            for (byte s = ((LicenseReader)Obj).Start; s <= ((LicenseReader)Obj).Stop; s++)
            {
                if (!Authenticate(new AuthenticateKey(s, false, DEFAULT_KEY)))
                {
                    return false;
                }
                if (!ReadSector(s, out temp))
                {
                    return false;
                }

                // Kiểm tra License đang gọi là license nào và so sánh sector == 0 hoặc == 6
                if (s == (LicenseType == LicenseReader.SWT ? 0 : 6))
                {
                    // 16 byte đầu tiên của sector 0 chứa dữ liệu NSX
                    Array.Copy(temp, (LicenseType == LicenseReader.SWT ? 16 : 0), License, offset, 32);
                    offset += 32;
                }
                else
                {
                    Array.Copy(temp, 0, License, offset, 48);
                    offset += 48;
                }
            }
            return true;
        }

        /// <summary>
        /// Write byte data to card
        /// </summary>
        /// <param name="Obj">congifuration object. It depents on card type
        ///                   Obj.Sector: not null
        ///                   Obj.IsKeyA: not null
        ///                   Obj.Key: có thể null</param>
        /// <param name="sectorData">data is writed on card</param>
        /// <returns></returns>
        public bool WriteByteData(Object Obj, byte[] data)
        {
            bool CheckWriteKey = false;
            //Parse Obj thành AuthenticateKey
            // nếu write data với key default, thêm Key defaulf cho Obj
            if (null == ((AuthenticateKey)Obj).Key)
            {
                ((AuthenticateKey)Obj).Key = DEFAULT_KEY;

                // Login with sector key 
                //
                if (!Authenticate(Obj))
                {
                    return false;
                }

                // Read sector data
                if (!WriteSector(((AuthenticateKey)Obj).Sector, data))
                {
                    return false;
                }

                // Write key 
                if (((AuthenticateKey)Obj).Key != DEFAULT_KEY)
                {
                    CheckWriteKey = ((AuthenticateKey)Obj).IsKeyA ? WriteKeyA(((AuthenticateKey)Obj).Sector, ((AuthenticateKey)Obj).Key) : WriteKeyB(((AuthenticateKey)Obj).Sector, ((AuthenticateKey)Obj).Key);
                    if (!CheckWriteKey)
                        return false;
                }
                return true;

            }

            return true;
        }

        /// <summary>
        /// Write string data to card
        /// </summary>
        /// <param name="obj">congifuration object. It depents on card type</param>
        /// <param name="Data">data is writed to card (string)</param>
        /// <returns></returns>
        public bool WriteStringData(Object Obj, string Data)
        {
            // Parse Obj thành Obj ListKey

            int offset = 0;
            Dictionary<byte, SectorKeyPairDTO> keyPairList = CreateDic(((ListKey)Obj).KeyList);
            for (byte Sector = ((ListKey)Obj).SectorStart; Sector <= ((ListKey)Obj).SectorStop; Sector++)
            {
                byte[] SectorData = GetDataWriteToSector(Data, Sector, ref offset);
                byte[] KeyA = StringUtils.HexStringToByteArray(keyPairList[Sector].KeyA);
                byte[] KeyB = StringUtils.HexStringToByteArray(keyPairList[Sector].KeyB);

                AuthenticateKey KeyObj = new AuthenticateKey();
                KeyObj.Sector = Sector;

                // Kiểm tra là KeyB
                KeyObj.Key = KeyB;                
                bool result = WriteByteData(KeyObj, SectorData);
                if (result)
                    continue;

                // Kiểm tra là KeyA
                KeyObj.Key = KeyA;
                KeyObj.IsKeyA = true;
                result = WriteByteData(KeyObj, SectorData);
                if (result)
                    continue;
            }

            return true;
        }

        /// <summary>
        /// Authenticate 
        /// </summary>
        /// <param name="Obj">congifuration object. It depents on card type</param>
        /// <returns>true - It's okie</returns>
        public bool Authenticate(Object Obj)
        {
            // Check key length
            if (((AuthenticateKey)Obj).Key.Length != 6)
            {
                throw new SmartCardException(ScErrorCodes.INVALID_ARGUMENT, "key length");
            }

            // Get block numbers of sector
            byte[] blockNumbers = GetBlockNumbersOfSector(((AuthenticateKey)Obj).Sector);

            // Load key to reader at position 0x00
            CMD_LOAD_KEY.Data = ((AuthenticateKey)Obj).Key;
            try
            {
                respond = cm.Transmit(CMD_LOAD_KEY);
            }
            catch (SmartCardException)
            {
                return false;
            }
            if (respond.Status != SuccessCode)
            {
                return false;
            }

            // Authenticate with card using key at position 0x00
            byte[] authDataBytes = new byte[] { 0x01, 0x00, blockNumbers[0], (byte)(((AuthenticateKey)Obj).IsKeyA ? 0x60 : 0x61), 0x00 };
            CMD_AUTH.Data = authDataBytes;
            respond = cm.Transmit(CMD_AUTH);
            try
            {
                return respond.Status == SuccessCode;
            }
            catch (SmartCardException)
            {
                return false;
            }
            //return false;
        }

        /// <summary>
        /// Is it swt card
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsSwtCard(Object obj)
        {
            //TODO implement
            return false;
        }

        /// <summary>
        /// read header data
        /// </summary>
        /// <param name="headerData"></param>
        /// <returns></returns>
        public bool ReadHeader(Object obj, out byte[] headerData)
        {
            //TODO implement
            headerData = new byte[10];
            return false;
        }

        public bool GetSerialNumber(Object obj, out string uid)
        {
            uid = null;
            try
            {
                respond = cm.Transmit(CommandGetUid);
                if (respond.Status == SuccessCode && respond.Data != null && respond.Data.Length == 4)
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

        #endregion

        #region Utilities

        #region Read Sector

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
            return respond.Status == SuccessCode;
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

        #endregion

        #region Write Sector

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
            return respond.Status == SuccessCode;
        }

        public bool WriteSector(byte sector, byte[] sectorData)
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

        #endregion

        #region Write Key

        public bool WriteSectorKeys(byte sector, byte[] newKeyA, byte[] newKeyB, byte[] accessCondition)
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

        public bool WriteDataKeys(byte sector, byte[] newKeyA, byte[] newKeyB)
        {
            return WriteSectorKeys(sector, newKeyA, newKeyB, SCAMPUS_ACCESS_CONDITION);
        }

        public bool WriteKeyA(byte sector, byte[] newKeyA)
        {
            return WriteSectorKeys(sector, newKeyA, DEFAULT_KEY, SCAMPUS_ACCESS_CONDITION);
        }

        public bool WriteKeyB(byte sector, byte[] newKeyB)
        {
            return WriteSectorKeys(sector, DEFAULT_KEY, newKeyB, SCAMPUS_ACCESS_CONDITION);
        }

        public bool WriteDefaultKeys(byte sector)
        {
            return WriteSectorKeys(sector, DEFAULT_KEY, DEFAULT_KEY, DEFAULT_ACCESS_CONDITION);
        }

        #endregion


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

        //Hàm chuyển đổi dữ liệu để ghi vào thẻ
        private byte[] GetDataWriteToSector(string dataStr, byte sector, ref int offset)
        {
            byte[] sectorData = null;
            //lấy dung lượng byte của sector
            int sectorSize = MifareClassicParams.DetermineDataSectorCapacity(sector);

            byte[] data = string.IsNullOrEmpty(dataStr)
                //nếu dữ liệu ghi là null hoặc trống thì data rỗng
                ? new byte[sectorSize]
                : (sector <= MifareClassicParams.HEADER_POSITION
                //check xem có phải header sector không
                        ? StringUtils.HexStringToByteArray(dataStr)
                        : StringUtils.GetBytes(dataStr));
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

        #endregion

        #region Hàm kết nối đầu đọc, đọc thông tin 

        event TagDetectedHandler IReader.TagDetected
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        public void ConnectToReader(string readerAlias)
        {
            this.currentReaderAlias = readerAlias;
            Thread th = new Thread(() =>
            {
                runReaderDetectionLoop = true;
                int sleepDuration = 1000;
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
                    string[] listReaders = cm.ListReaders();

                    // Nếu có đầu đọc kết nối đến máy tính, listReaders sẽ không null
                    if (listReaders != null)
                    {
                        foreach (string reader in listReaders)
                        {
                            // Kiểm tra có là đầu đọc đã đăng ký hay không
                            if (reader.CompareTo(this.currentReaderAlias) == 0)
                            {
                                // Kết nối đến đầu đọc
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
                        }
                    }
                    Thread.Sleep(sleepDuration);
                }
            });
            th.Start();
        }


        private bool ConnectToReader()
        {
            if (currentReaderAlias == null)
            {
                throw new ScException(ScErrorCodes.INVALID_ARGUMENT, "readerAlias");
            }
            try
            {
                cm.StopCardEvents();
                cm.StartCardEvents(currentReaderAlias);
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


        public void DisconnectFromReader()
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
                currentReaderAlias = null;
            }
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

    }
}
