using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper.Config;
using CryptoAlgorithm;
using CommonHelper.Utils;

namespace CryptoHelper.Generator
{
    public class GeneratorMaster : GeneratorKey
    {
        private static GeneratorMaster instance = null;
        private GeneratorMaster()
        {
            publickey = SystemSettings.Instance.Master;
            priData = StringUtils.HexStringToByteArray("serversworld");
            base.CreatedRSA();
        }


        public static GeneratorMaster Instance
        {
            get
            {
                if (null == instance)
                    instance = new GeneratorMaster();

                return instance;
            }
        }

    }

    public class GeneratorPartner : GeneratorKey
    {
        private static GeneratorPartner instance = null;
        private GeneratorPartner()
        {
            publickey = SystemSettings.Instance.Partner;
            base.CreatedRSA();
        }
        
        public static GeneratorPartner Instance
        {
            get
            {
                if (null == instance)
                    instance = new GeneratorPartner();

                return instance;
            }
        }
       
    }

    public class GeneratorKey
    {
        protected RsaEncryption RSA;
        protected AesEncryption AES;
        protected byte[] priData = StringUtils.HexStringToByteArray("serversworld");
        protected GeneratorKey() { }
        
        protected string publickey = String.Empty;

        protected virtual void CreatedRSA()
        {
            RSA = new RsaEncryption();
            RSA.LoadPublicFromXml(publickey);
        }

        public void CreatedRSA(string value)
        {
            AES = new AesEncryption(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattendata"></param>
        /// <param name="license"></param>
        /// <returns></returns>
        public bool ValidationDataFromServer(byte[] pattendata, byte[] license)
        {  
            byte[] data = new byte[pattendata.Length + priData.Length];
            Array.Copy(pattendata, 0, data, 0, pattendata.Length); 
            Array.Copy(priData, 0, data, pattendata.Length +1, priData.Length); 

           return ValidationSerialNumber(data, license);
        }

        public bool ValidationSerialNumber(byte[] pattendata, byte[] license)
        {
            // Verify license
            byte[] decrypted = RSA.PublicDecryption(license);
            return decrypted.SequenceEqual(pattendata);
        }
    }
}
