package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.Date;

public class MeetingLCT implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	private long neocoreId;
	private String name;
	private long organizationMeetingId;
	private long roomId;
	private String description;
	private long number;
	private Date startTime;
	private Date endTime;
	private String note;

	public long getNeocoreId() {
		return neocoreId;
	}

	public void setNeocoreId(long neocoreId) {
		this.neocoreId = neocoreId;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public long getOrganizationMeetingId() {
		return organizationMeetingId;
	}

	public void setOrganizationMeetingId(long organizationMeetingId) {
		this.organizationMeetingId = organizationMeetingId;
	}

	public long getRoomId() {
		return roomId;
	}

	public void setRoomId(long roomId) {
		this.roomId = roomId;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public long getNumber() {
		return number;
	}

	public void setNumber(long number) {
		this.number = number;
	}

	public Date getStartTime() {
		return startTime;
	}

	public void setStartTime(Date startTime) {
		this.startTime = startTime;
	}

	public Date getEndTime() {
		return endTime;
	}

	public void setEndTime(Date endTime) {
		this.endTime = endTime;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

}
