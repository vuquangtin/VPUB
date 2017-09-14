package com.meeting.services;

import java.io.UnsupportedEncodingException;
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

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.meeting.common.MeetingDefines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.swt.meeting.customObject.MeetingObjManager;
import com.swt.meeting.customObject.ObjectMail;
import com.swt.meeting.domain.EmailConfig;
import com.swt.meeting.domain.Meeting;
import com.swt.meeting.domain.Partaker;
import com.swt.meeting.impls.MeetingController;
import com.swt.meeting.impls.PartakerController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author TaiMai
 * 
 */
@Path(MeetingDefines.MEETING_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingMeetingManager {
	public static final String FORMAT_DATE = "yyyy-MM-dd HH:mm:ss";
	public static final String FORMAT_DATE_GETLIST = "yyyy-MM-dd";

	// insert meeting
	@POST
	@Path(MeetingDefines.INSERT_MEETING + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertMeeting(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject meeting) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Meeting nMeeting = new Meeting();
			GsonBuilder gsonBuilder = new GsonBuilder();
			gsonBuilder.setDateFormat("yyyy-MM-dd HH:mm:ss");
			Gson gson = gsonBuilder.create();
			nMeeting = gson.fromJson(meeting.toString(), Meeting.class);
			Meeting dl = MeetingController.Instance.insert(nMeeting);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// update meeting
	@POST
	@Path(MeetingDefines.UPDATE_MEETING + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject updateMeeting(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject meeting) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Meeting nMeeting = new Meeting();
			nMeeting = Utilites.getInstance().convertJsonObjToObject(meeting, Meeting.class);
			Meeting dl = MeetingController.Instance.update(nMeeting);
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
	 * Delete meeting by idMeeting
	 * @param session
	 * @param token
	 * @param meetingId
	 * @return
	 */
	@POST
	@Path(MeetingDefines.DELETE_MEETING + "/{token}/{meetingid}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject deleteMeeting(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("meetingid") long meetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			int kq = MeetingController.Instance.delete(meetingId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	/**
	 * Get meeting by id meeting
	 * @param session
	 * @param token
	 * @param meetingId
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_MEETING_BY_ID + "/{token}/{meetingid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getMeetingById(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("meetingid") long meetingId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Meeting dl = MeetingController.Instance.getMeetingById(meetingId);
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
	 * Get meetingid by date
	 * @param session
	 * @param token
	 * @param date
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_MEETING_BY_DATE + "/{token}/{date}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getMeetingObjByDate(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("date") String date) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");
			Date paraDate = new Date();
			try {
				paraDate = simpleDateFormat.parse(date);
			} catch (ParseException e) {
				e.printStackTrace();
			}
			List<Meeting> dl = MeetingController.Instance.getMeetingByDateTime(paraDate);
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
	@Path(MeetingDefines.GET_MEETING_BY_DATE_AND_ORGANIZATION_MEETING_ID_AND_MEETING_NAME
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
			MeetingObjManager rs = MeetingController.Instance.getMeetingByDateAndOrgIdAndMeetingName(start, end,
					paraFromDate, paraToDate, organizationMeetingId, meetingName);
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
	@Path(MeetingDefines.UPDATE_MEETING_SAME_SNONRESIDENT + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject updateNonResidentMeeting(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject nonResidentMeeting) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Meeting nNonResidentMeeting = null;
			GsonBuilder gsonBuilder = new GsonBuilder();
			gsonBuilder.setDateFormat(FORMAT_DATE);
			Gson gson = gsonBuilder.create();
			nNonResidentMeeting = gson.fromJson(nonResidentMeeting.toString(), Meeting.class);
			Meeting rs = MeetingController.Instance.update(nNonResidentMeeting);
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
	 * Lay chi tiet cuoc hop boi meetingcode
	 * @param session
	 * @param token
	 * @param meetingcode
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_DETAIL_MEETING_BY_MEETINGCODE + "/{token}/{meetingcode}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getDetailMeetingByBarCode(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("meetingcode") long meetingcode) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Meeting customMeeting = MeetingController.Instance.getMeetingByMeetingCodeActive(meetingcode);
			if (customMeeting != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(customMeeting);
		}
		return result;
	}

	/**
	 * Send email to partaker
	 * 
	 * @param session
	 * @param token
	 * @param json
	 * @return
	 * @throws UnsupportedEncodingException
	 */
	@POST
	@Path(MeetingDefines.SEND_MAIL + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject sendMail(@CookieParam("sessionid") String session, @PathParam("token") String token,
			String json) throws UnsupportedEncodingException {
		ResultObject result = new ResultObject(Status.FAILED);
		ObjectMail obj = new Gson().fromJson(json, ObjectMail.class);
		int kq = 0;
		try {
			kq = MeetingController.Instance.sendEmail(obj);
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		if (kq == 0) {
			result.setStatus(Status.SUCCESS);
		} else {
			result.setStatus(Status.FAILED);
		}
		return result;
	}

	/**
	 * Create Email config
	 * 
	 * @param session
	 * @param token
	 * @param emailConfigobj
	 * @return
	 */
	@POST
	@Path(MeetingDefines.REGISTER_EMAIL + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject registerEmail(@CookieParam("sessionid") String session, @PathParam("token") String token,
			String emailConfigobj) {
		EmailConfig email = new Gson().fromJson(emailConfigobj, EmailConfig.class);
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			EmailConfig emailConfig = MeetingController.Instance.insertEmailConfig(email);
			if (emailConfig != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(emailConfig);
		}
		return result;
	}

	/**
	 * Lay email config tu database
	 * 
	 * @param session
	 * @param token
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_EMAIL_CONFIG + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getEmailConfig(@CookieParam("sessionid") String session, @PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			EmailConfig emailConfig = MeetingController.Instance.getEmailConfig();
			if (emailConfig != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(emailConfig);
		}
		return result;
	}

	/**
	 * Lay danh sach cuoc hop theo ngay
	 * 
	 * @param session
	 * @param token
	 * @param date
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_LIST_MEETING_BY_DATE + "/{token}/{date}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getEmailConfig(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("date") String date) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		@SuppressWarnings("deprecation")
		Date dat1 = new Date(date);
		if (flag) {
			List<Meeting> lstMeeting = MeetingController.Instance.getMeetingByDateTime(dat1);
			if (lstMeeting != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(lstMeeting);
		}
		return result;
	}

	/**
	 * lay danh sach nguoi dang ky tham du hop tren web theo ma cuoc hop
	 * 
	 * @param session
	 * @param token
	 * @param meetingId
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_LIST_PARTAKER_BY_MEETING_ID + "/{token}/{meetingId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getlistPartakerByIdMeeting(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("meetingId") long meetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Partaker> lstMeeting = PartakerController.Instance.getPartakerRegisterByMeetingId(meetingId);
			if (lstMeeting != null) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			result.setObj(lstMeeting);
		}
		return result;
	}
}
