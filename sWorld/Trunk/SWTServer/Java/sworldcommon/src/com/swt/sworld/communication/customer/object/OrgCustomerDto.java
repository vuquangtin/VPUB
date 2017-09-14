/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;
import java.util.List;

/**
 * @author Administrator
 *
 */
public class OrgCustomerDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1009519637241129472L;
	
	private long OrgId ;
	private String OrgCode ;
	private String OrgShortName ;
	private String Name ;
	private String Issuer ;
	private List<SubOrgCustomerDto> SubOrgList ;
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
	 * @return the orgCode
	 */
	public String getOrgCode() {
		return OrgCode;
	}
	/**
	 * @param orgCode the orgCode to set
	 */
	public void setOrgCode(String orgCode) {
		OrgCode = orgCode;
	}
	/**
	 * @return the orgShortName
	 */
	public String getOrgShortName() {
		return OrgShortName;
	}
	/**
	 * @param orgShortName the orgShortName to set
	 */
	public void setOrgShortName(String orgShortName) {
		OrgShortName = orgShortName;
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
	 * @return the subOrgList
	 */
	public List<SubOrgCustomerDto> getSubOrgList() {
		return SubOrgList;
	}
	/**
	 * @param subOrgList the subOrgList to set
	 */
	public void setSubOrgList(List<SubOrgCustomerDto> subOrgList) {
		SubOrgList = subOrgList;
	}
	/**
	 * @return the issuer
	 */
	public String getIssuer() {
		return Issuer;
	}
	/**
	 * @param issuer the issuer to set
	 */
	public void setIssuer(String issuer) {
		Issuer = issuer;
	}

}
