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
@Table(name = "swt_smeeting_contact_statistic")
@NamedNativeQueries({
		@NamedNativeQuery(name = "statisticContactDetailByDateAndOrgId", query = "CALL statisticContactDetailByDateAndOrgId(:start, :limit, :fromdate, :todate, :orgid)", resultClass = SmeetingContactStatistic.class) })
public class SmeetingContactStatistic implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	private long id;

	// thong tin nguoi vao lien he
	@Column(name = "partakername")
	private String partakerName;

	@Column(name = "position")
	private String position;

	@Column(name = "identitycard", length = 30)
	private String identityCard;

	@Column(name = "phonenumber", length = 25)
	private String phonenumber;

	// don vi to chuc cuoc hop
	@Column(name = "organizationmeetingid")
	private long organizationMeetingId;

	@Column(name = "organizationmeetingname")
	private String organizationMeetingName;

	// don vi duoc moi tham du cuoc hop
	@Column(name = "organizationattendid")
	private long organizationAttendId;

	@Column(name = "organizationattendname")
	private String organizationAttendName;

	@Column(name = "note", columnDefinition = "Text")
	private String note;

	@Column(name = "inputtime")
	private Date inputTime;

	@Column(name = "outputtime")
	private Date outputTime;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getPartakerName() {
		return partakerName;
	}

	public void setPartakerName(String partakerName) {
		this.partakerName = partakerName;
	}

	public String getPosition() {
		return position;
	}

	public void setPosition(String position) {
		this.position = position;
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

	public String getNote() {
		return note;
	}

	public void setNote(String note) {
		this.note = note;
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
