using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Common
{
    public class CommunicationAttendance : CommunicationCommon
    {
        private static CommunicationAttendance instance = new CommunicationAttendance();
        public static CommunicationAttendance Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationAttendance();
                }
                return instance;
            }
        }

        public CommunicationAttendance() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"other";
        }
        public Attendance GetAttendanceById(string session, long attendanceId)
        {
            string parameters = Utilites.Instance.Paramater(session, attendanceId);
            Attendance result = GetDataFromServer(session, MethodNames.GET_ATTENDANCE_BY_ID, parameters, new Attendance().GetType()) as Attendance;
            if (null == result) throw new Exception();

            return result;
        }

        public Attendance AddAttendance(string session, Attendance attendance)
        {
            string parameters = Utilites.Instance.Paramater(session);
            Attendance result = PostDataToServerObject(session, MethodNames.INSERT_ATTENDANCE, parameters,attendance, new Attendance().GetType()) as Attendance;
            if (null == result) throw new Exception();

            return result;
        }

        public int UpdateAttendance(string session, Attendance attendance)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.UPDATE_ATTENDANCE, parameters, attendance);
        }

        public int RemoveAttendance(string session, long attendanceId)
        {
            string parameters = Utilites.Instance.Paramater(session, attendanceId);
            return GetDataFromServer(session, MethodNames.DELETE_ATTENDANCE, parameters);
        }

        public List<Attendance> GetAttendanceList(string session, AttendanceFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<Attendance> result = PostDataToServerObject(session, MethodNames.GET_ALL_ATTENDANCE, parameters, filter, new List<Attendance>().GetType()) as List<Attendance>;
            if (null == result) throw new Exception();

            return result;
        }

        public List<Attendance> GetAttendanceList(string session, long memberId)
        {
            string parameters = Utilites.Instance.Paramater(session, memberId);
            List<Attendance> result = GetDataFromServer(session, MethodNames.GET_BY_MEMBER_ID_ATTENDANCE, parameters, new List<Attendance>().GetType()) as List<Attendance>;
            if (null == result) throw new Exception();

            return result;
        }

        public List<Attendance> GetAttendanceList(string session, long memberId, string dateOut)
        {
            string parameters = Utilites.Instance.Paramater(session, memberId);
            List<Attendance> result = GetDataFromServer(session, MethodNames.GET_BY_MEMBER_ID_AND_DATE_OUT_ATTENDANCE, parameters, new List<Attendance>().GetType()) as List<Attendance>;
            if (null == result) throw new Exception();

            return result;
        }
    }
}
