package com.swt.saigonpearl.domain;

import java.io.Serializable;

import com.swt.sworld.ps.domain.Member;

public class RoleChipPersonalizationCustomDTO implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private long roleChipPersonalizationId;
	private Member member;
	private String serialNumber;

	
	public long getRoleChipPersonalizationId() {
		return roleChipPersonalizationId;
	}

	public void setRoleChipPersonalizationId(long roleChipPersonalizationId) {
		this.roleChipPersonalizationId = roleChipPersonalizationId;
	}

	public Member getMember() {
		return member;
	}

	public void setMember(Member member) {
		this.member = member;
	}

	public String getSerialNumber() {
		return serialNumber;
	}

	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
	}

}
