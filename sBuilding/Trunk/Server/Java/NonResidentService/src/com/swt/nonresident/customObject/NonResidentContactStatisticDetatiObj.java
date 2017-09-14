package com.swt.nonresident.customObject;

import java.io.Serializable;
import java.util.List;

import com.swt.nonresident.domain.NonResidentContactStatistic;

public class NonResidentContactStatisticDetatiObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private List<NonResidentContactStatistic> contactStatisticDetails;
	private long sum;

	public List<NonResidentContactStatistic> getContactStatisticDetails() {
		return contactStatisticDetails;
	}

	public void setContactStatisticDetails(List<NonResidentContactStatistic> contactStatisticDetails) {
		this.contactStatisticDetails = contactStatisticDetails;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
