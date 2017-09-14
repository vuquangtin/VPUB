package com.swt.timekeeping.impls;

import com.swt.timekeeping.customer.object.GeneralConfigJson;
import com.swt.timekeeping.domain.GeneralConfig;

/**
 * TimeKeeping General Config Controller
 * 
 * @author minh.nguyen
 *
 */
public class TimeKeepingGeneralConfigController {
	/**
	 * Instance of TimeKeepingGeneralConfigController
	 */
	public static final TimeKeepingGeneralConfigController Instance = new TimeKeepingGeneralConfigController();
	private TimeKeepingGeneralConfigDAO tgcDAO = new TimeKeepingGeneralConfigDAO();

	/**
	 * Method insert general config
	 * @param GeneralConfig
	 * @return GeneralConfig
	 */
	public GeneralConfig insertGeneralConfig(GeneralConfig gConfig) {
		return tgcDAO.insertGeneralConfig(gConfig);
	}

	/**
	 * Method update general config
	 * 
	 * @param GeneralConfig
	 * @return GeneralConfig
	 */
	public GeneralConfig updateGeneralConfig(GeneralConfig gConfig) {
		return tgcDAO.updateGeneralConfig(gConfig);
	}

	/**
	 * Method get general config by org's id
	 * 
	 * @param long
	 *            orgId
	 * @return GeneralConfig
	 */
	public GeneralConfig getGeneralConfigByOrgId(long orgId) {
		return tgcDAO.getGeneralConfigByOrgId(orgId);
	}
	
	/**
	 * Method get time of general config by org's id
	 * @param long orgId
	 * @return GeneralConfigJson
	 */
	public GeneralConfigJson getTimeGeneralConfigByOrgId(long orgId) {
		return tgcDAO.getTimeGeneralConfigByOrgId(orgId);
	}
}
