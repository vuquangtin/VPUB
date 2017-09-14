using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace CryptoHelper.Hashing
{
    public class Sha1Hashing
    {
        private Sha1Digest engine = new Sha1Digest();

        public byte[] Hash(string text, int loop)
        {
            byte[] msgBytes = ASCIIEncoding.ASCII.GetBytes(text);
            for (int i = 0; i < loop; i++)
            {
                msgBytes = Hash(msgBytes);
            }
            return msgBytes;
        }

        public byte[] Hash(string text)
        {
            byte[] msgBytes = ASCIIEncoding.ASCII.GetBytes(text);
            return Hash(msgBytes);
        }

        public byte[] Hash(byte[] textBytes)
        {
            engine.BlockUpdate(textBytes, 0, textBytes.Length);
            byte[] result = new byte[engine.GetDigestSize()];
            engine.DoFinal(result, 0);
            return result;
        }
    }
}
