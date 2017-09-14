/**
 * 
 */
package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.List;

public class JournalistAttendStatisticObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	private List<JournalistAttendStatistic> journalistAttendStatistics;
	private long sum;

	public List<JournalistAttendStatistic> getJournalistAttendStatistics() {
		return journalistAttendStatistics;
	}

	public void setJournalistAttendStatistics(List<JournalistAttendStatistic> journalistAttendStatistics) {
		this.journalistAttendStatistics = journalistAttendStatistics;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
