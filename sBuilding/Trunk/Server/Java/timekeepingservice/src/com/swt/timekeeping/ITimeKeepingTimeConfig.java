package com.swt.timekeeping;

import java.util.List;

import com.swt.timekeeping.domain.TimeConfig;
/**
 * ITimeKeepingTimeConfig interface
 * @author TrangPig
 *
 */
public interface ITimeKeepingTimeConfig {
/**
 * insert TimeKeepingTimeConfig
 * @param timeKeepingConfig
 * @return
 */
	public TimeConfig insert(TimeConfig timeKeepingConfig);
	/**
	 * update TimeKeepingTimeConfig
	 * @param timeKeepingConfig
	 * @return
	 */
	public TimeConfig update(TimeConfig timeKeepingConfig);
	/**
	 * delete TimeKeepingTimeConfig
	 * @param timeKeepingConfigId
	 * @return
	 */
	public int delete(long timeKeepingConfigId);
	/**
	 * getTimeKeepingConfigById
	 * @param timeKeepingConfigId
	 * @return
	 */
	public TimeConfig getTimeKeepingConfigById(long timeKeepingConfigId);
	
	/**
	 * getListTimeKeepingTimeConfigByOrgCode
	 * @param orgCode
	 * @return
	 */
	public List<TimeConfig> getListTimeKeepingTimeConfigByOrgCode(long orgId, String dayOfWeek);
	
	/**
	 * getListTimeKeepingTimeConfigByOrgCodes
	 * @param orgCode
	 * @return
	 */
	public List<TimeConfig> getListTimeKeepingTimeConfigByOrgId(long orgId);
	/**
	 * get TimeConfig By DayOfWeek and OrgId
	 * @param dayOfWeek
	 * @param orgId
	 * @return
	 */
	public TimeConfig getTimeConfigByDayOfWeekOrgId(int dayOfWeek, long orgId);
}
