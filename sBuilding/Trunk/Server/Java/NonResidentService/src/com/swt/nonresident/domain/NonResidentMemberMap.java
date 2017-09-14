package com.swt.nonresident.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swt_nonresident_member_map")
public class NonResidentMemberMap implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 7759375922720758757L;

	@Id
	@GeneratedValue
	@Column(name = "nonMemMapId", nullable = false)
	private long nonMemMapId;
	
	@Column(name = "nonOrgId", nullable = false)
	private long nonOrgId;

	@Column(name = "nonMemMapRefId", nullable = false)
	private long nonMemMapRefId;

	@Column(name = "nonOrgSubOrgRefId", nullable = false)
	private long nonOrgSubOrgRefId;

	public long getNonMemMapId() {
		return nonMemMapId;
	}

	public void setNonMemMapId(long nonMemMapId) {
		this.nonMemMapId = nonMemMapId;
	}

	public long getNonOrgId() {
		return nonOrgId;
	}

	public void setNonOrgId(long nonOrgId) {
		this.nonOrgId = nonOrgId;
	}

	public long getNonMemMapRefId() {
		return nonMemMapRefId;
	}

	public void setNonMemMapRefId(long nonMemMapRefId) {
		this.nonMemMapRefId = nonMemMapRefId;
	}

	public long getNonOrgSubOrgRefId() {
		return nonOrgSubOrgRefId;
	}

	public void setNonOrgSubOrgRefId(long nonOrgSubOrgRefId) {
		this.nonOrgSubOrgRefId = nonOrgSubOrgRefId;
	}
}
