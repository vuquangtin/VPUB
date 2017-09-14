package com.swt.saigonpearl.impls;

import java.util.List;

import com.swt.saigonpearl.IDeviceDoorGroup;
import com.swt.saigonpearl.domain.DeviceDoorGroup;

public class DeviceDoorGroupController {
	public static final DeviceDoorGroupController Instance = new DeviceDoorGroupController();
	IDeviceDoorGroup deviceDoorGroupDAO = new DeviceDoorGroupDAO();

	public DeviceDoorGroup insert(DeviceDoorGroup deviceDoorGroup) {
		return deviceDoorGroupDAO.insert(deviceDoorGroup);
	}

	public DeviceDoorGroup update(DeviceDoorGroup deviceDoorGroup) {
		return deviceDoorGroupDAO.update(deviceDoorGroup);
	}
	public int delete(long deviceDoorGroupId) {
		return deviceDoorGroupDAO.delete(deviceDoorGroupId);
	}
	public List<DeviceDoorGroup> getDeviceDoorGroup() {
		return deviceDoorGroupDAO.getDeviceDoorGroup();
	}

	public DeviceDoorGroup getDeviceDoorGroupById(long deviceDoorGroupId) {
		return deviceDoorGroupDAO.getDeviceDoorGroupById(deviceDoorGroupId);
	}
}
