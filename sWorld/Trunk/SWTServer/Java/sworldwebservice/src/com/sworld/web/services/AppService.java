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
import javax.ws.rs.core.Context;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Request;
import javax.ws.rs.core.UriInfo;

import org.codehaus.jettison.json.JSONObject;

import com.sworld.common.Defines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.swt.sworld.ams.domain.App;
import com.swt.sworld.ams.impls.AppController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author Administrator
 *
 */

@Path(Defines.AMS)
@Produces(Defines.APPLICATION_JSON)
public class AppService {
	
	@Context
	UriInfo uriInfo;

	@Context
	Request request;
	
	@GET
	@Path(Defines.GET_APP_DATA_LIST + "/{token}/{orgid}/{subOrgId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getAppDataList(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token,@PathParam("orgid") long orgid, 
			@PathParam("subOrgId") long subOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			List<App> app = AppController.Instance.GetAll();
			result.setStatus(Status.SUCCESS);
			result.setObj(app);
		}

		return result;
	}
	
	@POST
	@Path(Defines.INSERT_APP + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postInsertApp(@CookieParam("sessionid") String session,
			@PathParam("token") String token,JSONObject app) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			App application = new App();
			application = Utilites.getInstance().convertJsonObjToObject(app, application.getClass());
			int kq = AppController.Instance.insert(application);
			if(kq == ErrorCode.SUCCESS)
			{
				result.setStatus(Status.SUCCESS);
			}
			else
			{
				result.setStatus(Status.FAILED);
			}
			
		}
		return result;
	}
	
	@POST
	@Path(Defines.UPDATE_APP + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postUpdateApp(@CookieParam("sessionid") String session,
			@PathParam("token") String token,JSONObject app) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			App application = new App();
			application = Utilites.getInstance().convertJsonObjToObject(app, application.getClass());
			int kq = AppController.Instance.update(application);
			if(kq == ErrorCode.SUCCESS)
			{
				result.setStatus(Status.SUCCESS);
			}
			else
			{
				result.setStatus(Status.FAILED);
			}
			
		}
		return result;
	}
	
	@GET
	@Path(Defines.DELETE_APP + "/{token}/{id}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postDeleteApp(@CookieParam("sessionid") String session,
			@PathParam("token") String token,@PathParam("id") long id) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			int kq = AppController.Instance.delete(id);
			if(kq == ErrorCode.SUCCESS)
			{
				result.setStatus(Status.SUCCESS);
			}
			else
			{
				result.setStatus(Status.FAILED);
			}
			
		}
		return result;
	}
	
	@GET
	@Path(Defines.GET_APP_BY_APP_ID + "/{token}/{appid}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getAppByAppId(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token,@PathParam("appid") long appid) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			App app = AppController.Instance.GetAppByAppId(appid);
			result.setStatus(Status.SUCCESS);
			result.setObj(app);
		}
		return result;
	}

}
