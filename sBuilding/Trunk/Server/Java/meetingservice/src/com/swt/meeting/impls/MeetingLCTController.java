package com.swt.meeting.impls;

import com.swt.meeting.customObject.MeetingInvitationLCT;
import com.swt.meeting.customObject.MeetingLCT;

public class MeetingLCTController {
	public static final MeetingLCTController Instance = new MeetingLCTController();

	private MeetingLCTDAO mDAO = new MeetingLCTDAO();

	/**
	 * 21/1/2017 them cuoc hop tu doi tuong ben QLVP gui qua
	 * 
	 * @param meetingLCT
	 * @return boolean
	 */
	public boolean addMeeting(MeetingLCT meetingLCT) {
		return mDAO.addMeeting(meetingLCT);
	}

	/**
	 * 21/1/2017 sua cuoc hop tu doi tuong ben QLVP gui qua
	 * 
	 * @param meetingLCT
	 * @return boolean
	 */
	public boolean editMeeting(MeetingLCT meetingLCT) {
		return mDAO.editMeeting(meetingLCT);
	}

	/**
	 * 21/1/2017 xoa cuoc hop tu doi tuong ben QLVP gui qua chi thay doi truong
	 * neocoreStatus trong doi tuong Meeting
	 * 
	 * @param neocoreid
	 * @return boolean
	 */
	public boolean deleteMeeting(long neocoreid) {
		return mDAO.deleteMeeting(neocoreid);
	}

	/**
	 * doi lich hop
	 */
	public boolean changetimeMeeting(long idMeetingtingInvitationLCT, MeetingInvitationLCT meetingInvitationLCT){
		return mDAO.changetimeMeeting(idMeetingtingInvitationLCT, meetingInvitationLCT);
	}

	/**
	 * hoan lich
	 */
	public boolean postponedMeeting(long idMeetingtingInvitationLCT){
		return mDAO.postponedMeeting(idMeetingtingInvitationLCT);
	}
	
}
