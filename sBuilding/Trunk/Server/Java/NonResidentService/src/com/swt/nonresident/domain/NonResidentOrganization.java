package com.swt.nonresident.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swt_nonresident_organization")
public class NonResidentOrganization implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 2270198134481748048L;

	@Id
	@GeneratedValue
	@Column(name = "nonOrgId", nullable = false)
	private long nonOrgId;
	
	@Column(name = "nonOrgRefId", nullable = false)
	private long nonOrgRefId;
	
	@Column(name = "nonOrgName", nullable = false)
	private String nonOrgName;
	
	@Column(name = "isPeople", nullable = false)
	private int isPeople;
	
	@Column(name = "orgCode", nullable = false)
	private String orgCode;

	public long getNonOrgId() {
		return nonOrgId;
	}

	public void setNonOrgId(long nonOrgId) {
		this.nonOrgId = nonOrgId;
	}

	public long getNonOrgRefId() {
		return nonOrgRefId;
	}

	public void setNonOrgRefId(long nonOrgRefId) {
		this.nonOrgRefId = nonOrgRefId;
	}

	public String getNonOrgName() {
		return nonOrgName;
	}

	public void setNonOrgName(String nonOrgName) {
		this.nonOrgName = nonOrgName;
	}

	public int getIsPeople() {
		return isPeople;
	}

	public void setIsPeople(int isPeople) {
		this.isPeople = isPeople;
	}

	public String getOrgCode() {
		return orgCode;
	}

	public void setOrgCode(String orgCode) {
		this.orgCode = orgCode;
	}
}
