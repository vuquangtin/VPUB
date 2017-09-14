package com.sworld.timekeeping.services;

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

import org.codehaus.jettison.json.JSONArray;
import org.codehaus.jettison.json.JSONObject;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import com.nhn.error.ErrorCodeSworld;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.sworld.timekeeping.common.TimeKeepingDefines;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.timekeeping.customer.object.DayOffImportObject;
import com.swt.timekeeping.customer.object.DayOffResultForGet;
import com.swt.timekeeping.domain.DayOffConfig;
import com.swt.timekeeping.impls.TimeKeepingDayOffConfigController;

/**
 * TimeKeeping Day Off Config Manager
 * 
 * @author minh.nguyen
 *
 */
@Path(TimeKeepingDefines.TIMEKEEPINGDAYOFFCONFIGMANAGER)
@Produces(TimeKeepingDefines.APPLICATION_JSON)
public class TimeKeepingDayOffConfigManager {
	// service for timekeepingdayoffconfig
	/**
	 * update day off config
	 * 
	 * @param session
	 * @param token
	 * @param doConfigJson
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.UPDATE_TIMEKEEPING_DAY_OFF_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject updateDayOffConfig(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject doConfigJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DayOffResultForGet temp = new DayOffResultForGet();
			DayOffConfig doConfig = new DayOffConfig();

			try {
				temp.setDayOffConfigId(doConfigJson.getLong("dayOffConfigId"));
				temp.setMemberId(doConfigJson.getLong("memberId"));
				temp.setDate(doConfigJson.getString("date"));
				temp.setStatus(doConfigJson.getInt("status"));
				temp.setSubOrgId(doConfigJson.getLong("subOrgId"));

				doConfig = TimeKeepingDayOffConfigController.Instance.updateDayOffConfig(temp);
				if (null != doConfig)
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}

			DayOffResultForGet doResult = new DayOffResultForGet(doConfig);
			result.setObj(doResult);
		}

		return result;
	}

	/**
	 * Insert or Update DayOff by list memberId
	 * 
	 * @param session
	 * @param token
	 * @param memberId
	 * @param date
	 * @param status
	 * @param subOrgId
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.INSERT_OR_UPDATE_DAY_OFF_MEMBER_ID + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertOrUpdateDayOffByListMemberId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject doConfigJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DayOffResultForGet temp = new DayOffResultForGet();
			DayOffConfig doConfig = new DayOffConfig();

			try {
				temp = Utilites.getInstance().convertJsonObjToObject(doConfigJson, DayOffResultForGet.class);

				doConfig = TimeKeepingDayOffConfigController.Instance.insertOrUpdateDayOffByListMemberId(temp);
				if (null != doConfig)
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}

			DayOffResultForGet doResult = new DayOffResultForGet(doConfig);
			result.setObj(doResult);
		}

		return result;
	}

	/**
	 * delete day off config
	 * 
	 * @param session
	 * @param token
	 * @param dayOffConfigId
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.DELETE_TIMEKEEPING_DAY_OFF_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject deleteDayOffConfig(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONArray doConfigJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> listDOConfigId = new ArrayList<>();

			try {
				listDOConfigId = Utilites.getInstance().convertJsonArrayToListLong(doConfigJson);

				int iResult = TimeKeepingDayOffConfigController.Instance.deleteDayOffConfig(listDOConfigId);
				if (iResult != ErrorCodeSworld.NOT_FOUND_OBJ)
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	/**
	 * get day off config by dayOffConfigId
	 * 
	 * @param session
	 * @param token
	 * @param dayOffConfigId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_DAY_OFF_CONFIG + "/{token}/{doconfigid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getDayOffConfigById(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("doconfigid") long doConfigId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DayOffResultForGet doResult = TimeKeepingDayOffConfigController.Instance.getDayOffConfigById(doConfigId);
			if (null != doResult) {
				result.setStatus(Status.SUCCESS);
			}

			result.setObj(doResult);
		}

		return result;
	}

	/**
	 * filter list day off with subOrgId
	 *
	 * @param session
	 * @param token
	 * @param subOrgId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.FILTER_TIMEKEEPING_LIST_DAY_OFF_CONFIG_SUB_ORG_ID
			+ "/{token}/{datestart}/{dateend}/{suborgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject filterListDayOffBySubOrgId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("datestart") String dateStart,
			@PathParam("dateend") String dateEnd, @PathParam("suborgid") long subOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DateFormat dateFormat = new SimpleDateFormat("ddMMyyyy");
			Date dateStartCheck;
			Date dateEndCheck;

			try {
				dateStartCheck = dateFormat.parse(dateStart);
				dateEndCheck = dateFormat.parse(dateEnd);
				List<DayOffResultForGet> listDayOffResult = TimeKeepingDayOffConfigController.Instance
						.filterListDayOffBySubOrgId(dateStartCheck, dateEndCheck, subOrgId);
				if (null != listDayOffResult) {
					result.setStatus(Status.SUCCESS);
				}

				result.setObj(listDayOffResult);
			} catch (ParseException e) {
				e.printStackTrace();
			}
		}

		return result;
	}
	
	/**
	 * getStatusOfDateByMemberId
	 * 
	 * @param session
	 * @param token
	 * @param memberId
	 * @param date
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_DAY_OFF_MEMBER_ID_DATE + "/{token}/{memberid}/{date}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getDayOffByMemberIdAndDate(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("memberid") long memberId, @PathParam("date") String date) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DayOffResultForGet doResult = new DayOffResultForGet();
			DateFormat dateFormatFromUrl = new SimpleDateFormat("ddMMyyyy");
			DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
			Date dateCheck;

			try {
				// Lay tu URL String date dang ddMMyyyy chuyen sang thanh Date
				// object
				// sau do chuyen nguoc qua lai string dd/MM/yyyy
				dateCheck = dateFormatFromUrl.parse(date);
				doResult = TimeKeepingDayOffConfigController.Instance.getDayOffByMemberIdAndDate(memberId,
						dateFormat.format(dateCheck));
				if (null != doResult) {
					result.setStatus(Status.SUCCESS);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}

			result.setObj(doResult);
		}

		return result;
	}

	// load member
	/**
	 * get member by memberId
	 * 
	 * @param session
	 * @param token
	 * @param memberId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_MEMBER + "/{token}/{memberid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getMemberById(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("memberid") long memberId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Member member = MemberController.Instance.getMemberById(memberId);
			if (null != member) {
				result.setStatus(Status.SUCCESS);
			}

			result.setObj(member);
		}

		return result;
	}

	/**
	 * get member list by subOrgId
	 * 
	 * @param session
	 * @param token
	 * @param subOrgId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_MEMBER_LIST_SUB_ORG_ID + "/{token}/{suborgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getMemberBySubOrgId(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("suborgid") long subOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Member> listMember = MemberController.Instance.getMemberBySubOrgId(subOrgId);
			if (null != listMember) {
				result.setStatus(Status.SUCCESS);
			}

			result.setObj(listMember);
		}

		return result;
	}
	
	/**
	 * Ham nay import danh sach ngay nghi trong 1 thang 
	 * 
	 * @param session
	 * @param token
	 * @param timeKeepingShiftId
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.IMPORT_lIST_DAY_OFF + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject importListDayOff(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONArray listJson) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		
		if (flag) {
			
			// convert listImportObject
			List<DayOffImportObject> listImportObject = new ArrayList<DayOffImportObject>();
			TypeToken<List<DayOffImportObject>> temp = new TypeToken<List<DayOffImportObject>>() {
			};
			Gson gson = new Gson();
			listImportObject = gson.fromJson(listJson.toString(),
					temp.getType());
			
			// import
			List<DayOffImportObject> kq = TimeKeepingDayOffConfigController.Instance.importDayOffList(listImportObject);
			
			// set Status
			if (kq.size() <= 0) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
			
			// setObj
			result.setObj(kq);
		}
		return result;
	}
}
