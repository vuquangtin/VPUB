package com.swt.timekeeping;

import java.util.Date;

import com.swt.timekeeping.domain.DailyConfig;
/**
 * interface ITimekeepingDailyConfig
 * @author Trang-PC
 *
 */
public interface ITimekeepingDailyConfig {

	/**
	 * insert daily
	 * @param daily
	 * @return
	 */
	public DailyConfig insert(DailyConfig daily);
	
	/**
	 * get daily by date
	 * @param date
	 * @param orgId
	 * @return
	 */
	public DailyConfig getDailyConfigByDate(Date date, long orgId);
}
