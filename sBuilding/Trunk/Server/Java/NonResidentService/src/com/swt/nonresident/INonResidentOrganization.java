package com.swt.nonresident;

import java.util.List;

import com.swt.nonresident.domain.NonResidentOrganization;

/**
 * Service quan ly Org cho khach vang lai
 * 
 * @author MINH's Macbook Pro
 *
 */
public interface INonResidentOrganization {
	/**
	 * Them org
	 * 
	 * @param nonResOrg
	 * @return
	 */
	public NonResidentOrganization insert(NonResidentOrganization nonResOrg);
	
	/**
	 * Sua org
	 * 
	 * @param nonResOrg
	 * @return
	 */
	public NonResidentOrganization update(NonResidentOrganization nonResOrg);
	
	/**
	 * Xoa org
	 * 
	 * @param nonOrgId
	 * @return
	 */
	public int delete(long nonOrgId);
	
	/**
	 * Lay org
	 * 
	 * @param nonOrgId
	 * @return
	 */
	public NonResidentOrganization get(long nonOrgId);
	
	/**
	 * Lay danh sach tat ca cac org cua khach vang lai theo orgCode
	 * 
	 * @return
	 */
	public List<NonResidentOrganization> getListAllOrg(String orgCode);
}
