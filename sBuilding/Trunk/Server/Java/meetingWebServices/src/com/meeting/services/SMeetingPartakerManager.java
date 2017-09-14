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

import org.apache.commons.lang3.RandomStringUtils;
import org.codehaus.jettison.json.JSONObject;

import com.google.gson.Gson;
import com.meeting.common.MeetingDefines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.swt.meeting.customObject.KeyOrgMeetingObj;
import com.swt.meeting.domain.MeetingInvitation;
import com.swt.meeting.domain.Partaker;
import com.swt.meeting.impls.MeetingInvitationController;
import com.swt.meeting.impls.PartakerController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author TaiMai
 *
 */
@Path(MeetingDefines.PARTAKER_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingPartakerManager {
	/**
	 * Insert partaker for website
	 * 
	 * @param session
	 * @param token
	 * @param meetingId
	 * @param partaker
	 * @return
	 * @throws Exception
	 */
	@POST
	@Path(MeetingDefines.INSERT_PARTAKER_STRING + "/{token}/{meetingId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertPartaker(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("meetingId") long meetingId, String partaker) throws Exception {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Partaker nPartaker = new Partaker();
			nPartaker = new Gson().fromJson(partaker, Partaker.class);
			String barcode = RandomStringUtils.randomNumeric(12);
			// them m1ot so phia truoc de tranh truong hop random ra co so 0 dau
			// tiên
			barcode = 4 + barcode;
			nPartaker.setBarcode(barcode);
			Partaker dl = PartakerController.Instance.insert(nPartaker, meetingId);
			if (dl != null) {
				MeetingInvitation invitation = new MeetingInvitation();
				invitation.setMeetingBarCode(barcode);
				invitation.setMeetingId(meetingId);
				invitation.setOrganizationAttendId(dl.getOrgId());
				MeetingInvitation meetingInvitation = MeetingInvitationController.Instance.insert(invitation);
				if (meetingInvitation != null) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
				result.setObj(dl);
			}
		}
		return result;
	}

	/**
	 * insert partaker
	 * 
	 * @param session
	 * @param token
	 * @param meetingId
	 * @param partaker
	 * @return
	 * @throws Exception
	 */
	@POST
	@Path(MeetingDefines.INSERT_PARTAKER + "/{token}/{meetingId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertPartaker(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("meetingId") long meetingId, JSONObject partaker) throws Exception {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Partaker nPartaker = new Partaker();
			String barcode = RandomStringUtils.randomNumeric(12);
			// them m1ot so phia truoc de tranh truong hop random ra co so 0 dau
			// tiên
			nPartaker.setBarcode(4 + barcode);
			nPartaker = Utilites.getInstance().convertJsonObjToObject(partaker, Partaker.class);
			Partaker dl = PartakerController.Instance.insert(nPartaker, meetingId);
			if (dl != null) {
				MeetingInvitation invitation = new MeetingInvitation();
				invitation.setMeetingBarCode(barcode);
				invitation.setMeetingId(meetingId);
				invitation.setOrganizationAttendId(dl.getOrgId());
				MeetingInvitation meetingInvitation = MeetingInvitationController.Instance.insert(invitation);
				if (meetingInvitation != null) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
				result.setObj(dl);
			}
		}
		return result;
	}

	/**
	 * Update partaker
	 * 
	 * @param session
	 * @param token
	 * @param partaker
	 * @return
	 */
	@POST
	@Path(MeetingDefines.UPDATE_PARTAKER_STRING + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject updatePartaker(@CookieParam("sessionid") String session, @PathParam("token") String token,
			String partaker) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Partaker nPartaker = new Partaker();
			nPartaker = new Gson().fromJson(partaker, Partaker.class);
			Partaker dl = PartakerController.Instance.update(nPartaker);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * Update partaker format json
	 * @param session
	 * @param token
	 * @param partaker
	 * @return
	 */
	@POST
	@Path(MeetingDefines.UPDATE_PARTAKER + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject updatePartaker(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject partaker) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Partaker nPartaker = new Partaker();
			nPartaker = Utilites.getInstance().convertJsonObjToObject(partaker, Partaker.class);
			Partaker dl = PartakerController.Instance.update(nPartaker);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * delete partaker by id
	 * 
	 * @param session
	 * @param token
	 * @param meetingId
	 * @param PartakerId
	 * @return
	 */
	@GET
	@Path(MeetingDefines.DELETE_PARTAKER + "/{token}/{partakerid}/{meetingId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject deletePartaker(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("meetingId") long meetingId, @PathParam("partakerid") long PartakerId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			int kq = PartakerController.Instance.delete(PartakerId, meetingId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	/**
	 * get Partaker by id
	 * 
	 * @param session
	 * @param token
	 * @param partakerId
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_PARTAKER_BY_ID + "/{token}/{partakerid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getPartakerById(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("partakerid") int partakerId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Partaker dl = PartakerController.Instance.getPartakerById(partakerId);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * Get list partaker
	 * 
	 * @param session
	 * @param token
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_ALL_PARTAKER + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAllPartaker(@CookieParam("sessionid") String session, @PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Partaker> dl = PartakerController.Instance.getAllPartaker();
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * Get detail meeting invite from keycheck dcode base64(website)
	 * 
	 * @param session
	 * @param token
	 * @param keycheck
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_DETAIL_MEETING + "/{token}/{keycheck}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getListPartaker(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("keycheck") String keycheck) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			KeyOrgMeetingObj keyOrgMeetingObj = MeetingInvitationController.Instance.getDetailMeeting(keycheck);
			if (keyOrgMeetingObj != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(keyOrgMeetingObj);
		}
		return result;
	}

	/**
	 * Get list partaker
	 * 
	 * @param session
	 * @param token
	 * @param orgId
	 *            id of orgpartaker
	 * @param meetingid
	 *            id of meeting
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_LIST_PARTAKER_BY_ORG_AND_MEETINGID + "/{token}/{orgid}/{meetingid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getListPartaker(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("orgid") long orgId, @PathParam("meetingid") long meetingid) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Partaker> lstPartaker = MeetingInvitationController.Instance.getInvitationByOrgAndMeetingId(orgId,
					meetingid);
			if (lstPartaker != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(lstPartaker);
		}
		return result;
	}
}
