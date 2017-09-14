namespace ReaderManager.Pcsc
{
    /// <summary>
    /// This class is used to update a set of parameters of an APDUCommand object
    /// </summary>
    public class APDUParam
    {
        byte cla = 0, channel = 0, p2 = 0, p1 = 0;
        byte[] data = null;
        short le = -1;
        bool useP1 = false, useP2 = false, useChannel = false,
            useData = false, useClass = false, useLe = false;

        #region Constructors
        public APDUParam()
        {
        }

        /// <summary>
        /// Copy constructor (used for cloning)
        /// </summary>
        /// <param name="param"></param>
        public APDUParam(APDUParam param)
        {
            // Copy field
            if (param.data != null)
                param.data.CopyTo(data, 0);
            cla = param.cla;
            channel = param.channel;
            p1 = param.p1;
            p2 = param.p2;
            le = param.le;

            // Copy flags field
            useChannel = param.useChannel;
            useClass = param.useClass;
            useData = param.useData;
            useLe = param.useLe;
            useP1 = param.useP1;
            useP2 = param.useP2;
        }

        public APDUParam(byte bClass, byte bP1, byte bP2, byte[] baData, short nLe)
        {
            this.Class = bClass;
            this.P1 = bP1;
            this.P2 = bP2;
            this.Data = baData;
            this.Le = (byte)nLe;
        }
        #endregion

        /// <summary>
        /// Clones the current APDUParam instance
        /// </summary>
        /// <returns></returns>
        public APDUParam Clone()
        {
            return new APDUParam(this);
        }

        /// <summary>
        /// Resets the current instance, all flags are set to false
        /// </summary>
        public void Reset()
        {
            cla = 0;
            channel = 0;
            p2 = 0;
            p1 = 0;

            data = null;
            le = -1;

            useP1 = false;
            useP2 = false;
            useChannel = false;
            useData = false;
            useClass = false;
            useLe = false;
        }

        #region Flags properties

        public bool UseClass
        {
            get { return useClass; }
        }

        public bool UseChannel
        {
            get { return useChannel; }
        }

        public bool UseLe
        {
            get { return useLe; }
        }

        public bool UseData
        {
            get { return useData; }
        }

        public bool UseP1
        {
            get { return useP1; }
        }

        public bool UseP2
        {
            get { return useP2; }
        }
        #endregion

        #region Parameter properties
        public byte P1
        {
            get { return p1; }

            set
            {
                p1 = value;
                useP1 = true;
            }
        }

        public byte P2
        {
            get { return p2; }
            set
            {
                p2 = value;
                useP2 = true;
            }

        }

        public byte[] Data
        {
            get { return data; }
            set
            {
                data = value;
                useData = true;
            }
        }

        public byte Le
        {
            get { return (byte)le; }
            set
            {
                le = value;
                useLe = true;
            }
        }

        public byte Channel
        {
            get { return channel; }
            set
            {
                channel = value;
                useChannel = true;
            }
        }

        public byte Class
        {
            get { return cla; }
            set
            {
                cla = value;
                useClass = true;
            }
        }

        #endregion
    }
}
