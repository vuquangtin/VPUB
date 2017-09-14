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
import com.swt.meeting.domain.MeetingInvitation;
import com.swt.meeting.impls.MeetingInvitationController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author TaiMai
 *
 * 
 */
@Path(MeetingDefines.MEETING_INVITATION_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingMeetingInvitationManager {
	// insert MeetingInvitation
		@POST
		@Path(MeetingDefines.INSERT_MEETING_INVITATION + "/{token}")
		@Produces(MediaType.APPLICATION_JSON)
		@Consumes(MediaType.APPLICATION_JSON)
		public ResultObject insertMeetingInvitation(@CookieParam("sessionid") String session, @PathParam("token") String token,
				JSONObject meetingInvitation) {
			ResultObject result = new ResultObject(Status.FAILED);
			boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
			if (flag) {
				MeetingInvitation nMeetingInvitation = new MeetingInvitation();
				nMeetingInvitation = Utilites.getInstance().convertJsonObjToObject(meetingInvitation, MeetingInvitation.class);
				MeetingInvitation dl = MeetingInvitationController.Instance.insert(nMeetingInvitation);
				if (dl != null) {
					result.setStatus(Status.SUCCESS);
					result.setObj(dl);
				} else {
					result.setStatus(Status.FAILED);
				}
			}
			return result;
		}

		// update MeetingInvitation
		@POST
		@Path(MeetingDefines.UPDATE_MEETING_INVITATION + "/{token}")
		@Produces(MediaType.APPLICATION_JSON)
		@Consumes(MediaType.APPLICATION_JSON)
		public ResultObject updateMeetingInvitation(@CookieParam("sessionid") String session, @PathParam("token") String token,
				JSONObject meetingInvitation) {
			ResultObject result = new ResultObject(Status.FAILED);
			boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
			if (flag) {
				MeetingInvitation nMeetingInvitation = new MeetingInvitation();
				nMeetingInvitation = Utilites.getInstance().convertJsonObjToObject(meetingInvitation, MeetingInvitation.class);
				MeetingInvitation dl = MeetingInvitationController.Instance.update(nMeetingInvitation);
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

		// delete MeetingInvitation
		@POST
		@Path(MeetingDefines.DELETE_MEETING_INVITATION + "/{token}/{meetinginvitationid}")
		@Produces(MediaType.APPLICATION_JSON)
		@Consumes(MediaType.APPLICATION_JSON)
		public ResultObject deleteMeetingInvitation(@CookieParam("sessionid") String session, @PathParam("token") String token,
				@PathParam("meetinginvitationid") long meetingInvitationId) {
			ResultObject result = new ResultObject(Status.FAILED);
			boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
			if (flag) {
				int kq = MeetingInvitationController.Instance.delete(meetingInvitationId);
				if (kq == ErrorCode.SUCCESS) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
			}

			return result;
		}

		// get all MeetingInvitation
		@GET
		@Path(MeetingDefines.GET_ALL_MEETING_INVITATION + "/{token}")
		@Consumes(MediaType.APPLICATION_JSON)
		public ResultObject getAllMeetingInvitation(@CookieParam("sessionid") String session, @PathParam("token") String token) {
			ResultObject result = new ResultObject(Status.FAILED);
			boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
			if (flag) {
				List<MeetingInvitation> dl = MeetingInvitationController.Instance.getAllMeetingInvitation();
				if (dl != null) {
					result.setStatus(Status.SUCCESS);
					result.setObj(dl);
				} else {
					result.setStatus(Status.FAILED);
				}
			}
			return result;
		}

		// get MeetingInvitation by id
		@GET
		@Path(MeetingDefines.GET_MEETING_INVITATION_BY_ID + "/{token}/{meetinginvitationid}")
		@Consumes(MediaType.APPLICATION_JSON)
		public ResultObject getMeetingInvitationById(@CookieParam("sessionid") String session, @PathParam("token") String token,
				@PathParam("meetinginvitationid") int MeetingInvitationId) {

			ResultObject result = new ResultObject(Status.FAILED);
			boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
			if (flag) {
				MeetingInvitation dl = MeetingInvitationController.Instance.getMeetingInvitationById(MeetingInvitationId);
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
