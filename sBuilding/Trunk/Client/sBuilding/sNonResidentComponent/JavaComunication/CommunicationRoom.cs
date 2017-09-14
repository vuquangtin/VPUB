using JavaCommunication;
using JavaCommunication.Common;
using sMeetingComponent.Model;
using sNonResidentComponent.Constants;
using sNonResidentComponent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.JavaComunication
{
    public class CommunicationRoom : CommunicationCommon
    {
        private static CommunicationRoom instance = new CommunicationRoom();

        public static CommunicationRoom Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationRoom();
                }
                return instance;
            }
        }

        public CommunicationRoom() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"roommg";
        }

        /// <summary>
        /// get list room
        /// //15:GET Lấy danh sách các phòng
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public List<Room> getListRoom(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);

            try
            {
                return GetDataFromServer(session, NonResidentMethodNames.GET_LISTROOM, parameters, new List<Room>().GetType()) as List<Room>;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
