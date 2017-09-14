package com.swt.nonresident.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swt_smeeting_meeting")
public class NonResidentMeeting implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;

	@Column(name = "name", nullable = false, length = 100)
	private String name;

	@Column(name = "organizationmeetingid")
	private long organizationMeetingId;

	@Column(name = "organizationmeetingname", length = 100)
	private String organizationMeetingName;

	@Column(name = "roomid")
	private long roomId;

	@Column(name = "roomname", length = 100)
	private String roomName;

	// so luong to chuc duoc moi
	@Column(name = "number")
	private long number;

	@Column(name = "starttime")
	private Date startTime;

	@Column(name = "endtime")
	private Date endTime;

	@Column(name = "description", length = 225)
	private String description;

	@Column(name = "listnonresident", length = Integer.MAX_VALUE)
	private String listNonResident;

	@Column(name = "note", columnDefinition = "Text")
	private String note;

	// cuoc hop co phai cua khach vang lai khong
	@Column(name = "nonresident")
	private boolean nonresident;

	@Column(name = "meetingcode")
	private long meetingCode;

	@Column(name = "meetingcodestatus")
	private boolean meetingCodeStatus;

	@Column(name = "journalist")
	private boolean journalist;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
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

	public String getOrganizationMeetingName() {
		return organizationMeetingName;
	}

	public void setOrganizationMeetingName(String organizationMeetingName) {
		this.organizationMeetingName = organizationMeetingName;
	}

	public long getRoomId() {
		return roomId;
	}

	public void setRoomId(long roomId) {
		this.roomId = roomId;
	}

	public String getRoomName() {
		return roomName;
	}

	public void setRoomName(String roomName) {
		this.roomName = roomName;
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

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getListNonResident() {
		return listNonResident;
	}

	public void setListNonResident(String listNonResident) {
		this.listNonResident = listNonResident;
	}

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
	}

	public long getMeetingCode() {
		return meetingCode;
	}

	public void setMeetingCode(long meetingCode) {
		this.meetingCode = meetingCode;
	}

	public boolean isMeetingCodeStatus() {
		return meetingCodeStatus;
	}

	public void setMeetingCodeStatus(boolean meetingCodeStatus) {
		this.meetingCodeStatus = meetingCodeStatus;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}

	public boolean isNonresident() {
		return nonresident;
	}

	public void setNonresident(boolean nonresident) {
		this.nonresident = nonresident;
	}

	public boolean isJournalist() {
		return journalist;
	}

	public void setJournalist(boolean journalist) {
		this.journalist = journalist;
	}

}
