package com.swt.meeting;

import java.util.List;

import com.swt.meeting.domain.MeetingInvitation;

/**
 * IMeetingInvitation interface
 * 
 * @author TaiMai
 *
 */
public interface IMeetingInvitation {
	/**
	 * insert MeetingInvitation
	 * 
	 * @param meetingInvitation
	 * @return MeetingInvitation
	 */
	public MeetingInvitation insert(MeetingInvitation meetingInvitation);

	/**
	 * update MeetingInvitation
	 * 
	 * @param meetingInvitation
	 * @return MeetingInvitation
	 */
	public MeetingInvitation update(MeetingInvitation meetingInvitation);

	/**
	 * delete MeetingInvitation
	 * 
	 * @param meetingInvitationId
	 * @return
	 */
	public int delete(long meetingInvitationId);
	
	/**
	 * xoa MeetingInvitation theo meetingBarcode
	 * 
	 * @param meetingInvitationId
	 * @return
	 */
	public int deleteByBarcode(String meetingBarcode);

	/**
	 * getMeetingInvitationById
	 * 
	 * @param MeetingInvitationId
	 * @return MeetingInvitation
	 */
	public MeetingInvitation getMeetingInvitationById(long meetingInvitationId);

	/**
	 * getAllMeetingInvitation
	 * 
	 * @return  List<MeetingInvitation>
	 */
	public List<MeetingInvitation> getAllMeetingInvitation();
	/**
	 * getMeetingInvitationByBarcode
	 * @param barcode
	 * @return List<MeetingInvitation>
	 */
	public MeetingInvitation getMeetingInvitationByBarcode(String barcode);
	
	/**
	 * lay danh sach thu moi theo orgid va meeting id
	 * @param orgId
	 * @param meeting
	 * @return
	 */
	public List<MeetingInvitation> getInvitationByOrgAndMeetingId(long orgId,long meeting);
	
	/**
	 * lay danh sach thu moi theo meeting id
	 * @param meeting
	 * @return
	 */
	public List<MeetingInvitation> getInvitationByMeetingId(long meeting);
	
	/**
	 * update meetingId khi doi lich hop
	 * @param meetingIdOld
	 * @param meetingIdNew
	 * @return
	 */
	public boolean updateMeetingId(long meetingIdOld, long meetingIdNew);
}
