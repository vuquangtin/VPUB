/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class UserFilterDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 8768701875686778690L;
	
	private boolean FilterByUserStatus ;
	private int UserStatus ;

	private boolean FilterByGroupId ;
	private long GroupId ;

	private int Start ;

	private int Count ;
	
	
//	public UserFilterDto(boolean FilterByUserStatus, int UserStatus,
//			boolean FilterByGroupId, long GroupId, int Start, int Count)
//	{
//		this.FilterByUserStatus = FilterByUserStatus;
//		this.UserStatus = UserStatus;
//		this.FilterByGroupId = FilterByGroupId;
//		this.GroupId = GroupId;
//		this.Start = Start;
//		this.Count = Count;
//	}
	
	public String clone()
	{
		String resultSearch = "";
		if(FilterByUserStatus)
			resultSearch += " Status = " + UserStatus;
		
		if(resultSearch == "")
		{
			if(FilterByGroupId)
				resultSearch += " GroupId = " + GroupId ;
		}
		else
		{
			if(FilterByGroupId)
				resultSearch += " AND GroupId = " + GroupId ;
		}
		
		//chua lam filter theo start va count
		return resultSearch;
	}

	/**
	 * @return the filterByUserStatus
	 */
	public boolean isFilterByUserStatus() {
		return FilterByUserStatus;
	}

	/**
	 * @param filterByUserStatus the filterByUserStatus to set
	 */
	public void setFilterByUserStatus(boolean filterByUserStatus) {
		FilterByUserStatus = filterByUserStatus;
	}

	/**
	 * @return the userStatus
	 */
	public int getUserStatus() {
		return UserStatus;
	}

	/**
	 * @param userStatus the userStatus to set
	 */
	public void setUserStatus(int userStatus) {
		UserStatus = userStatus;
	}

	/**
	 * @return the filterByGroupId
	 */
	public boolean isFilterByGroupId() {
		return FilterByGroupId;
	}

	/**
	 * @param filterByGroupId the filterByGroupId to set
	 */
	public void setFilterByGroupId(boolean filterByGroupId) {
		FilterByGroupId = filterByGroupId;
	}

	/**
	 * @return the groupId
	 */
	public long getGroupId() {
		return GroupId;
	}

	/**
	 * @param groupId the groupId to set
	 */
	public void setGroupId(long groupId) {
		GroupId = groupId;
	}

	/**
	 * @return the start
	 */
	public int getStart() {
		return Start;
	}

	/**
	 * @param start the start to set
	 */
	public void setStart(int start) {
		Start = start;
	}

	/**
	 * @return the count
	 */
	public int getCount() {
		return Count;
	}

	/**
	 * @param count the count to set
	 */
	public void setCount(int count) {
		Count = count;
	}

}
