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
@Table(name = "swt_smeeting_journalist_attend_detail")
@NamedNativeQueries({
		@NamedNativeQuery(name = "statisticJournalistAttendDetailByMeetingId", query = "CALL statisticJournalistAttendDetailByMeetingId(:start, :limit, :meetingid)", resultClass = JournalistAttendStatisticDetail.class),
		@NamedNativeQuery(name = "statisticJournalistAttendDetailByOrgIdAndMeetingId", query = "CALL statisticJournalistAttendDetailByOrgIdAndMeetingId(:start, :limit, :fromdate, :todate, :organizationmeetingid, :meetingid)", resultClass = JournalistAttendStatisticDetail.class),
		@NamedNativeQuery(name = "statisticJournalistAttendDetail", query = "CALL statisticJournalistAttendDetail(:start, :limit, :fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = JournalistAttendStatisticDetail.class),
		@NamedNativeQuery(name = "statisticJournalistAttendDetailAll", query = "CALL statisticJournalistAttendDetailAll(:start, :limit, :fromDate, :toDate, :organizationMeetingId, :meetingName)", resultClass = JournalistAttendStatisticDetail.class) })
public class JournalistAttendStatisticDetail implements Serializable {
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
	@Column(name = "partakername")
	private String partakerName;
	@Column(name = "partakerposition")
	private String partakerPosition;
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

	public void setPartakerPosition(String partakerPosition) {
		this.partakerPosition = partakerPosition;
	}

	public String getPartakerPosition() {
		return partakerPosition;
	}
}
