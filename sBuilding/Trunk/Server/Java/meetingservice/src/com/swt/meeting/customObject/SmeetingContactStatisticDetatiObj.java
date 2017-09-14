package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.List;

import com.swt.meeting.domain.SmeetingContactStatistic;

public class SmeetingContactStatisticDetatiObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private List<SmeetingContactStatistic> contactStatisticDetails;
	private long sum;

	public void setContactStatisticDetails(List<SmeetingContactStatistic> contactStatisticDetails) {
		this.contactStatisticDetails = contactStatisticDetails;
	}

	public List<SmeetingContactStatistic> getContactStatisticDetails() {
		return contactStatisticDetails;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
