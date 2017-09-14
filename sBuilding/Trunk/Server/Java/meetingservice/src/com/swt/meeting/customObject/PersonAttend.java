package com.swt.meeting.customObject;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
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
 * @author TaiMai dung de thong ke so luong nguoi tham du cuoc hop
 */
@Entity
@Table(name = "swt_smeeting_person_attend")
@NamedNativeQueries({
		@NamedNativeQuery(name = "statisticPersonAttendAll", query = "CALL statisticPersonAttendAll(:start, :limit, :fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = PersonAttend.class),
		@NamedNativeQuery(name = "statisticPersonAttend", query = "CALL statisticPersonAttend(:start, :limit, :fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = PersonAttend.class),
		@NamedNativeQuery(name = "statisticPersonAttendNew", query = "CALL statisticPersonAttendNew(:fromDate, :toDate, :organizationMeetingId)", resultClass = PersonAttend.class) })

public class PersonAttend implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;

	@Column(name = "meetingid")
	private BigInteger meetingId;

	@Column(name = "meetingname")
	private String meetingName;

	@Column(name = "organizationmeetingid")
	private BigInteger organizationMeetingId;

	@Column(name = "organizationmeetingname")
	private String organizationMeetingName;

	@Column(name = "starttime")
	private Date startTime;

	@Column(name = "endtime")
	private Date endTime;

	@Column(name = "sumpeopleattendinvited")
	private long sumPeopleAttendInvited;

	@Column(name = "numberpeopleattendinvited")
	private BigDecimal numberPeopleAttendInvited;

	@Column(name = "numberpeopleadded")
	private BigDecimal numberPeopleAdded;

	@Column(name = "numberjournalist")
	private BigInteger numberJournalist;

	@Column(name = "numberNonresident")
	private long numberNonresident;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public BigInteger getMeetingId() {
		return meetingId;
	}

	public void setMeetingId(BigInteger meetingId) {
		this.meetingId = meetingId;
	}

	public String getMeetingName() {
		return meetingName;
	}

	public void setMeetingName(String meetingName) {
		this.meetingName = meetingName;
	}

	public BigInteger getOrganizationMeetingId() {
		return organizationMeetingId;
	}

	public void setOrganizationMeetingId(BigInteger organizationMeetingId) {
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

	public long getSumPeopleAttendInvited() {
		return sumPeopleAttendInvited;
	}

	public void setSumPeopleAttendInvited(long sumPeopleAttendInvited) {
		this.sumPeopleAttendInvited = sumPeopleAttendInvited;
	}

	public BigDecimal getNumberPeopleAttendInvited() {
		return numberPeopleAttendInvited;
	}

	public void setNumberPeopleAttendInvited(BigDecimal numberPeopleAttendInvited) {
		this.numberPeopleAttendInvited = numberPeopleAttendInvited;
	}

	public BigDecimal getNumberPeopleAdded() {
		return numberPeopleAdded;
	}

	public void setNumberPeopleAdded(BigDecimal numberPeopleAdded) {
		this.numberPeopleAdded = numberPeopleAdded;
	}

	public BigInteger getNumberJournalist() {
		return numberJournalist;
	}

	public void setNumberJournalist(BigInteger numberJournalist) {
		this.numberJournalist = numberJournalist;
	}

	public void setNumberNonresident(long numberNonresident) {
		this.numberNonresident = numberNonresident;
	}

	public long getNumberNonresident() {
		return numberNonresident;
	}

}
