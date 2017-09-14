package com.swt.sworld.common;

import java.util.List;

import com.swt.sworld.common.domain.PolicySworld;

public interface IPolicyDAO {
	
	List<Long> getModuleByGroupId(long groupid);
	
	PolicySworld addPolicy(PolicySworld pol);
	
	PolicySworld updatePolicy(PolicySworld pol);
	
	List<PolicySworld> getAllPolicyByGroupId(long groupid);

	int removePolicy(long policyId);

}
