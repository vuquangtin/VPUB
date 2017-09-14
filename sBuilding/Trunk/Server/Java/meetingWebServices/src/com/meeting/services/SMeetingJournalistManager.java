package com.meeting.services;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import org.codehaus.jettison.json.JSONObject;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.meeting.common.MeetingDefines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.swt.meeting.customObject.ListMeetingJournalistObj;
import com.swt.meeting.customObject.NumberObj;
import com.swt.meeting.impls.AttendMeetingJournalistController;
import com.swt.meeting.impls.JournaListController;
import com.swt.meeting.impls.ListMeetingJournalistController;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.ps.domain.Member;

/**
 * @author Ten.Nguyen
 *
 * 
 */
@Path(MeetingDefines.JOURNALIST_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingJournalistManager {

	/**
	 * lay thong tin nha bao
	 * 
	 * @param session
	 * @param token
	 * @param serialNumber
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_JOURNALIST_OBJ + "/{token}/{serialNumber}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getMeetingInvitationById(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("serialNumber") String serialNumber) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Member journaListObj = JournaListController.Instance.getJournalistBySerial(serialNumber);
			if (journaListObj != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(journaListObj);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// 28/10/2016 custom object : insert AttendMeetingJournalist object
	@POST
	@Path(MeetingDefines.INSERT_ATTEND_MEETING_JOURNALIST_OBJ + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertAttendMeetingJournalistObj(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject listAttendMeetingObj) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			ListMeetingJournalistObj nListMeetingJournalistObj = new ListMeetingJournalistObj();
			GsonBuilder gsonBuilder = new GsonBuilder();
			gsonBuilder.setDateFormat("yyyy-MM-dd HH:mm");
			Gson gson = gsonBuilder.create();
			nListMeetingJournalistObj = gson.fromJson(listAttendMeetingObj.toString(), ListMeetingJournalistObj.class);
			if (AttendMeetingJournalistController.Instance.insert(nListMeetingJournalistObj)) {
				result.setStatus(Status.SUCCESS);
			}
		}
		return result;

	}

	@GET
	@Path(MeetingDefines.CHECK_IS_DATE_EXPIRATED + "/{token}/{serialnumber}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject isDateExpirated(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("serialnumber") String serialNumber) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);

		if (flag) {
			int isDateExpirated = JournaListController.Instance.isDateExpirated(serialNumber);
			if (isDateExpirated == 1) { // Het han
				result.setStatus(Status.SUCCESS);
			}
		}

		return result;
	}

	/**
	 * 28/10/2016 checkout for journalist
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * 
	 */
	@GET
	@Path(MeetingDefines.CHECKOUT_JOURNALIST + "/{token}/{serialnumber}/{date}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject checkoutJournalist(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("serialnumber") String serialNumber, @PathParam("date") String date) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm");
			Date paraDate = null;
			try {
				paraDate = simpleDateFormat.parse(date);
			} catch (ParseException e) {
				e.printStackTrace();
			}
			NumberObj checkoutJournalist = AttendMeetingJournalistController.Instance.checkoutJournalist(serialNumber,
					paraDate);
			result.setStatus(Status.SUCCESS);
			result.setObj(checkoutJournalist);
		}
		return result;
	}

	// /**
	// * 27/11/2016 thong ke journalist theo theo meetingid
	// *
	// * @param serialNumber
	// * @param dateTime
	// *
	// */
	// @GET
	// @Path(MeetingDefines.STATISTIC_JOURNALIST_BY_MEETINGID +
	// "/{token}/{meetingid}")
	// @Consumes(MediaType.APPLICATION_JSON)
	// public ResultObject statisticJournalistsByDate(@CookieParam("sessionid")
	// String session,
	// @PathParam("token") String token, @PathParam("meetingid") long meetingId)
	// {
	// ResultObject result = new ResultObject(Status.FAILED);
	// boolean flag = TokenManager.getInstance().checkTokenSession(session,
	// token);
	// if (flag) {
	// // List<AttendMeetingJournalist> rs =
	// //
	// AttendMeetingJournalistController.Instance.getAttendMeetingJournalistStatisticByMeetingId(meetingId);
	// // if (rs != null) {
	// // result.setStatus(Status.SUCCESS);
	// // result.setObj(rs);
	// // } else {
	// // result.setStatus(Status.FAILED);
	// // }
	// }
	// return result;
	// }

	/**
	 * 27/10/2016 lay danh sach cuoc hop cua nha bao tu serialNumber , ngay va
	 * trong khoang bao nhieu phut truoc sau do
	 *
	 * @param serialNumber
	 * @param dateTime
	 *
	 */
	// @GET
	// @Path(MeetingDefines.GET_JOURNALIST_OBJ_BY_SERIAL_NUMBER_AND_DATE_TIME
	// + "/{token}/{serialnumber}/{meetingdatetime}/{previousminutes}")
	// @Consumes(MediaType.APPLICATION_JSON)
	// public ResultObject
	// getJournalistObjBySerialNumberAndDateTime(@CookieParam("sessionid")
	// String session,
	// @PathParam("token") String token, @PathParam("serialnumber") String
	// serialNumber,
	// @PathParam("meetingdatetime") String meetingDateTime,
	// @PathParam("previousminutes") int previousMinutes) {
	// ResultObject result = new ResultObject(Status.FAILED);
	// boolean flag = TokenManager.getInstance().checkTokenSession(session,
	// token);
	// if (flag) {
	// SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd
	// HH:mm");
	// Date paraMeetingDateTime = new Date();
	// try {
	// paraMeetingDateTime = simpleDateFormat.parse(meetingDateTime);
	// } catch (ParseException e) {
	// e.printStackTrace();
	// }
	// ListMeetingJournalistObj listMeetingJournalistObj =
	// ListMeetingJournalistController.Instance
	// .getListMeetingJonalist(serialNumber, paraMeetingDateTime,
	// previousMinutes);
	// if (listMeetingJournalistObj != null) {
	// result.setStatus(Status.SUCCESS);
	// result.setObj(listMeetingJournalistObj);
	// } else {
	// result.setStatus(Status.FAILED);
	// }
	// }
	// return result;
	// }
	@GET
	@Path(MeetingDefines.GET_JOURNALIST_OBJ_BY_SERIAL_NUMBER_AND_DATE_TIME
			+ "/{token}/{serialnumber}/{meetingdatetime}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getJournalistObjBySerialNumberAndDateTime(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("serialnumber") String serialNumber,
			@PathParam("meetingdatetime") String meetingDateTime) {

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
					.getListMeetingJonalist(serialNumber, paraMeetingDateTime);
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