package com.swt.saigonpearl;

import com.swt.saigonpearl.domain.DoorIn;

public interface IDoorIn {

	DoorIn insert(DoorIn doorIn);

	DoorIn update(DoorIn doorIn);

	int delete(long doorInId);

	DoorIn getDoorInBySerialNumber(String serialNumber, long deviceId);
}
