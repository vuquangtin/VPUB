package com.swt.meeting.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.NamedNativeQueries;
import javax.persistence.NamedNativeQuery;
import javax.persistence.Table;

/**
 * 
 * @author TaiMai
 * 
 */
@Entity
@Table(name = "swt_smeeting_meeting")
@NamedNativeQueries({
		@NamedNativeQuery(name = "getListMeetingJournalistNotInvited", query = "CALL getListMeetingJournalistNotInvited(:paraSerialNumber,:fromdate,:todate)", resultClass = Meeting.class) })

public class Meeting implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;

	@Column(name = "name",  length = Integer.MAX_VALUE)
	private String name;

	@Column(name = "organizationmeetingid")
	private long organizationMeetingId;

	@Column(name = "organizationmeetingname")
	private String organizationMeetingName;

	@Column(name = "roomid")
	private long roomId;

	@Column(name = "roomname")
	private String roomName;

	// so luong nguoi duoc moi
	@Column(name = "number", columnDefinition = "int default 0")
	private long number;

	// so luong nguoi duoc moi da vao
	@Column(name = "numberpeopleattendinvited", columnDefinition = "int default 0")
	private long numberPeopleAttendInvited;

	// so luong nguoi duoc them vao
	@Column(name = "numberpeopleadded", columnDefinition = "int default 0")
	private long numberPeopleAdded;

	// so luong nha bao
	@Column(name = "numberjournalist", columnDefinition = "int default 0")
	private long numberJournalist;

	// so luong khach vang lai
	@Column(name = "numberNonresident", columnDefinition = "int default 0")
	private long numberNonresident;

	

	@Column(name = "starttime")
	private Date startTime;

	@Column(name = "endtime")
	private Date endTime;

	@Column(name = "description", length = Integer.MAX_VALUE)
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
	
	@Column(name = "meetinginvitationname")
	private String meetingInvitationName;

	@Column(name = "meetingcodestatus")
	private boolean meetingCodeStatus;
	
	
	
	//

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

	public long getNumberPeopleAttendInvited() {
		return numberPeopleAttendInvited;
	}

	public void setNumberPeopleAttendInvited(long numberPeopleAttendInvited) {
		this.numberPeopleAttendInvited = numberPeopleAttendInvited;
	}

	public long getNumberPeopleAdded() {
		return numberPeopleAdded;
	}

	public void setNumberPeopleAdded(long numberPeopleAdded) {
		this.numberPeopleAdded = numberPeopleAdded;
	}

	public long getNumberJournalist() {
		return numberJournalist;
	}

	public void setNumberJournalist(long numberJournalist) {
		this.numberJournalist = numberJournalist;
	}

	public long getNumberNonresident() {
		return numberNonresident;
	}

	public void setNumberNonresident(long numberNonresident) {
		this.numberNonresident = numberNonresident;
	}

	public String getMeetingInvitationName() {
		return meetingInvitationName;
	}

	public void setMeetingInvitationName(String meetingInvitationName) {
		this.meetingInvitationName = meetingInvitationName;
	}
	
}
