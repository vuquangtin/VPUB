package com.swt.timekeeping;

import java.util.Date;
import java.util.List;

import com.swt.timekeeping.customer.object.ShiftFilter;
import com.swt.timekeeping.domain.Shift;
/**
 * ITimeKeepingShift interface
 * @author TrangPig
 *
 */
public interface ITimeKeepingShift {
/**
 * insert TimeKeepingShift
 * @param timeKeepingShift
 * @return
 */
	public Shift insert(Shift timeKeepingShift);
	/**
	 * update TimeKeepingShift
	 * @param timeKeepingShift
	 * @return
	 */
	public Shift update(Shift timeKeepingShift);
	/**
	 * delete TimeKeepingShift
	 * @param timeKeepingShiftId
	 * @return
	 */
	public int delete(long timeKeepingShiftId);
	/**
	 * get TimeKeepingShift By Id
	 * @param timeKeepingShiftId
	 * @return
	 */
	public Shift getTimeKeepingShiftById(long timeKeepingShiftId);
	/**
	 * get Shift By Filter
	 * @param shiftFilter
	 * @return
	 */
	public List<Shift> getShiftByFilter(ShiftFilter shiftFilter);
	/**
	 * get Shift by listMemberId, dateBegin, dateEnd, orgId and subOrgId
	 * call function GetShift 
	 * @param dateBegin
	 * @param dateEnd
	 * @param listMemberId
	 * @param orgId
	 * @param subOrgId
	 * @return
	 */
	public List<Shift> getShift(Date dateBegin, Date dateEnd, String listMemberId, long orgId, long subOrgId);
}
