package com.swt.nonresident.impls;

import java.util.List;

import com.swt.nonresident.domain.NonResidentPartaker;

public class PartakerController {
	/**
	 * Instance of Meeting
	 */
	public static final PartakerController Instance = new PartakerController();

	private PartakerDAO pDAO = new PartakerDAO();

	/**
	 * 16/12/2016 lay danh sach nguoi tham du cua cuoc hop da duoc moi truoc
	 * 
	 * @return
	 */
	public List<NonResidentPartaker> getPartakerByMeetingId(long meetingId) {
		return pDAO.getPartakerByMeetingId(meetingId);
	}
}
