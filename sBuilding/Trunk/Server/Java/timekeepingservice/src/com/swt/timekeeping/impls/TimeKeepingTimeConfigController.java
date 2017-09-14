package com.swt.timekeeping.impls;

import java.util.List;

import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.timekeeping.domain.TimeConfig;
import com.swt.timekeeping.domain.UserTimeConfig;

/**
 * TimeKeepingTimeConfigController
 * 
 * @author TrangPig
 * 
 */
public class TimeKeepingTimeConfigController {
	/**
	 * Instance of TimeKeepingTimeConfigController
	 */
	public static final TimeKeepingTimeConfigController Instance = new TimeKeepingTimeConfigController();

	private TimeKeepingTimeConfigDAO ttcDAO = new TimeKeepingTimeConfigDAO();

	/**
	 * insert TimeKeepingTimeConfig
	 * 
	 * @param timeKeepingConfig
	 * @return TimeKeepingTimeConfig
	 */
	public TimeConfig insert(TimeConfig timeKeepingConfig) {
		return ttcDAO.insert(timeKeepingConfig);
	}

	/**
	 * insert list time keeping configuration
	 * 
	 * @param lst
	 * @return
	 */
	public int insert(List<TimeConfig> lstTimeConfig, long orgId) {
		int result = 0;
		List<TimeConfig> TimeConfig = getListTimeKeepingTimeConfigByOrgId(orgId);
		// xoa tat ca cau hinh thoi gian thuoc org
		for (TimeConfig obj : TimeConfig) {
			delete(obj.getTimeConfigId());
		}
		// insert lai cáº¥u hÃ¬nh thá»�i gian má»›i thuá»™c org Ä‘Ã³
		for (TimeConfig timeConfig : lstTimeConfig) {
			timeConfig.setOrgId(orgId);
			if (null != ttcDAO.insert(timeConfig))
				result++;
		}
		// after insert timconfig insert table usertimeconfig
		if (result > 0) {
			TimekeepingUserTimeConfigController.Instance.deleteListUserTimeConfigOrgId(orgId);
			List<Member> lstMember = MemberController.Instance.getListMemberByOrgId(orgId);
			for (Member member : lstMember) {
				for (TimeConfig timeConfig : lstTimeConfig) {
					if (member.getActive()) {
						UserTimeConfig userTimeConfig = new UserTimeConfig();
						userTimeConfig.setDayOfWeek(timeConfig.getDayOfWeek());
						userTimeConfig.setMemberId(member.getId());
						userTimeConfig.setOrgId(orgId);
						userTimeConfig.setSessionWorking(timeConfig.getSessionWorking());
						TimekeepingUserTimeConfigController.Instance.insert(userTimeConfig);
					}

				}
			}
		}
		return result;
	}

	/**
	 * update TimeKeepingTimeConfig
	 * 
	 * @param timeKeepingConfig
	 * @return TimeKeepingTimeConfig
	 */
	public TimeConfig update(TimeConfig timeKeepingConfig) {
		return ttcDAO.update(timeKeepingConfig);
	}

	/**
	 * delete TimeKeepingTimeConfig
	 * 
	 * @param timeKeepingConfigId
	 * @return int
	 */
	public int delete(long timeKeepingConfigId) {
		return ttcDAO.delete(timeKeepingConfigId);
	}

	/**
	 * getTimeKeepingConfigById
	 * 
	 * @param timeKeepingConfigId
	 * @return TimeKeepingTimeConfig
	 */
	public TimeConfig getTimeKeepingConfigById(long timeKeepingConfigId) {
		return ttcDAO.getTimeKeepingConfigById(timeKeepingConfigId);
	}

	/**
	 * getListTimeKeepingTimeConfigByOrgCode
	 * 
	 * @param orgCode
	 * @return List<TimeKeepingTimeConfig>
	 */
	public List<TimeConfig> getListTimeKeepingTimeConfigByOrgCode(long orgId, String dayOfWeek) {
		return ttcDAO.getListTimeKeepingTimeConfigByOrgCode(orgId, dayOfWeek);
	}

	/**
	 * getListTimeKeepingTimeConfigByOrgCode
	 * 
	 * @param orgCode
	 * @return List<TimeConfig>
	 */
	public List<TimeConfig> getListTimeKeepingTimeConfigByOrgId(long orgId) {
		return ttcDAO.getListTimeKeepingTimeConfigByOrgId(orgId);
	}
	/**
	 * get TimeConfig By DayOfWeek and OrgId
	 * @param dayOfWeek
	 * @param orgId
	 * @return
	 */
	public TimeConfig getTimeConfigByDayOfWeekOrgId(int dayOfWeek, long orgId) {
		return ttcDAO.getTimeConfigByDayOfWeekOrgId(dayOfWeek, orgId);
	}
}
