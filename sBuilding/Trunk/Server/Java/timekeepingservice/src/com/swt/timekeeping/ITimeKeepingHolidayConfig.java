package com.swt.timekeeping;

import java.util.Date;
import java.util.List;

import com.swt.timekeeping.customer.object.HolidayResultForGet;
import com.swt.timekeeping.domain.HolidayConfig;

/**
 * Interface TimeKeepingHoliday
 * 
 * @author minh.nguyen
 *
 */
public interface ITimeKeepingHolidayConfig {

	/**
	 * Method insert holiday
	 * 
	 * @param HolidayResultForGet
	 * @return HolidayConfig
	 */
	public HolidayConfig insertHolidayConfig(HolidayResultForGet hResult);

	/**
	 * Method update holiday
	 * 
	 * @param HolidayResultForGet
	 * @return HolidayConfig
	 */
	public HolidayConfig updateHolidayConfig(HolidayResultForGet hResult);

	/**
	 * Method delete holiday
	 * 
	 * @param listHolidayId
	 * @return
	 */
	public int deleteHolidayConfigById(List<Long> listHolidayId);

	/**
	 * Method get holiday by id
	 * 
	 * @param long holidayId
	 * @return HolidayResultForGet
	 */
	public HolidayResultForGet getHolidayConfigById(long holidayId);

	/**
	 * Method check a date if that date is holiday or not
	 * 
	 * @param Date
	 *            dateCheck
	 * @param long orgId
	 * @return int result
	 */
	public int checkHoliday(Date dateCheck, long orgId);

	/**
	 * Method filter list holiday of org by a date start and a date end
	 * 
	 * @param Date
	 *            dateStart
	 * @param Date
	 *            dateEnd
	 * @param long orgId
	 * @return List<HolidayResultForGet>
	 */
	public List<HolidayResultForGet> filterHolidayListByOrgId(Date dateStart,
			Date dateEnd, long orgId);

	// trang.vo
	/**
	 * Get HolidayList By OrgId and Year 
	 * @param year
	 * @param orgId
	 * @return
	 */
	public List<HolidayResultForGet> GetHolidayListByOrgId(int year, long orgId);
}