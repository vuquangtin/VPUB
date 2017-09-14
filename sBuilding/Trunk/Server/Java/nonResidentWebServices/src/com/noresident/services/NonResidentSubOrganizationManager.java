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
import com.swt.nonresident.domain.NonResidentSubOrganization;
import com.swt.nonresident.impls.NonResidentSubOrganizationController;
import com.swt.sworld.common.utilitis.TokenManager;

@Path(NonResidentDefines.NON_RESIDENT_SUB_ORGANIZATION_MANAGER)
@Produces(NonResidentDefines.APPLICATION_JSON)
public class NonResidentSubOrganizationManager {
	@POST
	@Path(NonResidentDefines.INSERT_NON_RES_SUB_ORG + "/{token}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject insert(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject nonResSubOrgJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentSubOrganization nonResSubOrg = new NonResidentSubOrganization();

			try {
				nonResSubOrg.setNonSubOrgRefId(nonResSubOrgJson.getLong("nonSubOrgRefId"));
				nonResSubOrg.setNonOrgId(nonResSubOrgJson.getLong("nonOrgId"));
				nonResSubOrg.setNonSubOrgName(nonResSubOrgJson.getString("nonSubOrgName"));
				nonResSubOrg = NonResidentSubOrganizationController.Instance.insert(nonResSubOrg);
				if (null != nonResSubOrg) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResSubOrg);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@POST
	@Path(NonResidentDefines.UPDATE_NON_RES_SUB_ORG + "/{token}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject update(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject nonResSubOrgJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentSubOrganization nonResSubOrg = new NonResidentSubOrganization();

			try {
				nonResSubOrg.setNonSubOrgId(nonResSubOrgJson.getLong("nonSubOrgId"));
				nonResSubOrg.setNonSubOrgRefId(nonResSubOrgJson.getLong("nonSubOrgRefId"));
				nonResSubOrg.setNonOrgId(nonResSubOrgJson.getLong("nonOrgId"));
				nonResSubOrg.setNonSubOrgName(nonResSubOrgJson.getString("nonSubOrgName"));
				nonResSubOrg = NonResidentSubOrganizationController.Instance.insert(nonResSubOrg);
				if (null != nonResSubOrg) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResSubOrg);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@POST
	@Path(NonResidentDefines.DELETE_NON_RES_SUB_ORG + "/{token}/{nonsuborgid}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject delete(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("nonsuborgid") long nonSubOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			try {
				int iResult = NonResidentSubOrganizationController.Instance.delete(nonSubOrgId);
				if (iResult != ErrorCodeSworld.NOT_FOUND_OBJ)
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@GET
	@Path(NonResidentDefines.GET_NON_RES_SUB_ORG + "/{token}/{nonsuborgid}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject get(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("nonsuborgid") long nonSubOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentSubOrganization nonResSubOrg = new NonResidentSubOrganization();

			try {
				nonResSubOrg = NonResidentSubOrganizationController.Instance.get(nonSubOrgId);
				if (null != nonResSubOrg) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResSubOrg);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@GET
	@Path(NonResidentDefines.GET_LIST_ALL_NON_RES_SUB_ORG + "/{token}/{nonorgid}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject getListAllSubOrg(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("nonorgid") long nonOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<NonResidentSubOrganization> nonResListAllSubOrg;

			try {
				nonResListAllSubOrg = NonResidentSubOrganizationController.Instance.getListAllSubOrg(nonOrgId);
				if (null != nonResListAllSubOrg) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResListAllSubOrg);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}
}
