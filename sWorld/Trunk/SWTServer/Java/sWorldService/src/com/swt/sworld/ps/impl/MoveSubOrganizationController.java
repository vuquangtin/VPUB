package com.swt.sworld.ps.impl;

import java.util.List;

import com.swt.sworld.communication.customer.object.MoveMemberSubOrg;
import com.swt.sworld.communication.customer.object.OrgCustomerDto;
import com.swt.sworld.communication.customer.object.OrgFilterDto;
import com.swt.sworld.ps.domain.Member;

/**
 * Move Sub-Organization Controller
 * 
 * @author minh.nguyen
 *
 */
public class MoveSubOrganizationController {
	/**
	 * Instance of MoveSubOrganizationController
	 */
	public static final MoveSubOrganizationController Instance = new MoveSubOrganizationController();
	private MoveSubOrganizationDAO msoDAO = new MoveSubOrganizationDAO();

	/**
	 * Method get list all sub-organization
	 * 
	 * @param orgFilter
	 * @return
	 */
	public List<OrgCustomerDto> getListSubOrg(OrgFilterDto orgFilter) {
		return msoDAO.getListSubOrg(orgFilter);
	}

	/**
	 * Method get list all member in sub-organization by subOrgId
	 * 
	 * @param orgId
	 * @param parentOrgID
	 * @return
	 */
	public List<Member> getListMemberBySubOrgID(long currentSelectedID, long parentOrgID) {
		return msoDAO.getListMemberBySubOrgID(currentSelectedID, parentOrgID);
	}

	/**
	 * Method move member's sub-organization
	 * 
	 * @param subOrgIdLeft
	 * @param listMemberLeft
	 * @param subOrgIdRight
	 * @param listMemberRight
	 * @return
	 */
	public int moveSubOrg(long subOrgIdLeft, long subOrgIdRight, List<MoveMemberSubOrg> listMemberIDRight) {
		return msoDAO.moveSubOrg(subOrgIdLeft, subOrgIdRight, listMemberIDRight);
	}
}
