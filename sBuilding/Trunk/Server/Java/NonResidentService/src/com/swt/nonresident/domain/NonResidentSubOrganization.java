package com.swt.nonresident.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swt_nonresident_suborganization")
public class NonResidentSubOrganization implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 91394160001391923L;

	@Id
	@GeneratedValue
	@Column(name = "nonSubOrgId", nullable = false)
	private long nonSubOrgId;

	@Column(name = "nonSubOrgRefId", nullable = false)
	private long nonSubOrgRefId;

	@Column(name = "nonOrgId", nullable = false)
	private long nonOrgId;

	@Column(name = "nonSubOrgName", nullable = false)
	private String nonSubOrgName;

	public long getNonSubOrgId() {
		return nonSubOrgId;
	}

	public void setNonSubOrgId(long nonSubOrgId) {
		this.nonSubOrgId = nonSubOrgId;
	}

	public long getNonSubOrgRefId() {
		return nonSubOrgRefId;
	}

	public void setNonSubOrgRefId(long nonSubOrgRefId) {
		this.nonSubOrgRefId = nonSubOrgRefId;
	}

	public long getNonOrgId() {
		return nonOrgId;
	}

	public void setNonOrgId(long nonOrgId) {
		this.nonOrgId = nonOrgId;
	}

	public String getNonSubOrgName() {
		return nonSubOrgName;
	}

	public void setNonSubOrgName(String nonSubOrgName) {
		this.nonSubOrgName = nonSubOrgName;
	}
}
