package com.swt.device.impls;


import java.util.List;

import com.swt.device.IDeviceDoor;
import com.swt.sworld.device.domain.DeviceDoor;

/**
 * @author Tenit
 *
 */
public class DeviceDoorController {
	
	public static final DeviceDoorController Instance = new DeviceDoorController();
	IDeviceDoor deviceDoorDAO = new DeviceDoorDAO();
	
	public DeviceDoor insert(DeviceDoor deviceDoor) {
		return deviceDoorDAO.insert(deviceDoor);
	}

	public DeviceDoor update(DeviceDoor deviceDoor) {
		return deviceDoorDAO.update(deviceDoor);
	}

	public int delete(long deviceDoorId) {
		return deviceDoorDAO.delete(deviceDoorId);
	}
	
	public List<DeviceDoor> getDeviceDoorList(long orgID,long subOrgID) 
	{
		return getDeviceDoorListBySubID(orgID,subOrgID);
	}
	
	public List<DeviceDoor> getDeviceDoorList() 
	{
		return deviceDoorDAO.getDeviceDoorList();
	}
	
	public DeviceDoor getDeviceDoorId(long deviceDoorId) 
	{
		return deviceDoorDAO.getDeviceDoorId(deviceDoorId);
	}
	
	public DeviceDoor getDeviceDoorByIp(String ip) 
	{
		return deviceDoorDAO.getDeviceDoorByIp(ip);
	}
	public List<DeviceDoor> getDeviceDoorListBySubID(long orgid, long suborgid)
	{
		List<DeviceDoor> lstDevice = null;
		if(orgid < 0)
		{
			lstDevice = deviceDoorDAO.getByOrgIdDevice(suborgid);
		}
		if(orgid > 0)
		{
			lstDevice = deviceDoorDAO.getDeviceOrgAndSubDevice(orgid, suborgid);
		}
		return lstDevice;
	}
	
	
}
