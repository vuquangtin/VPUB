package com.sworld.common;

import java.io.Serializable;

public class ResultObject implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = -7285677562428617585L;
	private Status status;
	private Object obj;
	private String token;
	public ResultObject(){
		
	}
	public ResultObject(Status status)
	{
		this.status =status;
	}
	public ResultObject(Status status, String token)
	{
		this.status =status;
		this.token = token;
	}
	
	public ResultObject(String token)
	{
		this.token = token;
	}
	public ResultObject(Status status, Object obj)
	{
		this.status = status;
		this.obj = obj;
	}
	
	public Object getObj() {
		return obj;
	}
	public void setObj(Object obj) {
		this.obj = obj;
	}
	public Status getStatus() {
		return status;
	}
	public void setStatus(Status status) {
		this.status = status;
	}
	public String getToken() {
		return token;
	}
	public void setToken(String token) {
		this.token = token;
	}
	

}
