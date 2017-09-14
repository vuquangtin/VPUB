package com.swt.timekeeping.impls;

import java.util.Date;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.timekeeping.ITimeKeepingShift;
import com.swt.timekeeping.customer.object.ShiftFilter;
import com.swt.timekeeping.domain.Shift;
/**
 * TimeKeepingShiftDAO implements ITimeKeepingShift
 * @author TrangPig
 *
 */
public class TimeKeepingShiftDAO implements ITimeKeepingShift {

	@Override
	public Shift insert(Shift timeKeepingShift) {
		return HibernateUtil.insertObject(timeKeepingShift);
	}

	@Override
	public Shift update(Shift timeKeepingShift) {
		return HibernateUtil.updateObject(timeKeepingShift);
	}

	@Override
	public int delete(long timeKeepingShiftId) {
		Shift timeKeepingShift = new Shift();
		return HibernateUtil.deleteById(timeKeepingShift, timeKeepingShiftId);
	}

	@Override
	public Shift getTimeKeepingShiftById(long timeKeepingShiftId) {
		Session session = HibernateUtil.getSession();

		Shift result = new Shift();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM timekeepingshift WHERE timekeepingid = :id";
			Query query = session.createQuery(strQuery);
			query.setParameter("id", timeKeepingShiftId);
		
			result = (Shift) query.uniqueResult();
			
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
	public List<Shift> getShiftByFilter(ShiftFilter shiftFilter) {
Session session = HibernateUtil.getSession();
		
		List<Shift> lstAtt= null;
		
		try
		{
			String result = shiftFilter.clone();
			if(result == "")
			{
				session.getTransaction().begin();
				// ORDER BY dateIn ASC de sap xep thoi gian tang dan
				String strQuery = "FROM Shift ORDER BY dateIn ASC";
				Query query = session.createQuery(strQuery);
				lstAtt = query.list();
				session.getTransaction().commit();
			}
			else
			{
				session.getTransaction().begin();
				// ORDER BY dateIn ASC de sap xep thoi gian tang dan
				String strQuery = "FROM Shift WHERE "+ result + " ORDER BY dateIn ASC";
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

	@SuppressWarnings("unchecked")
	@Override
	public List<Shift> getShift(Date dateBegin, Date dateEnd, String listMemberId, long orgId, long subOrgId) {
		Session session = HibernateUtil.getSession();

		List<Shift> lstAtt = null;
		try {
			session.getTransaction().begin();
//			String strQuery = "Call GetShift(:dateBegin, :dateEnd, :listMemberId, :orgId, :subOrgId)";
//			Query query = session.createSQLQuery(strQuery);
			Query query = session.getNamedQuery("getShift");
			query.setParameter("dateBegin", dateBegin);
			query.setParameter("dateEnd", dateEnd);
			query.setParameter("listMemberId", listMemberId);
			query.setParameter("orgId", orgId);
			query.setParameter("subOrgId", subOrgId);
		
			lstAtt = query.list();

			session.getTransaction().commit();
		} catch (HibernateException e) {
			session.getTransaction().rollback();
			e.printStackTrace();
		} finally {
			session.flush();
			session.clear();
			session.close();
		}

		return lstAtt;
	}
	
}
