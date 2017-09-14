using CommonHelper.Utils;
using CommonLogger;
using ParkingModel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace ImageAccessor.DiskRepository
{
    /// <summary>
    /// Cấu trúc thư mục chứa hình như sau:
    /// + (ParkingDirPath)
    /// + -- CurrentDirPath
    /// + -- ArchieveDirPath
    /// + -- -- ddMMyyyy
    /// 
    /// Các từ viết tắt:
    /// - Image: img
    /// - Customer Face: cf
    /// - Number Plate: np
    /// - Source: src
    /// - Destination: dst
    /// </summary>
    internal class DiskImageRepository : IImageRepository
    {
        #region Private properties

        private const int MaxImageSize = 50;    // in kilobytes
        private const int MaxImageWidth = 400;  // in pixels
        private const int MaxImageHeight = 300; // in pixels

        private readonly ImageFormat DefaultImageFormat = ImageFormat.Jpeg;
        private readonly string DefaultImageFormatExt = "jpg";

        private readonly string ParkingDirPath;
        private readonly string CurrentDirPath;
        private readonly string ArchieveDirPath;

        private const string DirPathConfigKey = "image_dir_path";
        private const string CurrentDirName = "Current";
        private const string ArchieveDirName = "Archieved";
        private const string ArchieveDateFormat = "yyyyMMdd";

        #endregion

        #region Public constructor

        public DiskImageRepository()
        {
            try
            {
                ParkingDirPath = ConfigurationManager.AppSettings[DirPathConfigKey];
            }
            catch (ConfigurationErrorsException ex)
            {
                LogManager.LogError(ex);
                throw;
            }
            catch (Exception ex)
            {
                LogManager.LogError(ex);
                throw;
            }
            CurrentDirPath = ParkingDirPath + "\\" + CurrentDirName;
            ArchieveDirPath = ParkingDirPath + "\\" + ArchieveDirName;
        }

        #endregion

        #region Save image methods

        public string SaveParkingInImages(byte[] cfImgBytes, byte[] npImgBytes)
        {
            // Tạo unique ID cho các hình mới
            string imgId = ImageIdManager.GenerateNewId();

            // Tạo đường dẫn lưu hình
            string cfImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInCustomerFace);
            string npImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInNumberPlate);

            // Lưu hình vào ổ cứng
            SaveImageToDisk(cfImgPath, cfImgBytes);
            SaveImageToDisk(npImgPath, npImgBytes);

            // Trả về id của image đã lưu
            return imgId;
        }

        public void SaveParkingOutImages(byte[] cfImgBytes, byte[] npImgBytes, string imgId, DateTime parkingOutDate)
        {
            // Tạo lại đường dẫn các hình lúc xe vào
            string cfImgPath_in_src = CreateParkingInImagePath(imgId, ImageRole.ParkingInCustomerFace);
            string npImgPath_in_src = CreateParkingInImagePath(imgId, ImageRole.ParkingInNumberPlate);

            // Tạo đường dẫn cho các hình sẽ chứa trong thư mục xe ra
            string cfImgPath_in_dst = CreateParkingInImagePath(imgId, ImageRole.ParkingInCustomerFace);
            string npImgPath_in_dst = CreateParkingInImagePath(imgId, ImageRole.ParkingInNumberPlate);
            string cfImgPath_out = CreateParkingOutImagePath(imgId, parkingOutDate, ImageRole.ParkingOutCustomerFace);
            string npImgPath_out = CreateParkingOutImagePath(imgId, parkingOutDate, ImageRole.ParkingOutNumberPlate);

            // Lưu hình chụp xe ra
            SaveImageToDisk(cfImgPath_out, cfImgBytes);
            SaveImageToDisk(npImgPath_out, npImgBytes);

            // Move hình chụp xe vào đến thư mục mới
            if (File.Exists(cfImgPath_in_src))
            {
                File.Copy(cfImgPath_in_src, cfImgPath_in_dst);
                ImageDeletor.Instance.AddImagePath(cfImgPath_in_src);
            }
            if (File.Exists(npImgPath_in_src))
            {
                File.Copy(npImgPath_in_src, npImgPath_in_dst);
                ImageDeletor.Instance.AddImagePath(npImgPath_in_src);
            }
        }

        #endregion

        #region Load image methods

        public ParkingImagePairDto LoadParkingInImages(string imgId)
        {
            // KHởi tạo trước đối tượng chứa các hình
            ParkingImagePairDto result = new ParkingImagePairDto();
            
            // Xác định đường dẫn các hình
            string cfImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInCustomerFace);
            string npImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInNumberPlate);

            // Load hình chụp mặt khách & hình chụp biển số xe (nếu có)
            if (cfImgPath != null)
            {
                result.CustomerFaceImgBytes = FileUtils.ReadBytesFromFile(cfImgPath);
            }
            if (npImgPath != null)
            {
                result.NumberPlateImgBytes = FileUtils.ReadBytesFromFile(npImgPath);
            }

            // Trả về kết quả
            return result;
        }

        public ParkingImagePairDto LoadParkingOutImages(string imgId)
        {
        }

        public ParkingImageDto LoadParkingImages(string imgId)
        {
        }

        #endregion

        #region Private utility methods

        private string CreateParkingInImagePath(string imgId, ImageRole imgRole)
        {
            return string.Format("{0}\\{1}_{2}.{3}", CurrentDirPath, imgId, (byte)imgRole, DefaultImageFormatExt);
        }

        private string CreateParkingOutImagePath(string imageId, DateTime parkingOutDate, ImageRole imgRole)
        {
            return string.Format("{0}\\{1}\\{2}_{3}.{4}", ArchieveDirPath, parkingOutDate.ToString("yyyyMMdd"), (byte)imgRole, DefaultImageFormat);
        }

        private void SaveImageToDisk(string imgFilePath, byte[] imgData)
        {
            /* Để tiết kiệm dung lượng đĩa, server chỉ cho phép lưu image với
             * kích thước 400 x 300. Nhưng image khi transfer thông qua WCF 
             * ở dạng byte array. Nếu chuyển từ byte array sang image thì tốn 
             * thời gian. Do đó, kiểm tra dung lượng byte array, nếu vượt quá 
             * 50KB thì mới chuyển sang kiểu Image và resize.
             * 
             * Notes: thường hình camera khi lưu định dạng jpeg với kích thước
             * 400 x 300 sẽ có dung lượng khoảng 10 - 30KB.
             */

            // Save hình chụp mặt khách hàng
            if ((imgData.Length / 1024) > MaxImageSize)
            {
                Image img = ImageUtils.ByteArrayToImage(imgData);
                img = ImageUtils.ResizeImage(img, 400, 300);
                ImageUtils.WriteImageToFile(imgFilePath, img, DefaultImageFormat);
            }
            else
            {
                FileUtils.WriteBytesToFile(imgFilePath, imgData);
            }
        }

        #endregion
    }
}