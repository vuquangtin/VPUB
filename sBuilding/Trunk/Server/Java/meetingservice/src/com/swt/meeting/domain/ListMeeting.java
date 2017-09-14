package com.swt.meeting.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

/**
 * 
 * @author TaiMai
 * 
 */
@Entity
@Table(name = "swt_smeeting_list_meeting")
public class ListMeeting implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;

	@Column(name = "meetinginvitationid", nullable = false)
	private long meetingInvitationId;

	@Column(name = "partakerId", nullable = false)
	private long partakerId;

	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "meetingInvitationId", nullable = false)
	public long getMeetingInvitationId() {
		return meetingInvitationId;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getPartakerId() {
		return partakerId;
	}

	public void setPartakerId(long partakerId) {
		this.partakerId = partakerId;
	}

	public void setMeetingInvitationId(long meetingInvitationId) {
		this.meetingInvitationId = meetingInvitationId;
	}

}
