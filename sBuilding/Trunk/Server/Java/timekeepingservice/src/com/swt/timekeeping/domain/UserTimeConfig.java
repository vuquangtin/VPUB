package com.swt.timekeeping.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * @author Trang-PC
 */
@Entity
@Table(name = "swtgp_timekeeping_user_time_config")
public class UserTimeConfig implements Serializable{

	/**
	 */
	private static final long serialVersionUID = 1L;
	
	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;
	
	@Column(name = "orgid")
	private long orgId;

	@Column(name = "memberId")
	private long memberId;
	
	@Column(name = "dayofweek")
	private int dayOfWeek;
	
	@Column(name = "sessionworking", length = Integer.MAX_VALUE)
	private String sessionWorking;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

	public long getMemberId() {
		return memberId;
	}

	public void setMemberId(long memberId) {
		this.memberId = memberId;
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
