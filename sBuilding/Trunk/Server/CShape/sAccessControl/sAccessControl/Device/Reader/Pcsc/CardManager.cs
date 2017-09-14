using sAccessControl.Contants;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace sAccessControl.Device.Reader.Pcsc
{
	/// <summary>
	/// Implementation of ICard using native (P/Invoke) interoperability for PC/SC
	/// </summary>
	public class CardManager : CardBase
	{
		private	UInt32 context = 0;
		private	UInt32 cardHandle = 0;
		private	UInt32 protocol = (uint) PROTOCOL.T0;
		private	int	lastError = 0;

		/// <summary>
		/// Default constructor
		/// </summary>
		public CardManager()
		{
		}

		/// <summary>
		/// Object destruction
		/// </summary>
		~CardManager()
		{
			Disconnect(DISCONNECT.UNPOWER);
			ReleaseContext();
		}

		/// <summary>
		/// Wraps the PCSC function
		/// LONG SCardListReaders(SCARDCONTEXT hContext, 
		///		LPCTSTR mszGroups, 
		///		LPTSTR mszReaders, 
		///		LPDWORD pcchReaders 
		///	);
		/// </summary>
		/// <returns>A string array of the readers</returns>
		public override string[] ListReaders()
		{
			EstablishContext(SCOPE.USER);

			string[]	sListReaders = null;
			UInt32	pchReaders = 0;
			IntPtr	szListReaders = IntPtr.Zero;

			lastError = WinSCardWrapper.SCardListReaders(context, null, szListReaders, out pchReaders);
			if (lastError == 0)
			{
				szListReaders = Marshal.AllocHGlobal((int) pchReaders);
				lastError = WinSCardWrapper.SCardListReaders(context, null, szListReaders, out pchReaders);
				if (lastError == 0)
				{
					char[] caReadersData = new char[pchReaders];
					int	nbReaders = 0;
					for (int nI = 0; nI < pchReaders; nI++)
					{
						caReadersData[nI] = (char) Marshal.ReadByte(szListReaders, nI);

						if (caReadersData[nI] == 0)
							nbReaders++;
					}

					// Remove last 0
					--nbReaders;

					if (nbReaders != 0)
					{
						sListReaders = new string[nbReaders];
						char[] caReader = new char[pchReaders];
						int	nIdx = 0;
						int	nIdy = 0;
						int	nIdz = 0;
						// Get the nJ string from the multi-string

						while(nIdx < pchReaders - 1)
						{
							caReader[nIdy] = caReadersData[nIdx];
							if (caReader[nIdy] == 0)
							{
								sListReaders[nIdz] = new string(caReader, 0, nIdy);
								++nIdz;
								nIdy = 0;
								caReader = new char[pchReaders];
							}
							else
								++nIdy;

							++nIdx;
						}
					}

				}

				Marshal.FreeHGlobal(szListReaders);
			}

			ReleaseContext();

			return sListReaders;
		}

		/// <summary>
		/// Wraps the PCSC function 
		/// LONG SCardEstablishContext(
		///		IN DWORD dwScope,
		///		IN LPCVOID pvReserved1,
		///		IN LPCVOID pvReserved2,
		///		OUT LPSCARDCONTEXT phContext
		///	);
		/// </summary>
		/// <param name="Scope"></param>
		public void EstablishContext(SCOPE Scope)
		{
			IntPtr hContext = Marshal.AllocHGlobal(Marshal.SizeOf(context));

			lastError = WinSCardWrapper.SCardEstablishContext((uint)Scope, IntPtr.Zero, IntPtr.Zero, hContext);
			if (lastError != 0)
			{
				string msg = "SCardEstablishContext error: " + lastError;

				Marshal.FreeHGlobal(hContext);
				throw new SmartCardException(msg);
			}

			context = (uint) Marshal.ReadInt32(hContext);

			Marshal.FreeHGlobal(hContext);
		}

		/// <summary>
		/// Wraps the PCSC function
		/// LONG SCardReleaseContext(
		///		IN SCARDCONTEXT hContext
		///	);
		/// </summary>
		public void ReleaseContext()
		{
			if (context != 0)
			{
				lastError = WinSCardWrapper.SCardReleaseContext(context);

				if (lastError != 0)
				{
					string	msg = "SCardReleaseContext error: " + lastError;
					throw new SmartCardException(msg);
				}

				context = 0;
			}
		}

		/// <summary>
		///  Wraps the PCSC function
		///  LONG SCardConnect(
		///		IN SCARDCONTEXT hContext,
		///		IN LPCTSTR szReader,
		///		IN DWORD dwShareMode,
		///		IN DWORD dwPreferredProtocols,
		///		OUT LPSCARDHANDLE phCard,
		///		OUT LPDWORD pdwActiveProtocol
		///	);
		/// </summary>
		/// <param name="readerAlias"></param>
		/// <param name="ShareMode"></param>
		/// <param name="PreferredProtocols"></param>
		public override void Connect(string readerAlias, SHARE_MODE ShareMode, PROTOCOL PreferredProtocols)
		{
			EstablishContext(SCOPE.USER);

			IntPtr	hCard = Marshal.AllocHGlobal(Marshal.SizeOf(cardHandle));
			IntPtr	pProtocol = Marshal.AllocHGlobal(Marshal.SizeOf(protocol));

			lastError = WinSCardWrapper.SCardConnect(context, 
				readerAlias, 
				(uint) ShareMode, 
				(uint) PreferredProtocols, 
				hCard,
				pProtocol);

			if (lastError != 0)
			{
				string msg = "SCardConnect error: " + lastError;

				Marshal.FreeHGlobal(hCard);
				Marshal.FreeHGlobal(pProtocol);
				throw new SmartCardException(msg);
			}

			cardHandle = (uint) Marshal.ReadInt32(hCard);
			protocol = (uint) Marshal.ReadInt32(pProtocol);

			Marshal.FreeHGlobal(hCard);
			Marshal.FreeHGlobal(pProtocol);
		}

		/// <summary>
		/// Wraps the PCSC function
		///	LONG SCardDisconnect(
		///		IN SCARDHANDLE hCard,
		///		IN DWORD dwDisposition
		///	);
		/// </summary>
		/// <param name="Disposition"></param>
		public override void Disconnect(DISCONNECT Disposition)
		{
			if (cardHandle != 0)
			{
				lastError = WinSCardWrapper.SCardDisconnect(cardHandle, (uint)Disposition);
				cardHandle = 0;

				if (lastError != 0)
				{
					string msg = "SCardDisconnect error: " + lastError;
					throw new SmartCardException(msg);
				}

				ReleaseContext();
			}
		}

		/// <summary>
		/// Wraps the PCSC function
		/// LONG SCardTransmit(
		///		SCARDHANDLE hCard,
		///		LPCSCARD_I0_REQUEST pioSendPci,
		///		LPCBYTE pbSendBuffer,
		///		DWORD cbSendLength,
		///		LPSCARD_IO_REQUEST pioRecvPci,
		///		LPBYTE pbRecvBuffer,
		///		LPDWORD pcbRecvLength
		///	);
		/// </summary>
		/// <param name="ApduCmd">APDUCommand object with the APDU to send to the card</param>
		/// <returns>An APDUResponse object with the response from the card</returns>
		public override APDUResponse Transmit(APDUCommand ApduCmd)
		{
			uint	RecvLength = (uint) (ApduCmd.Length + APDUResponse.SW_LENGTH);
			byte[]	ApduBuffer = null;
			byte[]	ApduResponse = new byte[ApduCmd.Length + APDUResponse.SW_LENGTH];
			SCardIORequest	ioRequest = new SCardIORequest();
			ioRequest.m_dwProtocol = protocol;
			ioRequest.m_cbPciLength = 8;

			// Build the command APDU
			if (ApduCmd.Data == null)
			{
				ApduBuffer = new byte[APDUCommand.APDU_MIN_LENGTH + ((ApduCmd.Length != 0) ? 1 : 0)];

				if (ApduCmd.Length != 0)
					ApduBuffer[4] = (byte)ApduCmd.Length;
			}
			else
			{
				ApduBuffer = new byte[APDUCommand.APDU_MIN_LENGTH + 1 + ApduCmd.Data.Length];

				for (int nI = 0; nI < ApduCmd.Data.Length; nI++)
					ApduBuffer[APDUCommand.APDU_MIN_LENGTH + 1 + nI] = ApduCmd.Data[nI];

				ApduBuffer[APDUCommand.APDU_MIN_LENGTH] = (byte) ApduCmd.Data.Length;
			}

			ApduBuffer[0] = ApduCmd.Class;
			ApduBuffer[1] = ApduCmd.Instruction;
			ApduBuffer[2] = ApduCmd.P1;
			ApduBuffer[3] = ApduCmd.P2;

			lastError = WinSCardWrapper.SCardTransmit(cardHandle, ref ioRequest, ApduBuffer, (uint)ApduBuffer.Length, IntPtr.Zero, ApduResponse, out RecvLength); 
			if (lastError != 0)
			{
				string msg = "SCardTransmit error: " + lastError;
				throw new SmartCardException(msg);
			}
			
			byte[] ApduData = new byte[RecvLength];

			for (int nI = 0; nI < RecvLength; nI++)
				ApduData[nI] = ApduResponse[nI];

			return new APDUResponse(ApduData);
		}

		/// <summary>
		/// Wraps the PSCS function
		/// LONG SCardBeginTransaction(
		///     SCARDHANDLE hCard
		///  );
		/// </summary>
		public override void BeginTransaction()
		{
			if (cardHandle != 0)
			{
				lastError = WinSCardWrapper.SCardBeginTransaction(cardHandle);
				if (lastError != 0)
				{
					throw new SmartCardException("SCardBeginTransaction error: " + lastError);
				}
			}
		}

		/// <summary>
		/// Wraps the PCSC function
		/// LONG SCardEndTransaction(
		///     SCARDHANDLE hCard,
		///     DWORD dwDisposition
		/// );
		/// </summary>
		/// <param name="Disposition">A value from DISCONNECT enum</param>
		public override void EndTransaction(DISCONNECT Disposition)
		{
			if (cardHandle != 0)
			{
				lastError = WinSCardWrapper.SCardEndTransaction(cardHandle, (UInt32)Disposition);
				if (lastError != 0)
				{
					string msg = "SCardEndTransaction error: " + lastError;
					throw new SmartCardException(msg);
				}
			}
		}

		/// <summary>
		/// Gets the attributes of the card
		/// </summary>
		/// <param name="attribId">Identifier for the Attribute to get</param>
		/// <returns>Attribute content</returns>
		public override byte[] GetAttribute(UInt32 attribId)
		{
			byte[] attr = null;
			UInt32 attrLen = 0;

			lastError = WinSCardWrapper.SCardGetAttrib(cardHandle, attribId, attr, out attrLen);
			if (lastError == 0)
			{
				if (attrLen != 0)
				{
					attr = new byte[attrLen];
					lastError = WinSCardWrapper.SCardGetAttrib(cardHandle, attribId, attr, out attrLen);
					if (lastError != 0)
					{
						throw new SmartCardException("SCardGetAttr error: " + lastError);
					}
				}
			}
			else
			{
				throw new SmartCardException("SCardGetAttr error: " + lastError);
			}

			return attr;
		}

		/// <summary>
		/// This function must implement a card detection mechanism.
		/// 
		/// When card insertion is detected, it must call the method CardInserted()
		/// When card removal is detected, it must call the method CardRemoved()
		/// 
		/// </summary>
		protected override void RunCardDetection(object readerAlias)
		{
			bool bFirstLoop = true;
			UInt32 hContext = 0;    // Local context
			IntPtr phContext;

			phContext = Marshal.AllocHGlobal(Marshal.SizeOf(hContext));

			if (WinSCardWrapper.SCardEstablishContext((uint)SCOPE.USER, IntPtr.Zero, IntPtr.Zero, phContext) == SCardReturnValue.SCARD_S_SUCCESS)
			{
				hContext = (uint)Marshal.ReadInt32(phContext);
				Marshal.FreeHGlobal(phContext);

				UInt32 nbReaders = 1;
				SCardReaderState[] readerState = new SCardReaderState[nbReaders];

				readerState[0].m_dwCurrentState = (UInt32) CARD_STATE.UNAWARE;
				readerState[0].m_szReader = (string)readerAlias;

				UInt32 eventState;
				UInt32 currentState = readerState[0].m_dwCurrentState;

				// Card detection loop
				do
				{
					int errCode;
					if ((errCode = WinSCardWrapper.SCardGetStatusChange(hContext, WAIT_TIME, readerState, nbReaders)) == 0)
					{
						eventState = readerState[0].m_dwEventState;
						currentState = readerState[0].m_dwCurrentState;

						// Check state
						if (((eventState & (uint)CARD_STATE.CHANGED) == (uint)CARD_STATE.CHANGED) && !bFirstLoop)
						{
							// State has changed
							if ((eventState & (uint)CARD_STATE.EMPTY) == (uint)CARD_STATE.EMPTY)
							{
								// There is no card, card has been removed -> Fire CardRemoved event
								HandleCardRemoved();
							}

							if (((eventState & (uint)CARD_STATE.PRESENT) == (uint)CARD_STATE.PRESENT) &&
								((eventState & (uint)CARD_STATE.PRESENT) != (currentState & (uint)CARD_STATE.PRESENT)))
							{
								// There is a card in the reader -> Fire CardInserted event
								HandleCardInserted();
							}

							if ((eventState & (uint)CARD_STATE.ATRMATCH) == (uint)CARD_STATE.ATRMATCH)
							{
								// There is a card in the reader and it matches the ATR we were expecting-> Fire CardInserted event
								HandleCardInserted();
							}
						}

						// The current stateis now the event state
						readerState[0].m_dwCurrentState = eventState;

						bFirstLoop = false;
					}
					else
					{
						if ((uint)errCode == SCardReturnValue.SCARD_E_NO_READERS_AVAILABLE)
						{
							HandleReaderUnplugged();
							break;
						}
					}

					Thread.Sleep(ReaderContants.CardDetectionDelayTime);

					if (th_flag == false)
						break;
				}
				while (true);    // Exit on request
			}
			else
			{
				Marshal.FreeHGlobal(phContext);
				throw new SmartCardException("PC/SC error");
			}

			WinSCardWrapper.SCardReleaseContext(hContext);
		}
	}
}
