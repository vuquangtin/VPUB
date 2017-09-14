/**
 * 
 */
package com.swt.sworld.common.impls;

import java.util.List;

import com.swt.sworld.common.domain.PolicySworld;
import com.swt.sworld.common.domain.UserSworld;

/**
 * @author Administrator
 *
 */
public class PolicyController {
	
	public static final PolicyController Instance = new PolicyController();
	private PolicyDAOImpl PolicyDAO = new PolicyDAOImpl();
	private UserDAOImpl USERDAO = new UserDAOImpl();
	private PolicyController() {

	}
	
	public List<Long> getModuleByGroupId(long groupid)
	{
		return PolicyDAO.getModuleByGroupId(groupid);
	}
	
	public PolicySworld add(PolicySworld pol)
	{
		return PolicyDAO.addPolicy(pol);
	}
	
	public List<PolicySworld> getAllByGroupId(long groupid)
	{
		return PolicyDAO.getAllPolicyByGroupId(groupid);
	}
	
	public PolicySworld update(PolicySworld pol)
	{
		return PolicyDAO.updatePolicy(pol);
	}
	public int removePolicy(long policyId) 
	{
		return PolicyDAO.removePolicy(policyId);
	}
	
	public List<PolicySworld> getPermissionList(long userid)
	{
		UserSworld userSworld = USERDAO.getGroupIDByUserId(userid);
		List<PolicySworld> lstpolicy = PolicyDAO.getAllPolicyByGroupId(userSworld.getGroupId());
		if(lstpolicy == null)
		{
			return null;
		}
		else
		{
			return lstpolicy;
		}
	}

}
