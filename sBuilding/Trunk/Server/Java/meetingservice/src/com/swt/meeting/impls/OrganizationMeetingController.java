package com.swt.meeting.impls;

import java.util.List;

import com.swt.meeting.domain.MeetingInvitationOrgOther;
import com.swt.meeting.domain.OrganizationMeeting;

/**
 * OrganizationMeetingController
 * 
 * @author TaiMai
 * 
 */
public class OrganizationMeetingController {
	/**
	 * Instance of OrganizationMeetingController
	 */
	public static final OrganizationMeetingController Instance = new OrganizationMeetingController();

	private OrganizationMeetingDAO omDAO = new OrganizationMeetingDAO();

	/**
	 * insert OrganizationMeeting
	 * 
	 * @param organizationMeeting
	 * @return OrganizationMeeting
	 */
	public OrganizationMeeting insert(OrganizationMeeting organizationMeeting) {
		return omDAO.insert(organizationMeeting);
	}

	/**
	 * update OrganizationMeeting
	 * 
	 * @param organizationMeeting
	 * @return OrganizationMeeting
	 */
	public OrganizationMeeting update(OrganizationMeeting organizationMeeting) {
		return omDAO.update(organizationMeeting);
	}

	/**
	 * delete OrganizationMeeting
	 * 
	 * @param organizationMeetingId
	 * @return int
	 */
	public int delete(long organizationMeetingId) {
		return omDAO.delete(organizationMeetingId);
	}

	/**
	 * getOrganizationMeetingById
	 * 
	 * @param organizationMeetingId
	 * @return OrganizationMeeting
	 */
	public OrganizationMeeting getOrganizationMeetingById(long organizationMeetingId) {
		return omDAO.getOrganizationMeetingById(organizationMeetingId);
	}

	/**
	 * getAllOrganizationMeeting
	 * 
	 * @param
	 * @return List<OrganizationMeeting>
	 */
	public List<OrganizationMeeting> getAllOrganizationMeeting() {
		return omDAO.getAllOrganizationMeeting();
	}
	
	/**
	 * getAllOrganizationMeetingASC
	 * 
	 * @param
	 * @return List<OrganizationMeeting>
	 */
	public List<OrganizationMeeting> getAllOrganizationMeetingASC() {
		return omDAO.getAllOrganizationMeetingASC();
	}
	
	
	/**
	 * getAllOrganizationPartaker
	 * 
	 * @param
	 * @return List<OrganizationMeeting>
	 */
	public List<OrganizationMeeting> getAllOrganizationPartaker() {
		return omDAO.getAllOrganizationPartaker();
	}

	public OrganizationMeeting getByName(String orgName) {
		return omDAO.getByName(orgName);
	}
	
	public List<OrganizationMeeting> getByName(String orgName, int meetingType) {
		return omDAO.getByName(orgName,meetingType);
	}

	// lay thong tin to chuc khac duoc them vao bang barcode
	public MeetingInvitationOrgOther getOrgOtherByBarcode(String barcode) {
		return omDAO.getByBarcode(barcode);
	}

	/**
	 * @author My.nguyen
	 * Kiem tra orgmeting co id nay chua
	 * co: khong insert duoc
	 * khong: cho insert
	 * getOrganizationMeetingByReferenceId
	 * 
	 * @param organizationMeetingId
	 * @return OrganizationMeeting
	 */
	public List<OrganizationMeeting> getOrganizationMeetingByReferenceId(long getOrganizationMeetingByReferenceId) {
		return omDAO.getOrganizationMeetingByReferenceId(getOrganizationMeetingByReferenceId);
	}
	
	/**
	 * @author My.nguyen
	 * */
	public int edit(OrganizationMeeting organizationMeetingNew) {
		// TODO Auto-generated method stub
		return omDAO.edit(organizationMeetingNew);
	}

	/**
	 * @author My.nguyen
	 * */
	public int deleteByReferenceId(long organizationLCTId) {
		// TODO Auto-generated method stub
		return omDAO.deleteByReferenceId(organizationLCTId);
	}
}
