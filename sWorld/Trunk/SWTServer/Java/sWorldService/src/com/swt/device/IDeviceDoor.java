package com.swt.device;


import java.util.List;

import com.swt.sworld.device.domain.DeviceDoor;

/**
 * @author Tenit
 *
 */
public interface IDeviceDoor {

	DeviceDoor insert(DeviceDoor deviceDoor);

	DeviceDoor update(DeviceDoor deviceDoor);

	int delete(long deviceDoorId);

	DeviceDoor getDeviceDoorId(long deviceDoorId);

	DeviceDoor getDeviceDoorByIp(String ip);

	List<DeviceDoor> getByOrgIdDevice(long orgID);

	List<DeviceDoor> getBySubOrgIdDevice(long subOrg);

	List<DeviceDoor> getDeviceOrgAndSubDevice(long orgId, long subOrg);

	List<DeviceDoor> getDeviceDoorList();
	
	
}
