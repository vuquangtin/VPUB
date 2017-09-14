package com.swt.timekeeping.customer.object;

import java.io.Serializable;
import java.util.List;

import com.swt.timekeeping.domain.Event;
import com.swt.timekeeping.domain.EventMember;

public class EventMemberListDTO implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	private Event eventObj;
	
	private List<EventMember> eventMemberListObj;

	public Event getEventObj() {
		return eventObj;
	}

	public void setEventObj(Event eventObj) {
		this.eventObj = eventObj;
	}

	public List<EventMember> getEventMemberListObj() {
		return eventMemberListObj;
	}

	public void setEventMemberListObj(List<EventMember> eventMemberListObj) {
		this.eventMemberListObj = eventMemberListObj;
	}

}
