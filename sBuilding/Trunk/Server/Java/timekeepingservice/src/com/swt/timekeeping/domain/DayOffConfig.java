package com.swt.timekeeping.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * TimeKeepingDayOffConfig
 * 
 * @author minh.nguyen
 *
 */
@Entity
@Table(name = "swtgp_timekeeping_day_off_config")
public class DayOffConfig implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "dayoffconfigid", nullable = false)
	private long dayOffConfigId;

	@Column(name = "memberid", nullable = false)
	private long memberId;

	@Column(name = "date", nullable = false)
	private Date date;

	@Column(name = "status", nullable = false)
	private int status;

	@Column(name = "suborgid", nullable = false)
	private long subOrgId;

	public long getDayOffConfigId() {
		return dayOffConfigId;
	}

	public void setDayOffConfigId(long dayOffConfigId) {
		this.dayOffConfigId = dayOffConfigId;
	}

	public long getMemberId() {
		return memberId;
	}

	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}

	public Date getDate() {
		return date;
	}

	public void setDate(Date date) {
		this.date = date;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}

	public long getSubOrgId() {
		return subOrgId;
	}

	public void setSubOrgId(long subOrgId) {
		this.subOrgId = subOrgId;
	}
}
