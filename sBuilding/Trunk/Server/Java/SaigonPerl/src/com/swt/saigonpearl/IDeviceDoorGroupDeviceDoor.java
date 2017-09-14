package com.swt.saigonpearl;

import java.util.List;

import com.swt.saigonpearl.domain.DeviceDoorGroupDeviceDoor;

/*
 * @author tenit
 */
public interface IDeviceDoorGroupDeviceDoor {
	DeviceDoorGroupDeviceDoor insert(DeviceDoorGroupDeviceDoor doorGroupDDeviceDoor);

	int delete(long doorGroupDeviceDoorId);

	List<DeviceDoorGroupDeviceDoor> getListDeviceDoorGroupDeviceDoorByGroupId(long deviceDoorGroupId);

	void deleteDevice(long deviceId, long groupId);

}
