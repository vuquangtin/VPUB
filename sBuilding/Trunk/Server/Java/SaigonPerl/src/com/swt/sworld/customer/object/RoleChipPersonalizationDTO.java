/**
 * 
 */
package com.swt.sworld.customer.object;

import java.io.Serializable;


/**
 * @author Administrator
 *
 */
public class RoleChipPersonalizationDTO implements Serializable{

	private static final long serialVersionUID = 1L;
	/**
	 * 
	 */
	
	private long memberId;
	private String serialNumber;
	
	public String getSerialNumber() {
		return serialNumber;
	}
	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
	}
	
	public long getMemberId() {
		return memberId;
	}
	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}
	
}
