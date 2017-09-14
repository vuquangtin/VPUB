package com.swt.timekeeping.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.timekeeping.ITimeKeepingDeviceConfig;
import com.swt.timekeeping.domain.DeviceConfig;

/**
 * TimeKeepingDeviceConfigDAO implements ITimeKeepingDeviceConfig
 * 
 * @author TrangPig
 *
 */
public class TimeKeepingDeviceConfigDAO implements ITimeKeepingDeviceConfig {

	@Override
	public DeviceConfig insert(DeviceConfig timeKeepingConfig) {
		return HibernateUtil.insertObject(timeKeepingConfig);
	}

	@Override
	public DeviceConfig update(DeviceConfig timeKeepingConfig) {
		return HibernateUtil.updateObject(timeKeepingConfig);
	}

	@Override
	public int delete(long timeKeepingConfigId) {
		DeviceConfig timeKeepingConfig = new DeviceConfig();
		return HibernateUtil.deleteById(timeKeepingConfig, timeKeepingConfigId);
	}
	@Override
	public DeviceConfig getDeviceConfigById(long deviceConfigId) {
		Session session = HibernateUtil.getSession();

		DeviceConfig deviceConfig = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceConfig WHERE id = :deviceConfigId";
			Query query = session.createQuery(strQuery);
			query.setParameter("deviceConfigId", deviceConfigId);
			deviceConfig = (DeviceConfig) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return deviceConfig;
	}
	@Override
	public DeviceConfig getTimeKeepingConfigById(long timeKeepingConfigId) {
		Session session = HibernateUtil.getSession();

		DeviceConfig result = new DeviceConfig();
		
		try {
			session.getTransaction().begin();
			String strQuery = "FROM TimeKeepingDeviceConfig WHERE configdeviceid = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", timeKeepingConfigId);

			result = (DeviceConfig) query.uniqueResult();
				
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
	public List<DeviceConfig> getListDeviceConfigByOrgId(
			long orgId) {
		Session session = HibernateUtil.getSession();
		List<DeviceConfig> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceConfig WHERE orgId = :orgId";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgId);
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

	@SuppressWarnings("unchecked")
	@Override
	public List<DeviceConfig> getTimeKeepingConfigByIp(String timeKeepingConfigIp) {
		Session session = HibernateUtil.getSession();
		List<DeviceConfig> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceConfig WHERE ip = :ip";
			Query query = session.createQuery(strQuery);
			query.setParameter("ip", timeKeepingConfigIp);
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
