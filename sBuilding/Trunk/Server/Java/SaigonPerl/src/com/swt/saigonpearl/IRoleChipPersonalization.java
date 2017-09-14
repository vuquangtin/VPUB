package com.swt.saigonpearl;

import java.util.List;

import com.swt.saigonpearl.domain.RoleChipPersonalization;
import com.swt.saigonpearl.domain.RoleDeviceDoorGroup;
import com.swt.sworld.ps.domain.Member;

public interface IRoleChipPersonalization {
	RoleChipPersonalization insert(RoleChipPersonalization roleChipPersonalization);
	
	int insertRoleChipPersonalization(RoleChipPersonalization roleChipPersonalization);

	RoleChipPersonalization update(RoleChipPersonalization roleChipPersonalization);

	int delete(long roleChipPersonalizationId);

	List<RoleChipPersonalization> getRoleChipPersonalizations();

	RoleChipPersonalization getRoleChipPersonalizationById(long roleChipPersonalization);
	
	List<RoleChipPersonalization> getRoleChipPersonalizationsByRoleId(long roleId);
	//getlistmember by suborg but not exit in role
	List<Member> getListMember(long roleId,long subOrgId);
	
	List<RoleDeviceDoorGroup> getListGroupByRoleId(long roleId);
}
