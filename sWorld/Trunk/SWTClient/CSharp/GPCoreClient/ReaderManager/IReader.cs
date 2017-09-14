using ReaderLibrary;
using ReaderManager.Enum;
using ReaderManager.Model;
using ReaderManager.Pcsc;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;

namespace ReaderManager
{
    
     /// <summary>
     /// Interface reader.
     /// New card reader need implement this interface.
     /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Loại đầu đọc thẻ
        /// </summary>
        ReaderType Type { get; }

        /// <summary>
        /// find all card reader has same type
        /// </summary>
        /// <returns>list of card reader name</returns>
        List<String> FindAllCardReader();

        /// <summary>
        /// Kết nối đến đầu đọc. Sau khi kết nối, tiến trình phát hiện thẻ chưa được chạy.
        /// Cần phải gọi hàm StartCardDetection.
        /// </summary>
        /// <returns></returns>
        bool Connect(Object name);

        /// <summary>
        /// Ngắt kết nối đến đầu đọc (đồng thời ngừng tiến trình phát hiện thẻ, nếu đang chạy).
        /// </summary>
        void Disconnect(Object obj);

        /// <summary>
        /// Alert signal when read card
        /// </summary>
        void AlertSignalOnTagDetected(Object obj);

        /// <summary>
        /// Chờ đưa card vào
        /// </summary>
        /// <param name="obj"></param>
        void WaittingCard(Object obj);

        /// <summary>
        /// Bắt đầu tiến trình phát hiện thẻ
        /// </summary>
        void StartCardDetection(Object obj);

        /// <summary>
        /// Ngừng tiến trình phát hiện thẻ
        /// </summary>
        void StopCardDetection(Object obj);

        /// <summary>
        /// Read license
        /// </summary>
        /// <param name="obj">configuration object. It depents on card type</param>
        /// <param name="license">license data</param>
        /// <returns></returns>
        bool ReadLicense(Object obj, out byte[] license);

        /// <summary>
        /// Read data from card
        /// </summary>
        /// <param name="obj">ccongifuration object. It depents on card type</param>
        /// <param name="data">data from card</param>
        /// <returns></returns>
        bool ReadData(Object obj, out byte[] data);

        /// <summary>
        /// read header data
        /// </summary>
        /// <param name="headerData"></param>
        /// <returns></returns>
        bool ReadHeader(Object obj, out byte[] headerData);

        bool WriteLicense(Object obj, byte[] license);

        /// <summary>
        /// Write byte data to card
        /// </summary>
        /// <param name="obj">congifuration object. It depents on card type</param>
        /// <param name="sectorData">data is writed on card</param>
        /// <returns></returns>
        bool WriteData(Object obj, byte[] data);

        /// <summary>
        /// write byte header
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="headerData"></param>
        /// <returns></returns>
        bool WriteHeader(Object obj, byte[] headerData);

        bool GetSerialNumber(Object obj, out string uid);

        event DelegateCardDataHandler ReturnCardData;

        /// <summary>
        /// free for sParking
        /// </summary>
        /// <param name="obj"></param>
        void SetFreesParking();
    }
}