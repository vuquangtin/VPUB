package com.swt.timekeeping.impls;

import java.util.Calendar;
import java.util.Date;

import com.swt.timekeeping.domain.DailyConfig;
import com.swt.timekeeping.domain.TimeConfig;
/**
 * TimeKeepingDailyConfig Controller
 * @author Trang-PC
 *
 */
public class TimeKeepingDailyConfigController {
	/**
	 * Instance of TimeKeepingDailyConfigController
	 */
	public static final TimeKeepingDailyConfigController Instance = new TimeKeepingDailyConfigController();
	private TimeKeepingDailyConfigDAO dcDAO = new TimeKeepingDailyConfigDAO();

	/**
	 * insert
	 * 
	 * @param daily
	 * @return
	 */
	public DailyConfig insert(DailyConfig daily) {
		return dcDAO.insert(daily);
	}

	/**
	 * getDailyConfig by date and orgId
	 * 
	 * @param date
	 * @param orgId
	 * @return
	 */
	public DailyConfig getDailyConfigByDate(Date date, long orgId) {
		DailyConfig daily = dcDAO.getDailyConfigByDate(date, orgId);
		if (null == daily) {
			Calendar c = Calendar.getInstance();
			c.setTime(date);
			// get dayOfWeek
			int dayOfWeek = c.get(Calendar.DAY_OF_WEEK);
			TimeConfig timeConfig = TimeKeepingTimeConfigController.Instance
					.getTimeConfigByDayOfWeekOrgId(dayOfWeek, orgId);
			if (null != timeConfig) {
				daily = new DailyConfig();
				daily.setDate(date);
				daily.setOrgId(orgId);
				daily.setJsonTimeConfig(timeConfig.getSessionWorking());
				daily = insert(daily);
			}
		}
		return daily;
	}
}
