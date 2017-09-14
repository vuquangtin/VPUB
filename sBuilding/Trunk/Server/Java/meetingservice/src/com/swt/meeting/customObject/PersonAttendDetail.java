package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.NamedNativeQueries;
import javax.persistence.NamedNativeQuery;
import javax.persistence.Table;

@Entity
@Table(name = "swt_smeeting_person_attend_detail")
@NamedNativeQueries({
		@NamedNativeQuery(name = "statisticPersonAttendDetailByMeetingId", query = "CALL statisticPersonAttendDetailByMeetingId(:start, :limit, :meetingid)", resultClass = PersonAttendDetail.class),
		@NamedNativeQuery(name = "statisticPersonAttendDetailByOrgIdAndMeetingId", query = "CALL statisticPersonAttendDetailByOrgIdAndMeetingId(:start, :limit, :fromdate, :todate, :organizationmeetingid, :meetingid)", resultClass = PersonAttendDetail.class),
		@NamedNativeQuery(name = "statisticPersonAttendDetailByOrgMeetingId", query = "CALL statisticPersonAttendDetailByOrgMeetingId(:start, :limit, :fromdate, :todate, :organizationmeetingid)", resultClass = PersonAttendDetail.class),
		@NamedNativeQuery(name = "statisticPersonAttendDetail", query = "CALL statisticPersonAttendDetail(:start, :limit, :fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = PersonAttendDetail.class),
		@NamedNativeQuery(name = "statisticPersonAttendDetailAll", query = "CALL statisticPersonAttendDetailAll(:start, :limit, :fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = PersonAttendDetail.class) })
public class PersonAttendDetail implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;
	@Column(name = "organizationattendid")
	private long organizationAttendId;
	@Column(name = "organizationattendname")
	private String organizationAttendName;

	// thong tin nguoi tham du
	@Column(name = "partakername")
	private String partakerName;

	@Column(name = "partakerposition")
	private String partakerPosition;

	// them thong tin cmnd va sdt
	@Column(name = "personnotbarcodeid")
	private long personNotBarcodeId;

	@Column(name = "identitycard", length = 30)
	private String identityCard;

	@Column(name = "phonenumber", length = 25)
	private String phonenumber;
	//
	@Column(name = "isadd")
	private boolean isAdd;
	@Column(name = "isjournalist")
	private boolean isJournalist;
	@Column(name = "inputtime")
	private Date inputTime;
	@Column(name = "outputtime")
	private Date outputTime;
	@Column(name = "note")
	private String note;
	// them de thong ke tong the chi tiet
	private String meetingName;
	private long organizationMeetingId;
	private String organizationMeetingName;
	private Date startTime;
	private Date endTime;
	// them truong de client kiem tra co phai khach vang lai ko
	private boolean isNonresident;

	// tinh trang nguoi do da tham du hop
	private boolean status;

	public void setStatus(boolean status) {
		this.status = status;
	}

	public boolean isStatus() {
		return status;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
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

	public String getPartakerName() {
		return partakerName;
	}

	public void setPartakerName(String partakerName) {
		this.partakerName = partakerName;
	}

	public String getPartakerPosition() {
		return partakerPosition;
	}

	public void setPartakerPosition(String partakerPosition) {
		this.partakerPosition = partakerPosition;
	}

	public boolean isAdd() {
		return isAdd;
	}

	public void setAdd(boolean isAdd) {
		this.isAdd = isAdd;
	}

	public boolean isJournalist() {
		return isJournalist;
	}

	public void setJournalist(boolean isJournalist) {
		this.isJournalist = isJournalist;
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

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
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

	public boolean isNonresident() {
		return isNonresident;
	}

	public void setNonresident(boolean isNonresident) {
		this.isNonresident = isNonresident;
	}

	public long getPersonNotBarcodeId() {
		return personNotBarcodeId;
	}

	public void setPersonNotBarcodeId(long personNotBarcodeId) {
		this.personNotBarcodeId = personNotBarcodeId;
	}

	public String getIdentityCard() {
		return identityCard;
	}

	public void setIdentityCard(String identityCard) {
		this.identityCard = identityCard;
	}

	public String getPhonenumber() {
		return phonenumber;
	}

	public void setPhonenumber(String phonenumber) {
		this.phonenumber = phonenumber;
	}

}
