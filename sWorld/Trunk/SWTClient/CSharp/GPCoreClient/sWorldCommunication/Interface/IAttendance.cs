using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldCommunication.Interface
{
    public interface IAttendance
    {
        /// <summary>
        /// Thêm thông tin một lượt ra/vào cửa
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="serialNumber">serial number của thẻ</param>
        /// <returns>Thông tin lượt ra/vào</returns>
        Attendance AddAttendance(string session, Attendance attendance);
        
        /// <summary>
        /// Cập nhật thông tin một lượt ra/vào
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="attendance">Thông tin một lượt ra/vào</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int UpdateAttendance(string session, Attendance attendance);

        /// <summary>
        /// Cập nhật thông tin lượt ra/vào
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="attendanceId">Id của lượt ra/vào</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int RemoveAttendance(string session, long attendanceId);

        /// <summary>
        /// Lấy danh sách lượt ra/vào theo filter
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>Danh sách lượt ra/vào</returns>
        List<Attendance> GetAttendanceList(string session, AttendanceFilterDto filter);

        /// <summary>
        /// Lấy danh sách lượt ra/vào theo member
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="memberId">Id của thành viên</param>
        /// <returns>Danh sách lượt ra/vào</returns>
        List<Attendance> GetAttendanceList(string session, long memberId);

        /// <summary>
        /// Lấy danh sách lượt ra/vào theo member và ngày ra
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="memberId">Id của thành viên</param>
        /// <param name="dateOut">Ngày ra</param>
        /// <returns>Danh sách lượt ra/vào</returns>
        List<Attendance> GetAttendanceList(string session, long memberId, string dateOut);

        /// <summary>
        /// Lấy thông tin của lượt ra/vào
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="attendanceId">Id của Attendance</param>
        /// <returns></returns>
        Attendance GetAttendanceById(string session, long attendanceId);
    }
}
