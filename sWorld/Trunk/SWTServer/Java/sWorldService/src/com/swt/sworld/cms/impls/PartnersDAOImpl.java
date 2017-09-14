package com.swt.sworld.cms.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.cms.IPartnerDAO;
import com.swt.sworld.cms.domain.PartnersOfMaster;

public  class PartnersDAOImpl implements IPartnerDAO {

	@Override
	public List<PartnersOfMaster> getPartnersOfMaster(long masterid) {
		//TODO :implement
		return null;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Long> getPartnersIdOfMaster(long masterid) {
		Session session = HibernateUtil.getSession();
		
		List<Long> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT partnerid FROM PartnersOfMaster WHERE masterid = :masterid";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterid", masterid);
			
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

	@Override
	public int insert(PartnersOfMaster pom) {
		return HibernateUtil.insert(pom);
	}

	@Override
	public int update(PartnersOfMaster pom) {
		return HibernateUtil.update(pom);
	}

	@Override
	public int delete(long id) {
		PartnersOfMaster pom = new PartnersOfMaster();
		return HibernateUtil.deleteById(pom, id);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Long> getAllMasterList() {
		Session session = HibernateUtil.getSession();
		
		List<Long> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT masterid FROM PartnersOfMaster";
			Query query = session.createQuery(strQuery);
			
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

	@SuppressWarnings("unchecked")
	@Override
	public List<Long> getPartnersByFilter(long masterid) {
		Session session = HibernateUtil.getSession();
		
		List<Long> result = null;
		try {
			if(masterid == -1)
			{
				session.getTransaction().begin();
				String strQuery = "SELECT partnerid FROM PartnersOfMaster";
				Query query = session.createQuery(strQuery);
				result = query.list();
			}
			else
			{
			session.getTransaction().begin();
			String strQuery = "SELECT partnerid FROM PartnersOfMaster WHERE masterid = :masterid";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterid", masterid);
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

	@SuppressWarnings("unchecked")
	@Override
	public List<PartnersOfMaster> checkPartnersOfMaster(long masterid,
			long partnerid) {
		Session session = HibernateUtil.getSession();
		
		List<PartnersOfMaster> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM PartnersOfMaster WHERE masterid = :masterid AND partnerid = :partnerid";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterid", masterid);
			query.setParameter("partnerid", partnerid);
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

	@Override
	public long getId(String issuer, String partnercode) {
		Session session = HibernateUtil.getSession();
		
		long result = 0;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT id FROM PartnersOfMaster WHERE issuer = :issuer AND partnercode = :partnercode";
			Query query = session.createQuery(strQuery);
			query.setParameter("issuer", issuer);
			query.setParameter("partnercode", partnercode);
			if(null != query.uniqueResult())
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
	public void deleteAllMaster(String code) {
		Session session = HibernateUtil.getSession();
		
		try {
			session.getTransaction().begin();
			String strQuery = "DELETE FROM PartnersOfMaster WHERE mastercode = :code";
			Query query = session.createQuery(strQuery);
			query.setParameter("code", code);
			query.executeUpdate();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.close();
		}
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<PartnersOfMaster> getByMasterCode(String masterCode) {
		Session session = HibernateUtil.getSession();
		
		List<PartnersOfMaster> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT id FROM PartnersOfMaster WHERE mastercode = :masterCode";
			Query query = session.createQuery(strQuery);
			query.setParameter("masterCode", masterCode);
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
