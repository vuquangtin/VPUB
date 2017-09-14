package com.swt.meeting.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swt_smeeting_key_org_meeting")
public class KeyOrgMeeting implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;

	@Column(name = "meetingid")
	private long meetingId;

	@Column(name = "orgattendid")
	private long orgAttendId;

	@Column(name = "partakerid")
	private long partakerId;

	@Column(name = "keycheck")
	private String key;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getMeetingId() {
		return meetingId;
	}

	public void setMeetingId(long meetingId) {
		this.meetingId = meetingId;
	}

	public long getOrgAttendId() {
		return orgAttendId;
	}

	public void setOrgAttendId(long orgAttendId) {
		this.orgAttendId = orgAttendId;
	}

	public long getPartakerId() {
		return partakerId;
	}

	public void setPartakerId(long partakerId) {
		this.partakerId = partakerId;
	}

	public void setKey(String key) {
		this.key = key;
	}

	public String getKey() {
		return key;
	}
}
