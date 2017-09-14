package com.swt.timekeeping;

import java.util.List;

import com.swt.timekeeping.domain.UserTimeConfig;

/** interface ITimekeepingUserTimeConfig 
 * @author Trang-PC
 */
public interface ITimekeepingUserTimeConfig {
	/**
	 * insert
	 * @param userTimeConfig
	 * @return
	 */
	public UserTimeConfig insert(UserTimeConfig userTimeConfig);
	/**
	 * update
	 * @param userTimeConfig
	 * @return
	 */
	public UserTimeConfig update(UserTimeConfig userTimeConfig);
	/**
	 * delete
	 * @param shList
	 * @return
	 */
	public int delete(List<Long> shList);
	/**
	 * get UserTimeConfig By Id
	 * @param id
	 * @return
	 */
	public UserTimeConfig getUserTimeConfigById(long id);
	/**
	 * get List UserTimeConfig By MemberId
	 * @param orgId
	 * @param memberId
	 * @return
	 */
	public List<UserTimeConfig> getListUserTimeConfigByMemberId(long orgId, long memberId);
	/**
	 * delete List UserTimeConfig by OrgId
	 * @param orgId
	 */
	public void deleteListUserTimeConfigOrgId(long orgId);
	
}

