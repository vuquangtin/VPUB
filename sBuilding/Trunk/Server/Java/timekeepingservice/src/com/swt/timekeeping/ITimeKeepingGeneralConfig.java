package com.swt.timekeeping;

import com.swt.timekeeping.customer.object.GeneralConfigJson;
import com.swt.timekeeping.domain.GeneralConfig;

/**
 * Interface TimeKeepingGeneralConfig
 * 
 * @author minh.nguyen
 *
 */
public interface ITimeKeepingGeneralConfig {
	
	/**
	 * Method insert general config
	 * @param GeneralConfig
	 * @return GeneralConfig
	 */
	public GeneralConfig insertGeneralConfig(GeneralConfig gConfig);

	/**
	 * Method update general config
	 * 
	 * @param GeneralConfig
	 * @return GeneralConfig
	 */
	public GeneralConfig updateGeneralConfig(GeneralConfig gConfig);

	/**
	 * Method get general config by org's id
	 * 
	 * @param long
	 *            orgId
	 * @return GeneralConfig
	 */
	public GeneralConfig getGeneralConfigByOrgId(long orgId);

	/**
	 * Method get time of general config by org's id
	 * @param long orgId
	 * @return GeneralConfigJson
	 */
	public GeneralConfigJson getTimeGeneralConfigByOrgId(long orgId);
}
