/**
 * 
 */
package com.sworld.web.services;

import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import org.codehaus.jettison.json.JSONArray;
import org.codehaus.jettison.json.JSONObject;

import com.sworld.common.Defines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.swt.sworld.common.domain.GroupSworld;
import com.swt.sworld.common.domain.LoginHistory;
import com.swt.sworld.common.domain.PolicySworld;
import com.swt.sworld.common.domain.UserSworld;
import com.swt.sworld.common.impls.AuthenticationController;
import com.swt.sworld.common.impls.GroupController;
import com.swt.sworld.common.impls.LoginHistoryController;
import com.swt.sworld.common.impls.PolicyController;
import com.swt.sworld.common.impls.UserController;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.communication.customer.object.GroupCustomerDto;
import com.swt.sworld.communication.customer.object.GroupFilterDto;
import com.swt.sworld.communication.customer.object.LoginHistoryFilterDto;
import com.swt.sworld.communication.customer.object.MethodResultDto;
import com.swt.sworld.communication.customer.object.SessionDTO;
import com.swt.sworld.communication.customer.object.UserFilterDto;

/**
 * @author Administrator
 * 
 */
@Path(Defines.OTHER)
@Produces(Defines.APPLICATION_JSON)
public class OtherManager {

	@POST
	@Path(Defines.GET_GROUP_LIST + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGroupList(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject groupFilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			GroupFilterDto groupFter = new GroupFilterDto();
			groupFter = Utilites.getInstance().convertJsonObjToObject(groupFilter, groupFter.getClass());
			List<GroupSworld> lstgroup = GroupController.Instance.getGroupList(groupFter);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstgroup);
		}
		return result;
	}

	@GET
	@Path(Defines.GET_GROUP_BY_GROUPID + "/{token}/{groupid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGroupByGroupId(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("groupid") long groupid) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			GroupCustomerDto groupFunction = GroupController.Instance.getGroupByGroupId(groupid);
			result.setStatus(Status.SUCCESS);
			result.setObj(groupFunction);
		}
		return result;
	}

	@POST
	@Path(Defines.ADD_GROUP + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postAddGroup(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject groupCustommer) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			GroupCustomerDto group = new GroupCustomerDto();
			group = Utilites.getInstance().convertJsonObjToObject(groupCustommer, group.getClass());
			GroupCustomerDto groupcus = GroupController.Instance.addGroup(group);
			result.setStatus(Status.SUCCESS);
			result.setObj(groupcus);
		}
		return result;
	}

	@POST
	@Path(Defines.UPDATE_GROUP + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postUpdateGroup(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject groupCustommer) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			GroupCustomerDto group = new GroupCustomerDto();
			group = Utilites.getInstance().convertJsonObjToObject(groupCustommer, group.getClass());
			GroupCustomerDto groupcus = GroupController.Instance.updateGroup(group);
			result.setStatus(Status.SUCCESS);
			result.setObj(groupcus);
		}
		return result;
	}

	@GET
	@Path(Defines.REMOVE_GROUP + "/{token}/{groupId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postRemoveGroup(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("groupId") long groupId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<MethodResultDto> lstMethod = GroupController.Instance.removeGroup(groupId);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMethod);
		}
		return result;
	}

	@POST
	@Path(Defines.GET_USER_LIST + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetUserList(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject userFilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			UserFilterDto user = new UserFilterDto();
			user = Utilites.getInstance().convertJsonObjToObject(userFilter, user.getClass());
			List<UserSworld> lstUser = UserController.Instance.getUserList(user);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstUser);
		}
		return result;
	}

	@GET
	@Path(Defines.GET_USER_BY_USERID + "/{token}/{userid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetUserByUserId(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("userid") long userid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			UserSworld lstUser = UserController.Instance.getUserByUserId(userid);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstUser);
		}
		return result;
	}

	@POST
	@Path(Defines.ADD_USER + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postAddUser(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject userDB) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			UserSworld userSworld = new UserSworld();
			userSworld = Utilites.getInstance().convertJsonObjToObject(userDB, userSworld.getClass());
			UserSworld lstUser = UserController.Instance.addUser(userSworld);
			if (lstUser == null) {
				result.setStatus(Status.FAILED);
			} else {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstUser);
			}
		}
		return result;
	}

	@POST
	@Path(Defines.UPDATE_USER + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postUpdateUser(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject userDB) {
		int kq = -100;
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			UserSworld userSworld = new UserSworld();
			userSworld = Utilites.getInstance().convertJsonObjToObject(userDB, userSworld.getClass());
			kq = UserController.Instance.updateUser(userSworld);
			if (kq != -1) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(userSworld);
		}
		return result;
	}

	@GET
	@Path(Defines.CHANGE_USER_GROUP + "/{token}/{userid}/{newgroupid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postChangeUserGroup(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("userid") long userid, @PathParam("newgroupid") long newgroupid) {
		int kq = -100;
		ResultObject result = new ResultObject(Status.FAILED);
		UserSworld userSworld = new UserSworld();
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			kq = UserController.Instance.changeUserGroup(userid, newgroupid);
			if (kq != -1) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(userSworld);
		}
		return result;
	}

	@POST
	@Path(Defines.LOCK_USER + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postLockUsers(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONArray userid) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> luser = Utilites.getInstance().convertJsonArrayToListLong(userid);
			List<MethodResultDto> lstMethod = UserController.Instance.lockUser(luser);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMethod);
		}
		return result;
	}

	@GET
	@Path(Defines.RESET_PASSWORD + "/{token}/{userid}/{newpassword}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postResetPassword(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("userid") long userid, @PathParam("newpassword") String newpassword) {
		ResultObject result = new ResultObject(Status.FAILED);
		UserSworld userSworld = new UserSworld();
		int kq = 0;
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			String[] pass = newpassword.split("@");
			String userName = pass[0];
			String passOld = pass[1];
			String passNew = pass[2];
			//false để giữ lại token
			SessionDTO sessionDTO = AuthenticationController.Instance.login(userName, passOld,false);
			if (sessionDTO != null) {
				result.setStatus(Status.FAILED);
				kq = UserController.Instance.resetPassword(userid, passNew);
				if (kq < 0) {
					result.setStatus(Status.FAILED);
				} else {
					result.setStatus(Status.SUCCESS);
				}
				result.setObj(userSworld);
			}else{
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@POST
	@Path(Defines.UNLOCK_USER + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postUnLockUsers(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONArray userid) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> user = Utilites.getInstance().convertJsonArrayToListLong(userid);
			List<MethodResultDto> lstMethod = UserController.Instance.unlockUser(user);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMethod);
		}
		return result;
	}

	@POST
	@Path(Defines.REMOVE_USER + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postRemoveUser(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONArray userid) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> user = null;
			user = Utilites.getInstance().convertJsonArrayToListLong(userid);
			List<MethodResultDto> lstMethod = UserController.Instance.removeUser(user);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMethod);
		}
		return result;
	}

	@POST
	@Path(Defines.GET_LOGIN_HISTORY + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetLoginHistory(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject login) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			LoginHistoryFilterDto loginhistory = new LoginHistoryFilterDto();
			loginhistory = Utilites.getInstance().convertJsonObjToObject(login, loginhistory.getClass());
			List<LoginHistory> lstlogin = LoginHistoryController.Instance.getLoginHistoryList(loginhistory);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstlogin);
		}
		return result;
	}

	@GET
	@Path(Defines.GET_PERMISSION_LIST + "/{token}/{userid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getPermissionList(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("userid") long userid) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<PolicySworld> lstpol = PolicyController.Instance.getPermissionList(userid);
			if (lstpol != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstpol);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

}
