using ReaderLibrary.PcscLib;
using System;
using System.Threading;
using ReaderManager;

namespace ReaderLibrary
{
    public class PcscReader : IReader
    {
        #region Private Properties

        private CardManager cm = new CardManager();
        private string currentReaderAlias;
        private bool runReaderDetectionLoop = false;

        private APDUCommand CMD_GET_UID = new APDUCommand(0xFF, 0xCA, 0x00, 0x00, null, 0x04);
        private APDUCommand CMD_LOAD_KEY = new APDUCommand(0xFF, 0x82, 0x00, 0x00, null, 0x06);
        private APDUCommand CMD_AUTH = new APDUCommand(0xFF, 0x86, 0x00, 0x00, null, 0x05);
        private APDUCommand CMD_READ_BLOCK = new APDUCommand(0xFF, 0xB0, 0x00, 0x00, null, 0x10);
        private APDUCommand CMD_WRITE_BLOCK = new APDUCommand(0xFF, 0xD6, 0x00, 0x00, null, 0x10);
        private readonly APDUCommand CMD_DISABLE_BUZZER = new APDUCommand(0xFF, 0x00, 0x52, 0x00, null, 0x00);
        private readonly APDUCommand CMD_ENABLE_BUZZER = new APDUCommand(0xFF, 0x00, 0x52, 0xFF, null, 0x00);
        private readonly APDUCommand CMD_BEEP = new APDUCommand(0xFF, 0x00, 0x40, 0xCF, new byte[] { 0x02, 0x00, 0x01, 0x01 }, 0x04);

        private APDUResponse RESPONSE = null;

        private readonly byte[] DEFAULT_KEY = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
        private readonly byte[] DEFAULT_ACCESS_CONDITION = new byte[] { 0xFF, 0x07, 0x80, 0x69 };
        private readonly byte[] SCAMPUS_ACCESS_CONDITION = new byte[] { 0x78, 0x77, 0x88, 0x69 };

        private const int SCODE_SUCESS = 0x9000;

        #endregion

        #region Public Properties

        public byte[] DefaultKey
        {
            get { return (byte[])DEFAULT_KEY.Clone(); }
        }

        #endregion

        #region Events

        public event TagDetectedEventHandler TagDetected;
        public event EventHandler TagRemoved;
        public event EventHandler ReaderUnplugged;
        public event EventHandler ReaderPlugged;
        public event EventHandler ReaderNotPresent;

        #endregion

        #region Public (basic) methods

        public string[] ListReaders()
        {
            return cm.ListReaders();
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

        public bool Authenticate(byte sector, bool isKeyA, byte[] key)
        {
            // Check key length
            if (key.Length != 6)
            {
                throw new ScException(ScErrorCodes.INVALID_ARGUMENT, "key length");
            }

            // Get block numbers of sector
            byte[] blockNumbers = GetBlockNumbersOfSector(sector);

            // Load key to reader at position 0x00
            CMD_LOAD_KEY.Data = key;
            try
            {
                RESPONSE = cm.Transmit(CMD_LOAD_KEY);
            }
            catch (ScException)
            {
                return false;
            }
            if (RESPONSE.Status != SCODE_SUCESS)
            {
                return false;
            }

            // Authenticate with card using key at position 0x00
            byte[] authDataBytes = new byte[] { 0x01, 0x00, blockNumbers[0], (byte)(isKeyA ? 0x60 : 0x61), 0x00 };
            CMD_AUTH.Data = authDataBytes;
            RESPONSE = cm.Transmit(CMD_AUTH);
            try
            {
                return RESPONSE.Status == SCODE_SUCESS;
            }
            catch (ScException)
            {
                return false;
            }
        }

        public bool AuthenticateDefaultKeyB(byte sector)
        {
            return Authenticate(sector, false, DEFAULT_KEY);
        }
        public bool AuthenticateDefault(byte sector)
        {
            return Authenticate(sector, true, DEFAULT_KEY);
        }

        public bool ReadBlock(byte block, out byte[] blockData)
        {
            // P2 is block number to be accessed
            CMD_READ_BLOCK.P2 = block;

            try
            {
                RESPONSE = cm.Transmit(CMD_READ_BLOCK);
            }
            catch (ScException)
            {
                blockData = null;
                return false;
            }
            blockData = RESPONSE.Data;
            return RESPONSE.Status == SCODE_SUCESS;
        }

        /// <summary>
        /// Read data block of sector (not trailer block)
        /// </summary>
        public bool ReadSector(byte sector, out byte[] sectorData)
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
                    Array.Copy(RESPONSE.Data, 0, sectorData, j * MifareClassicParams.BLOCK_SIZE, MifareClassicParams.BLOCK_SIZE);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool WriteBlock(byte block, byte[] blockData)
        {
            // Check if data length is greater than block size
            if (blockData.Length > MifareClassicParams.BLOCK_SIZE)
            {
                throw new ScException(ScErrorCodes.INVALID_ARGUMENT, "blockData");
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
                RESPONSE = cm.Transmit(CMD_WRITE_BLOCK);
            }
            catch (ScException)
            {
                return false;
            }
            return RESPONSE.Status == SCODE_SUCESS;
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

        #region Public (advanced) methods

        public bool ReadLicense(byte start, byte top, out byte[] license)
        {
            license = new byte[MifareClassicParams.LICENSE_LENGTH];
            int offset = 0;
            byte[] temp = null;

            for (byte s = start; s <= top; s++)
            {
                if (!AuthenticateDefault(s))
                {
                    return false;
                }
                if (!ReadSector(s, out temp))
                {
                    return false;
                }

                if (s == 0)
                {
                    // 16 byte đầu tiên của sector 0 chứa dữ liệu NSX
                    Array.Copy(temp, 16, license, offset, 32);
                    offset += 32;
                }
                else
                {
                    Array.Copy(temp, 0, license, offset, 48);
                    offset += 48;
                }
            }
            return true;
        }

        public bool ReadLicensePartner(byte start, byte top, out byte[] license)
        {
            license = new byte[MifareClassicParams.LICENSE_LENGTH];
            int offset = 0;
            byte[] temp = null;

            for (byte s = start; s <= top; s++)
            {
                if (!AuthenticateDefault(s))
                {
                    return false;
                }
                if (!ReadSector(s, out temp))
                {
                    return false;
                }

                if (s == 6)
                {
                    Array.Copy(temp, 0, license, offset, 32);
                    offset += 32;
                }
                else
                {
                    Array.Copy(temp, 0, license, offset, 48);
                    offset += 48;
                }
            }
            return true;
        }

        public bool IsSwtCard(byte[] firstSectorKeyA)
        {
            return Authenticate(0, true, firstSectorKeyA);
        }

        public bool ReadHeader(out byte[] headerData)
        {
            return ReadSector(MifareClassicParams.HEADER_POSITION, out headerData);
        }

        public bool WriteHeader(byte[] headerData)
        {
            return WriteSector(MifareClassicParams.HEADER_POSITION, headerData);
        }

        public bool WriteSectorKeys(byte sector, byte[] newKeyA, byte[] newKeyB, byte[] accessCondition)
        {
            if (newKeyA == null || newKeyA.Length != 6)
            {
                throw new ScException(ScErrorCodes.INVALID_ARGUMENT, "newKeyA");
            }
            if (newKeyB == null || newKeyB.Length != 6)
            {
                throw new ScException(ScErrorCodes.INVALID_ARGUMENT, "newKeyB");
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

        public bool WriteHeaderKeyB(byte sector, byte[] newKeyB)
        {
            return WriteSectorKeys(sector, DEFAULT_KEY, newKeyB, SCAMPUS_ACCESS_CONDITION);
        }

        public bool WriteDefaultKeys(byte sector)
        {
            return WriteSectorKeys(sector, DEFAULT_KEY, DEFAULT_KEY, DEFAULT_ACCESS_CONDITION);
        }

        public bool ClearSectorData(byte sector)
        {
            byte[] zeroData = new byte[48];
            return WriteSector(sector, zeroData);
        }

        #endregion

        #region Buzzer & LED methods

        public void EnableAutomaticBuzzer(bool enabled)
        {
            APDUCommand cmd = enabled ? CMD_ENABLE_BUZZER : CMD_DISABLE_BUZZER;
            try
            {
                RESPONSE = cm.Transmit(cmd);
            }
            catch (ScException)
            {
                return;
            }
        }

        public void Beep(byte numRepeat)
        {
            try
            {
                while (numRepeat-- > 0)
                {
                    cm.Transmit(CMD_BEEP);
                    Thread.Sleep(150);
                }
            }
            catch (ScException)
            {
                return;
            }
        }

        public void Beep(bool isSucceed)
        {
            byte numRepeat = isSucceed ? (byte)1 : (byte)2;
            Beep(numRepeat);
        }

        #endregion

        #region Private methods

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

        private void SubscribeEvents()
        {
            cm.CardInserted += OnCardInsertedHandler;
            cm.CardRemoved += OnCardRemovedHandler;
            cm.ReaderUnplugged += OnReaderUnpluggedHandler;
        }

        private void UnsubscribeEvents()
        {
            cm.CardInserted -= OnCardInsertedHandler;
            cm.CardRemoved -= OnCardRemovedHandler;
            cm.ReaderUnplugged -= OnReaderUnpluggedHandler;
        }

        private void OnCardRemovedHandler(object sender, EventArgs e)
        {
            if (TagRemoved != null)
            {
                TagRemoved(this, EventArgs.Empty);
            }
        }

        private void OnCardInsertedHandler(short cardType, byte[] serialNumber)
        {
            if (TagDetected != null)
            {
                TagDetected(cardType, serialNumber);
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
                throw new ScException(ScErrorCodes.OUT_OF_SECTOR, sector.ToString());
            }

            byte[] blockNumbers = new byte[blocksPerSector];
            for (byte i = 0; i < blocksPerSector; i++)
            {
                blockNumbers[i] = (byte)(minBlockNumber + i);
            }
            return blockNumbers;
        }

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
                throw new ScException(ScErrorCodes.OUT_OF_SECTOR, sector.ToString());
            }
        }

        #endregion
    }
}