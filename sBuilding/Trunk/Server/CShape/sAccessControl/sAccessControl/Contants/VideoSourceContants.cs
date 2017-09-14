using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sAccessControl.Contants
{
    internal class VideoSourceContants
    {
        public static readonly string SnapshotDirPath = Application.StartupPath + Path.DirectorySeparatorChar + "Snapshot" + Path.DirectorySeparatorChar;
        public const string ImageExtension = "jpg";
        public const uint SnapshotWidth = 400;
        public const uint SnapshotHeight = 300;

        public const int CheckConnectionDelayTime = 1000;

        public const string NotConfiguredMessage = "Chưa cấu hình thông số kết nối";
        public const string ConnectingMessage = "Đang kết nối đến camera...";
        public const string DataReceivingMessage = "Đang nhận tín hiệu từ camera";
        public const string DisconnectedMessage = "Không nhận được tín hiệu từ camera";
        public const string DisconnectingMessage = "Đang ngắt kết nối với camera...";
        public const string DisconnectedByUserMessage = "Đã ngưng nhận tín hiệu\ntheo yêu cầu của người dùng";
    }
}
