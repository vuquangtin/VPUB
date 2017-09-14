package com.swt.saigonpearl.domain;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swtgp_sbuilding_devicedoorgroup_devicedoor")
public class DeviceDoorGroupDeviceDoor {
	@Id
	@GeneratedValue
	@Column(name = "devicedoorgroupdeviceid", nullable = false)
	private long deviceDoorGroupDeviceId;

	@Column(name = "devicedoorgroupid")
	private long deviceDoorGroupId;

	@Column(name = "devicedoorid")
	private long deviceDoorId;

	@Column(name = "devicedoorname")
	private String deviceDoorName;

	@Column(name = "devicedoorgroupname")
	private String deviceDoorGroupName;

	@Column(name = "ip")
	private String ip;

	@Column(name = "desriptiondevice")
	private String deviceDoordesription;

	public long getDeviceDoorGroupDeviceId() {
		return deviceDoorGroupDeviceId;
	}

	public void setDeviceDoorGroupDeviceId(long deviceDoorGroupDeviceId) {
		this.deviceDoorGroupDeviceId = deviceDoorGroupDeviceId;
	}

	public long getDeviceDoorGroupId() {
		return deviceDoorGroupId;
	}

	public void setDeviceDoorGroupId(long deviceDoorGroupId) {
		this.deviceDoorGroupId = deviceDoorGroupId;
	}

	public String getDeviceDoorGroupName() {
		return deviceDoorGroupName;
	}

	public void setDeviceDoorGroupName(String deviceDoorGroupName) {
		this.deviceDoorGroupName = deviceDoorGroupName;
	}

	public long getDeviceDoorId() {
		return deviceDoorId;
	}

	public void setDeviceDoorId(long deviceDoorId) {
		this.deviceDoorId = deviceDoorId;
	}

	public String getDeviceDoorName() {
		return deviceDoorName;
	}

	public void setDeviceDoorName(String deviceDoorName) {
		this.deviceDoorName = deviceDoorName;
	}

	public String getIp() {
		return ip;
	}

	public void setIp(String ip) {
		this.ip = ip;
	}

	public String getDeviceDoordesription() {
		return deviceDoordesription;
	}

	public void setDeviceDoordesription(String deviceDoordesription) {
		this.deviceDoordesription = deviceDoordesription;
	}

	

}
