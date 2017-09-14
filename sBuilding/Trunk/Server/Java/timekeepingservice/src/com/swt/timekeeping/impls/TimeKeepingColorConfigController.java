package com.swt.timekeeping.impls;

import java.util.List;

import com.swt.timekeeping.domain.ColorConfig;

/**
 * TimeKeeping Color Config Controller
 * 
 * @author minh.nguyen
 *
 */
public class TimeKeepingColorConfigController {
	/**
	 * Instance of TimeKeepingColorConfigController
	 */
	public static final TimeKeepingColorConfigController Instance = new TimeKeepingColorConfigController();
	private TimeKeepingColorConfigDAO tccDAO = new TimeKeepingColorConfigDAO();

	/**
	 * Method insert color
	 * @param ColorConfig
	 * @return ColorConfig
	 */
	public ColorConfig insertColorConfig(ColorConfig cConfig) {
		return tccDAO.insertColorConfig(cConfig);
	}

	/**
	 * Method update color
	 * 
	 * @param ColorConfig
	 * @return ColorConfig
	 */
	public ColorConfig updateColorConfig(ColorConfig cConfig) {
		return tccDAO.updateColorConfig(cConfig);
	}

	/**
	 * Method get color by id
	 * 
	 * @param long
	 *            colorConfigId
	 * @return ColorConfig
	 */
	public ColorConfig getColorConfigById(long colorConfigId) {
		return tccDAO.getColorConfigById(colorConfigId);
	}

	/**
	 * Method get list color
	 * @return List<ColorConfig>
	 */
	public List<ColorConfig> getColorConfigList() {
		return tccDAO.getColorConfigList();
	}

	/**
	 * Method get list color by org's id
	 * 
	 * @param long
	 *            orgId
	 * @return List<ColorConfig>
	 */
	public List<ColorConfig> getColorConfigListByOrgId(long orgId) {
		return tccDAO.getColorConfigListByOrgId(orgId);
	}
}
