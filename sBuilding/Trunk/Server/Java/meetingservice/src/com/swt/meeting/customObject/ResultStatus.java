package com.swt.meeting.customObject;

import java.io.Serializable;
import com.sworld.common.Status;

public class ResultStatus implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private Status status;
	public ResultStatus(Status status){
		this.status = status;
	}
	public Status getStatus() {
		return status;
	}
	public void setStatus(Status status) {
		this.status = status;
	}
	

}
