package com.meeting.services;

import java.util.Date;

import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.meeting.common.MeetingDefines;
import com.sworld.common.Status;
import com.swt.meeting.customObject.MeetingInvitationLCT;
import com.swt.meeting.customObject.ResultStatus;
import com.swt.meeting.impls.MeetingInvitationLCTController;
import com.swt.meeting.impls.MeetingLCTController;

@Path(MeetingDefines.MEETING_LCT_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingMeetingLCTManager {
	public static final String DATE_DEFAULT = "1971-1-1 00:00:00";

	// ----------------------- meeting ----------------------------//

	/**
	 * 
	 * @param token
	 * @param idMeetingtingInvitationLCT // id meeting code de xoa
	 * @param meetingInvitationLCT // meeting moi
	 * @return
	 */
	@POST
	@Path(MeetingDefines.CHANGE_TIME_MEETING_LCT + "/{token}/{idmeetingtinginvitationlct}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultStatus changetimeMeeting(@PathParam("token") String token,
			@PathParam("idmeetingtinginvitationlct") long idMeetingtingInvitationLCT, String meetingInvitationLCT) {
		ResultStatus result = new ResultStatus(Status.FAILED);
		boolean flag = true;
		if (flag) {
			try {
				GsonBuilder gsonBuilder = new GsonBuilder();
				gsonBuilder.setDateFormat("yyyy-MM-dd HH:mm");
				Gson gson = gsonBuilder.create();
				MeetingInvitationLCT nMeetingInvitationLCT = gson.fromJson(meetingInvitationLCT.toString(),
						MeetingInvitationLCT.class);
				System.out.println("change time meeting: idInvitation:" + nMeetingInvitationLCT.getMeetingInvitationId() + ", code: "
						+ nMeetingInvitationLCT.getMeetingName() + " : " + new Date().toString());
				
				boolean check = MeetingLCTController.Instance.changetimeMeeting(idMeetingtingInvitationLCT,nMeetingInvitationLCT);
				if (check) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
			} catch (Exception e) {
				System.out.println(e.getMessage());
				System.out.println("**************FAIL CHANGE TIME****************");
			}
		}
		return result;
	}

	/**
	 * hoan lich
	 * @param token
	 * @param idMeetingtingInvitationLCT // id cuoc hop bi hoan
	 * @return
	 */
	@GET
	@Path(MeetingDefines.POSTPONED_MEETING_LCT + "/{token}/{idmeetingtinginvitationlct}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultStatus postponedMeeting(@PathParam("token") String token,
			@PathParam("idmeetingtinginvitationlct") long idMeetingtingInvitationLCT) {
		ResultStatus result = new ResultStatus(Status.FAILED);
		boolean flag = true;
		if (flag) {
			try {
				boolean check = MeetingLCTController.Instance.postponedMeeting(idMeetingtingInvitationLCT);
				if (check) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
			} catch (Exception e) {
				System.out.println(e.getMessage());
				System.out.println("**************FAIL PSOTPONED****************");
			}
		}
		return result;
	}

	// add meeting invitation
	@POST
	@Path(MeetingDefines.ADD_MEETING_INVITATION_LCT + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultStatus addMeetingInvitation(@PathParam("token") String token, String meetingInvitationLCT) {
		ResultStatus result = new ResultStatus(Status.FAILED);
		boolean flag;
		flag = true;
		if (flag) {
			try {
				GsonBuilder gsonBuilder = new GsonBuilder();
				gsonBuilder.setDateFormat("yyyy-MM-dd HH:mm");
				Gson gson = gsonBuilder.create();
				MeetingInvitationLCT nMeetingInvitationLCT = gson.fromJson(meetingInvitationLCT.toString(),
						MeetingInvitationLCT.class);
				System.out.println("add meeting: idInvitation:" + nMeetingInvitationLCT.getMeetingInvitationId() + ", code: "
						+ nMeetingInvitationLCT.getMeetingName() + " : " + new Date().toString());
				MeetingInvitationLCT object = MeetingInvitationLCTController.Instance.add(nMeetingInvitationLCT);
				if (object != null) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
			} catch (Exception e) {
				System.out.println(e.getMessage());
				System.out.println("**************FAIL ADD****************");
			}
		}
		return result;
	}

	// edit meeting invitation
	@POST
	@Path(MeetingDefines.EDIT_MEETING_INVITATION_LCT + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultStatus editMeetingInvitation(@PathParam("token") String token, String meetingInvitationLCT) {
		ResultStatus result = new ResultStatus(Status.FAILED);
		boolean flag;
		flag = true;
		if (flag) {
			try {
				GsonBuilder gsonBuilder = new GsonBuilder();
				gsonBuilder.setDateFormat("yyyy-MM-dd HH:mm");
				Gson gson = gsonBuilder.create();
				MeetingInvitationLCT nMeetingInvitationLCT = gson.fromJson(meetingInvitationLCT.toString(),
						MeetingInvitationLCT.class);
				MeetingInvitationLCT object = MeetingInvitationLCTController.Instance.edit(nMeetingInvitationLCT);
				if (object != null) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
			} catch (Exception e) {
				System.out.println("**************FAIL EDIT****************");
			}
		}
		return result;
	}

	// delete meeting invitation
	@POST
	@Path(MeetingDefines.DELETE_MEETING_INVITATION_LCT + "/{token}/{idMeetingtingInvitationLCT}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultStatus deleteMeetingInvitation(@PathParam("token") String token,
			@PathParam("idMeetingtingInvitationLCT") String idMeetingtingInvitationLCT) {
		ResultStatus result = new ResultStatus(Status.FAILED);
		boolean flag;
		// flag = TokenManager.getInstance().checkTokenSession(null, token);
		flag = true;
		if (flag) {
			System.out.println("delte meeting " + idMeetingtingInvitationLCT);
			try {
				int object = MeetingInvitationLCTController.Instance.delete(Long.parseLong(idMeetingtingInvitationLCT));
				if (object != 0) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
			} catch (Exception e) {
				System.out.println("**************FAIL DELETE****************");
			}
		}
		return result;
	}

	// ----------------------- close meeting invitation
	// ----------------------------//

}
