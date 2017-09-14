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
@Table(name = "swt_smeeting_attend_meeting")
public class AttendMeeting implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 14855445L;

	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;

	@Column(name = "meetingbarcode", length = 30)
	private String meetingBarcode;

	@Column(name = "meetingid")
	private long meetingId;

	@Column(name = "meetingname", length = Integer.MAX_VALUE)
	private String meetingName;

	// don vi to chuc cuoc hop
	@Column(name = "organizationmeetingid")
	private long organizationMeetingId;

	@Column(name = "organizationmeetingname")
	private String organizationMeetingName;

	@Column(name = "partakerid")
	private long partakerId;

	@Column(name = "partakername")
	private String partakerName;

	// don vi duoc moi tham du cuoc hop
	@Column(name = "organizationattendid")
	private long organizationAttendId;

	@Column(name = "organizationattendname")
	private String organizationAttendName;

	@Column(name = "note", columnDefinition = "Text")
	private String note;

	@Column(name = "inputtime")
	private Date inputTime;

	@Column(name = "outputtime")
	private Date outputTime;

	@Column(name = "invited")
	private boolean invited;

	@Column(name = "status")
	private boolean status;

	// khi la nguoi dc them vao bang tay. Thi duoc lay du lieu o day
	@Column(name = "personnotbarcodeid")
	private long personNotBarcodeId;

	public void setPersonNotBarcodeId(long personNotBarcodeId) {
		this.personNotBarcodeId = personNotBarcodeId;
	}

	public long getPersonNotBarcodeId() {
		return personNotBarcodeId;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getMeetingBarcode() {
		return meetingBarcode;
	}

	public void setMeetingBarcode(String meetingBarcode) {
		this.meetingBarcode = meetingBarcode;
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

	public long getPartakerId() {
		return partakerId;
	}

	public void setPartakerId(long partakerId) {
		this.partakerId = partakerId;
	}

	public String getPartakerName() {
		return partakerName;
	}

	public void setPartakerName(String partakerName) {
		this.partakerName = partakerName;
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

	public boolean isInvited() {
		return invited;
	}

	public void setInvited(boolean invited) {
		this.invited = invited;
	}

	public boolean isStatus() {
		return status;
	}

	public void setStatus(boolean status) {
		this.status = status;
	}

}
