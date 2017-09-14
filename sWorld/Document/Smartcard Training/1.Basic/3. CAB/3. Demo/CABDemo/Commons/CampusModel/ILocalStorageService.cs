using System;

namespace CampusModel
{
    public interface ILocalStorageService
    {
        /// <summary>
        /// Lưu trữ session id hiện tại. Dữ liệu này luôn được lưu trong cache
        /// và mặc định là null.
        /// </summary>
        string CurrentSessionId { get; set; }

        /// <summary>
        /// Lưu trữ tên đăng nhập của người dùng hiện tại. Dữ liệu này luôn được
        /// lưu trong cache và mặc định là null.
        /// </summary>
        string CurrentUserName { get; set; }

        /// <summary>
        /// Lưu một object bất kỳ với thời gian mặc định 5' và không mã hóa
        /// </summary>
        /// <param name="obj">Object cần lưu</param>
        /// <returns>Alias của object trong cache. Alias này sẽ được dùng 
        /// để thao tác với object sau này</returns>
        string StoreObject(object obj);

        void StoreObject(string alias, object obj);

        /// <summary>
        /// Lưu một object với thời gian tự định trước và không mã hóa
        /// </summary>
        /// <param name="obj">Object cần lưu</param>
        /// <param name="duration">Khoảng thời gian mà object có hiệu lực;
        /// sau khoảng thời gian này, object sẽ bị xóa khỏi cache</param>
        /// <returns>Alias của object trong cache. Alias này sẽ được dùng 
        /// để thao tác với object sau này</returns>
        string StoreObject(object obj, TimeSpan duration);

        void StoreObject(string alias, object obj, TimeSpan duration);

        /// <summary>
        /// Lưu một object cho đến khi bị remove hoặc tắt chương trình
        /// và không có mã hóa.
        /// </summary>
        /// <param name="obj">Object cần lưu</param>
        /// <returns>Alias của object trong cache. Alias này sẽ được dùng 
        /// để thao tác với object sau này</returns>
        string StoreObjectPermanently(object obj);

        void StoreObjectPermanently(string alias, object obj);

        /// <summary>
        /// Kiểm tra xem cache có chứa object có alias cho trước hay không
        /// </summary>
        /// <param name="alias">Alias của object cần tìm</param>
        /// <returns>True nếu cache có chứa object; ngược lại là false</returns>
        bool HasContains(string alias);

        /// <summary>
        /// Xóa một object ra khỏi cache dựa vào alias của object đó.
        /// Nếu object không tồn tại, hàm này sẽ không tung exception.
        /// </summary>
        /// <param name="alias">Alias của object cần xóa</param>
        void ClearObject(string alias);

        /// <summary>
        /// Lấy về một object dựa vào alias của nó.
        /// </summary>
        /// <param name="alias">Alias của object cần xóa</param>
        /// <returns>Giá trị của object đó; null nếu không tìm thấy object
        /// dựa vào alias</returns>
        object GetObject(string alias);

        /// <summary>
        /// Xóa tất cả object đang lưu
        /// </summary>
        void ClearAll();
    }
}
