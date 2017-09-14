package com.swt.meeting;

import java.util.List;

import com.swt.meeting.domain.ListMeeting;

/**
 * IListMeeting interface
 * 
 * @author TaiMai
 *
 */
public interface IListMeeting {
	/**
	 * insert ListMeeting
	 * 
	 * @param listMeeting
	 * @return ListMeeting
	 */
	public ListMeeting insert(ListMeeting listMeeting);

	/**
	 * update ListMeeting
	 * 
	 * @param listMeeting
	 * @return ListMeeting
	 */
	public ListMeeting update(ListMeeting listMeeting);

	/**
	 * delete ListMeeting
	 * 
	 * @param listMeetingId
	 * @return ListMeeting
	 */
	public int delete(long listMeetingId);

	/**
	 * getListMeetingById
	 * 
	 * @param listMeetingId
	 * @return ListMeeting
	 */
	public ListMeeting getListMeetingById(long listMeetingId);

	/**
	 * getAllListMeeting
	 * 
	 * @return List<ListMeeting>
	 */
	public List<ListMeeting> getAllListMeeting();

	/**
	 * getListMeetingByMeetingInvitationId
	 * 
	 * @param meetingInvitationId
	 * @return List<ListMeeting>
	 */
	public List<ListMeeting> getListMeetingByMeetingInvitationId(long meetingInvitationId, long orgId);
	
	
	/**
	 * xoa theo meetingInvitationId
	 */
	public int deleteByMeetingInvitationId(long meetingInvitationId);
	
	/***
	 * version 2
	 * lay danh sach nhung nguoi duoc moi trong mot cuoc hop theo ma thu moi
	 * 
	 */
	public List<ListMeeting> getListMeetingByMeetingInvitationId(long meetingInvitationId);
}
