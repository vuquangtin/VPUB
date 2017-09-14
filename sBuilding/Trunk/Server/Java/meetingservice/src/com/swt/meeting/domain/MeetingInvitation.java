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
@Table(name = "swt_smeeting_meeting_invitation")
public class MeetingInvitation implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;

	@Column(name = "meetingbarcode", length = 30)
	private String meetingBarCode;

	@Column(name = "meetingid")
	private long meetingId;

	// don vi duoc moi
	@Column(name = "organizationattendid")
	private long organizationAttendId;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getMeetingBarCode() {
		return meetingBarCode;
	}

	public void setMeetingBarCode(String meetingBarCode) {
		this.meetingBarCode = meetingBarCode;
	}

	public void setMeetingId(long meetingId) {
		this.meetingId = meetingId;
	}

	public long getMeetingId() {
		return meetingId;
	}

	public long getOrganizationAttendId() {
		return organizationAttendId;
	}

	public void setOrganizationAttendId(long organizationAttendId) {
		this.organizationAttendId = organizationAttendId;
	}

}
