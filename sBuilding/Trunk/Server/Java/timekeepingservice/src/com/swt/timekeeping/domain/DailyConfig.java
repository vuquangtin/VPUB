package com.swt.timekeeping.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * 
 * @author Trang-PC
 *
 */
@Entity
@Table(name = "swtgp_timekeeping_daily_config")
public class DailyConfig implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long id;
	
	@Column(name = "orgid", nullable = false)
	private long orgId;
	
	@Column(name = "date", nullable = false)
	private Date date;
	
	@Column(name = "jsontimeconfig", nullable = false)
	private String jsonTimeConfig;
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
	public Date getDate() {
		return date;
	}
	public void setDate(Date date) {
		this.date = date;
	}
	public String getJsonTimeConfig() {
		return jsonTimeConfig;
	}
	public void setJsonTimeConfig(String jsonTimeConfig) {
		this.jsonTimeConfig = jsonTimeConfig;
	}
	
}
