using CommonHelper.Utils;
using CommonLogger;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

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

        private const int MaxImageSize = 30;    // in kilobytes
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

        #endregion Private properties

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

            if (!ParkingDirPath.EndsWith("\\"))
            {
                ParkingDirPath += "\\";
            }

            CurrentDirPath = ParkingDirPath + CurrentDirName;
            ArchieveDirPath = ParkingDirPath + ArchieveDirName;
        }

        #endregion Public constructor

        #region IImageRepository properties

        public List<long> CurrentParkingInIds
        {
            get
            {
                if (!Directory.Exists(CurrentDirPath))
                {
                    return new List<long>();
                }

                // Lấy ra danh sách các tên file trong thư mục current
                string[] fileNames = Directory.GetFiles(CurrentDirPath, string.Format("*.{0}", DefaultImageFormatExt))
                    .Select(path => Path.GetFileName(path)).ToArray();

                // Chuyển đổi tên file thành parkingInId
                List<long> result = new List<long>();
                string imageId = null;
                long parkingInId = 0;
                foreach (string fn in fileNames)
                {
                    imageId = fn.Substring(0, fn.IndexOf('_'));

                    if (long.TryParse(imageId, out parkingInId) && !result.Contains(parkingInId))
                    {
                        result.Add(parkingInId);
                    }
                }

                return result;
            }
        }

        public string Address
        {
            get
            {
                return ParkingDirPath.Substring(0, ParkingDirPath.IndexOf('\\'));
            }
        }

        public float RemainingStoragePercentage
        {
            get
            {
                if (!Directory.Exists(ParkingDirPath))
                {
                    Directory.CreateDirectory(ParkingDirPath);
                }

                ulong freeBytesAvailable;
                ulong totalNumberOfBytes;
                ulong totalNumberOfFreeBytes;

                bool success = GetDiskFreeSpaceEx(ParkingDirPath,
                    out freeBytesAvailable, out totalNumberOfBytes,
                    out totalNumberOfFreeBytes);

                if (!success)
                {
                    return 0F;
                }

                return (float)freeBytesAvailable / (float)totalNumberOfBytes;
            }
        }

        #endregion IImageRepository properties

        #region IImageRepository methods

        public void SaveParkingInImages(long parkingInId, byte[] cfImgBytes, byte[] npImgBytes)
        {
            // Image ID cũng chính là parkingInId
            string imgId = parkingInId.ToString();

            // Tạo đường dẫn lưu hình
            string cfImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInCustomerFace);
            string npImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInNumberPlate);

            // Lưu hình vào ổ cứng
            SaveImageToDisk(cfImgPath, cfImgBytes);
            SaveImageToDisk(npImgPath, npImgBytes);
        }

        public void SaveParkingOutImages(long parkingInId, long parkingOutId, byte[] cfImgBytes, byte[] npImgBytes, DateTime parkingOutDate)
        {
            // Tạo lại đường dẫn các hình lúc xe vào.
            // Image ID cũng chính là parkingInId.
            string inImgId = parkingInId.ToString();
            string cfImgPath_in_src = CreateParkingInImagePath(inImgId, ImageRole.ParkingInCustomerFace);
            string npImgPath_in_src = CreateParkingInImagePath(inImgId, ImageRole.ParkingInNumberPlate);

            // Tạo đường dẫn cho các hình sẽ chứa trong thư mục xe ra.
            // Image ID cũng chính là parkingOutId.
            string outImgId = parkingOutId.ToString();
            string cfImgPath_in_dst = CreateParkingOutImagePath(outImgId, ImageRole.ParkingInCustomerFace, parkingOutDate);
            string npImgPath_in_dst = CreateParkingOutImagePath(outImgId, ImageRole.ParkingInNumberPlate, parkingOutDate);
            string cfImgPath_out = CreateParkingOutImagePath(outImgId, ImageRole.ParkingOutCustomerFace, parkingOutDate);
            string npImgPath_out = CreateParkingOutImagePath(outImgId, ImageRole.ParkingOutNumberPlate, parkingOutDate);

            // Lưu hình chụp xe ra
            SaveImageToDisk(cfImgPath_out, cfImgBytes);
            SaveImageToDisk(npImgPath_out, npImgBytes);

            // Move hình chụp xe vào đến thư mục mới
            if (File.Exists(cfImgPath_in_src))
            {
                File.Copy(cfImgPath_in_src, cfImgPath_in_dst, true);
                FileDeletor.Instance.AddPath(cfImgPath_in_src);
            }
            if (File.Exists(npImgPath_in_src))
            {
                File.Copy(npImgPath_in_src, npImgPath_in_dst, true);
                FileDeletor.Instance.AddPath(npImgPath_in_src);
            }
        }

        public void SaveParkingOutImages(long parkingOutId, byte[] inCfImgBytes, byte[] inNpImgBytes,
            byte[] outCfImgBytes, byte[] outNpImgBytes, DateTime parkingOutDate)
        {
            // Tạo đường dẫn cho các hình sẽ chứa trong thư mục xe ra.
            // Image ID cũng chính là parkingOutId.
            string outImgId = parkingOutId.ToString();
            string cfImgPath_in = CreateParkingOutImagePath(outImgId, ImageRole.ParkingInCustomerFace, parkingOutDate);
            string npImgPath_in = CreateParkingOutImagePath(outImgId, ImageRole.ParkingInNumberPlate, parkingOutDate);
            string cfImgPath_out = CreateParkingOutImagePath(outImgId, ImageRole.ParkingOutCustomerFace, parkingOutDate);
            string npImgPath_out = CreateParkingOutImagePath(outImgId, ImageRole.ParkingOutNumberPlate, parkingOutDate);

            // Lưu hình chụp xe vào
            SaveImageToDisk(cfImgPath_in, inCfImgBytes);
            SaveImageToDisk(npImgPath_in, inNpImgBytes);

            // Lưu hình chụp xe ra
            SaveImageToDisk(cfImgPath_out, outCfImgBytes);
            SaveImageToDisk(npImgPath_out, outNpImgBytes);
        }

        public void DeleteParkingInImages(long parkingInId)
        {
            // Image ID cũng chính là parkingInId
            string imgId = parkingInId.ToString();

            // Xác định đường dẫn các hình
            string cfImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInCustomerFace);
            string npImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInNumberPlate);

            // Thêm đường dẫn các hình cần xóa vào hàng đợi
            FileDeletor.Instance.AddPath(cfImgPath);
            FileDeletor.Instance.AddPath(npImgPath);
        }

        public void DeleteArchievedParkingOutImages(DateTime maxParkingOutDate)
        {
            if (!Directory.Exists(ArchieveDirPath))
            {
                return;
            }

            // Lấy ra danh sách các thư mục
            string[] dirs = Directory.GetDirectories(ArchieveDirPath);

            DateTime test;
            string dirName;

            // Duyệt từng thư mục, lấy ra danh sách các thư mục sớm hơn ngày đã định
            foreach (string d in dirs)
            {
                // Lấy ra tên thư mục
                dirName = d.Substring(d.LastIndexOf("\\") + 1);

                if (DateTime.TryParseExact(dirName, "yyyyMMdd", null, DateTimeStyles.None, out test))
                {
                    if (test <= maxParkingOutDate)
                    {
                        FileDeletor.Instance.AddPath(d);
                    }
                }
            }
        }

        public void GetParkingInImagePaths(long parkingInId, out string cfImgPath, out string npImgPath)
        {
            // Image ID cũng chính là parkingInId
            string imgId = parkingInId.ToString();

            // Tạo đường dẫn lưu hình
            cfImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInCustomerFace);
            npImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInNumberPlate);

            // Kiểm tra file tồn tại hay không
            if (!File.Exists(cfImgPath))
            {
                cfImgPath = null;
            }
            if (!File.Exists(npImgPath))
            {
                npImgPath = null;
            }
        }

        public ImagePairDto LoadParkingInImages(long parkingInId)
        {
            // Khởi tạo trước đối tượng chứa các hình
            ImagePairDto result = new ImagePairDto();

            // Image ID cũng chính là parkingInId
            string imgId = parkingInId.ToString();

            // Xác định đường dẫn các hình
            string cfImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInCustomerFace);
            string npImgPath = CreateParkingInImagePath(imgId, ImageRole.ParkingInNumberPlate);

            // Load hình chụp mặt khách & hình chụp biển số xe (nếu có)
            if (cfImgPath != null)
            {
                result.FaceImageBytes = FileUtils.ReadBytesFromFile(cfImgPath);
            }
            if (npImgPath != null)
            {
                result.PlateImageBytes = FileUtils.ReadBytesFromFile(npImgPath);
            }

            // Trả về kết quả
            return result;
        }

        public ImagePairDto LoadParkingOutImages(long parkingOutId, DateTime parkingOutDate)
        {
            // Khởi tạo trước đối tượng chứa các hình
            ImagePairDto result = new ImagePairDto();

            // Image ID cũng chính là parkingOutId
            string imgId = parkingOutId.ToString();

            // Xác định đường dẫn các hình
            string cfImgPath = CreateParkingOutImagePath(imgId, ImageRole.ParkingOutCustomerFace, parkingOutDate);
            string npImgPath = CreateParkingOutImagePath(imgId, ImageRole.ParkingOutNumberPlate, parkingOutDate);

            // Load hình chụp mặt khách & hình chụp biển số xe (nếu có)
            if (cfImgPath != null)
            {
                result.FaceImageBytes = FileUtils.ReadBytesFromFile(cfImgPath);
            }
            if (npImgPath != null)
            {
                result.PlateImageBytes = FileUtils.ReadBytesFromFile(npImgPath);
            }

            // Trả về kết quả
            return result;
        }

        public ImagesDto LoadParkingImages(long parkingOutId, DateTime? parkingOutDate)
        {
            // Khởi tạo trước đối tượng chứa các hình
            ImagesDto result = new ImagesDto();
            result.Images = new ImagePairDto();
            result.ParkingOutImages = new ImagePairDto();

            // Các biến tạm
            string cfImgPath_in, npImgPath_in, cfImgPath_out, npImgPath_out;
            string imgId = parkingOutId.ToString();

            // Xác định đường dẫn các hình
            if (parkingOutDate.HasValue)
            {
                cfImgPath_in = CreateParkingOutImagePath(imgId, ImageRole.ParkingInCustomerFace, parkingOutDate.Value);
                npImgPath_in = CreateParkingOutImagePath(imgId, ImageRole.ParkingInNumberPlate, parkingOutDate.Value);
                cfImgPath_out = CreateParkingOutImagePath(imgId, ImageRole.ParkingOutCustomerFace, parkingOutDate.Value);
                npImgPath_out = CreateParkingOutImagePath(imgId, ImageRole.ParkingOutNumberPlate, parkingOutDate.Value);
            }
            else
            {
                cfImgPath_in = CreateParkingInImagePath(imgId, ImageRole.ParkingInCustomerFace);
                npImgPath_in = CreateParkingInImagePath(imgId, ImageRole.ParkingInNumberPlate);
                cfImgPath_out = npImgPath_out = null;
            }

            // Load hình
            if (cfImgPath_in != null)
            {
                result.Images.FaceImageBytes = FileUtils.ReadBytesFromFile(cfImgPath_in);
            }
            if (npImgPath_in != null)
            {
                result.Images.PlateImageBytes = FileUtils.ReadBytesFromFile(npImgPath_in);
            }
            if (cfImgPath_out != null)
            {
                result.ParkingOutImages.FaceImageBytes = FileUtils.ReadBytesFromFile(cfImgPath_out);
            }
            if (npImgPath_out != null)
            {
                result.ParkingOutImages.PlateImageBytes = FileUtils.ReadBytesFromFile(npImgPath_out);
            }

            // Trả về kết quả
            return result;
        }

        #endregion IImageRepository methods

        #region Private utility methods

        private string CreateParkingInImagePath(string imgId, ImageRole imgRole)
        {
            return string.Format("{0}\\{1}_{2}.{3}", CurrentDirPath, imgId, (byte)imgRole, DefaultImageFormatExt);
        }

        private string CreateParkingOutImageDirPath(DateTime parkingOutDate)
        {
            return string.Format("{0}\\{1}\\", ArchieveDirPath, parkingOutDate.ToString("yyyyMMdd"));
        }

        private string CreateParkingOutImagePath(string imgId, ImageRole imgRole, DateTime parkingOutDate)
        {
            return string.Format("{0}\\{1}\\{2}_{3}.{4}", ArchieveDirPath, parkingOutDate.ToString("yyyyMMdd"), imgId, (byte)imgRole, DefaultImageFormat);
        }

        private void SaveImageToDisk(string imgFilePath, byte[] imgData)
        {
            /* Để tiết kiệm dung lượng đĩa, server chỉ cho phép lưu image với
             * kích thước 400 x 300. Nhưng image khi transfer thông qua WCF
             * ở dạng byte array. Nếu chuyển từ byte array sang image thì tốn
             * thời gian. Do đó, kiểm tra dung lượng byte array, nếu vượt quá
             * 30KB thì mới chuyển sang kiểu Image và resize.
             *
             * Notes: thường hình camera khi lưu định dạng jpeg với kích thước
             * 400 x 300 sẽ có dung lượng khoảng 10 - 30KB.
             */

            // Kiểm tra thư mục chứa hình đã tồn tại chưa
            string dirPath = imgFilePath.Substring(0, imgFilePath.LastIndexOf('\\'));
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            // Nếu dữ liệu là null thì không cần lưu
            if (imgData == null)
            {
                return;
            }

            // Save hình chụp mặt khách hàng
            if ((imgData.Length / 1024) > MaxImageSize)
            {
                using (Image originator = ImageUtils.ByteArrayToImage(imgData))
                using (Image resized = ImageUtils.ResizeImage(originator, 400, 300))
                {
                    ImageUtils.WriteImageToFile(imgFilePath, resized, DefaultImageFormat);
                }
            }
            else
            {
                FileUtils.WriteBytesToFile(imgFilePath, imgData);
            }
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
           out ulong lpFreeBytesAvailable,
           out ulong lpTotalNumberOfBytes,
           out ulong lpTotalNumberOfFreeBytes);

        #endregion Private utility methods
    }
}