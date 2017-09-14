package com.swt.saigonpearl.domain;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swtgp_sbuilding_role_devicedoorgroup")
public class RoleDeviceDoorGroup {
	@Id
	@GeneratedValue
	@Column(name = "roledevicedoorgroupid", nullable = false)
	private long roleDeviceDoorGroupId;
	@Column(name = "roleid")
	private long roleId;
	@Column(name = "devicedoorgroupid")
	private long deviceDoorGroupId;
	
	public long getRoleDeviceDoorGroupId() {
		return roleDeviceDoorGroupId;
	}
	public void setRoleDeviceDoorGroupId(long roleDeviceDoorGroupId) {
		this.roleDeviceDoorGroupId = roleDeviceDoorGroupId;
	}
	public long getRoleId() {
		return roleId;
	}
	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}
	public long getDeviceDoorGroupId() {
		return deviceDoorGroupId;
	}
	public void setDeviceDoorGroupId(long deviceDoorGroupId) {
		this.deviceDoorGroupId = deviceDoorGroupId;
	}
	
	

}
