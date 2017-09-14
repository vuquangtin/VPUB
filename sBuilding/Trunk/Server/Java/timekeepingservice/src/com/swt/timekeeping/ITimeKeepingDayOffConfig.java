package com.swt.timekeeping;

import java.util.Date;
import java.util.List;

import com.swt.timekeeping.customer.object.DayOffResultForGet;
import com.swt.timekeeping.customer.object.DayOffImportObject;
import com.swt.timekeeping.domain.DayOffConfig;

/**
 * Interface TimeKeepingDayOff
 * 
 * @author minh.nguyen
 *
 */
public interface ITimeKeepingDayOffConfig {

	/**
	 * Method insert day off
	 * 
	 * @param DayOffResultForGet
	 * @return DayOffConfig
	 */
	public DayOffConfig insertDayOffConfig(DayOffResultForGet doResult);

	/**
	 * Method update day off
	 * 
	 * @param DayOffResultForGet
	 * @return DayOffConfig
	 */
	public DayOffConfig updateDayOffConfig(DayOffResultForGet doResult);

	/**
	 * Method insert or update day off by member's id
	 * 
	 * @param DayOffResultForGet
	 * @return DayOffConfig
	 */
	public DayOffConfig insertOrUpdateDayOffByListMemberId(DayOffResultForGet doResult);

	/**
	 * Method delete day off
	 * 
	 * @param listDOConfigId
	 * @return
	 */
	public int deleteDayOffConfig(List<Long> listDOConfigId);

	/**
	 * Method get day off by id
	 * 
	 * @param long
	 *            doConfigId
	 * @return DayOffResultForGet
	 */
	public DayOffResultForGet getDayOffConfigById(long doConfigId);

	/**
	 * Method get list day off by member's id
	 * 
	 * @param long
	 *            memberId
	 * @return List<DayOffResultForGet>
	 */
	public List<DayOffResultForGet> getListDayOffConfigByMemberId(long memberId);

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
	public List<DayOffResultForGet> filterListDayOffBySubOrgId(Date dateStart, Date dateEnd, long subOrgId);

	/**
	 * Method get status of a date by member's id
	 * 
	 * @param long memberId
	 * @param String date
	 * @return int result
	 */
	public int getStatusOfDateByMemberId(long memberId, String date);
	
	/**
	 * Method get day off by member's id and date
	 * 
	 * @param long
	 *            memberId
	 * @param String
	 *            date
	 * @return DayOffResultForGet
	 */
	public DayOffResultForGet getDayOffByMemberIdAndDate(long memberId, String date);
	
	/**
	 * Method list day off excel
	 * 
	 * @param excelDayOffList
	 * @return
	 */
	public List<DayOffImportObject> importDayOffList(List<DayOffImportObject> excelDayOffList);
}
