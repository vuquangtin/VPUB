package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.Date;

public class AttendMeetingJournalistStatistic implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private String meetingName;
	private String orgMeetingName;
	private String orgJournalistName;
	private long numberOfParticipants;
	private Date inputTime;
	private Date outputTime;

	public String getMeetingName() {
		return meetingName;
	}

	public void setMeetingName(String meetingName) {
		this.meetingName = meetingName;
	}

	public String getOrgMeetingName() {
		return orgMeetingName;
	}

	public void setOrgMeetingName(String orgMeetingName) {
		this.orgMeetingName = orgMeetingName;
	}

	public String getOrgJournalistName() {
		return orgJournalistName;
	}

	public void setOrgJournalistName(String orgJournalistName) {
		this.orgJournalistName = orgJournalistName;
	}

	public long getNumberOfParticipants() {
		return numberOfParticipants;
	}

	public void setNumberOfParticipants(long numberOfParticipants) {
		this.numberOfParticipants = numberOfParticipants;
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

}
