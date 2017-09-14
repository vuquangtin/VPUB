package com.swt.nonresident.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.NamedNativeQueries;
import javax.persistence.NamedNativeQuery;
import javax.persistence.Table;

/**
 * 
 * @author TaiMai
 * 
 */
@Entity
@Table(name = "swt_smeeting_partaker")
@NamedNativeQueries({
	@NamedNativeQuery(
			name = "getPartakerByMeetingId",
			query = "CALL getPartakerByMeetingId(:meetingid)",
			resultClass = NonResidentPartaker.class
			)
	}
)

public class NonResidentPartaker implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;

	@Column(name = "cardchipid")
	private long cardChipId;

	@Column(name = "name", length = 150)
	private String name;

	@Column(name = "position", length = 50)
	private String position;

	@Column(name = "orgid")
	private long orgId;

	@Column(name = "orgname")
	private String orgname;

	@Column(name = "referenceid")
	private long referenceId;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getCardChipId() {
		return cardChipId;
	}

	public void setCardChipId(long cardChipId) {
		this.cardChipId = cardChipId;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getPosition() {
		return position;
	}

	public void setPosition(String position) {
		this.position = position;
	}

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

	public String getOrgname() {
		return orgname;
	}

	public void setOrgname(String orgname) {
		this.orgname = orgname;
	}

	public long getReferenceId() {
		return referenceId;
	}

	public void setReferenceId(long referenceId) {
		this.referenceId = referenceId;
	}

}
