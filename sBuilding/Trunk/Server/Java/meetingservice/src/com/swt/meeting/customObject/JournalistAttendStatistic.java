/**
 * 
 */
package com.swt.meeting.customObject;

import java.io.Serializable;
import java.math.BigInteger;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.NamedNativeQueries;
import javax.persistence.NamedNativeQuery;
import javax.persistence.Table;

@Entity
@Table(name = "swt_smeeting_journalist_attend_statistic")
@NamedNativeQueries({
		@NamedNativeQuery(name = "statisticJournalistAttendAll", query = "CALL statisticJournalistAttendAll(:start, :limit, :fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = JournalistAttendStatistic.class),
		@NamedNativeQuery(name = "statisticJournalistAttend", query = "CALL statisticJournalistAttend(:start, :limit, :fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = JournalistAttendStatistic.class), })

public class JournalistAttendStatistic implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "id")
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

	@Column(name = "numberjournalist")
	private BigInteger numberJournalist;

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

	public BigInteger getNumberJournalist() {
		return numberJournalist;
	}

	public void setNumberJournalist(BigInteger numberJournalist) {
		this.numberJournalist = numberJournalist;
	}

}
