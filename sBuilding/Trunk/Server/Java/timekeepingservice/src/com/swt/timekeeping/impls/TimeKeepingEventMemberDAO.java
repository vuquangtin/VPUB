package com.swt.timekeeping.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.timekeeping.ITimeKeepingEventMember;
import com.swt.timekeeping.domain.EventMember;
/**
 * TimeKeepingEventMemberDAO implements ITimeKeepingEventMember
 * @author Trang-PC
 *
 */
public class TimeKeepingEventMemberDAO implements ITimeKeepingEventMember{

	@Override
	public EventMember insert(EventMember timeKeepingEventMember) {
		return HibernateUtil.insertObject(timeKeepingEventMember);
	}
	
	@Override
	public EventMember update(EventMember timeKeepingEventMember) {
		return HibernateUtil.updateObject(timeKeepingEventMember);
	}

	@Override
	public int delete(long timeKeepingEventMemberId) {
		EventMember timeKeepingEvent = new EventMember();
		return HibernateUtil.deleteById(timeKeepingEvent, timeKeepingEventMemberId);
	}

	@Override
	public EventMember getTimeKeepingEventMemberById(long timeKeepingEventMemberId) {
		Session session = HibernateUtil.getSession();

		EventMember result = new EventMember();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM EventMember WHERE eventid = :eventid";
			Query query = session.createQuery(strQuery);
			query.setParameter("eventid", timeKeepingEventMemberId);
		
			result = (EventMember) query.uniqueResult();
			
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
	public List<EventMember> getTimeKeepingEventMemberListByEventId(long eventId) {
		Session session = HibernateUtil.getSession();

		List<EventMember> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = "FROM EventMember WHERE eventId = :eventId";
			Query query = session.createQuery(strQuery);
			query.setParameter("eventId", eventId);
		
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
	
}
