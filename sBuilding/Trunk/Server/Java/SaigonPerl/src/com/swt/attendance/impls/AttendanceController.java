/**
 * 
 */
package com.swt.attendance.impls;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import com.swt.attendance.domain.Attendance;
import com.swt.saigonpearl.domain.ManagerCosts;
import com.swt.saigonpearl.impls.ManagerCostsController;
import com.swt.sworld.customer.object.AttendanceFilterDto;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.ChipPersonalizationController;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.sworld.utilites.SworldConst;


/**
 * @author Administrator
 *
 */
public class AttendanceController {
	public static final AttendanceController Instance = new AttendanceController();
	private AttendanceDAO AttDAO = new AttendanceDAO();
	private AttendanceController()
	{
		
	}
	
	public Attendance insert(Attendance attendance)
	{
		Attendance attRe = null;
		ChipPersonalization chipper = ChipPersonalizationController.Instance.getBySerial(attendance.getSerialNumber());
		if(chipper != null)
		{
			Member member = MemberController.Instance.getMemberById(chipper.getPsMemberId());
			ManagerCosts mc = ManagerCostsController.Instance.getManagerCostBySubOrgId(member.getSubOrgId());
			if(mc == null)
			{
				//kiem tra serial va status la process
				Attendance att = AttDAO.GetBySerialAndStatus(attendance.getSerialNumber(), SworldConst.Process);
				if(att != null)
				{
					att.setDateOut(formatYearMonDayHhSs());
					att.setImgOut(attendance.getImgIn());
					att.setStatus(SworldConst.Success);
					return AttDAO.update(att);
				}
				else
				{
					Attendance att1 = new Attendance();
					att1.setDateIn(formatYearMonDayHhSs());
					att1.setMemberId(chipper.getPsMemberId());
					att1.setSerialNumber(attendance.getSerialNumber());
					att1.setImgIn(attendance.getImgIn());
					att1.setStatus(SworldConst.Process);
					return AttDAO.insert(att1);
				}
			}
		}
		return attRe;
	}
	
	public static String formatYearMonDayHhSs()
	{
		SimpleDateFormat formatter = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
		String dateString = formatter.format(new Date());
		return dateString;
	}
	
	public Attendance update(Attendance att)
	{
		return AttDAO.update(att);
	}
	
	public int delete(long attId)
	{
		return AttDAO.delete(attId);
	}
	
	public List<Attendance> getByMemberIdAndDateOut(long memberId, String dateOut)
	{
		return AttDAO.GetAttendanceByMemberIdAndDateOut(memberId, dateOut);
	}
	
	public List<Attendance> getByMemberId(long memberId)
	{
		return AttDAO.GetAttendanceByMemberId(memberId);
	}
	
	public List<Attendance> getAll(AttendanceFilterDto dto)
	{
		return AttDAO.getByFilter(dto);
	}
	
}
