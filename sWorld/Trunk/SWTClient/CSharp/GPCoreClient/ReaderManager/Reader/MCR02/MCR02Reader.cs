using System;
using System.Collections.Generic;
using ReaderManager.Model;
using sWorldModel.TransportData;
using ReaderManager.Pcsc;
using ReaderManager.Reader.MCR02;
using ReaderLibrary;
using CommonHelper.Config;
using ReaderManager.Enum;

namespace ReaderManager.MCR02
{
    public class MCR02Reader : IReader
    {
        #region Private properties

        private NetworkService nService;
        private string serPort;

        //dùng để check xem 1 hàm có được hỗ trợ hay ko.
        public bool isConnectSupport = true;
        public bool isStartCardDetectionSupport = false;
        public bool isStopCardDetectionSupport = false;
        public bool isReadDataSupport = false;
        public bool isWriteDataSupport = false;

        #endregion

        //Contructor
        public MCR02Reader()
        {
            nService = new NetworkService(ReaderSettings.Instance.MCRPort);
        }

        public event DelegateCardDataHandler ReturnCardData;

       
        #region IReader properties.
        // Implement từ IReader, ko cần giải thích.
        private bool isBeepOnTagDetected;
        private byte readerAddress;

        public ReaderType Type
        {
            get { return ReaderType.MCR02; }
        }

        public byte Address
        {
            get
            {
                return this.readerAddress;
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

        #region IReader methods

        public List<string> FindAllCardReader()
        {
            return null;
        }

        public bool Connect(Object obj)
        {
            return nService.StartService();
        }

        public void Disconnect(Object obj)
        {
            nService.StartService();
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
            throw new NotImplementedException();
        }

        public void StopCardDetection(Object obj)
        {
            throw new NotImplementedException();
        }

        public bool ReadLicense(object obj, out byte[] license)
        {
            throw new NotImplementedException();
        }

        public bool ReadData(object obj, out byte[] data)
        {
            throw new NotImplementedException();
        }

        public bool WriteData(object obj, byte[] sectorData)
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

        public void ChangeReaderAddress(byte newAddress)
        {
            throw new NotImplementedException();
        }

        #endregion


        public bool WriteLicense(object obj, byte[] license)
        {
            throw new NotImplementedException();
        }

        public void SetFreesParking()
        {
            throw new NotImplementedException();
        }
    }
}
