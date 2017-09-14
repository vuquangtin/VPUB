using JavaCommunication;
using JavaCommunication.Common;
using sMeetingComponent.Constants;
using sMeetingComponent.Model.CustomObj.JournalistObjForStatictis;
using sMeetingComponent.Model.CustomObj.PersonInfoForStatictis;
using System;
using System.Collections.Generic;

namespace sMeetingComponent.JavaComunication
{
    public class CommunicationAttendMeetingStatistic : CommunicationCommon
    {

        private static CommunicationAttendMeetingStatistic instance = new CommunicationAttendMeetingStatistic();

        public static CommunicationAttendMeetingStatistic Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationAttendMeetingStatistic();
                }
                return instance;
            }
        }

        public CommunicationAttendMeetingStatistic() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"attendmeetingmg"; 
        }

        /// <summary>
        /// 12: THống kê : LẤy thông tin chi tiết người tham dự họp
        /// get list PersonAttendDetail based on meetingid 
        /// danh sách thống kê thông tin chi tiết hội họp dựa vào vị trí bắt đầu , số lượng cần lấy, meetingID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        public PersonAttendDetailObj getListAttendMeetingByMeetingidAndDate(string session, int from, int to, long meetingId)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, meetingId);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_ATTEND_MEETING_STATISTIC_OBJ_BY_MEETING_ID, parameters, new PersonAttendDetailObj().GetType()) as PersonAttendDetailObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 11. Thống kê Lấy số lượng người tham dự họp
        /// danh sách thống kê số lượng người tham dự hội họp dựa vào vị trí bắt đầu , số lượng cần lấy, ngày bắt đầu, ngày kết thúc, organizationMeetingId, tên cuộc họp
        /// get list statistic attendmeeting base on  orgid, nameMeeting (defaul="ALL")
        /// </summary>
        /// <param name="session"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <param name="organizationMeetingId"></param>
        /// <param name="nameMeeting"></param>
        /// <returns></returns>
        public PersonAttendStatisticObj getListAttendMeetingStatisticByDate(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId, string nameMeeting)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2, organizationMeetingId, nameMeeting);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_LISTATTEND_MEETING_STATISTIC_BY_DATE, parameters, new PersonAttendStatisticObj().GetType()) as PersonAttendStatisticObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 13:LẤY THÔNG TIN CHI TIẾT CUỘC HỌP và số lượng người tham dự họp
        /// lấy thông tin danh sách các cuộc họp theo điều kiện lọc 
        /// có thông tin thống kê số lượng
        /// get list statistic detail attendmeeting  base on orgid
        /// </summary>
        /// <param name="session"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <param name="organizationMeetingId"></param>
        /// <returns></returns>
        public List<PersonAttendObj> getListAttendMeetingStatisticByDateAndOrgId(string session, String dateIn, String dateIn2, long organizationMeetingId)
        {
            string parameters = Utilites.Instance.Paramater(session, dateIn, dateIn2, organizationMeetingId);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_LISTATTEND_MEETING_STATISTIC_BY_DATE_ORGID, parameters, new List<PersonAttendObj>().GetType()) as List<PersonAttendObj>;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 14: THống kê CHI TIẾT HỘI HỌP : LẤy thông tin chi tiết người tham dự họp
        /// lấy thông tin thống kê chi tiết theo điều kiện orgid meetingid
        ///  get list statistic detail attendmeeting  base on orgid, meetindID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <param name="organizationMeetingId"></param>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        public PersonAttendDetailObj getListPersonAttendDetailByDateAndOrgIdAndMeetingId(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId, long meetingId)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2, organizationMeetingId, meetingId);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_LISTATTEND_MEETING_STATISTIC_DETAIL_BY_DATE_ORGID_MEETINGID, parameters, new PersonAttendDetailObj().GetType()) as PersonAttendDetailObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //--------------------------------------------Thống kê báo chí-----------------------------------------
        /// <summary>
        /// 15. Thống kê BÁO CHÍ Lấy số lượng người tham dự họp
        /// danh sách thống kê số lượng người tham dự hội họp dựa vào vị trí bắt đầu , số lượng cần lấy, ngày bắt đầu, ngày kết thúc, organizationMeetingId, tên cuộc họp
        /// get list number statictis of journalist attendmeeting based on orgid, nameMeeting(default="ALL")
        /// </summary>
        /// <param name="session"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <param name="organizationMeetingId"></param>
        /// <param name="nameMeeting"></param>
        /// <returns></returns>
        public JournalistAttendStatisticObj getListAttendMeetingJournalistStatisticByDate(string session, int from, int to, string dateIn, string dateIn2, long organizationMeetingId, string nameMeeting)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2, organizationMeetingId, nameMeeting);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_LISTATTEND_MEETING_STATISTIC_JOURNALIST_BY_DATE, parameters, new JournalistAttendStatisticObj().GetType()) as JournalistAttendStatisticObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 16: THống kê BÁO CHÍ : LẤy thông tin chi tiết NHÀ BÁO người tham dự họp
        /// get list JournalistAttendStatisticDetail based on meetingid 
        /// danh sách thống kê thông tin chi tiết hội họp dựa vào vị trí bắt đầu , số lượng cần lấy, meetingID
        ///  get list info statictis of journalist attendmeeting based on meetingID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        public JournalistAttendStatisticDetailObj getListAttendMeetingJournalistByMeetingidAndDate(string session, int from, int to, long meetingId)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, meetingId);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_ATTEND_MEETING_STATISTIC_OBJ_JOURNALIST_BY_MEETING_ID, parameters, new JournalistAttendStatisticDetailObj().GetType()) as JournalistAttendStatisticDetailObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 17: THống kê CHI TIẾT HỘI HỌP : LẤy thông tin chi tiết người tham dự họp của BÁO CHÍ
        /// lấy thông tin thống kê chi tiết theo điều kiện orgid meetingid
        ///  get list info statistic detail journalist attendmeeting  base on orgid, meetindID
        /// </summary>
        /// <param name="session"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="dateIn"></param>
        /// <param name="dateIn2"></param>
        /// <param name="organizationMeetingId"></param>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        public JournalistAttendStatisticDetailObj getListPersonAttendDetailJournalistByDateAndOrgIdAndMeetingId(string session, int from, int to, String dateIn, String dateIn2, long organizationMeetingId, long meetingId)
        {
            string parameters = Utilites.Instance.Paramater(session, from, to, dateIn, dateIn2, organizationMeetingId, meetingId);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_LISTATTEND_MEETING_STATISTIC_DETAIL_JOURNALIST_BY_DATE_ORGID_MEETINGID, parameters, new JournalistAttendStatisticDetailObj().GetType()) as JournalistAttendStatisticDetailObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
