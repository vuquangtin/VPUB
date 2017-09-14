package com.swt.saigonpearl.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.saigonpearl.ISaiGonpearlManagerCosts;
import com.swt.saigonpearl.domain.ManagerCosts;


public class ManagerCostsDAO implements ISaiGonpearlManagerCosts{
	

	public int deleteManagerCostsID(long configId) {
		ManagerCosts config = new ManagerCosts();
		return HibernateUtil.deleteById(config, configId);
	}

	
	
	public int RemoveAllManagerCosts(List<ManagerCosts> lstManagerCosts)
	{
		int ResultTypeInt = 1;	
		if(lstManagerCosts.size() == 0)
			return ResultTypeInt;
		for (ManagerCosts mn : lstManagerCosts)
		{
			if(mn.getId() > 0)
			{
				ResultTypeInt =  deleteManagerCostsID(mn.getId());
			}
		}
		
		return ResultTypeInt;
	}

	@Override
	public ManagerCosts insert(ManagerCosts managerCosts) {
		return HibernateUtil.insertObject(managerCosts);
	}

	@Override
	public ManagerCosts update(ManagerCosts managerCosts) {
		return HibernateUtil.updateObject(managerCosts);
	}

	@Override
	public int delete(long managerCostsId) {
		ManagerCosts managerCosts = new ManagerCosts();
		return HibernateUtil.deleteById(managerCosts, managerCostsId);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	public List<ManagerCosts> getAllManagerCosts() {
		
		Session session = HibernateUtil.getSessionFactory().openSession();
		
		List<ManagerCosts> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ManagerCosts";
			Query query = session.createQuery(strQuery);
			//query.setParameter("status", 0);
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
	public ManagerCosts GetManagerCost(String subOrgCode) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void updateManagerCostBySubOrgCode(String subOrgCode) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		try {
			session.getTransaction().begin();
			String strQuery = "UPDATE ManagerCosts set Active = :active "  + "WHERE SubOrgCode = :subOrgCode";
			Query query = session.createQuery(strQuery);
			query.setParameter("active", 0);
			query.setParameter("subOrgCode", subOrgCode);
			
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
	
	public ManagerCosts getManagerCostBySubOrgId(long subOrgId) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		ManagerCosts result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ManagerCosts WHERE Active = :active and SubOrgId = :subOrgId";
			Query query = session.createQuery(strQuery);
			query.setParameter("active", true);
			query.setParameter("subOrgId", subOrgId);
			result = (ManagerCosts) query.uniqueResult();

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
	public List<ManagerCosts> getManagerCostAllBySubOrgId(long subOrgId) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		List<ManagerCosts> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ManagerCosts WHERE SubOrgId = :subOrgId";
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
}
