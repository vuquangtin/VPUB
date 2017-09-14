package com.swt.meeting.impls;

import com.swt.meeting.customObject.OrganizationLCT;

/**
 * OrganizationLCTController
 * 
 * @author My.Nguyen
 * 
 */
public class OrganizationLCTController {

	public static final OrganizationLCTController Instance = new OrganizationLCTController();

	private OrganizationLCTDAO omDAO = new OrganizationLCTDAO();

	public boolean insert(OrganizationLCT organizationMeetingLCT) {
		return omDAO.insert(organizationMeetingLCT);
	}

	public boolean update(OrganizationLCT organizationMeetingLCT) {
		return omDAO.update(organizationMeetingLCT);
	}

	public boolean delete(long organizationMeetingLCTId) {
		return omDAO.delete(organizationMeetingLCTId);
	}

}
