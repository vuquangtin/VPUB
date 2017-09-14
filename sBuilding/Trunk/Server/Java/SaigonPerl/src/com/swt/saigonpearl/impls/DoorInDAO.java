package com.swt.saigonpearl.impls;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.saigonpearl.IDoorIn;
import com.swt.saigonpearl.domain.DoorIn;

public class DoorInDAO implements IDoorIn {

	@Override
	public DoorIn insert(DoorIn doorIn) {
		return HibernateUtil.insertObject(doorIn);
	}

	@Override
	public DoorIn update(DoorIn doorIn) {
		return HibernateUtil.updateObject(doorIn);
	}

	@Override
	public int delete(long doorInId) {
		DoorIn doorIn = new DoorIn();
		return HibernateUtil.deleteById(doorIn, doorInId);
	}
	
	@Override
	public DoorIn getDoorInBySerialNumber(String serialNumber, long deviceId) {
		Session session = HibernateUtil.getSession();

		DoorIn result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DoorIn WHERE SerialNumber = :serialNumber AND DeviceDoorId = :deviceId";
			Query query = session.createQuery(strQuery);
			query.setParameter("serialNumber", serialNumber);
			query.setParameter("deviceId", deviceId);
			result = (DoorIn) query.uniqueResult();

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
