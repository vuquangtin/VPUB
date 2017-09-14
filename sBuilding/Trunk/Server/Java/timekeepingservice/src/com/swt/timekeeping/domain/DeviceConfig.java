package com.swt.timekeeping.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * TimeKeepingDeviceConfig
 * 
 * @author TrangPig
 * 
 */
@Entity
@Table(name = "swtgp_timekeeping_device_config")
public class DeviceConfig implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long deviceConfigId;

	@Column(name = "devicedoorid", nullable = false)
	private long deviceDoorId;

	@Column(name = "ip")
	private String ip;

	@Column(name = "devicename")
	private String deviceName;

	@Column(name = "orgid")
	private long orgId;

	@Column(name = "devicedescription")
	private String deviceDescription;

	public long getDeviceConfigId() {
		return deviceConfigId;
	}

	public void setDeviceConfigId(long deviceConfigId) {
		this.deviceConfigId = deviceConfigId;
	}

	public long getDeviceDoorId() {
		return deviceDoorId;
	}

	public void setDeviceDoorId(long deviceDoorId) {
		this.deviceDoorId = deviceDoorId;
	}

	public String getIp() {
		return ip;
	}

	public void setIp(String ip) {
		this.ip = ip;
	}

	public String getDeviceName() {
		return deviceName;
	}

	public void setDeviceName(String deviceName) {
		this.deviceName = deviceName;
	}

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

	public String getDeviceDescription() {
		return deviceDescription;
	}

	public void setDeviceDescription(String deviceDescription) {
		this.deviceDescription = deviceDescription;
	}

}
