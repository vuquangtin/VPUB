/**
 * 
 */
package com.swt.sworld.cms.impls;

import java.util.ArrayList;
import java.util.List;

import com.nhn.utilities.Utilities;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.communication.customer.object.OrgFilterDto;
import com.swt.sworld.communication.customer.object.SubOrgCustomerDto;
import com.swt.sworld.communication.customer.object.SubOrgFilterDto;
import com.swt.sworld.ps.impl.MemberController;

/**
 * @author Administrator
 * 
 */
public class SubOrganizationController {

	public static final SubOrganizationController Instance = new SubOrganizationController();

	private SubOrganizationDAOImpl SUBORG = new SubOrganizationDAOImpl();
	// list suborg get by parent

	private SubOrganizationController() {
	}
	public List<SubOrganization> getSubOrgListByOrgId(long orgid) {
		return SUBORG.getSubOrgByOrgId(orgid);
	}
	public List<SubOrgCustomerDto> getSubOrgListDataByOrgId(long orgid) {
		List<SubOrgCustomerDto> lstSubOrgCustomer = new ArrayList<SubOrgCustomerDto>();

		// get sub org
		OrgFilterDto filter = new OrgFilterDto();
		List<SubOrganization> lsOrg = SUBORG.getByOrgId(orgid, filter);
		for (SubOrganization sub : lsOrg) {
			if (sub.getStatus() >= 0) {
				SubOrgCustomerDto temp = new SubOrgCustomerDto();
				temp.setSubOrgId(sub.getSuborgid());
				temp.setOrgId(sub.getOrgid());
				temp.setOrgCode(sub.getOrgcode());
				temp.setName(sub.getNames());
				temp.setOrgShortName(sub.getShortname());
				// ko biet dung de lam gi.Tam thoi dong lai da
				// temp.setSwtGroup(sub.getSwtGroup());
				lstSubOrgCustomer.add(temp);
			}
		}

		return lstSubOrgCustomer;
	}

	public List<SubOrgCustomerDto> getSubOrgListByOrgId(long orgid, SubOrgFilterDto subOrgDto) {
		List<SubOrgCustomerDto> lstSubOrgCustomer = new ArrayList<SubOrgCustomerDto>();
		OrgFilterDto filter = new OrgFilterDto();
		List<SubOrganization> lsOrg = SUBORG.getByOrgId(orgid, filter);
		for (SubOrganization sub : lsOrg) {
			if (sub.getStatus() >= 0) {
				SubOrgCustomerDto temp = new SubOrgCustomerDto();

				temp.setSubOrgId(sub.getSuborgid());
				temp.setOrgId(sub.getOrgid());
				temp.setOrgCode(sub.getOrgcode());
				temp.setName(sub.getNames());
				temp.setOrgShortName(sub.getShortname());
				// khong biet dung de lam gi nen tam thoi dong lai da
				// temp.setSwtGroup(sub.getSwtGroup());
				lstSubOrgCustomer.add(temp);
			}
		}

		return lstSubOrgCustomer;
	}

	public int insertSubOrg(String session, SubOrganization suborg) {
		String user = TokenManager.getInstance().getUserBySession(session);
		if (!"".equals(user)) {
			String date = Utilities.getInstance().currentDateStrDDMMYYYY();

			suborg.setCreatedby(user);
			suborg.setCreatedon(date);
			suborg.setModifiedby(user);
			suborg.setModifiedon(date);
			return SUBORG.insert(suborg);
		}

		return ErrorCode.FALSED;
	}

	public int updateSubOrg(String session, SubOrganization suborg) {
		String user = TokenManager.getInstance().getUserBySession(session);
		if (!"".equals(user)) {
			String date = Utilities.getInstance().currentDateStrDDMMYYYY();
			suborg.setModifiedby(user);
			suborg.setModifiedon(date);
			return SUBORG.update(suborg);
		}

		return ErrorCode.FALSED;

	}

	public int update(SubOrganization subOrg) {
		return SUBORG.update(subOrg);
	}

	public int deleteSubOrg(long suborgid) {
		if (!MemberController.Instance.hasMemberInSubOrg(suborgid)) {
			SubOrganization suborg = SUBORG.getSubOrgById(suborgid);
			return SUBORG.delele(suborg);
		}

		return ErrorCode.FALSED;
	}

	public SubOrganization getSubOrgById(long suborgid) {
		return SUBORG.getSubOrgById(suborgid);
	}

	public SubOrganization getSubOrgByCode(String code) {
		return SUBORG.getSubOrgByCode(code);
	}

	public List<SubOrganization> getSubOrgByOrgId(long orgid, OrgFilterDto filter) {
		List<SubOrganization> lstsub = new ArrayList<SubOrganization>();
		List<SubOrganization> lstsubcheck = SUBORG.getByOrgId(orgid, filter);
		for (SubOrganization subOrganization : lstsubcheck) {
			if (subOrganization.getStatus() == -1) {
				continue;
			} else {
				lstsub.add(subOrganization);
			}
		}
		return lstsub;
	}

	/**
	 * Ham gọi đệ quy lấy list suborg
	 * 
	 * @param result
	 * @param subOrgId
	 */
	public void cycleSubOrgByParentId(List<SubOrganization> result, long subOrgId) {

		List<SubOrganization> lstsubResult = SUBORG.getSubOrgByParentId(subOrgId);

		if (lstsubResult.size() > 0 && lstsubResult != null) {
			for (SubOrganization subOrganization : lstsubResult) {
				if (subOrganization.getStatus() != -1) {
					result.add(subOrganization);
					cycleSubOrgByParentId(result, subOrganization.getSuborgid());
				}
			}
		}
	}

	/**
	 * Lấy list suborg dựa vào suborg id và gọi đệ quy với parentid
	 * 
	 * @param orgId
	 * @return
	 */
	public List<SubOrganization> getSubOrgByParentId(long orgId) {

		List<SubOrganization> lstSubOrganization = new ArrayList<SubOrganization>();
		SubOrganization subOrg = SUBORG.getSubOrgById(orgId);
		lstSubOrganization.add(subOrg);
		List<SubOrganization> lstsubResult = SUBORG.getSubOrgByParentId(orgId);

		if (lstsubResult != null && lstsubResult.size() > 0) {
			for (SubOrganization subOrganization : lstsubResult) {
				if (subOrganization.getStatus() != -1) {
					lstSubOrganization.add(subOrganization);
					cycleSubOrgByParentId(lstSubOrganization, subOrganization.getSuborgid());
				}
			}
		}
		return lstSubOrganization;
	}

	public List<SubOrganization> getSubOrgByOrgIdAndLastId(long orgId, long lastId) {
		return SUBORG.getSubOrgByOrgId(orgId, lastId);
	}

}
