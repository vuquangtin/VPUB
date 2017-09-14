package com.swt.sworld.device.domain;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.NamedNativeQueries;
import javax.persistence.NamedNativeQuery;
import javax.persistence.Table;

@Entity
@Table(name = "swtgp_device_device_door")
@NamedNativeQueries({
    @NamedNativeQuery(
            name = "getDeviceDoor",
            query = "CALL getDeviceDoor(:groupsId)",
            resultClass = DeviceDoor.class
    )
})
public class DeviceDoor {

	@Id
	@GeneratedValue
	@Column(name = "Id", nullable = false)
	private long Id;

	@Column(name = "Name", nullable = false)
	private String Name;

	@Column(name = "Ip", nullable = false)
	private String Ip;

	@Column(name = "Port")
	private String Port;

	@Column(name = "Locked")
	private Boolean Locked;

	@Column(name = "status")
	private String status;

	@Column(name = "TimeOpen")
	private String TimeOpen;

	@Column(name = "TimeClose")
	private String TimeClose;

	@Column(name = "CreateBy")
	private String CreateBy;

	@Column(name = "CreateAt")
	private String CreateAt;

	@Column(name = "ModifiedBy")
	private String ModifiedBy;

	@Column(name = "ModifiedAt")
	private String ModifiedAt;

	@Column(name = "description")
	private String Description;

	@Column(name = "devicetimekeeping")
	private boolean deviceTimekeeping;
	
	@Column(name = "deviceofgroup")
	private boolean deviceOfGroup;
	
	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public String getName() {
		return Name;
	}

	public void setName(String name) {
		Name = name;
	}

	public String getIp() {
		return Ip;
	}

	public void setIp(String ip) {
		Ip = ip;
	}

	public String getPort() {
		return Port;
	}

	public void setPort(String port) {
		Port = port;
	}

	public Boolean getLocked() {
		return Locked;
	}

	public void setLocked(Boolean locked) {
		Locked = locked;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public String getTimeOpen() {
		return TimeOpen;
	}

	public void setTimeOpen(String timeOpen) {
		TimeOpen = timeOpen;
	}

	public String getTimeClose() {
		return TimeClose;
	}

	public void setTimeClose(String timeClose) {
		TimeClose = timeClose;
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

	public String getDescription() {
		return Description;
	}

	public void setDescription(String description) {
		this.Description = description;
	}

	public boolean isDeviceTimekeeping() {
		return deviceTimekeeping;
	}

	public void setDeviceTimekeeping(boolean deviceTimekeeping) {
		this.deviceTimekeeping = deviceTimekeeping;
	}

	public boolean isDeviceOfGroup() {
		return deviceOfGroup;
	}

	public void setDeviceOfGroup(boolean deviceOfGroup) {
		this.deviceOfGroup = deviceOfGroup;
	}
	
}


