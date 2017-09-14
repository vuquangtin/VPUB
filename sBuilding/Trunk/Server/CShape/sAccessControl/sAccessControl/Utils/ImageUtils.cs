using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace sAccessControl.Utils
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
