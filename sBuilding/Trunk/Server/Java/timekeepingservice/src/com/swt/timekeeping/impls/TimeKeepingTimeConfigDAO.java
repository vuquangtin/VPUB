package com.swt.timekeeping.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.timekeeping.ITimeKeepingTimeConfig;
import com.swt.timekeeping.domain.TimeConfig;
/**
 * TimeKeepingTimeConfigDAO implements ITimeKeepingTimeConfig
 * @author TrangPig
 *
 */
public class TimeKeepingTimeConfigDAO implements ITimeKeepingTimeConfig{

	@Override
	public TimeConfig insert(TimeConfig timeKeepingConfig) {
		return HibernateUtil.insertObject(timeKeepingConfig);
	}

	@Override
	public TimeConfig update(TimeConfig timeKeepingConfig) {
		return HibernateUtil.updateObject(timeKeepingConfig);
	}

	@Override
	public int delete(long timeKeepingConfigId) {
		TimeConfig timeKeepingConfig = new TimeConfig();
		return HibernateUtil.deleteById(timeKeepingConfig, timeKeepingConfigId);
	}

	@Override
	public TimeConfig getTimeKeepingConfigById(
			long timeKeepingConfigId) {
		Session session = HibernateUtil.getSession();

		TimeConfig result = new TimeConfig();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM TimeConfig WHERE Id = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", timeKeepingConfigId);
		
			result = (TimeConfig) query.uniqueResult();
			
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
	public List<TimeConfig> getListTimeKeepingTimeConfigByOrgCode(
			long orgId, String dayOfWeek) {
		Session session = HibernateUtil.getSession();
		List<TimeConfig> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM TimeConfig WHERE orgId = :orgId AND DayOfWeek = :dayofweek";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgId);
			query.setParameter("dayofweek", dayOfWeek);
		
			result =  query.list();
			
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
	public List<TimeConfig> getListTimeKeepingTimeConfigByOrgId(long ordId) {
		Session session = HibernateUtil.getSession();
		List<TimeConfig> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM TimeConfig WHERE orgId = :ordId";
			Query query = session.createQuery(strQuery);
			query.setParameter("ordId", ordId);
		
			result =  query.list();
			
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

	/**
	 * getTimeConfig By DayOfWeek and OrgId
	 */
	@Override
	public TimeConfig getTimeConfigByDayOfWeekOrgId(int dayOfWeek, long orgId) {
		Session session = HibernateUtil.getSession();

		TimeConfig result = new TimeConfig();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM TimeConfig WHERE DayOfWeek = "+dayOfWeek+" AND orgId = "+orgId;
			Query query = session.createQuery(strQuery);
		
			result = (TimeConfig) query.uniqueResult();
			
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
