package com.swt.timekeeping.impls;

import java.util.ArrayList;
import java.util.List;

import com.swt.timekeeping.domain.UserTimeConfig;
/**
 * TimekeepingUserTimeConfigController
 * @author Trang-PC
 *
 */
public class TimekeepingUserTimeConfigController {

	private TimekeepingUserTimeConfigDAO utcDAO = new TimekeepingUserTimeConfigDAO();
	 /**
	  * TimekeepingUserTimeConfigController Instance
	  */
	public static final TimekeepingUserTimeConfigController Instance = new TimekeepingUserTimeConfigController();
	/**
	 * insert
	 * @param userTimeConfig
	 * @return
	 */
	public UserTimeConfig insert(UserTimeConfig userTimeConfig) {
		return utcDAO.insert(userTimeConfig);	
		}
	/**
	 * update
	 * @param userTimeConfig
	 * @return
	 */
	public UserTimeConfig update(UserTimeConfig userTimeConfig) {
		return utcDAO.update(userTimeConfig);
	}
	/**
	 * delete
	 * @param shList
	 * @return
	 */
	public int delete(List<Long> shList) {
		return utcDAO.delete(shList);
	}
	/**
	 * get UserTimeConfig By Id
	 * @param id
	 * @return
	 */
	public UserTimeConfig getUserTimeConfigById(long id){
		return utcDAO.getUserTimeConfigById(id);
	}
	/**
	 * get ListUserTimeConfig By MemberId
	 * @param orgId
	 * @param memberId
	 * @return
	 */
	public List<UserTimeConfig> getListUserTimeConfigByMemberId(long orgId, long memberId){
		return utcDAO.getListUserTimeConfigByMemberId(orgId, memberId);
	}
	/**
	 * delete ListUserTimeConfig by OrgId
	 * @param orgId
	 */
	public void deleteListUserTimeConfigOrgId(long orgId){
		utcDAO.deleteListUserTimeConfigOrgId(orgId);
	}
	/**
	 * get ListUserTimeConfig By MemberIdList
	 * @param orgId
	 * @param memberId
	 * @return
	 */
	public List<List<UserTimeConfig>> getListUserTimeConfigByMemberIdList(long orgId, List<Long> memberId){
		List<List<UserTimeConfig>> resultList = new ArrayList<List<UserTimeConfig>>();
		List<UserTimeConfig> list = null;
		for (long id : memberId) {
			list = utcDAO.getListUserTimeConfigByMemberId(orgId, id);
			if(null != list && list.size() != 0)
			resultList.add(list);
		}
		
		return resultList;
	}
}
