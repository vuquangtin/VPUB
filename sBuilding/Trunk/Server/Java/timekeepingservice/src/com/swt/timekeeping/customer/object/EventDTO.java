package com.swt.timekeeping.customer.object;

import java.io.Serializable;

import com.swt.timekeeping.domain.EventMember;
/**
 * Clas nay dung de gui va nhan du lieu giua client va server
 * @author Trang-PC
 *
 */
public class EventDTO implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	//eventmemberid dung de nguoi dung chon va gui len server xoa trong bang EventMember 
	private long eventMemberId;
	
	private EventResultForGet eventObj;
	
	private EventMember eventMemberObj;
	
	public long getEventMemberId() {
		return eventMemberId;
	}
	
	public void setEventMemberId(long eventMemberId) {
		this.eventMemberId = eventMemberId;
	}

	public EventResultForGet getEventObj() {
		return eventObj;
	}

	public void setEventObj(EventResultForGet eventObj) {
		this.eventObj = eventObj;
	}

	public EventMember getEventMemberObj() {
		return eventMemberObj;
	}

	public void setEventMemberObj(EventMember eventMemberObj) {
		this.eventMemberObj = eventMemberObj;
	}


}
