
package com.meeting.services;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import com.google.gson.Gson;
import com.meeting.common.MeetingDefines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.swt.meeting.customObject.OrganizationLCT;
import com.swt.meeting.impls.OrganizationLCTController;
import com.swt.sworld.common.utilitis.TokenManager;


/**
 * @author My.nguyen
 *
 * 
 */
@Path(MeetingDefines.ORGANIZATION_MEETING_LCT_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingOrganizationLCTManager {
	// insert OrganizationLCT
	@POST
	@Path(MeetingDefines.INSERT_ORGANIZATION_MEETING_LCT + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertOrganizationLCTLCT(@CookieParam("sessionid") String session, @PathParam("token") String token,
			String organizationLCT) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Gson gson = new Gson();
			OrganizationLCT nOrganizationLCT = gson.fromJson(organizationLCT, OrganizationLCT.class);
			boolean dl = OrganizationLCTController.Instance.insert(nOrganizationLCT);
			
			
			if (dl) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@POST
	@Path(MeetingDefines.UPDATE_ORGANIZATION_MEETING_LCT + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject updateOrganizationLCTLCT(@CookieParam("sessionid") String session, @PathParam("token") String token,
			String organizationLCT) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Gson gson = new Gson();
			OrganizationLCT nOrganizationLCT = gson.fromJson(organizationLCT, OrganizationLCT.class);
			boolean dl = OrganizationLCTController.Instance.update(nOrganizationLCT);
			if (dl) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				// result.setObj(new Shift());
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// delete OrganizationLCT
	@POST
	@Path(MeetingDefines.DELETE_ORGANIZATION_MEETING_LCT + "/{token}/{organizationLCTid}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject deleteOrganizationLCTLCT(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("organizationLCTid") long organizationLCTId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			boolean kq = OrganizationLCTController.Instance.delete(organizationLCTId);
			if (kq) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

}
