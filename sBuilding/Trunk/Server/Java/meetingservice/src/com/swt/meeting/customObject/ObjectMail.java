/**
 * 
 */
package com.swt.meeting.customObject;

/**
 * @author Tenit
 *
 */
public class ObjectMail {
	private String subject;
	private String content;
	private long orgPartaker;
	private long meetingId;
	
	public String getSubject() {
		return subject;
	}
	public void setSubject(String subject) {
		this.subject = subject;
	}
	public String getContent() {
		return content;
	}
	public void setContent(String content) {
		this.content = content;
	}
	public long getOrgPartaker() {
		return orgPartaker;
	}
	public void setOrgPartaker(long orgPartaker) {
		this.orgPartaker = orgPartaker;
	}
	public long getMeetingId() {
		return meetingId;
	}
	public void setMeetingId(long meetingId) {
		this.meetingId = meetingId;
	}

}
