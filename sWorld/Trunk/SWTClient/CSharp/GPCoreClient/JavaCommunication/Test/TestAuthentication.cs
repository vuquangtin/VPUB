using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using sWorldModel.Model;
using JavaCommunication;
using sWorldModel.TransportData;
using JavaCommunication.Test;

namespace JavaCommunication.Java
{
    public class TestAuthentication : IAuthentication
    {
        private static TestAuthentication instance = new TestAuthentication();
        public static TestAuthentication Instance
        {
            get {
                if (instance == null){
                    instance = new TestAuthentication();
                }
                return instance;
            }
        }
        private TestAuthentication()
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
            return HardCode.Instance.GetSession();
        }

        /// <summary>
        /// Đăng xuất dựa vào mã session
        /// </summary>
        /// <param name="sessionId">Mã session của lần đăng nhập thành công trước đó</param>
        public void Logout(string session) 
        { }
    }
}
