package com.noresident.services;

import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;

import org.codehaus.jettison.json.JSONObject;

import com.nhn.error.ErrorCodeSworld;
import com.nonresident.common.NonResidentDefines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.swt.nonresident.customObject.NonResidentMemberMapCustom;
import com.swt.nonresident.domain.NonResidentMemberMap;
import com.swt.nonresident.impls.NonResidentMemberMapController;
import com.swt.sworld.common.utilitis.TokenManager;

@Path(NonResidentDefines.NON_RESIDENT_MEMBER_MAP_MANAGER)
@Produces(NonResidentDefines.APPLICATION_JSON)
public class NonResidentMemberMapManager {
	@POST
	@Path(NonResidentDefines.INSERT_NON_RES_MEMBER_MAP + "/{token}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject insert(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject nonResMemMapJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentMemberMap nonResMemMap = new NonResidentMemberMap();

			try {
				nonResMemMap.setNonOrgId(nonResMemMapJson.getLong("nonOrgId"));
				nonResMemMap.setNonMemMapRefId(nonResMemMapJson.getLong("nonMemMapRefId"));
				nonResMemMap.setNonOrgSubOrgRefId(nonResMemMapJson.getLong("nonOrgSubOrgRefId"));
				nonResMemMap = NonResidentMemberMapController.Instance.insert(nonResMemMap);
				if (null != nonResMemMap) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResMemMap);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@POST
	@Path(NonResidentDefines.UPDATE_NON_RES_MEMBER_MAP + "/{token}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject update(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject nonResMemMapJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentMemberMap nonResMemMap = new NonResidentMemberMap();

			try {
				nonResMemMap.setNonMemMapId(nonResMemMapJson.getLong("nonMemMapId"));
				nonResMemMap.setNonOrgId(nonResMemMapJson.getLong("nonOrgId"));
				nonResMemMap.setNonMemMapRefId(nonResMemMapJson.getLong("nonMemMapRefId"));
				nonResMemMap.setNonOrgSubOrgRefId(nonResMemMapJson.getLong("nonOrgSubOrgRefId"));
				nonResMemMap = NonResidentMemberMapController.Instance.update(nonResMemMap);
				if (null != nonResMemMap) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResMemMap);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@POST
	@Path(NonResidentDefines.DELETE_NON_RES_MEMBER_MAP + "/{token}/{nonmemmapid}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject delete(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("nonmemmapid") long nonMemMapId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			try {
				int iResult = NonResidentMemberMapController.Instance.delete(nonMemMapId);
				if (iResult != ErrorCodeSworld.NOT_FOUND_OBJ)
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@GET
	@Path(NonResidentDefines.GET_NON_RES_MEMBER_MAP + "/{token}/{nonmemmapid}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject get(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("nonmemmapid") long nonMemMapId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentMemberMap nonResMemMap = new NonResidentMemberMap();

			try {
				nonResMemMap = NonResidentMemberMapController.Instance.get(nonMemMapId);
				if (null != nonResMemMap) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResMemMap);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@GET
	@Path(NonResidentDefines.GET_LIST_ALL_NON_RES_MEMBER_MAP + "/{token}/{nonorgid}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject getListAllMemMap(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("nonorgid") long nonOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<NonResidentMemberMapCustom> nonResListAllMemMapCustom;

			try {
				nonResListAllMemMapCustom = NonResidentMemberMapController.Instance.getListAllMemMap(nonOrgId);
				if (null != nonResListAllMemMapCustom) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResListAllMemMapCustom);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}
}
