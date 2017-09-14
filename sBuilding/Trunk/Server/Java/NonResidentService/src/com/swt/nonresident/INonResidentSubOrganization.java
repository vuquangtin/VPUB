package com.swt.nonresident;

import java.util.List;

import com.swt.nonresident.domain.NonResidentSubOrganization;

/**
 * Service quan ly suborg cho khach vang lai
 * 
 * @author MINH's Macbook Pro
 *
 */
public interface INonResidentSubOrganization {
	/**
	 * Them suborg
	 * 
	 * @param nonResSubOrg
	 * @return
	 */
	public NonResidentSubOrganization insert(NonResidentSubOrganization nonResSubOrg);
	
	/**
	 * Sua suborg
	 * 
	 * @param nonResSubOrg
	 * @return
	 */
	public NonResidentSubOrganization update(NonResidentSubOrganization nonResSubOrg);
	
	/**
	 * Xoa suborg
	 * 
	 * @param nonSubOrgId
	 * @return
	 */
	public int delete(long nonSubOrgId);
	
	/**
	 * Lay suborg
	 * 
	 * @param nonSubOrgId
	 * @return
	 */
	public NonResidentSubOrganization get(long nonSubOrgId);
	
	/**
	 * Lay tat ca cac danh sach suborg cua khach vang lai theo nonOrgId
	 * 
	 * @param nonOrgId
	 * @return
	 */
	public List<NonResidentSubOrganization> getListAllSubOrg(long nonOrgId);
}
