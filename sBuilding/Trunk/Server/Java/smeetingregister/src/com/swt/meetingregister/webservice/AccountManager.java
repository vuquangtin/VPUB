package com.swt.meetingregister.webservice;


import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.swt.meetingregister.common.Define;
import com.swt.meetingregister.controller.RegisterAccountController;
import com.swt.meetingregister.doman.Account;
import com.swt.meetingregister.doman.EmailConfig;

/**
 * @author Tenit
 *
 */
@Path(Define.ACCOUNT)
@Produces(Define.APPLICATION_JSON)
public class AccountManager {

	@GET
	@Path(Define.LOGIN + "/{username}/{password}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject login(@CookieParam("sessionid") String session, @PathParam("username") String userName,
			@PathParam("password") String passWord) {

		ResultObject result = new ResultObject(Status.FAILED);
		Account account = RegisterAccountController.Instance.login(userName, passWord);

		if (account != null) {
			result.setStatus(Status.SUCCESS);
		} else {
			result.setStatus(Status.FAILED);
		}
		result.setObj(account);

		return result;
	}

	@POST
	@Path(Define.INSERT)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject InsertAccount(Account account) {

		ResultObject result = new ResultObject(Status.FAILED);
		Account accountResult = RegisterAccountController.Instance.insert(account);
		if (accountResult != null) {
			result.setStatus(Status.SUCCESS);
		} else {
			result.setStatus(Status.FAILED);
		}
		result.setObj(accountResult);
		return result;
	}
	@POST
	@Path(Define.REGISTER_EMAIL)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject registerEmail(EmailConfig emailConfigobj) {

		ResultObject result = new ResultObject(Status.FAILED);
		EmailConfig emailConfig = RegisterAccountController.Instance.insertEmailConfig(emailConfigobj);
		if (emailConfig != null) {
			result.setStatus(Status.SUCCESS);
		} else {
			result.setStatus(Status.FAILED);
		}
		result.setObj(emailConfig);
		return result;
	}
}
