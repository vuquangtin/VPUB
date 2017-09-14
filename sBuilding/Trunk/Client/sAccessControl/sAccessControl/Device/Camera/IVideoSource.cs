using sAccessControl.Device.Camera;
using sAccessControl.Enums;
using System;
using System.Drawing;

namespace sAccessControl.Device.Camera
{
    internal interface IVideoSource : IDisposable
    {
        /// <summary>
        /// Kiểu kết nối đến nguồn phát video
        /// </summary>
        CameraConnectionType ConnectionType { get; }
        
        /// <summary>
        /// Nguồn phát video
        /// </summary>
        string Source { get; set; }

        /// <summary>
        /// Canvas là nơi mà hình ảnh video được hiển thị
        /// </summary>
        IntPtr Canvas { get; set; }

        /// <summary>
        /// Cho biết có đang nhận được tín hiệu video hay không
        /// </summary>
        bool IsPlaying { get; }

        /// <summary>
        /// Cho biết đối tượng video source đã bị hủy hay chưa.
        /// Sau khi bị hủy, không được phép dùng lại đối tượng.
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Kết nối & nhận tín hiệu camera. Lưu ý là hầu hết các kiểu kết nối
        /// video đều hiện thực "time-to-live". Do đó, không chắc sau khi gọi
        /// hàm này thì sẽ nhận được tín hiệu video ngay lập tức.
        /// </summary>
        void Play();

        /// <summary>
        /// Ngừng nhận tín hiệu video
        /// </summary>
        void Stop();

        /// <summary>
        /// Chụp hình
        /// </summary>
        /// <returns></returns>
        Image TakeSnapshot();

        event VideoSourceEventHandler Played;

        /// <summary>
        /// Event cho biết đã mất kết nối với nguồn phát video
        /// </summary>
        event VideoSourceEventHandler Stopped;
    }
}