package com.swt.meeting.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * 
 * @author TaiMai
 * 
 */
@Entity
@Table(name = "swt_smeeting_organization_meeting")
public class OrganizationMeeting implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;

	@Column(name = "name", length = 150)
	private String name;

	@Column(name = "referenceid")
	private long referenceId;

	@Column(name = "meeting", columnDefinition = "int default 0")
	private int typeOrg;

	@Column(name = "code", columnDefinition = "varchar(255) default 'N/A'")
	private String code;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public long getReferenceId() {
		return referenceId;
	}

	public void setReferenceId(long referenceId) {
		this.referenceId = referenceId;
	}

	public int getTypeOrg() {
		return typeOrg;
	}

	public void setTypeOrg(int typeOrg) {
		this.typeOrg = typeOrg;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getCode() {
		return code;
	}

}
