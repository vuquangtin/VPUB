package com.swt.nonresident.impls;

import java.util.List;

import com.swt.nonresident.domain.NonResidentOrganization;

public class NonResidentOrganizationController {
	public static final NonResidentOrganizationController Instance = new NonResidentOrganizationController();
	private NonResidentOrganizationDAO nroDAO = new NonResidentOrganizationDAO();

	/**
	 * Them org
	 * 
	 * @param nonResOrg
	 * @return
	 */
	public NonResidentOrganization insert(NonResidentOrganization nonResOrg) {
		return nroDAO.insert(nonResOrg);
	}

	/**
	 * Sua org
	 * 
	 * @param nonResOrg
	 * @return
	 */
	public NonResidentOrganization update(NonResidentOrganization nonResOrg) {
		return nroDAO.update(nonResOrg);
	}

	/**
	 * Xoa org
	 * 
	 * @param nonOrgId
	 * @return
	 */
	public int delete(long nonOrgId) {
		return nroDAO.delete(nonOrgId);
	}

	/**
	 * Lay org
	 * 
	 * @param nonOrgId
	 * @return
	 */
	public NonResidentOrganization get(long nonOrgId) {
		return nroDAO.get(nonOrgId);
	}
	
	/**
	 * Lay danh sach tat ca cac org cua khach vang lai theo orgCode
	 * 
	 * @return
	 */
	public List<NonResidentOrganization> getListAllOrg(String orgCode){
		return nroDAO.getListAllOrg(orgCode);
	}
}
