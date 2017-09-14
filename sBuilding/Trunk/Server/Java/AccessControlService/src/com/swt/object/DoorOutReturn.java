package com.swt.object;

import java.io.Serializable;




public class DoorOutReturn implements Serializable  {
	
	private static final long serialVersionUID = -4438911533642453314L;
	
	private long id;

	private long subOrgId;

	private long memberId;

	private long cardId;

	private long deviceDoorId;

	private String serialNumber;

	private String dateIn;

	private String dateOut;

	private String imageIn;

	private String imageOut;

	private String createBy;

	private String createAt;

	private String modifiedBy;

	private String modifiedAt;

	private int status;


	public long getId() {
		return id;
	}


	public void setId(long id) {
		this.id = id;
	}


	public long getSubOrgId() {
		return subOrgId;
	}


	public void setSubOrgId(long subOrgId) {
		this.subOrgId = subOrgId;
	}


	public long getMemberId() {
		return memberId;
	}


	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}


	public long getCardId() {
		return cardId;
	}


	public void setCardId(long cardId) {
		this.cardId = cardId;
	}


	public long getDeviceDoorId() {
		return deviceDoorId;
	}


	public void setDeviceDoorId(long deviceDoorId) {
		this.deviceDoorId = deviceDoorId;
	}


	public String getSerialNumber() {
		return serialNumber;
	}


	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
	}


	public String getDateIn() {
		return dateIn;
	}


	public void setDateIn(String dateIn) {
		this.dateIn = dateIn;
	}


	public String getDateOut() {
		return dateOut;
	}


	public void setDateOut(String dateOut) {
		this.dateOut = dateOut;
	}


	public String getImageIn() {
		return imageIn;
	}


	public void setImageIn(String imageIn) {
		this.imageIn = imageIn;
	}


	public String getImageOut() {
		return imageOut;
	}


	public void setImageOut(String imageOut) {
		this.imageOut = imageOut;
	}


	public String getCreateBy() {
		return createBy;
	}


	public void setCreateBy(String createBy) {
		this.createBy = createBy;
	}


	public String getCreateAt() {
		return createAt;
	}


	public void setCreateAt(String createAt) {
		this.createAt = createAt;
	}


	public String getModifiedBy() {
		return modifiedBy;
	}


	public void setModifiedBy(String modifiedBy) {
		this.modifiedBy = modifiedBy;
	}


	public String getModifiedAt() {
		return modifiedAt;
	}


	public void setModifiedAt(String modifiedAt) {
		this.modifiedAt = modifiedAt;
	}


	public int getStatus() {
		return status;
	}


	public void setStatus(int status) {
		this.status = status;
	}


	public static long getSerialversionuid() {
		return serialVersionUID;
	}

}
