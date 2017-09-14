package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

public class TotalMemberDTO implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	 
	private long totalMember = 0;

	public TotalMemberDTO(long totalMember) {
		super();
		this.totalMember = totalMember;
	}

	public long getTotalMember() {
		return totalMember;
	}

	public void setTotalMember(long totalMember) {
		this.totalMember = totalMember;
	}

}
