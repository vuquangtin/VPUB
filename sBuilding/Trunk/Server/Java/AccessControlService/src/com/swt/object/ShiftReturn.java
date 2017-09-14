package com.swt.object;

import java.io.Serializable;


public class ShiftReturn implements Serializable{
	
	private static final long serialVersionUID = 1L;

	private long id;
	
	private long dateIn;
	
	private long deviceDoorId;
	
	private String deviceDoorIp;
	
	private String imageIn;
	
	private long memberId;
	
	private String serialNumber;
	
	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getDeviceDoorId() {
		return deviceDoorId;
	}

	public void setDeviceDoorId(long deviceDoorId) {
		this.deviceDoorId = deviceDoorId;
	}


	public String getDeviceDoorIp() {
		return deviceDoorIp;
	}

	public void setDeviceDoorIp(String deviceDoorIp) {
		this.deviceDoorIp = deviceDoorIp;
	}

	public String getImageIn() {
		return imageIn;
	}

	public void setImageIn(String imageIn) {
		this.imageIn = imageIn;
	}

	public long getMemberId() {
		return memberId;
	}

	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}

	public String getSerialNumber() {
		return serialNumber;
	}

	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
	}

	public long getDateIn() {
		return dateIn;
	}

	public void setDateIn(long dateIn) {
		this.dateIn = dateIn;
	}

}
