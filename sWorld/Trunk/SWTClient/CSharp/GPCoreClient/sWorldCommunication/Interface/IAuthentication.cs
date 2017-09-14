using System;
using System.Collections.Generic;
using System.Text;
using sWorldModel.Model;
using sWorldModel.TransportData;

namespace sWorldCommunication
{
    public interface IAuthentication
    {
        /// <summary>
        /// Hàm đăng nhập dựa vào username và password
        /// </summary>
        /// <param name="userName">Tên tài khoản</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>Mã session nếu đăng nhập thành công</returns>
        SessionDTO Login(string userName, string password);

        /// <summary>
        /// Hàm đăng nhập dựa vào username và password
        /// </summary>
        /// <param name="userName">Tên tài khoản</param>
        /// <param name="password">Mật khẩu</param>
        /// <param name="accept">đồng ý đăng nhập sau</param>
        /// <returns>Mã session nếu đăng nhập thành công</returns>
        SessionDTO Login(string userName, string password, string accept);

        /// <summary>
        /// Đăng xuất dựa vào mã session
        /// </summary>
        /// <param name="sessionId">Mã session của lần đăng nhập thành công trước đó</param>
        void Logout(string session);
    }
}
