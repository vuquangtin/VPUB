using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using sWorldModel.Model;
using JavaCommunication;
using JavaCommunication.Common;
using sWorldModel.TransportData;
using sWorldCommunication;

namespace JavaCommunication.Java
{
    public class JavaAuthentication : IAuthentication
    {
        private static JavaAuthentication instance = new JavaAuthentication();
        public static JavaAuthentication Instance
        {
            get {
                if (instance == null){
                    instance = new JavaAuthentication();
                }
                return instance;
            }
        }
        private JavaAuthentication()
        { 
        }

        /// <summary>
        /// Hàm đăng nhập dựa vào username và password
        /// </summary>
        /// <param name="userName">Tên tài khoản</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>Mã session nếu đăng nhập thành công</returns>
        public SessionDTO Login(string userName, string password) 
        {
            return CommunicationAuthenlication.Instance.Login(userName, password);
        }

        /// <summary>
        /// Hàm đăng nhập dựa vào username và password và đồng ý đăng nhập nếu có người đăng nhập trước
        /// </summary>
        /// <param name="userName">Tên tài khoản</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>Mã session nếu đăng nhập thành công</returns>
        public SessionDTO Login(string userName, string password, string accept)
        {
            return CommunicationAuthenlication.Instance.Login(userName, password, accept);
        }

        /// <summary>
        /// Đăng xuất dựa vào mã session
        /// </summary>
        /// <param name="sessionId">Mã session của lần đăng nhập thành công trước đó</param>
        public void Logout(string session) 
        {
            CommunicationAuthenlication.Instance.Logout(session);
        }
    }
}
