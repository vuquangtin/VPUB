package com.sworld.saigonpearl.services;

import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import org.codehaus.jettison.json.JSONArray;

import com.sworld.common.ResultObject;
import com.sworld.common.Status;




import com.sworld.common.Utilites;
import com.sworld.saigonpearl.common.SaigonPearlDefines;
import com.swt.saigonpearl.domain.ManagerCosts;
import com.swt.saigonpearl.impls.ManagerCostsController;
import com.swt.sworld.common.utilitis.TokenManager;

/**
 * @author Cong Thanh
 * 
 */

@Path(SaigonPearlDefines.SaiGonPearl)
@Produces(SaigonPearlDefines.APPLICATION_JSON)

public class SaiGonPearlManager {

	// Import from file excel
	@POST
	@Path(SaigonPearlDefines.INSERT_FILE_EXCEL + "/{token}/{orgId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject insertFileExcel(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("orgId") long orgId,
			JSONArray configObj) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {		
			List<ManagerCosts> lstconfig;
			lstconfig = Utilites.getInstance().convertJsonArrayToList(configObj);
			
//			ManagerCosts mc = 
					ManagerCostsController.Instance.importManagerCost(session, orgId,lstconfig);	
			if(lstconfig != null)
			{
				result.setStatus(Status.SUCCESS);
			}
			else
			{
				result.setStatus(Status.FAILED);
			}
			result.setObj(lstconfig);
		}
		return result;
	}
	
	@GET
	@Path(SaigonPearlDefines.GET_MANAGER_COST_BY_SUBORGID + "/{token}/{subOrgId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getManagerCostBySubOrgId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("subOrgId") long subOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {		
			ManagerCosts mc = ManagerCostsController.Instance.getManagerCostBySubOrgId(subOrgId);
			if(mc != null)
			{
				result.setStatus(Status.SUCCESS);
				result.setObj(mc);
			}
			else
			{
				result.setObj(new ManagerCosts());
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
	

	@GET
	@Path(SaigonPearlDefines.GET_MANAGER_COST_LIST_BY_SUBORGID + "/{token}/{subOrgId}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getManagerCostAllBySubOrgId(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("subOrgId") long subOrgId) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {		
			List<ManagerCosts> mcList = ManagerCostsController.Instance.getManagerCostAllBySubOrgId(subOrgId);
			if(mcList != null)
			{
				result.setStatus(Status.SUCCESS);
				result.setObj(mcList);
			}
			else
			{
				result.setObj(new ManagerCosts());
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
}
