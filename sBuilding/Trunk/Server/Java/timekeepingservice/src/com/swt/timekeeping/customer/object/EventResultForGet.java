package com.swt.timekeeping.customer.object;

import java.io.Serializable;

import com.swt.timekeeping.domain.Event;
/**
 * 
 * @author asuspc
 *
 */
public class EventResultForGet implements Serializable{

	private static final long serialVersionUID = 1L;
	private long eventId;
	private String eventName;
	private long orgId;
	private long subOrgId;
	private String dateIn;
	private String hourEventBegin;
	private int hourEventKeeping;
	private String description;
	public EventResultForGet(){}
	public EventResultForGet(Event event){
		 this.eventId = event.getEventId();
		 this.eventName = event.getEventName();
		 this.orgId = event.getOrgId();
		 this.subOrgId = event.getSubOrgId();
		 this.dateIn = event.getDateIn().toString();
		 this.hourEventBegin = event.getHourEventBegin();
		 this.hourEventKeeping = event.getHourEventKeeping();
		 this.description = event.getDescription();
	}
	public long getEventId() {
		return eventId;
	}
	public void setEventId(long eventId) {
		this.eventId = eventId;
	}
	public String getEventName() {
		return eventName;
	}
	public void setEventName(String eventName) {
		this.eventName = eventName;
	}
	public long getOrgId() {
		return orgId;
	}
	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}
	public long getSubOrgId() {
		return subOrgId;
	}
	public void setSubOrgId(long subOrgId) {
		this.subOrgId = subOrgId;
	}
	public String getDateIn() {
		return dateIn;
	}
	public void setDateIn(String dateIn) {
		this.dateIn = dateIn;
	}
	public String getHourEventBegin() {
		return hourEventBegin;
	}
	public void setHourEventBegin(String hourEventBegin) {
		this.hourEventBegin = hourEventBegin;
	}
	public int getHourEventKeeping() {
		return hourEventKeeping;
	}
	public void setHourEventKeeping(int hourEventKeeping) {
		this.hourEventKeeping = hourEventKeeping;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	
	
}
