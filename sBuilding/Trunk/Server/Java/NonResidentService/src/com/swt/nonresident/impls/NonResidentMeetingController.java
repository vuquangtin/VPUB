package com.swt.nonresident.impls;

import java.util.Date;
import java.util.List;

import com.swt.nonresident.customObject.NonResidentMeetingObj;
import com.swt.nonresident.domain.NonResidentMeeting;

public class NonResidentMeetingController {
	/**
	 * Instance of Meeting
	 */
	public static final NonResidentMeetingController Instance = new NonResidentMeetingController();

	private NonResidentMeetingDAO mDAO = new NonResidentMeetingDAO();

	/**
	 * them cuoc hop
	 *
	 * @param meeting
	 * @return NonResident
	 */
	public NonResidentMeeting insert(NonResidentMeeting meeting) {
		return mDAO.insert(meeting);
	}

	/**
	 * 12/12/2016 cap nhat thay doi
	 * 
	 * @param organizationMeetingId
	 */
	public NonResidentMeeting update(NonResidentMeeting meeting) {
		return mDAO.update(meeting);
	}

	/**
	 * 12/12/2016 xoa cuoc hop
	 * 
	 * @param organizationMeetingId
	 */
	public int delete(long meetingId) {
		return mDAO.delete(meetingId);
	}

	/**
	 * 30/11/2016 lay danh sach cuoc hop trong ngay theo organizationAttendId
	 *
	 * @param organizationMeetingId
	 */
	public List<NonResidentMeeting> getNonResidentMeetingByOrganizationMeetingId(long organizationMeetingId) {
		return mDAO.getNonResidentMeetingByOrganizationMeetingId(organizationMeetingId);
	}

	/**
	 * 30/11/2016 lay danh sach cuoc hop tu ngay den ngay va ten to chuc cuoc
	 * hop va ten cuoc hop
	 *
	 * @param start
	 * @param end
	 * @param fromTime
	 * @param toTime
	 * @param organizationMeetingId
	 * @param meetingName
	 */
	public NonResidentMeetingObj getNonResidentMeetingByDateAndOrgIdAndMeetingName(int start, int limit, Date fromTime,
			Date toTime, long organizationMeetingId, String meetingName) {
		return mDAO.getNonResidentMeetingByDateAndOrgIdAndMeetingName(start, limit, fromTime, toTime,
				organizationMeetingId, meetingName);
	}

	/**
	 * 6/12/2016 lay cuoc hop theo id hop va ten cuoc hop
	 *
	 * @param meetingId
	 */

	public NonResidentMeeting getNonResidentMeetingById(long meetingId) {
		return mDAO.getNonResidentMeetingById(meetingId);
	}
}
