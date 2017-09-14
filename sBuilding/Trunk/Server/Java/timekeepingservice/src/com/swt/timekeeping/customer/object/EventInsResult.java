package com.swt.timekeeping.customer.object;

import java.io.Serializable;
public class EventInsResult implements Serializable{
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private long eventId;
	private String eventName;
	private long orgId;
	private long subOrgId;
	private long dateIn;
	private String hourEventBegin;
	private int hourEventKeeping;
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

	public long getDateIn() {
	return dateIn;
	}
	
	/**
	 * setDateIn
	 * @param dateIn
	 */
	public void setDateIn(long dateIn) {
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
