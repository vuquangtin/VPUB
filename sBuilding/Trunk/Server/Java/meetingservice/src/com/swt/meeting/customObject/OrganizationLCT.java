package com.swt.meeting.customObject;

import java.io.Serializable;

public class OrganizationLCT implements Serializable{
	
	/***
	 * @author my.nguyen
	 */

	private static final long serialVersionUID = 1L;
	private long id;
	private String name;
	private String code;

	public long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
	}

	
}
