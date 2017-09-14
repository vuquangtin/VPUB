package com.swt.timekeeping.domain;

//import java.util.Date;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * TimeKeepingTime
 * 
 * @author TrangPig
 *
 */
@Entity
@Table(name = "swtgp_timekeeping_time_config")
public class TimeConfig implements Serializable{

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "timeid", nullable = false)
	private long timeConfigId;
	
	@Column(name = "orgid")
	private long orgId;
	                                         
	@Column(name = "dayofweek")
	private int dayOfWeek;

	@Column(name = "sessionworking", length = Integer.MAX_VALUE)
	private String sessionWorking;

	public long getTimeConfigId() {
		return timeConfigId;
	}

	public void setTimeConfigId(long timeConfigId) {
		this.timeConfigId = timeConfigId;
	}

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

	public int getDayOfWeek() {
		return dayOfWeek;
	}

	public void setDayOfWeek(int dayOfWeek) {
		this.dayOfWeek = dayOfWeek;
	}

	public String getSessionWorking() {
		return sessionWorking;
	}

	public void setSessionWorking(String sessionWorking) {
		this.sessionWorking = sessionWorking;
	}

	
	}
