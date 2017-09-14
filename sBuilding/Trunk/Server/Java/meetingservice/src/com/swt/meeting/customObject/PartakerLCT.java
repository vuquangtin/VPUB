package com.swt.meeting.customObject;

import java.io.Serializable;

public class PartakerLCT implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private long orgId;
	private String orgName;
	private String orgCode;

	private String partakerName;
	private String partakerPosition;
	private String email;
	private String key;
	private String barCode;

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

	public void setKey(String key) {
		this.key = key;
	}

	public String getKey() {
		return key;
	}

	public void setOrgCode(String orgCode) {
		this.orgCode = orgCode;
	}

	public String getOrgCode() {
		return orgCode;
	}

	public String getPartakerName() {
		return partakerName;
	}

	public void setPartakerName(String partakerName) {
		this.partakerName = partakerName;
	}

	public String getPartakerPosition() {
		return partakerPosition;
	}

	public void setPartakerPosition(String partakerPosition) {
		this.partakerPosition = partakerPosition;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getEmail() {
		return email;
	}

	public String getBarCode() {
		return barCode;
	}

	public void setBarCode(String barCode) {
		this.barCode = barCode;
	}
	
}
