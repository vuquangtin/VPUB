package com.swt.timekeeping;

import java.util.List;

import com.swt.timekeeping.domain.ColorConfig;

/**
 * Interface TimeKeepingColorConfig
 * 
 * @author minh.nguyen
 *
 */
public interface ITimeKeepingColorConfig {
	
	/**
	 * Method insert color
	 * @param ColorConfig
	 * @return ColorConfig
	 */
	public ColorConfig insertColorConfig(ColorConfig cConfig);

	/**
	 * Method update color
	 * 
	 * @param ColorConfig
	 * @return ColorConfig
	 */
	public ColorConfig updateColorConfig(ColorConfig cConfig);

	/**
	 * Method get color by id
	 * 
	 * @param long
	 *            colorConfigId
	 * @return ColorConfig
	 */
	public ColorConfig getColorConfigById(long colorConfigId);

	/**
	 * Method get list color
	 * @return List<ColorConfig>
	 */
	public List<ColorConfig> getColorConfigList();

	/**
	 * Method get list color by org's id
	 * 
	 * @param long
	 *            orgId
	 * @return List<ColorConfig>
	 */
	public List<ColorConfig> getColorConfigListByOrgId(long orgId);
}
