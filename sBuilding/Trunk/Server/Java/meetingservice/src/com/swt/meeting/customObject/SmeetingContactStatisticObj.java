package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.List;

import com.swt.meeting.domain.SmeetingContactCount;

public class SmeetingContactStatisticObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private List<SmeetingContactCount> contactStatistics;
	private long sum;

	public List<SmeetingContactCount> getContactStatistics() {
		return contactStatistics;
	}

	public void setContactStatistics(List<SmeetingContactCount> contactStatistics) {
		this.contactStatistics = contactStatistics;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
