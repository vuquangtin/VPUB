/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class OrgFilterDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 7385972439842762845L;
	
	private boolean FilterByOrgName ;
	private String OrgName ;
	private boolean FilterByOrgCode ;
	private String OrgCode ;
	
	public String clone()
	{
		String resultSearch = "";
		if(FilterByOrgName)
			resultSearch += "  Name LIKE '%"+OrgName+"%'";
		
		if(FilterByOrgCode){
			resultSearch += "".equals(resultSearch)?"" : " AND ";
			resultSearch += "  OrgCode LIKE '%"+OrgCode+"%'";
		}
		return resultSearch;
	}
	
	/**
	 * @return the filterByOrgName
	 */
	public boolean isFilterByOrgName() {
		return FilterByOrgName;
	}
	/**
	 * @param filterByOrgName the filterByOrgName to set
	 */
	public void setFilterByOrgName(boolean filterByOrgName) {
		FilterByOrgName = filterByOrgName;
	}
	/**
	 * @return the orgName
	 */
	public String getOrgName() {
		return OrgName;
	}
	/**
	 * @param orgName the orgName to set
	 */
	public void setOrgName(String orgName) {
		OrgName = orgName;
	}
	/**
	 * @return the filterByOrgCode
	 */
	public boolean isFilterByOrgCode() {
		return FilterByOrgCode;
	}
	/**
	 * @param filterByOrgCode the filterByOrgCode to set
	 */
	public void setFilterByOrgCode(boolean filterByOrgCode) {
		FilterByOrgCode = filterByOrgCode;
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

}
