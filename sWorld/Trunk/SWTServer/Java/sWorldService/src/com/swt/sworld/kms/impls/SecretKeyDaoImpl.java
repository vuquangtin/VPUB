package com.swt.sworld.kms.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.kms.ISecretKeyDao;
import com.swt.sworld.kms.domain.SecretKey;

public class SecretKeyDaoImpl implements ISecretKeyDao {

	@SuppressWarnings("unchecked")
	@Override
	public List<SecretKey> getAll() {
		// TODO Auto-generated method stub
		Session session = HibernateUtil.getSession();

		
		List<SecretKey> lsKms = null;
		try {
			session.getTransaction().begin();
			lsKms = session.createQuery("FROM SecretKey").list();

			session.getTransaction().commit();

		} catch (HibernateException e) {
			
				session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}

		return lsKms;
	}

	@Override
	public SecretKey getById(long id) {
		Session session = HibernateUtil.getSession();
		
		SecretKey result = null;
		try {
			session.getTransaction().begin();
			String strquery = "FROM SecretKey WHERE SecretKeyId = :id";
			Query query = session.createQuery(strquery);
			query.setParameter("id", id);

			result = (SecretKey) query.uniqueResult();

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
	public int makePersistence(SecretKey kms) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public int updateStatus(int id, boolean newStatus) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public int delete(int id) {
		// TODO Auto-generated method stub
		return 0;
	}
}
