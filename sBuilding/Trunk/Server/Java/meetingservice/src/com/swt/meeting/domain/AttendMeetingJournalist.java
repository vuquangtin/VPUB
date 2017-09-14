package com.swt.meeting.domain;

import java.io.Serializable;
import java.util.Date;

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
@Table(name = "swt_smeeting_attend_meeting_journalist")
public class AttendMeetingJournalist implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;

	// thong tin nha bao
	@Column(name = "serialnumber", length = 30)
	private String serialNumber;

	@Column(name = "organizationattendid")
	private long organizationAttendId;

	@Column(name = "organizationattendname")
	private String organizationAttendName;

	@Column(name = "lowerfullname")
	private String lowerFullName;

	// thong tin cuoc hop
	@Column(name = "meetingid")
	private long meetingId;

	@Column(name = "meetingname")
	private String meetingName;

	@Column(name = "isInvite")
	private boolean isInvite;

	@Column(name = "organizationmeetingid")
	private long organizationMeetingId;

	@Column(name = "organizationmeetingname")
	private String organizationMeetingName;

	@Column(name = "note", columnDefinition = "Text")
	private String note;

	@Column(name = "inputtime")
	private Date inputTime;

	@Column(name = "outputtime")
	private Date outputTime;

	@Column(name = "status")
	private boolean status;

	// dung de thong ke nha bao di bao nhieu cuoc hop.
	@Column(name = "numbermeeting")
	private int numberMeeting;

	@Column(name = "numbermeetingadd")
	private int numberMeetingAdd;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getSerialNumber() {
		return serialNumber;
	}

	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
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

	public void setLowerFullName(String lowerFullName) {
		this.lowerFullName = lowerFullName;
	}

	public String getLowerFullName() {
		return lowerFullName;
	}

	public long getMeetingId() {
		return meetingId;
	}

	public void setMeetingId(long meetingId) {
		this.meetingId = meetingId;
	}

	public String getMeetingName() {
		return meetingName;
	}

	public void setMeetingName(String meetingName) {
		this.meetingName = meetingName;
	}

	public boolean isInvite() {
		return isInvite;
	}

	public void setInvite(boolean isInvite) {
		this.isInvite = isInvite;
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

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public Date getInputTime() {
		return inputTime;
	}

	public void setInputTime(Date inputTime) {
		this.inputTime = inputTime;
	}

	public Date getOutputTime() {
		return outputTime;
	}

	public void setOutputTime(Date outputTime) {
		this.outputTime = outputTime;
	}

	public boolean isStatus() {
		return status;
	}

	public void setStatus(boolean status) {
		this.status = status;
	}

	public int getNumberMeeting() {
		return numberMeeting;
	}

	public void setNumberMeeting(int numberMeeting) {
		this.numberMeeting = numberMeeting;
	}

	public int getNumberMeetingAdd() {
		return numberMeetingAdd;
	}

	public void setNumberMeetingAdd(int numberMeetingAdd) {
		this.numberMeetingAdd = numberMeetingAdd;
	}

}
