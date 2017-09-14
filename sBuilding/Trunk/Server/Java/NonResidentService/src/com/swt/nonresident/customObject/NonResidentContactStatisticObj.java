package com.swt.nonresident.customObject;

import java.io.Serializable;
import java.util.List;

import com.swt.nonresident.domain.NonResidentContactCount;

public class NonResidentContactStatisticObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private List<NonResidentContactCount> contactStatistics;
	private long sum;

	public List<NonResidentContactCount> getContactStatistics() {
		return contactStatistics;
	}

	public void setContactStatistics(List<NonResidentContactCount> contactStatistics) {
		this.contactStatistics = contactStatistics;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
