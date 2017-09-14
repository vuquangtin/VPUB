/**
 * 
 */
package com.meeting.services;

import java.lang.reflect.Type;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
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

import org.codehaus.jettison.json.JSONArray;
import org.codehaus.jettison.json.JSONObject;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import com.meeting.common.MeetingDefines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.swt.meeting.customObject.JournalistAttendStatisticDetailObj;
import com.swt.meeting.customObject.JournalistAttendStatisticObj;
import com.swt.meeting.customObject.NumberObj;
import com.swt.meeting.customObject.PersonAttend;
import com.swt.meeting.customObject.PersonAttendDetailObj;
import com.swt.meeting.customObject.PersonAttendObj;
import com.swt.meeting.customObject.PersonNotBarcodeObj;
import com.swt.meeting.domain.AttendMeeting;
import com.swt.meeting.domain.NonResident;
import com.swt.meeting.impls.AttendMeetingController;
import com.swt.meeting.impls.AttendMeetingJournalistController;
import com.swt.meeting.impls.DetailInfoBarcodeController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author TaiMai
 *
 * 
 */
@Path(MeetingDefines.ATTEND_MEETING_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingAttendMeetingManager {
	// insert AttendMeeting
	@POST
	@Path(MeetingDefines.INSERT_ATTEND_MEETING + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertAttendMeeting(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONArray listAttendMeeting) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<AttendMeeting> attendMeetings = new ArrayList<AttendMeeting>();
			GsonBuilder gsonBuilder = new GsonBuilder();
			try {
				gsonBuilder.setDateFormat("yyyy-MM-dd HH:mm");
				Gson gson = gsonBuilder.create();

				Type listType = new TypeToken<ArrayList<AttendMeeting>>() {
				}.getType();
				attendMeetings = gson.fromJson(listAttendMeeting.toString(), listType);
				for (AttendMeeting attendMeeting : attendMeetings) {
					AttendMeetingController.Instance.insert(attendMeeting);
				}
				result.setStatus(Status.SUCCESS);
				result.setObj(new AttendMeeting());
			} catch (Exception e) {
				System.out.println(e.getMessage());
				return result;
			}
		}
		return result;
	}

	// delete AttendMeeting
	@POST
	@Path(MeetingDefines.DELETE_ATTEND_MEETING + "/{token}/{AttendMeetingid}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject deleteAttendMeeting(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("AttendMeetingId") long attendMeetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			int kq = AttendMeetingController.Instance.delete(attendMeetingId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	// get AttendMeeting by id
	@GET
	@Path(MeetingDefines.GET_ATTEND_MEETING_BY_ID + "/{token}/{attendmeetingid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAttendMeetingById(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("attendmeetingid") int attendMeetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			AttendMeeting dl = AttendMeetingController.Instance.getAttendMeetingById(attendMeetingId);
			if (dl != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(dl);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// check AttendMeeting by barcode
	@GET
	@Path(MeetingDefines.CHECKINOUT_ATTEND_MEETING_BY_BARCODE + "/{token}/{barcode}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject checkInOutAttendMeeting(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("barcode") String barcode) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		System.out.println("CHECKINOUT_ATTEND_MEETING_BY_BARCODE");
		if (flag) {
			// -----------vervion 1--------
			// NumberObj checkExistBarcode =
			// AttendMeetingController.Instance.isExistBarcode(barcode);
			// ------------version 1--------

			NumberObj checkExistBarcode = DetailInfoBarcodeController.Instance.checkBarcode(barcode);
			result.setStatus(Status.SUCCESS);
			result.setObj(checkExistBarcode);
		}
		return result;
	}

	/**
	 * update attendmeeting by barcode
	 * 
	 * @param session
	 * @param token
	 * @param attendmeeting
	 * @return
	 */
	@POST
	@Path(MeetingDefines.UPDATE_ATTEND_MEETING_BY_BARCODE + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject checkInOutAttendMeeting(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject attendmeeting) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			try {

				String barcode = attendmeeting.getString("meetingBarcode").trim();
				String strtimeout = attendmeeting.getString("outputTime");
				DateFormat formatdate = new SimpleDateFormat("yyyy-MM-dd hh:mm");
				Date timeout = formatdate.parse(strtimeout);
				int out = AttendMeetingController.Instance.update(barcode, timeout);
				if (out > 0) {
					result.setStatus(Status.SUCCESS);
				} else {
					result.setStatus(Status.FAILED);
				}
			} catch (Exception ex) {

			}
		}
		return result;
	}

	/**
	 * 18/10/2016 thong ke theo ma cuoc hop
	 * 
	 * @param session
	 * @param token
	 * @param attendmeeting
	 * @return
	 */
	@GET
	@Path(MeetingDefines.GET_ATTEND_MEETING_STATISTIC_OBJ_BY_MEETING_ID + "/{token}/{start}/{end}/{meetingid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAttendMeetingByMeetingId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("start") int start, @PathParam("end") int limit,
			@PathParam("meetingid") long meetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			PersonAttendDetailObj dl = AttendMeetingController.Instance.statisticPersonAttendDetailByMeetingId(start,
					limit, meetingId);
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
	 * 19/10/2016 thong ke AttendMeeting theo ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @return List<AttendMeetingStatisticObj>
	 */
	@GET
	@Path(MeetingDefines.GET_ATTEND_MEETING_STATISTIC_OBJ_BY_DATE
			+ "/{token}/{start}/{end}/{fromDate}/{toDate}/{organizationMeetingId}/{meetingName}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAttendMeetingStatisticObjByDate(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("start") int start, @PathParam("end") int limit,
			@PathParam("fromDate") String fromDate, @PathParam("toDate") String toDate,
			@PathParam("organizationMeetingId") long organizationMeetingId,
			@PathParam("meetingName") String meetingName) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");
			Date paraFromDate = new Date();
			Date paraToDate = new Date();
			try {
				paraFromDate = simpleDateFormat.parse(fromDate);
				paraToDate = simpleDateFormat.parse(toDate);
			} catch (ParseException e) {
				e.printStackTrace();
			}
			PersonAttendObj personAttends = AttendMeetingController.Instance.statisticPersonAttend(start, limit,
					paraFromDate, paraToDate, organizationMeetingId, meetingName);
			if (personAttends != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(personAttends);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * 2/12/2016 thong ke AttendMeeting theo ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @return List<AttendMeetingStatisticObj>
	 */
	@GET
	@Path(MeetingDefines.GET_ATTEND_MEETING_STATISTIC_DETAIL_BY_DATE
			+ "/{token}/{start}/{end}/{fromDate}/{toDate}/{organizationMeetingId}/{meetingName}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAttendMeetingStatisticDetailByDate(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("start") int start, @PathParam("end") int limit,
			@PathParam("fromDate") String fromDate, @PathParam("toDate") String toDate,
			@PathParam("organizationMeetingId") long organizationMeetingId,
			@PathParam("meetingName") String meetingName) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");
			Date paraFromDate = new Date();
			Date paraToDate = new Date();
			try {
				paraFromDate = simpleDateFormat.parse(fromDate);
				paraToDate = simpleDateFormat.parse(toDate);
			} catch (ParseException e) {
				e.printStackTrace();
			}
			PersonAttendDetailObj personAttends = AttendMeetingController.Instance.statisticPersonAttendDetail(start,
					limit, paraFromDate, paraToDate, organizationMeetingId, meetingName);
			if (personAttends != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(personAttends);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * 23/12/2016 danh sach cuoc hop theo ngay va don vi to chuc
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @ @return List<PersonAttend>
	 */
	@GET
	@Path(MeetingDefines.GET_ATTEND_MEETING_STATISTIC_BY_DATE + "/{token}/{fromDate}/{toDate}/{organizationMeetingId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAttendMeetingStatisticByDate(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("fromDate") String fromDate,
			@PathParam("toDate") String toDate, @PathParam("organizationMeetingId") long organizationMeetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");
			Date paraFromDate = new Date();
			Date paraToDate = new Date();
			try {
				paraFromDate = simpleDateFormat.parse(fromDate);
				paraToDate = simpleDateFormat.parse(toDate);
			} catch (ParseException e) {
				e.printStackTrace();
			}
			List<PersonAttend> personAttends = AttendMeetingController.Instance.statisticPersonAttend(paraFromDate,
					paraToDate, organizationMeetingId);
			if (personAttends != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(personAttends);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * 23/12/2016 thong ke chi tiet nguoi tham du theo ngay , orgid va meetingid
	 * 
	 * @param start
	 * @param limit
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @param meetingId
	 * @return PersonAttendDetailObj
	 */
	@GET
	@Path(MeetingDefines.GET_ATTEND_MEETING_STATISTIC_DETAIL_BY_ORGANIZATION_MEETING_ID_AND_MEETING_ID
			+ "/{token}/{start}/{end}/{fromDate}/{toDate}/{organizationMeetingId}/{meetingId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAttendMeetingStatisticDetailByOrganizationMeetingIdAndMeetingId(
			@CookieParam("sessionid") String session, @PathParam("token") String token, @PathParam("start") int start,
			@PathParam("end") int limit, @PathParam("fromDate") String fromDate, @PathParam("toDate") String toDate,
			@PathParam("organizationMeetingId") long organizationMeetingId, @PathParam("meetingId") long meetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");
			Date paraFromDate = new Date();
			Date paraToDate = new Date();
			try {
				paraFromDate = simpleDateFormat.parse(fromDate);
				paraToDate = simpleDateFormat.parse(toDate);
			} catch (ParseException e) {
				e.printStackTrace();
			}
			PersonAttendDetailObj personAttends = AttendMeetingController.Instance.statisticPersonAttendDetail(start,
					limit, paraFromDate, paraToDate, organizationMeetingId, meetingId);
			if (personAttends != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(personAttends);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * 28/03/2017 cho nguoi vao cuoc hop khi khong co barcode
	 * 
	 */
	@POST
	@Path(MeetingDefines.INSERT_ATTEND_MEETING_ADD + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public ResultObject insertAttendMeetingAdd(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject personNotBarcodeObj) {
		
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			PersonNotBarcodeObj personNotBarcodeObjTmp = new PersonNotBarcodeObj();
			GsonBuilder gsonBuilder = new GsonBuilder();
			try {
				gsonBuilder.setDateFormat("yyyy-MM-dd HH:mm");
				Gson gson = gsonBuilder.create();

				personNotBarcodeObjTmp = gson.fromJson(personNotBarcodeObj.toString(), PersonNotBarcodeObj.class);
				AttendMeetingController.Instance.insertPersonNotBarcode(personNotBarcodeObjTmp);
				result.setStatus(Status.SUCCESS);
				result.setObj(new AttendMeeting());
			} catch (Exception e) {
				System.out.println(e.getMessage());
				return result;
			}
		}
		return result;
	}

	// insert list nonresident
	@POST
	@Path(MeetingDefines.INSERT_ATTEND_MEETING_NONRESIDENT + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertAttendMeetingNonresident(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONArray listAttendMeeting) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<NonResident> attendMeetings = new ArrayList<NonResident>();
			GsonBuilder gsonBuilder = new GsonBuilder();
			try {
				gsonBuilder.setDateFormat("yyyy-MM-dd HH:mm");
				Gson gson = gsonBuilder.create();

				Type listType = new TypeToken<ArrayList<NonResident>>() {
				}.getType();
				attendMeetings = gson.fromJson(listAttendMeeting.toString(), listType);
				for (NonResident attendMeeting : attendMeetings) {
					AttendMeetingController.Instance.insertNonresident(attendMeeting);
				}
				result.setStatus(Status.SUCCESS);
				result.setObj(new AttendMeeting());
			} catch (Exception e) {
				System.out.println(e.getMessage());
				return result;
			}
		}
		return result;
	}

	// ------------------thong ke nha bao----------------
	/**
	 * 03/04/2017 thong ke cuoc hoc nha bao theo meeting id
	 * 
	 */
	@GET
	@Path(MeetingDefines.GET_JOURNALIST_ATTEND_MEETING_STATISTIC_OBJ_BY_MEETING_ID
			+ "/{token}/{start}/{end}/{meetingid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getJournalistAttendMeetingByMeetingId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("start") int start, @PathParam("end") int limit,
			@PathParam("meetingid") long meetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			JournalistAttendStatisticDetailObj dl = AttendMeetingJournalistController.Instance
					.statisticJournalistAttendDetailByMeetingId(start, limit, meetingId);
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
	 * 03/04/2017 thong ke nha bao theo ngay
	 * 
	 */
	@GET
	@Path(MeetingDefines.GET_JOURNALIST_ATTEND_MEETING_STATISTIC_OBJ_BY_DATE
			+ "/{token}/{start}/{end}/{fromDate}/{toDate}/{organizationMeetingId}/{meetingName}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getJournalistAttendMeetingStatisticObjByDate(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("start") int start, @PathParam("end") int limit,
			@PathParam("fromDate") String fromDate, @PathParam("toDate") String toDate,
			@PathParam("organizationMeetingId") long organizationMeetingId,
			@PathParam("meetingName") String meetingName) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");
			Date paraFromDate = new Date();
			Date paraToDate = new Date();
			try {
				paraFromDate = simpleDateFormat.parse(fromDate);
				paraToDate = simpleDateFormat.parse(toDate);
			} catch (ParseException e) {
				e.printStackTrace();
			}
			JournalistAttendStatisticObj journalistAttendStatistic = AttendMeetingJournalistController.Instance
					.statisticJourlistAttend(start, limit, paraFromDate, paraToDate, organizationMeetingId,
							meetingName);
			if (journalistAttendStatistic != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(journalistAttendStatistic);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * 03/04/2017 thong ke chi tiet nha bao tham du theo ngay , orgid va
	 * meetingid
	 * 
	 */
	@GET
	@Path(MeetingDefines.GET_JOURNALIST_ATTEND_MEETING_STATISTIC_DETAIL_BY_ORGANIZATION_MEETING_ID_AND_MEETING_ID
			+ "/{token}/{start}/{end}/{fromDate}/{toDate}/{organizationMeetingId}/{meetingId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getJournalistAttendMeetingStatisticDetailByOrganizationMeetingIdAndMeetingId(
			@CookieParam("sessionid") String session, @PathParam("token") String token, @PathParam("start") int start,
			@PathParam("end") int limit, @PathParam("fromDate") String fromDate, @PathParam("toDate") String toDate,
			@PathParam("organizationMeetingId") long organizationMeetingId, @PathParam("meetingId") long meetingId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");
			Date paraFromDate = new Date();
			Date paraToDate = new Date();
			try {
				paraFromDate = simpleDateFormat.parse(fromDate);
				paraToDate = simpleDateFormat.parse(toDate);
			} catch (ParseException e) {
				e.printStackTrace();
			}
			JournalistAttendStatisticDetailObj attendStatisticDetailObj = AttendMeetingJournalistController.Instance
					.statisticJournalistAttendDetail(start, limit, paraFromDate, paraToDate, organizationMeetingId,
							meetingId);
			if (attendStatisticDetailObj != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(attendStatisticDetailObj);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// -----------------------End thong ke nha bao---------------------------
}
