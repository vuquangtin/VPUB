package com.swt.meeting.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swt_smeeting_meeting_invitation_org_other")
public class MeetingInvitationOrgOther implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	private long id;

	@Column(name = "barcode")
	private String barcode;

	@Column(name = "orgid")
	private long orgId;

	@Column(name = "orgname")
	private String orgName;

	@Column(name = "orgCode")
	private String orgCode;

	@Column(name = "meetingid")
	private long meetingId;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getBarcode() {
		return barcode;
	}

	public void setBarcode(String barcode) {
		this.barcode = barcode;
	}

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

	public String getOrgName() {
		return orgName;
	}

	public void setOrgName(String orgName) {
		this.orgName = orgName;
	}

	public void setMeetingId(long meetingId) {
		this.meetingId = meetingId;
	}

	public long getMeetingId() {
		return meetingId;
	}

	public void setOrgCode(String orgCode) {
		this.orgCode = orgCode;
	}

	public String getOrgCode() {
		return orgCode;
	}
}
