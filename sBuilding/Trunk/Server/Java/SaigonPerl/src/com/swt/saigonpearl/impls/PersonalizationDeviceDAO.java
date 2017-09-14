package com.swt.saigonpearl.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.saigonpearl.IPersonalizationDevice;
import com.swt.saigonpearl.domain.PersonalizationDevice;

public class PersonalizationDeviceDAO implements IPersonalizationDevice {

	@Override
	public PersonalizationDevice insert(PersonalizationDevice personalizationDevice) {
		return HibernateUtil.insertObject(personalizationDevice);
	}

	@Override
	public PersonalizationDevice update(PersonalizationDevice personalizationDevice) {
		return HibernateUtil.updateObject(personalizationDevice);
	}

	@Override
	public int delete(long personalizationDeviceId) {
		PersonalizationDevice personalizationDevice = new PersonalizationDevice();
		return HibernateUtil.deleteById(personalizationDevice, personalizationDeviceId);
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<PersonalizationDevice> getPersonalizationDevices() {
		Session session = HibernateUtil.getSession();

		List<PersonalizationDevice> personalizationDevice = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM PersonalizationDevice";
			Query query = session.createQuery(strQuery);
			personalizationDevice = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return personalizationDevice;
	}

	@Override
	public PersonalizationDevice getPersonalizationDeviceById(long personalizationDeviceId) {
		Session session = HibernateUtil.getSession();

		PersonalizationDevice personalizationDevice = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM PersonalizationDevice WHERE personalizationDeviceId = :personalizationDeviceId";
			Query query = session.createQuery(strQuery);
			query.setParameter("personalizationDeviceId", personalizationDeviceId);
			personalizationDevice = (PersonalizationDevice) query.uniqueResult();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return personalizationDevice;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List<PersonalizationDevice> getListPersonalizationDevices(String deviceip,
			String serialNumber) {
		Session session = HibernateUtil.getSession();

		List<PersonalizationDevice> personalizationDevice = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM PersonalizationDevice where deviceip = :deviceip and serialnumber = :serialNumber";
			Query query = session.createQuery(strQuery);
			query.setParameter("deviceip", deviceip);
			query.setParameter("serialNumber", serialNumber);
			personalizationDevice = query.list();
			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}
		return personalizationDevice;
	}
}
