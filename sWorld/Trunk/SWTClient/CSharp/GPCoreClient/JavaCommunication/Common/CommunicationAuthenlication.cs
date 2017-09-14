using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using sWorldModel.TransportData;

namespace JavaCommunication.Common
{
    public class CommunicationAuthenlication : CommunicationCommon
    {
        private static CommunicationAuthenlication instance = new CommunicationAuthenlication();
        public static CommunicationAuthenlication Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationAuthenlication();
                }
                return instance;
            }
        }
        public CommunicationAuthenlication() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"auth";
        }

        public SessionDTO Login(string userName, string password)
        {
            String parameters = Utilites.Instance.Paramater( userName, password);
            return GetDataFromServer("alibaba", MethodNames.LOGIN, parameters, new SessionDTO().GetType()) as SessionDTO;
        }

        public SessionDTO Login(string userName, string password, string accept)
        {
            String parameters = Utilites.Instance.Paramater(userName, password, accept);
            return GetDataFromServer("alibaba", MethodNames.LOGIN, parameters, new SessionDTO().GetType()) as SessionDTO;
        }

        public int Logout(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return GetDataFromServer(session, MethodNames.GET_LOGOUT, parameters);
        }
    }
}
