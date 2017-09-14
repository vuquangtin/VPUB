package com.swt.timekeeping;

import java.util.List;

import com.swt.timekeeping.domain.DeviceConfig;

/**
 * ITimeKeepingDeviceConfig interface
 * 
 * @author TrangPig
 *
 */
public interface ITimeKeepingDeviceConfig {
	/**
	 * insert TimeKeepingDeviceConfig
	 * 
	 * @param timeKeepingConfig
	 * @return
	 */
	public DeviceConfig insert(DeviceConfig timeKeepingConfig);

	/**
	 * update TimeKeepingDeviceConfig
	 * 
	 * @param timeKeepingConfig
	 * @return
	 */
	public DeviceConfig update(DeviceConfig timeKeepingConfig);

	/**
	 * delete TimeKeepingDeviceConfig
	 * 
	 * @param timeKeepingConfigId
	 * @return
	 */
	public int delete(long timeKeepingConfigId);
	
	DeviceConfig getDeviceConfigById(long idDeviceConfig);

	/**
	 * getTimeKeepingConfigById
	 * 
	 * @param timeKeepingConfigId
	 * @return
	 */
	public DeviceConfig getTimeKeepingConfigById(long timeKeepingConfigId);
	
	public List<DeviceConfig> getTimeKeepingConfigByIp(String timeKeepingConfigIp);
	
	public List<DeviceConfig> getListDeviceConfigByOrgId(long orgId);

}
