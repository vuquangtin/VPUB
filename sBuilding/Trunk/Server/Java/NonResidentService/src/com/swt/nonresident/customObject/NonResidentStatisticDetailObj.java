package com.swt.nonresident.customObject;

import java.io.Serializable;
import java.util.List;

public class NonResidentStatisticDetailObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private List<NonResidentObj> nonResidentObjs;
	private long sum;

	public List<NonResidentObj> getNonResidentObjs() {
		return nonResidentObjs;
	}

	public void setNonResidentObjs(List<NonResidentObj> nonResidentObjs) {
		this.nonResidentObjs = nonResidentObjs;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
