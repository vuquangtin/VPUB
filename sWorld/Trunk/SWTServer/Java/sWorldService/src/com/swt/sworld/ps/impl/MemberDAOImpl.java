/**
 * 
 */
package com.swt.sworld.ps.impl;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.error.ErrorCodeSworld;
import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.communication.customer.object.MemberFilter;
import com.swt.sworld.communication.customer.object.PersoChipFilter;
import com.swt.sworld.ps.IMemberDAO;
import com.swt.sworld.ps.domain.Member;

/**
 * @author Administrator
 * 
 */
public class MemberDAOImpl implements IMemberDAO {

	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getBySubOrgId(long subOrgId, MemberFilter memberFilter) {
		Session session = HibernateUtil.getSession();
		// //20170603 BUG 705 thêm filter để lọc dữ liệu Ten Nguyen Start
		List<Member> result = null;
		try {
			String search = memberFilter.clone();
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE SubOrgId = :subOrgId";
				Query query = session.createQuery(strQuery);
				query.setParameter("subOrgId", subOrgId);
				result = query.list();
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE SubOrgId = :subOrgId"
						+ search;
				Query query = session.createQuery(strQuery);
				query.setParameter("subOrgId", subOrgId);
				result = query.list();
			}
			// //20170603 BUG 705 thêm filter để lọc dữ liệu Ten Nguyen End
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getByOrgId(long OrgId, PersoChipFilter filter) {
		Session session = HibernateUtil.getSession();

		List<Member> result = null;
		try {
			String search = filter.cloneMember();
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE OrgId = :OrgId";
				Query query = session.createQuery(strQuery);
				query.setParameter("OrgId", OrgId);
				result = query.list();
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE OrgID = :OrgId" + search;
				Query query = session.createQuery(strQuery);
				query.setParameter("OrgId", OrgId);
				result = query.list();
			}
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getMemberByOrgAndSub(long orgId, long subOrgId,
			PersoChipFilter filter) {
		Session session = HibernateUtil.getSession();

		List<Member> result = null;
		try {
			String search = filter.cloneMember();
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE OrgID = :orgId AND SubOrgId = :subOrgId";
				Query query = session.createQuery(strQuery);
				query.setParameter("orgId", orgId);
				query.setParameter("subOrgId", subOrgId);
				result = query.list();
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE OrgID = :orgId AND SubOrgId = :subOrgId"
						+ search;
				Query query = session.createQuery(strQuery);
				query.setParameter("orgId", orgId);
				query.setParameter("subOrgId", subOrgId);
				result = query.list();
			}
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Long> getListMemberIdByOrgAndSub(long orgId, long subOrgId,
			PersoChipFilter filter) {
		Session session = HibernateUtil.getSession();

		List<Long> result = null;
		try {
			String search = filter.cloneMember();
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "SELECT Id FROM Member WHERE OrgID = :orgId AND SubOrgId = :subOrgId";
				Query query = session.createQuery(strQuery);
				query.setParameter("orgId", orgId);
				query.setParameter("subOrgId", subOrgId);
				result = query.list();
			} else {
				session.getTransaction().begin();
				String strQuery = "SELECT Id FROM Member WHERE OrgID = :orgId AND SubOrgId = :subOrgId"
						+ search;
				Query query = session.createQuery(strQuery);
				query.setParameter("orgId", orgId);
				query.setParameter("subOrgId", subOrgId);
				result = query.list();
			}

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getMemberBySubOrgId(long subOrgId) {
		Session session = HibernateUtil.getSession();

		List<Member> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Member WHERE SubOrgId = :subOrgId";
			Query query = session.createQuery(strQuery);
			query.setParameter("subOrgId", subOrgId);
			result = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	@Override
	public Member getMembeByMemberid(long memberid) {
		Session session = HibernateUtil.getSession();

		Member result = new Member();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Member WHERE Id = :memberid";
			Query query = session.createQuery(strQuery);
			query.setParameter("memberid", memberid);

			result = (Member) query.uniqueResult();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	@Override
	public Member getMemberByCode(long orgid, String code) {
		Session session = HibernateUtil.getSession();

		Member result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Member WHERE Code = :code AND OrgID = :orgid";
			Query query = session.createQuery(strQuery);
			query.setParameter("code", code);
			query.setParameter("orgid", orgid);
			result = (Member) query.uniqueResult();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return result;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getByOrgIdMember(long OrgId, MemberFilter filter) {
		Session session = HibernateUtil.getSession();

		List<Member> result = null;
		try {
			String search = filter.clone();
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE OrgId = :OrgId";
				Query query = session.createQuery(strQuery);
				query.setParameter("OrgId", OrgId);
				result = query.list();
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE OrgId = :OrgId" + search;
				Query query = session.createQuery(strQuery);
				query.setParameter("OrgId", OrgId);
				result = query.list();
			}
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getMemberByOrgAndSubMember(long orgId, long subOrgId,
			MemberFilter filter) {
		Session session = HibernateUtil.getSession();

		List<Member> result = null;
		try {
			if (filter == null) {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE OrgID = :orgId AND SubOrgId = :subOrgId";
				Query query = session.createQuery(strQuery);
				query.setParameter("orgId", orgId);
				query.setParameter("subOrgId", subOrgId);
				result = query.list();
			} else {
				String search = filter.clone();
				if (search == "" || search == null) {
					session.getTransaction().begin();
					String strQuery = "FROM Member WHERE OrgID = :orgId AND SubOrgId = :subOrgId";
					Query query = session.createQuery(strQuery);
					query.setParameter("orgId", orgId);
					query.setParameter("subOrgId", subOrgId);
					result = query.list();
				} else {
					session.getTransaction().begin();
					String strQuery = "FROM Member WHERE OrgID = :orgId AND SubOrgId = :subOrgId"
							+ search;
					Query query = session.createQuery(strQuery);
					query.setParameter("orgId", orgId);
					query.setParameter("subOrgId", subOrgId);
					result = query.list();
				}
			}

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	@Override
	public int insertMember(Member mem) {
		return HibernateUtil.insert(mem);
	}

	@Override
	public int updateMember(Member mem) {
		return HibernateUtil.update(mem);
	}

	@Override
	public int deleteMember(long memid) {
		Member mem = new Member();
		return HibernateUtil.deleteById(mem, memid);
	}

	@Override
	public Member getMemberByInfo(String hashcode, String birthday,
			String location, int sex, String telephone, String username,
			String deviceid) {
		Session session = HibernateUtil.getSession();

		Member result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Member WHERE HashCode = :hashcode AND BirthDate = :birthday"
					+ " AND PermanentAddress = :location AND Gender = :sex AND PhoneNo = :telephone"
					+ " AND LowerFullName = :username AND Position = :deviceid";
			Query query = session.createQuery(strQuery);
			query.setParameter("hashcode", hashcode);
			query.setParameter("birthday", birthday);
			query.setParameter("location", location);
			query.setParameter("sex", sex);
			query.setParameter("telephone", telephone);
			query.setParameter("username", username);
			query.setParameter("deviceid", deviceid);

			result = (Member) query.uniqueResult();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	@Override
	public long getMemberIdByCode(String token) {
		long result = ErrorCodeSworld.FALSED_VALUE;
		Member member = getMemberByCode(token);
		if (null != member)
			result = member.getId();

		return result;
	}

	public Member getMemberByCode(String token) {
		Session session = HibernateUtil.getSession();
		Member result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Member WHERE Code = :code";
			Query query = session.createQuery(strQuery);
			query.setParameter("code", token);
			result = (Member) query.uniqueResult();

			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getAllMember() {
		Session session = HibernateUtil.getSession();
		List<Member> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Member";
			Query query = session.createQuery(strQuery);
			result = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	@Override
	public Member getMemberByNameAndPhone(String fullName, String phone) {
		Session session = HibernateUtil.getSession();
		Member result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Member WHERE LowerFullName LIKE '%"
					+ fullName + "%' AND PhoneNo = :phone";
			Query query = session.createQuery(strQuery);
			query.setParameter("phone", phone);
			result = (Member) query.uniqueResult();

			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	@Override
	public Member getMemberByPhone(String phone) {
		Session session = HibernateUtil.getSession();
		Member result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Member WHERE PhoneNo = :phone";
			Query query = session.createQuery(strQuery);
			query.setParameter("phone", phone);
			result = (Member) query.uniqueResult();

			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getAlListMemberFilter(long OrgId, String area,
			int gender, String search) {
		Session session = HibernateUtil.getSession();

		// VourcherGiftCard vg = new VourcherGiftCard();
		// String search = new VourcherGiftCard().clone();

		List<Member> result = null;
		if (search != "") {
			try {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE " + search;
				Query query = session.createQuery(strQuery);

				result = query.list();

				session.getTransaction().commit();
			} catch (HibernateException e) {
				session.getTransaction().rollback();
				e.printStackTrace();
			} finally {
				session.flush();
				session.clear();
				session.close();
			}
		} else {
			return null;
		}
		return result;
	}

	@Override
	public boolean hasInSubOrg(long suborgId) {
		Session session = HibernateUtil.getSession();

		long result = -1;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT COUNT(*) FROM Member WHERE SubOrgId = :subOrgId";
			Query query = session.createQuery(strQuery);
			query.setParameter("subOrgId", suborgId);

			result = (long) query.uniqueResult();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result <= 0 ? false : true;
	}

	/*
	 * get list member by org for config timekeeping every user
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getByOrgId(long orgId) {
		Session session = HibernateUtil.getSession();
		List<Member> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Member WHERE OrgId = :orgid";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgid", orgId);
			result = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	/*
	 * getMemberBySubOrg filter by PersoChipFilter
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getMemberBySubOrgAndPersoChipFilter(long subOrgId,
			PersoChipFilter filter) {

		Session session = HibernateUtil.getSession();
		List<Member> result = null;
		try {
			String search = filter.clone();
			if (search == "") {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE SubOrgId = :subOrgId";
				Query query = session.createQuery(strQuery);
				query.setParameter("subOrgId", subOrgId);
				result = query.list();
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM Member WHERE SubOrgId = :subOrgId"
						+ search;
				Query query = session.createQuery(strQuery);
				query.setParameter("subOrgId", subOrgId);
				result = query.list();
			}
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	/**
	 * getMember By suborg, start-end
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getMemberBytotalCount(List<SubOrganization> subOrgList,
			MemberFilter filter, int start, int length) {
		Session session = HibernateUtil.getSession();
		// //10052017 thong ke Trang Vo Start
		List<Member> result = null;
		int size = subOrgList.size();
		String checkSubOrg = " WHERE ( SubOrgId = "
				+ subOrgList.get(0).getSuborgid();
		for (int i = 1; i < size; i++) {
			checkSubOrg += " OR SubOrgId = " + subOrgList.get(i).getSuborgid();
		}
		checkSubOrg += " ) ";
		// get tu database
		try {
			// filter
			String search = filter.clone();

			// begin
			session.getTransaction().begin();

			// query
			String strQuery = "FROM Member" + checkSubOrg
					+ " AND ( Title <> :Title OR Title = :TtNull ) " + search;
			Query query = session.createQuery(strQuery);
			query.setParameter("Title", MemberController.TITLE_BAO_CHI);
			query.setParameter("TtNull", null);
			query.setFirstResult(start);
			query.setMaxResults(length);

			// get list
			result = query.list();

			// //10052017 thong ke Trang Vo End

			// commit
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	/**
	 * get By OrgId, By start-end
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getByOrgIdBytotalCount(long orgId, MemberFilter filter,
			int start, int length) {
		// //10052017 thong ke Trang Vo Start
		Session session = HibernateUtil.getSession();
		List<Member> result = null;
		try {
			// filter
			String search = filter.clone();

			// begin
			session.getTransaction().begin();

			// query
			String strQuery = "FROM Member WHERE OrgId = :orgid AND ( Title <> :Title OR Title = :TtNull ) "
					+ search;
			Query query = session.createQuery(strQuery);
			query.setParameter("orgid", orgId);
			query.setParameter("Title", MemberController.TITLE_BAO_CHI);
			query.setParameter("TtNull", null);
			query.setFirstResult(start);
			query.setMaxResults(length);

			// get list
			result = query.list();

			// commit
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		// //10052017 thong ke Trang Vo End
		return result;
	}

	/**
	 * get total count by orgid
	 */
	@Override
	public long getTotalMemberByOrgId(long selectrdOrg, MemberFilter filter) {
		Session session = HibernateUtil.getSession();

		long result = -1;
		try {
			String search = filter.clone();

			session.getTransaction().begin();

			// query
			String strQuery = "SELECT COUNT(*) FROM Member WHERE OrgId = :orgid "
					+ search;
			Query query = session.createQuery(strQuery);
			query.setParameter("orgid", selectrdOrg);

			// get count
			result = (long) query.uniqueResult();

			// commit
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return result;
	}

	/**
	 * get total by list suborg
	 */
	@Override
	public long getTotalMemberByListSubOrg(long selectrdOrg,
			List<SubOrganization> listSubOrg, MemberFilter filter) {

		Session session = HibernateUtil.getSession();

		long result = -1;
		try {
			String search = filter.clone();

			session.getTransaction().begin();

			// create query by suborg
			int size = listSubOrg.size();
			String checkSubOrg = " WHERE ( SubOrgId = "
					+ listSubOrg.get(0).getSuborgid();
			for (int i = 1; i < size; i++) {
				checkSubOrg += " OR SubOrgId = "
						+ listSubOrg.get(i).getSuborgid();
			}
			checkSubOrg += " ) ";

			// get tu database
			String strQuery = "SELECT COUNT(*) FROM Member " + checkSubOrg
					+ search;
			Query query = session.createQuery(strQuery);

			// get count
			result = (long) query.uniqueResult();

			// commit
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return result;
	}

	/**
	 * get all member not journalist
	 * - orgId = -1: get all 
	 * - orgId != -1: get member by orgId
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Member> getAllMemberNotJournalist(long orgId,
			MemberFilter filter, String title) {
		// //10052017 thong ke Trang Vo Start
		Session session = HibernateUtil.getSession();
		List<Member> result = null;
		try {
			// filter
			String search = filter.clone();

			// begin
			session.getTransaction().begin();

			// query

			// kiem tra orgid = -1
			if (orgId == -1) {
				String strQuery = "FROM Member WHERE Title <> :Title OR Title = :TtNull "
						+ search;
				Query query = session.createQuery(strQuery);
				query.setParameter("Title", title);
				query.setParameter("TtNull", null);

				// get list
				result = query.list();

			} else {
				String strQuery = "FROM Member WHERE OrgId = :orgid AND ( Title <> :Title OR Title = :TtNull ) "
						+ search;
				Query query = session.createQuery(strQuery);
				query.setParameter("orgid", orgId);
				query.setParameter("Title", title);
				query.setParameter("TtNull", null);

				// get list
				result = query.list();
			}

			// commit
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		// //10052017 thong ke Trang Vo End
		return result;
	}
}
