package com.swt.saigonpearl;

import java.util.List;

import com.swt.saigonpearl.domain.PersonalizationDevice;

public interface IPersonalizationDevice {
	PersonalizationDevice insert(PersonalizationDevice personalizationDevice);

	PersonalizationDevice update(PersonalizationDevice personalizationDevice);

	int delete(long personalizationDeviceId);

	List<PersonalizationDevice> getPersonalizationDevices();

	PersonalizationDevice getPersonalizationDeviceById(long personalizationDeviceId);
	List<PersonalizationDevice> getListPersonalizationDevices(String ip,String serialNumber);
	
}
