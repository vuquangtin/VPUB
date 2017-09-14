/**
 * 
 */
package com.swt.meetingregister.customobject;

import java.util.Date;

/**
 * @author Tenit
 *
 */
public class CustomMeeting {
	private String barcode;
	private String partaker;
	private String detailMeeting;
	private String orgMeetingName;
	private long orgattendId;
	private int hour;
	private int minute;
	public String getBarcode() {
		return barcode;
	}
	public void setBarcode(String barcode) {
		this.barcode = barcode;
	}
	public String getPartaker() {
		return partaker;
	}
	public void setPartaker(String partaker) {
		this.partaker = partaker;
	}
	public String getDetailMeeting() {
		return detailMeeting;
	}
	public void setDetailMeeting(String detailMeeting) {
		this.detailMeeting = detailMeeting;
	}
	public String getOrgMeetingName() {
		return orgMeetingName;
	}
	public void setOrgMeetingName(String orgMeetingName) {
		this.orgMeetingName = orgMeetingName;
	}
	public long getOrgattendId() {
		return orgattendId;
	}
	public void setOrgattendId(long orgattendId) {
		this.orgattendId = orgattendId;
	}
	public int getHour() {
		return hour;
	}
	public void setHour(int hour) {
		this.hour = hour;
	}
	public int getMinute() {
		return minute;
	}
	public void setMinute(int minute) {
		this.minute = minute;
	}
	
	

}
