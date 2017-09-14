using sMeetingComponent.Interface;
using System;
using System.Collections.Generic;
using sMeetingComponent.Model;
using sMeetingComponent.JavaComunication;
using sMeetingComponent.Model.CustomObj;
using sMeetingComponent.Model.CustomObj.PersonHaveBarcode;
using sMeetingComponent.Model.CustomObj.PersonNotBarcode;

namespace sMeetingComponent.Java
{
    public class JavaAttendMeeting : IAttendMeeting
    {
        private static JavaAttendMeeting instance = new JavaAttendMeeting();

        public static JavaAttendMeeting Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaAttendMeeting();
                }
                return instance;
            }
        }

        private JavaAttendMeeting()
        {
        }

        public int insertEventAttendMeeting(string session, List<EventAttendMeeting> eventAttendMeeting)
        {
            return CommunicationAttendMeeting.Instance.insertEventAttendMeeting(session, eventAttendMeeting);
        }

        public NumberObj checkInOutEventAttendMeeting(string session, String barcode)
        {
            return CommunicationAttendMeeting.Instance.checkInOutEventAttendMeeting(session, barcode);
        }

        public int insertAttendMeetingNotBarcode(string session, PersonNotBarcodeObj personNotBarcodeObj)
        {
            return CommunicationAttendMeeting.Instance.insertAttendMeetingNotBarcode(session, personNotBarcodeObj);
        }

        public int insertEventAttendMeetingEnterprise(string session, List<NonResident> listNoresident)
        {
            return CommunicationAttendMeeting.Instance.insertEventAttendMeetingEnterprise(session, listNoresident);
        }
    }
}
