using JavaCommunication;
using JavaCommunication.Common;
using sMeetingComponent.Constants;
using sMeetingComponent.Model.CustomObj;
using sMeetingComponent.Model.CustomObj.InfoJournalistObj;
using System;

namespace sMeetingComponent.JavaComunication
{
    public class CommunicationJournalist : CommunicationCommon
    {
        private static CommunicationJournalist instance = new CommunicationJournalist();

        public static CommunicationJournalist Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationJournalist();
                }
                return instance;
            }
        }

        public CommunicationJournalist() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"journalistmng";
        }

        /// <summary>
        /// 7.1GET Đọc thông tin của thẻ xem có thông tin hay không
        /// get info Journalist by serialnumber
        /// </summary>
        /// <param name="session"></param>
        /// <param name="cardchip"></param>
        /// <returns></returns>
        public Journalist getJournalistByCardChip(string session, String cardchip)
        {

            string parameters = Utilites.Instance.Paramater(session, cardchip);
            Journalist result = null;
            try
            {
                result = GetDataFromServer(session, MeetingMethodNames.GET_JOURNALIST_BY_CARDCHIP, parameters, new Journalist().GetType()) as Journalist;
            }
            catch (Exception e)
            {

            };
            return result;
        }

        /// <summary>
        /// 7: lấy thông tin các cuộc họp hôm nay, các cuộc họp nhà báo được vào
        ///  get info card based on serialnumber , datetime: yyyy-MM-dd HH:mm
        /// lấy về thông tin của nhà báo, các cuộc họp nhà báo được mời, các cuộc họp hôm nay
        /// <param name="session"></param>
        /// <param name="cardchip"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public MeetingInfoJournalistObj getListMeetingJournalistObjByCardChip(string session, String cardchip, String datetime)//, int previousMinutes)
        {

            string parameters = Utilites.Instance.Paramater(session, cardchip, datetime);//,  previousMinutes);
            MeetingInfoJournalistObj result = null;
            try
            {
                result = GetDataFromServer(session, MeetingMethodNames.GET_LISTMEETING_JOURNALIST_BY_SERIALNUMBER_DATETIME, parameters, new MeetingInfoJournalistObj().GetType()) as MeetingInfoJournalistObj;


            }
            catch (Exception e)
            {
            };
            return result;
        }

        /// <summary>
        /// Kiểm tra thẻ nhà báo có hết hạn hay không
        /// </summary>
        /// <param name="session">session hiện tại</param>
        /// <param name="serialNumber">serial number của thẻ nhà báo đó để xuống db lấy lên</param>
        /// <returns></returns>
        public int isDateExpirated(string session, string serialNumber) {
            string parameters = Utilites.Instance.Paramater(session, serialNumber);
            return GetDataFromServer(session, MeetingMethodNames.CHECK_IS_DATE_EXPIRATED, parameters);
        }

        /// <summary>
        /// check card
        /// 3. kiểm tra xem  thẻ quét vào hôm nay có tham dự cuộc họp nào không Nocập nhật thời gian) , (xem thông tin thẻ)
        /// trước tiên kiểm tra xem bảng AttendMeetingJournalist có thông tin của thẻ trong hôm nay không
        /// nếu có thì cập nhật thời gian ra về
        /// nếu không thì trả về FALSE
        /// <param name="session"></param>
        /// <param name="cardchip"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public NumberObj checkInOutUpdateAttendMeetingJournalist(string session, String cardchip, String datetime)
        {
            string parameters = Utilites.Instance.Paramater(session, cardchip, datetime);
            return GetDataFromServer(session, MeetingMethodNames.CHECK_INOUT_UPDATE_ATTENDMEETING, parameters,new NumberObj().GetType()) as NumberObj;
        }

        /// <summary>
        /// 8: Thêm danh sách các cuộc họp người đó tham dự
        /// insert attendmeeting of journalist  
        ///  lưu xuống database các dòng AttendMeetingJournalist lấy thông tin từ ListMeetingJournalistObj gửi về server
        ///  
        /// <param name="session"></param>
        /// <param name="listMeetingJournalistObj"></param>
        /// <returns></returns>
        public int insertAttendMeetingJournalist(string session, MeetingInfoJournalistObj listMeetingJournalistObj)
        {
            string parameters = Utilites.Instance.Paramater(session);
          
            int result = 0;
            try
            {
                 result = PostDataFromServer(session, MeetingMethodNames.INSERT_ATTENDMEETING_JOURNALIST, parameters, listMeetingJournalistObj);
            }
            catch (Exception e)
            {
            }
            return result;
        }
    }
}
