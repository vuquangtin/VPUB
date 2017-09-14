package com.sworld.timekeeping.services;

import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;

import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.timekeeping.common.TimeKeepingDefines;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.timekeeping.customer.object.ChipPersonalizationCustom;
import com.swt.timekeeping.customer.object.MemberCustom;
import com.swt.timekeeping.impls.TimeKeepingFormTimeKeepingController;

/**
 * TimeKeeping Form Time Keeping Manager
 * 
 * @author minh.nguyen
 *
 */
@Path(TimeKeepingDefines.TIMEKEEPINGFORMTIMEKEEPINGMANAGER)
@Produces(TimeKeepingDefines.APPLICATION_JSON)
public class TimeKeepingFormTimeKeepingManager {
	// service for timekeepingformtimekeepingmgt
	/**
	 * get list chip personalization custom
	 * 
	 * @param session
	 * @param token
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_LIST_CHIP_PERSONALIZATION_CUSTOM + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getListChipPersonalizationCustom(@CookieParam("sessionid") String session,
			@PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<ChipPersonalizationCustom> listChipPersonalizationCustom = TimeKeepingFormTimeKeepingController.Instance
					.getListChipPersonalizationCustom();

			if (null != listChipPersonalizationCustom) {
				result.setStatus(Status.SUCCESS);
			}

			result.setObj(listChipPersonalizationCustom);
		}

		return result;
	}

	/**
	 * get list member custom
	 * 
	 * @param session
	 * @param token
	 * @return
	 */
	@GET
	@Path(TimeKeepingDefines.GET_LIST_MEMBER_CUSTOM + "/{token}")
	@Consumes(TimeKeepingDefines.APPLICATION_JSON)
	public ResultObject getListMemberCustom(@CookieParam("sessionid") String session,
			@PathParam("token") String token) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<MemberCustom> listMemberCustom = TimeKeepingFormTimeKeepingController.Instance.getListMemberCustom();

			if (null != listMemberCustom) {
				result.setStatus(Status.SUCCESS);
			}

			result.setObj(listMemberCustom);
		}

		return result;
	}
}
