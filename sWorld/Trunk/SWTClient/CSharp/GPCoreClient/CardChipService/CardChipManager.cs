using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper.Utils;
using CommonHelper.Config;
using sWorldModel.TransportData;
using CommonControls;
using System.Collections;
using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI;
using System.Text.RegularExpressions;
using ReaderManager.Pcsc;
using ReaderManager.Model;
using ReaderManager;
using System.Globalization;
using ReaderManager.Enum;
using CardChipService.Card;
using CryptoAlgorithm;

namespace CardChipService
{
    public class CardChipManager : ICardChipManager
    {
        #region Properties

        private IReader readerLib = null;
        private ReaderFactory factory = null;
        public event DelegateCardActionHandler ActionDataHandler;

        private String readerName;
        private byte[] serialCard;
        private int CardType;
        private byte[] prifix = { 0xAD, 0xAD, 0xAD };
        private byte[] endfix = { 0xDA, 0xDA, 0xDA };
        private byte[] licenseServer = null;

        // decrypt master data from server
        private byte[] ModulusMasterServerKey = StringUtils.HexStringToByteArray(MasterServerKeySettings.Instance.Modulus);
        private byte[] ExponenMasterServerKey = StringUtils.HexStringToByteArray(MasterServerKeySettings.Instance.Exponent);
        
        // decrypt partner data from server
        private byte[] ModulusPartnerServerKey = StringUtils.HexStringToByteArray(PartnerServerKeySettings.Instance.Modulus);
        private byte[] ExponentPartnerServerKey = StringUtils.HexStringToByteArray(PartnerServerKeySettings.Instance.Exponent);

        // dercrypt master data on card
        private byte[] ModulusLicenseMaster = StringUtils.HexStringToByteArray(LicenseMasterKeySettings.Instance.Modulus);
        private byte[] ExponentLicenseMaster = StringUtils.HexStringToByteArray(LicenseMasterKeySettings.Instance.Exponent);

        // decrypt partner data on card
        private byte[] ModulusLicensePartner = StringUtils.HexStringToByteArray(LicensePartnerKeySettings.Instance.Modulus);
        private byte[] ExponentLicensePartner = StringUtils.HexStringToByteArray(LicensePartnerKeySettings.Instance.Exponent);

        private byte numberkey = 16;
       

        private byte BEGIN_SECTOR_DATA_NOTPARTNER = 4;//khi master va partner trung nhau
        private byte BEGIN_SECTOR_DATA_HASPARTNER = 7;//khi master va partner khac nhau

        //private byte sectorPayIn = 11 //Sector nap tien
        //    , sectorPayOut = 12; // Sector tru tien


        #endregion

        public CardChipManager()
        {

        }

        public void SetReader(IReader reader)
        {
            this.readerLib = reader;
        }

        public void SetCardInfor(int cardType, byte[] serial)
        {
            int len = serial.Length;
            // create license server from serial data
            licenseServer = new byte[6 + len];
            Array.Copy(prifix, 0, licenseServer, 0, 3);
            Array.Copy(serial, 0, licenseServer, 3, len);
            Array.Copy(endfix, 0, licenseServer, len + 3, 3);

            serialCard = new byte[len];
            Array.Copy(serial, serialCard, len);
            CardType = cardType;
        }
       
        #region Verified License

        /// <summary>
        /// verify license of organization in card
        /// </summary>
        /// <param name="license">license</param>
        /// <returns></returns>
        public bool RsaVerifiedMasterLicenseServerHexValue(String license)
        {
            if (license == null) return false;

            byte[] data = StringUtils.HexStringToByteArray(license);

            return RsaVerifiedMasterServerLicense(data, licenseServer);
        }

        public bool RsaVerifiedLicenseMaster(byte start, byte stop, out string msg)
        {
            //read master
            byte[] licenseOnCard = ReadLicenseOnCard(start, stop, out msg);
            if (String.Empty != msg || licenseOnCard == null)
                return false;

            bool result = RsaVerifiedLicenseMaster(licenseOnCard, serialCard);
            if (!result)
                msg = "wronglicense";

            return result;
                             
        }


        public bool RsaVerifiedPartnerLicenseServerHexValue(string license)
        {
            if (license == null) return false;

            byte[] data = StringUtils.HexStringToByteArray(license);
            return RsaVerifiedPartnerServerLicense(data, licenseServer);
        }

        public bool RsaVerifiedLicensePartner(byte start, byte stop, out string msg)
        {
            //read master
            byte[] licenseOnCard = ReadLicenseOnCard(start, stop, out msg, false);
            if (String.Empty != msg || licenseOnCard == null)
                return false;

            bool result = RsaVerifiedLicensePartner(licenseOnCard, serialCard);
            if (!result)
                msg = "wronglicense";

            return result;
        }


        private byte[] ReadLicenseOnCard(byte start, byte stop, out string msg, bool isSwt = true)
        {
            msg = String.Empty;
            byte[] license = null;

            bool result = false;
            LicenseReader obj = new LicenseReader(isSwt ? LicenseReader.SWT : LicenseReader.PARTNER, start, stop);
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    obj.Mode = ACTION_MODE.READ_LICENSE_ON_DESFIRE;
                    result = DesfireEVWrapper.ReadLicense(readerLib, obj, out license);
                    break;
                default:
                    result =  MifareClassicWrapper.ReadLicense(readerLib, obj, out license);
                        
                    break;
            }

            if (!result)
            {
                msg = "CanNotRead";
            }
            return license;


        }
        
        /// <summary>
        /// verify license which send from server of partner
        /// </summary>
        /// <param name="license"></param>
        /// <param name="comparedata"></param>
        /// <returns></returns>
        private bool RsaVerifiedPartnerServerLicense(byte[] license, byte[] comparedata)
        {
            BigInteger encData = new BigInteger(license);

            BigInteger exp = new BigInteger(ExponentPartnerServerKey);
            BigInteger mod = new BigInteger(ModulusPartnerServerKey);

            // (encData ^ Exponent) % Modulus - This Decrypt the data using the public Exponent
            BigInteger bnData = encData.modPow(exp, mod);
            byte[] deCodeData = bnData.getBytes();

            int deCodeDataLenght = deCodeData.Length;
            int seriallen = comparedata.Length;


            byte[] temp = new byte[seriallen];
            bool isOkie = false;

            if (deCodeDataLenght >= seriallen)
            {
                int len = deCodeDataLenght - seriallen;
                Buffer.BlockCopy(deCodeData, len, temp, 0, seriallen);
                isOkie = comparedata.SequenceEqual(temp);
            }

            return isOkie;
        }

        /// <summary>
        /// verify license
        /// </summary>
        /// <param name="license"></param>
        /// <returns></returns>
        private bool RsaVerifiedMasterServerLicense(byte[] license, byte[] comparedata)
        {
            BigInteger encData = new BigInteger(license);
            BigInteger exp = new BigInteger(ExponenMasterServerKey);
            BigInteger mod = new BigInteger(ModulusMasterServerKey);

            // (encData ^ Exponent) % Modulus - This Decrypt the data using the public Exponent
            BigInteger bnData = encData.modPow(exp, mod);
            byte[] deCodeData = bnData.getBytes();

            int deCodeDataLenght = deCodeData.Length;
            int seriallen = comparedata.Length;


            byte[] temp = new byte[seriallen];
            bool isOkie = false;

            if (deCodeDataLenght >= seriallen)
            {
                int len = deCodeDataLenght - seriallen;
                Buffer.BlockCopy(deCodeData, len, temp, 0, seriallen);
                isOkie = comparedata.SequenceEqual(temp);
            }

            return isOkie;
        }


        private bool RsaVerifiedLicensePartner(byte[] license, byte[] comparedata)
        {
            if (license == null)
                return false;

            BigInteger encData = new BigInteger(license);
            BigInteger exp = new BigInteger(ExponentLicensePartner);
            BigInteger mod = new BigInteger(ModulusLicensePartner);

            // (encData ^ Exponent) % Modulus - This Decrypt the data using the public Exponent
            BigInteger bnData = encData.modPow(exp, mod);
            byte[] deCodeData = bnData.getBytes();

            int deCodeDataLenght = deCodeData.Length;
            int seriallen = comparedata.Length;


            byte[] temp = new byte[seriallen];
            bool isOkie = false;

            if (deCodeDataLenght >= seriallen)
            {
                int len = deCodeDataLenght - seriallen;
                Buffer.BlockCopy(deCodeData, len, temp, 0, seriallen);
                isOkie = comparedata.SequenceEqual(temp);
            }

            return isOkie;
        }

        private bool RsaVerifiedLicenseMaster(byte[] license, byte[] comparedata)
        {
            if (license == null)
                return false;

            BigInteger encData = new BigInteger(license);
            BigInteger exp = new BigInteger(ExponentLicenseMaster);
            BigInteger mod = new BigInteger(ModulusLicenseMaster);

            // (encData ^ Exponent) % Modulus - This Decrypt the data using the public Exponent
            BigInteger bnData = encData.modPow(exp, mod);
            byte[] deCodeData = bnData.getBytes();

            int deCodeDataLenght = deCodeData.Length;
            int seriallen = comparedata.Length;


            byte[] temp = new byte[seriallen];
            bool isOkie = false;

            if (deCodeDataLenght >= seriallen)
            {
                int len = deCodeDataLenght - seriallen;
                Buffer.BlockCopy(deCodeData, len, temp, 0, seriallen);
                isOkie = comparedata.SequenceEqual(temp);
            }

            return isOkie;
        }
        private byte[] decryptAES(byte[] data, string keycode)
        {
            AesEncryption aes = new AesEncryption(LicensePartnerKeySettings.Instance.ValueKey);
            byte[] decryp = aes.Decrypt(data);
            return decryp;
        }
        private byte [] decrypRSA(byte[] data, string keycode)
        {
            BigInteger encData = new BigInteger(data);

            BigInteger exp = null;
            BigInteger mod = null;
            switch (keycode)
            {
                case "partner":
                    exp = new BigInteger(ExponentLicensePartner);
                    mod = new BigInteger(ModulusLicensePartner);
                    break;
                default:
                    break;
            }

            // (encData ^ Exponent) % Modulus - This Decrypt the data using the public Exponent
            BigInteger bnData = encData.modPow(exp, mod);
            return bnData.getBytes();
        }
        public byte[] decryptData(string algorithmName, byte[] data, string keycode)
        {
            if (data == null)
                return null;

            byte[] result = null;
            switch (algorithmName)
            {
                case "RSA":
                    result = decrypRSA(data, keycode);
                    break;
                case "AES":
                    result = decryptAES(data, keycode);
                    break;

            }

            return result;
            
            
            
        }
        #endregion

        #region Master & Partner

        /// <summary>
        /// lookup on header data to find partner in
        /// </summary>
        /// <param name="headerdata"></param>
        /// <returns></returns>
        public bool HasPartner(byte[] headerdata)
        {
            bool result = false;
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = DesfireEVWrapper.HasPartner(readerLib);
                    break;
                default:
                    result = MifareClassicWrapper.HasPartner(headerdata);
                    break;

            }

            return result;
        }

        /// <summary>
        /// write license data on card
        /// </summary>
        /// <param name="start">start sector</param>
        /// <param name="stop">stop secltor</param>
        /// <param name="resultKeyPair"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool WriteLicenseData(byte start, byte stop, ResultCheckCardDTO keypair, out String msg)
        {
            bool result = false;
            msg = "Cannotwritelicense";
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = DesfireEVWrapper.WriteLicenseData(readerLib, start, stop, keypair, out msg);
                    break;
                default:
                    result = MifareClassicWrapper.WriteLicenseData(readerLib, start, stop, keypair, out msg);
                    msg = String.Empty;
                    break;
            }
           
            return result;

        }

        #endregion

        #region Write and Read Herder
        /// <summary>
        /// read header data on card
        /// </summary>
        /// <param name="headerData">buffer using to store header data</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool ReadHeaderData(out byte[] headerData, out string msg)
        {
            bool result = false;

            msg = "CannotReadHeader";
            headerData = null;
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = true;// do not use
                    headerData = new byte[4];
                    break;
                default:
                    result = MifareClassicWrapper.ReadHeaderData(readerLib, out headerData, out msg);
                    msg = String.Empty;
                    break;
            }

            return result;
        }

        /// <summary>
        /// write data to header
        /// </summary>
        /// <param name="IsMaster"></param>
        /// <param name="keydata"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool WriteHeaderData(bool IsMaster, List<KeyDTO> keydata, out string msg)
        {
            msg = String.Empty;
            bool result = false;
            // Check if teacher app metadat exists on card
            if (keydata == null)
            {
                msg = "CanNotWriteData";
                return result;
            }
           
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    return true;// do not use header data
                    break;
                default:
                    result = MifareClassicWrapper.WriteHeaderData(readerLib, IsMaster, keydata, out msg);
                    break;
            }

            return result;
        }

        /// <summary>
        /// update header data
        /// </summary>
        /// <param name="headerData"></param>
        /// <param name="headerKeyB"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateHeaderData(byte[] headerData, byte[] headerKeyB, out string msg)
        {
            msg = String.Empty;
            bool result = false;
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = true; // do not use header data
                    break;
                default:
                    result = MifareClassicWrapper.UpdateHeaderData(readerLib, headerData, headerKeyB, out msg);
                    break;
            }
            
            return result;
        }

        /// <summary>
        /// request key for read data
        /// </summary>
        /// <param name="headerData"></param>
        /// <returns></returns>
        public List<int> NeedRequestKeyReadData(byte[] headerData)
        {
            List<int> lsresult = null;
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    lsresult = DesfireEVWrapper.KeysRequestForReadData();
                    break;
                default:
                    lsresult = MifareClassicWrapper.NeedRequestKeyReadData(headerData);
                    break;
            }

            return lsresult;

        }

        #endregion

        #region Write and Read Data

        public bool ReadPersoData(DataToReadCardDTO key, byte[] headerData, out byte[] appdata, out string msg)
        {
            bool result = false;
            msg = String.Empty;
            appdata = null;
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = DesfireEVWrapper.ReadPersoData(readerLib, key, out appdata, out msg);
                    break;
                default:
                    result = MifareClassicWrapper.ReadAppData(readerLib, key, headerData, out appdata, out msg);
                    break;
            }
            return result;
        }

        public bool ReadAppData(DataToReadCardDTO key, byte[] headerData, out byte[] appdata, out string msg)
        {
            bool result = false;
            msg = String.Empty;
            appdata = null;
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = DesfireEVWrapper.ReadApplicationData(readerLib, key, out appdata, out msg);
                    break;
                default:
                    result = MifareClassicWrapper.ReadAppData(readerLib, key, headerData, out appdata, out msg);
                    break;
            }
            return result;
        }

        public bool WritePersoData(DataToWriteCardDTO keyAnddata, out string msg)
        {
            bool result = false;
            msg = String.Empty;

            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = DesfireEVWrapper.WritePersoData(readerLib, keyAnddata, out msg);
                    break;
                default:
                    result = MifareClassicWrapper.WriteAppData(readerLib, keyAnddata, out msg);
                    break;
            }
            return result;
        }
        /// <summary>
        /// write information to card
        /// </summary>
        /// <param name="keyAnddata"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool WriteAppData(DataToWriteCardDTO keyAnddata, out string msg)
        {
            bool result = false;
            msg = String.Empty;

            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = DesfireEVWrapper.WriteApplicationData(readerLib, keyAnddata, out msg);
                    break;
                default:
                    result = MifareClassicWrapper.WriteAppData(readerLib, keyAnddata, out msg);
                    break;
            }
            return result;
        }

        /// <summary>
        /// clear app data
        /// </summary>
        /// <param name="keydata"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool ClearUpAllData(DataToWriteCardDTO keydata, out string msg, bool isPartner)
        {
            bool result = false;
            msg = String.Empty;
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = DesfireEVWrapper.ClearTheAllApplication(readerLib, keydata, out msg, isPartner);
                    break;
                default:
                    result = MifareClassicWrapper.ClearUpAllData(readerLib, keydata, out msg, isPartner);
                    break;

            }

            return result;
            
        }


        #endregion

        #region Write and read eCash


        #region Utilitis

        //lay sector bat dau va sector ket thuc de ghi data
        public void IdentifyBeginSectorFromHeaderData(byte[] headerData, out byte sectorBegin, out byte sectorEnd)
        {
            sectorBegin = 0;
            sectorEnd = 0;
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    //do not use header data in the case desfire card
                    break;
                default:
                    MifareClassicWrapper.IdentifyBeginSectorFromHeaderData(headerData, out sectorBegin, out sectorEnd);
                    break;

            }
        }

        /// <summary>
        /// lay thong tin HMK_ALIAS, DMKA_ALIAS, DMKB_ALIAS, PVK_ALIAS
        /// de ghi vao the
        /// </summary>
        /// <param name="headerData"></param>
        public bool GetDataHerder(ref byte[] headerData)
        {
            bool result = false;
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = true; //
                    break;
                default:
                    result = MifareClassicWrapper.GetDataHerder(ref headerData);
                    break;

            }

            return result;
        }

        public bool ClearAppData(DataToWriteCardDTO keydata, out string msg)
        {
            bool result = false;
            msg = String.Empty;
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = DesfireEVWrapper.ClearApplicationData(readerLib, keydata, out msg);
                    break;
                default:
                    result = MifareClassicWrapper.ClearAppData(readerLib, keydata, out msg);
                    break;
            }

            return result;
        }

        public bool ClearPersoData(DataToWriteCardDTO keydata, out string msg)
        {
            bool result = false;
            msg = String.Empty;
            switch (CardType)
            {
                case (int)CARD_TYPE.DESFIRE_CARD:
                    result = DesfireEVWrapper.ClearPersoData(readerLib, keydata, out msg);
                    break;
                default:
                    result = MifareClassicWrapper.ClearAppData(readerLib, keydata, out msg);
                    break;
            }

            return result;
        }

        public bool WaitingCard(string name)
        {
            readerLib = ReaderFactory.GetInstance().GetReader(name);
            if (readerLib != null)
            {
                WaitingCardObject objControl = new WaitingCardObject();
                objControl.CurrentReaderName = name;
                readerLib.WaittingCard(objControl);
                readerLib.ReturnCardData += ReturnCardAction;
                return true;
            }

            return false;
        }

        public void ReturnCardAction(DataCardObject obj)
        {
            ActionDataHandler(obj);
        }

        public List<string> FindAllCardReader()
        {
            return ReaderFactory.GetInstance().FindAllCardReader();
        }

        public bool Disconnect()
        {
            if (null != readerLib)
            {
                readerLib.Disconnect(null);
                readerLib.ReturnCardData -= ReturnCardAction;
                readerLib = null;
                return true;
            }
            return false;
        }

        public void Alert(bool flag)
        {
            readerLib.AlertSignalOnTagDetected(flag);
        }

        public void SetFreesParking()
        {
            readerLib.SetFreesParking();
        }

        #endregion

        #endregion

    }
}
