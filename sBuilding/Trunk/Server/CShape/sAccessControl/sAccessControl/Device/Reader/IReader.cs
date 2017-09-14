using sAccessControl.Enums;
using System;

namespace sAccessControl.Device.Reader
{
    internal delegate void DisconnectedHandler();
    internal delegate void TagDetectedHandler(byte[] cardId);
    internal interface IReader
    {
        /// <summary>
        /// Loại đầu đọc thẻ
        /// </summary>
        ReaderType Type { get; }

        /// <summary>
        /// Địa chỉ kết nối đến đầu đọc thẻ, ràng buộc tùy thuộc loại đầu đọc
        /// </summary>
        byte Address { get; }

        bool BeepOnTagDetected { get; }

        /// <summary>
        /// Kết nối đến đầu đọc. Sau khi kết nối, tiến trình phát hiện thẻ chưa được chạy.
        /// Cần phải gọi hàm StartCardDetection.
        /// </summary>
        /// <returns></returns>
        bool Connect();

        /// <summary>
        /// Ngắt kết nối đến đầu đọc (đồng thời ngừng tiến trình phát hiện thẻ, nếu đang chạy).
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Bắt đầu tiến trình phát hiện thẻ
        /// </summary>
        void StartCardDetection();

        /// <summary>
        /// Ngừng tiến trình phát hiện thẻ
        /// </summary>
        void StopCardDetection();

        void ChangeReaderAddress(byte newAddress);

        /// <summary>
        /// Event cho biết đã mất kết nối với đầu đọc thẻ
        /// </summary>
        event DisconnectedHandler Disconnected;

        /// <summary>
        /// Event cho biết đã phát hiện thẻ trong vùng đọc
        /// </summary>
        event TagDetectedHandler TagDetected;

        /// <summary>
        /// Get License ghi tren the
        /// </summary>
        /// <param name="start">Sector bat dau</param>
        /// <param name="stop">Sector ket thuc</param>
        /// <param name="license">Tra license</param>
        /// <returns></returns>
        bool ReadLicense(byte start, byte stop, out byte[] license);
    }
}