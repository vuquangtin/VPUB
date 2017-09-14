package com.swt.timekeeping.impls;

import java.util.Date;
import java.util.List;

import com.swt.timekeeping.customer.object.DayOffImportObject;
import com.swt.timekeeping.customer.object.DayOffResultForGet;
import com.swt.timekeeping.domain.DayOffConfig;

/**
 * TimeKeeping Day Off Config Controller
 * 
 * @author minh.nguyen
 *
 */
public class TimeKeepingDayOffConfigController {
	/**
	 * Instance of TimeKeepingDayOffConfigController
	 */
	public static final TimeKeepingDayOffConfigController Instance = new TimeKeepingDayOffConfigController();
	private TimeKeepingDayOffConfigDAO tdocDAO = new TimeKeepingDayOffConfigDAO();

	/**
	 * Method insert day off
	 * 
	 * @param DayOffResultForGet
	 * @return DayOffConfig
	 */
	public DayOffConfig insertDayOffConfig(DayOffResultForGet doResult) {
		return tdocDAO.insertDayOffConfig(doResult);
	}

	/**
	 * Method update day off
	 * 
	 * @param DayOffResultForGet
	 * @return DayOffConfig
	 */
	public DayOffConfig updateDayOffConfig(DayOffResultForGet doResult) {
		return tdocDAO.updateDayOffConfig(doResult);
	}

	/**
	 * Method insert or update day off by member's id
	 * 
	 * @param DayOffResultForGet
	 * @return DayOffConfig
	 */
	public DayOffConfig insertOrUpdateDayOffByListMemberId(DayOffResultForGet doResult) {
		return tdocDAO.insertOrUpdateDayOffByListMemberId(doResult);
	}

	/**
	 * Method delete day off
	 * 
	 * @param listDOConfigId
	 * @return
	 */
	public int deleteDayOffConfig(List<Long> listDOConfigId) {
		return tdocDAO.deleteDayOffConfig(listDOConfigId);
	}

	/**
	 * Method get day off by id
	 * 
	 * @param long
	 *            doConfigId
	 * @return DayOffResultForGet
	 */
	public DayOffResultForGet getDayOffConfigById(long doConfigId) {
		return tdocDAO.getDayOffConfigById(doConfigId);
	}

	/**
	 * Method get list day off by member's id
	 * 
	 * @param long
	 *            memberId
	 * @return List<DayOffResultForGet>
	 */
	public List<DayOffResultForGet> getListDayOffConfigByMemberId(long memberId) {
		return tdocDAO.getListDayOffConfigByMemberId(memberId);
	}

	/**
	 * Method filter list day off of sub org by a date start and a date end
	 * 
	 * @param Date
	 *            dateStart
	 * @param Date
	 *            dateEnd
	 * @param long
	 *            subOrgId
	 * @return List<DayOffResultForGet>
	 */
	public List<DayOffResultForGet> filterListDayOffBySubOrgId(Date dateStart, Date dateEnd, long subOrgId) {
		return tdocDAO.filterListDayOffBySubOrgId(dateStart, dateEnd, subOrgId);
	}

	/**
	 * Method get status of a date by member's id
	 * 
	 * @param long memberId
	 * @param String date
	 * @return int result
	 */
	public int getStatusOfDateByMemberId(long memberId, String date) {
		return tdocDAO.getStatusOfDateByMemberId(memberId, date);
	}
	
	/**
	 * Method get day off by member's id and date
	 * 
	 * @param long
	 *            memberId
	 * @param String
	 *            date
	 * @return DayOffResultForGet
	 */
	public DayOffResultForGet getDayOffByMemberIdAndDate(long memberId, String date) {
		return tdocDAO.getDayOffByMemberIdAndDate(memberId, date);
	}
	
	/**
	 * Method list day off excel
	 *
	 * @param List<DayOffImportObject> listDayOffImportObject
	 * @return List<DayOffImportObject>
	 */
	public List<DayOffImportObject> importDayOffList(List<DayOffImportObject> listDayOffImportObject ) {
		return tdocDAO.importDayOffList(listDayOffImportObject);
	}
}
