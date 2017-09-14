using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CommonHelper.Utils
{
    public static class ImageUtils
    {
        public static byte[] ImageToByteArray(Image img)
        {
            if (img == null)
            {
                return null;
            }

            MemoryStream ms = new MemoryStream();
            try
            {
                img.Save(ms, ImageFormat.Jpeg);
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (ExternalException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }

            return ms.ToArray();
        }

        public static Image ByteArrayToImage(byte[] bArray)
        {
            if (bArray == null)
            {
                return null;
            }

            MemoryStream ms = new MemoryStream(bArray);
            try
            {
                return Image.FromStream(ms);
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ImageToBase64(Image image)
        {
            if (image == null)
                return string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                image = ImageUtils.ResizeImage(image, 400, 300);
                // Convert Image to byte[]
                image.Save(ms, ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public static Image Base64ToImage(string imgBase64String)
        {
            if (string.IsNullOrEmpty(imgBase64String))
                return null;
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(imgBase64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            if (srcImage.Width == newWidth && srcImage.Height == newHeight)
            {
                return srcImage;
            }
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
            }
            return newImage;
        }

        public static Image LoadImageFromFile(string filePath)
        {
            /* Dùng cách load data của file rồi convert sang image
             * chứ không dùng hàm Image.FromFile() vì hàm này sẽ
             * lock file hình, các process khác (nếu có) sẽ không 
             * truy cập được.
             */
            byte[] imageData = FileUtils.ReadBytesFromFile(filePath);

            // Chuyển dữ liệu mảng byte thành đối tượng Image và trả về
            return ImageUtils.ByteArrayToImage(imageData);
        }

        public static void WriteImageToFile(string filePath, Image img, ImageFormat format)
        {
            img.Save(filePath, format);
        }
    }
}
