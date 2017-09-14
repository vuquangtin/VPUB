/**
 * 
 */
package com.swt.sworld.communication.customer.object;

public class SubOrgCustomerDto {

	private long SubOrgId ;
	private long OrgId ;
	private long parentOrgId;
	private String OrgCode ;
	private String OrgShortName ;
	private String Name ;
	private String SwtGroup ;
	
//	public SubOrgCustomerDto(long suborgid, long orgid, String code, String shortname, String name)
//	{
//		this.SubOrgId = suborgid;
//		this.OrgId = orgid;
//		this.OrgCode = code;
//		this.OrgShortName = shortname;
//		this.Name =  name;
//		
//	}
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

	public long getParentOrgId() {
		return parentOrgId;
	}

	public void setParentOrgId(long parentOrgId) {
		this.parentOrgId = parentOrgId;
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
	 * @return the swtGroup
	 */
	public String getSwtGroup() {
		return SwtGroup;
	}

	/**
	 * @param swtGroup the swtGroup to set
	 */
	public void setSwtGroup(String swtGroup) {
		SwtGroup = swtGroup;
	}

}
