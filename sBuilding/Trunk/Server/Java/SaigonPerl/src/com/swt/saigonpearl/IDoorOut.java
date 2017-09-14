package com.swt.saigonpearl;

import java.util.List;

import com.swt.saigonpearl.domain.DoorOut;
import com.swt.saigonpearl.domain.DoorOutFilterDto;

public interface IDoorOut {

	DoorOut insert(DoorOut doorOut);

	DoorOut update(DoorOut doorOut);

	int delete(long doorOutId);

	List<DoorOut> getDoorOutByFilter(DoorOutFilterDto dto);

	DoorOut getDoorOutBySerialNumber(String serialNumber, long deviceId,
			int status);

	DoorOut getDoorOutById(long doorOutId);

}
