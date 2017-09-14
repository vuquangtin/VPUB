package com.swt.saigonpearl.domain;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swtgp_sbuilding_door_out")
public class DoorOut {

	@Id
	@GeneratedValue
	@Column(name = "Id", nullable = false)
	private long Id;
	
	@Column(name = "SubOrgId", nullable = false)
	private long SubOrgId;
	
	@Column(name = "MemberId", nullable = false)
	private long MemberId;
	
	@Column(name = "CardId", nullable = false)
	private long CardId;
	
	@Column(name = "DeviceDoorId", nullable = false)
	private long DeviceDoorId;
	
	@Column(name = "SerialNumber", nullable = false)
	private String SerialNumber;
	
	@Column(name = "DateIn", nullable = false)
	private String DateIn;
	
	@Column(name = "DateOut")
	private String DateOut;
	
	@Column(name = "ImageIn", columnDefinition="Text")
	private String ImageIn;
	
	@Column(name = "ImageOut", columnDefinition="Text")
	private String ImageOut;
	
	@Column(name = "CreateBy")
	private String CreateBy;
	
	@Column(name = "CreateAt")
	private String CreateAt;
	
	@Column(name = "ModifiedBy")
	private String ModifiedBy;
	
	@Column(name = "ModifiedAt")
	private String ModifiedAt;
	
	@Column(name = "Status")
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
	
	
}
