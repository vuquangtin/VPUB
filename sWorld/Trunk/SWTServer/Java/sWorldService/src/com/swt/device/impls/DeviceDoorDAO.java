package com.swt.device.impls;


import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.device.IDeviceDoor;
import com.swt.sworld.device.domain.DeviceDoor;
/**
 * @author Tenit
 *
 */
public class DeviceDoorDAO implements IDeviceDoor {

	@Override
	public DeviceDoor insert(DeviceDoor deviceDoor) {
		return HibernateUtil.insertObject(deviceDoor);
	}

	@Override
	public DeviceDoor update(DeviceDoor deviceDoor) {
		return HibernateUtil.updateObject(deviceDoor);
	}

	@Override
	public int delete(long deviceDoorId) {
		DeviceDoor deviceDoor = new DeviceDoor();
		return HibernateUtil.deleteById(deviceDoor, deviceDoorId);
	}


	@Override
	public DeviceDoor getDeviceDoorId(long deviceDoorId) {
		Session session = HibernateUtil.getSession();

		DeviceDoor cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceDoor WHERE Id = :deviceDoorId";
			Query query = session.createQuery(strQuery);
			query.setParameter("deviceDoorId", deviceDoorId);
			cp = (DeviceDoor) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cp;
	}

	@Override
	public DeviceDoor getDeviceDoorByIp(String ip) {
		Session session = HibernateUtil.getSession();

		DeviceDoor cp = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceDoor WHERE Ip = :ip";
			Query query = session.createQuery(strQuery);
			query.setParameter("ip", ip);
			cp = (DeviceDoor) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return cp;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<DeviceDoor> getByOrgIdDevice(long OrgId) {

		Session session = HibernateUtil.getSession();

		List<DeviceDoor> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceDoor WHERE OrgId = :OrgId";
			Query query = session.createQuery(strQuery);
			query.setParameter("OrgId", OrgId);
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
	public List<DeviceDoor> getBySubOrgIdDevice(long subOrgId) {

		Session session = HibernateUtil.getSession();

		List<DeviceDoor> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceDoor WHERE SubOrgId = :subOrgId";
			Query query = session.createQuery(strQuery);
			query.setParameter("SubOrgId", subOrgId);
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
	public List<DeviceDoor> getDeviceOrgAndSubDevice(long orgId, long subOrgId) {
		Session session = HibernateUtil.getSession();

		List<DeviceDoor> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceDoor WHERE OrgID = :orgId AND SubOrgId = :subOrgId";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgId);
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

	@SuppressWarnings("unchecked")
	@Override
	public List<DeviceDoor> getDeviceDoorList() {
		Session session = HibernateUtil.getSession();

		List<DeviceDoor> deviceDoorList = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceDoor";
			Query query = session.createQuery(strQuery);
			deviceDoorList = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return deviceDoorList;

	}

	
	
}
