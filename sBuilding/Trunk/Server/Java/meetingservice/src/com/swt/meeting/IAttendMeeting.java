package com.swt.meeting;

import java.math.BigInteger;
import java.util.Date;
import java.util.List;

import com.swt.meeting.customObject.NumberObj;
import com.swt.meeting.customObject.PersonAttend;
import com.swt.meeting.customObject.PersonAttendDetailObj;
import com.swt.meeting.customObject.PersonAttendObj;
import com.swt.meeting.domain.AttendMeeting;
import com.swt.meeting.domain.NonResident;

/**
 * IAttendMeeting interface
 * 
 * @author TaiMai
 *
 */
public interface IAttendMeeting {
	/**
	 * insert AttendMeeting
	 * 
	 * @param AttendMeeting
	 * @return
	 */
	public AttendMeeting insert(AttendMeeting attendMeeting);

	/**
	 * update output time when go out update AttendMeeting
	 * 
	 * @param AttendMeeting
	 * @return
	 */
	public int update(String barcode, Date date);

	/**
	 * delete AttendMeeting
	 * 
	 * @param AttendMeetingId
	 * @return
	 */
	public int delete(long attendMeetingId);
	
	/**
	 * 24/04/2017 xoa attendmeeting theo partakerId
	 * @param partakerId
	 * @return
	 */
	public void deleteByPartakerId(long partakerId);

	/**
	 * getAttendMeetingById
	 * 
	 * @param AttendMeetingId
	 * @return
	 */
	public AttendMeeting getAttendMeetingById(long attendMeetingId);

	/**
	 * isExistBarcode
	 * 
	 * @param barcode
	 * @return List<AttendMeeting>
	 */
	public NumberObj isExistBarcode(String barcode);

	/* ======================== thong ke moi ===================== */
	/**
	 * 23/10/2016 thong ke so luong nguoi tham du cuoc hop cuoc hop theo ngay
	 * 
	 * @param start
	 * @param end
	 * @param fromDate
	 * @param toDate
	 * 
	 * @return PersonAttendObj
	 */
	public PersonAttendObj statisticPersonAttend(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName);

	/**
	 * 23/10/2016 tong so cuoc hop theo ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @param meetingName
	 * @return long
	 */
	public long sumStatisticPersonAttend(Date fromDate, Date toDate, long organizationMeetingId, String meetingName);

	/**
	 * 21/10/2016 thong ke chi tiet nguoi tham du theo ma cuoc hop
	 * 
	 * @param meetingId
	 * @return PersonAttendDetailObj
	 */
	public PersonAttendDetailObj statisticPersonAttendDetailByMeetingId(int start, int limit, long meetingId);

	/**
	 * 9/12/2016 tong so luong chi tiet nguoi tham du theo ma cuoc hop
	 * 
	 * @param meetingId
	 * @return long
	 */
	public long sumStatisticPersonAttendDetailByMeetingId(long meetingId);

	/**
	 * 2/12/2016 thong ke chi tiet nguoi tham du theo ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @param meetingName
	 * @return long
	 */
	public PersonAttendDetailObj statisticPersonAttendDetail(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName);

	/**
	 * 9/12/2016 tong so luong chi tiet nguoi tham du theo don vi to chuc va ten
	 * cuoc hop
	 * 
	 * @param meetingId
	 * @return long
	 */
	public long sumStatisticPersonAttendDetail(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName);

	/**
	 * 9/12/2016 tong so luong chi tiet nguoi tham du theo don vi to chuc va ten
	 * cuoc hop
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @param meetingName
	 * @return long
	 */
	public long sumStatisticPersonAttendDetailAll(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName);

	/**
	 * 23/12/2016 thong ke nguoi tham du theo ngay va don vi to chuc
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @return List<AttendMeeting>
	 */
	public List<PersonAttend> statisticPersonAttend(Date fromDate, Date toDate, long organizationMeetingId);

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
			long organizationMeetingId, long meetingId);

	/**
	 * 23/12/2016 tong so luong chi tiet nguoi tham du theo ma don vi to chuc va
	 * ma cuoc hop
	 * 
	 * @param organizationMeetingId
	 * @param meetingId
	 * @return long
	 */
	public long sumStatisticPersonAttendDetailByOgranizationMeetingIdAndMeetingId(Date fromDate, Date toDate,
			long organizationMeetingId, long meetingId);

	/* ============================================= */

	/**
	 * 15/3/2017 khoi phuc cac the barcode theo meeting id
	 * 
	 * 
	 */
	public boolean refreshBarcodeByMeetingId(long meetingId);

	/**
	 * 15/3 cap nhat lai thoi gian bat dau hop
	 * 
	 * @param meetingId
	 * @param date
	 * @return
	 */
	public boolean updateMeetingStartTime(long meetingId, Date date);

	/**
	 * tong so khach vang lai tham du
	 */
	public long sumNumberNonresident(BigInteger meetingId);

	 /**
	  * lay khach vang lai theo meeting id
	  * @param meetingId
	  * @return
	  */
	public List<NonResident> sumNonresidentDetail(long meetingId);

	/**
	 * lay khach vang lai theo meeting id va co gioi han de phan trang
	 * @param meetingId
	 * @param start
	 * @param limit
	 * @return
	 */
	public List<NonResident> sumNonresidentDetailLimit(long meetingId, long start, long limit);

	
	/**
	 * lay khach vang lai theo organizationMeetingId, tu ngay den ngay va theo ten cuoc hop
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @param meetingName
	 * @return
	 */
	public List<NonResident> sumNonresidentDetail(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName);

	/**
	 * lay khach vang lai theo organizationMeetingId, tu ngay den ngay va theo ten cuoc hop va co gioi han de phan trang
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @param meetingName
	 * @param start
	 * @param limit
	 * @return
	 */
	public List<NonResident> sumNonresidentDetailLimit(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName, long start, long limit);

	/**
	 * in vao bang nonresident de thong ke
	 * @param nonResident
	 * @return
	 */
	public NonResident insertNonresident(NonResident nonResident);
	
	/**
	 * update meetingId khi doi lich hop
	 * @param meetingIdOld
	 * @param meetingIdNew
	 * @return
	 */
	public boolean updateMeetingId(long meetingIdOld, long meetingIdNew);
}
