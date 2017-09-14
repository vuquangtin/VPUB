package com.swt.sworld.ps.impl;

import java.util.ArrayList;
import java.util.List;

import com.nhn.error.ErrorCodeSworld;
import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.cms.impls.OrganizationController;
import com.swt.sworld.cms.impls.SubOrganizationController;
import com.swt.sworld.communication.customer.object.MemberFilter;
import com.swt.sworld.communication.customer.object.MoveMemberSubOrg;
import com.swt.sworld.communication.customer.object.OrgCustomerDto;
import com.swt.sworld.communication.customer.object.OrgFilterDto;
import com.swt.sworld.ps.IMoveSubOrganization;
import com.swt.sworld.ps.domain.Member;

/**
 * 
 * @author minh.nguyen
 *
 */
public class MoveSubOrganizationDAO implements IMoveSubOrganization {

	@Override
	public List<OrgCustomerDto> getListSubOrg(OrgFilterDto orgFilter) {
		List<OrgCustomerDto> listOrg = OrganizationController.Instance.getOrgList(orgFilter);

		return listOrg;
	}

	@Override
	public List<Member> getListMemberBySubOrgID(long currentSelectedID, long parentOrgID) {
		List<Member> listMember = new ArrayList<Member>();
		List<SubOrganization> listSubOrg = new ArrayList<SubOrganization>();

		if (parentOrgID == -1) {
			listSubOrg = SubOrganizationController.Instance.getSubOrgListByOrgId(currentSelectedID);
		} else {
			listSubOrg = SubOrganizationController.Instance.getSubOrgByParentId(currentSelectedID);
		}

		if (listSubOrg != null) {
			for (SubOrganization subOrganization : listSubOrg) {
				if (null != subOrganization) {
					List<Member> listSubMember = new ArrayList<Member>();
					MemberFilter filter = new MemberFilter();

					listSubMember = (new MemberDAOImpl()).getBySubOrgId(subOrganization.getSuborgid(), filter);
					if (listSubMember != null && listSubMember.size() > 0) {
						listMember.addAll(listSubMember);
					}
				}
			}
		}

		return listMember;
	}

	@Override
	public int moveSubOrg(long subOrgIdLeft, long subOrgIdRight, List<MoveMemberSubOrg> listMemberIDLeftRight) {
		for (MoveMemberSubOrg moveMember : listMemberIDLeftRight) {
			Member member = MemberController.Instance.getMemberByMemId(moveMember.getMemberID());

			if (moveMember.isLeft()) { // Ben trai
				if (member.getSubOrgId() == subOrgIdLeft) {
					continue;
				}

				// Thay subOrg roi update member
				member.setSubOrgId(subOrgIdLeft);
			} else { // Ben phai
				if (member.getSubOrgId() == subOrgIdRight) {
					continue;
				}

				// Thay subOrg roi update member
				member.setSubOrgId(subOrgIdRight);
			}

			if (HibernateUtil.update(member) != ErrorCodeSworld.SUCCESS) { // Update
				// that
				// bai
				return 0;
			}
		}
		return 1;
	}

}
