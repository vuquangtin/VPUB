using System;
using System.Collections.Generic;
using sWorldModel.TransportData;

namespace ImageAccessor
{
    public interface IImageRepository
    {
        #region Properties

        /// <summary>
        /// Danh sách parkingInId từ tên các file trong thư mục current
        /// </summary>
        List<long> CurrentParkingInIds { get; }

        /// <summary>
        /// Địa chỉ nơi chứa hình xe
        /// </summary>
        string Address {get; }

        /// <summary>
        /// Phần trăm dung lượng hiện còn của nơi chứa hình
        /// </summary>
        float RemainingStoragePercentage { get; }

        #endregion

        #region Save image methods

        /// <summary>
        /// Lưu các hình lúc xe ra, dùng parkingInId để đặt trên cho file hình.
        /// </summary>
        /// <param name="parkingInId">
        /// Mã record chứa thông tin xe vào
        /// </param>
        /// <param name="cfImgBytes">
        /// Hình chụp mặt hách hàng lúc vào dưới dạng mảng byte
        /// </param>
        /// <param name="npImgBytes">
        /// Hình chụp biển số xe lúc vào dưới dạng mảng byte
        /// </param>
        void SaveParkingInImages(long parkingInId, byte[] cfImgBytes, byte[] npImgBytes);

        /// <summary>
        /// Lưu các hình lúc xe ra, dùng parkingOutId làm tên file hình.
        /// Đồng thời, hàm này sẽ move các hình lúc xe vào sang cùng thư
        /// mục với thư mục chứa hình xe ra & đổi tên các file hình lúc
        /// vào thành parkingOutId.
        /// </summary>
        /// <param name="parkingInId">
        /// Mã record chứa thông tin xe vào
        /// </param>
        /// <param name="parkingOutId">
        /// Mã record chứa thông tin xe ra
        /// </param>
        /// <param name="cfImgBytes">
        /// Hình chụp mặt khách hàng lúc ra dưới dạng mảng byte
        /// </param>
        /// <param name="npImgBytes">
        /// Hình chụp biển số xe lúc ra dưới dạng mảng byte
        /// </param>
        /// <param name="parkingOutDate">
        /// Thời điểm xe ra
        /// </param>
        
        ///
        void SaveTimeKeepingImages(long timeKeepingId, byte[] imgBytes);

        void SaveParkingOutImages(long parkingInId, long parkingOutId, byte[] cfImgBytes, byte[] npImgBytes, DateTime parkingOutDate);

        void SaveParkingOutImages(long parkingOutId, byte[] inCfImgBytes, byte[] inNpImgBytes,
            byte[] outCfImgBytes, byte[] outNpImgBytes, DateTime parkingOutDate);

        #endregion

        #region Delete image methods

        /// <summary>
        /// Xóa hình lúc xe vào dựa vào mã lượt gởi xe.
        /// </summary>
        /// <param name="parkingInId">
        /// Mã của record chứa dữ liệu lượt gởi xe vào.
        /// </param>
        void DeleteParkingInImages(long parkingInId);

        /// <summary>
        /// Xóa các thư mục chứa hình xe đã ra.
        /// </summary>
        /// <param name="maxParkingOutDate">
        /// Các hình xe được tạo từ ngày này trở về trước xe bị xóa.
        /// </param>
        void DeleteArchievedParkingOutImages(DateTime maxParkingOutDate);

        #endregion

        #region Load image methods

        /// <summary>
        /// Lấy các đường dẫn hình của lượt xe vào
        /// </summary>
        /// <param name="parkingInId"></param>
        /// <param name="cfImgPath"></param>
        /// <param name="npImgPath"></param>
        void GetParkingInImagePaths(long parkingInId, out string cfImgPath, out string npImgPath);

        /// <summary>
        /// Tải các hình lúc xe vào dựa vào mã lượt gởi xe.
        /// </summary>
        /// <param name="parkingInId">
        /// Mã của record chứa dữ liệu lượt gởi xe vào.
        /// </param>
        /// <returns>
        /// Đối tượng chứa các hình lúc xe vào.
        /// </returns>
        ImagePairDto LoadParkingInImages(long parkingInId);

        /// <summary>
        /// Tải các hình lúc xe ra dựa vào mã lượt gởi xe
        /// </summary>
        /// <param name="parkingOutId">
        /// Mã của record chứa dữ liệu lượt gởi xe ra.
        /// </param>
        /// <param name="parkingOutDate">
        /// Thời điểm xe ra.
        /// </param>
        /// <returns>
        /// Đối tượng chứa các hình lúc xe ra.
        /// </returns>
        ImagePairDto LoadParkingOutImages(long parkingOutId, DateTime parkingOutDate);

        /// <summary>
        /// Tải các hình của lượt gởi xe đã ra (gồm hình xe lúc vào lẫn ra)
        /// </summary>
        /// <param name="parkingOutId">
        /// Mã của record chứa dữ liệu lượt gởi xe ra.
        /// </param>
        /// <param name="parkingOutDate">
        /// Thời điểm xe ra.
        /// </param>
        /// <returns>
        /// Đối tượng chứa các hình của lượt gởi xe.
        /// </returns>
        ImagesDto LoadParkingImages(long parkingOutId, DateTime? parkingOutDate);

        #endregion
    }
}