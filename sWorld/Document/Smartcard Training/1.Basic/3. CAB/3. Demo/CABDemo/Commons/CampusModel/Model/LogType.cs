namespace CampusModel.Model
{
    /// <summary>
    /// Cấp độ của log
    /// </summary>
    public enum LogType : int
    {
        Debug = 1,      //Log dành cho việc test hệ thống: tốc độ truy xuất, dữ liệu trả về...
        Info = 2,       //Log thông báo một công việc đã hoàn tất (dù thành công hay không)
        Error = 3,      //Log thông báo lỗi trong quá trình xử lý của hệ thống
    }
}