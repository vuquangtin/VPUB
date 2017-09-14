package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.List;

import com.swt.meeting.domain.Meeting;

public class MeetingObjManager implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private List<Meeting> meetings;
	private long sum;

	public List<Meeting> getMeetings() {
		return meetings;
	}

	public void setMeetings(List<Meeting> meetings) {
		this.meetings = meetings;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
