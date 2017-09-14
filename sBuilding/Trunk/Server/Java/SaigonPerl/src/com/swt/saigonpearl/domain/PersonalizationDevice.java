package com.swt.saigonpearl.domain;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/*
 * Class nay dung de truy van cho phep vao cua hay khong
 */
@Entity
@Table(name = "swtgp_sbuilding_personalization_device")
public class PersonalizationDevice {

	@Id
	@GeneratedValue
	@Column(name = "personalizationdeviceid", nullable = false)
	private long personalizationDeviceId;

	@Column(name = "memberid")
	private long memberId;

	@Column(name = "roleid")
	private long roleId;

	@Column(name = "devicedoorgroupid")
	private long deviceDoorGroupId;

	@Column(name = "serialnumber")
	private String serialNumber;

	@Column(name = "deviceid")
	private long deviceId;

	@Column(name = "deviceip")
	private String deviceIp;

	public long getPersonalizationDeviceId() {
		return personalizationDeviceId;
	}

	public void setPersonalizationDeviceId(long personalizationDeviceId) {
		this.personalizationDeviceId = personalizationDeviceId;
	}

	public long getMemberId() {
		return memberId;
	}

	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}

	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}

	public long getDeviceDoorGroupId() {
		return deviceDoorGroupId;
	}

	public void setDeviceDoorGroupId(long deviceDoorGroupId) {
		this.deviceDoorGroupId = deviceDoorGroupId;
	}

	public String getSerialNumber() {
		return serialNumber;
	}

	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
	}

	public long getDeviceId() {
		return deviceId;
	}

	public void setDeviceId(long deviceId) {
		this.deviceId = deviceId;
	}

	public String getDeviceIp() {
		return deviceIp;
	}

	public void setDeviceIp(String deviceIp) {
		this.deviceIp = deviceIp;
	}

}