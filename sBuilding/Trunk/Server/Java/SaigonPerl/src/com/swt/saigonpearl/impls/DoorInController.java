package com.swt.saigonpearl.impls;


import com.swt.saigonpearl.IDoorIn;
import com.swt.saigonpearl.domain.DoorIn;

public class DoorInController {
	public static final DoorInController Instance = new DoorInController();
	IDoorIn doorInDAO = new DoorInDAO();
	
	public DoorIn insert(DoorIn doorIn) {
		return doorInDAO.insert(doorIn);
	}

	public DoorIn update(DoorIn doorIn) {
		return doorInDAO.update(doorIn);
	}

	public int delete(long doorInId) {
		return doorInDAO.delete(doorInId);
	}
	
	public DoorIn getDoorInBySerialNumber(String serialNumber, long deviceId) 
	{
		return doorInDAO.getDoorInBySerialNumber(serialNumber,deviceId);
	}
	
}
