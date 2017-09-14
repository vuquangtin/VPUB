package com.swt.meeting;

import java.util.Date;
import java.util.List;

import com.swt.meeting.customObject.MeetingObjManager;
import com.swt.meeting.domain.EmailConfig;
import com.swt.meeting.domain.Meeting;

/**
 * IMeeting interface
 * 
 * @author TaiMai
 *
 */
public interface IMeeting {
	/**
	 * insert Meeting
	 * 
	 * @param meeting
	 * @return Meeting
	 */
	public Meeting insert(Meeting meeting);

	/**
	 * update Meeting
	 * 
	 * @param meeting
	 * @return Meeting
	 */
	public Meeting update(Meeting meeting);

	/**
	 * delete Meeting
	 * 
	 * @param meetingId
	 * @return int
	 */
	public int delete(long meetingId);

	/**
	 * getMeetingById
	 * 
	 * @param meetingId
	 * @return Meeting
	 */
	public Meeting getMeetingById(long meetingId);
	/**
	 * getmeetingbymeetingcode
	 * @param meetingcode
	 * @return
	 */
	public List<Meeting> getMeetingByMeetingCode(long meetingcode);
	
	/**
	 * get meeting by meetingCode and status = true
	 * @param meetingcode
	 * @return
	 */
	public Meeting getMeetingByMeetingCodeActive(long meetingcode);

	/**
	 * 26/10/2016 danh sach Meeting theo ngay va gio, de getMeetingObjByDateTime
	 * dung getMeetingByDateTime
	 * 
	 * @param meetingDateTime
	 * @return List<Meeting>
	 */
	public List<Meeting> getMeetingByDateTime(Date meetingDateTime);

	/**
	 * dung trong getMeetingObjBySerialNumerAndDateTime
	 * @param meetingId
	 * @param dateTime
	 * @return
	 */
	public Meeting getMeetingByIdAndDateTime(long meetingId, Date dateTime);

	/**
	 * sua doi cuoc hop theo neocoreId
	 * @param meeting
	 * @return
	 */
	public int edit(Meeting meeting);
	
	/**
	 * sua lai tinh trang khi ben kia xoa cuoc hop theo neocoreId
	 * @param neocoreId
	 * @return
	 */
	public int updateNeocoreStatus(long neocoreId);
	
	/**
	 * Lay tat ca danh sach cuoc hop cho nguoi dung cho tren web
	 * @return
	 */
	public List<Meeting> getListMeeting();
	
	/**
	//start giong service ben snonresident
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
	public MeetingObjManager getMeetingByDateAndOrgIdAndMeetingName(int start, int limit, Date fromDate,
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
	public long sumMeetingByDateAndOrgIdAndMeetingName(Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName);
	
	/**
	 * tang so luong nguoi vao tuy theo loai
	 * @param meetingId
	 * @param personAttendType
	 */
	public void increasePersonAttend(long meetingId, int personAttendType);
	
	/**
	//end giong service ben snonresident
	 * 
	 * @param emailConfig
	 * @return
	 */
	public EmailConfig insertEmailConfig(EmailConfig emailConfig);
	public EmailConfig getEmailConfig();
}
