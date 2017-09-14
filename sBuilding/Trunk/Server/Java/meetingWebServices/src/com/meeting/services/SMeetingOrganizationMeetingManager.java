/**
 * 
 */
package com.meeting.services;

import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import org.codehaus.jettison.json.JSONObject;

import com.meeting.common.MeetingDefines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.swt.meeting.domain.OrganizationMeeting;
import com.swt.meeting.impls.OrganizationMeetingController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author TaiMai
 *
 * 
 */
@Path(MeetingDefines.ORGANIZATION_MEETING_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingOrganizationMeetingManager {
	// insert OrganizationMeeting
	@POST
	@Path(MeetingDefines.INSERT_ORGANIZATION_MEETING + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertOrganizationMeeting(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject organizationMeeting) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			OrganizationMeeting nOrganizationMeeting = new OrganizationMeeting();
			nOrganizationMeeting = Utilites.getInstance().convertJsonObjToObject(organizationMeeting,
					OrganizationMeeting.class);
			OrganizationMeeting dl = OrganizationMeetingController.Instance.insert(nOrganizationMeeting);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// update OrganizationMeeting
	@POST
	@Path(MeetingDefines.UPDATE_ORGANIZATION_MEETING + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject updateOrganizationMeeting(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject organizationMeeting) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			OrganizationMeeting nOrganizationMeeting = new OrganizationMeeting();
			nOrganizationMeeting = Utilites.getInstance().convertJsonObjToObject(organizationMeeting,
					OrganizationMeeting.class);
			OrganizationMeeting dl = OrganizationMeetingController.Instance.update(nOrganizationMeeting);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				// result.setObj(new Shift());
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// delete OrganizationMeeting
	@POST
	@Path(MeetingDefines.DELETE_ORGANIZATION_MEETING + "/{token}/{organizationmeetingid}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject deleteOrganizationMeeting(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("organizationmeetingid") long organizationMeetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			int kq = OrganizationMeetingController.Instance.delete(organizationMeetingId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	// get all OrganizationMeeting
	@GET
	@Path(MeetingDefines.GET_ALL_ORGANIZATION_MEETING + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAllOrganizationMeeting(@CookieParam("sessionid") String session,
			@PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<OrganizationMeeting> dl = OrganizationMeetingController.Instance.getAllOrganizationMeeting();
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// get all OrganizationMeeting
	@GET
	@Path(MeetingDefines.GET_ALL_ORGANIZATION_MEETING_ASC + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAllOrganizationMeetingASC(@CookieParam("sessionid") String session,
			@PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<OrganizationMeeting> dl = OrganizationMeetingController.Instance.getAllOrganizationMeetingASC();
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@GET
	@Path(MeetingDefines.GET_ALL_ORG_PARTAKER + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAllOrgPartaker(@CookieParam("sessionid") String session, @PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<OrganizationMeeting> dl = OrganizationMeetingController.Instance.getAllOrganizationMeeting();
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// get OrganizationMeeting by id
	@GET
	@Path(MeetingDefines.GET_ORGANIZATION_MEETING_BY_ID + "/{token}/{organizationmeetingid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getOrganizationMeetingById(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("organizationmeetingid") int organizationMeetingId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			OrganizationMeeting dl = OrganizationMeetingController.Instance
					.getOrganizationMeetingById(organizationMeetingId);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
}
