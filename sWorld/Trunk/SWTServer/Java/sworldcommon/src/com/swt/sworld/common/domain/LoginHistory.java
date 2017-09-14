/**
 * 
 */
package com.swt.sworld.common.domain;

import java.io.Serializable;

import javax.persistence.*;

/**
 * @author sangdb
 *
 */

@Entity
@Table(name = "swtgp_login_history")

public class LoginHistory implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 2767521520338446493L;

	@Id @GeneratedValue
	@Column(name = "Id")
	private long Id;
	
	@Column(name = "UserName", length=45, nullable = false)
	private String UserName;
	
	@Column(name = "LoginTime", length=45, nullable = false)
	private String LoginTime;
	
	@Column(name = "LogoutTime", length=45)
	private String LogoutTime;
	
	@Column(name = "Result", nullable = false)
	private Boolean Result;
	
	@Column(name = "FailedCode", nullable = false)
	private int FailedCode;

	/**
	 * @return the id
	 */
	public long getId() {
		return Id;
	}

	/**
	 * @param id the id to set
	 */
	public void setId(long id) {
		Id = id;
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
	 * @return the loginTime
	 */
	public String getLoginTime() {
		return LoginTime;
	}

	/**
	 * @param loginTime the loginTime to set
	 */
	public void setLoginTime(String loginTime) {
		LoginTime = loginTime;
	}

	/**
	 * @return the logoutTime
	 */
	public String getLogoutTime() {
		return LogoutTime;
	}

	/**
	 * @param logoutTime the logoutTime to set
	 */
	public void setLogoutTime(String logoutTime) {
		LogoutTime = logoutTime;
	}

	/**
	 * @return the result
	 */
	public Boolean isResult() {
		return Result;
	}

	/**
	 * @param result the result to set
	 */
	public void setResult(Boolean result) {
		Result = result;
	}

	/**
	 * @return the failedCode
	 */
	public int getFailedCode() {
		return FailedCode;
	}

	/**
	 * @param failedCode the failedCode to set
	 */
	public void setFailedCode(int failedCode) {
		FailedCode = failedCode;
	}
}



	