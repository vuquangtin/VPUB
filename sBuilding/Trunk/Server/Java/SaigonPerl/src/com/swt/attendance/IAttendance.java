/**
 * 
 */
package com.swt.attendance;

import java.util.List;

import com.swt.attendance.domain.Attendance;
import com.swt.sworld.customer.object.AttendanceFilterDto;

/**
 * @author Administrator
 *
 */
public interface IAttendance {
	
	Attendance insert(Attendance att);
	Attendance update(Attendance att);
	int delete(long idAtt);
	List<Attendance> GetAttendanceByMemberIdAndDateOut(long memberId, String dateOut);
	List<Attendance> GetAttendanceByMemberId(long memberId);
	List<Attendance> GetAttendanceAll();
	Attendance GetBySerialAndStatus(String serialNumber, int status);
	
	List<Attendance> getByFilter(AttendanceFilterDto dto);
}
