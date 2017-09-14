using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Reader.MCR02
{
    /// <summary>
    /// Lớp hiện thực cho việc đọc Terminal Request từ MCR Reader.
    /// </summary>

    public class TerminalRequest
    {
        #region Properties

        //char dùng để cắt chuỗi.
        private char[] seperator1 = { ',' };
        private char[] seperator2 = { '=' };

        //private holder
        private string _devID = string.Empty;
        private string _UID = string.Empty;

        public string devID
        {
            get
            {
                if (!string.IsNullOrEmpty(_devID))
                    return _devID;
                return string.Empty;
            }
        }

        public string UID
        {
            get
            {
                if (!string.IsNullOrEmpty(_UID))
                    return _UID;
                return string.Empty;
            }
        }

        #endregion

        //Constructor, mặc định khi tạo phải truyền vào request data.
        public TerminalRequest(string request)
        {
            readTerminalRequest(request);
        }

        //dùng để đọc request data.
        public void readTerminalRequest(string request)
        {
            request = request.Trim();

            string[] temp = request.Split(seperator1);
            _devID = temp[0];
            temp = temp[1].Split(seperator2);
            _UID = temp[1];
        }
    }
}
