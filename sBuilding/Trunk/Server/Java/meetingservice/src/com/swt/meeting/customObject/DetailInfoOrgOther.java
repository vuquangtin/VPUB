package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.Date;

public class DetailInfoOrgOther implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private long meetingId;

	private String meetingname;

	private Date startTime;

	private String note;

	// don vi to chuc
	private long organizationMeetingId;

	private String organizationMeetingName;

	// don vi tham du
	private long organizationAttendId;

	private String organizationAttendName;

	private String organizationAttendCode;

	public long getMeetingId() {
		return meetingId;
	}

	public void setMeetingId(long meetingId) {
		this.meetingId = meetingId;
	}

	public String getMeetingname() {
		return meetingname;
	}

	public void setMeetingname(String meetingname) {
		this.meetingname = meetingname;
	}

	public Date getStartTime() {
		return startTime;
	}

	public void setStartTime(Date startTime) {
		this.startTime = startTime;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public long getOrganizationMeetingId() {
		return organizationMeetingId;
	}

	public void setOrganizationMeetingId(long organizationMeetingId) {
		this.organizationMeetingId = organizationMeetingId;
	}

	public String getOrganizationMeetingName() {
		return organizationMeetingName;
	}

	public void setOrganizationMeetingName(String organizationMeetingName) {
		this.organizationMeetingName = organizationMeetingName;
	}

	public long getOrganizationAttendId() {
		return organizationAttendId;
	}

	public void setOrganizationAttendId(long organizationAttendId) {
		this.organizationAttendId = organizationAttendId;
	}

	public String getOrganizationAttendName() {
		return organizationAttendName;
	}

	public void setOrganizationAttendName(String organizationAttendName) {
		this.organizationAttendName = organizationAttendName;
	}

	public void setOrganizationAttendCode(String organizationAttendCode) {
		this.organizationAttendCode = organizationAttendCode;
	}

	public String getOrganizationAttendCode() {
		return organizationAttendCode;
	}
}
