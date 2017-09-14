package com.swt.nonresident;

import java.util.List;

import com.swt.nonresident.domain.NonResidentPartaker;

public interface IPartaker {
	/**
	 * 16/12/2016 lay danh sach nguoi tham du cua cuoc hop da duoc moi truoc
	 * service nay giong ben cuc Smeeting  IPartaker
	 * @return
	 */
	public List<NonResidentPartaker> getPartakerByMeetingId(long meetingId); 
}
