using JavaCommunication.Common;
using sWorldCommunication.Interface;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Java
{
    public class JavaAttendance : IAttendance
    {
        private static JavaAttendance instance = new JavaAttendance();
        public static JavaAttendance Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaAttendance();
                }
                return instance;
            }
        }
        private JavaAttendance()
        {
        }

        public Attendance GetAttendanceById(string session, long attendanceId)
        {
            return CommunicationAttendance.Instance.GetAttendanceById(session, attendanceId);
        }

        public Attendance AddAttendance(string session, Attendance attendance)
        {
            return CommunicationAttendance.Instance.AddAttendance(session, attendance);
        }

        public int UpdateAttendance(string session, Attendance attendance)
        {
            return CommunicationAttendance.Instance.UpdateAttendance(session, attendance);
        }

        public int RemoveAttendance(string session, long attendanceId)
        {
            return CommunicationAttendance.Instance.RemoveAttendance(session, attendanceId);
        }

        public List<Attendance> GetAttendanceList(string session, AttendanceFilterDto filter)
        {
            return CommunicationAttendance.Instance.GetAttendanceList(session, filter);
        }

        public List<Attendance> GetAttendanceList(string session, long memberId)
        {
            return CommunicationAttendance.Instance.GetAttendanceList(session, memberId);
        }

        public List<Attendance> GetAttendanceList(string session, long memberId, string dateOut)
        {
            return CommunicationAttendance.Instance.GetAttendanceList(session, memberId, dateOut);
        }
    }
}
