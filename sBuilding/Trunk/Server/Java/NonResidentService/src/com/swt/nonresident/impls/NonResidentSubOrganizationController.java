package com.swt.nonresident.impls;

import java.util.List;

import com.swt.nonresident.domain.NonResidentSubOrganization;

public class NonResidentSubOrganizationController {
	public static final NonResidentSubOrganizationController Instance = new NonResidentSubOrganizationController();
	private NonResidentSubOrganizationDAO nrsoDAO = new NonResidentSubOrganizationDAO();

	/**
	 * Them suborg
	 * 
	 * @param nonResSubOrg
	 * @return
	 */
	public NonResidentSubOrganization insert(NonResidentSubOrganization nonResSubOrg) {
		return nrsoDAO.insert(nonResSubOrg);
	}

	/**
	 * Sua suborg
	 * 
	 * @param nonResSubOrg
	 * @return
	 */
	public NonResidentSubOrganization update(NonResidentSubOrganization nonResSubOrg) {
		return nrsoDAO.update(nonResSubOrg);
	}

	/**
	 * Xoa suborg
	 * 
	 * @param nonSubOrgId
	 * @return
	 */
	public int delete(long nonSubOrgId) {
		return nrsoDAO.delete(nonSubOrgId);
	}

	/**
	 * Lay suborg
	 * 
	 * @param nonSubOrgId
	 * @return
	 */
	public NonResidentSubOrganization get(long nonSubOrgId) {
		return nrsoDAO.get(nonSubOrgId);
	}

	/**
	 * Lay tat ca cac danh sach suborg cua khach vang lai theo nonOrgId
	 * 
	 * @param nonOrgId
	 * @return
	 */
	public List<NonResidentSubOrganization> getListAllSubOrg(long nonOrgId) {
		return nrsoDAO.getListAllSubOrg(nonOrgId);
	}
}
