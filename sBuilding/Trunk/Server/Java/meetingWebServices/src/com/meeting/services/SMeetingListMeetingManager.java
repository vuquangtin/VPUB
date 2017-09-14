/**
 * 
 */
package com.meeting.services;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
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
import com.swt.meeting.customObject.ListMeetingJournalistObj;
import com.swt.meeting.domain.ListMeeting;
import com.swt.meeting.impls.ListMeetingController;
import com.swt.meeting.impls.ListMeetingJournalistController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author TaiMai
 *
 * 
 */
@Path(MeetingDefines.LIST_MEETING_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingListMeetingManager {
	// insert ListMeeting
	@POST
	@Path(MeetingDefines.INSERT_LIST_MEETING + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertListMeeting(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject listMeeting) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			ListMeeting nListMeeting = new ListMeeting();
			nListMeeting = Utilites.getInstance().convertJsonObjToObject(listMeeting, ListMeeting.class);
			ListMeeting dl = ListMeetingController.Instance.insert(nListMeeting);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// update ListMeeting
	@POST
	@Path(MeetingDefines.UPDATE_LIST_MEETING + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject updateListMeeting(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject listMeeting) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			ListMeeting nListMeeting = new ListMeeting();
			nListMeeting = Utilites.getInstance().convertJsonObjToObject(listMeeting, ListMeeting.class);
			ListMeeting dl = ListMeetingController.Instance.update(nListMeeting);
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

	// delete ListMeeting
	@POST
	@Path(MeetingDefines.DELETE_LIST_MEETING + "/{token}/{listmeetingid}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject deleteListMeeting(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("listmeetingid") long listMeetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			int kq = ListMeetingController.Instance.delete(listMeetingId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	// get all ListMeeting
	@GET
	@Path(MeetingDefines.GET_ALL_LIST_MEETING + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAllListMeeting(@CookieParam("sessionid") String session, @PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<ListMeeting> dl = ListMeetingController.Instance.getAllListMeeting();
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// get ListMeeting by id
	@GET
	@Path(MeetingDefines.GET_LIST_MEETING_BY_ID + "/{token}/{listmeetingid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getListMeetingById(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("listmeetingid") int listMeetingId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			ListMeeting dl = ListMeetingController.Instance.getListMeetingById(listMeetingId);
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
	 * 27/10/2016 lay danh sach cuoc hop cua nha bao tu serialNumber , ngay va
	 * trong khoang bao nhieu phut truoc sau do
	 *
	 * @param serialNumber
	 * @param dateTime
	 *
	 */
	@GET
	@Path(MeetingDefines.GET_JOURNALIST_OBJ_BY_SERIAL_NUMBER_AND_DATE_TIME
			+ "/{token}/{serialnumber}/{meetingdatetime}/{previousminutes}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getJournalistObjBySerialNumberAndDateTime(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("serialnumber") String serialNumber,
			@PathParam("meetingdatetime") String meetingDateTime, @PathParam("previousminutes") int previousMinutes) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm");
			Date paraMeetingDateTime = new Date();
			try {
				paraMeetingDateTime = simpleDateFormat.parse(meetingDateTime);
			} catch (ParseException e) {
				e.printStackTrace();
			}
			ListMeetingJournalistObj listMeetingJournalistObj = ListMeetingJournalistController.Instance
					.getListMeetingJonalist(serialNumber, paraMeetingDateTime, previousMinutes);
			if (listMeetingJournalistObj != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(listMeetingJournalistObj);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
}
