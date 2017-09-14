package com.swt.timekeeping.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * 
 * @author Tenit
 *
 */
@Entity
@Table(name = "swtgp_timekeeping_event_member")
public class EventMember implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "eventmemberid", nullable = false)
	private long eventmemberId;
	
	@Column(name = "eventid", nullable = false)
	private long eventId;
	
	@Column(name = "memberid", nullable = false)
	private long memberId;
	
	@Column(name = "membername", nullable = false)
	private String memberName;

	public long getEventmemberId() {
		return eventmemberId;
	}

	public void setEventmemberId(long eventmemberId) {
		this.eventmemberId = eventmemberId;
	}

	public long getEventId() {
		return eventId;
	}

	public void setEventId(long eventId) {
		this.eventId = eventId;
	}

	public long getMemberId() {
		return memberId;
	}

	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}

	public String getMemberName() {
		return memberName;
	}

	public void setMemberName(String memberName) {
		this.memberName = memberName;
	}
	
	
	
}
