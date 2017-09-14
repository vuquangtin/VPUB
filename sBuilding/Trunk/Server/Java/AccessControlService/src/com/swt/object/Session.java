package com.swt.object;

import java.io.Serializable;
import java.util.Date;

public class Session implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = -4438911533642453314L;

	private long id;
	private long groupid;
	private String username;
	private String token;
	private String datelogin;
	private  boolean IsRoot;

	public Session() {

	}

	public Session(long id, long grid, String user, boolean IsRoot){
		this.id = id;
		this.groupid = grid;
		this.setUsername(user);
		this.token = null;
		this.datelogin = new Date().toString();
		this.setIsRoot(IsRoot);
	}

	

	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}

	public String getDatelogin() {
		return datelogin;
	}

	public void setDatelogin(String datelogin) {
		this.datelogin = datelogin;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getGroupid() {
		return groupid;
	}

	public void setGroupid(long groupid) {
		this.groupid = groupid;
	}

	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	/**
	 * @return the isRoot
	 */
	public boolean isIsRoot() {
		return IsRoot;
	}

	/**
	 * @param isRoot the isRoot to set
	 */
	public void setIsRoot(boolean isRoot) {
		IsRoot = isRoot;
	}

}
