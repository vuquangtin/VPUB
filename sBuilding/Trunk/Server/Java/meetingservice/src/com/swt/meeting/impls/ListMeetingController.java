package com.swt.meeting.impls;

import java.util.List;

import com.swt.meeting.domain.ListMeeting;

/**
 * ListMeetingController
 * 
 * @author TaiMai
 * 
 */
public class ListMeetingController {
	/**
	 * Instance of ListMeetingController
	 */
	public static final ListMeetingController Instance = new ListMeetingController();

	private ListMeetingDAO rDAO = new ListMeetingDAO();

	/**
	 * insert ListMeeting
	 * 
	 * @param listMeeting
	 * @return ListMeeting
	 */
	public ListMeeting insert(ListMeeting listMeeting) {
		return rDAO.insert(listMeeting);
	}

	/**
	 * update ListMeeting
	 * 
	 * @param listMeeting
	 * @return ListMeeting
	 */
	public ListMeeting update(ListMeeting listMeeting) {
		return rDAO.update(listMeeting);
	}

	/**
	 * delete ListMeeting
	 * 
	 * @param listMeetingId
	 * @return int
	 */
	public int delete(long listMeetingId) {
		return rDAO.delete(listMeetingId);
	}

	/**
	 * getListMeetingById
	 * 
	 * @param listMeetingId
	 * @return ListMeeting
	 */
	public ListMeeting getListMeetingById(long listMeetingId) {
		return rDAO.getListMeetingById(listMeetingId);
	}

	/**
	 * getAllListMeeting
	 * 
	 * @param
	 * @return List<ListMeeting>
	 */
	public List<ListMeeting> getAllListMeeting() {
		return rDAO.getAllListMeeting();
	}

	/**
	 * getListMeetingByMeetingInvitationId
	 * 
	 * @param
	 * @return List<ListMeeting>
	 */
	public List<ListMeeting> getListMeetingByMeetingInvitationId(long meetingInvitationId, long orgId) {
		return rDAO.getListMeetingByMeetingInvitationId(meetingInvitationId, orgId);
	}
	/**
	 * xoa theo meetingInvitationId
	 */
	public int deleteByMeetingInvitationId(long meetingInvitationId){
		return rDAO.deleteByMeetingInvitationId(meetingInvitationId);
	}
	
	/***
	 * version 2
	 * lay danh sach nhung nguoi duoc moi trong mot cuoc hop theo ma thu moi
	 * 
	 */
	public List<ListMeeting> getListMeetingByMeetingInvitationId(long meetingInvitationId) {
		return rDAO.getListMeetingByMeetingInvitationId(meetingInvitationId);
	}
}
