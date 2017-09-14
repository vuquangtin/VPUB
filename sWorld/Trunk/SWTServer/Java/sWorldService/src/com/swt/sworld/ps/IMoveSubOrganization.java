package com.swt.sworld.ps;

import java.util.List;

import com.swt.sworld.communication.customer.object.MoveMemberSubOrg;
import com.swt.sworld.communication.customer.object.OrgCustomerDto;
import com.swt.sworld.communication.customer.object.OrgFilterDto;
import com.swt.sworld.ps.domain.Member;

/**
 * 
 * @author MINH's Macbook Pro
 *
 */
public interface IMoveSubOrganization {
	/**
	 * Method get list all sub-organization
	 * 
	 * @param orgFilter
	 * @return
	 */
	public List<OrgCustomerDto> getListSubOrg(OrgFilterDto orgFilter);
	
	/**
	 * Method get list all member in sub-organization by subOrgId
	 * 
	 * @param orgId
	 * @param parentOrgID
	 * @return
	 */
	public List<Member> getListMemberBySubOrgID(long currentSelectedID, long parentOrgID);
	
	/**
	 * Method move member's sub-organization
	 * 
	 * @param subOrgIdLeft
	 * @param subOrgIdRight
	 * @param listMemberIDLeftRight
	 * @return
	 */
	public int moveSubOrg(long subOrgIdLeft, long subOrgIdRight, List<MoveMemberSubOrg> listMemberIDLeftRight);
}
