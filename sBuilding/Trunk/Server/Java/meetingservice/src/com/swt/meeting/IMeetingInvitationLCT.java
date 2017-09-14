package com.swt.meeting;

import java.io.File;
import java.util.Date;
import java.util.List;

import com.swt.meeting.customObject.FileLCT;
import com.swt.meeting.customObject.MeetingInvitationLCT;
//service cung cap cho NSS
public interface IMeetingInvitationLCT {
	/**
	 * them cuoc hop
	 * @param meetingInvitationLCT
	 * @return
	 */
	public MeetingInvitationLCT add(MeetingInvitationLCT meetingInvitationLCT);

	/**
	 * chinh sua cuoc hop
	 * @param meetingInvitationLCT
	 * @return
	 */
	public MeetingInvitationLCT edit(MeetingInvitationLCT meetingInvitationLCT);

	/**
	 * xoa cuoc hop
	 * @param idMeetingInvitationLCT
	 * @return
	 */
	public int delete(long idMeetingInvitationLCT);

	/**
	 * luu file dinh kem khi them cuoc hop
	 * @param meetingInvitationId
	 * @param startDate
	 * @param fileLCT
	 * @return
	 */
	public FileLCT saveFile(long meetingInvitationId, Date startDate, FileLCT fileLCT);
	
	/**
	 * xoa file dinh kem khi them cuoc hop
	 * @param meetingInvitationId
	 * @param startDate
	 */
	public void deleteFile(long meetingInvitationId, Date startDate);
	
	/**
	 * lay danh sach file dinh kem khi them cuoc hop
	 * @param meetingCode
	 * @param startDate
	 * @return
	 */
	public List<File> getPathFiles(long meetingCode, Date startDate);
}
