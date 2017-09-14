package com.swt.nonresident.customObject;

import java.io.Serializable;
import java.util.List;

public class NonResidentStatisticObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private List<NonResidentStatistic> nonResidentStatistics;
	private long sum;

	public List<NonResidentStatistic> getNonResidentStatistics() {
		return nonResidentStatistics;
	}

	public void setNonResidentStatistics(List<NonResidentStatistic> nonResidentStatistics) {
		this.nonResidentStatistics = nonResidentStatistics;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
