using sMeetingComponent.Model;
using sNonResidentComponent.Interface;
using sNonResidentComponent.JavaComunication;
using sNonResidentComponent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Java
{
    public class JavaRoom : IRoom
    {
        private static JavaRoom instance = new JavaRoom();

        public static JavaRoom Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaRoom();
                }
                return instance;
            }
        }

        private JavaRoom()
        {
        }

        public List<Room> getListRoom(string session)
        {
            return CommunicationRoom.Instance.getListRoom(session);
        }
    }
}
