package com.swt.saigonpearl;

import java.util.List;

import com.swt.saigonpearl.domain.ManagerCosts;

public interface ISaiGonpearlManagerCosts {

	ManagerCosts insert(ManagerCosts managerCosts);

	ManagerCosts update(ManagerCosts managerCosts);

	int delete(long managerCostsId);

	ManagerCosts GetManagerCost(String subOrgCode);

	int RemoveAllManagerCosts(List<ManagerCosts> lstmanagerCosts);
	int deleteManagerCostsID(long vourcherId);
	List<ManagerCosts> getAllManagerCosts();

	void updateManagerCostBySubOrgCode(String subOrgCode);

	ManagerCosts getManagerCostBySubOrgId(long subOrgId);
}
