/**
 * 
 */
package com.swt.attendance.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.attendance.IAttendance;
import com.swt.attendance.domain.Attendance;
import com.swt.sworld.customer.object.AttendanceFilterDto;

/**
 * @author Administrator
 *
 */
public class AttendanceDAO implements IAttendance {

	/* (non-Javadoc)
	 * @see com.swt.sattendance.IAttendance#insert(com.swt.sattendance.domain.Attendance)
	 */
	@Override
	public Attendance insert(Attendance att) {
		return HibernateUtil.insertObject(att);
	}

	/* (non-Javadoc)
	 * @see com.swt.sattendance.IAttendance#update(com.swt.sattendance.domain.Attendance)
	 */
	@Override
	public Attendance update(Attendance att) {
		return HibernateUtil.updateObject(att);
	}

	/* (non-Javadoc)
	 * @see com.swt.sattendance.IAttendance#delete(long)
	 */
	@Override
	public int delete(long idAtt) {
		Attendance att = new Attendance();
		return HibernateUtil.deleteById(att, idAtt);
	}

	/* (non-Javadoc)
	 * @see com.swt.sattendance.IAttendance#GetAttendanceByMemberIdAndDateOut(long, java.lang.String)
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Attendance> GetAttendanceByMemberIdAndDateOut(long memberId,
			String dateOut) {
		Session session = HibernateUtil.getSession();
		
		List<Attendance> lstAtt= null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Attendance WHERE MemberId=:memberId AND DateOut=:dateOut";
			Query query = session.createQuery(strQuery);
			query.setParameter("memberId", memberId);
			query.setParameter("dateOut", dateOut);
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

	/* (non-Javadoc)
	 * @see com.swt.sattendance.IAttendance#GetAttendanceByMemberId(long)
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Attendance> GetAttendanceByMemberId(long memberId) {
		Session session = HibernateUtil.getSession();
		
		List<Attendance> lstAtt = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Attendance WHERE MemberId=:memberId ";
			Query query = session.createQuery(strQuery);
			query.setParameter("memberId", memberId);
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

	/* (non-Javadoc)
	 * @see com.swt.sattendance.IAttendance#GetAttendanceAll()
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<Attendance> GetAttendanceAll() {
		Session session = HibernateUtil.getSession();
		
		List<Attendance> lstAtt= null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Attendance";
			Query query = session.createQuery(strQuery);
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

	@Override
	public Attendance GetBySerialAndStatus(String serialNumber, int status) {
		Session session = HibernateUtil.getSession();
		
		Attendance lstAtt= null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Attendance WHERE SerialNumber=:serialNumber AND Status=:status";
			Query query = session.createQuery(strQuery);
			query.setParameter("serialNumber", serialNumber);
			query.setParameter("status", status);
			lstAtt = (Attendance) query.uniqueResult();
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

	@SuppressWarnings("unchecked")
	@Override
	public List<Attendance> getByFilter(AttendanceFilterDto dto) {
		Session session = HibernateUtil.getSession();
		
		List<Attendance> lstAtt= null;
		
		try
		{
			String result = dto.clone();
			if(result == "")
			{
				session.getTransaction().begin();
				String strQuery = "FROM Attendance";
				Query query = session.createQuery(strQuery);
				lstAtt = query.list();
				session.getTransaction().commit();
			}
			else
			{
				session.getTransaction().begin();
				String strQuery = "FROM Attendance WHERE "+ result;
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
