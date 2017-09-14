/**
 * 
 */
package com.swt.sworld.cms.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.cms.ISubOrganizationDAO;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.communication.customer.object.OrgFilterDto;

/**
 * @author Administrator
 * 
 */
public class SubOrganizationDAOImpl implements ISubOrganizationDAO {

	@SuppressWarnings("unchecked")
	@Override
	public List<SubOrganization> getByOrgId(long orgid, OrgFilterDto filter) {
		Session session = HibernateUtil.getSession();

		List<SubOrganization> result = null;
		try {
			if (orgid != -1) {
				String search = (null != filter) ? filter.clone() : "";
				if (search == "") {
					session.getTransaction().begin();
					String strQuery = "FROM SubOrganization WHERE orgid = :orgid";
					Query query = session.createQuery(strQuery);
					query.setParameter("orgid", orgid);
					result = query.list();
				} else {
					session.getTransaction().begin();
					String strQuery = "FROM SubOrganization WHERE orgid = :orgid" + search;
					Query query = session.createQuery(strQuery);
					query.setParameter("orgid", orgid);
					result = query.list();
				}
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM SubOrganization";
				Query query = session.createQuery(strQuery);
				result = query.list();
			}
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return result;
	}

	@Override
	public int insert(SubOrganization suborg) {
		return HibernateUtil.insert(suborg);
	}

	@Override
	public int update(SubOrganization suborg) {
		return HibernateUtil.update(suborg);
	}

	@Override
	public int delele(SubOrganization suborg) {
		suborg.setStatus(-1);
		return HibernateUtil.update(suborg);
	}

	@Override
	public SubOrganization getSubOrgById(long id) {
		Session session = HibernateUtil.getSession();

		SubOrganization result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM SubOrganization WHERE suborgid = :id";
			Query query = session.createQuery(strQuery);
			query.setParameter("id", id);
			result = (SubOrganization) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return result;
	}

	@Override
	public SubOrganization getSubOrgByCode(String code) {
		Session session = HibernateUtil.getSession();

		SubOrganization result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM SubOrganization WHERE orgcode = :code AND status <> -1";
			Query query = session.createQuery(strQuery);
			query.setParameter("code", code);
			result = (SubOrganization) query.uniqueResult();
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
	public List<SubOrganization> getSubOrgByOrgId(long orgId, long lastId) {
		Session session = HibernateUtil.getSession();

		List<SubOrganization> result = null;
		try {
			if (lastId != 0) {
				session.getTransaction().begin();
				String strQuery = "FROM SubOrganization WHERE orgid = :orgId AND suborgid > :lastId";
				Query query = session.createQuery(strQuery);
				query.setParameter("orgId", orgId);
				query.setParameter("lastId", lastId);
				result = query.list();
				session.getTransaction().commit();
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM SubOrganization WHERE orgid = :orgId";
				Query query = session.createQuery(strQuery);
				query.setParameter("orgId", orgId);
				result = query.list();
				session.getTransaction().commit();
			}
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
	public List<SubOrganization> getSubOrgByOrgId(long id) {
		Session session = HibernateUtil.getSession();

		List<SubOrganization> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM SubOrganization WHERE orgid = :orgid";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgid", id);
			result = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return result;
	}

	/*
	 * lây danh sach to chuc con dua vao suborgid va goi de quy
	 * 
	 * @see com.swt.sworld.cms.ISubOrganizationDAO#getSubOrgByParentId(long)
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<SubOrganization> getSubOrgByParentId(long orgId) {
		Session session = HibernateUtil.getSession();

		List<SubOrganization> result = null;
		try {

			session.getTransaction().begin();
			String strQuery = "FROM SubOrganization WHERE parentorgid = :orgId";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgId);
			result = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return result;
	}
	
}
