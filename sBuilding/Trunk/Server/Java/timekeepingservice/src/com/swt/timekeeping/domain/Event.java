package com.swt.timekeeping.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * TimeKeepingEvent
 * @author TrangPig
 *
 */
@Entity
@Table(name = "swtgp_timekeeping_event")
public class Event implements Serializable{
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "eventid", nullable = false)
	private long eventId;
	
	@Column(name = "eventname", nullable = false)
	private String eventName;
	
	@Column(name = "orgid", nullable = false)
	private long orgId;
	
	@Column(name = "suborgid")
	private long subOrgId;
	
	@Column(name = "datein", nullable = false)
	private Date dateIn;
	
	@Column(name = "houreventbegin", nullable = false)
	private String hourEventBegin;
	
	@Column(name = "houreventkeeping", nullable = false)
	private int hourEventKeeping;
	
	@Column(name = "description")
	private String description;
/**
 * 
 * @return the eventId
 */
	public long getEventId() {
		return eventId;
	}
/**
 * 
 * @param eventId
 */
	public void setEventId(long eventId) {
		this.eventId = eventId;
	}

	/**
	 * getOrgId
	 * @return
	 */
	public long getOrgId() {
	return orgId;
	}
	/**
	 * setOrgId
	 * @param orgId
	 */
	public void setOrgId(long orgId) {
	this.orgId = orgId;
	}
	/**
	 * getSubOrgId
	 * @return
	 */
	public long getSubOrgId() {
		return subOrgId;
	}
	/**
	 * setSubOrgId
	 * @param subOrgId
	 */
	public void setSubOrgId(long subOrgId) {
		this.subOrgId = subOrgId;
	}
/**
 * 
 * @return the eventName
 */
	public String getEventName() {
		return eventName;
	}
/**
 * 
 * @param eventName
 */
	public void setEventName(String eventName) {
		this.eventName = eventName;
	}
	
	/**
	 * getDateIn
	 * @return
	 */

	public Date getDateIn() {
	return dateIn;
	}
	
	/**
	 * setDateIn
	 * @param dateIn
	 */
	public void setDateIn(Date dateIn) {
	this.dateIn = dateIn;
	}

	/**
	 * 
	 * @return hourEventKeeping
	 */
	public int getHourEventKeeping() {
		return hourEventKeeping;
	}
	/**
	 * setHourEventKeeping
	 * @param hourEventKeeping
	 */
	public void setHourEventKeeping(int hourEventKeeping) {
		this.hourEventKeeping = hourEventKeeping;
	}
	
/**
 * 
 * @return the description
 */
	public String getDescription() {
		return description;
	}
/**
 * 
 * @param description
 */
	public void setDescription(String description) {
		this.description = description;
	}
public String getHourEventBegin() {
	return hourEventBegin;
}
public void setHourEventBegin(String hourEventBegin) {
	this.hourEventBegin = hourEventBegin;
}

}
