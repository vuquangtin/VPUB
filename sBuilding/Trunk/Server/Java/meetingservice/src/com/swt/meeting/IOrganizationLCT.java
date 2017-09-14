package com.swt.meeting;

import com.swt.meeting.customObject.OrganizationLCT;

/**
 * IOrganizationLCT interface
 * 
 * @author my.nguyen
 *
 */
public interface IOrganizationLCT {
	/**
	 * insert
	 * @param OrganizationLCT
	 * @return
	 */
	public boolean insert(OrganizationLCT OrganizationLCT);

	/**
	 * udpate
	 * @param OrganizationLCT
	 * @return
	 */
	public boolean update(OrganizationLCT OrganizationLCT);

	/**
	 * delete
	 * @param OrganizationLCTId
	 * @return
	 */
	public boolean delete(long OrganizationLCTId);


	

}
