using CommonHelper.Config;
using sAccessControl.Contants;
using sAccessControl.Device.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sAccessControl.Utils
{
    public class CheckLicenseCard
    {
        #region Properties

        private IReader readerLib;
        private byte[] serialCard;
        private byte[] prifix = { 0xAD, 0xAD, 0xAD };
        private byte[] endfix = { 0xDA, 0xDA, 0xDA };
        private byte[] licenseServer = null;
        private byte[] Modulus = StringUtils.HexStringToByteArray(PublicMasterKeySettings.Instance.Modulus);
        private byte[] Exponent = StringUtils.HexStringToByteArray(PublicMasterKeySettings.Instance.Exponent);
        private byte partner = 0xAA;
        private byte master = 0x00;
        private byte numberkey = 16;
        private readonly string DEFAULT_KEY = "ffffffffffff";

        private byte sectorDataNotPartner = 4;//khi master va partner trung nhau
        private byte sectorDataPartner = 7;//khi master va partner khac nhau

        #endregion

        public CheckLicenseCard(byte[] serial)
        {
            int len = serial.Length;
            licenseServer = new byte[6 + len];
            Array.Copy(prifix, 0, licenseServer, 0, 3);
            Array.Copy(serial, 0, licenseServer, 3, serial.Length);
            Array.Copy(endfix, 0, licenseServer, serial.Length + 3, 3);

            serialCard = new byte[len];
            Array.Copy(serial, serialCard, len);

            this.readerLib = readerLib;
        }

        #region Verified License

        public bool RsaVerifiedLicenServerHexValue(String license)
        {
            if (license == null) return false;

            byte[] data = StringUtils.HexStringToByteArray(license);

            BigInteger encData = new BigInteger(data);
            BigInteger exp = new BigInteger(Exponent);
            BigInteger mod = new BigInteger(Modulus);

            // (encData ^ Exponent) % Modulus - This Decrypt the data using the public Exponent
            BigInteger bnData = encData.modPow(exp, mod);
            byte[] deCodeData = bnData.getBytes();

            int serialLenght = licenseServer.Length;
            int deCodeDataLenght = deCodeData.Length;

            bool result = true;
            int index = 0;
            for (index = serialLenght - 1; index >= 0; index--)
            {
                deCodeDataLenght = --deCodeDataLenght;
                if (deCodeData[deCodeDataLenght] != licenseServer[index])
                {
                    result = false;
                    break;
                }
            }

            return result;
            //return true;
        }

        public bool RsaVerifiedLicenseMaster(byte[] license, out string msg)
        {
            msg = String.Empty;
            //byte[] license;
            //// read license from 3 sectors
            //if (!readerLib.ReadLicense(start, stop, out license))
            //{
            //    msg = CommonMessages.CanNotRead;
            //    return false;
            //}

            String strtemp = StringUtils.ByteArrayToHexString(license);

            BigInteger encData = new BigInteger(license);
            BigInteger exp = new BigInteger(Exponent);
            BigInteger mod = new BigInteger(Modulus);

            // (encData ^ Exponent) % Modulus - This Decrypt the data using the public Exponent
            BigInteger bnData = encData.modPow(exp, mod);
            byte[] deCodeData = bnData.getBytes();

            int deCodeDataLenght = deCodeData.Length;
            int seriallen = serialCard.Length;


            bool isOkie = true;

            for (int index = seriallen - 1; index >= 0; index--)
            {
                deCodeDataLenght = --deCodeDataLenght;
                if (deCodeDataLenght < 0 || deCodeData[deCodeDataLenght] != serialCard[index])
                {
                    isOkie = false;
                    msg = CommonMessages.WrongLicense;
                    break;
                }
            }

            return isOkie;
            //return true;
        }

        #endregion

    }
}
