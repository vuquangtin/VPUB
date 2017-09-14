/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class LoginHistoryFilterDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 7475031159039661877L;
	
	private boolean FilterByUserName ;
	private String UserName ;

	private boolean FilterByLoginTime ;
	private TimePeriodDto LoginTimePeriod ;

	private boolean FilterByLoginResult ;
	private boolean LoginSuccess ;

	private int Start ;

	private int Count ;

	private String Status ;
	
	public String clone()
	{
		String resultSearch = "";
		if(FilterByUserName)
			resultSearch += " UserName = '" + UserName + "'";
		
		if(resultSearch == "")
		{
			if(FilterByLoginTime)
				resultSearch += " LoginTime = " + LoginTimePeriod.getStart() + " AND LogoutTime = " + LoginTimePeriod.getEnd() ;
		}
		else
		{
			if(FilterByLoginTime)
				resultSearch += " AND LoginTime = " + LoginTimePeriod.getStart() + " AND LogoutTime = " + LoginTimePeriod.getEnd() ;
		}
		
		if(resultSearch == "")
		{
			if(FilterByLoginResult)
				resultSearch += " Result = " + LoginSuccess;
		}
		else
		{
			if(FilterByLoginResult)
				resultSearch += " AND Result = " + LoginSuccess;
		}
		
		//chua lam filter theo start va count va status
		return resultSearch;
	}

	/**
	 * @return the filterByUserName
	 */
	public boolean isFilterByUserName() {
		return FilterByUserName;
	}

	/**
	 * @param filterByUserName the filterByUserName to set
	 */
	public void setFilterByUserName(boolean filterByUserName) {
		FilterByUserName = filterByUserName;
	}

	/**
	 * @return the userName
	 */
	public String getUserName() {
		return UserName;
	}

	/**
	 * @param userName the userName to set
	 */
	public void setUserName(String userName) {
		UserName = userName;
	}

	/**
	 * @return the filterByLoginTime
	 */
	public boolean isFilterByLoginTime() {
		return FilterByLoginTime;
	}

	/**
	 * @param filterByLoginTime the filterByLoginTime to set
	 */
	public void setFilterByLoginTime(boolean filterByLoginTime) {
		FilterByLoginTime = filterByLoginTime;
	}

	/**
	 * @return the loginTimePeriod
	 */
	public TimePeriodDto getLoginTimePeriod() {
		return LoginTimePeriod;
	}

	/**
	 * @param loginTimePeriod the loginTimePeriod to set
	 */
	public void setLoginTimePeriod(TimePeriodDto loginTimePeriod) {
		LoginTimePeriod = loginTimePeriod;
	}

	/**
	 * @return the filterByLoginResult
	 */
	public boolean isFilterByLoginResult() {
		return FilterByLoginResult;
	}

	/**
	 * @param filterByLoginResult the filterByLoginResult to set
	 */
	public void setFilterByLoginResult(boolean filterByLoginResult) {
		FilterByLoginResult = filterByLoginResult;
	}

	/**
	 * @return the loginSuccess
	 */
	public boolean isLoginSuccess() {
		return LoginSuccess;
	}

	/**
	 * @param loginSuccess the loginSuccess to set
	 */
	public void setLoginSuccess(boolean loginSuccess) {
		LoginSuccess = loginSuccess;
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
