package com.swt.object;

import java.io.Serializable;




public class DoorOut implements Serializable  {
	
	private static final long serialVersionUID = -4438911533642453314L;
	
	private long Id;

	private long SubOrgId;

	private long MemberId;

	private long CardId;

	private long DeviceDoorId;

	private String SerialNumber;

	private String DateIn;

	private String DateOut;

	private String ImageIn;

	private String ImageOut;

	private String CreateBy;

	private String CreateAt;

	private String ModifiedBy;

	private String ModifiedAt;

	private int Status;

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getSubOrgId() {
		return SubOrgId;
	}

	public void setSubOrgId(long subOrgId) {
		SubOrgId = subOrgId;
	}

	public long getMemberId() {
		return MemberId;
	}

	public void setMemberId(long memberId) {
		MemberId = memberId;
	}

	public long getCardId() {
		return CardId;
	}

	public void setCardId(long cardId) {
		CardId = cardId;
	}

	public long getDeviceDoorId() {
		return DeviceDoorId;
	}

	public void setDeviceDoorId(long deviceDoorId) {
		DeviceDoorId = deviceDoorId;
	}

	public String getSerialNumber() {
		return SerialNumber;
	}

	public void setSerialNumber(String serialNumber) {
		SerialNumber = serialNumber;
	}

	public String getDateIn() {
		return DateIn;
	}

	public void setDateIn(String dateIn) {
		DateIn = dateIn;
	}

	public String getDateOut() {
		return DateOut;
	}

	public void setDateOut(String dateOut) {
		DateOut = dateOut;
	}

	public String getImageIn() {
		return ImageIn;
	}

	public void setImageIn(String imageIn) {
		ImageIn = imageIn;
	}

	public String getImageOut() {
		return ImageOut;
	}

	public void setImageOut(String imageOut) {
		ImageOut = imageOut;
	}

	public String getCreateBy() {
		return CreateBy;
	}

	public void setCreateBy(String createBy) {
		CreateBy = createBy;
	}

	public String getCreateAt() {
		return CreateAt;
	}

	public void setCreateAt(String createAt) {
		CreateAt = createAt;
	}

	public String getModifiedBy() {
		return ModifiedBy;
	}

	public void setModifiedBy(String modifiedBy) {
		ModifiedBy = modifiedBy;
	}

	public String getModifiedAt() {
		return ModifiedAt;
	}

	public void setModifiedAt(String modifiedAt) {
		ModifiedAt = modifiedAt;
	}

	public int getStatus() {
		return Status;
	}

	public void setStatus(int status) {
		Status = status;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}

}
