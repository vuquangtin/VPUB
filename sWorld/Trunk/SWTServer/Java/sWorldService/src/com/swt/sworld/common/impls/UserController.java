/**
 * 
 */
package com.swt.sworld.common.impls;

import java.util.ArrayList;
import java.util.List;

import com.swt.sworld.common.domain.GroupSworld;
import com.swt.sworld.common.domain.UserSworld;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.communication.customer.object.MethodResultDto;
import com.swt.sworld.communication.customer.object.UserFilterDto;

/**
 * @author Administrator
 *
 */
public class UserController {
	
	public static final UserController Instance = new UserController();
	
	private String methodLock = "LOCK_USER";
	private String methodUnLock = "UNLOCK_USER";
	private String methodRemove = "REMOVE_USER";
	private UserDAOImpl userDao = new UserDAOImpl();
	private GroupDAOImpl groupDao = new GroupDAOImpl();
	private UserController() {

	}
	
	public List<UserSworld> getUserList(UserFilterDto filter)
	{
		List<UserSworld> userSworld = userDao.getUserList(filter);
		return userSworld;
	}
	
	public UserSworld getUserByUserId(long userid)
	{
		return userDao.getUserByUserId(userid);
	}
	
	public UserSworld addUser(UserSworld userSworld)
	{
		UserSworld checkUser = userDao.getUserByUserName(userSworld.getUserName());
		if(checkUser != null)
		{
			checkUser = null;
		}
		else
		{
			checkUser = userDao.addUser(userSworld);
		}
		
		return checkUser;
	}
	
	public int updateUser(UserSworld userSworld)
	{
		return userDao.updateUser(userSworld);
	}
	
	public int changeUserGroup(long userid, long newgroupid)
	{
		int kq = userDao.changeUserGroup(userid, newgroupid);
		
		if(kq == -99)
		{
			kq = ErrorCode.UNKNOW;
		}
		
		return kq;
	}
	
	public List<MethodResultDto> lockUser(List<Long> userid)
	{
		List<MethodResultDto> lstMethod = new ArrayList<MethodResultDto>();
		boolean result = false;
		for (Long id : userid) {
			long kq = userDao.lockUser(id);
			UserSworld nameUser = userDao.getUserByUserId(id);
			if(kq != id && kq<=0)
			{
				MethodResultDto method = new MethodResultDto(nameUser.getUserName(), methodLock, result, String.valueOf(ErrorCode.USER_LOCKED));
				lstMethod.add(method);
			}
			else
			{
				result = true;
				MethodResultDto method = new MethodResultDto(nameUser.getUserName(), methodLock, result, String.valueOf(1000));
				lstMethod.add(method);
			}
			
		}
		
		return lstMethod;
	}
	
	public int resetPassword(long userid, String newpass)
	{
		int kq = userDao.resetPassword(userid, newpass);
		
		if(kq == -99)
		{
			return kq;
		}
		kq = (int)userid;
		return kq;
	}
	
	public List<MethodResultDto> unlockUser(List<Long> userid)
	{
		List<MethodResultDto> lstMethod = new ArrayList<MethodResultDto>();
		boolean result = false;
		for (Long id : userid) {
			long kq = userDao.unlockUser(id);
			UserSworld nameUser = userDao.getUserByUserId(id);
			if(kq<0)
			{
				MethodResultDto method = new MethodResultDto(nameUser.getUserName(), methodUnLock, result, String.valueOf(ErrorCode.USER_NOT_LOCKED));
				lstMethod.add(method);
			}
			else
			{
				result = true;
				MethodResultDto method = new MethodResultDto(nameUser.getUserName(), methodUnLock, result, String.valueOf(1000));
				lstMethod.add(method);
			}
			
		}
		
		return lstMethod;
	}
	
	public  List<MethodResultDto> removeUser(List<Long> userid)
	{
		List<MethodResultDto> lstMethod = new ArrayList<MethodResultDto>();
		boolean result = false;
		for (Long id : userid) {
			long kq = userDao.removeUser(id);
			UserSworld nameUser = userDao.getUserByUserId(id);
			if(kq<0)
			{
				MethodResultDto method = new MethodResultDto(nameUser.getUserName(), methodRemove, result, String.valueOf(ErrorCode.USER_CANCELED));
				lstMethod.add(method);
			}
			else
			{
				result = true;
				MethodResultDto method = new MethodResultDto(nameUser.getUserName(), methodRemove, result, String.valueOf(1000));
				lstMethod.add(method);
			}
			
		}
		
		return lstMethod;
	}

	public UserSworld getUserByNameAndPassWord(String username, String pwd) {
		return userDao.getUserByUserNameAndPassWord(username, pwd);
	}

	public GroupSworld getUserGroup(long groupid) {
			return groupDao.getById(groupid);
	}

	public String getUserPermission(long groupid) {
		GroupSworld group = groupDao.getById(groupid);
		return group.getPermission();
	}
	
	public List<UserSworld> getUsersMerchant(long orgid) {
		return userDao.getUsersMerchant(orgid);
	}
	
	public UserSworld getByMemberId(long memberId)
	{
		return userDao.getUserByMemberId(memberId);
	}
	
	public int deleteUserShopping(long userId)
	{
		return userDao.deleteUserShopping(userId);
	}
}
