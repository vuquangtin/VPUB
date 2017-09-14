package com.swt.saigonpearl.impls;

import java.util.List;

import com.swt.saigonpearl.IRole;
import com.swt.saigonpearl.domain.RoleDTO;
;

public class RoleController {
	
	public static final RoleController Instance = new RoleController();
	IRole roleDAO = new RoleDAO();
	
	public RoleDTO insert(RoleDTO role) {
		return roleDAO.insert(role);
	}

	public RoleDTO update(RoleDTO role) {
		return roleDAO.update(role);
	}

	public int delete(long roleId) {
		return roleDAO.delete(roleId);
	}
	
	public List<RoleDTO> getRoles() 
	{
		return roleDAO.getRoles();
	}
	
	public RoleDTO getRoleById(long roleId) 
	{
		return roleDAO.getRoleById(roleId);
	}
}
