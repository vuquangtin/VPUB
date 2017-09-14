package com.swt.timekeeping.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * TimeKeepingColorConfig
 * 
 * @author minh.nguyen
 *
 */
@Entity
@Table(name = "swtgp_timekeeping_color_config")
public class ColorConfig implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "colorconfigid", nullable = false)
	private long colorConfigId;

	@Column(name = "colorconfignameid", nullable = false)
	private long colorConfigNameId;

	@Column(name = "colorid", nullable = false)
	private long colorId;

	@Column(name = "orgid", nullable = false)
	private long orgId;

	public long getColorConfigId() {
		return colorConfigId;
	}

	public void setColorConfigId(long colorConfigId) {
		this.colorConfigId = colorConfigId;
	}

	public long getColorConfigNameId() {
		return colorConfigNameId;
	}

	public void setColorConfigNameId(long colorConfigNameId) {
		this.colorConfigNameId = colorConfigNameId;
	}

	public long getColorId() {
		return colorId;
	}

	public void setColorId(long colorId) {
		this.colorId = colorId;
	}

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}
}
