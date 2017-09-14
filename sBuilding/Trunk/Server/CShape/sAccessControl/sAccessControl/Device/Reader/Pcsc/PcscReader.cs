using System.Threading;
using sAccessControl.Enums;
using System;

namespace sAccessControl.Device.Reader.Pcsc
{
    /// <summary>
    /// Lớp hiện thực cho các đầu đọc hỗ trợ PC/SC
    /// </summary>
    internal class PcscReader : IReader
    {
        #region Private properties

        private CardManager cm = new CardManager();
        private readonly APDUCommand CommandGetUid = new APDUCommand(0xFF, 0xCA, 0x00, 0x00, null, 0x04);
        private readonly APDUCommand CommandDisableBuzzer = new APDUCommand(0xFF, 0x00, 0x52, 0x00, null, 0x00);
        private readonly APDUCommand CommandEnableBuzzer = new APDUCommand(0xFF, 0x00, 0x52, 0xFF, null, 0x00);
        private readonly APDUCommand CommandBeep = new APDUCommand(0xFF, 0x00, 0x40, 0xCF, new byte[] { 0x02, 0x00, 0x01, 0x01 }, 0x04);
        private APDUResponse respond = null;

        private byte readerOrderNumber;
        private string readerAlias = null;

        private bool isBuzzerDisabled = false;
        private bool isBeepOnTagDetected = false;

        private const ushort SuccessCode = 36864;   // 0x9000
        private const ushort FailedCode = 25344;    // 0x6300

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

        #region Public constructor

        public PcscReader(byte readerOrderNumber, bool beepOnTag)
        {
            this.readerOrderNumber = readerOrderNumber;
            this.isBeepOnTagDetected = beepOnTag;

            cm.CardInserted += cm_CardInserted;
            cm.ReaderUnplugged += cm_ReaderUnplugged;
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
        public event TagDetectedHandler TagDetected;

        #endregion

        #region IReader methods

        public bool Connect()
        {
            // Disconnect if connected
            Disconnect();

            // Liệt kê danh sách các reader được kết nối với máy tính. 
            // Mỗi reader được định danh bằng: <reader-name> <order-number>. 
            // Ví dụ: SCM Microsystems Inc. SCL011G Contactless Reader 0
            string[] listAliases;
            try
            {
                listAliases = cm.ListReaders();
            }
            catch (SmartCardException ex)
            {
                throw new ReaderException(ex.Message);
            }

            // Nếu có đầu đọc kết nối đến máy tính, listReaders sẽ không null
            if (listAliases == null)
            {
                return false;
            }

            string orderNumberStr = readerOrderNumber.ToString();

            // Duyệt tuần tự từng alias & kiểm tra xem có đầu đọc đã đăng ký không
            foreach (string alias in listAliases)
            {
                if (alias.Substring(alias.Length - 1).Equals(orderNumberStr))
                {
                    this.readerAlias = alias;
                    return true;
                }
            }

            return false;
        }

        public void Disconnect()
        {
            try
            {
                cm.Disconnect(DISCONNECT.UNPOWER);
                cm.StopCardEvents();
            }
            catch (SmartCardException ex)
            {
                throw new ReaderException(ex.Message);
            }
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

        public void StartCardDetection()
        {
            if (readerAlias == null)
            {
                throw new ReaderException("Chưa kết nối với đầu đọc thẻ!");
            }

            cm.StopCardEvents();
            cm.StartCardEvents(readerAlias);
        }

        public void StopCardDetection()
        {
            cm.StopCardEvents();
        }

        public void ChangeReaderAddress(byte newAddress)
        {
            this.readerOrderNumber = newAddress;
        }

        #endregion

        #region Private methods

        public bool ReadLicense(byte start, byte stop, out byte[] license)
        {
            license = new byte[MifareClassicParams.LICENSE_LENGTH];
            int offset = 0;
            byte[] temp = null;

            for (byte s = start; s <= stop; s++)
            {
                if (!AuthenticateDefault(s))
                {
                    return false;
                }
                if (!ReadSector(s, out temp))
                {
                    return false;
                }

                if (s == 0 || s == 6)
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

        public bool Authenticate(byte sector, bool isKeyA, byte[] key)
        {
            // Check key length
            if (key.Length != 6)
            {
                throw new SmartCardException(ScErrorCodes.INVALID_ARGUMENT, "key length");
            }

            // Get block numbers of sector
            byte[] blockNumbers = GetBlockNumbersOfSector(sector);

            // Load key to reader at position 0x00
            CMD_LOAD_KEY.Data= key;
            try
            {
                RESPONSE = cm.Transmit(CMD_LOAD_KEY);
            }
            catch (SmartCardException)
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
            catch (SmartCardException)
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
            catch (SmartCardException)
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

        private void cm_CardInserted()
        {
            try
            {
                cm.Connect(readerAlias, SHARE_MODE.SHARED, PROTOCOL.T0_OR_T1);

                if (!isBuzzerDisabled)
                {
                    /* Tắt tính năng tự động phát âm báo hiệu khi đưa thẻ vào đầu đọc
                     * vì người dùng có thể nhầm tưởng là chương trình đã xử lý xong
                     * và đưa thẻ ra khỏi đầu đọc trước khi chương trình đọc được UID.
                     * 
                     * Sau khi đọc được mã thẻ & xử lý xong, chương trình sẽ chủ động
                     * gởi yêu cầu phát âm báo hiệu đến đầu đọc.
                     */
                    //DisableAutomaticBuzzer();
                }

                respond = cm.Transmit(CommandGetUid);
            }
            catch (SmartCardException)
            {
                return;
            }

            if (respond.Status == SuccessCode)
            {
                if (respond.Data != null && respond.Data.Length == 4)
                {
                    if (TagDetected != null)
                    {
                        // Notify
                        if (isBeepOnTagDetected)
                        {
                            Beep(1);
                        }

                        // Raise event
                        TagDetected(respond.Data);
                    }
                }
            }
        }

        private void cm_ReaderUnplugged()
        {
            if (Disconnected != null)
            {
                Disconnected();
            }
        }

        private void DisableAutomaticBuzzer()
        {
            try
            {
                respond = cm.Transmit(CommandDisableBuzzer);
            }
            catch (SmartCardException)
            {
                return;
            }

            if (respond.Status == SuccessCode)
            {
                isBuzzerDisabled = true;
            }
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
                throw new SmartCardException(ScErrorCodes.OUT_OF_SECTOR, sector.ToString());
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
                throw new SmartCardException(ScErrorCodes.OUT_OF_SECTOR, sector.ToString());
            }
        }

        #endregion
    }
}