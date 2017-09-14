using JavaCommunication;
using JavaCommunication.Common;
using sMeetingComponent.Constants;
using sMeetingComponent.Model;
using sMeetingComponent.Model.CustomObj;
using sMeetingComponent.Model.CustomObj.PersonHaveBarcode;
using sMeetingComponent.Model.CustomObj.PersonNotBarcode;
using System;
using System.Collections.Generic;

namespace sMeetingComponent.JavaComunication
{
    public class CommunicationAttendMeeting : CommunicationCommon
    {

        private static CommunicationAttendMeeting instance = new CommunicationAttendMeeting();

        public static CommunicationAttendMeeting Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationAttendMeeting();
                }
                return instance;
            }
        }

        public CommunicationAttendMeeting() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"attendmeetingmg";
        }

        /// <summary>
        /// 5. Thêm thông tin người tham dự họp
        /// insert attendmeeting
        /// thêm người tham dự cuộc họp
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventAttendMeeting"></param>
        /// <returns></returns>
        public int insertEventAttendMeeting(string session, List<EventAttendMeeting> eventAttendMeeting)
        {
            string parameters = Utilites.Instance.Paramater(session);

            int i = 0;
            try
            {
                i = PostDataFromServer(session, MeetingMethodNames.INSERT_MEETING_ATTENDMEETING, parameters, eventAttendMeeting);
            }
            catch (Exception e)
            {
            }
            return i;
        }

        /// <summary>
        /// 2.kiểm tra xem thư mời này có thông tin không
        /// check barcode of attendmeeting
        /// </summary>
        /// <param name="session"></param>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public NumberObj checkInOutEventAttendMeeting(string session, String barcode)
        {
            string parameters = Utilites.Instance.Paramater(session, barcode);
            return GetDataFromServer(session, MeetingMethodNames.CHECK_INOUT_ATTENDMEETING, parameters, new NumberObj().GetType()) as NumberObj;
        }
        
        /// <summary>
        /// 10. thêm danh sách các cuộc họp người đó ĐĂNG KÝ tham dự (không có thẻ, không có thư mời)
        /// insert attendmeeting 
        /// thêm thong tin của người không có thẻ, không có thư mời họp
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventAttendMeeting"></param>
        /// <returns></returns>
        public int insertAttendMeetingNotBarcode(string session, PersonNotBarcodeObj personNotBarcodeObj)
        {
            string parameters = Utilites.Instance.Paramater(session);

            int i = 0;
            try
            {
                i = PostDataFromServer(session, MeetingMethodNames.INSERT_MEETING_ATTENDMEETING_NOT_BARCODE, parameters, personNotBarcodeObj);
            }
            catch (Exception e)
            {
            }
            return i;
        }


        public int insertEventAttendMeetingEnterprise(string session, List<NonResident> listNoresident)
        {
            string parameters = Utilites.Instance.Paramater(session);

            int i = 0;
            try
            {
                i = PostDataFromServer(session, MeetingMethodNames.INSERT_MEETING_ATTENDMEETING_ENTERPRISE, parameters, listNoresident);
            }
            catch (Exception e)
            {
            }
            return i;
        }
    }
}
