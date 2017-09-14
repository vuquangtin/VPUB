package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

public class MoveMemberSubOrg implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private long memberID;
	private boolean isLeft;
	
	
	public MoveMemberSubOrg(long memberID, boolean isLeft) {
		this.memberID = memberID;
		this.isLeft = isLeft;
	}

	public long getMemberID() {
		return memberID;
	}
	
	public void setMemberID(long memberID) {
		this.memberID = memberID;
	}
	
	public boolean isLeft() {
		return isLeft;
	}
	
	public void setLeft(boolean isLeft) {
		this.isLeft = isLeft;
	}
}
