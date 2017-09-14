using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ImageAccessor.DiskRepository
{
    /// <summary>
    /// Class quản lý việc xóa file trên ổ cứng.
    /// 
    /// Do việc xóa file phụ thuộc nhiều vào tốc độ xử lý của phần cứng,
    /// nên thay vì thực hiện xóa file ngay khi có request, chương trình
    /// sẽ đưa đường dẫn (của file sẽ xóa) vào một hàng đợi. Một tiến
    /// trình sẽ kiểm tra danh sách item trong hàng đợi và thực hiện công
    /// việc xóa hình. Tiến trình này sẽ được chạy theo khoảng thời gian.
    /// Như vậy, khi có một request được gởi đến class này, file sẽ không
    /// chắc được xóa ngay lập tức (thật sự cũng không cần phải xóa ngay).
    /// </summary>
    internal sealed class FileDeletor
    {
        private static FileDeletor instance = new FileDeletor();

        private Queue<string> pathQueue = new Queue<string>();
        private Timer deleteTimer = null;
        private const int dueTime = 0;      // in miliseconds
        private const int period = 60000;   // in miliseconds

        private FileDeletor()
        {
            deleteTimer = new Timer(new TimerCallback(Execute), null, dueTime, period);
        }

        public static FileDeletor Instance
        {
            get { return instance; }
        }

        public void AddPath(string path)
        {
            pathQueue.Enqueue(path);
        }

        private void Execute(object state)
        {
            /* Trong khi hàm Execute này được chạy, có thể queue sẽ được
             * enqueue thêm phần tử mới. Mặc khác, với các file vì một
             * lý do nào đó không xóa được ngay sẽ vẫn được giữ lại trong
             * queue. Do đó, cần giới hạn số vòng lặp trong 1 lần chạy 
             * thay vì cứ chạy hoài mà không biết khi nào sẽ ngừng được.
             * 
             * Có thể giá trị count này sẽ không chính xác nhưng không 
             * sao cả. Những item mới được enqueue sẽ được xử lý trong 
             * lần chạy timer kế tiếp. Nhưng cần đảm bảo pathQueue sẽ
             * không bị dequeue tại bất kỳ chỗ nào khác ngoài hàm này.
             * 
             * Đối với các file không xóa được ngay, có thể do đang bị 
             * lock bởi một tiến trình khác, sẽ được xóa vào các lần chạy
             * timer kế tiếp.
             */
            int count = pathQueue.Count;
            string path = null;

            while (count-- > 0)
            {
                path = pathQueue.Peek();

                try
                {
                    FileAttributes attr = File.GetAttributes(path);

                    // Kiểm tra đây là file hay directory
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        Directory.Delete(path, true);
                    }
                    else
                    {
                        File.Delete(path);
                    }
                }
                catch (FileNotFoundException)
                {
                }
                catch (DirectoryNotFoundException)
                {
                }
                catch (IOException)
                {
                    pathQueue.Enqueue(path);
                }
                catch (UnauthorizedAccessException)
                {
                    pathQueue.Enqueue(path);
                }
                catch (Exception)
                {
                    pathQueue.Enqueue(path);
                }
                finally
                {
                    pathQueue.Dequeue();
                }
            }
        }
    }
}