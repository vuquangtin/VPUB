package com.swt.timekeeping.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * TimeKeepingGeneralConfig
 * 
 * @author minh.nguyen
 *
 */
@Entity
@Table(name = "swtgp_timekeeping_config")
public class GeneralConfig implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "generalconfigid", nullable = false)
	private long generalConfigId;

	@Column(name = "orgid", nullable = false)
	private long orgId;

	@Column(name = "gconfigjson", length = Integer.MAX_VALUE)
	private String generalConfigJson;

	public long getGeneralConfigId() {
		return generalConfigId;
	}

	public void setGeneralConfigId(long generalConfigId) {
		this.generalConfigId = generalConfigId;
	}

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

	public String getGeneralConfigJson() {
		return generalConfigJson;
	}

	public void setGeneralConfigJson(String generalConfigJson) {
		this.generalConfigJson = generalConfigJson;
	}
}
