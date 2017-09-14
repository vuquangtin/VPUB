package com.swt.sworld.communication.customer.object;

import java.io.Serializable;
public class MemberFilter implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -2228959532755707559L;
	private boolean FilterByMemberName ;
	private String MemberName ;
	private boolean FilterByCode ;
	private String Code ;
	private boolean FilterByActive ;
	private boolean Active ;
	private String Status ;
	
	public String clone()
	{
		String resultSearch = "";
		if(FilterByMemberName)
			resultSearch += " AND LowerFullName LIKE '%"+MemberName+"%'";
		if(FilterByCode)
			resultSearch += " AND Code LIKE '%"+Code+"%'" ;
		if(FilterByActive)
			resultSearch += " AND Active = " + Active;
		return resultSearch;
	}
	
	public String cloneChip()
	{
		String resultSearch = "";
		if(Status != "")
			resultSearch += " AND Status = " + Status;
		return resultSearch;
	}
	
	/**
	 * @return the filterByMemberName
	 */
	public boolean isFilterByMemberName() {
		return FilterByMemberName;
	}
	/**
	 * @param filterByMemberName the filterByMemberName to set
	 */
	public void setFilterByMemberName(boolean filterByMemberName) {
		FilterByMemberName = filterByMemberName;
	}
	/**
	 * @return the memberName
	 */
	public String getMemberName() {
		return MemberName;
	}
	/**
	 * @param memberName the memberName to set
	 */
	public void setMemberName(String memberName) {
		MemberName = memberName;
	}
	/**
	 * @return the filterByCode
	 */
	public boolean isFilterByCode() {
		return FilterByCode;
	}
	/**
	 * @param filterByCode the filterByCode to set
	 */
	public void setFilterByCode(boolean filterByCode) {
		FilterByCode = filterByCode;
	}
	/**
	 * @return the code
	 */
	public String getCode() {
		return Code;
	}
	/**
	 * @param code the code to set
	 */
	public void setCode(String code) {
		Code = code;
	}
	/**
	 * @return the filterByActive
	 */
	public boolean isFilterByActive() {
		return FilterByActive;
	}
	/**
	 * @param filterByActive the filterByActive to set
	 */
	public void setFilterByActive(boolean filterByActive) {
		FilterByActive = filterByActive;
	}
	/**
	 * @return the active
	 */
	public boolean isActive() {
		return Active;
	}
	/**
	 * @param active the active to set
	 */
	public void setActive(boolean active) {
		Active = active;
	}
	/**
	 * @return the status
	 */
	public String getStatus() {
		return Status;
	}
	/**
	 * @param status the status to set
	 */
	public void setStatus(String status) {
		Status = status;
	}
	
}
