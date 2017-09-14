package com.swt.timekeeping.impls;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.swt.timekeeping.customer.object.ShiftFilter;
import com.swt.timekeeping.domain.Shift;

/**
 * Timekeepingcontroller
 * 
 * @author TrangPig
 *
 */

public class TimeKeepingShiftController {
	/**
	 * Instance of TimeKeepingShiftController
	 */
	public static final TimeKeepingShiftController Instance = new TimeKeepingShiftController();

	private TimeKeepingShiftDAO tsDAO = new TimeKeepingShiftDAO();

	/**
	 * insert TimekeepingShift
	 * 
	 * @param timeKeepingShift
	 * @return TimeKeepingShiftDAO
	 */
	public Shift insert(Shift timeKeepingShift) {
		return tsDAO.insert(timeKeepingShift);
	}

	/**
	 * update TimekeepingShift
	 * 
	 * @param timeKeepingShift
	 * @return TimeKeepingShiftDAO
	 */
	public Shift update(Shift timeKeepingShift) {
		return tsDAO.update(timeKeepingShift);
	}

	/**
	 * delete TimekeepingShift
	 * 
	 * @param timeKeepingShiftId
	 * @return int
	 */
	public int delete(long timeKeepingShiftId) {
		return tsDAO.delete(timeKeepingShiftId);
	}

	/**
	 * getTimekeepingShiftByShiftId
	 * 
	 * @param timeKeepingShiftId
	 * @return TimeKeepingShiftDAO
	 */
	public Shift getTimeKeepingShiftById(long timeKeepingShiftId) {
		return tsDAO.getTimeKeepingShiftById(timeKeepingShiftId);
	}

	/**
	 * Ham lay danh sach shift voi dieu kien ngay
	 * 
	 * @param date
	 * @param name
	 * @param deviceName
	 * @return List<TimeKeepingShift>
	 */
	public List<Shift> getShiftListByDate(String date, String name,
			String deviceName) {
		List<Shift> resultList = new ArrayList<>();
		ShiftFilter filter = new ShiftFilter();
		filter.setFilterByDateIn(true);
		try {
			DateFormat formatter = new SimpleDateFormat("dd-MM-yyyy");
			Date dateTime = (Date) formatter.parse(date);
			filter.setDateIn(dateTime);
		} catch (ParseException e) {
			e.printStackTrace();
		}

		resultList = tsDAO.getShiftByFilter(filter);
		return resultList;
	}

	/**
	 * Ham lay danh sach shift voi dieu kien nam
	 * 
	 * @param year
	 * @param name
	 * @param deviceName
	 * @return List<TimeKeepingShift>
	 */
	@SuppressWarnings("deprecation")
	public List<Shift> getShiftListByYear(String year, String name,
			String deviceName) {
		List<Shift> resultList = new ArrayList<>();
		ShiftFilter filter = new ShiftFilter();
		filter.setFilterByDateIn(true);
		Date dateTime = new Date();
		dateTime.setYear(Integer.parseInt(year));
		filter.setDateIn(dateTime);

		resultList = tsDAO.getShiftByFilter(filter);
		return resultList;
	}

	/**
	 * Ham lay danh sach shift voi dieu kien thang
	 * 
	 * @param month
	 * @param year
	 * @param name
	 * @param deviceName
	 * @return List<TimeKeepingShift>
	 */
	@SuppressWarnings("deprecation")
	public List<Shift> getShiftListByMonth(String month, String year,
			String name, String deviceName) {
		List<Shift> resultList = new ArrayList<>();
		ShiftFilter filter = new ShiftFilter();
		filter.setFilterByDateIn(true);
		Date dateTime = new Date();
		dateTime.setYear(Integer.parseInt(year));
		dateTime.setMonth(Integer.parseInt(month));
		filter.setDateIn(dateTime);

		resultList = tsDAO.getShiftByFilter(filter);
		return resultList;
	}

	/**
	 * get ShiftList By ShiftFilter
	 * 
	 * @param shiftFilter
	 * @return
	 */
	public List<Shift> getShiftListByShiftFilter(ShiftFilter shiftFilter) {
		return tsDAO.getShiftByFilter(shiftFilter);
	}

	/**
	 * getShift: call function GetShift
	 * 
	 * @param dateBegin
	 * @param dateEnd
	 * @param listMemberId
	 * @param orgId
	 * @param subOrgId
	 * @return
	 */
	@SuppressWarnings("deprecation")
	public List<Shift> getShift(Date dateBegin, Date dateEnd,
			String listMemberId, long orgId, long subOrgId) {
		dateBegin.setHours(0);
		dateEnd.setHours(23);
		dateEnd.setMinutes(59);
		dateEnd.setSeconds(59);
		return tsDAO
				.getShift(dateBegin, dateEnd, listMemberId, orgId, subOrgId);
	}

}
