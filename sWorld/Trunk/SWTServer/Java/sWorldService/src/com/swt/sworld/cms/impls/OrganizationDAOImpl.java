/**
 * 
 */
package com.swt.sworld.cms.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.cms.IOrganizationDAO;
import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.communication.customer.object.OrgFilterDto;
import com.swt.sworld.utilites.SworldConst;

/**
 * @author loc.le
 * 
 */
public class OrganizationDAOImpl implements IOrganizationDAO {

	@SuppressWarnings("unchecked")
	@Override
	public List<Organization> getAll(OrgFilterDto filter) {
		// TODO Auto-generated method stub
		Session session = HibernateUtil.getSession();

		
		List<Organization> lsOrg = null;
		try {
			String search = filter.clone();
			if (search == "") {
				session.getTransaction().begin();
				lsOrg = session.createQuery("FROM Organization").list();
			} else {
				session.getTransaction().begin();
				String strQuery = "FROM Organization WHERE " + search;
				Query query = session.createQuery(strQuery);
				lsOrg = query.list();
			}
			session.getTransaction().commit();

		} catch (HibernateException e) {
			
				session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return lsOrg;
	}

	@Override
	public Organization getById(long id, OrgFilterDto filter) {
		Session session = HibernateUtil.getSession();
		Transaction transaction = null;
		Organization result = null;
		try {
			String search = filter.clone();
			if (search == "") {
				transaction = session.beginTransaction();
				String strQuery = "FROM Organization WHERE OrgId=:id";
				Query query = session.createQuery(strQuery);
				query.setParameter("id", id);
				result = (Organization) query.uniqueResult();
			} else {
				transaction = session.beginTransaction();
				String strQuery = "FROM Organization WHERE OrgId=:id" + search;
				Query query = session.createQuery(strQuery);
				query.setParameter("id", id);
				result = (Organization) query.uniqueResult();
			}

			transaction.commit();
		} catch (HibernateException e) {
			transaction.rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return result;
	}

	@Override
	public int makePersistence(Organization org) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public int updateStatus(int id, boolean newStatus) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public int delete(Organization org) {
		org.setStatus(-1);
		return HibernateUtil.update(org);
	}

	@Override
	public Organization getOrgByIssuerCode(String code) {
		Session session = HibernateUtil.getSessionFactory().openSession();
		Transaction transaction = null;
		Organization result = null;
		try {
			transaction = session.beginTransaction();
			String strQuery = "FROM Organization WHERE Issuer=:code";
			Query query = session.createQuery(strQuery);
			query.setParameter("code", code);

			result = (Organization) query.uniqueResult();

			transaction.commit();
		} catch (HibernateException e) {
			transaction.rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return result;
	}

	@Override
	public long getSecrectKeyId(long id) {
		// TODO Auto-generated method stub
		Session session = HibernateUtil.getSession();

		
		long result = -1;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT secretkeyid FROM Organization WHERE OrgId=:id";
			Query query = session.createQuery(strQuery);
			query.setParameter("id", id);
			result = (Long) query.uniqueResult();
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
	public Organization addOrgObj(Organization org) {
		return HibernateUtil.insertObject(org);
	}
	
//	@Override
//	public int addOrg(Organization org) {
//		return HibernateUtil.insert(org);
//	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Organization> getOrgIssuerList() {
		Session session = HibernateUtil.getSession();
		
		List<Organization> lsOrg = null;
		try {

			session.getTransaction().begin();
			String strQuery = "FROM Organization WHERE Issuer <> :issuer";
			Query query = session.createQuery(strQuery);
			query.setParameter("issuer", SworldConst.NOTMASTER);
			lsOrg = query.list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			
				session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return lsOrg;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Organization> getAllOrgList() {
		Session session = HibernateUtil.getSession();

		
		List<Organization> lsOrg = null;
		try {

			session.getTransaction().begin();
			lsOrg = session.createQuery("FROM Organization").list();
			session.getTransaction().commit();

		} catch (HibernateException e) {
			
				session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return lsOrg;
	}

	@Override
	public Organization getOrgByPartnerCode(String code, OrgFilterDto filter) {
		Session session = HibernateUtil.getSession();
		Transaction transaction = null;
		Organization result = null;
		try {
			String search = filter.clone();
			if(search == "")
			{
			transaction = session.beginTransaction();
			String strQuery = "FROM Organization WHERE OrgCode=:code";
			Query query = session.createQuery(strQuery);
			query.setParameter("code", code);
			result = (Organization) query.uniqueResult();
			}
			else
			{
				transaction = session.beginTransaction();
				String strQuery = "FROM Organization WHERE OrgCode=:code"+search;
				Query query = session.createQuery(strQuery);
				query.setParameter("code", code);
				result = (Organization) query.uniqueResult();
			}

			transaction.commit();
		} catch (HibernateException e) {
			transaction.rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return result;
	}

	@Override
	public Organization getById(long id) {
		Session session = HibernateUtil.getSession();
		Transaction transaction = null;
		Organization result = null;
		try {
				transaction = session.beginTransaction();
				String strQuery = "FROM Organization WHERE OrgId=:id";
				Query query = session.createQuery(strQuery);
				query.setParameter("id", id);
				result = (Organization) query.uniqueResult();

			transaction.commit();
		} catch (HibernateException e) {
			transaction.rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return result;
	}

	@Override
	public Organization getByOrgCode(String orgCode) {
		Session session = HibernateUtil.getSession();
		Transaction transaction = null;
		Organization result = null;
		try {
			transaction = session.beginTransaction();
			String strQuery = "FROM Organization WHERE OrgCode=:orgCode";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgCode", orgCode);
			result = (Organization) query.uniqueResult();
			transaction.commit();
		} catch (HibernateException e) {
			transaction.rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
		return result;
	}

}
