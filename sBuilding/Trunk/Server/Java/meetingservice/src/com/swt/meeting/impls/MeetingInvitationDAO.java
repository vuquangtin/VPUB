package com.swt.meeting.impls;

import java.util.ArrayList;
import java.util.List;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IMeetingInvitation;
import com.swt.meeting.domain.MeetingInvitation;

public class MeetingInvitationDAO implements IMeetingInvitation {

	@Override
	public MeetingInvitation insert(MeetingInvitation meetingInvitation) {
		return HibernateUtil.insertObject(meetingInvitation);
	}

	@Override
	public MeetingInvitation update(MeetingInvitation meetingInvitation) {
		return HibernateUtil.updateObject(meetingInvitation);
	}

	@Override
	public int delete(long meetingInvitationId) {
		MeetingInvitation meetingInvitation = new MeetingInvitation();
		return HibernateUtil.deleteById(meetingInvitation, meetingInvitationId);
	}
	// get meeting invitation by id
	@Override
	public MeetingInvitation getMeetingInvitationById(long meetingInvitationId) {
		Session session = HibernateUtil.getSession();

		MeetingInvitation result = new MeetingInvitation();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM MeetingInvitation WHERE id = :confid";
			Query query = session.createQuery(strQuery);
			query.setParameter("confid", meetingInvitationId);

			result = (MeetingInvitation) query.uniqueResult();

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
	public List<MeetingInvitation> getAllMeetingInvitation() {
		Session session = HibernateUtil.getSession();

		List<MeetingInvitation> result = new ArrayList<MeetingInvitation>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM MeetingInvitation";
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
	
	
	/*
	 * 
	 * getMeetingInvitationByBarcode
	 */
	@Override
	public MeetingInvitation getMeetingInvitationByBarcode(String barcode) {
		Session session = HibernateUtil.getSession();

		MeetingInvitation result = new MeetingInvitation();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM MeetingInvitation WHERE meetingbarcode = :barcode";
			Query query = session.createQuery(strQuery);
			query.setParameter("barcode", barcode);

			result = (MeetingInvitation) query.uniqueResult();

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
	public int deleteByBarcode(String meetingBarcode) {
		Session session = HibernateUtil.getSession();

		int result = 0;
		try {
			session.getTransaction().begin();
			String strQuery = "DELETE MeetingInvitation WHERE meetingbarcode = :barcode";
			Query query = session.createQuery(strQuery);
			query.setParameter("barcode", meetingBarcode);

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

	/* function for web
	 * @see com.swt.meeting.IMeetingInvitation#getInvitationByOrgAndMeetingId(long, long)
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<MeetingInvitation>  getInvitationByOrgAndMeetingId(long orgId, long meetingId) {
		Session session = HibernateUtil.getSession();

		List<MeetingInvitation> result = new ArrayList<MeetingInvitation>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM MeetingInvitation WHERE organizationAttendId = :orgId AND meetingid = :meetingId";
			Query query = session.createQuery(strQuery);
			query.setParameter("orgId", orgId);
			query.setParameter("meetingId", meetingId);
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
	public List<MeetingInvitation> getInvitationByMeetingId(long meetingId) {
		Session session = HibernateUtil.getSession();

		List<MeetingInvitation> result = new ArrayList<MeetingInvitation>();
		try {
			session.getTransaction().begin();
			String strQuery = "FROM MeetingInvitation WHERE meetingid = :meetingId";
			Query query = session.createQuery(strQuery);
			query.setParameter("meetingId", meetingId);
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

	@Override
	public boolean updateMeetingId(long meetingIdOld, long meetingIdNew) {
		int result = -1;
		Session session = HibernateUtil.getSession();
		try {
			session.getTransaction().begin();

			String strQuery = "UPDATE MeetingInvitation " + "SET meetingId = :meetingIdNew "
					+ "WHERE meetingId = :meetingIdOld";
			Query query = session.createQuery(strQuery);
			query.setParameter("meetingIdOld", meetingIdOld);
			query.setParameter("meetingIdNew", meetingIdNew);
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
		if(result > 1){
			return true;
		}else{
			return false;
		}
	}
}
