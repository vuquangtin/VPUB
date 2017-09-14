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
import com.swt.meeting.customObject.SmeetingContactStatisticDetatiObj;
import com.swt.meeting.customObject.SmeetingContactStatisticObj;
import com.swt.meeting.domain.SmeetingContactStatistic;
import com.swt.meeting.impls.SmeetingContactStatisticController;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author TaiMai
 *
 * 
 */
@Path(MeetingDefines.SMEETING_CONTACT_STATISTIC_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingContactStatisticManaget {
	/**
	 * 06/04/2017 insert nguoi lien he
	 * 
	 * @param session
	 * @param token
	 * @param listAttendMeetingObj
	 * @return
	 */
	@POST
	@Path(MeetingDefines.INSERT_SMEETING_CONTACT_STATISTIC + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertAttendMeetingJournalistObj(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject smeetingContactStatistic) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SmeetingContactStatistic nSmeetingContactStatistic = new SmeetingContactStatistic();
			GsonBuilder gsonBuilder = new GsonBuilder();
			gsonBuilder.setDateFormat("yyyy-MM-dd HH:mm");
			Gson gson = gsonBuilder.create();
			nSmeetingContactStatistic = gson.fromJson(smeetingContactStatistic.toString(),
					SmeetingContactStatistic.class);
			SmeetingContactStatistic smeetingContact = SmeetingContactStatisticController.Instance
					.insert(nSmeetingContactStatistic);
			if (smeetingContact != null) {
				result.setStatus(Status.SUCCESS);
			}
		}
		return result;

	}

	/**
	 * 05/04/2017 thong ke so luong nguoi den lien he theo ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @ @return List<PersonAttend>
	 */
	@GET
	@Path(MeetingDefines.SMEETING_CONTACT_STATISTIC_BY_DATE + "/{token}/{start}/{end}/{fromDate}/{toDate}/{orgId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject statisticContactByDate(@CookieParam("sessionid") String session, @PathParam("start") int start,
			@PathParam("end") int limit, @PathParam("token") String token, @PathParam("fromDate") String fromDate,
			@PathParam("toDate") String toDate, @PathParam("orgId") long orgId) {
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
			SmeetingContactStatisticObj personAttends = SmeetingContactStatisticController.Instance
					.statisticByDate(start, limit, paraFromDate, paraToDate, orgId);
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
	 * 05/04/2017 thong ke chi tiet nguoi den lien he theo ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @ @return List<PersonAttend>
	 */
	@GET
	@Path(MeetingDefines.SMEETING_CONTACT_STATISTIC_BY_DATE_AND_ORG_ID
			+ "/{token}/{start}/{end}/{fromDate}/{toDate}/{orgId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject statisticContactDetaiByDateAndOrgId(@CookieParam("sessionid") String session,
			@PathParam("start") int start, @PathParam("end") int limit, @PathParam("token") String token,
			@PathParam("fromDate") String fromDate, @PathParam("toDate") String toDate,
			@PathParam("orgId") long orgId) {
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
			SmeetingContactStatisticDetatiObj personAttends = SmeetingContactStatisticController.Instance
					.statisticDetailByOrgId(start, limit, paraFromDate, paraToDate, orgId);
			if (personAttends != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(personAttends);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
}
