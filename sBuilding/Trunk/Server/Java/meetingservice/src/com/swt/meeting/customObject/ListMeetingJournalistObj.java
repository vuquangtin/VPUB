package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.List;

import com.swt.meeting.domain.AttendMeetingJournalist;
import com.swt.meeting.domain.Meeting;
import com.swt.sworld.ps.domain.Member;

public class ListMeetingJournalistObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private AttendMeetingJournalist attendMeetingJournalist;// thÃ´ng tin ngÃ y
															// giá»�
															// tráº¡ng thÃ¡i

	// private JournaList journalist; // thanh doi tuong member

	private Member journalist;
	// danh sach cuoc hop duoc moi
	private List<Meeting> meetingInviteds;

	// danh sach cuoc cuoc hop khong duoc moi
	private List<Meeting> meetingNotInviteds;

	// To chuc cua nha bao
	private long orgId;

	private String orgName;

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

	public String getOrgName() {
		return orgName;
	}

	public void setOrgName(String orgName) {
		this.orgName = orgName;
	}

	public AttendMeetingJournalist getAttendMeetingJournalist() {
		return attendMeetingJournalist;
	}

	public void setAttendMeetingJournalist(AttendMeetingJournalist attendMeetingJournalist) {
		this.attendMeetingJournalist = attendMeetingJournalist;
	}

	public Member getJournalist() {
		return journalist;
	}

	public void setJournalist(Member journalist) {
		this.journalist = journalist;
	}

	public List<Meeting> getMeetingInviteds() {
		return meetingInviteds;
	}

	public void setMeetingInviteds(List<Meeting> meetingInviteds) {
		this.meetingInviteds = meetingInviteds;
	}

	public List<Meeting> getMeetingNotInviteds() {
		return meetingNotInviteds;
	}

	public void setMeetingNotInviteds(List<Meeting> meetingNotInviteds) {
		this.meetingNotInviteds = meetingNotInviteds;
	}

}
