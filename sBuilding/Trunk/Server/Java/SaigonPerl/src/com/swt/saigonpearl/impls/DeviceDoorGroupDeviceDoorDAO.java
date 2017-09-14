package com.swt.saigonpearl.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.saigonpearl.IDeviceDoorGroupDeviceDoor;
import com.swt.saigonpearl.domain.DeviceDoorGroupDeviceDoor;

/*
 * 
 */
public class DeviceDoorGroupDeviceDoorDAO implements IDeviceDoorGroupDeviceDoor {

	@Override
	public DeviceDoorGroupDeviceDoor insert(
			DeviceDoorGroupDeviceDoor doorGroupDeviceDoor) {
		return HibernateUtil.insertObject(doorGroupDeviceDoor);
	}

	@Override
	public int delete(long doorGroupDeviceDoorId) {
		DeviceDoorGroupDeviceDoor doorGroupDeviceDoor = new DeviceDoorGroupDeviceDoor();
		return HibernateUtil.deleteById(doorGroupDeviceDoor, doorGroupDeviceDoorId);
	}
	
	@SuppressWarnings("unchecked")
	@Override
	public List<DeviceDoorGroupDeviceDoor> getListDeviceDoorGroupDeviceDoorByGroupId(
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

	/* delete record has role id and groupid equals
	 * 	 * @see com.swt.saigonpearl.IDeviceDoorGroupDeviceDoor#deleteDevice(long, long)
	 */
	@Override
	public void deleteDevice(long deviceId, long groupId) {
		Session session = HibernateUtil.getSession();

		try {
			session.getTransaction().begin();
			String strQuery = "DELETE DeviceDoorGroupDeviceDoor WHERE devicedoorid = :deviceId and devicedoorgroupid = :groupId";
			Query query = session.createQuery(strQuery);
			query.setParameter("deviceId", deviceId);
			query.setParameter("groupId", groupId);
			query.executeUpdate();
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

	
	
}
