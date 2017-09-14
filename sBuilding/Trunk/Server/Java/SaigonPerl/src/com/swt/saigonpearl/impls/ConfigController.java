package com.swt.saigonpearl.impls;

import java.util.List;

import com.nhn.utilities.HibernateUtil;
import com.swt.saigonpearl.domain.ConfigApartment;




public class ConfigController {

	public static final ConfigController Instance = new ConfigController();
	
	private ConfigApartmentDAO configaprtmentDAO= new ConfigApartmentDAO();
	
	private ConfigController()
	{
		
	}
	
	public ConfigApartment insertConfigApartment(ConfigApartment config)
	{
		return configaprtmentDAO.insertApartment(config);
	}
	
	public ConfigApartment updateConfigCard(ConfigApartment config)
	{
		return configaprtmentDAO.updateConfigApartment(config);
	}
	public ConfigApartment getConfigByConfigId(long configId)
	{
		return configaprtmentDAO.getConfigByConfigId(configId);
	}
	
	public int deleteConfigApartment(long configId)
	{
		//return itemDAO.deleteItem(ItemId);
		//return ecashGroupDAO.deleteGroupItem(groupItemId);		
		ConfigApartment config = getConfigByConfigId(configId);
		config.setStatus(10);		
		return HibernateUtil.update(config);	
	}
	public List<ConfigApartment> getAllConfigApartment()
	{
		return configaprtmentDAO.getAllConfigApartment();
	}
	
	
}
