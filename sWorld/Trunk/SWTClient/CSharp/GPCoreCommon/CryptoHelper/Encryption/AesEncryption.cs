using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Text;

namespace CryptoAlgorithm
{
    public class AesEncryption
    {
        private readonly string keyValue;

        private Encoding encoding;
        private IBlockCipherPadding padding;

        private readonly IBlockCipher blockCipher;
        private PaddedBufferedBlockCipher cipher;

        public AesEncryption(string keyValue)
        {
            this.keyValue = keyValue;

            encoding = new ASCIIEncoding();
            padding = new Pkcs7Padding();
            blockCipher = new AesEngine();
        }

        #region Chip

        public byte[] Encrypt(string plainText)
        {
            return BouncyCastleCrypto(true, encoding.GetBytes(plainText), keyValue);
        }

        public byte[] Encrypt(byte[] plainText)
        {
            return BouncyCastleCrypto(true, plainText, keyValue);
        }

        public byte[] Decrypt(string cipherText)
        {
            return BouncyCastleCrypto(false, Convert.FromBase64String(cipherText), keyValue);
        }

        public byte[] Decrypt(byte[] cipherText)
        {
            return BouncyCastleCrypto(false, cipherText, keyValue);
        }

        private byte[] BouncyCastleCrypto(bool forEncrypt, byte[] input, string key)
        {
            try
            {
                cipher = padding == null ? new PaddedBufferedBlockCipher(blockCipher) : new PaddedBufferedBlockCipher(blockCipher, padding);
                byte[] keyByte = encoding.GetBytes(key);
                cipher.Init(forEncrypt, new KeyParameter(keyByte));
                return cipher.DoFinal(input);
            }
            catch (CryptoException)
            {
                throw;
            }
        }

        #endregion

        #region Magnetic

        public string MEncrypt(string plainText)
        {
            if (plainText.Length == 0)
            {
                return string.Empty;
            }
            byte[] result = MDoCrypto(true, encoding.GetBytes(plainText));
            return Convert.ToBase64String(result);
        }

        public string MDecrypt(string cipherText)
        {
            if (cipherText.Length == 0)
            {
                return string.Empty;
            }
            byte[] result = MDoCrypto(false, Convert.FromBase64String(cipherText));
            return encoding.GetString(result);
        }

        private byte[] MDoCrypto(bool forEncrypt, byte[] input)
        {
            try
            {
                cipher = new PaddedBufferedBlockCipher(blockCipher, padding);
                byte[] keyByte = encoding.GetBytes(keyValue);
                cipher.Init(forEncrypt, new KeyParameter(keyByte));
                return cipher.DoFinal(input);
            }
            catch (CryptoException)
            {
                throw;
            }
        }

        #endregion
    }
}