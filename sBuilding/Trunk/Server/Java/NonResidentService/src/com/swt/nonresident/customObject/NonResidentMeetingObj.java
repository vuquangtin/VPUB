package com.swt.nonresident.customObject;

import java.io.Serializable;
import java.util.List;

import com.swt.nonresident.domain.NonResidentMeeting;

public class NonResidentMeetingObj implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private List<NonResidentMeeting> nonResidentMeetings;
	private long sum;

	public List<NonResidentMeeting> getNonResidentMeetings() {
		return nonResidentMeetings;
	}

	public void setNonResidentMeetings(List<NonResidentMeeting> nonResidentMeetings) {
		this.nonResidentMeetings = nonResidentMeetings;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
