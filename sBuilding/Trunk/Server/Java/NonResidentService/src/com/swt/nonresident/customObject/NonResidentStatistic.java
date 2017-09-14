package com.swt.nonresident.customObject;

import java.io.Serializable;

/**
 * NonResidentStatistic class
 * 
 * @author TaiMai
 *
 */
public class NonResidentStatistic implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private long orgId;
	private String orgName;
	private long number;

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

	public String getOrgName() {
		return orgName;
	}

	public void setOrgName(String orgName) {
		this.orgName = orgName;
	}

	public Long getNumber() {
		return number;
	}

	public void setNumber(Long number) {
		this.number = number;
	}

}
