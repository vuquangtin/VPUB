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
import com.swt.nonresident.domain.NonResidentOrganization;
import com.swt.nonresident.impls.NonResidentOrganizationController;
import com.swt.sworld.common.utilitis.TokenManager;

@Path(NonResidentDefines.NON_RESIDENT_ORGANIZATION_MANAGER)
@Produces(NonResidentDefines.APPLICATION_JSON)
public class NonResidentOrganizationManager {
	@POST
	@Path(NonResidentDefines.INSERT_NON_RES_ORG + "/{token}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject insert(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject nonResOrgJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentOrganization nonResOrg = new NonResidentOrganization();

			try {
				nonResOrg.setNonOrgRefId(nonResOrgJson.getLong("nonOrgRefId"));
				nonResOrg.setNonOrgName(nonResOrgJson.getString("nonOrgName"));
				nonResOrg.setIsPeople(nonResOrgJson.getInt("isPeople"));
				nonResOrg.setOrgCode(nonResOrgJson.getString("orgCode"));
				nonResOrg = NonResidentOrganizationController.Instance.insert(nonResOrg);
				if (null != nonResOrg) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResOrg);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@POST
	@Path(NonResidentDefines.UPDATE_NON_RES_ORG + "/{token}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject update(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject nonResOrgJson) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentOrganization nonResOrg = new NonResidentOrganization();

			try {
				nonResOrg.setNonOrgId(nonResOrgJson.getLong("nonOrgId"));
				nonResOrg.setNonOrgRefId(nonResOrgJson.getLong("nonOrgRefId"));
				nonResOrg.setNonOrgName(nonResOrgJson.getString("nonOrgName"));
				nonResOrg.setIsPeople(nonResOrgJson.getInt("isPeople"));
				nonResOrg.setOrgCode(nonResOrgJson.getString("orgCode"));
				nonResOrg = NonResidentOrganizationController.Instance.update(nonResOrg);
				if (null != nonResOrg) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResOrg);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@POST
	@Path(NonResidentDefines.DELETE_NON_RES_ORG + "/{token}/{nonorgid}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject delete(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("nonorgid") long nonOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			try {
				int iResult = NonResidentOrganizationController.Instance.delete(nonOrgId);
				if (iResult != ErrorCodeSworld.NOT_FOUND_OBJ)
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@GET
	@Path(NonResidentDefines.GET_NON_RES_ORG + "/{token}/{nonorgid}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject get(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("nonorgid") long nonOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			NonResidentOrganization nonResOrg = new NonResidentOrganization();

			try {
				nonResOrg = NonResidentOrganizationController.Instance.get(nonOrgId);
				if (null != nonResOrg) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResOrg);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}

	@GET
	@Path(NonResidentDefines.GET_LIST_ALL_NON_RES_ORG + "/{token}/{orgcode}")
	@Consumes(NonResidentDefines.APPLICATION_JSON)
	public ResultObject getListAllOrg(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("orgcode") String orgCode) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<NonResidentOrganization> nonResListAllOrg;

			try {
				nonResListAllOrg = NonResidentOrganizationController.Instance.getListAllOrg(orgCode);
				if (null != nonResListAllOrg) {
					result.setStatus(Status.SUCCESS);
					result.setObj(nonResListAllOrg);
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}
}
