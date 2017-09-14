package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedNativeQueries;
import javax.persistence.NamedNativeQuery;
import javax.persistence.Table;

@Entity
@Table(name = "swt_smeeting_detail_info_only_person")
@NamedNativeQueries({
		@NamedNativeQuery(name = "getDetailInfoPerson", query = "CALL getDetailInfoPerson(:barcode)", resultClass = DetailInfoOnlyPerson.class) })

public class DetailInfoOnlyPerson implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	private int id;
	// meeting
	@Column(name = "meetingid")
	private int meetingId;

	@Column(name = "meetingname")
	private String meetingname;

	@Column(name = "starttime")
	private Date startTime;

	@Column(name = "note", length = Integer.MAX_VALUE)
	private String note;

	// partker
	@Column(name = "partakerid")
	private int partakerId;

	@Column(name = "partakername")
	private String partakerName;

	@Column(name = "position")
	private String position;

	// don vi to chuc
	@Column(name = "organizationmeetingid")
	private int organizationMeetingId;

	@Column(name = "organizationmeetingname")
	private String organizationMeetingName;

	// don vi tham du
	@Column(name = "organizationattendid")
	private int organizationAttendId;

	@Column(name = "organizationattendname")
	private String organizationAttendName;

	// meeting invitation
	@Column(name = "meetinginvitationid")
	private int meetingInvitationId;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public int getMeetingId() {
		return meetingId;
	}

	public void setMeetingId(int meetingId) {
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

	public int getPartakerId() {
		return partakerId;
	}

	public void setPartakerId(int partakerId) {
		this.partakerId = partakerId;
	}

	public String getPartakerName() {
		return partakerName;
	}

	public void setPartakerName(String partakerName) {
		this.partakerName = partakerName;
	}

	public String getPosition() {
		return position;
	}

	public void setPosition(String position) {
		this.position = position;
	}

	public int getOrganizationMeetingId() {
		return organizationMeetingId;
	}

	public void setOrganizationMeetingId(int organizationMeetingId) {
		this.organizationMeetingId = organizationMeetingId;
	}

	public String getOrganizationMeetingName() {
		return organizationMeetingName;
	}

	public void setOrganizationMeetingName(String organizationMeetingName) {
		this.organizationMeetingName = organizationMeetingName;
	}

	public int getOrganizationAttendId() {
		return organizationAttendId;
	}

	public void setOrganizationAttendId(int organizationAttendId) {
		this.organizationAttendId = organizationAttendId;
	}

	public String getOrganizationAttendName() {
		return organizationAttendName;
	}

	public void setOrganizationAttendName(String organizationAttendName) {
		this.organizationAttendName = organizationAttendName;
	}

	public int getMeetingInvitationId() {
		return meetingInvitationId;
	}

	public void setMeetingInvitationId(int meetingInvitationId) {
		this.meetingInvitationId = meetingInvitationId;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}

}
