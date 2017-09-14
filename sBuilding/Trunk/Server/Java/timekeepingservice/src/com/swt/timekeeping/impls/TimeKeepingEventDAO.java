package com.swt.timekeeping.impls;

import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.timekeeping.ITimeKeepingEvent;
import com.swt.timekeeping.customer.object.EventFilter;
import com.swt.timekeeping.domain.Event;

/**
 * TimeKeepingEventDAO implements ITimeKeepingEvent
 * 
 * @author TrangPig
 *
 */
public class TimeKeepingEventDAO implements ITimeKeepingEvent {

	@Override
	public Event insert(Event timeKeepingEvent) {
		return HibernateUtil.insertObject(timeKeepingEvent);
	}

	@Override
	public Event update(Event timeKeepingEvent) {
		return HibernateUtil.updateObject(timeKeepingEvent);
	}

	@Override
	public int delete(long timeKeepingEventId) {
		Event timeKeepingEvent = new Event();
		return HibernateUtil.deleteById(timeKeepingEvent, timeKeepingEventId);
	}

	@Override
	public Event getTimeKeepingEventById(long timeKeepingEventId) {
		Session session = HibernateUtil.getSession();

		Event result = new Event();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM Event WHERE eventid = :eventid";
			Query query = session.createQuery(strQuery);
			query.setParameter("eventid", timeKeepingEventId);

			result = (Event) query.uniqueResult();

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
	public List<Event> getTimeKeepingEventListByOrgId(EventFilter eventFilter,
			long orgId) {
		Session session = HibernateUtil.getSession();

		List<Event> result = null;
		try {
			session.getTransaction().begin();
			String strQuery = eventFilter.clone(orgId, -1);
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
	public List<Event> getTimeKeepingEventListBySubOrgId(
			EventFilter eventFilter, long orgId, long suborgId) {
		Session session = HibernateUtil.getSession();

		List<Event> result = null;
		try {

			session.getTransaction().begin();
			String strQuery = eventFilter.clone(orgId, suborgId);
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
	public List<Event> getListEventByDateForMember(long memberId, String date) {
		Session session = HibernateUtil.getSession();

		List<Event> result = null;
		try {

			session.getTransaction().begin();

			String strQuery = "SELECT ev FROM EventMember evm, Event ev WHERE evm.eventId = ev.eventId  AND evm.memberId"
					+ "= :memId AND dateIn BETWEEN '"
					+ date
					+ " 00:00:00' AND '" + date + " :23:59:59'";
			Query query = session.createQuery(strQuery);
			query.setParameter("memId", memberId);

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
