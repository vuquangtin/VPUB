package com.swt.timekeeping.impls;

import java.util.Date;
import java.util.List;

import com.swt.timekeeping.customer.object.HolidayResultForGet;
import com.swt.timekeeping.domain.HolidayConfig;

/**
 * TimeKeeping Holiday Config Controller
 * 
 * @author minh.nguyen
 *
 */
public class TimeKeepingHolidayConfigController {
	/**
	 * Instance of TimeKeepingHolidayConfigController
	 */
	public static final TimeKeepingHolidayConfigController Instance = new TimeKeepingHolidayConfigController();
	private TimeKeepingHolidayConfigDAO thcDAO = new TimeKeepingHolidayConfigDAO();

	/**
	 * Method insert holiday
	 * 
	 * @param HolidayResultForGet
	 * @return HolidayConfig
	 */
	public HolidayConfig insertHolidayConfig(HolidayResultForGet hResult) {
		return thcDAO.insertHolidayConfig(hResult);
	}

	/**
	 * Method update holiday
	 * 
	 * @param HolidayResultForGet
	 * @return HolidayConfig
	 */
	public HolidayConfig updateHolidayConfig(HolidayResultForGet hResult) {
		return thcDAO.updateHolidayConfig(hResult);
	}

	/**
	 * Method delete holiday
	 * 
	 * @param listHolidayId
	 * @return
	 */
	public int deleteHolidayConfigById(List<Long> listHolidayId) {
		return thcDAO.deleteHolidayConfigById(listHolidayId);
	}

	/**
	 * Method get holiday by id
	 * 
	 * @param long holidayId
	 * @return HolidayResultForGet
	 */
	public HolidayResultForGet getHolidayConfigById(long holidayId) {
		return thcDAO.getHolidayConfigById(holidayId);
	}

	/**
	 * Method check a date if that date is holiday or not
	 * 
	 * @param Date
	 *            dateCheck
	 * @param long orgId
	 * @return int result
	 */
	public int checkHoliday(Date dateCheck, long orgId) {
		return thcDAO.checkHoliday(dateCheck, orgId);
	}

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
			Date dateEnd, long orgId) {
		return thcDAO.filterHolidayListByOrgId(dateStart, dateEnd, orgId);
	}

	// trang.vo
	/**
	 * Get Holiday List By OrgId and Year
	 * 
	 * @param int year
	 * @param long orgId
	 * @return
	 */
	public List<HolidayResultForGet> GetHolidayListByOrgId(int year, long orgId) {
		return thcDAO.GetHolidayListByOrgId(year, orgId);
	}
}
