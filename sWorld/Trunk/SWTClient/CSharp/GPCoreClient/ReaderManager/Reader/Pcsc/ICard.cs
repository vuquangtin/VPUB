using System;

namespace ReaderManager.Pcsc
{
	/// <summary>
	/// This interface gives access to the basic card functions. It must be implemented by a class.
	/// </summary>
	public interface ICard
	{
		/// <summary>
		/// Wraps the PCSC funciton
		/// LONG SCardListReaders(SCARDCONTEXT hContext, 
		///		LPCTSTR mszGroups, 
		///		LPTSTR mszReaders, 
		///		LPDWORD pcchReaders 
		///	);
		/// </summary>
		/// <returns>A string array of the readers</returns>
		string[] ListReaders();

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
		/// <param name="Reader"></param>
		/// <param name="ShareMode"></param>
		/// <param name="PreferredProtocols"></param>
		void Connect(string Reader, SHARE_MODE ShareMode, PROTOCOL PreferredProtocols);

		/// <summary>
		/// Wraps the PCSC function
		///	LONG SCardDisconnect(
		///		IN SCARDHANDLE hCard,
		///		IN DWORD dwDisposition
		///	);
		/// </summary>
		/// <param name="Disposition"></param>
		void Disconnect(DISCONNECT Disposition);

		/// <summary>
		/// Wraps the PCSC function
		/// LONG SCardTransmit(
		///		SCARDHANDLE hCard,
		///		LPCSCARD_I0_REQUEST pioSendPci,
		///		LPCBYTE pbSendBuffer,SCardTransmit
		///		DWORD cbSendLength,
		///		LPSCARD_IO_REQUEST pioRecvPci,
		///		LPBYTE pbRecvBuffer,
		///		LPDWORD pcbRecvLength
		///	);
		/// </summary>
		/// <param name="ApduCmd">APDUCommand object with the APDU to send to the card</param>
		/// <returns>An APDUResponse object with the response from the card</returns>
		APDUResponse Transmit(APDUCommand ApduCmd);
        APDUResponse TransmitDesFire(APDUCommand ApduCmd);

		/// <summary>
		/// Wraps the PSCS function
		/// LONG SCardBeginTransaction(
		///     SCARDHANDLE hCard
		/// );
		/// </summary>
		void BeginTransaction();

		/// <summary>
		/// Wraps the PCSC function
		/// LONG SCardEndTransaction(
		///     SCARDHANDLE hCard,
		///     DWORD dwDisposition
		/// );
		/// </summary>
		void EndTransaction(DISCONNECT Disposition);

		/// <summary>
		/// Gets the attributes of the card
		/// </summary>
		/// <param name="AttribId">Identifier for the Attribute to get</param>
		/// <returns>Attribute content</returns>
		byte[] GetAttribute(UInt32 AttribId);
	}
}
