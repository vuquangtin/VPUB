package com.swt.saigonpearl.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.saigonpearl.IDeviceDoorGroup;
import com.swt.saigonpearl.domain.DeviceDoorGroup;
import com.swt.saigonpearl.domain.DeviceDoorGroupDeviceDoor;

/*
 * 
 */
public class DeviceDoorGroupDAO implements IDeviceDoorGroup {

	@Override
	public DeviceDoorGroup insert(DeviceDoorGroup doorGroup) {

		return HibernateUtil.insertObject(doorGroup);
	}

	@Override
	public DeviceDoorGroup update(DeviceDoorGroup doorGroup) {
		return HibernateUtil.updateObject(doorGroup);
	}

	@Override
	public int delete(long doorGroupId) {
		DeviceDoorGroup doorGroup = new DeviceDoorGroup();
		return HibernateUtil.deleteById(doorGroup, doorGroupId);
	}

	@Override
	public DeviceDoorGroup getDeviceDoorGroupById(long doorGroupId) {
		Session session = HibernateUtil.getSession();
		DeviceDoorGroup deviceDoorGroup = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceDoorGroup WHERE devicedoorgroupid = :doorGroupId";
			Query query = session.createQuery(strQuery);
			query.setParameter("doorGroupId", doorGroupId);
			deviceDoorGroup = (DeviceDoorGroup) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return deviceDoorGroup;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.swt.saigonpearl.IDeviceDoorGroup#getDeviceDoorGroup()
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<DeviceDoorGroup> getDeviceDoorGroup() {
		Session session = HibernateUtil.getSession();

		List<DeviceDoorGroup> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceDoorGroup";
			Query query = session.createQuery(strQuery);
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
	public List<DeviceDoorGroupDeviceDoor> getListDeviceGroupDeviceByGroupId(
			long deviceDoorGroupId) {
		Session session = HibernateUtil.getSession();
		List<DeviceDoorGroupDeviceDoor> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DeviceDoorGroupDeviceDoor WHERE devicedoorgroupid = :deviceDoorGroupId";
			Query query = session.createQuery(strQuery);
			query.setParameter("deviceDoorGroupId", deviceDoorGroupId);
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
