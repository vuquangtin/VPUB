package com.noresident.services;

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
import com.swt.meeting.domain.NonResident;
import com.swt.nonresident.customObject.NonResidentObj;
import com.swt.nonresident.domain.NonResidentMeeting;
import com.swt.nonresident.impls.NonResidentController;
import com.swt.nonresident.impls.NonResidentMeetingController;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author TaiMai
 * 
 */
@Path(NonResidentDefines.NON_RESIDENT_MANAGER)
@Produces(NonResidentDefines.APPLICATION_JSON)
public class NonResidentManager {

	public static final String FORMAT_DATE = "yyyy-MM-dd HH:mm:ss";
	public static final String FORMAT_DATE_GETLIST = "yyyy-MM-dd";

	/**
	 * insert nonresident
	 * 
	 * 
	 * @param nonResident
	 * @return NonResident
	 */
	@POST
	@Path(NonResidentDefines.INSERT_NONRESIDENT + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertNonResident(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject nonresident) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentObj nNonResidentObj = new NonResidentObj();
			GsonBuilder gsonBuilder = new GsonBuilder();
			gsonBuilder.setDateFormat(FORMAT_DATE);
			Gson gson = gsonBuilder.create();
			nNonResidentObj = gson.fromJson(nonresident.toString(), NonResidentObj.class);
			// neu orgId = -1, tim va thay the don vi to chuc cuoc hop theo
			// meetingId
			if (nNonResidentObj.getNonResident().getOrgId() == -1) {
				NonResidentMeeting tmpObj = NonResidentMeetingController.Instance
						.getNonResidentMeetingById(nNonResidentObj.getNonResident().getMeetingId());
				nNonResidentObj.getNonResident().setOrgId(tmpObj.getOrganizationMeetingId());
				nNonResidentObj.getNonResident().setOrgName(tmpObj.getOrganizationMeetingName());
			}
			NonResident nonResidentInsert = NonResidentController.Instance.insert(nNonResidentObj.getNonResident());
			if (nonResidentInsert != null) {

				result.setStatus(Status.SUCCESS);
				NonResidentController.Instance.insertImageFace(nonResidentInsert.getId(),
						nNonResidentObj.getDataImageFace());
				NonResidentController.Instance.insertImageIdentityCard(nonResidentInsert.getId(),
						nNonResidentObj.getDataImageIdentityCard());
				result.setObj(nonResidentInsert);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * update nonresident
	 *
	 * @param nonResident
	 * @return NonResident
	 */
	@POST
	@Path(NonResidentDefines.UPDATE_NONRESIDENT + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	public ResultObject updateNonResident(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject nonresident) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			GsonBuilder gsonBuilder = new GsonBuilder();
			gsonBuilder.setDateFormat(FORMAT_DATE);
			Gson gson = gsonBuilder.create();
			NonResident nNonResident = new NonResident();
			nNonResident = NonResidentController.Instance
					.update(gson.fromJson(nonresident.toString(), NonResident.class));
			if (nNonResident != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(nNonResident);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// get nonresident by serialnumber
	@GET
	@Path(NonResidentDefines.GET_NON_RESIDENT_BY_SERIALNUMBER + "/{token}/{serialnumber}")
	@Produces(MediaType.APPLICATION_JSON)
	public ResultObject getNonResidentBySerialnumber(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("serialnumber") String serialnumber) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResident nonResident = NonResidentController.Instance.getNonResidentBySerialNumber(serialnumber);
			if (nonResident != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(nonResident);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// viet lai service moi : thong ke theo co quan tu ngay den ngay
	// // get list nonresident by date
	// @GET
	// @Path(NonResidentDefines.GET_LISTNONRESIDENT_BY_DATE +
	// "/{token}/{fromdate}/{todate}")
	// @Produces(MediaType.APPLICATION_JSON)
	// public ResultObject getListNonResidentByDate(@CookieParam("sessionid")
	// String session,
	// @PathParam("token") String token, @PathParam("fromdate") String fromDate,
	// @PathParam("todate") String toDate) {
	// ResultObject result = new ResultObject(Status.FAILED);
	// boolean flag = TokenManager.getInstance().checkTokenSession(session,
	// token);
	// if (flag) {
	// SimpleDateFormat simpleDateFormat = new
	// SimpleDateFormat(FORMAT_DATE_GETLIST);
	// Date paraFromDate = null;
	// Date paraToDate = null;
	// try {
	// paraFromDate = simpleDateFormat.parse(fromDate);
	// paraToDate = simpleDateFormat.parse(toDate);
	// } catch (ParseException e) {
	// e.printStackTrace();
	// }
	// List<NonResident> listNonResident =
	// NonResidentController.Instance.getListNonResidentByDate(paraFromDate,
	// paraToDate);
	// if (listNonResident != null) {
	// result.setStatus(Status.SUCCESS);
	// }
	// }
	// return result;
	// }

	// kiem tra the co ton tai khong
	@GET
	@Path(NonResidentDefines.CHECK_INOUT_NONRESIDENT_BY_SERIALNUMBER + "/{token}/{serialnumber}")
	@Produces(MediaType.APPLICATION_JSON)
	public ResultObject checkInOutNonResidentBySerialnumber(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("serialnumber") String serialnumber) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentObj nonResidentObj = NonResidentController.Instance
					.checkInOutNonResidentBySerialNumberAndDateime(serialnumber);
			if (nonResidentObj != null) {
				result.setStatus(Status.SUCCESS);
				nonResidentObj.setDataImageFace(
						NonResidentController.Instance.getImageFace(nonResidentObj.getNonResident().getId()));
				nonResidentObj.setDataImageIdentityCard(
						NonResidentController.Instance.getImageIdentityCard(nonResidentObj.getNonResident().getId()));
				result.setObj(nonResidentObj);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// update output time
	@POST
	@Path(NonResidentDefines.UPDATE_NONRESIDENT_BY_SERIALNUMBER_DATETIME + "/{token}")
	@Produces(MediaType.APPLICATION_JSON)
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject updateNonResidentBySerialnumberDateTime(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject nonresident) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResident nNonResident = new NonResident();
			GsonBuilder gsonBuilder = new GsonBuilder();
			gsonBuilder.setDateFormat(FORMAT_DATE);
			Gson gson = gsonBuilder.create();
			nNonResident = gson.fromJson(nonresident.toString(), NonResident.class);
			boolean check = NonResidentController.Instance.updateOutputTimeNonResident(nNonResident.getSerialNumber(),
					nNonResident.getOutputTime());
			if (check) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

}
