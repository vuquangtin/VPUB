package com.sworld.web.services;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.Request;
import javax.ws.rs.core.UriInfo;

import com.sworld.common.Defines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.swt.sworld.common.domain.UserSworld;
import com.swt.sworld.common.impls.AuthenticationController;
import com.swt.sworld.common.impls.UserController;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.communication.customer.object.SessionDTO;

@Path(Defines.AUTHENTICATION)
@Produces(Defines.APPLICATION_JSON)
public class Authentication {
	@Context
	UriInfo uriInfo;

	@Context
	Request request;

	/**
	 * 
	 * @param username
	 * @param pwd
	 * @return
	 */
	@GET
	@Path(Defines.LOGIN + "/{user}/{pwd}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject login(@PathParam("user") String username,
			@PathParam("pwd") String pwd) {
		ResultObject result = new ResultObject(Status.FAILED);
		SessionDTO session = AuthenticationController.Instance.login(username,
				pwd, false);
		if (null != session) {
			result.setStatus(Status.SUCCESS);
			result.setToken(session.getToken());
			result.setObj(session);
		} else {
			result.setStatus(Status.FAILED);
			result.setObj(new SessionDTO());
		}
		return result;
	}
	// 2017-07-03 Bug718: All - Token for single user -> vu.pham Start
	@GET
	@Path(Defines.LOGIN + "/{user}/{pwd}/{accpet}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject login2(@PathParam("user") String username,
			@PathParam("pwd") String pwd, @PathParam("accpet") String accept) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean isAccept = false;
		if(accept != null && accept != ""){
			isAccept = true;
		}
		SessionDTO session = AuthenticationController.Instance.login(username,
				pwd, isAccept);
		if (null != session) {
			result.setStatus(Status.SUCCESS);
			result.setToken(session.getToken());
			result.setObj(session);
		} else {
			result.setStatus(Status.FAILED);
			result.setObj(new SessionDTO());
		}
		return result;
	}
	// 2017-07-03 Bug718: All - Token for single user -> vu.pham End
	@GET
	@Path(Defines.LOGIN_UBND + "/{user}/{pwd}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject loginUBND(@PathParam("user") String username,
			@PathParam("pwd") String pwd) {
		ResultObject result = new ResultObject(Status.FAILED);
		SessionDTO session = AuthenticationController.Instance.login(username,pwd);
		if (null != session) {
			result.setStatus(Status.SUCCESS);
			result.setToken(session.getToken());
			result.setObj(null);
		} else {
			result.setStatus(Status.FAILED);
			result.setObj(null);
		}
		return result;
	}
	// 2017-07-03 Bug718: All - Token for single user -> vu.pham Start
	/**
	 * 
	 * @param username
	 * @param pwd
	 * @return
	 */
	@GET
	@Path(Defines.LOGOUT + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject logout(@CookieParam("sessionid") String sessionid,
			@PathParam("token") String token) {

		TokenManager.getInstance().removeTokenSession(sessionid, token);

		return new ResultObject(Status.SUCCESS, Defines.STR_DEFULT);

	}
	// 2017-07-03 Bug718: All - Token for single user -> vu.pham End
	@GET
	@Path(Defines.PEMISSION + "/{token}/{user}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getPermission(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("user") String username) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,
				token);
		if (flag) {
			result.setStatus(Status.SUCCESS);
		}

		return result;
	}

	@GET
	@Path(Defines.GET_USER_BY_ID + "/{token}/{userId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getUserById(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("userId") long userId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		UserSworld user = UserController.Instance.getUserByUserId(userId);
		if (flag) {
			result.setStatus(Status.SUCCESS);
			result.setObj(user);
		}
		else {
			result.setStatus(Status.FAILED);
		}

		return result;
	}
}
