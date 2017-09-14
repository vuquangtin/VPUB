package com.swt.saigonpearl.impls;

import java.util.List;

import com.swt.saigonpearl.domain.ManagerCosts;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.cms.impls.SubOrganizationController;

public class ManagerCostsController {

	public static final ManagerCostsController Instance = new ManagerCostsController();

	private ManagerCostsDAO mcDAO = new ManagerCostsDAO();

	public ManagerCosts importManagerCost(String session,long orgId ,List<ManagerCosts> managerCosts) {

		ManagerCosts ResultTypeInt = null;

		if (managerCosts.size() == 0)
			return ResultTypeInt;

		for (ManagerCosts mbReduce : managerCosts) {

			SubOrganization subOrg = SubOrganizationController.Instance.getSubOrgByCode(mbReduce.getSubOrgCode());
			
			if(subOrg == null)
			{
				SubOrganization subOrgNew = new SubOrganization();
				subOrgNew.setOrgid(mbReduce.getSubOrgId());
				subOrgNew.setOrgcode(mbReduce.getSubOrgCode());
				subOrgNew.setNames(mbReduce.getSubOrgCode());
				subOrgNew.setShortname(mbReduce.getSubOrgCode());
				SubOrganizationController.Instance.insertSubOrg(session, subOrgNew);
				subOrg = SubOrganizationController.Instance.getSubOrgByCode(mbReduce.getSubOrgCode());
			}
			
			//1. Cap nhat active la false
			updateManagerCostActive(subOrg.getSuborgid());
			if(mbReduce.getPayManager() > 0 || mbReduce.getPayWater() > 0)
			{
				//2. Them phi quan ly va tien nuoc moi
				ManagerCosts MP = new ManagerCosts();

				MP.setSubOrgId(subOrg.getSuborgid());
				MP.setSubOrgCode(subOrg.getOrgcode());
				MP.setNameHeadApartment(subOrg.getNames());
				MP.setManagerCostOld(mbReduce.getManagerCostOld());
				MP.setPayManager(mbReduce.getPayManager());
				MP.setPayWater(mbReduce.getPayWater());

				MP.setDayPay(mbReduce.getDayPay());
				MP.setSumMoney(mbReduce.getSumMoney());
				MP.setActive(true);
				MP.setCreatedBy(mbReduce.getCreatedBy());
				MP.setCreatedDate(mbReduce.getCreatedDate());
				MP.setModifiedBy(mbReduce.getModifiedBy());
				MP.setModifieDate(mbReduce.getModifieDate());
				MP.setStatus(mbReduce.getStatus());

				mcDAO.insert(MP);
			}
		}

		return ResultTypeInt;
	}
	
	public ManagerCosts getManagerCostBySubOrgId(long subOrgId)
	{
		return mcDAO.getManagerCostBySubOrgId(subOrgId);
	}
	
	public void updateManagerCostActive(long subOrgId)
	{
		List<ManagerCosts> mcList = mcDAO.getManagerCostAllBySubOrgId(subOrgId);
		if(mcList != null)
		{
			for(ManagerCosts mc : mcList)
			{
				mc.setActive(false);
				mcDAO.update(mc);
			}
		}
	}
	
	public List<ManagerCosts> getManagerCostAllBySubOrgId(long subOrgId) 
	{
		return mcDAO.getManagerCostAllBySubOrgId(subOrgId);
	}
}
