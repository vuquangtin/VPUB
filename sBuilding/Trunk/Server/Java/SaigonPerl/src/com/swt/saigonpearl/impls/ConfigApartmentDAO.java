package com.swt.saigonpearl.impls;

import java.util.ArrayList;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.saigonpearl.ISaiGonpearlConfigApartment;
import com.swt.saigonpearl.domain.ConfigApartment;

public class ConfigApartmentDAO implements ISaiGonpearlConfigApartment{

	@Override
	public ConfigApartment insertApartment(ConfigApartment config) {
		return HibernateUtil.insertObject(config);
	}
	
	@Override
	public ConfigApartment updateConfigApartment(ConfigApartment config){
		return HibernateUtil.updateObject(config);
	}

	@Override
	public int deleteConfigApartment(long configId) {
		ConfigApartment config = new ConfigApartment();
		return HibernateUtil.deleteById(config, configId);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<ConfigApartment> getAllConfigApartment() {
		Session session = HibernateUtil.getSession();

		List<ConfigApartment> result = new ArrayList<ConfigApartment>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ConfigApartment WHERE Status = :status";
			Query query = session.createQuery(strQuery);
			query.setParameter("status", 0);
			
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
	public ConfigApartment getConfigByConfigId(long configId) {
		Session session = HibernateUtil.getSession();

		ConfigApartment result = new ConfigApartment();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ConfigApartment WHERE Id = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", configId);
		
			result = (ConfigApartment) query.uniqueResult();
			
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
