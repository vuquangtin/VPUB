using System.Text;

namespace ReaderManager.Pcsc
{
	/// <summary>
	/// This class represents the APDU response sent by the card
	/// </summary>
	public class APDUResponse
	{
		/// <summary>
		///	Status bytes length
		/// </summary>
		public const int SW_LENGTH = 2;
        public const int DESFIRE_LENGTH = 255;	

		private byte[] data = null;	
		private byte sw1, sw2;

		/// <summary>
		/// Constructor from the byte data sent back by the card
		/// </summary>
		/// <param name="data">Buffer of data from the card</param>
		public APDUResponse(byte[] data)
		{
            
			if (data.Length > SW_LENGTH)
			{
				this.data = new byte[data.Length - SW_LENGTH];

				for (int i = 0; i < data.Length - SW_LENGTH; i++)
					this.data[i] = data[i];
			}
            if (null != data && data.Length >= 2)
            {
                sw1 = data[data.Length - 2];
                sw2 = data[data.Length - 1];
            }
		}

		/// <summary>
		/// Response data get property. Contains the data sent by the card minus the 2 status bytes (SW1, SW2)
		/// null if no data were sent by the card
		/// </summary>
		public byte[] Data
		{
			get
			{
				return data;
			}
		}

		/// <summary>
		/// SW1 byte get property
		/// </summary>
		public byte	SW1
		{
			get
			{
				return sw1;
			}
		}

		/// <summary>
		/// SW2 byte get property
		/// </summary>
		public byte	SW2
		{
			get
			{
				return sw2;
			}
		}

		/// <summary>
		/// Status get property
		/// </summary>
		public ushort Status
		{
			get
			{
				return (ushort) (((short) sw1 << 8) + (short) sw2);
			}
		}

		/// <summary>
		/// Overrides the ToString method to format to a string the APDUResponse object
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string sRet;
	
			// Display SW1 SW2
			sRet = string.Format("SW={0:X04}", Status);

			if (data != null)
			{
				StringBuilder sData = new StringBuilder(data.Length * 2);
				for (int nI = 0; nI < data.Length; nI++)
					sData.AppendFormat("{0:X02}", data[nI]);

				sRet += " Data=" + sData.ToString();
			}

			return sRet;
		}
	}
}
