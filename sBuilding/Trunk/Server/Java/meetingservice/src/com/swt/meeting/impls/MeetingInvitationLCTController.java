package com.swt.meeting.impls;

import java.io.File;
import java.util.Date;
import java.util.List;

import com.swt.meeting.customObject.MeetingInvitationLCT;

public class MeetingInvitationLCTController {
	public static final MeetingInvitationLCTController Instance = new MeetingInvitationLCTController();

	private MeetingInvitationLCTDAO miLCTDAO = new MeetingInvitationLCTDAO();

	/**
	 * them cuoc hop
	 * @param meetingInvitationLCT
	 * @return
	 */
	public MeetingInvitationLCT add(MeetingInvitationLCT meetingInvitationLCT) {
		return miLCTDAO.add(meetingInvitationLCT);
	}

	/**
	 * chinh sua cuoc hop
	 * @param meetingInvitationLCT
	 * @return
	 */
	public MeetingInvitationLCT edit(MeetingInvitationLCT meetingInvitationLCT) {
		return miLCTDAO.edit(meetingInvitationLCT);
	}

	/**
	 * xoa cuoc hop
	 * @param idMeetingInvitationLCT
	 * @return
	 */
	public int delete(long idMeetingInvitationLCT) {
		return miLCTDAO.delete(idMeetingInvitationLCT);
	}

	/**
	 * lay danh sach file dinh kem khi them cuoc hop
	 * @param meetingCode
	 * @param startDate
	 * @return
	 */
	public List<File> getPathFiles(long meetingCode, Date startDate) {
		return miLCTDAO.getPathFiles(meetingCode, startDate);
	}
	
}
