package com.swt.meeting;

import java.util.List;

import com.swt.meeting.domain.MeetingInvitationOrgOther;
import com.swt.meeting.domain.OrganizationMeeting;

/**
 * IOrganizationMeeting interface
 * 
 * @author TaiMai
 *
 */
public interface IOrganizationMeeting {
	/**
	 * insert OrganizationMeeting
	 * 
	 * @param organizationMeeting
	 * @return OrganizationMeeting
	 */
	public OrganizationMeeting insert(OrganizationMeeting organizationMeeting);

	/**
	 * update OrganizationMeeting
	 * 
	 * @param organizationMeeting
	 * @return OrganizationMeeting
	 */
	public OrganizationMeeting update(OrganizationMeeting organizationMeeting);

	/**
	 * delete OrganizationMeeting
	 * 
	 * @param organizationMeetingId
	 * @return int
	 */
	public int delete(long organizationMeetingId);

	/**
	 * getOrganizationMeetingById
	 * 
	 * @param organizationMeetingId
	 * @return OrganizationMeeting
	 */
	public OrganizationMeeting getOrganizationMeetingById(long organizationMeetingId);

	/**
	 * getAllOrganizationMeeting
	 * 
	 * @return List<OrganizationMeeting>
	 */
	public List<OrganizationMeeting> getAllOrganizationMeeting();
	
	/**
	 * getAllOrganizationMeetingASC
	 * 
	 * @return List<OrganizationMeeting>
	 */
	public List<OrganizationMeeting> getAllOrganizationMeetingASC();
	
	public OrganizationMeeting getByName(String name);
	
	//lay thong tin to chuc khac duoc them vao bang  barcode
	public MeetingInvitationOrgOther getByBarcode(String barcode);
	
	public List<OrganizationMeeting> getByName(String name, int meetingType);
	
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
	public List<OrganizationMeeting> getOrganizationMeetingByReferenceId(long getOrganizationMeetingByReferenceId);
	
	/**
	 * @author My.nguyen
	 * */
	public int edit(OrganizationMeeting organizationMeetingNew);
	
	/**
	 * @author My.nguyen
	 * */
	public int deleteByReferenceId(long organizationLCTId);

	
}
