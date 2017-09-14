package com.swt.saigonpearl.impls;

import java.util.List;

import com.swt.saigonpearl.IDoorOut;
import com.swt.saigonpearl.domain.DoorOut;
import com.swt.saigonpearl.domain.DoorOutFilterDto;

public class DoorOutController {
	public static final DoorOutController Instance = new DoorOutController();
	IDoorOut doorOutDAO = new DoorOutDAO();
	
	public DoorOut insert(DoorOut doorOut) {
		return doorOutDAO.insert(doorOut);
	}

	public DoorOut update(DoorOut doorOut) {
		return doorOutDAO.update(doorOut);
	}

	public int delete(long doorOutId) {
		return doorOutDAO.delete(doorOutId);
	}
	
	public DoorOut getDoorOutById(long doorOutId) 
	{
		return doorOutDAO.getDoorOutById(doorOutId);
	}
	
	public DoorOut getDoorOutBySerialNumber(String serialNumber,long deviceId, int status) 
	{
		return doorOutDAO.getDoorOutBySerialNumber(serialNumber,deviceId,status);
	}
	
	public List<DoorOut> getDoorOutByFilter(DoorOutFilterDto dto)
	{
		return doorOutDAO.getDoorOutByFilter(dto);
	}
}
