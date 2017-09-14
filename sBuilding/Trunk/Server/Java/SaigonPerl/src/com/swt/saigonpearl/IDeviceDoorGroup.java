package com.swt.saigonpearl;

import java.util.List;

import com.swt.saigonpearl.domain.DeviceDoorGroup;
import com.swt.saigonpearl.domain.DeviceDoorGroupDeviceDoor;
/*
 * @auther tenit
 */
public interface IDeviceDoorGroup {
	DeviceDoorGroup insert(DeviceDoorGroup doorGroup);

	DeviceDoorGroup update(DeviceDoorGroup doorGroup);

	int delete(long doorGroupId);

	List<DeviceDoorGroup> getDeviceDoorGroup();

	DeviceDoorGroup getDeviceDoorGroupById(long doorGroupId);
	
	List<DeviceDoorGroupDeviceDoor> getListDeviceGroupDeviceByGroupId(
			long deviceDoorGroupId);
	
}
