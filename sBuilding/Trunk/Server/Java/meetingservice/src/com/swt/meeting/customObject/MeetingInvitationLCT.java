package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

public class MeetingInvitationLCT implements Serializable {
	private static final long serialVersionUID = 1L;

	private long meetingInvitationId;
	private String meetingInvitationName;
	private String meetingName;
	private long roomId;
	private String roomName;
	private String description;
	private Date startTime;
	private Date endTime;
	private List<PartakerLCT> listPartaker;
	
	//danh sach file
	private List<FileLCT> listFile;
	
	public void setListFile(List<FileLCT> listFile) {
		this.listFile = listFile;
	}
	
	public List<FileLCT> getListFile() {
		return listFile;
	}

	public void setRoomId(long roomId) {
		this.roomId = roomId;
	}

	public long getRoomId() {
		return roomId;
	}

	public long getMeetingInvitationId() {
		return meetingInvitationId;
	}

	public void setMeetingInvitationId(long meetingInvitationId) {
		this.meetingInvitationId = meetingInvitationId;
	}

	public String getMeetingName() {
		return meetingName;
	}

	public void setMeetingName(String meetingName) {
		this.meetingName = meetingName;
	}

	public String getRoomName() {
		return roomName;
	}

	public void setRoomName(String roomName) {
		this.roomName = roomName;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
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

	public List<PartakerLCT> getListPartaker() {
		return listPartaker;
	}

	public void setListPartaker(List<PartakerLCT> listPartaker) {
		this.listPartaker = listPartaker;
	}

	public String getMeetingInvitationName() {
		return meetingInvitationName;
	}

	public void setMeetingInvitationName(String meetingInvitationName) {
		this.meetingInvitationName = meetingInvitationName;
	}
	
	

}
