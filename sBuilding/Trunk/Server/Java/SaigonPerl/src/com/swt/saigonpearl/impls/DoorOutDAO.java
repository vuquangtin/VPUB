package com.swt.saigonpearl.impls;

import java.util.List;






import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.saigonpearl.IDoorOut;
import com.swt.saigonpearl.domain.DoorOut;
import com.swt.saigonpearl.domain.DoorOutFilterDto;

public class DoorOutDAO implements IDoorOut{

	@Override
	public DoorOut insert(DoorOut doorOut) {
		return HibernateUtil.insertObject(doorOut);
	}

	@Override
	public DoorOut update(DoorOut doorOut) {
		return HibernateUtil.updateObject(doorOut);
	}

	@Override
	public int delete(long doorOutId) {
		DoorOut doorOut = new DoorOut();
		return HibernateUtil.deleteById(doorOut, doorOutId);
	}
	
	@Override
	public DoorOut getDoorOutById(long doorOutId) {
		Session session = HibernateUtil.getSessionFactory().openSession();

		DoorOut result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DoorOut WHERE Id = :doorOutId";
			Query query = session.createQuery(strQuery);
			query.setParameter("doorOutId", doorOutId);
			result = (DoorOut) query.uniqueResult();

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
	
	@Override
	public DoorOut getDoorOutBySerialNumber(String serialNumber,long deviceId, int status) {
		Session session = HibernateUtil.getSession();

		DoorOut result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM DoorOut WHERE SerialNumber = :serialNumber AND DeviceDoorId = :deviceId AND Status=:status";
			Query query = session.createQuery(strQuery);
			query.setParameter("serialNumber", serialNumber);
			query.setParameter("deviceId", deviceId);
			query.setParameter("status", status);
			result = (DoorOut) query.uniqueResult();

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
	public List<DoorOut> getDoorOutByFilter(DoorOutFilterDto dto) {
		Session session = HibernateUtil.getSession();
		
		List<DoorOut> lstAtt= null;
		
		try
		{
			String result = dto.clone();
			if(result == "")
			{
				session.getTransaction().begin();
				String strQuery = "FROM DoorOut";
				Query query = session.createQuery(strQuery);
				lstAtt = query.list();
				session.getTransaction().commit();
			}
			else
			{
				session.getTransaction().begin();
				String strQuery = "FROM DoorOut WHERE "+ result;
				Query query = session.createQuery(strQuery);
				lstAtt = query.list();
			}
		}
		catch(HibernateException ex)
		{
			session.getTransaction().rollback();
			ex.printStackTrace();
		}
		finally
		{
			session.flush();
			session.clear();
			session.close();
		}
		
		return lstAtt;
	}

}
