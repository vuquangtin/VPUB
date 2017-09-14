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

@Entity
@Table(name = "swt_nonresident_nonresident")
@NamedNativeQueries({
		@NamedNativeQuery(name = "statisticNonresidentByMeetingId", query = "CALL statisticNonresidentByMeetingId(:start, :limit, :fromdate, :todate, :meetingid)", resultClass = NonResident.class),
		@NamedNativeQuery(name = "statisticNonresidentLimitByDateAndOrgIdAndMeetingName", query = "CALL statisticNonresidentLimitByDateAndOrgIdAndMeetingName(:start, :limit, :fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = NonResident.class),
		@NamedNativeQuery(name = "statisticNonresidentLimitByDateAndOrgIdAndMeetingNameAll", query = "CALL statisticNonresidentLimitByDateAndOrgIdAndMeetingNameAll(:start, :limit, :fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = NonResident.class),
		@NamedNativeQuery(name = "statisticNonresidentByDateAndOrgIdAndMeetingNameAll", query = "CALL statisticNonresidentByDateAndOrgIdAndMeetingNameAll(:fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = NonResident.class),
		@NamedNativeQuery(name = "statisticNonresidentByDateAndOrgIdAndMeetingName", query = "CALL statisticNonresidentByDateAndOrgIdAndMeetingName(:fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = NonResident.class),
		@NamedNativeQuery(name = "sumNonresidentDetailByMeetingId", query = "CALL sumNonresidentDetailByMeetingId(:fromDate, :toDate, :meetingid)", resultClass = NonResident.class),
		@NamedNativeQuery(name = "statisticNonresidentLimitByDateAndOrgId", query = "CALL statisticNonresidentLimitByDateAndOrgId(:start, :limit, :fromDate, :toDate, :orgId)", resultClass = NonResident.class),
		@NamedNativeQuery(name = "statisticNonresidentLimitDetailByDate", query = "CALL statisticNonresidentLimitDetailByDate(:start, :limit, :fromDate, :toDate)", resultClass = NonResident.class),
		@NamedNativeQuery(name = "statisticNonresidentLimitDetailByDateAndOrgId", query = "CALL statisticNonresidentLimitDetailByDateAndOrgId(:start, :limit, :fromDate, :toDate, :orgId)", resultClass = NonResident.class), })
public class NonResident implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	private long id;

	@Column(name = "serialnumber", length = 10)
	private String serialNumber;

	@Column(name = "name", length = 50)
	private String name;

	@Column(name = "birthday")
	private Date birthday;

	@Column(name = "gender")
	private boolean gender;

	@Column(name = "identitycard", length = 30)
	private String identityCard;

	@Column(name = "identitycardissuedate")
	private Date identityCardIssueDate;

	@Column(name = "identitycardissue", length = 30)
	private String identitycardIssue;

	@Column(name = "phonenumber", length = 25)
	private String phonenumber;

	@Column(name = "temporaryaddress")
	private String temporaryAddress;

	@Column(name = "inputTime")
	private Date inputTime;

	@Column(name = "outputTime")
	private Date outputTime;

	// den to chuc nao
	@Column(name = "orgid")
	private long orgId;

	@Column(name = "orgname", length = 150)
	private String orgName;

	// den cuoc hop nao
	@Column(name = "meetingid")
	private long meetingId;
	@Column(name = "meetingname")
	private String meetingName;

	@Column(name = "nonresidentposition")
	public String nonResidentPosition;

	@Column(name = "nonresidentorganization")
	public String nonResidentOrganization;

	// danh de phan biet khach vang lai va doanh nghiep khac duoc them vao
	@Column(name = "isorgother")
	private boolean isOrgOther;

	@Column(name = "note")
	private String note;

	@Column(name = "nonMemOrSubOrgId")
	private long nonMemOrSubOrgId;

	@Column(name = "isPeople")
	private int isPeople;

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

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Date getBirthday() {
		return birthday;
	}

	public void setBirthday(Date birthday) {
		this.birthday = birthday;
	}

	public boolean isGender() {
		return gender;
	}

	public void setGender(boolean gender) {
		this.gender = gender;
	}

	public String getIdentityCard() {
		return identityCard;
	}

	public void setIdentityCard(String identityCard) {
		this.identityCard = identityCard;
	}

	public Date getIdentityCardIssueDate() {
		return identityCardIssueDate;
	}

	public void setIdentityCardIssueDate(Date identityCardIssueDate) {
		this.identityCardIssueDate = identityCardIssueDate;
	}

	public String getIdentitycardIssue() {
		return identitycardIssue;
	}

	public void setIdentitycardIssue(String identitycardIssue) {
		this.identitycardIssue = identitycardIssue;
	}

	public String getPhonenumber() {
		return phonenumber;
	}

	public void setPhonenumber(String phonenumber) {
		this.phonenumber = phonenumber;
	}

	public String getTemporaryAddress() {
		return temporaryAddress;
	}

	public void setTemporaryAddress(String temporaryAddress) {
		this.temporaryAddress = temporaryAddress;
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

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

	public String getOrgName() {
		return orgName;
	}

	public void setOrgName(String orgName) {
		this.orgName = orgName;
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

	public String getNonResidentPosition() {
		return nonResidentPosition;
	}

	public void setNonResidentPosition(String nonResidentPosition) {
		this.nonResidentPosition = nonResidentPosition;
	}

	public String getNonResidentOrganization() {
		return nonResidentOrganization;
	}

	public void setNonResidentOrganization(String nonResidentOrganization) {
		this.nonResidentOrganization = nonResidentOrganization;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}

	public long getNonMemOrSubOrgId() {
		return nonMemOrSubOrgId;
	}

	public void setNonMemOrSubOrgId(long nonMemOrSubOrgId) {
		this.nonMemOrSubOrgId = nonMemOrSubOrgId;
	}

	public int getIsPeople() {
		return isPeople;
	}

	public void setIsPeople(int isPeople) {
		this.isPeople = isPeople;
	}
}
