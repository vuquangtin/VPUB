package com.swt.meeting;

import java.util.Date;
import java.util.List;

import com.swt.meeting.customObject.ListMeetingJournalistObj;
import com.swt.meeting.domain.ListMeetingJournalist;
import com.swt.meeting.domain.Meeting;

public interface IListMeetingJournalist {

	/**
	 * 26/10/2016 lay List<ListMeetingJournalist>
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * @return List<MeetingObj>
	 */
	public List<ListMeetingJournalist> getListMeetingJournalistBySerialNumer(String serialNumber);

	/**
	 * danh sach tat cac cuoc hop nha bao trong mot khoang thoi gian
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * @param previousMinutes
	 * @return
	 */
	public ListMeetingJournalistObj getListMeetingJonalist(String serialNumber, Date dateTime, int previousMinutes);

	/**
	 * danh sach tat cac cuoc hop nha bao 
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * @return
	 */
	public ListMeetingJournalistObj getListMeetingJonalist(String serialNumber, Date dateTime);

	/**
	 * 12/12/2016 danh sach cuoc hop nha bao duoc moi
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * @param previousMinutes
	 * @return List<Meeting>
	 */
	public List<Meeting> getListMeetingJournalistInvited(String serialNumber, Date dateTime, int previousMinutes);

	/**
	 * 12/12/2016 danh sach cuoc hop nha bao khong duoc moi duoc moi
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * @param previousMinutes
	 * @return List<Meeting>
	 */
	public List<Meeting> getListMeetingJournalistNotInvited(String serialNumber, Date dateTime, int previousMinutes);

}
