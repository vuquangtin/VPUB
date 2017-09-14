package com.sworld.timekeeping.services;

import java.util.ArrayList;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;

import org.codehaus.jettison.json.JSONObject;

import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.timekeeping.common.TimeKeepingDefines;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.timekeeping.domain.ColorConfig;
import com.swt.timekeeping.impls.TimeKeepingColorConfigController;

/**
 * TimeKeeping Color Config Manager
 * 
 * @author minh.nguyen
 *
 */
@Path(TimeKeepingDefines.TIMEKEEPINGCOLORMANAGER)
@Produces(TimeKeepingDefines.APPLICATION_JSON)
public class TimeKeepingColorConfigManager {
	// service for timekeepingcolorconfig
	/**
	 * update colorConfig
	 * 
	 * @param session
	 * @param token
	 * @param cConfigJson
	 * @return
	 */
	@POST
	@Path(TimeKeepingDefines.UPDATE_TIMEKEEPING_COLOR_CONFIG + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject updateColorConfig(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject cConfigJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;
		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			ColorConfig temp = new ColorConfig();
			ColorConfig cConfig = new ColorConfig();

			try {
				temp.setColorConfigId(cConfigJson.getLong("colorConfigId"));
				temp.setColorConfigNameId(cConfigJson.getLong("colorConfigNameId"));
				temp.setColorId(cConfigJson.getLong("colorId"));
				temp.setOrgId(cConfigJson.getLong("orgId"));

				cConfig = TimeKeepingColorConfigController.Instance.updateColorConfig(temp);

				if (null != cConfig)
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}

			result.setObj(cConfig);
		}
		return result;
	}

	/**
	 * get colorConfig by colorConfigId
	 * 
	 * @param session
	 * @param token
	 * @param colorConfigId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_COLOR_CONFIG + "/{token}/{colorconfigid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getColorConfigById(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("colorconfigid") long colorConfigId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;
		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			ColorConfig cConfig = TimeKeepingColorConfigController.Instance.getColorConfigById(colorConfigId);

			if (null != cConfig) {
				result.setStatus(Status.SUCCESS);
			}

			result.setObj(cConfig);
		}
		return result;
	}

	/**
	 * get list colorConfig by orgId
	 * 
	 * @param session
	 * @param token
	 * @param orgId
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_TIMEKEEPING_LIST_COLOR_CONFIG_ORG_ID + "/{token}/{orgid}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getColorConfigListByOrgId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;
		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<ColorConfig> listColorConfig = TimeKeepingColorConfigController.Instance
					.getColorConfigListByOrgId(orgId);

			// Neu nhu tra ve null nghia la org nay chua duoc cau hinh mau
			// tao cau hinh mau mac dinh cho org do
			if (0 == listColorConfig.size()) {
				listColorConfig = new ArrayList<>();

				try {
					for (int i = 0; i < 7; i++) {
						ColorConfig cConfig = new ColorConfig();
						ColorConfig temp = new ColorConfig();
						temp.setColorConfigNameId(i + 1);
						temp.setColorId(i + 1);
						temp.setOrgId(orgId);
						
						cConfig = TimeKeepingColorConfigController.Instance.insertColorConfig(temp);
						// Insert xong 1 object add vao list de return
						listColorConfig.add(cConfig);
					}
				} catch (Exception e) {
					e.printStackTrace();
				}
			}

			result.setStatus(Status.SUCCESS);
			result.setObj(listColorConfig);
		}
		return result;
	}
}