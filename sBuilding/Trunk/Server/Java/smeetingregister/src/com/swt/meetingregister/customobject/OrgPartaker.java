/**
 * 
 */
package com.swt.meetingregister.customobject;

/**
 * @author Tenit
 *
 */
public class OrgPartaker {
	private String name;
	private String reason;
	private long meetingId;
	private boolean meeting;
	private String barcode;
	private long orgattendId;
	
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getReason() {
		return reason;
	}

	public void setReason(String reason) {
		this.reason = reason;
	}

	public long getMeetingId() {
		return meetingId;
	}

	public void setMeetingId(long meetingId) {
		this.meetingId = meetingId;
	}

	public boolean isMeeting() {
		return meeting;
	}

	public void setMeeting(boolean meeting) {
		this.meeting = meeting;
	}

	public String getBarcode() {
		return barcode;
	}

	public void setBarcode(String barcode) {
		this.barcode = barcode;
	}

	public long getOrgattendId() {
		return orgattendId;
	}

	public void setOrgattendId(long orgattendId) {
		this.orgattendId = orgattendId;
	}

}
