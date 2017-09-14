package com.swt.meeting;

import java.util.Date;

import com.swt.meeting.customObject.JournalistAttendStatisticDetailObj;
import com.swt.meeting.customObject.JournalistAttendStatisticObj;
import com.swt.meeting.customObject.NumberObj;
import com.swt.meeting.domain.AttendMeetingJournalist;

public interface IAttendMeetingJournalist {
	/**
	 * 28/10/2016 insert attendMeetingJournalist
	 * 
	 * @param attendMeetingJournalist
	 * @return int
	 */
	public AttendMeetingJournalist insert(AttendMeetingJournalist attendMeetingJournalist);

	/**
	 * 28/10/2016 checkout journalist
	 * 
	 * @param serialNumber
	 * @param date
	 * @return
	 */
	public NumberObj checkoutJournalist(String serialNumber, Date date);

	/**
	 * 28/10/2016 update output time journalist
	 * 
	 * @param fromDate
	 * @param toDate
	 * @return
	 */
	public int updateOutputTimeJournalist(String serialNumber, Date date);

	// thong ke nha bao
	/**
	 * 23/10/2016 thong ke so luong nha bao tham du cuoc hop cuoc hop theo ngay
	 * 
	 * @param start
	 * @param end
	 * @param fromDate
	 * @param toDate
	 * 
	 * @return PersonAttendObj
	 */
	public JournalistAttendStatisticObj statisticJourlistAttend(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName);

	public long sumStatisticJourlistAttend(Date fromDate, Date toDate, long organizationMeetingId, String meetingName);

	/**
	 * 03/04/2017 thong ke so chi tiet nha bao theo meeting id
	 * 
	 * @param start
	 * @param limit
	 * @param meetingId
	 * @return
	 */
	public JournalistAttendStatisticDetailObj statisticJournalistAttendDetailByMeetingId(int start, int limit,
			long meetingId);

	public long sumStatisticJournalistAttendDetailByMeetingId(long meetingId);

	/**
	 * 03/04/2017 thong ke chi tiet nha bao theo ngay va ma to chuc
	 * 
	 * @param start
	 * @param limit
	 * @param paraFromDate
	 * @param paraToDate
	 * @param organizationMeetingId
	 * @param meetingId
	 * @return
	 */
	public JournalistAttendStatisticDetailObj statisticJournalistAttendDetail(int start, int limit, Date paraFromDate,
			Date paraToDate, long organizationMeetingId, long meetingId);

	public long sumStatisticJournalistAttendDetail(Date paraFromDate, Date paraToDate, long organizationMeetingId,
			long meetingId);

	/**
	 * 03/04/2017 thong ke chi tiet nha bao theo ngay va ten to chuc
	 * 
	 * @param start
	 * @param limit
	 * @param paraFromDate
	 * @param paraToDate
	 * @param organizationMeetingId
	 * @param meetingId
	 * @return
	 */
	public JournalistAttendStatisticDetailObj statisticJournalistAttendDetail(int start, int limit, Date paraFromDate,
			Date paraToDate, long organizationMeetingId, String meetingName);

	public long sumStatisticJournalistAttendDetail(Date paraFromDate, Date paraToDate, long organizationMeetingId,
			String meetingName);

	public long sumStatisticJournalistAttendDetailAll(Date paraFromDate, Date paraToDate, long organizationMeetingId,
			String meetingName);
	
	/**
	 * 06/04/2017 kiem tra nha bao do da dc luu vao database chua
	 * @param serialnumber
	 * @param meetingId
	 * @return
	 */
	public AttendMeetingJournalist checkJournalistIsSaveByMeetingIdAndSerialNumber(String serialnumber, long meetingId);
}
