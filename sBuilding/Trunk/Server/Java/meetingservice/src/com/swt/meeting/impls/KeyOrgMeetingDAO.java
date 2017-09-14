/**
 * 
 */
package com.swt.meeting.impls;

import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IKeyOrgMeeting;
import com.swt.meeting.domain.KeyOrgMeeting;

/**
 * @author Tenit
 *
 */
public class KeyOrgMeetingDAO implements IKeyOrgMeeting{

	/* (non-Javadoc)
	 * @see com.swt.meeting.IKeyOrgMeeting#getKeyOrgMeetingByKey(java.lang.String)
	 */
	@Override
	public KeyOrgMeeting getKeyOrgMeetingByKey(String key) {
		Session session = HibernateUtil.getSession();
		KeyOrgMeeting result = null;
		try {
			session.getTransaction().begin();

			// String strQuery = "FROM Meeting WHERE neocoreId = :neocoreId AND
			// neocoreStatus = true";
			String strQuery = "FROM KeyOrgMeeting WHERE key = :key";
			Query query = session.createQuery(strQuery);
			query.setParameter("key", key);
			result = (KeyOrgMeeting) query.uniqueResult();
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

			String strQuery = "UPDATE KeyOrgMeeting " + "SET meetingId = :meetingIdNew "
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
