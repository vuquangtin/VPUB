package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.List;

public class JournalistAttendStatisticDetailObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private List<JournalistAttendStatisticDetail> attendStatisticDetails;
	private long sum;

	public List<JournalistAttendStatisticDetail> getAttendStatisticDetails() {
		return attendStatisticDetails;
	}

	public void setAttendStatisticDetails(List<JournalistAttendStatisticDetail> attendStatisticDetails) {
		this.attendStatisticDetails = attendStatisticDetails;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
