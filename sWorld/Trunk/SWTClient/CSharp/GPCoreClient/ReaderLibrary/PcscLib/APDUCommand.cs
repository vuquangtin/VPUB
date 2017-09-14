using System.Text;

namespace ReaderLibrary.PcscLib
{
	/// <summary>
	/// This class represents a command APDU
	/// </summary>
	public class APDUCommand
	{
		#region Accessors

		/// <summary>
		/// Minimun size in bytes of an APDU command
		/// </summary>
		public const int APDU_MIN_LENGTH = 4;

		private byte cla, ins, p1, p2, le;
		private byte[] data;

		/// <summary>
		/// Class get property
		/// </summary>
		public byte Class
		{
			get
			{
				return cla;
			}
		}

		/// <summary>
		/// Instruction get property
		/// </summary>
		public byte Instruction
		{
			get
			{
				return ins;
			}
		}

		/// <summary>
		/// Parameter P1 get property
		/// </summary>
		public byte P1
		{
			get
			{
				return p1;
			}
		}

		/// <summary>
		/// Parameter P2 get property
		/// </summary>
		public byte P2
		{
			get
			{
				return p2;
			}
            set
            {
                p2 = value;
            }
		}

		/// <summary>
		/// Data get property
		/// </summary>
		public byte[] Data
		{
			get
			{
				return data;
			}
            set
            {
                data = value;
            }
		}

		/// <summary>
		/// Length expected get property
		/// </summary>
		public byte Length
		{
			get
			{
				return le;
			}
            set
            {
                le = value;
            }
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="cla">Class byte</param>
		/// <param name="ins">Instruction byte</param>
		/// <param name="p1">Parameter P1 byte</param>
		/// <param name="p2">Parameter P2 byte</param>
		/// <param name="data">Data to send to the card if any, null if no data to send</param>
		/// <param name="le">Number of data expected, 0 if none</param>
		public APDUCommand(byte cla, byte ins, byte p1, byte p2, byte[] data, byte le)
		{
			this.cla = cla;
			this.ins = ins;
			this.p1 = p1;
			this.p2 = p2;
			this.data = data;
			this.le = le;
		}

		/// <summary>
		/// Update the current APDU with selected parameters
		/// </summary>
		/// <param name="apduParam">APDU parameters</param>
		public void Update(APDUParam apduParam)
		{
			if (apduParam.UseData)
				data = apduParam.Data;

			if (apduParam.UseLe)
				le = apduParam.Le;

			if (apduParam.UseP1)
				p1 = apduParam.P1;

			if (apduParam.UseP2)
				p2 = apduParam.P2;

			if (apduParam.UseChannel)
				cla += apduParam.Channel;
		}

		/// <summary>
		/// Overrides the ToString method to format to a string the APDUCommand object
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string strData = null;
			byte lc = 0, p3 = le;    

			if (data != null)
			{
				StringBuilder sData = new StringBuilder(data.Length * 2);
				for (int nI = 0; nI < data.Length; nI++)
					sData.AppendFormat("{0:X02}", data[nI]);

				strData = "Data=" + sData.ToString();
				lc = (byte) data.Length;
				p3 = lc;
			}
			
			StringBuilder strApdu = new StringBuilder();

			strApdu.AppendFormat("Class={0:X02} Ins={1:X02} P1={2:X02} P2={3:X02} P3={4:X02} ",
				cla, ins, p1, p2, p3);
			if (data != null)
				strApdu.Append(strData);

			return strApdu.ToString();
		}
	}
}
