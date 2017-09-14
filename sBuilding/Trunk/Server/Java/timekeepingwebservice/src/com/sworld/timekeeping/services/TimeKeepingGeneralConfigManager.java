package com.sworld.timekeeping.services;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;

import org.codehaus.jettison.json.JSONObject;

import com.google.gson.Gson;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.timekeeping.common.TimeKeepingDefines;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.timekeeping.customer.object.GeneralConfigJson;
import com.swt.timekeeping.customer.object.GeneralConfigTime;
import com.swt.timekeeping.customer.object.TimeValue;
import com.swt.timekeeping.domain.GeneralConfig;
import com.swt.timekeeping.impls.TimeKeepingGeneralConfigController;

/**
 * TimeKeeping General Config Manager
 * 
 * @author minh.nguyen
 *
 */
@Path(TimeKeepingDefines.TIMEKEEPINGGENERALCONFIGMANAGER)
@Produces(TimeKeepingDefines.APPLICATION_JSON)
public class TimeKeepingGeneralConfigManager {
	// service for timekeepinggeneralconfig
	/**
	 * update general config
	 * 
	 * @param session
	 * @param token
	 * @param gConfigJson
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.UPDATE_TIMEKEEPING_GENERAL_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject updateGeneralConfig(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject gConfigJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			GeneralConfig temp = new GeneralConfig();
			GeneralConfig gConfig = new GeneralConfig();

			try {
				temp.setGeneralConfigId(gConfigJson.getLong("generalConfigId"));
				temp.setOrgId(gConfigJson.getLong("orgId"));
				temp.setGeneralConfigJson(gConfigJson.getString("generalConfigJson"));

				gConfig = TimeKeepingGeneralConfigController.Instance.updateGeneralConfig(temp);
				if (null != gConfig)
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}

			result.setObj(gConfig);
		}

		return result;
	}

	/**
	 * get general config list by orgId
	 * 
	 * @param session
	 * @param token
	 * @param orgId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_GENERAL_CONFIG_ORG_ID + "/{token}/{orgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getGeneralConfigByOrgId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			GeneralConfig gConfig = TimeKeepingGeneralConfigController.Instance.getGeneralConfigByOrgId(orgId);
			// Neu orgId nay chua duoc cau hinh chung thi tao cau hinh mac dinh
			// cho org do
			if (null == gConfig) {
				gConfig = new GeneralConfig();
				GeneralConfig temp = new GeneralConfig();
				GeneralConfigJson gConfigJson = new GeneralConfigJson();
				GeneralConfigTime cardTag = new GeneralConfigTime();
				GeneralConfigTime late = new GeneralConfigTime();
				GeneralConfigTime lateHalfDay = new GeneralConfigTime();

				try {
					// Cau hinh cho tag the tre
					cardTag.setValue(60);
					cardTag.setType(TimeValue.MINUTE.getValue());
					// Cau hinh cho thoi gian tre
					late.setValue(15);
					late.setType(TimeValue.MINUTE.getValue());
					// Cau hinh cho thoi gian tinh nghi nua ngay
					lateHalfDay.setValue(2);
					lateHalfDay.setType(TimeValue.HOUR.getValue());

					// Set data cho json
					gConfigJson.setCardTag(cardTag);
					gConfigJson.setLate(late);
					gConfigJson.setLateHalfDay(lateHalfDay);

					// Parse tu GeneralConfigJson object sang string json
					Gson gson = new Gson();

					String strGConfigJson = gson.toJson(gConfigJson);

					temp.setOrgId(orgId);
					temp.setGeneralConfigJson(strGConfigJson);

					gConfig = TimeKeepingGeneralConfigController.Instance.insertGeneralConfig(temp);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}

			result.setStatus(Status.SUCCESS);
			result.setObj(gConfig);
		}

		return result;
	}
}
