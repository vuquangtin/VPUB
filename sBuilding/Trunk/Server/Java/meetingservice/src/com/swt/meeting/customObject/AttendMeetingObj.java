package com.swt.meeting.customObject;

import java.util.List;

import com.swt.meeting.domain.AttendMeeting;
import com.swt.meeting.domain.Partaker;
 
public class AttendMeetingObj {
	private AttendMeeting attendMeeting;
	private List<Partaker> partakers;

	public AttendMeeting getAttendMeeting() {
		return attendMeeting;
	}

	public void setAttendMeeting(AttendMeeting attendMeeting) {
		this.attendMeeting = attendMeeting;
	}

	public List<Partaker> getPartakers() {
		return partakers;
	}

	public void setPartakers(List<Partaker> partakers) {
		this.partakers = partakers;
	}

}
