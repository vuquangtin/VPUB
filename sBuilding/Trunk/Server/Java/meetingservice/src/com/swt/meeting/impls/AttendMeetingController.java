package com.swt.meeting.impls;

import java.util.Date;
import java.util.List;

import com.swt.meeting.customObject.NumberObj;
import com.swt.meeting.customObject.PersonAttend;
import com.swt.meeting.customObject.PersonAttendDetailObj;
import com.swt.meeting.customObject.PersonAttendObj;
import com.swt.meeting.customObject.PersonNotBarcodeObj;
import com.swt.meeting.domain.AttendMeeting;
import com.swt.meeting.domain.NonResident;
import com.swt.meeting.domain.PersonNotBarcode;
import com.swt.meeting.lib.tm.CommonFunction;
import com.swt.meeting.lib.tm.Constant;

/**
 * AttendMeetingController
 * 
 * @author TaiMai
 * 
 */
public class AttendMeetingController {
	/**
	 * Instance of AttendMeetingController
	 */
	public static final AttendMeetingController Instance = new AttendMeetingController();

	private AttendMeetingDAO amDAO = new AttendMeetingDAO();

	/**
	 * insert AttendMeeting
	 * 
	 * @param attendMeeting
	 * @return AttendMeeting
	 */
	public AttendMeeting insert(AttendMeeting attendMeeting) {
		return amDAO.insert(attendMeeting);
	}

	/**
	 * update AttendMeeting
	 * 
	 * @param attendMeeting
	 * @return AttendMeeting
	 */
	/*
	 * public int update(AttendMeeting attendMeeting) { return
	 * amDAO.update(attendMeeting); }
	 */

	public int update(String barcode, Date timeout) {
		return amDAO.update(barcode, timeout);
	}

	/**
	 * delete AttendMeeting
	 * 
	 * @param attendMeetingId
	 * @return int
	 */
	public int delete(long attendMeetingId) {
		return amDAO.delete(attendMeetingId);
	}

	/**
	 * getAttendMeetingById
	 * 
	 * @param attendMeetingId
	 * @return AttendMeeting
	 */
	public AttendMeeting getAttendMeetingById(long attendMeetingId) {
		return amDAO.getAttendMeetingById(attendMeetingId);
	}

	/*
	 * public List<AttendMeeting> checkInOutAttendMeeting(String barcode){
	 * return amDAO.checkInOutAttendMeeting(barcode); }
	 */

	/**
	 * kiem barcode trong attendMeeting da ton tai chua? isExistBarcode()
	 * 
	 * @param barcode
	 * @return List<AttendMeeting>
	 */

	public NumberObj isExistBarcode(String barcode) {
		return amDAO.isExistBarcode(barcode);
	}

	/**
	 * 21/10/2016 thong ke AttendMeeting theo ma cuoc hop
	 * 
	 * @param meetingId
	 * @return List<AttendMeeting>
	 */
	public PersonAttendDetailObj statisticPersonAttendDetailByMeetingId(int start, int limit, long meetingId) {
		return amDAO.statisticPersonAttendDetailByMeetingId(start, limit, meetingId);
	}

	/* ===================Thong ke nguoi di hop moi================ */
	/**
	 * 23/10/2016 thong ke so luong nguoi tham du cuoc hop cuoc hop theo ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @return List<AttendMeeting>
	 */
	public PersonAttendObj statisticPersonAttend(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName) {
		return amDAO.statisticPersonAttend(start, limit, fromDate, toDate, organizationMeetingId, meetingName);
	}

	/**
	 * 2/12/2016 thong ke chi tiet nguoi tham du theo ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @param meetingName
	 * @return List<AttendMeeting>
	 */
	public PersonAttendDetailObj statisticPersonAttendDetail(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName) {
		return amDAO.statisticPersonAttendDetail(start, limit, fromDate, toDate, organizationMeetingId, meetingName);
	}

	/**
	 * 23/12/2016 thong ke nguoi tham du theo ngay va don vi to chuc
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @return List<AttendMeeting>
	 */
	public List<PersonAttend> statisticPersonAttend(Date fromDate, Date toDate, long organizationMeetingId) {
		return amDAO.statisticPersonAttend(fromDate, toDate, organizationMeetingId);
	}

	/**
	 * 23/12/2016 thong ke chi tiet nguoi tham du theo ngay , orgid va meetingid
	 * 
	 * @param start
	 * @param limit
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @param meetingId
	 * @return PersonAttendDetailObj
	 */
	public PersonAttendDetailObj statisticPersonAttendDetail(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, long meetingId) {
		if (organizationMeetingId != -1 && meetingId != -1) {
			return amDAO.statisticPersonAttendDetail(start, limit, fromDate, toDate, organizationMeetingId, meetingId);
		} else {
			return amDAO.statisticPersonAttendDetail(start, limit, fromDate, toDate, organizationMeetingId, "all");
		}
	}

	/**
	 * 15/3/2017 khoi phuc cac the barcode theo meeting id
	 * 
	 * 
	 */
	public boolean refreshBarcodeByMeetingId(long meetingId) {
		return amDAO.refreshBarcodeByMeetingId(meetingId);
	}

	/**
	 * 15/3/2017 cap nhat lai thoi gian bat dau hop
	 * 
	 * @param meetingId
	 * @param date
	 * @return
	 */
	public boolean updateMeetingStartTime(long meetingId, Date date) {
		return amDAO.updateMeetingStartTime(meetingId, date);
	}

	/**
	 * 16/3/2017 doi thoi gian hop
	 */
	public boolean changeStartTime(long meetingId, Date date) {
		return this.refreshBarcodeByMeetingId(meetingId) && this.updateMeetingStartTime(meetingId, date);
	}

	/**
	 * 28/03/2017 them nguoi vao. Nhung nguoi do khong co barcode
	 */
	public AttendMeeting insertPersonNotBarcode(PersonNotBarcodeObj personNotBarcodeObj) {
		// insert person not barcode
		CommonFunction.INSTANCE.setTable(new PersonNotBarcode());
		PersonNotBarcode person = (PersonNotBarcode) CommonFunction.INSTANCE
				.insert(personNotBarcodeObj.getPersonNotBarcode());
		// insert attend meeting
		AttendMeeting attendMeeting = new AttendMeeting();
		// set thong tin nguoi ko co barcode

		attendMeeting.setInvited(false);
		attendMeeting.setInputTime(personNotBarcodeObj.getInputTime());
		attendMeeting.setOutputTime(personNotBarcodeObj.getOutputTime());

		attendMeeting.setMeetingBarcode(Constant.BARCODE_DEFAULT);
		attendMeeting.setMeetingId(personNotBarcodeObj.getMeetingId());
		attendMeeting.setMeetingName(personNotBarcodeObj.getMeetingName());
		attendMeeting.setNote(personNotBarcodeObj.getNote());

		attendMeeting.setOrganizationMeetingId(personNotBarcodeObj.getOrganizationMeetingId());
		attendMeeting.setOrganizationMeetingName(personNotBarcodeObj.getOrganizationMeetingName());

		attendMeeting.setPersonNotBarcodeId(person.getId());

		attendMeeting.setStatus(true);
		CommonFunction.INSTANCE.setTable(new AttendMeeting());

		// tang so luong nguoi duoc them da vao mot cuoc hop
		MeetingController.Instance.increasePersonAttend(personNotBarcodeObj.getMeetingId(), Constant.PERSON_ATTEND_ADD);
		return (AttendMeeting) CommonFunction.INSTANCE.insert(attendMeeting);
	}

	// insert giong ben Nonresident
	public NonResident insertNonresident(NonResident nonResident) {
		return amDAO.insertNonresident(nonResident);
	}

	/**
	 * 24/04/2017 xoa attendmeeting theo partakerId
	 * 
	 * @param partakerId
	 * @return
	 */
	public void deleteByPartakerId(long partakerId) {
		amDAO.deleteByPartakerId(partakerId);
	}

	/**
	 * update meetingId khi doi lich hop
	 * 
	 * @param meetingIdOld
	 * @param meetingIdNew
	 * @return
	 */
	public boolean updateMeetingId(long meetingIdOld, long meetingIdNew) {
		return amDAO.updateMeetingId(meetingIdOld, meetingIdNew);
	}
}
