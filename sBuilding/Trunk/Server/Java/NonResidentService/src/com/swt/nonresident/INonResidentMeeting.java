package com.swt.nonresident;

import java.util.Date;
import java.util.List;

import com.swt.nonresident.customObject.NonResidentMeetingObj;
import com.swt.nonresident.domain.NonResidentMeeting;

public interface INonResidentMeeting {
	/**
	 * 29/11/2016 them cuoc hop
	 * 
	 * @param meeting
	 * @return
	 */
	public NonResidentMeeting insert(NonResidentMeeting meeting);

	/**
	 * 12/12/2016 cap nhat thay doi
	 * 
	 * @param organizationMeetingId
	 */
	public NonResidentMeeting update(NonResidentMeeting meeting);

	/**
	 * 12/12/2016 xoa cuoc hop
	 * 
	 * @param organizationMeetingId
	 */
	public int delete(long meetingId);

	/**
	 * 30/11/2016 lay danh sach cuoc hop trong ngay theo organizationAttendId
	 * 
	 * @param organizationMeetingId
	 */
	public List<NonResidentMeeting> getNonResidentMeetingByOrganizationMeetingId(long organizationMeetingId);

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
	public NonResidentMeetingObj getNonResidentMeetingByDateAndOrgIdAndMeetingName(int start, int limit, Date fromDate,
			Date toDate, long organizationMeetingId, String meetingName);

	/**
	 * 13/12/2016 tong so cuoc hop tu ngay den ngay va ten to chuc cuoc hop va
	 * ten cuoc hop
	 * 
	 * @param start
	 * @param end
	 * @param fromTime
	 * @param toTime
	 * @param organizationMeetingId
	 * @param meetingName
	 */
	public long sumNonResidentMeetingByDateAndOrgIdAndMeetingName(Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName);

	/**
	 * 6/12/2016 lay cuoc hop theo id cuoc hop
	 * 
	 * @param meetingId
	 */

	public NonResidentMeeting getNonResidentMeetingById(long meetingId);
}
