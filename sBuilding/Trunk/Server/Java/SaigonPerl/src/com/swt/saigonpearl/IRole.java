package com.swt.saigonpearl;

import java.util.List;

import com.swt.saigonpearl.domain.RoleDTO;

public interface IRole {
	RoleDTO insert(RoleDTO role);

	RoleDTO update(RoleDTO role);

	int delete(long roleId);

	List<RoleDTO> getRoles();

	RoleDTO getRoleById(long roleId);
	
}
