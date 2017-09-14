package com.swt.timekeeping.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.timekeeping.ITimeKeepingColorConfig;
import com.swt.timekeeping.domain.ColorConfig;

/**
 * TimeKeepingColorConfigDAO implements ITimeKeepingColorConfig
 * 
 * @author minh.nguyen
 *
 */
public class TimeKeepingColorConfigDAO implements ITimeKeepingColorConfig {

	@Override
	public ColorConfig insertColorConfig(ColorConfig cConfig) {
		return HibernateUtil.insertObject(cConfig);
	}

	@Override
	public ColorConfig updateColorConfig(ColorConfig cConfig) {
		return HibernateUtil.updateObject(cConfig);
	}

	@Override
	public ColorConfig getColorConfigById(long colorConfigId) {
		Session session = HibernateUtil.getSession();
		ColorConfig cConfig = new ColorConfig();

		try {
			session.beginTransaction();
			String strQuery = "FROM ColorConfig WHERE colorConfigId = :id";
			Query query = session.createQuery(strQuery);

			query.setParameter("id", colorConfigId);
			cConfig = (ColorConfig) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cConfig;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<ColorConfig> getColorConfigList() {
		Session session = HibernateUtil.getSession();
		List<ColorConfig> listColorConfig = null;

		try {
			session.beginTransaction();
			String strQuery = "FROM ColorConfig";
			Query query = session.createQuery(strQuery);

			listColorConfig = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return listColorConfig;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<ColorConfig> getColorConfigListByOrgId(long orgId) {
		Session session = HibernateUtil.getSession();
		List<ColorConfig> listColorConfig = null;

		try {
			session.beginTransaction();
			String strQuery = "FROM ColorConfig WHERE orgId = :id";
			Query query = session.createQuery(strQuery);

			query.setParameter("id", orgId);
			listColorConfig = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return listColorConfig;
	}
}
