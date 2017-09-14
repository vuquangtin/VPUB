package com.swt.meeting.impls;

import java.util.Date;
import java.util.List;

import com.swt.meeting.customObject.JournalistAttendStatisticDetailObj;
import com.swt.meeting.customObject.JournalistAttendStatisticObj;
import com.swt.meeting.customObject.ListMeetingJournalistObj;
import com.swt.meeting.customObject.NumberObj;
import com.swt.meeting.domain.AttendMeetingJournalist;
import com.swt.meeting.domain.Meeting;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.ChipPersonalizationController;

/**
 * AttendMeetingJournalistController
 * 
 * @author TaiMai
 * 
 */
public class AttendMeetingJournalistController {
	/**
	 * 28/10/2016 insert attendMeetingJournalist
	 * 
	 * @param attendMeetingJournalist
	 * @return int
	 */
	public static final AttendMeetingJournalistController Instance = new AttendMeetingJournalistController();

	private AttendMeetingJournalistDAO amjDAO = new AttendMeetingJournalistDAO();

	public boolean insert(ListMeetingJournalistObj listMeetingJournalistObj) {
		List<Meeting> meetingInviteds = listMeetingJournalistObj.getMeetingInviteds();
		List<Meeting> meetingNotInviteds = listMeetingJournalistObj.getMeetingNotInviteds();
		Member journaList = listMeetingJournalistObj.getJournalist();
		AttendMeetingJournalist attendMeetingJournalist = listMeetingJournalistObj.getAttendMeetingJournalist();

		if (attendMeetingJournalist == null) {
			return false;
		}

		// cac thong tin chung
		ChipPersonalization chipPersonalization = ChipPersonalizationController.Instance
				.getByMemberId(journaList.getId());
		if (chipPersonalization == null) {
			return false;
		}
		String serialNumber = chipPersonalization.getSerialNumber();
		
		long orgId = listMeetingJournalistObj.getOrgId();
		String orgName = listMeetingJournalistObj.getOrgName();
		String lastName = journaList.getLastName();
		String firstName = journaList.getFirstName();
		String note = attendMeetingJournalist.getNote();
		boolean status = attendMeetingJournalist.isStatus();
		Date inputTime = attendMeetingJournalist.getInputTime();
		Date outputTime = attendMeetingJournalist.getOutputTime();
		int numberMeeting = attendMeetingJournalist.getNumberMeeting();
		int numberMeetingOther = attendMeetingJournalist.getNumberMeetingAdd();

		// phai tao doi tuong moi vi hibernate insert theo doi tuong.
		// Neu ko insert hibernate hieu se la update

		// meetingInviteds
		for (Meeting meetingObj : meetingInviteds) {
			// kiem tra nha bao da duoc luu vao hay chua
			// dua vao serialnnumber va meeting id
			AttendMeetingJournalist attendMeetingJournalistFact = amjDAO.checkJournalistIsSaveByMeetingIdAndSerialNumber(serialNumber, meetingObj.getId());
			if (attendMeetingJournalistFact == null) {
				//
				attendMeetingJournalistFact = new AttendMeetingJournalist();

				// nhap thong tin nha bao
				attendMeetingJournalistFact.setSerialNumber(serialNumber);
				attendMeetingJournalistFact.setOrganizationAttendId(orgId);
				attendMeetingJournalistFact.setOrganizationAttendName(orgName);
				attendMeetingJournalistFact.setLowerFullName(lastName + " " + firstName);

				// meetingObj
				attendMeetingJournalistFact.setMeetingId(meetingObj.getId());
				attendMeetingJournalistFact.setMeetingName(meetingObj.getName());

				attendMeetingJournalistFact.setOrganizationMeetingId(meetingObj.getOrganizationMeetingId());
				attendMeetingJournalistFact.setOrganizationMeetingName(meetingObj.getOrganizationMeetingName());
				attendMeetingJournalistFact.setInvite(true);
				attendMeetingJournalistFact.setNote(note);

				attendMeetingJournalistFact.setStatus(status);

				attendMeetingJournalistFact.setInputTime(inputTime);
				attendMeetingJournalistFact.setOutputTime(outputTime);

				attendMeetingJournalistFact.setNumberMeeting(numberMeeting);
				attendMeetingJournalistFact.setNumberMeetingAdd(numberMeetingOther);

				amjDAO.insert(attendMeetingJournalistFact);
			}else{
				attendMeetingJournalistFact.setNote(note);
				amjDAO.insert(attendMeetingJournalistFact);
			}
		}

		// meetingNotInviteds
		for (Meeting meetingObj : meetingNotInviteds) {

			AttendMeetingJournalist attendMeetingJournalistFact = amjDAO.checkJournalistIsSaveByMeetingIdAndSerialNumber(serialNumber, meetingObj.getId());
			if (attendMeetingJournalistFact == null) {
				//
				attendMeetingJournalistFact = new AttendMeetingJournalist();

				// nhap thong tin nha bao
				attendMeetingJournalistFact.setSerialNumber(serialNumber);
				attendMeetingJournalistFact.setOrganizationAttendId(orgId);
				attendMeetingJournalistFact.setOrganizationAttendName(orgName);
				attendMeetingJournalistFact.setLowerFullName(lastName + " " + firstName);

				// meetingObj
				attendMeetingJournalistFact.setMeetingId(meetingObj.getId());
				attendMeetingJournalistFact.setMeetingName(meetingObj.getName());

				attendMeetingJournalistFact.setOrganizationMeetingId(meetingObj.getOrganizationMeetingId());
				attendMeetingJournalistFact.setOrganizationMeetingName(meetingObj.getOrganizationMeetingName());
				attendMeetingJournalistFact.setInvite(true);
				attendMeetingJournalistFact.setNote(note);

				attendMeetingJournalistFact.setStatus(status);

				attendMeetingJournalistFact.setInputTime(inputTime);
				attendMeetingJournalistFact.setOutputTime(outputTime);

				attendMeetingJournalistFact.setNumberMeeting(numberMeeting);
				attendMeetingJournalistFact.setNumberMeetingAdd(numberMeetingOther);

				amjDAO.insert(attendMeetingJournalistFact);
			}else{
				attendMeetingJournalistFact.setNote(note);
				amjDAO.insert(attendMeetingJournalistFact);
			}
		}

		return true;
	}

	/**
	 * 28/10/2016 checkout journalist
	 * 
	 * @param serialNumber
	 * @param date
	 * @return
	 */
	public NumberObj checkoutJournalist(String serialNumber, Date date) {
		return amjDAO.checkoutJournalist(serialNumber, date);
	}

	/**
	 * 28/10/2016 update output time journalist
	 * 
	 * @param fromDate
	 * @param toDate
	 * @return
	 */
	public int updateOutputTimeJournalist(String serialNumber, Date date) {
		return amjDAO.updateOutputTimeJournalist(serialNumber, date);
	}

	/**
	 * 23/10/2016 thong ke so luong nguoi tham du cuoc hop cuoc hop theo ngay
	 * 
	 * @param start
	 * @param end
	 * @param fromDate
	 * @param toDate
	 * 
	 * @return JournalistAttendStatisticObj
	 */
	public JournalistAttendStatisticObj statisticJourlistAttend(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName) {
		return amjDAO.statisticJourlistAttend(start, limit, fromDate, toDate, organizationMeetingId, meetingName);
	}

	/**
	 * 23/10/2016 tong so cuoc hop theo ngay
	 * 
	 * @param fromDate
	 * @param toDate
	 * @param organizationMeetingId
	 * @param meetingName
	 * @return long
	 */
	public long sumStatisticJourlistAttend(Date fromDate, Date toDate, long organizationMeetingId, String meetingName) {
		return amjDAO.sumStatisticJourlistAttend(fromDate, toDate, organizationMeetingId, meetingName);
	}

	public JournalistAttendStatisticDetailObj statisticJournalistAttendDetailByMeetingId(int start, int limit,
			long meetingId) {
		return amjDAO.statisticJournalistAttendDetailByMeetingId(start, limit, meetingId);
	}

	public JournalistAttendStatisticDetailObj statisticJournalistAttendDetail(int start, int limit, Date paraFromDate,
			Date paraToDate, long organizationMeetingId, long meetingId) {
		if (organizationMeetingId != -1 && meetingId != -1) {
			return amjDAO.statisticJournalistAttendDetail(start, limit, paraFromDate, paraToDate, organizationMeetingId,
					meetingId);
		} else {
			return amjDAO.statisticJournalistAttendDetail(start, limit, paraFromDate, paraToDate, organizationMeetingId,
					"all");
		}
	}
}