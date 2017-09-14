package com.swt.saigonpearl;

import java.util.List;

import com.swt.saigonpearl.domain.ConfigApartment;

/**
 * @author Cong thanh
 *
 */
public interface ISaiGonpearlConfigApartment {
	
	ConfigApartment insertApartment(ConfigApartment configapartment);
	
	ConfigApartment updateConfigApartment(ConfigApartment configapartment);
	int deleteConfigApartment(long configId);
	List<ConfigApartment> getAllConfigApartment();
	
	ConfigApartment getConfigByConfigId(long configId);
	
}
