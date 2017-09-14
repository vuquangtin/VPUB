package com.swt.meeting.impls;

import com.swt.meeting.IJournaList;
import com.swt.meeting.IMeeting;
import com.swt.sworld.ps.domain.Member;

public class JournaListController {
	public static final JournaListController Instance = new JournaListController();
	IJournaList JDAO = new JournaListDAO();
	IMeeting mDAO = new MeetingDAO();

	public Member getJournalistBySerial(String serialNumber) {
		return JDAO.getJournalistBySerial(serialNumber);
	}

	public int isDateExpirated(String serialNumber) {
		return JDAO.isDateExpirated(serialNumber);
	}
}
