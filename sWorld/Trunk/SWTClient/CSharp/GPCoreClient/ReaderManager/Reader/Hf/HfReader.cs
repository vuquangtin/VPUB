using ParkingProcessComponent.Device.Reader.Hf;
using ReaderManager;
using ReaderManager.Contants;
using ReaderManager.Model;
using ReaderManager.Pcsc;
using sWorldModel.TransportData;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using ReaderLibrary;
using System;
using ReaderManager.Enum;

namespace ReaderManager.Hf
{
   public class HfReader : IReader
    {

        #region Private properties

        private byte readerComPort;
        private byte comAddress = 0;
        private int statusCode = -1;
        private int frmHandle = -1;
        private bool beepOnTagDetected = false;
        private Thread th_CardDetection = null;
        private volatile bool flg_CardDetection = false;
        private static readonly object MultiCallsLob = new object();

        #endregion

        #region Public constructor

        public HfReader()
        {

        }

        /// <summary></summary>
        /// <param name="readerComPort">
        /// Địa chỉ cổng COM mà đầu đọc được gắn vào
        /// </param>
        public HfReader(byte readerComPort, bool beepOnTagDetected)
        {
            this.readerComPort = readerComPort;
            this.beepOnTagDetected = beepOnTagDetected;
        }


        public event DelegateCardDataHandler ReturnCardData
        {
            add
            {

            }
            remove
            {

            }
        }


        #endregion

        #region IReader properties

        public ReaderType Type
        {
            get { return ReaderType.HF; }
        }

        public byte Address
        {
            get
            {
                return this.readerComPort;
            }
        }

        public bool BeepOnTagDetected
        {
            get
            {
                return beepOnTagDetected;
            }
        }

        #endregion

        #region IReader events

        public event DisconnectedHandler Disconnected;
        public event TagDetectedHandler TagDetected;

        #endregion

        #region IReader methods

        public List<string> FindAllCardReader()
        {
            return null;
        }

        public bool Connect(Object obj)
        {
            // Disconnect if connected
            Disconnect(obj);

            // Open COM port

            statusCode = Rr3036Wrapper.OpenComPort(readerComPort, ref comAddress, ref frmHandle);

            //// Cần phải sleep trong 1 khoảng thời gian vì không phải COM port sẽ không mở ngay lập tức
            //Thread.Sleep(ReaderContants.ComPortDelayTime);

            return statusCode == Rr3036Wrapper.OK || statusCode == Rr3036Wrapper.comPortOpened;
        }
      
        public void Disconnect(Object obj)
        {
            StopCardDetection(obj);
            Rr3036Wrapper.CloseSpecComPort(frmHandle);
        }

        public void AlertSignalOnTagDetected(object obj)
        {
            throw new NotImplementedException();
        }

        public void WaittingCard(Object obj)
        {
            throw new NotImplementedException();
        }
     
       public void StartCardDetection(Object obj)
        {
            if (th_CardDetection == null || th_CardDetection.ThreadState == ThreadState.Aborted
                || th_CardDetection.ThreadState == ThreadState.Stopped)
            {
                flg_CardDetection = true;
                th_CardDetection = new Thread(CardDetectionWorker);
                th_CardDetection.Start();
            }
        }

        public void StopCardDetection(Object obj)
        {
            if (th_CardDetection != null)
            {
                int delay = ReaderContants.CardDetectionDelayTime / 2 + 10;
                int timeOut = 10, count = 0;
                bool stopped = false;
                flg_CardDetection = false;

                do
                {
                    if (count > timeOut)
                    {
                        th_CardDetection.Abort();
                        break;
                    }

                    if (th_CardDetection.ThreadState == ThreadState.Aborted)
                    {
                        stopped = true;
                    }

                    if (th_CardDetection.ThreadState == ThreadState.Stopped)
                    {
                        stopped = true;
                    }

                    Thread.Sleep(delay);
                    ++count;
                }
                while (!stopped);

                th_CardDetection = null;
            }
        }

        public bool ReadLicense(object obj, out byte[] license)
        {
            throw new NotImplementedException();
        }

        public bool ReadData(object obj, out byte[] data)
        {
            throw new NotImplementedException();
        }

        public bool WriteData(object obj, byte[] data)
        {
            throw new NotImplementedException();
        }

        public bool WriteLicense(Object obj, byte[] license)
        {
            throw new NotImplementedException();
        }

        public bool ReadHeader(object obj, out byte[] headerData)
        {
            throw new NotImplementedException();
        }

        public bool WriteHeader(object obj, byte[] headerData)
        {
            throw new NotImplementedException();
        }

        public bool GetSerialNumber(object obj, out string uid)
        {
            throw new NotImplementedException();
        }

        private void Beep(byte numRepeat)
        {
            Rr3036Wrapper.SetBeep(ref comAddress, 0x01, 0x01, numRepeat, frmHandle);
        }
  
        public void ChangeReaderAddress(byte newAddress)
        {
            this.readerComPort = newAddress;
        }

        #endregion

        #region Private

        private void CardDetectionWorker()
        {
            //// Open RF (không cần vì RF tự mở khi reader "power on")
            //lastStatusCode = BasicBWrapper.OpenRf(ref comAddress, frmHandle);
            //if (lastStatusCode != BasicBStatusCodes.OK) { return; }

            // Temporary variables
            byte[] serialNumber, tagType;
            byte errCode;

            do
            {
                Thread.Sleep(ReaderContants.CardDetectionDelayTime);

                // Set giá trị mặc định cho các biến
                tagType = new byte[2];
                errCode = Rr3036Wrapper.OK;

                // Request to card (if any)
                statusCode = Rr3036Wrapper.ISO14443ARequest(ref comAddress, (byte)0x01, tagType, ref errCode, frmHandle);

                if (statusCode != Rr3036Wrapper.OK)
                {
                    if (statusCode == Rr3036Wrapper.communicationErr)
                    {
                        if (Disconnected != null)
                        {
                            Disconnected();
                        }
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (errCode != Rr3036Wrapper.OK)
                {
                    continue;
                }

                // Anti-collision
                serialNumber = new byte[4];
                statusCode = Rr3036Wrapper.ISO14443AAnticoll(ref comAddress, (byte)0x00, serialNumber, ref errCode, frmHandle);

                if (statusCode != Rr3036Wrapper.OK)
                {
                    if (statusCode == Rr3036Wrapper.communicationErr)
                    {
                        if (Disconnected != null)
                        {
                            Disconnected();
                        }
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (errCode != Rr3036Wrapper.OK)
                {
                    continue;
                }

                if (TagDetected != null)
                {
                    // Notify
                    if (beepOnTagDetected)
                    {
#if(!DEBUG)
                        Beep(1);
#endif
                    }

                    // Fire event
                    TagDetected(serialNumber);

                    // Sleep
                    Thread.Sleep(ReaderContants.CardDetectionDelayTime);
                }
            }
            while (flg_CardDetection);
        }

        public void SetFreesParking()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}