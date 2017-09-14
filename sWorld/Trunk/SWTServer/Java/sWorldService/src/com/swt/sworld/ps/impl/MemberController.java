/**
 * 
 */
package com.swt.sworld.ps.impl;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import com.nhn.utilities.HibernateUtil;
import com.nhn.utilities.Utilities;
import com.swt.sworld.cms.domain.CardChip;
import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.cms.impls.CardChipDAOImpl;
import com.swt.sworld.cms.impls.CardMagneticDAOImpl;
import com.swt.sworld.cms.impls.OrganizationDAOImpl;
import com.swt.sworld.cms.impls.SubOrganizationController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.communication.customer.object.CardMagneticFilterDto;
import com.swt.sworld.communication.customer.object.MemberCustomerDTO;
import com.swt.sworld.communication.customer.object.MemberFilter;
import com.swt.sworld.communication.customer.object.MemberMagneticPersoDTO;
import com.swt.sworld.communication.customer.object.PersoCardCustomerDTO;
import com.swt.sworld.communication.customer.object.PersoChipFilter;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.domain.MagneticPersonalization;
import com.swt.sworld.ps.domain.Member;

/**
 * @author Administrator
 *
 */
public class MemberController implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 991484174336291251L;

	public static final String TITLE_BAO_CHI = "Nhà báo";
	
	public static final MemberController Instance = new MemberController();
	private ChipPersonalizationDAOImpl CHIPPERSODAO = new ChipPersonalizationDAOImpl();
	private MemberDAOImpl MEMDAO = new MemberDAOImpl();
	private CardChipDAOImpl CARDCHIPDAO = new CardChipDAOImpl();
	private MagneticPersonalizationDAOImpl MAGNETICPERSODAO = new MagneticPersonalizationDAOImpl();
	private CardMagneticDAOImpl MAGNETICDAO = new CardMagneticDAOImpl();
	private OrganizationDAOImpl ORGDAO = new OrganizationDAOImpl();

	private MemberController() {

	}

	public Member getMemberById(long memberid) {
		// TODO: implement with memberfilter
		return MEMDAO.getMembeByMemberid(memberid);
	}

	public List<Member> getMemberListDataByOrgId(long orgid, MemberFilter filter) {
		// TODO: implement with memberfilter
		return MEMDAO.getByOrgIdMember(orgid, filter);
	}

	/**
	 * 
	 * @param orgid
	 * @param suborgid
	 * @param filter
	 * @param flag
	 *            : true --> get all member ; false ---> get member has card
	 * @return
	 */
	// private List<MemberCustomerDTO> getMemberByOrgIdSubOrgId(long orgid, long
	// suborgid, MemberFilter filter, boolean flag)
	// {
	// List<MemberCustomerDTO> result = new ArrayList<MemberCustomerDTO>();
	// List<Member> lstMember = null;
	// if(orgid < 0)
	// {
	// lstMember = MEMDAO.getByOrgIdMember(suborgid, filter);
	// }
	// else if(suborgid < 0)
	// {
	// lstMember = MEMDAO.getByOrgIdMember(orgid, filter);
	// }
	// else
	// {
	// lstMember = MEMDAO.getMemberByOrgAndSubMember(orgid, suborgid, filter);
	// }
	// for (Member member : lstMember) {
	// if(member.getActive()){
	// ChipPersonalization chiperso =
	// CHIPPERSODAO.getChipPersoforPersoCusMember(member.getId());
	// MemberCustomerDTO memcusdto = new MemberCustomerDTO(member);
	// if(chiperso != null)
	// {
	// CardChip cardChip =
	// CARDCHIPDAO.getCardChipById(chiperso.getCardChipId());
	// if(cardChip == null)
	// {
	// memcusdto.setPersoCard(null);
	// result.add(memcusdto);
	// continue;
	// }
	// PersoCardCustomerDTO persoDTO = new
	// PersoCardCustomerDTO(chiperso.getChipPersoId(), chiperso.getCardChipId(),
	// chiperso.getSerialNumber(), chiperso.getCreatedOn(),
	// chiperso.getExpirationDate(), cardChip.getLogicalStatus(),
	// cardChip.getPhysicalStatus(), chiperso.getNotes(), chiperso.getStatus());
	// memcusdto.setPersoCard(persoDTO);
	// result.add(memcusdto);
	// }
	// else
	// {
	// memcusdto.setPersoCard(null);
	// result.add(memcusdto);
	// }
	// }
	// }
	//
	// return result;
	// }
	/**
	 * get list meber by org Sua lai voi menu nhieu cap
	 * 
	 * @param orgid
	 * @param parentOrgID
	 *            id parent
	 * @param filter
	 * @param flag
	 * @return
	 */
	private List<MemberCustomerDTO> getMemberByOrgIdSubOrgId(long orgid,
			long parentOrgID, MemberFilter filter, boolean flag) {
		List<SubOrganization> listSubOrg = new ArrayList<SubOrganization>();
		List<MemberCustomerDTO> result = new ArrayList<MemberCustomerDTO>();
		List<Member> lstMember = new ArrayList<Member>();
		// get list suborg before get list member
		if (parentOrgID == -1) {
			listSubOrg = SubOrganizationController.Instance
					.getSubOrgListByOrgId(orgid);
		} else {
			listSubOrg = SubOrganizationController.Instance
					.getSubOrgByParentId(orgid);
		}
		if (listSubOrg != null) {
			for (SubOrganization subOrganization : listSubOrg) {
				List<Member> listMember = new ArrayList<Member>();
				// // 20170603 BUG 705 thêm filter để lọc dữ liệu Ten Nguyen
				// // Start
				// listMember =
				// MEMDAO.getBySubOrgId(subOrganization.getSuborgid());
				listMember = MEMDAO.getBySubOrgId(
						subOrganization.getSuborgid(), filter);
				// // 20170603 BUG 705 thêm filter để lọc dữ liệu Ten Nguyen End
				if (listMember != null && listMember.size() > 0) {
					lstMember.addAll(listMember);
				}
			}
		}
		if (lstMember != null) {
			for (Member member : lstMember) {
				if (member.getActive()) {
					ChipPersonalization chiperso = CHIPPERSODAO
							.getChipPersoforPersoCusMember(member.getId());
					MemberCustomerDTO memcusdto = new MemberCustomerDTO(member);
					if (chiperso != null) {
						CardChip cardChip = CARDCHIPDAO
								.getCardChipById(chiperso.getCardChipId());
						if (cardChip == null) {
							memcusdto.setPersoCard(null);
							result.add(memcusdto);
							continue;
						}
						PersoCardCustomerDTO persoDTO = new PersoCardCustomerDTO(
								chiperso.getChipPersoId(),
								chiperso.getCardChipId(),
								chiperso.getSerialNumber(),
								chiperso.getCreatedOn(),
								chiperso.getExpirationDate(),
								cardChip.getLogicalStatus(),
								cardChip.getPhysicalStatus(),
								chiperso.getNotes(), chiperso.getStatus());
						memcusdto.setPersoCard(persoDTO);
						result.add(memcusdto);
					} else {
						memcusdto.setPersoCard(null);
						result.add(memcusdto);
					}
				}

			}
		}
		return result;
	}

	// private List<MemberCustomerDTO> getMemberByOrgIdSubOrgIdPerso(long orgid,
	// long suborgid, PersoChipFilter filter,
	// boolean flag) {
	// PersoCardCustomerDTO hardcode = null;
	// int logical = 0;
	// int physical = 0;
	// List<MemberCustomerDTO> result = new ArrayList<MemberCustomerDTO>();
	// List<Member> lstMember = null;
	//
	// System.out.println("orgid=" + orgid + "suorgid=" + suborgid);
	//
	// if (suborgid < 0) {
	// lstMember = MEMDAO.getByOrgId(orgid, filter);
	// } else {
	// lstMember = MEMDAO.getMemberByOrgAndSub(orgid, suborgid, filter);
	// }
	//
	// System.out.println("member =" + lstMember.size());
	// for (Member member : lstMember) {
	//
	// // create member cuisomer dto
	// MemberCustomerDTO memcusdto = new MemberCustomerDTO(member);
	//
	// ChipPersonalization chiperso =
	// CHIPPERSODAO.getChipPersoforPersoCus(member.getId(), filter);
	//
	// if (null == chiperso) {
	// System.out.println("chiperso = null");
	//
	// continue;
	// } else {
	// CardChip cc =
	// CARDCHIPDAO.getLogicAndPhyByCardId(chiperso.getCardChipId());
	// if (null == cc) {
	// System.out.println("CardChip = null");
	// continue;
	// } else {
	//
	// System.out.println("11111");
	// logical = cc.getLogicalStatus();
	// physical = cc.getPhysicalStatus();
	// hardcode = new PersoCardCustomerDTO(chiperso.getChipPersoId(),
	// chiperso.getCardChipId(),
	// chiperso.getSerialNumber(), chiperso.getPersoDate(),
	// chiperso.getExpirationDate(), logical,
	// physical, chiperso.getNotes(), chiperso.getStatus());
	//
	// System.out.println("hardcode");
	//
	// memcusdto.setPersoCard(hardcode);
	// }
	// }
	//
	// result.add(memcusdto);
	//
	// }
	//
	// return result;
	// }
	/**
	 * Get danh sách member Sửa lại với menu nhiều cấp
	 * 
	 * @param orgid
	 * @param suborgid
	 * @param filter
	 * @param flag
	 * @return
	 */
	private List<MemberCustomerDTO> getMemberByOrgIdSubOrgIdPerso(long orgid,
			long parentOrgId, PersoChipFilter filter, boolean flag) {
		List<SubOrganization> listSubOrg = new ArrayList<SubOrganization>();
		List<Member> lstMember = new ArrayList<Member>();
		List<MemberCustomerDTO> result = new ArrayList<MemberCustomerDTO>();
		// get list suborg before get list member
		if (parentOrgId == -1) {
			listSubOrg = SubOrganizationController.Instance
					.getSubOrgListByOrgId(orgid);
		} else {
			listSubOrg = SubOrganizationController.Instance
					.getSubOrgByParentId(orgid);
		}
		// get list member by list suborg
		if (listSubOrg != null) {
			for (SubOrganization subOrganization : listSubOrg) {
				List<Member> listMember = new ArrayList<Member>();
				// tam thoi chưa dùng tới nên để fillter là null
				listMember = MEMDAO.getMemberBySubOrgAndPersoChipFilter(
						subOrganization.getSuborgid(), filter);
				if (listMember != null && listMember.size() > 0) {
					lstMember.addAll(listMember);
				}
			}
		}
		// 20170703 #Bug675 Them cac string search vao object search Ten nguyen
		// Start
		if (lstMember != null) {
			for (Member member : lstMember) {
				if (member.getActive()) {
					// create member cuisomer dto
					MemberCustomerDTO memcusdto = new MemberCustomerDTO(member);
					ChipPersonalization chiperso = CHIPPERSODAO
							.getChipPersoforPersoCusMember(member.getId());

					if (chiperso != null) {
						CardChip cardChip = CARDCHIPDAO
								.getCardChipById(chiperso.getCardChipId());
						if (cardChip == null) {
							memcusdto.setPersoCard(null);
							result.add(memcusdto);
							continue;
						}
						PersoCardCustomerDTO persoDTO = new PersoCardCustomerDTO(
								chiperso.getChipPersoId(),
								chiperso.getCardChipId(),
								chiperso.getSerialNumber(),
								chiperso.getCreatedOn(),
								chiperso.getExpirationDate(),
								cardChip.getLogicalStatus(),
								cardChip.getPhysicalStatus(),
								chiperso.getNotes(), chiperso.getStatus());
						memcusdto.setPersoCard(persoDTO);
						result.add(memcusdto);
					} else {
						memcusdto.setPersoCard(null);
						result.add(memcusdto);
					}
					// 20170703 #Bug675 Them cac string search vao object search
					// Ten nguyen End
				}
			}
		}

		return result;
	}

	// /**
	// * get member has card
	// *
	// * @param orgid
	// * @param suborgid
	// * @param filter
	// * @return
	// */
	// public List<MemberCustomerDTO> getMemberListBySubOrgId(long orgid, long
	// suborgid, PersoChipFilter filter) {
	// return getMemberByOrgIdSubOrgIdPerso(orgid, suborgid, filter, false);
	// }
	/**
	 * sua lai voi menu nhiều cấp org
	 * 
	 * @param orgid
	 * @param parentOrgId
	 *            id parent của đối tượng select
	 * @param filter
	 * @return
	 */
	public List<MemberCustomerDTO> getMemberListBySubOrgId(long orgid,
			long parentOrgId, PersoChipFilter filter) {
		return getMemberByOrgIdSubOrgIdPerso(orgid, parentOrgId, filter, false);
	}

	public List<MemberCustomerDTO> getMemberListBySub(long orgid,
			long suborgid, MemberFilter filter) {
		return getMemberByOrgIdSubOrgId(orgid, suborgid, filter, true);
	}

	/**
	 * 
	 * @param orgid
	 * @param suborgid
	 * @param cardmagneticfilter
	 * @param flag
	 *            : true --> get all member ; false ---> get member has card
	 * @return
	 */
	public List<MemberMagneticPersoDTO> getMemberMagneticList(long orgid,
			long suborgid, CardMagneticFilterDto cardmagneticfilter,
			boolean flag) {
		List<MemberMagneticPersoDTO> lstMemberMagnetic = new ArrayList<MemberMagneticPersoDTO>();
		Member member = null;

		// get list card magnetic of org or suborg from swtgp_cms_cardmagnetic
		List<Long> listcardid = MAGNETICDAO.getMemberPersoByfilter(orgid,
				suborgid, cardmagneticfilter);

		for (Long long1 : listcardid) {
			MagneticPersonalization magicPer = MAGNETICPERSODAO
					.getByFilter(long1);
			if (null != magicPer && magicPer.getMemberId() > 0) {
				// get Member by memberid
				member = MEMDAO.getMembeByMemberid(magicPer.getMemberId());

			}
			MemberMagneticPersoDTO obj = new MemberMagneticPersoDTO(member,
					magicPer);
			lstMemberMagnetic.add(obj);
		}

		return lstMemberMagnetic;
	}

	public List<MemberMagneticPersoDTO> getMemBerListMagnetic(long orgid,
			long suborgid, CardMagneticFilterDto cardmagneticfilter) {
		return getMemberMagneticList(orgid, suborgid, cardmagneticfilter, false);
	}

	public int updateMemberActive(Member mem) {
		String date = Utilities.getInstance().currentDateStrDDMMYYYY();
		mem.setModifiedDate(date);
		return MEMDAO.updateMember(mem);
	}

	public int deleteMember(long memid) {
		Member mem = MEMDAO.getMembeByMemberid(memid);
		mem.setActive(false);
		return HibernateUtil.update(mem);
	}

	public List<Member> getMemberBySubOrgId(long subOrgId) {
		return MEMDAO.getMemberBySubOrgId(subOrgId);
	}

	public Member getMemberByMemId(long memid) {
		return MEMDAO.getMembeByMemberid(memid);
	}

	public Member getMemberBygInfo(String activecode, String birthday,
			String location, int sex, String telephone, String username,
			String deviceid) {
		return MEMDAO.getMemberByInfo(activecode, birthday, location, sex,
				telephone, username, deviceid);
	}

	public long getMemberIdByCode(String token) {
		return MEMDAO.getMemberIdByCode(token);
	}

	public Member getMemberByCode(String token) {
		return MEMDAO.getMemberByCode(token);
	}

	public Member getMemberByCode(long orgId, String code) {
		return MEMDAO.getMemberByCode(orgId, code);
	}

	public List<Member> getAllMember() {
		return MEMDAO.getAllMember();
	}

	public Member getMemberByNameAndPhone(String fullName, String phone) {
		return MEMDAO.getMemberByNameAndPhone(fullName, phone);
	}

	public Member getMemberByPhone(String phone) {
		return MEMDAO.getMemberByPhone(phone);
	}

	public boolean hasMemberInSubOrg(long suborgid) {
		return MEMDAO.hasInSubOrg(suborgid);
	}

	public int insertMember(Member mem) {
		long orgid = mem.getOrgId();
		if (orgid <= 0)
			return ErrorCode.FALSED;

		Organization org = ORGDAO.getById(orgid);
		if (null == org)
			return ErrorCode.FALSED;

		mem.setOrgCode(org.getOrgCode());
		mem.setActive(true);

		String fullname = mem.getFirstName() + mem.getLastName();
		mem.setLowerFullName(fullname);

		String date = Utilities.getInstance().currentDateStrDDMMYYYY();
		mem.setCreatedDate(date);
		mem.setModifiedDate(date);
		int kq = 0;
		kq = MEMDAO.insertMember(mem);
		if (kq != 0)
			return ErrorCode.FALSED;

		return ErrorCode.SUCCESS;
	}

	public int updateMember(Member mem) {
		String fullname = mem.getFirstName() + mem.getLastName();
		mem.setLowerFullName(fullname);
		String date = Utilities.getInstance().currentDateStrDDMMYYYY();
		mem.setModifiedDate(date);
		int kq = 0;
		kq = MEMDAO.updateMember(mem);
		if (kq != 0)
			return ErrorCode.FALSED;

		return ErrorCode.SUCCESS;
	}

	public List<Member> insertMember(List<Member> listmem) {
		List<Member> result = new ArrayList<Member>();
		for (Member mem : listmem) {
			if (insertMember(mem) == ErrorCode.FALSED) {
				result.add(mem);
				break;
			}

		}
		return result;
	}

	public List<Member> getListMemberByOrgId(long orgId) {
		return MEMDAO.getByOrgId(orgId);
	}

	/**
	 * getMemberBytotalCount
	 * 
	 * @param selectrdOrg
	 * @param parentSelectedOrg
	 *            : neu parentSelectedOrg == -1 => selectrdOrg: orgID
	 * @param filter
	 * @param start
	 * @param length
	 * @return
	 */
	public List<Member> getMemberBytotalCount(long selectrdOrg,
			long parentSelectedOrg, MemberFilter filter, int start, int length) {
		List<SubOrganization> listSubOrg = new ArrayList<SubOrganization>();
		List<Member> listMember = new ArrayList<Member>();
		// //10052017 thong ke Trang Vo Start

		// get theo orgId
		if (parentSelectedOrg == -1) {
			listMember = MEMDAO.getByOrgIdBytotalCount(selectrdOrg, filter,
					start, length);
		} else {
			// get theo subOrgId
			listSubOrg = SubOrganizationController.Instance
					.getSubOrgByParentId(selectrdOrg);
			if (listSubOrg != null) {
				listMember = MEMDAO.getMemberBytotalCount(listSubOrg, filter,
						start, length);
			}
		}
		// //10052017 thong ke Trang Vo End
		return listMember;
	}

	/**
	 * get total member
	 * 
	 * @param selectrdOrg
	 * @param parentSelectedOrg
	 * @param filter
	 * @return
	 */
	public long getTotalMember(long selectrdOrg, long parentSelectedOrg,
			MemberFilter filter) {

		long count = 0;
		// get theo orgId
		if (parentSelectedOrg == -1) {
			count = MEMDAO.getTotalMemberByOrgId(selectrdOrg, filter);
		} else {
			// get theo subOrgId
			List<SubOrganization> listSubOrg = SubOrganizationController.Instance
					.getSubOrgByParentId(selectrdOrg);
			if (listSubOrg != null) {
				count = MEMDAO.getTotalMemberByListSubOrg(selectrdOrg,
						listSubOrg, filter);
			}
		}
		return count;

	}
	
	/**
	 * get all member not Journalist
	 * @param orgId = -1: get all
	 * 		  orgId != -1: get member by orgId
	 * @param filter
	 * @return
	 */
	public List<Member> getAllMemberNotJournalist(long orgId, MemberFilter filter){
		return MEMDAO.getAllMemberNotJournalist(orgId, filter, TITLE_BAO_CHI);
	}
}
