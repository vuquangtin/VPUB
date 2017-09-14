package com.swt.saigonpearl;

import java.util.List;

import com.swt.saigonpearl.domain.RoleDeviceDoorGroup;

public interface IRoleDeviceDoorGroup {
	RoleDeviceDoorGroup insert(RoleDeviceDoorGroup roleDeviceDoorGroup);

	RoleDeviceDoorGroup update(RoleDeviceDoorGroup roleDeviceDoorGroup);

	int delete(long roleDeviceDoorGroupId);

	List<RoleDeviceDoorGroup> getRoleDeviceDoorGroups();

	RoleDeviceDoorGroup getRoleDeviceDoorGroupById(long roleDeviceDoorGroupId);

	List<RoleDeviceDoorGroup> getDeviceDoorGroupByRoleId(long roleId);
	
	void deleteRoleDeviceDoorGroup(long roleId,long deviceDoorGroupId);

	List<RoleDeviceDoorGroup> getDeviceDoorGroupByGroupId(
			long roleDeviceDoorGroupId);

}
