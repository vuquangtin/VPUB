package com.swt.saigonpearl.impls;

import java.util.List;

import com.swt.saigonpearl.IPersonalizationDevice;
import com.swt.saigonpearl.domain.PersonalizationDevice;
;

public class PersonalizationDeviceController {
	
	public static final PersonalizationDeviceController Instance = new PersonalizationDeviceController();
	IPersonalizationDevice personalizationDeviceDAO = new PersonalizationDeviceDAO();
	
	public PersonalizationDevice insert(PersonalizationDevice personalizationDevice) {
		return personalizationDeviceDAO.insert(personalizationDevice);
	}

	public PersonalizationDevice update(PersonalizationDevice personalizationDevice) {
		return personalizationDeviceDAO.update(personalizationDevice);
	}

	public int delete(long roleId) {
		return personalizationDeviceDAO.delete(roleId);
	}
	
	public List<PersonalizationDevice> getPersonalizationDevices() 
	{
		return personalizationDeviceDAO.getPersonalizationDevices();
	}
	
	public PersonalizationDevice getPersonalizationDeviceById(long personalizationDeviceId) 
	{
		return personalizationDeviceDAO.getPersonalizationDeviceById(personalizationDeviceId);
	}
}
