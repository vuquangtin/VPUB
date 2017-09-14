package com.swt.timekeeping.customer.object;

import java.io.Serializable;

public class TimeKeepingAcessDTO implements Serializable{
	
	 /**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private long memberId;
	 private long deviceDoorId;
	 
	public long getMemberId() {
		return memberId;
	}
	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}
	public long getDeviceDoorId() {
		return deviceDoorId;
	}
	public void setDeviceDoorId(long deviceDoorId) {
		this.deviceDoorId = deviceDoorId;
	}
	 
}
