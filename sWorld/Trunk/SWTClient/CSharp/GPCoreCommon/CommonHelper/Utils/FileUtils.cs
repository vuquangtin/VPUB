using System;
using System.IO;

namespace CommonHelper.Utils
{
    public class FileUtils
    {
        public static byte[] ReadBytesFromFile(string filePath)
        {
            // Load metadata của file
            FileInfo fileInfo = new FileInfo(filePath);

            // Kiểm tra file tồn tại hay không
            if (!fileInfo.Exists)
            {
                return null;
            }

            // Tạo mảng byte sẽ chứa dữ liệu của file
            byte[] dataBytes = new byte[fileInfo.Length];

            // Đọc dữ liệu file vào mảng byte, dùng read access
            using (FileStream fs = fileInfo.OpenRead())
            {
                try
                {
                    fs.Read(dataBytes, 0, dataBytes.Length);
                }
                catch (FileNotFoundException)
                {
                    return null;
                }
                catch (IOException)
                {
                    return null;
                }
            }

            return dataBytes;
        }

        public static void WriteBytesToFile(string filePath, byte[] bytes)
        {
            var fs = new BinaryWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write));
            fs.Write(bytes);
            fs.Close();
            //fs.Dispose();
        }
    }
}
