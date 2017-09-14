package com.swt.meeting.impls;

import java.util.Date;
import java.util.List;

import com.swt.meeting.customObject.ListMeetingJournalistObj;
import com.swt.meeting.domain.ListMeetingJournalist;

/**
 * ListMeetingJournalistController
 * 
 * @author TaiMai
 * 
 */
public class ListMeetingJournalistController {
	public static final ListMeetingJournalistController Instance = new ListMeetingJournalistController();

	private ListMeetingJournalistDAO DAO = new ListMeetingJournalistDAO();

	/**
	 * 26/10/2016 lay List<ListMeetingJournalist>
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * @return List<MeetingObj>
	 */
	public List<ListMeetingJournalist> getListMeetingJournalistBySerialNumer(String serialNumber) {
		return DAO.getListMeetingJournalistBySerialNumer(serialNumber);
	}

	/**
	 * danh sach tat cac cuoc hop nha bao trong mot khoang thoi gian
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * @param previousMinutes
	 * @return
	 */
	public ListMeetingJournalistObj getListMeetingJonalist(String serialNumber, Date dateTime, int previousMinutes) {
		return DAO.getListMeetingJonalist(serialNumber, dateTime, previousMinutes);
	}
	/**
	 * danh sach tat cac cuoc hop nha bao 
	 * 
	 * @param serialNumber
	 * @param dateTime
	 * @return
	 */
	public ListMeetingJournalistObj getListMeetingJonalist(String serialNumber, Date dateTime) {
		return DAO.getListMeetingJonalist(serialNumber, dateTime);
	}

}
