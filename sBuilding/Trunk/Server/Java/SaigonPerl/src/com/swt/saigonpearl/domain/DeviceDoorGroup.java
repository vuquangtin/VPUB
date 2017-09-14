package com.swt.saigonpearl.domain;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "swtgp_sbuilding_devicedoorgroup")
public class DeviceDoorGroup {

	@Id
	@GeneratedValue
	@Column(name = "devicedoorgroupid", nullable = false)
	private long deviceDoorGroupId;

	@Column(name = "devicedoorgroupname")
	private String deviceDoorGroupName;

	@Column(name = "description")
	private String description;

	@Column(name = "isschedule")
	private boolean isSchedule;

	@Column(name = "addgroupmember", columnDefinition = "boolean default false")
	private boolean addGroupMember;

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

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public boolean isSchedule() {
		return isSchedule;
	}

	public void setSchedule(boolean isSchedule) {
		this.isSchedule = isSchedule;
	}

	public boolean isAddGroupMember() {
		return addGroupMember;
	}

	public void setAddGroupMember(boolean addGroupMember) {
		this.addGroupMember = addGroupMember;
	}

}
