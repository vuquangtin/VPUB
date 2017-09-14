/**
 * 
 */
package com.swt.sworld.ams.impls;
import java.util.List;

import org.apache.commons.lang3.RandomStringUtils;
import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.sworld.ams.IApp;
import com.swt.sworld.ams.domain.App;

/**
 * @author loc.le
 *
 */
public class AppDAOImpl implements IApp {

	@Override
	public int insert(App application) {
		String alias = RandomStringUtils.randomNumeric(2);
		byte ali = Byte.parseByte(alias);
		application.setAlias(ali);
		return HibernateUtil.insert(application);
	}

	@Override
	public int update(App application) {
		return HibernateUtil.update(application);
	}

	@Override
	public int delete(long id) {
		App app = new App();
		return HibernateUtil.deleteById(app, id);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<App> getall() {
		Session session = HibernateUtil.getSession();
		
		List<App> lstapp= null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM App";
			Query query = session.createQuery(strQuery);
			lstapp = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return lstapp;
	}

	@Override
	public App selectByAppId(long appId) {
		Session session = HibernateUtil.getSession();
		
		App cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM App WHERE Id = :appId";
			Query query = session.createQuery(strQuery);
			query.setParameter("appId", appId);
			cp = (App) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		}
		finally
		{
			session.flush();
			session.clear();
			session.close();
		}
		
		return cp;
	}
}
