package com.swt.sworld.common;

import java.util.List;

import com.swt.sworld.common.domain.UserSworld;
import com.swt.sworld.communication.customer.object.UserFilterDto;

public interface IUserDAO {
	UserSworld getUserByUserNameAndPwd(String user, String pwd);
	
	List<UserSworld> getUserList(UserFilterDto filter);
	
	UserSworld getUserByUserId(long userid);
	
	UserSworld addUser(UserSworld userSworld);
	
	int updateUser(UserSworld userSworld);
	
	int changeUserGroup(long userid, long newgroupid);
	
	long lockUser(long userid);
	
	long unlockUser(long userid);
	
	long removeUser(long userid);
	
	int resetPassword(long userid, String newpass);
	
	UserSworld getUserByUserName(String user);
	
	int deleteUser(UserSworld userSworld,long userid);
	
	List<UserSworld> getUser(long groupid);
	
	UserSworld getGroupIDByUserId(long userid);

	UserSworld getUserByUserNameAndPassWord(String username, String pwd);
	
	UserSworld getUserByMemberId(long memberId);
	
	int deleteUserShopping(long userId);
}
