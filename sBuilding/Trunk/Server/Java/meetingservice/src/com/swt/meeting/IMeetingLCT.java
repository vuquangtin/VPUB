package com.swt.meeting;

import com.swt.meeting.customObject.MeetingInvitationLCT;
import com.swt.meeting.customObject.MeetingLCT;

public interface IMeetingLCT {
	// cuoc hop
	/**
	 * 21/1/2017 them cuoc hop tu doi tuong ben QLVP gui qua
	 * 
	 * @param meetingLCT
	 * @return boolean
	 */
	public boolean addMeeting(MeetingLCT meetingLCT);

	/**
	 * 21/1/2017 sua cuoc hop tu doi tuong ben QLVP gui qua
	 * 
	 * @param meetingLCT
	 * @return boolean
	 */
	public boolean editMeeting(MeetingLCT meetingLCT);

	/**
	 * 21/1/2017 xoa cuoc hop tu doi tuong ben QLVP gui qua chi thay doi truong
	 * neocoreStatus trong doi tuong Meeting
	 * 
	 * @param neocoreid
	 * @return boolean
	 */
	public boolean deleteMeeting(long neocoreid);

	/**
	 * doi lich hop
	 */
	public boolean changetimeMeeting(long idMeetingtingInvitationLCT, MeetingInvitationLCT meetingInvitationLCT);
	
	/**
	 * hoan lich
	 */
	public boolean postponedMeeting(long idMeetingtingInvitationLCT);
}
