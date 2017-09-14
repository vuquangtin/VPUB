/**
 * 
 */
package com.swt.sworld.common.impls;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.common.IConfigDAO;
import com.swt.sworld.common.domain.Config;


/**
 * @author sang.do
 *
 */
public class ConfigDAOImpl implements IConfigDAO {

	
	@Override
	public Config addConfig(Config config) {
		return HibernateUtil.insertObject(config);
	
	}

	@Override
	public Config updateConfig(Config config) {
		return HibernateUtil.updateObject(config);
	}

	@Override
	public int deleteConfig(long configId) {
		Config gr = new Config();
		return HibernateUtil.deleteById(gr, configId);
	}
	
	
	@Override
	public Config getValueByName(String name) {
		Session session = HibernateUtil.getSession();
		Config result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Config WHERE Name = :Name";
			Query query = session.createQuery(strQuery);
			query.setParameter("Name", name);
			
			result = (Config) query.uniqueResult();
			
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		}
		finally
		{
			session.close();
		}
		
		return result;
	}

	@Override
	public Config getById(int id) {
		Session session = HibernateUtil.getSession();
		Config result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Config WHERE Id = :id";
			Query query = session.createQuery(strQuery);
			query.setParameter("id", id);
			
			result = (Config) query.uniqueResult();
			
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		}
		finally
		{
			session.close();
		}
		
		return result;
	}

	public Config getValueActiveByName(String keyASecorValue) {
		Session session = HibernateUtil.getSession();
		Config result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Config WHERE Name = :Name AND status = 1";
			Query query = session.createQuery(strQuery);
			query.setParameter("Name", keyASecorValue);
			
			result = (Config) query.uniqueResult();
			
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		}
		finally
		{
			session.close();
		}
		
		return result;
	}
	
	public String getValueActive(String keyASecorValue) {
		Session session = HibernateUtil.getSession();
		Config result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Config WHERE Name = :Name AND status = 1";
			Query query = session.createQuery(strQuery);
			query.setParameter("Name", keyASecorValue);
			
			result = (Config) query.uniqueResult();
			if(result !=null)
				return result.getValue();
			
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		}
		finally
		{
			session.close();
		}
		
		return "";
	}

}
