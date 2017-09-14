package com.swt.timekeeping.customer.object;

import java.io.Serializable;
import java.util.List;

import com.swt.timekeeping.domain.Event;

public class ConfigForStatisticDTO implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private List<Event> eventList;
	private String sessionWorking;
	public List<Event> getEventList() {
		return eventList;
	}
	public void setEventList(List<Event> eventList) {
		this.eventList = eventList;
	}
	public String getSessionWorking() {
		return sessionWorking;
	}
	public void setSessionWorking(String sessionWorking) {
		this.sessionWorking = sessionWorking;
	} 
	
}
