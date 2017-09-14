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

import com.nhn.error.ErrorCodeSworld;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.sworld.timekeeping.common.TimeKeepingDefines;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.timekeeping.customer.object.HolidayResultForGet;
import com.swt.timekeeping.domain.HolidayConfig;
import com.swt.timekeeping.impls.TimeKeepingHolidayConfigController;

/**
 * TimeKeeping Holiday Config Manager
 * 
 * @author minh.nguyen
 *
 */
@Path(TimeKeepingDefines.TIMEKEEPINGHOLIDAYMANAGER)
@Produces(TimeKeepingDefines.APPLICATION_JSON)
public class TimeKeepingHolidayConfigManager {
	// service for timekeepingholidayconfig
	/**
	 * insert holiday
	 * 
	 * @param session
	 * @param token
	 * @param orgId
	 * @param hConfigJson
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.INSERT_TIMEKEEPING_HOLIDAY_CONFIG
			+ "/{token}/{orgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject insertHolidayConfig(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgId,
			JSONObject hConfigJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			HolidayResultForGet temp = new HolidayResultForGet();
			HolidayConfig hConfig = new HolidayConfig();

			try {
				temp.setHolidayName(hConfigJson.getString("holidayName"));
				temp.setHolidayStart(hConfigJson.getString("holidayStart"));
				temp.setHolidayEnd(hConfigJson.getString("holidayEnd"));
				temp.setHolidayDescription(hConfigJson
						.getString("holidayDescription"));
				temp.setOrgId(orgId);

				hConfig = TimeKeepingHolidayConfigController.Instance
						.insertHolidayConfig(temp);
				if (null != hConfig)
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}

			HolidayResultForGet hResult = new HolidayResultForGet(hConfig);
			result.setObj(hResult);
		}

		return result;
	}

	/**
	 * update holiday
	 * 
	 * @param session
	 * @param token
	 * @param hConfigJson
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.UPDATE_TIMEKEEPING_HOLIDAY_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject updateHolidayConfig(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject hConfigJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			HolidayResultForGet temp = new HolidayResultForGet();
			HolidayConfig hConfig = new HolidayConfig();

			try {
				temp.setHolidayId(hConfigJson.getLong("holidayId"));
				temp.setHolidayName(hConfigJson.getString("holidayName"));
				temp.setHolidayStart(hConfigJson.getString("holidayStart"));
				temp.setHolidayEnd(hConfigJson.getString("holidayEnd"));
				temp.setHolidayDescription(hConfigJson
						.getString("holidayDescription"));
				temp.setOrgId(hConfigJson.getLong("orgId"));

				hConfig = TimeKeepingHolidayConfigController.Instance
						.updateHolidayConfig(temp);
				if (null != hConfig)
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}

			HolidayResultForGet hResult = new HolidayResultForGet(hConfig);
			result.setObj(hResult);
		}

		return result;
	}

	/**
	 * delete holiday by holidayId
	 * 
	 * @param session
	 * @param token
	 * @param holidayId
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.DELETE_TIMEKEEPING_HOLIDAY_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject deleteHolidayConfigById(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONArray hConfigJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> listHolidayId = new ArrayList<>();

			try {
				listHolidayId = Utilites.getInstance()
						.convertJsonArrayToListLong(hConfigJson);

				int iResult = TimeKeepingHolidayConfigController.Instance
						.deleteHolidayConfigById(listHolidayId);
				if (iResult != ErrorCodeSworld.NOT_FOUND_OBJ)
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	/**
	 * get holiday by holidayId
	 * 
	 * @param session
	 * @param token
	 * @param holidayId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_HOLIDAY_CONFIG
			+ "/{token}/{holidayid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getHolidayConfigById(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("holidayid") long holidayId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			HolidayResultForGet hResult = TimeKeepingHolidayConfigController.Instance
					.getHolidayConfigById(holidayId);
			if (null != hResult) {
				result.setStatus(Status.SUCCESS);
			}

			result.setObj(hResult);
		}

		return result;
	}

	/**
	 * check holiday with orgId
	 * 
	 * @param session
	 * @param token
	 * @param orgId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.CHECK_HOLIDAY + "/{token}/{date}/{orgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject checkHoliday(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("date") String date,
			@PathParam("orgid") long orgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DateFormat dateFormat = new SimpleDateFormat("ddMMyyyy");
			Date holidayCheck;
			try {
				holidayCheck = dateFormat.parse(date);
				int isHoliday = TimeKeepingHolidayConfigController.Instance
						.checkHoliday(holidayCheck, orgId);
				if (isHoliday == 0)
					result.setStatus(Status.SUCCESS);
			} catch (ParseException e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	/**
	 * filter list holiday with orgId
	 *
	 * @param session
	 * @param token
	 * @param orgId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.FILTER_TIMEKEEPING_LIST_HOLIDAY_CONFIG_ORG_ID
			+ "/{token}/{datestart}/{dateend}/{orgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject filterHolidayListByOrgId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("datestart") String dateStart,
			@PathParam("dateend") String dateEnd, @PathParam("orgid") long orgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			DateFormat dateFormat = new SimpleDateFormat("ddMMyyyy");
			Date holidayStartCheck;
			Date holidayEndCheck;
			try {
				holidayStartCheck = dateFormat.parse(dateStart);
				holidayEndCheck = dateFormat.parse(dateEnd);
				List<HolidayResultForGet> listHolidayResult = TimeKeepingHolidayConfigController.Instance
						.filterHolidayListByOrgId(holidayStartCheck,
								holidayEndCheck, orgId);
				if (null != listHolidayResult) {
					result.setStatus(Status.SUCCESS);
				}

				result.setObj(listHolidayResult);
			} catch (ParseException e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	// trang.vo
	/**
	 * Get HolidayList By OrgId
	 * 
	 * @param session
	 * @param token
	 * @param year
	 * @param orgId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_HOLIDAY_LIST_BY_ORGID_YEAR
			+ "/{token}/{year}/{orgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getHolidayListByOrgIdAndYear(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("year") int year,
			@PathParam("orgid") long orgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<HolidayResultForGet> listHolidayResult = TimeKeepingHolidayConfigController.Instance
					.GetHolidayListByOrgId(year, orgId);
			if (null != listHolidayResult) {
				result.setStatus(Status.SUCCESS);
			}

			result.setObj(listHolidayResult);
		}
		return result;
	}

}
