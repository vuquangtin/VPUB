package com.swt.saigonpearl.domain;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swtgp_sbuilding_role_chip_personalization")
public class RoleChipPersonalization {
	@Id
	@GeneratedValue
	@Column(name = "rolechippersonalizationid", nullable = false)
	private long roleChipPersonalizationId;
	@Column(name = "roleid")
	private long roleId;
	@Column(name = "serialnumber")
	private String serialNumber;
	@Column(name = "memberid")
	private long memberId;
	public long getRoleChipPersonalizationId() {
		return roleChipPersonalizationId;
	}
	public void setRoleChipPersonalizationId(long roleChipPersonalizationId) {
		this.roleChipPersonalizationId = roleChipPersonalizationId;
	}
	public long getRoleId() {
		return roleId;
	}
	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}
	public String getSerialNumber() {
		return serialNumber;
	}
	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
	}
	public long getMemberId() {
		return memberId;
	}
	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}
	

	

}
