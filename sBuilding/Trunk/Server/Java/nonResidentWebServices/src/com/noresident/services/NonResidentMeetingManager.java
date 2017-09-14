package com.noresident.services;

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

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.nonresident.common.NonResidentDefines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.swt.nonresident.customObject.NonResidentMeetingObj;
import com.swt.nonresident.domain.NonResidentMeeting;
import com.swt.nonresident.impls.NonResidentMeetingController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;

@Path(NonResidentDefines.NON_RESIDENT_MEETING_MANAGER)
@Produces(NonResidentDefines.APPLICATION_JSON)
public class NonResidentMeetingManager {
	public static final String FORMAT_DATE = "yyyy-MM-dd HH:mm:ss";
	public static final String FORMAT_DATE_GETLIST = "yyyy-MM-dd";

	// insert nonresident
	@POST
	@Path(NonResidentDefines.INSERT_NON_RESIDENT_MEETING + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertNonResidentMeeting(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject nonResidentMeeting) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentMeeting nNonResidentMeeting = null;
			GsonBuilder gsonBuilder = new GsonBuilder();
			gsonBuilder.setDateFormat(FORMAT_DATE);
			Gson gson = gsonBuilder.create();
			nNonResidentMeeting = gson.fromJson(nonResidentMeeting.toString(), NonResidentMeeting.class);
			NonResidentMeeting rs = NonResidentMeetingController.Instance.insert(nNonResidentMeeting);
			if (rs != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(rs);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}


	/**
	 * 30/11/2016 lay danh sach cuoc hop tu ngay den ngay
	 *
	 * @param date
	 */
	@GET
	@Path(NonResidentDefines.GET_NON_RESIDENT_MEETING_BY_ORGANIZATION_MEETING_ID + "/{token}/{organizationmeetingid}")
	@Produces(MediaType.APPLICATION_JSON)
	public ResultObject getNonResidentMeetingByDate(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("organizationmeetingid") long organizationMeetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<NonResidentMeeting> rs = NonResidentMeetingController.Instance
					.getNonResidentMeetingByOrganizationMeetingId(organizationMeetingId);
			if (rs != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(rs);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * 30/11/2016 lay danh sach cuoc hop tu ngay den ngay va ten to chuc cuoc
	 * hop va ten cuoc hop
	 * 
	 * @param start
	 * @param end
	 * @param fromTime
	 * @param toTime
	 * @param organizationMeetingId
	 * @param meetingName
	 */
	@GET
	@Path(NonResidentDefines.GET_NON_RESIDENT_MEETING_BY_DATE_AND_ORGANIZATION_MEETING_ID_AND_MEETING_NAME
			+ "/{token}/{start}/{end}/{fromdate}/{todate}/{organizationmeetingid}/{meetingname}")
	@Produces(MediaType.APPLICATION_JSON)
	public ResultObject getNonResidentMeetingByDateAndOrgIdAndMeetingName(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("start") int start, @PathParam("end") int end,
			@PathParam("fromdate") String fromDate, @PathParam("todate") String toDate,
			@PathParam("organizationmeetingid") long organizationMeetingId,
			@PathParam("meetingname") String meetingName) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat(FORMAT_DATE_GETLIST);
			Date paraFromDate = null;
			Date paraToDate = null;
			try {
				paraFromDate = simpleDateFormat.parse(fromDate);
				paraToDate = simpleDateFormat.parse(toDate);
			} catch (java.text.ParseException e) {
				e.printStackTrace();
			}
			NonResidentMeetingObj rs = NonResidentMeetingController.Instance
					.getNonResidentMeetingByDateAndOrgIdAndMeetingName(start, end, paraFromDate, paraToDate,
							organizationMeetingId, meetingName);
			if (rs != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(rs);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * 6/12/2016 lay cuoc hop theo id hop va ten cuoc hop
	 * 
	 * @param meetingId
	 */
	@GET
	@Path(NonResidentDefines.GET_NON_RESIDENT_MEETING_BY_ID + "/{token}/{meetingid}")
	@Produces(MediaType.APPLICATION_JSON)
	public ResultObject getNonResidentMeetingById(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("meetingid") long meetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentMeeting rs = NonResidentMeetingController.Instance.getNonResidentMeetingById(meetingId);
			if (rs != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(rs);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * 6/12/2016 cap nhat thay doi cuoc hop
	 * 
	 */
	@POST
	@Path(NonResidentDefines.UPDATE_NON_RESIDENT_MEETING + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject updateNonResidentMeeting(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject nonResidentMeeting) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentMeeting nNonResidentMeeting = null;
			GsonBuilder gsonBuilder = new GsonBuilder();
			gsonBuilder.setDateFormat(FORMAT_DATE);
			Gson gson = gsonBuilder.create();
			nNonResidentMeeting = gson.fromJson(nonResidentMeeting.toString(), NonResidentMeeting.class);
			NonResidentMeeting rs = NonResidentMeetingController.Instance.update(nNonResidentMeeting);
			if (rs != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(rs);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// delete room
	@GET
	@Path(NonResidentDefines.DELETE_NON_RESIDENT_MEETING + "/{token}/{meetingid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject deleteRoom(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("meetingid") long meetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			int kq = NonResidentMeetingController.Instance.delete(meetingId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

}
