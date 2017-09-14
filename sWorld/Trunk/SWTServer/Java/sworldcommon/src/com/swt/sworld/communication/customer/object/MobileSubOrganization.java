/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class MobileSubOrganization implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 3329824787881967255L;
	
	private long SubOrgId;
	private long OrgId;
	private String SubOrgShortName;
	private String Name;
	private String Phone;
	private String Email;
	/**
	 * @return the subOrgId
	 */
	public long getSubOrgId() {
		return SubOrgId;
	}
	/**
	 * @param subOrgId the subOrgId to set
	 */
	public void setSubOrgId(long subOrgId) {
		SubOrgId = subOrgId;
	}
	/**
	 * @return the orgId
	 */
	public long getOrgId() {
		return OrgId;
	}
	/**
	 * @param orgId the orgId to set
	 */
	public void setOrgId(long orgId) {
		OrgId = orgId;
	}
	/**
	 * @return the subOrgShortName
	 */
	public String getSubOrgShortName() {
		return SubOrgShortName;
	}
	/**
	 * @param subOrgShortName the subOrgShortName to set
	 */
	public void setSubOrgShortName(String subOrgShortName) {
		SubOrgShortName = subOrgShortName;
	}
	/**
	 * @return the name
	 */
	public String getName() {
		return Name;
	}
	/**
	 * @param name the name to set
	 */
	public void setName(String name) {
		Name = name;
	}
	/**
	 * @return the phone
	 */
	public String getPhone() {
		return Phone;
	}
	/**
	 * @param phone the phone to set
	 */
	public void setPhone(String phone) {
		Phone = phone;
	}
	/**
	 * @return the email
	 */
	public String getEmail() {
		return Email;
	}
	/**
	 * @param email the email to set
	 */
	public void setEmail(String email) {
		Email = email;
	}
	
}
