/**
 * 
 */
package com.swt.meeting.customObject;

import java.util.List;

import com.swt.meeting.domain.Meeting;
import com.swt.meeting.domain.Partaker;

/**
 * @author Tenit
 *
 */
public class KeyOrgMeetingObj {
	private Meeting meeting;
	private String orgPartakerName;
	private long orgPartakerId;
	private List<Partaker> partaker;
	public Meeting getMeeting() {
		return meeting;
	}
	public void setMeeting(Meeting meeting) {
		this.meeting = meeting;
	}
	public String getOrgPartakerName() {
		return orgPartakerName;
	}
	public void setOrgPartakerName(String orgPartakerName) {
		this.orgPartakerName = orgPartakerName;
	}
	public List<Partaker> getPartaker() {
		return partaker;
	}
	public void setPartaker(List<Partaker> partaker) {
		this.partaker = partaker;
	}
	public long getOrgPartakerId() {
		return orgPartakerId;
	}
	public void setOrgPartakerId(long orgPartakerId) {
		this.orgPartakerId = orgPartakerId;
	}

}
