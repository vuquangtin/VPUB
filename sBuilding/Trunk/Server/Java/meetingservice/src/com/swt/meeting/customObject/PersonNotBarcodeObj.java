package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.Date;

import com.swt.meeting.domain.PersonNotBarcode;

public class PersonNotBarcodeObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	private Date inputTime;
	private Date outputTime;
	private long meetingId;
	private String meetingName;
	private String note;
	private long organizationMeetingId;
	private String organizationMeetingName;
	private PersonNotBarcode personNotBarcode;

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

	public PersonNotBarcode getPersonNotBarcode() {
		return personNotBarcode;
	}

	public void setPersonNotBarcode(PersonNotBarcode personNotBarcode) {
		this.personNotBarcode = personNotBarcode;
	}

}
