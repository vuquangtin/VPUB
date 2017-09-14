/**
 * 
 */
package com.swt.sworld.cms.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.cms.IAcquirerDAO;
import com.swt.sworld.cms.domain.Acquirer;

/**
 * @author Administrator
 * 
 */
public class AcquirerDAOImpl implements IAcquirerDAO {

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * com.swt.sworld.cms.interfaces.IAcquirerDAO#Insert(com.swt.sworld.cms.
	 * domain.Acquirer)
	 */
	@Override
	public int insert(Acquirer ac) {
		return HibernateUtil.insert(ac);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * com.swt.sworld.cms.interfaces.IAcquirerDAO#Update(com.swt.sworld.cms.
	 * domain.Acquirer)
	 */
	@Override
	public int update(Acquirer ac) {

		return HibernateUtil.update(ac);

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.swt.sworld.cms.interfaces.IAcquirerDAO#Delete(int)
	 */
	@Override
	public int delete(long Id) {
		Acquirer ac = new Acquirer();
		return HibernateUtil.deleteById(ac, Id);
	}

	@Override
	public Acquirer getAcquirerById(long acId) {
		Session session = HibernateUtil.getSession();

		Acquirer ac = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Acquirer WHERE AcquirerId = :acId";
			Query query = session.createQuery(strQuery);
			query.setParameter("acId", acId);
			ac = (Acquirer) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return ac;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Acquirer> check(String acquirerCode, String accessCode) {
		Session session = HibernateUtil.getSession();

		List<Acquirer> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Acquirer WHERE AcquierMasterCode = :acquirerCode AND AccessCode = :accessCode";
			Query query = session.createQuery(strQuery);
			query.setParameter("acquirerCode", acquirerCode);
			query.setParameter("accessCode", accessCode);
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
	public Acquirer getId(String acquirerCode, String accessCode) {
		Session session = HibernateUtil.getSession();

		Acquirer result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Acquirer WHERE AcquierMasterCode = :acquirerCode AND AccessCode = :accessCode";
			Query query = session.createQuery(strQuery);
			query.setParameter("acquirerCode", acquirerCode);
			query.setParameter("accessCode", accessCode);
			result = (Acquirer) query.uniqueResult();

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
	public List<Acquirer> getall() {
		Session session = HibernateUtil.getSession();

		List<Acquirer> ac = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Acquirer";
			Query query = session.createQuery(strQuery);
			ac = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return ac;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<String> getPartnerByMasterCode(String masterCode) {
		Session session = HibernateUtil.getSession();

		List<String> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT AccessCode FROM Acquirer WHERE AcquierMasterCode = :masterCode";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterCode", masterCode);
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
	public void deleteAllMaster(String code) {
		Session session = HibernateUtil.getSession();

		try {
			session.getTransaction().begin();
			String strQuery = "DELETE FROM Acquirer WHERE AcquierMasterCode = :code";
			Query query = session.createQuery(strQuery);
			query.setParameter("code", code);
			query.executeUpdate();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Acquirer> getByMasterCode(String masterCode) {
		Session session = HibernateUtil.getSession();

		List<Acquirer> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Acquirer WHERE AcquierMasterCode = :masterCode";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterCode", masterCode);
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
}
