package com.swt.meeting.impls;

import java.util.ArrayList;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IListMeeting;
import com.swt.meeting.domain.ListMeeting;

public class ListMeetingDAO implements IListMeeting {
	@Override
	public ListMeeting insert(ListMeeting listMeeting) {
		return HibernateUtil.insertObject(listMeeting);
	}

	@Override
	public ListMeeting update(ListMeeting listMeeting) {
		return HibernateUtil.updateObject(listMeeting);
	}

	@Override
	public int delete(long ListMeetingId) {
		ListMeeting ListMeeting = new ListMeeting();
		return HibernateUtil.deleteById(ListMeeting, ListMeetingId);
	}

	@Override
	public ListMeeting getListMeetingById(long listMeetingId) {
		Session session = HibernateUtil.getSession();

		ListMeeting result = new ListMeeting();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ListMeeting WHERE id = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", listMeetingId);

			result = (ListMeeting) query.uniqueResult();

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
	public List<ListMeeting> getAllListMeeting() {
		Session session = HibernateUtil.getSession();

		List<ListMeeting> result = new ArrayList<ListMeeting>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM ListMeeting";
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


	/** 
	 * danh sach cac cuoc hop theo ma thu moi hop va don vi to chuc 
	 * @param meetingInvitationId
	 * @param orgId
	 * 
	 * @return List<ListMeeting>
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<ListMeeting> getListMeetingByMeetingInvitationId(long meetingInvitationId, long orgId) {
		Session session = HibernateUtil.getSession();

		List<ListMeeting> result = new ArrayList<ListMeeting>();
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT lm.id as id, lm.meetingInvitationId as meetingInvitationId, lm.partakerId as partakerId "
					+ "FROM ListMeeting as lm, Partaker as p "
					+ "WHERE lm.partakerId = p.id AND p.orgId = :orgId AND lm.meetingInvitationId = :meetingInvitationId";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgId);
			query.setParameter("meetingInvitationId", meetingInvitationId);

			List<Object[]> personAttends = (List<Object[]>) query.list();
			session.getTransaction().commit();

			if (personAttends.size() > 0) {
				for (Object[] objectTmp : personAttends) {
					ListMeeting personAttend = new ListMeeting();
					personAttend.setId((long) objectTmp[0]);
					personAttend.setMeetingInvitationId((long) objectTmp[1]);
					personAttend.setPartakerId((long) objectTmp[2]);
					result.add(personAttend);
				}
			}
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
	public int deleteByMeetingInvitationId(long meetingInvitationId) {
		Session session = HibernateUtil.getSession();

		int result = 0;
		try {
			session.getTransaction().begin();
			String strQuery = "DELETE ListMeeting WHERE meetingInvitationId = :meetingInvitationId";
			Query query = session.createQuery(strQuery);
			query.setParameter("meetingInvitationId", meetingInvitationId);

			result = query.executeUpdate();

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
	public List<ListMeeting> getListMeetingByMeetingInvitationId(long meetingInvitationId) {
		Session session = HibernateUtil.getSession();

		List<ListMeeting> result = new ArrayList<ListMeeting>();
		try {
			session.getTransaction().begin();
			String strQuery = "SELECT lm.id as id, lm.meetingInvitationId as meetingInvitationId, lm.partakerId as partakerId "
					+ "FROM ListMeeting as lm, Partaker as p "
					+ "WHERE lm.partakerId = p.id AND lm.meetingInvitationId = :meetingInvitationId";
			Query query = session.createQuery(strQuery);
			query.setParameter("meetingInvitationId", meetingInvitationId);

			List<Object[]> personAttends = (List<Object[]>) query.list();
			session.getTransaction().commit();

			if (personAttends.size() > 0) {
				for (Object[] objectTmp : personAttends) {
					ListMeeting personAttend = new ListMeeting();
					personAttend.setId((long) objectTmp[0]);
					personAttend.setMeetingInvitationId((long) objectTmp[1]);
					personAttend.setPartakerId((long) objectTmp[2]);
					result.add(personAttend);
				}
			}
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
